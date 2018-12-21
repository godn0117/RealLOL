using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI
{
    public class Passive
    {
        private string name;

        public string Name

        {
            get { return name; }
            set { name = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private string full;

        public string Full
        {
            get { return full; }
            set { full = value; }
        }
        private Image skImage;

        public Image SkImage
        {
            get { return skImage; }
            set { skImage = value; }
        }

    }
}
