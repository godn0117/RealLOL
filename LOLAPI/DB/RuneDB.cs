using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI.DB
{
    class RuneDB
    {
        public void InsertRune(List<Rune> runeList)
        {
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();
                
                foreach (var rune in runeList)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertRune";
                    cmd.Parameters.AddWithValue("Id", rune.Id);
                    cmd.Parameters.AddWithValue("key", rune.Key);
                    cmd.Parameters.AddWithValue("name", rune.Name);

                    string slots = "";
                    
                    if (rune.Slots != null)
                    {
                        foreach (List<string> item in rune.Slots)
                        {
                            slots += "/";
                            foreach (string item2 in item)
                            {
                                if (item2.Contains(rune.Id.ToString()))
                                {
                                    slots += item2 + ",";
                                }
                            }
                        }
                        slots = slots.Substring(0, slots.Length - 1);
                    }

                    cmd.Parameters.AddWithValue("slots", slots);

                    MemoryStream ms = new MemoryStream();
                    rune.Image.Save(ms, rune.Image.RawFormat);

                    cmd.Parameters.AddWithValue("image", ms.ToArray());

                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        public List<Rune> SelectRune(List<Rune> runeList)
        {
            string version = String.Empty;

            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectRune";

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Rune rune = new Rune();
                    rune.Id = int.Parse(sdr["Id"].ToString());
                    rune.Key = sdr["key"].ToString();
                    rune.Name = sdr["name"].ToString();

                    List<List<string>> ii = new List<List<string>>();
                    List<string> ss = new List<string>();

                    int i = 0;
                    foreach (var item in sdr["slots"].ToString().Split(','))
                    {
                        if (item.Contains("/"+rune.Id))
                        {                            
                            ss = new List<string>();
                            ii.Add(ss);
                            //if (i == 0)
                            //{
                            //    i++;
                            //}
                            //else
                            //{

                            //}

                            ss.Add(item);
                        }
                        else
                        {
                            if (item.Contains(rune.Id.ToString()))
                            {
                                ss.Add(item);
                            }
                        }
                    }

                    rune.Slots = ii;

                    foreach (var item in rune.Slots)
                    {
                        foreach (var jItem in item)
                        {
                            jItem.Replace("/", "");
                        }
                    }

                    byte[] array = (byte[])sdr["image"];
                    MemoryStream ms = new MemoryStream(array);
                    Image image = Image.FromStream(ms);
                    rune.Image = image;

                    runeList.Add(rune);
                }
                con.Close();
            }
            return runeList;
        }

        // ============================================================

        public void InsertInnerRune(List<InnerRune> innerRuneList)
        {
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();
                foreach (var innerRune in innerRuneList)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertInnerRune";
                    cmd.Parameters.AddWithValue("Id", innerRune.Id);
                    cmd.Parameters.AddWithValue("key", innerRune.Key);
                    cmd.Parameters.AddWithValue("name", innerRune.Name);
                    cmd.Parameters.AddWithValue("shortDesc", innerRune.ShortDesc);
                    cmd.Parameters.AddWithValue("longDesc", innerRune.LongDesc);

                    MemoryStream ms = new MemoryStream();
                    innerRune.Image.Save(ms, innerRune.Image.RawFormat);

                    cmd.Parameters.AddWithValue("image", ms.ToArray());

                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        public List<InnerRune> SelectInnerRune(List<InnerRune> innerRuneList)
        {
            string version = String.Empty;
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectInnerRune";

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    InnerRune innerRune = new InnerRune();
                    innerRune.Id = int.Parse(sdr["Id"].ToString());
                    innerRune.Key = sdr["key"].ToString();
                    innerRune.Name = sdr["name"].ToString();
                    innerRune.ShortDesc = sdr["shortDesc"].ToString();
                    innerRune.LongDesc = sdr["longDesc"].ToString();

                    byte[] array = (byte[])sdr["image"];
                    MemoryStream ms = new MemoryStream(array);
                    Image image = Image.FromStream(ms);
                    innerRune.Image = image;

                    innerRuneList.Add(innerRune);
                }
                con.Close();
            }
            return innerRuneList;
        }
    }
}
