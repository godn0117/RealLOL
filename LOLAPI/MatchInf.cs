using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI
{
    class MatchInf
    {
        private bool firstDragon;

        public bool FirstDragon
        {
            get { return firstDragon; }
            set { firstDragon = value; }
        }
        private List<Bans> bans;

        public List<Bans> Bans
        {
            get { return bans; }
            set { bans = value; }
        }
        private bool firstInhibitor;

        public bool FirstInhibitor
        {
            get { return firstInhibitor; }
            set { firstInhibitor = value; }
        }

        private string win;

        public string Win
        {
            get { return win; }
            set { win = value; }
        }
        private bool firstRiftHerald;

        public bool FirstRiftHerald
        {
            get { return firstRiftHerald; }
            set { firstRiftHerald = value; }
        }
        private bool firstBaron;

        public bool FirstBaron
        {
            get { return firstBaron; }
            set { firstBaron = value; }
        }
        private int baronKills;

        public int BaronKills
        {
            get { return baronKills; }
            set { baronKills = value; }
        }

        private int riftHeraldKills;

        public int RiftHeraldKills
        {
            get { return riftHeraldKills; }
            set { riftHeraldKills = value; }
        }

        private bool firstBlood;

        public bool FirstBlood
        {
            get { return firstBlood; }
            set { firstBlood = value; }
        }

        private int teamId;

        public int TeamId
        {
            get { return teamId; }
            set { teamId = value; }
        }
        private bool firstTower;

        public bool FirstTower
        {
            get { return firstTower; }
            set { firstTower = value; }
        }

        private int vilemawKills;

        public int VilemawKills
        {
            get { return vilemawKills; }
            set { vilemawKills = value; }
        }

        private int inhibitorKills;

        public int InhibitorKills
        {
            get { return inhibitorKills; }
            set { inhibitorKills = value; }
        }

        private int towerKills;

        public int TowerKills
        {
            get { return towerKills; }
            set { towerKills = value; }
        }

        private int dominionVictoryScore;

        public int DominionVictoryScore
        {
            get { return dominionVictoryScore; }
            set { dominionVictoryScore = value; }
        }
        private int dragonKills;

        public int DragonKills
        {
            get { return dragonKills; }
            set { dragonKills = value; }
        }


    }
}
