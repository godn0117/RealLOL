using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI
{
    class Skin
    {
        private int num;

        public int Num
        {
            get { return num; }
            set { num = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private Image skinImage;

        public Image SkinImage
        {
            get { return skinImage; }
            set { skinImage = value; }
        }


    }
}
