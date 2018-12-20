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
    class SpellDB
    {
        public void InsertSpell(List<Spell> spellList)
        {            
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();
                foreach (var spell in spellList)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertSpell";
                    cmd.Parameters.AddWithValue("Id", spell.ID);
                    cmd.Parameters.AddWithValue("name", spell.Name);                    
                    cmd.Parameters.AddWithValue("description", spell.Description);
                    cmd.Parameters.AddWithValue("cooldownBurn", spell.CooldownBurn);
                    cmd.Parameters.AddWithValue("key", spell.Key);
                    cmd.Parameters.AddWithValue("summonerLevel", spell.SummonerLevel);
                    cmd.Parameters.AddWithValue("rangeBurn", spell.RangeBurn);
                    
                    string modes = "";
                    if (spell.Modes != null)
                    {
                        foreach (var spellArr in spell.Modes)
                        {
                            modes += spellArr + ",";
                        }

                        modes = modes.Substring(0, modes.Length - 1);
                    }
                    cmd.Parameters.AddWithValue("modes", modes);

                    MemoryStream ms = new MemoryStream();
                    spell.Image.Save(ms, spell.Image.RawFormat);

                    cmd.Parameters.AddWithValue("image", ms.ToArray());

                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        public List<Spell> SelectSpell(List<Spell> spellList) 
        {
            
            string version = String.Empty;
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectSpell";

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Spell spell = new Spell();
                    spell.ID = sdr["Id"].ToString();
                    spell.Name = sdr["name"].ToString();
                    spell.Description = sdr["description"].ToString();
                    spell.CooldownBurn = sdr["cooldownBurn"].ToString();
                    spell.Key = sdr["key"].ToString();
                    spell.SummonerLevel = Int32.Parse(sdr["summonerLevel"].ToString());
                    spell.RangeBurn = sdr["rangeBurn"].ToString();
                    spell.Modes = sdr["modes"].ToString().Split(',');

                    byte[] array = (byte[])sdr["image"];
                    MemoryStream ms = new MemoryStream(array);
                    Image image = Image.FromStream(ms);
                    spell.Image = image;

                    spellList.Add(spell);
                }

                con.Close();
            }

            return spellList;
        }
    }
}
