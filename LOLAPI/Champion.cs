using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI
{
    public class Champion
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private int key;

        public int Key
        {
            get { return key; }
            set { key = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string blurb;

        public string Blurb
        {
            get { return blurb; }
            set { blurb = value; }
        }

        private ChampionInfo info;

        public ChampionInfo Info
        {
            get { return info; }
            set { info = value; }
        }

        private string full;

        public string Full
        {
            get { return full; }
            set { full = value; }
        }

        private string[] tags;

        public string[] Tags
        {
            get { return tags; }
            set { tags = value; }
        }
        private Status status;

        public Status Status
        {
            get { return status; }
            set { status = value; }
        }

        private Skin[] skin;

        public Skin[] Skin
        {
            get { return skin; }
            set { skin = value; }
        }


        private Spells[] spell;

        public Spells[] Spell
        {
            get { return spell; }
            set { spell = value; }
        }
        private Passive passive;

        public Passive Passive
        {
            get { return passive; }
            set { passive = value; }
        }

        private Image chamImage;

        public Image ChamImage
        {
            get { return chamImage; }
            set { chamImage = value; }
        }
        private Image loadImage;

        public Image LoadImage
        {
            get { return loadImage; }
            set { loadImage = value; }
        }

    }
}
