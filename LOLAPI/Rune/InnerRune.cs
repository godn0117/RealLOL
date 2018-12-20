using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI
{
    class InnerRune
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string key;

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private Image image;

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string shortDesc;

        public string ShortDesc
        {
            get { return shortDesc; }
            set { shortDesc = value; }
        }

        private string longDesc;

        public string LongDesc
        {
            get { return longDesc; }
            set { longDesc = value; }
        }

    }
}
