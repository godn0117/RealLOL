using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI
{
    class Bans
    {
        private int pickTurn;

        public int PickTurn
        {
            get { return pickTurn; }
            set { pickTurn = value; }
        }

        private int championId;

        public int ChampionId
        {
            get { return championId; }
            set { championId = value; }
        }

    }
}
