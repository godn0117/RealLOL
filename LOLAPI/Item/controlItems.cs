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
using Newtonsoft.Json.Linq;
using LOLAPI.DAO;
using LOLAPI.JSON;
using LOLAPI.Item;
using System.Resources;
using System.Reflection;

namespace LOLAPI
{
    public partial class controlItems : UserControl
    {
        List<string> itemNumberList = new List<string>(); // 아이템 코드 번호 리스트
        internal static List<LOLItem> itemList = new List<LOLItem>(); // 아이템 객체 리스트

        List<ListViewItem> listItemList = new List<ListViewItem>(); // 리스트아이템 리스트        

        List<string> newList = new List<string>(); // 조건에 걸러진 아이템들 

        List<string> selectedMenu = new List<string>(); // 조건 리스트

        VersionDB versionDAO = new VersionDB();
        ItemDB itemDAO = new ItemDB();
        Version version = new Version();
        JsonWork jsonWork = new JsonWork();

        public Assembly Assemble { get; private set; }

        public controlItems()
        {
            InitializeComponent();
        }               

        private void controlItems_Load(object sender, EventArgs e) // 로드
        {   
            string SelectQuery = "select itemVersion from Version";

            string latestVersion = version.CheckLatestVersion(); // 최신버전
            string nowVersion = versionDAO.SelectVersion(SelectQuery); // 현재 버전

            lblVersion.Text = "버전 : " + latestVersion;

            if (version.VersionUpdate(latestVersion, nowVersion)) // 최신 버전이면 DB에서 가져오기 
            {
                itemList = itemDAO.SelectItem(itemList); // DB에서 ItemList 가져오기
            }
            else // 최신 버전이 아니면 DB 업데이트
            {
                CreateItemJsonData(latestVersion); // ItemList 리셋
                itemDAO.InsertItem(itemList); // DB에 ItemList 저장
                
                string updateQuery = "update Version set itemVersion='" + latestVersion+"'";
                versionDAO.UpdateVersion(updateQuery);
            }

            MakeListViewItem();
            CheckedChanged(null, null);
        }

        private void MakeListViewItem() // 리스트뷰아이템을 만들어 리스트에 아이템 등록
        {
            ImageList imageList = new ImageList();

            this.listView1.View = View.LargeIcon;

            foreach (LOLItem item in itemList)
            {
                imageList.Images.Add(item.Name, item.Image);

                imageList.ImageSize = new Size(64, 64);
                this.listView1.LargeImageList = imageList;


                ListViewItem lItem = new ListViewItem();
                lItem.Name = item.Name;
                lItem.Text = item.Name;
                lItem.ImageKey = item.Name;

                listItemList.Add(lItem);


            }

            

            
        }

        //private void MakeListViewItem2(List<string> newList) // 리스트뷰아이템을 만들어 리스트에 아이템 등록
        //{
        //    ImageList imageList = new ImageList();

        //    this.listView1.View = View.LargeIcon;

        //    foreach (var nitem in newList)
        //    {
        //        foreach (LOLItem item in itemList)
        //        {
        //            if (nitem.Equals(item.Name))
        //            {
        //                imageList.Images.Add(item.Code, item.Image);

        //                imageList.ImageSize = new Size(64, 64);
        //                this.listView1.LargeImageList = imageList;


        //                ListViewItem lItem = new ListViewItem();
        //                lItem.Name = item.Code;
        //                lItem.Text = item.Name;
        //                lItem.ImageKey = item.Code;

        //                listView1.Items.Add(lItem);
        //            }                    
        //        }
        //    }            
        //}

        private void CreateItemJsonData(string version) // Json 가져와 List에 저장하는 메서드
        {
            itemList.Clear();

            JObject jObject = JObject.Parse(jsonWork.GetJsonFromWeb("http://ddragon.leagueoflegends.com/cdn/" + version + "/data/ko_KR/item.json"));
            JObject j = JObject.Parse(jObject["data"].ToString());

            foreach (var item in j)
            {
                itemNumberList.Add(item.Key);
            }

            foreach (var number in itemNumberList)
            {
                LOLItem item = new LOLItem();
                item.Code = number;
                item.Name = jObject["data"][number]["name"].ToString();
                item.Description = jObject["data"][number]["description"].ToString().Replace("<groupLimit>", "").Replace("</groupLimit>", "").Replace("<passive>", "").Replace("</passive>", "").Replace("<br>", "").Replace("</br>", "").Replace("<unique>", "").Replace("</unique>", "").Replace("<stats>", "").Replace("</stats>", "").Replace("<mana>", "").Replace("</mana>", "").Replace("<consumable>", "").Replace("</consumable>", "").Replace("<u>", "").Replace("</u>", "").Replace("<rules>", "").Replace("</rules>", "").Replace("<levelLimit>", "").Replace("</levelLimit>", "").Replace("<mainText>", "").Replace("</mainText>", "").Replace("<active>", "").Replace("</active>", "").Replace("<i>", "").Replace("</i>", "").Replace("<unlockedPassive>", "").Replace("</unlockedPassive>", "").Replace("<hr>", "").Replace("</hr>", "");
                item.Plaintext = jObject["data"][number]["plaintext"].ToString();
                item.ImageName = jObject["data"][number]["image"]["full"].ToString();
                item.Gold = int.Parse(jObject["data"][number]["gold"]["base"].ToString());
                item.Tags = jObject["data"][number]["tags"].ToString().Split(',');
                item.Image = jsonWork.GetJsonImageFromWeb("http://ddragon.leagueoflegends.com/cdn/" + version + "/img/item/" + jObject["data"][number]["image"]["full"].ToString());
                if (item.Image == null)
                {
                    item.Image = Image.FromFile(@"C:\1.PNG");
                }
                try
                {
                    item.From = jObject["data"][number]["from"].ToString().Split(',');
                }
                catch (Exception)
                {
                    item.From = null;
                }
                try
                {
                    item.Into = jObject["data"][number]["into"].ToString().Split(',');
                }
                catch (Exception)
                {
                    item.Into = null;
                }

                itemList.Add(item);
            }
        }       

        private void CheckedChanged(object sender, EventArgs e) // 메뉴 선택되었는지 확인하는 메서드
        {
            selectedMenu.Clear();
            foreach (CheckBox item in groupBoxDefence.Controls)
            {
                if (item.Checked)
                {
                    selectedMenu.Add(item.Name.Replace("chk", ""));
                }
            }

            foreach (CheckBox item in groupBoxAttack.Controls)
            {
                if (item.Checked)
                {
                    selectedMenu.Add(item.Name.Replace("chk", ""));
                }
            }

            foreach (CheckBox item in groupBoxMagic.Controls)
            {
                if (item.Checked)
                {
                    selectedMenu.Add(item.Name.Replace("chk", ""));
                }
            }

            newList.Clear();
            CopyNameToNewList();
            listView1.Clear();

            foreach (var selected in selectedMenu)
            {
                ChangeListItemBySelectedMenu(itemList, listView1.Items, selected);
            }

            //MakeListViewItem2(newList);
            foreach (var item in newList)
            {

                foreach (ListViewItem listItem in listItemList)
                {
                    if (item.Equals(listItem.Text))
                    {
                        listView1.Items.Add((ListViewItem)listItem.Clone());

                    }
                }
            }
        }

        private void CopyNameToNewList() // newList 초기화
        {
            foreach (var item in itemList)
            {
                newList.Add(item.Name);
            }
        }

        // tag가 존재하는지 확인해서 newList
        private void ChangeListItemBySelectedMenu(List<LOLItem> itemList, ListView.ListViewItemCollection items, string selected)
        {
            foreach (var item in itemList)
            {
                bool isExist = false;
                foreach (var tag in item.Tags)
                {
                    if (tag.Replace("[", "").Replace("]", "").Replace("\"", "").Trim().Equals(selected)) // 태그가 존재
                    {
                        isExist = true;
                    }
                }

                if (isExist == false)
                {
                    if (newList.IndexOf(item.Name) != -1)
                    {                        
                        newList.RemoveAt(newList.IndexOf(item.Name));
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            foreach (var item in newList)
            {
                if (item.Contains(txtSearch.Text.Trim()))
                {
                    foreach (ListViewItem listItem in listItemList)
                    {
                        if (item.Equals(listItem.Name))
                        {                             
                            
                            listView1.Items.Add((ListViewItem)listItem.Clone());
                            
                        }
                    }
                }
            }
        }

        private void listView1_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e) // 툴팁 옵션
        {            
            ToolTip toolTip = new ToolTip();
            toolTip.ReshowDelay = 0;
            
            foreach (var item in itemList)
            {
                if (e.Item.Text.Equals(item.Name))
                {
                    string s = item.Name + "\r\n" + item.Plaintext + "\n" + item.Description + "\n" + "가격 : " + item.Gold + "GOLD";
                    toolTip.SetToolTip(listView1, s);
                    break;
                }
            }
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DetailItem detailItem = new DetailItem();

            if (listView1.SelectedItems.Count > 0)   
            {
                if (detailItem != null)
                {
                    detailItem.Close();
                }
                LOLItem lItem = new LOLItem();

                foreach (var item in itemList)
                {
                    if (listView1.SelectedItems[0].Text.Equals(item.Name))
                    {
                        lItem = item;

                        detailItem = new DetailItem(lItem);
                        detailItem.Show();
                        detailItem.Focus();
                        break;
                    }
                }
                

            }
        }
    }
}
