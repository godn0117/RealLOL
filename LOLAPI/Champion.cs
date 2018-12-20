using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI
{
    class Champion
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

        private float hp;

        public float Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        private float hpperlevel;

        public float Hpperlevel
        {
            get { return hpperlevel; }
            set { hpperlevel = value; }
        }

        private float mp;

        public float Mp
        {
            get { return mp; }
            set { mp = value; }
        }

        private float mpperlevel;

        public float Mpperlevel
        {
            get { return mpperlevel; }
            set { mpperlevel = value; }
        }

        private float movespeed;

        public float Movespeed
        {
            get { return movespeed; }
            set { movespeed = value; }
        }

        private float armor;

        public float Armor
        {
            get { return armor; }
            set { armor = value; }
        }

        private float armorperlevel;

        public float Armorperlevel
        {
            get { return armorperlevel; }
            set { armorperlevel = value; }
        }

        private float spellblock;

        public float Spellblock
        {
            get { return spellblock; }
            set { spellblock = value; }
        }

        private float spellblockperlevel;

        public float Spellblockperlevel
        {
            get { return spellblockperlevel; }
            set { spellblockperlevel = value; }
        }

        private float attackrange;

        public float Attackrange
        {
            get { return attackrange; }
            set { attackrange = value; }
        }

        private float hpregen;

        public float Hpregen
        {
            get { return hpregen; }
            set { hpregen = value; }
        }

        private float hpregenperlevel;

        public float Hpregenperlevel
        {
            get { return hpregenperlevel; }
            set { hpregenperlevel = value; }
        }

        private float mpregen;

        public float Mpregen
        {
            get { return mpregen; }
            set { mpregen = value; }
        }

        private float mpregenperlevel;

        public float Mpregenperlevel
        {
            get { return mpregenperlevel; }
            set { mpregenperlevel = value; }
        }

        private float attackdamage;

        public float Attackdamage
        {
            get { return attackdamage; }
            set { attackdamage = value; }
        }

        private float attackdamageperlevel;

        public float Attackdamageperlevel
        {
            get { return attackdamageperlevel; }
            set { attackdamageperlevel = value; }
        }

        private float attackspeed;

        public float Attackspeed
        {
            get { return attackspeed; }
            set { attackspeed = value; }
        }

        private float attackspeedperlevel;

        public float Attackspeedperlevel
        {
            get { return attackspeedperlevel; }
            set { attackspeedperlevel = value; }
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
