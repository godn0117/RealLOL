using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI
{
    class VersionDB
    {
        public void UpdateVersion(string query) // 버전 업데이트
        {
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                //cmd.Parameters.AddWithValue("version", version);

                cmd.ExecuteNonQuery();

                //System.Windows.Forms.MessageBox.Show("버전 업데이트 ");

                con.Close();
            }
        }

        public string SelectVersion(string query) // 버전 체크
        {
            string version = String.Empty;
            
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                // SqlDataReader sdr = cmd.ExecuteReader();
                version = cmd.ExecuteScalar().ToString();

                con.Close();
            }

            return version;
        }      
    }
}
