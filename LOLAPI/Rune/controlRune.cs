using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LOLAPI.JSON;
using LOLAPI.DB;
using Newtonsoft.Json.Linq;

namespace LOLAPI
{
    public partial class controlRune : UserControl
    {
        List<Rune> runeList = new List<Rune>(); // 최상위 룬 저장 리스트
        List<InnerRune> innerRuneList = new List<InnerRune>(); // 안쪽 룬 저장 리스트
        List<List<string>> slotsList = new List<List<string>>(); // 소속 룬 계층 저장 리스트

        List<string> runeNameList = new List<string>();

        Version version = new Version();
        JsonWork jsonWork = new JsonWork();
        RuneDB runeDAO = new RuneDB();
        VersionDB versionDAO = new VersionDB();

        public controlRune()
        {
            InitializeComponent();
        }

        private void controlRune_Load(object sender, EventArgs e)
        {
            string SelectQuery = "select runeVersion from Version";

            string latestVersion = version.CheckLatestVersion(); // 최신버전
            string nowVersion = versionDAO.SelectVersion(SelectQuery); // 현재 버전

            lblVersion.Text = "버전 : " + latestVersion;


            if (version.VersionUpdate(latestVersion, nowVersion)) // 최신 버전이면 DB에서 가져오기 
            {
                runeList = runeDAO.SelectRune(runeList); // DB에서 RuneList 가져오기
                innerRuneList = runeDAO.SelectInnerRune(innerRuneList);
            }
            else // 최신 버전이 아니면 DB 업데이트
            {
                CreateItemJsonData(latestVersion); // RuneList 리셋
                runeDAO.InsertRune(runeList); // DB에 RuneList 저장
                runeDAO.InsertInnerRune(innerRuneList);
                string updateQuery = "update Version set runeVersion='" + latestVersion + "'";
                versionDAO.UpdateVersion(updateQuery);
                MessageBox.Show("Json에서 Rune 뽑아오기 완료");
            }

            SetButtonImage();
            SetRune();
        }

        private void SetButtonImage()
        {
            foreach (Button item in panel1.Controls)
            {
                foreach (var rune in runeList)
                {
                    if (item.Name.Contains(rune.Name))
                    {
                        item.Image = rune.Image;

                    }
                }

            }
        }

        private void SetRune()
        {
            //foreach (var item in runeList)
            //{
            //    foreach (var item2 in item.Slots)
            //    {
            //        foreach (var item3 in item2)
            //        {
            //            textBox1.Text += item3 + "    ";
            //        }
            //        textBox1.Text += "\r\n";

            //    }
            //}
        }

        private void CreateItemJsonData(string version) // Json 가져와 List에 저장하는 메서드
        {
            runeList.Clear();
            innerRuneList.Clear();

            JArray jArr = JArray.Parse(jsonWork.GetJsonFromWeb("http://ddragon.leagueoflegends.com/cdn/" + version + "/data/ko_KR/runesReforged.json"));

            foreach (JObject rune in jArr)
            {
                Rune r = new Rune();
                r.Id = int.Parse(rune["id"].ToString());
                r.Key = rune["key"].ToString();
                r.Name = rune["name"].ToString();
                r.Image = jsonWork.GetJsonImageFromWeb("http://ddragon.leagueoflegends.com/cdn/img/" + rune["icon"].ToString());

                JArray slots = JArray.Parse(rune["slots"].ToString());

                foreach (var item in slots)
                {
                    JArray innerRune = JArray.Parse(item["runes"].ToString());

                    List<string> ii = new List<string>();

                    foreach (JObject inRune in innerRune)
                    {
                        InnerRune ir = new InnerRune();

                        ir.Id = int.Parse(inRune["id"].ToString());
                        ir.Key = inRune["key"].ToString();
                        ir.Image = jsonWork.GetJsonImageFromWeb("http://ddragon.leagueoflegends.com/cdn/img/" + inRune["icon"].ToString());
                        ir.Name = inRune["name"].ToString();
                        ir.ShortDesc = inRune["shortDesc"].ToString();
                        ir.LongDesc = inRune["longDesc"].ToString();

                        ii.Add(rune["id"].ToString() + ":" + inRune["id"].ToString());

                        innerRuneList.Add(ir);
                    }

                    slotsList.Add(ii);
                }
                r.Slots = slotsList;

                runeList.Add(r);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            this.Controls.RemoveByKey("runePanel");

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Name = "runePanel";
            panel.Visible = true;
            panel.Location = new Point(39, 160);
            panel.Size = new Size(1000, 500);

            panel.BringToFront();

            this.Controls.Add(panel);

            Button b = (Button)sender;

            foreach (var rune in runeList)
            {
                if (b.Name.Contains(rune.Name))
                {
                    panel.BackgroundImage = Image.FromFile(@"C:\Users\GD1\Desktop\Lol\LOLAPI\Resources\" + rune.Name + ".jpg");
                    panel.BackgroundImageLayout = ImageLayout.Stretch;

                    foreach (var slots in rune.Slots)
                    {
                        FlowLayoutPanel firstPanel = new FlowLayoutPanel();
                        firstPanel.Size = new Size(900, 100);
                        panel.Controls.Add(firstPanel);
                        Button mainButton = new Button();
                        mainButton.Name = "MainButton";

                        mainButton.Size = new Size(100, 90);
                        firstPanel.Controls.Add(mainButton);
                        
                        foreach (var innerRune in slots)
                        {
                            Button subButton = new Button();
                            subButton.Click += new EventHandler(this.btnInnerRune_Click);
                            foreach (var item in innerRuneList)
                            {
                                if (innerRune.Contains(item.Id.ToString()))
                                {   
                                    subButton.Name = item.Name;
                                    subButton.Size = new Size(80, 80);
                                    subButton.BackgroundImage = item.Image;
                                    subButton.BackgroundImageLayout = ImageLayout.Stretch;
                                }
                            }
                            firstPanel.Controls.Add(subButton);
                        }
                    }
                }
            }
        }       

        private void btnInnerRune_Click(object sender, EventArgs e)
        {            
            Button b = (Button)sender;             
            FlowLayoutPanel firstPanel = (FlowLayoutPanel)b.Parent;

            foreach (Button item in firstPanel.Controls)
            {
                if (item.Name.Equals("MainButton"))
                {   
                    item.BackgroundImage = b.BackgroundImage;
                    item.BackgroundImageLayout = ImageLayout.Stretch;
                    item.Refresh();
                }
            }
        }
    }
}
