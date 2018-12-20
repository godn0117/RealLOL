using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI.JSON
{
    public class JsonWork
    {
        public string GetJsonFromWeb(string url) // 웹에서 json 받아오기
        {

            string readToEnd = "";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            if (res.StatusCode == HttpStatusCode.OK)
            {
                Stream stream = res.GetResponseStream();
                StreamReader sr = new StreamReader(stream, Encoding.UTF8);

                readToEnd = sr.ReadToEnd();
            }

            return readToEnd;
        }

        public Image GetJsonImageFromWeb(string url) // 웹에서 이미지 받아오기
        {
            Image image = null;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            if (res.StatusCode == HttpStatusCode.OK)
            {
                Stream stream = res.GetResponseStream();
                BinaryReader sr = new BinaryReader(stream, Encoding.UTF8);

                image = Image.FromStream(stream);
            }

            return image;
        }
    }
}
