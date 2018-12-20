using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI
{
    public class LOLItem
    {        
        private string code; // 코드

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private string name;

        public string Name // 이름
        {
            get { return name; }
            set { name = value; }
        }

        private string description;

        public string Description // 설명
        {
            get { return description; }
            set { description = value; }
        }

        private string plaintext;

        public string Plaintext // 부연 설명
        {
            get { return plaintext; }
            set { plaintext = value; }
        }

        private string imageName; // img 저장이름

        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; }
        }

        private int gold; // 판매 가격

        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }

        private string[] from;

        public string[] From
        {
            get { return from; }
            set { from = value; }
        }

        private string[] into;

        public string[] Into
        {
            get { return into; }
            set { into = value; }
        }

        private string[] tags;

        public string[] Tags
        {
            get { return tags; }
            set { tags = value; }
        }

        private Image image;

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }
    }
}
