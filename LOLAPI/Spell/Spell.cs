using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI
{
    public class Spell
    {
        private string id;

        public string ID
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

        private string cooldownBurn;

        public string CooldownBurn
        {
            get { return cooldownBurn; }
            set { cooldownBurn = value; }
        }

        private string key;

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private int summonerLevel;

        public int SummonerLevel
        {
            get { return summonerLevel; }
            set { summonerLevel = value; }
        }

        private string rangeBurn;

        public string RangeBurn
        {
            get { return rangeBurn; }
            set { rangeBurn = value; }
        }

        private Image image;

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        private string[] modes;

        public string[] Modes
        {
            get { return modes; }
            set { modes = value; }
        }
    }
}
