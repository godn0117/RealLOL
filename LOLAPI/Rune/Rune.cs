
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI
{
    class Rune
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

        private List<InnerRune> innerRune;

        public List<InnerRune> InnerRune
        {
            get { return innerRune; }
            set { innerRune = value; }
        }

        private List<List<string>> slots;

        public List<List<string>> Slots
        {
            get { return slots; }
            set { slots = value; }
        }

        
    }
}
