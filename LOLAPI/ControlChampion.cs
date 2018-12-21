using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Data.SqlClient;

namespace LOLAPI
{
    public partial class ControlChampion : UserControl
    {
        public ControlChampion()
        {
            InitializeComponent();
        }
        public static List<Champion> champions;
        private void ControlChampion_Load(object sender, EventArgs e)
        {
            champions = new List<Champion>();

            #region DB에서 데이터 뽑기
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "SelectChampion";

                SqlDataReader dr = com.ExecuteReader();


                while (dr.Read())
                {
                    string id = dr["id"].ToString();
                    int key = int.Parse(dr["key"].ToString());
                    string name = dr["name"].ToString();
                    string title = dr["title"].ToString();
                    string blurb = dr["blurb"].ToString();
                    string full = dr["full"].ToString();
                    string tags = dr["tags"].ToString();

                    byte[] array = (byte[])dr["chamImage"];
                    MemoryStream ms = new MemoryStream(array);
                    Image cImage = Image.FromStream(ms);
                    //item.Image = image;

                    array = (byte[])dr["loadImage"];
                    ms = new MemoryStream(array);
                    Image loadImage = Image.FromStream(ms);

                    string[] tag = tags.Split(',');

                    champions.Add(new Champion { Id = id, Key = key, Name = name, Title = title, Blurb = blurb, Full = full, Tags = tag, ChamImage = cImage, LoadImage = loadImage });
                }

                dr.Close();
                con.Close();
            }

            foreach (var item in champions)
            {
                using (SqlConnection con = DBConnection.Connecting())
                {
                    con.Open();
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "SelectInfo";

                    SqlDataReader dr = com.ExecuteReader();

                    while (dr.Read())
                    {
                        int attack = int.Parse(dr["attack"].ToString());
                        int defense = int.Parse(dr["defense"].ToString());
                        int magic = int.Parse(dr["magic"].ToString());
                        int difficulty = int.Parse(dr["difficulty"].ToString());

                        item.Info = new ChampionInfo { Defense = defense, Attack = attack, Magic = magic, Difficulty = defense };
                    }

                    dr.Close();
                    con.Close();
                }
            }

            #endregion


            #region Json 챔피언 정보 데이터 뽑기
            //string serverUrl = "http://ddragon.leagueoflegends.com/cdn/8.24.1/data/ko_KR/champion.json";

            //var req = WebRequest.Create(serverUrl) as HttpWebRequest;
            //var res = req.GetResponse() as HttpWebResponse;
            //var stream = res.GetResponseStream();
            //var sr = new StreamReader(stream, Encoding.UTF8);
            //var json = sr.ReadToEnd();

            //JObject jObj = JObject.Parse(json);
            //JObject jsondata = JObject.Parse(jObj["data"].ToString());

            //List<string> ll = new List<string>();

            //foreach (var item in JObject.Parse(jObj["data"].ToString()))
            //{
            //    string id = item.Key; // 챔피언 이름
            //    string key = item.Value["key"].ToString(); // 챔피언 id
            //    string name = item.Value["name"].ToString(); // 챔피언 한글이름
            //    string title = item.Value["title"].ToString(); // 챔피언 타이틀
            //    string blurb = item.Value["blurb"].ToString(); // 챔피언 배경설명
            //    var itemArr = JArray.Parse(item.Value["tags"].ToString());
            //    foreach (var item2 in itemArr)
            //    {
            //        ll.Add(item2.ToString());
            //    }


            //    champions.Add(new Champion { Id = id, Key = int.Parse(key), Name = name, Title = title, Blurb = blurb, Tags = ll.ToArray() });
            //}

            // 챔피언 스탯
            //string[] statsArr = { "hp", "hpperlevel", "mp","mpperlevel","movespeed","armor","armorperlevel","spellblock",
                //"spellblockperlevel","attackrange","hpregen","hpregenperlevel","mpregen","mpregenperlevel",
                //"attackdamage","attackdamageperlevel","attackspeedperlevel","attackspeed" };
            // 챔피언 정보 4가지
            //string[] infoArr = { "attack", "defense", "magic", "difficulty" };
            //foreach (var item in infoArr)
            //{
            //    MessageBox.Show(jObj["data"][name]["info"][item].ToString());
            //}

            // 챔피언 이미지
            // jObj["data"]["Aatrox"]["image"]["full"].ToString();
            

            //string chName = String.Empty;
            //foreach (var item in champions)
            //{
            //    chName = item.Id;
            //    JObject jsonCham = ReJObject(chName);

            //    string full = jObj["data"][chName]["image"]["full"].ToString();
            //    item.Full = full;

            //    foreach (var chamItem in JObject.Parse(jsonCham.ToString()))
            //    {
            //        string[] strStat = new string[18];
            //        int i = 0;

            //        // 스탯
            //        foreach (var statsItem in statsArr)
            //        {
            //            strStat[i++] = jsonCham[chName]["stats"][statsItem].ToString();
            //            //MessageBox.Show(jObj["data"][chName]["stats"][statsItem].ToString());
            //        }
            //        // "hp", "hpperlevel", "mp","mpperlevel","movespeed","armor","armorperlevel","spellblock",
            //        //"spellblockperlevel","attackrange","hpregen","hpregenperlevel","mpregen","mpregenperlevel",
            //        //"attackdamage","attackdamageperlevel","attackspeedperlevel","attackspeed"
            //        //item.Hp = float.Parse(strStat[0]);
            //        //item.Hpperlevel = float.Parse(strStat[1]);
            //        //item.Mp = float.Parse(strStat[2]);
            //        //item.Mpperlevel = float.Parse(strStat[3]);
            //        //item.Movespeed = float.Parse(strStat[4]);
            //        //item.Armor = float.Parse(strStat[5]);
            //        //item.Armorperlevel = float.Parse(strStat[6]);
            //        //item.Spellblock = float.Parse(strStat[7]);
            //        //item.Spellblockperlevel = float.Parse(strStat[8]);
            //        //item.Attackrange = float.Parse(strStat[9]);
            //        //item.Hpregen = float.Parse(strStat[10]);
            //        //item.Hpregenperlevel = float.Parse(strStat[11]);
            //        //item.Mpregen = float.Parse(strStat[12]);
            //        //item.Mpregenperlevel = float.Parse(strStat[13]);
            //        //item.Attackdamage = float.Parse(strStat[14]);
            //        //item.Attackdamageperlevel = float.Parse(strStat[15]);
            //        //item.Attackspeed = float.Parse(strStat[16]);
            //        //item.Attackspeedperlevel = float.Parse(strStat[17]);
            //    }

            //    foreach (var chamItem in JObject.Parse(jsonCham.ToString()))
            //    {
            //        string[] strInfo = new string[4];
            //        int i = 0;
            //        foreach (var infoItem in infoArr)
            //        {
            //            strInfo[i++] = jsonCham[chName]["info"][infoItem].ToString();
            //            //MessageBox.Show(jObj["data"][chName]["info"][infoItem].ToString());
            //        }
            //        item.Info = new ChampionInfo { Attack = int.Parse(strInfo[0]), Defense = int.Parse(strInfo[1]),
            //            Magic = int.Parse(strInfo[2]), Difficulty = int.Parse(strInfo[3]) };
            //    }

            //    List<Skin> skin = new List<Skin>();
            //    foreach (var chamSkin in JArray.Parse(jsonCham[chName]["skins"].ToString()))
            //    {
            //        skin.Add(new Skin { Num = Int32.Parse(chamSkin["num"].ToString()), Name = chamSkin["name"].ToString() });
            //    }
            //    item.Skin = skin.ToArray();

            //    List<Spells> spells = new List<Spells>();
            //    foreach (var chamSpell in JArray.Parse(jsonCham[chName]["spells"].ToString()))
            //    {
            //        string id = chamSpell["id"].ToString();
            //        string name = chamSpell["name"].ToString();
            //        string description = chamSpell["description"].ToString();
            //        string tooltip = chamSpell["tooltip"].ToString();
            //        List<int> cost = new List<int>();
            //        foreach (var chCost in JArray.Parse(chamSpell["cost"].ToString()))
            //        {
            //            cost.Add(int.Parse(chCost.ToString()));
            //        }
            //        List<int> range = new List<int>();
            //        foreach (var chrang in JArray.Parse(chamSpell["range"].ToString()))
            //        {
            //            range.Add(int.Parse(chrang.ToString()));
            //        }
            //        string image = chamSpell["image"]["full"].ToString();

            //        spells.Add(new Spells { Id = id, Name = name, Description = description, Tooltip = tooltip, Cost = cost.ToArray(), Range = range.ToArray(), Full = image });
            //    }
            //    item.Spell = spells.ToArray();

            //    item.Passive = new Passive
            //    {
            //        Name = jsonCham[chName]["passive"]["name"].ToString(),
            //        Description = jsonCham[chName]["passive"]["description"].ToString(),
            //        Full = jsonCham[chName]["passive"]["image"]["full"].ToString()
            //    };
            //}
            #endregion

            #region 이미지 처리
            //Image chamImage;
            //WebClient w = new WebClient();
            //imageList1.ImageSize = new Size(64, 64);
            //string imageURL = string.Empty;
            //int imgIndex = 0;
            //foreach (var item in champions)
            //{
            //    imageURL = "http://ddragon.leagueoflegends.com/cdn/8.24.1/img/champion/" + item.Full;
            //    byte[] imageByte = w.DownloadData(imageURL);
            //    MemoryStream imagestream = new MemoryStream(imageByte);
            //    chamImage = Image.FromStream(imagestream);
            //    this.imageList1.Images.Add(chamImage);
            //    this.listView1.Items.Add(item.Name, imgIndex++);
            //}

            //this.listView1.LargeImageList = imageList1;
            #endregion

            // 로딩 이미지 추가
            // http://ddragon.leagueoflegends.com/cdn/img/champion/loading/Aatrox_0.jpg // 챔피언 로딩 사진

            // 스킨 이미지 추가
            // http://ddragon.leagueoflegends.com/cdn/img/champion/splash/Aatrox_0.jpg // 챔피언 스킨 사진

            // details
            
        }

        private JObject ReJObject(string name)
        {
            string serverUrl = "http://ddragon.leagueoflegends.com/cdn/8.24.1/data/ko_KR/champion/" + name + ".json";
            var req = WebRequest.Create(serverUrl) as HttpWebRequest;
            var res = req.GetResponse() as HttpWebResponse;
            var stream = res.GetResponseStream();
            var sr = new StreamReader(stream, Encoding.UTF8);
            var json = sr.ReadToEnd();

            JObject jObj = JObject.Parse(json);

            return JObject.Parse(jObj["data"].ToString());
        }
        
        #region 체크박스
        private void checkBox1_CheckedChanged(object sender, EventArgs e) // 암살자
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) // 전사
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) // 마법사
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e) // 서포터
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e) // 탱커
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e) // 원거리 딜러
        {

        }
        #endregion
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)   // 아이템이 선택되지 않았을 경우(선택 취소) - 예외처리
            {
                MessageBox.Show(listView1.SelectedItems[0].Text);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                this.listView1.View = View.LargeIcon;
            }
            else
            {
                this.listView1.View = View.Details;
            }
        }
    }
}
