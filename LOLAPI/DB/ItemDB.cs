using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI.DAO
{
    class ItemDB
    {
        public void InsertItem(List<LOLItem> itemList)
        {
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();
                foreach (var item in itemList)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertItem";
                    cmd.Parameters.AddWithValue("code", item.Code);
                    cmd.Parameters.AddWithValue("name", item.Name);
                    cmd.Parameters.AddWithValue("description", item.Description);
                    cmd.Parameters.AddWithValue("plaintext", item.Plaintext);
                    cmd.Parameters.AddWithValue("imagename", item.ImageName);
                    cmd.Parameters.AddWithValue("gold", item.Gold);

                    string from = "";
                    if (item.From != null)
                    {
                        foreach (var fromArr in item.From)
                        {
                            from += fromArr + ",";
                        }

                        from = from.Substring(0, from.Length - 1);
                    }
                    cmd.Parameters.AddWithValue("from", from);

                    string into = "";
                    if (item.Into != null)
                    {
                        foreach (var intoArr in item.Into)
                        {
                            into += intoArr + ",";
                        }

                        into = into.Substring(0, into.Length - 1);
                    }
                    cmd.Parameters.AddWithValue("into", into);

                    string tags = "";
                    if (item.Tags != null)
                    {
                        foreach (var tagsArr in item.Tags)
                        {
                            tags += tagsArr + ",";
                        }

                        tags = tags.Substring(0, tags.Length - 1);
                    }
                    cmd.Parameters.AddWithValue("tags", tags);

                    MemoryStream ms = new MemoryStream();
                    item.Image.Save(ms, item.Image.RawFormat);

                    cmd.Parameters.AddWithValue("image", ms.ToArray());

                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        public List<LOLItem> SelectItem(List<LOLItem> itemList) // 버전 체크
        {
            
            string version = String.Empty;
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectItem";

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    LOLItem item = new LOLItem();
                    item.Code = sdr["code"].ToString();
                    item.Name = sdr["name"].ToString();
                    item.Description = sdr["description"].ToString();
                    item.Plaintext = sdr["plaintext"].ToString();
                    item.ImageName = sdr["imagename"].ToString();
                    item.Gold = int.Parse(sdr["gold"].ToString());
                    item.From = sdr["from"].ToString().Split(',');
                    item.Into = sdr["into"].ToString().Split(',');
                    item.Tags = sdr["tags"].ToString().Split(',');
                                        
                    byte[] array = (byte[])sdr["image"];
                    MemoryStream ms = new MemoryStream(array);
                    Image image = Image.FromStream(ms);
                    item.Image = image;
                    itemList.Add(item);
                }

                con.Close();
            }

            return itemList;
        }
    }
}
