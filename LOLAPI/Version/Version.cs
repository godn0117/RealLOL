using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOLAPI
{
    public class Version
    {        
        public string CheckLatestVersion() // 웹에서 버전 가져오는 메서드
        {
            string readToEnd = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://ddragon.leagueoflegends.com/api/versions.json");
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            if (res.StatusCode == HttpStatusCode.OK)
            {
                Stream stream = res.GetResponseStream();
                StreamReader sr = new StreamReader(stream, Encoding.UTF8);

                readToEnd = sr.ReadToEnd();
            }

            JArray jArr = JArray.Parse(readToEnd);

            return jArr[0].ToString();
        }

        public bool VersionUpdate(string latestVersion, string nowVersion) // 최신 버전인지 아닌지 확인
        {
            bool updated = true;

            if (latestVersion.Equals(nowVersion))
            {
                updated = true;
                //MessageBox.Show("최신 버전 입니다");
            }
            else
            {
                updated = false;
                //MessageBox.Show("업데이트가 필요 합니다");
            }

            return updated;
        }
    }
}
