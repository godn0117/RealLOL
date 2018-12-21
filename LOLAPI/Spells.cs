using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI
{
    public class Spells
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
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
        private string tooltip;

        public string Tooltip
        {
            get { return tooltip; }
            set { tooltip = value; }
        }

        private int[] cost;

        public int[] Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        private int[] range;

        public int[] Range
        {
            get { return range; }
            set { range = value; }
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
