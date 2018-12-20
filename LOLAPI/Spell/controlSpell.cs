using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using LOLAPI.JSON;
using LOLAPI.DB;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.ListViewItem;

namespace LOLAPI
{
    public partial class controlSpell : UserControl
    {
        List<Spell> spellList = new List<Spell>();
        List<string> spellNameList = new List<string>();

        Version version = new Version();
        JsonWork jsonWork = new JsonWork();
        SpellDB spellDAO = new SpellDB();
        VersionDB versionDAO = new VersionDB();

        public controlSpell()
        {
            InitializeComponent();
        }

        private void controlSpell_Load(object sender, EventArgs e)
        {
            string SelectQuery = "select spellVersion from Version";

            string latestVersion = version.CheckLatestVersion(); // 최신버전
            string nowVersion = versionDAO.SelectVersion(SelectQuery); // 현재 버전

            lblVersion.Text = "버전 : " + latestVersion;

            if (version.VersionUpdate(latestVersion, nowVersion)) // 최신 버전이면 DB에서 가져오기 
            {
                spellList = spellDAO.SelectSpell(spellList); // DB에서 ItemList 가져오기
            }
            else // 최신 버전이 아니면 DB 업데이트
            {
                CreateItemJsonData(latestVersion); // ItemList 리셋
                spellDAO.InsertSpell(spellList); // DB에 ItemList 저장

                string updateQuery = "update Version set spellVersion='" + latestVersion + "'";
                versionDAO.UpdateVersion(updateQuery);
            }

            MakeListViewItem();
        }        

        private void MakeListViewItem() // 리스트뷰아이템을 만들어 리스트에 아이템 등록
        {
            listView1.Clear();

            ImageList imageList = new ImageList();
            this.listView1.View = View.Details;

            
            listView1.Columns.Add("이름", 150);
            listView1.Columns.Add("재사용 대기 시간", 150);
            listView1.Columns.Add("소환사 레벨", 130);
            listView1.Columns.Add("설명", 1500);

            foreach (Spell spell in spellList)
            {
                imageList.Images.Add(spell.Name, spell.Image);

                imageList.ImageSize = new Size(32, 32);
                this.listView1.LargeImageList = imageList;
                this.listView1.SmallImageList = imageList;
                
                ListViewItem lItem = new ListViewItem();
                lItem.Name = spell.Name;
                lItem.Text = spell.Name;
                lItem.ImageKey = spell.Name;

                ListViewSubItem subItemCoolDownBurn = new ListViewSubItem();
                subItemCoolDownBurn.Name = spell.CooldownBurn;
                subItemCoolDownBurn.Text = spell.CooldownBurn;

                ListViewSubItem summonerLevel = new ListViewSubItem();
                summonerLevel.Name = spell.SummonerLevel.ToString();
                summonerLevel.Text = spell.SummonerLevel.ToString();

                ListViewSubItem description = new ListViewSubItem();
                description.Name = spell.Description;
                description.Text = spell.Description;


                lItem.SubItems.Add(subItemCoolDownBurn);
                lItem.SubItems.Add(summonerLevel);
                lItem.SubItems.Add(description);

                //    modes
                listView1.Items.Add(lItem);
            }
        }

        private void CreateItemJsonData(string version) // Json 가져와 List에 저장하는 메서드
        {
            spellList.Clear();
        
            JObject jObject = JObject.Parse(jsonWork.GetJsonFromWeb("http://ddragon.leagueoflegends.com/cdn/" + version + "/data/ko_KR/summoner.json"));
            JObject j = JObject.Parse(jObject["data"].ToString());

            foreach (var item in j)
            {
                spellNameList.Add(item.Key);
            }

            foreach (var number in spellNameList)
            {
                Spell spell = new Spell();
                spell.ID = number;
                spell.Name = jObject["data"][number]["name"].ToString();
                spell.Description = jObject["data"][number]["description"].ToString().Replace("<groupLimit>", "").Replace("</groupLimit>", "").Replace("<passive>", "").Replace("</passive>", "").Replace("<br>", "").Replace("</br>", "").Replace("<unique>", "").Replace("</unique>", "").Replace("<stats>", "").Replace("</stats>", "").Replace("<mana>", "").Replace("</mana>", "").Replace("<consumable>", "").Replace("</consumable>", "").Replace("<u>", "").Replace("</u>", "").Replace("<rules>", "").Replace("</rules>", "").Replace("<levelLimit>", "").Replace("</levelLimit>", "").Replace("<mainText>", "").Replace("</mainText>", "").Replace("<active>", "").Replace("</active>", "").Replace("<i>", "").Replace("</i>", "").Replace("<unlockedPassive>", "").Replace("</unlockedPassive>", "").Replace("<hr>", "").Replace("</hr>", "");
                spell.CooldownBurn = jObject["data"][number]["cooldownBurn"].ToString();                
                spell.Key = jObject["data"][number]["key"].ToString();
                spell.SummonerLevel = int.Parse(jObject["data"][number]["summonerLevel"].ToString());
                spell.RangeBurn = jObject["data"][number]["rangeBurn"].ToString();
                spell.Modes = jObject["data"][number]["rangeBurn"].ToString().Split(',');            
                spell.Image = jsonWork.GetJsonImageFromWeb("http://ddragon.leagueoflegends.com/cdn/" + version + "/img/spell/" + jObject["data"][number]["image"]["full"].ToString());

                if (spell.Image == null)
                {
                    spell.Image = Image.FromFile(@"C:\1.PNG");
                }
                
                spellList.Add(spell);
            }
        }         
    }
}
