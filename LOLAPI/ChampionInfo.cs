using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI
{
    class ChampionInfo
    {
        private int attack;

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        private int defense;

        public int Defense
        {
            get { return defense; }
            set { defense = value; }
        }

        private int magic;

        public int Magic
        {
            get { return magic; }
            set { magic = value; }
        }

        private int difficulty;

        public int Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
        }
    }
}
