using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI
{
    class SummonerRank
    {
        private string queueType;

        public string QueueType
        {
            get { return queueType; }
            set { queueType = value; }
        }

        private string summonerName;

        public string SummonerName
        {
            get { return summonerName; }
            set { summonerName = value; }
        }

        private int wins;

        public int Wins
        {
            get { return wins; }
            set { wins = value; }
        }

        private int losses;

        public int Losses
        {
            get { return losses; }
            set { losses = value; }
        }
        private string rank;

        public string Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        private string leagueName;

        public string LeagueName
        {
            get { return leagueName; }
            set { leagueName = value; }
        }
        private string leagueId;

        public string LeagueId
        {
            get { return leagueId; }
            set { leagueId = value; }
        }
        private string tier;

        public string Tier
        {
            get { return tier; }
            set { tier = value; }
        }
        private string summonerId;

        public string SummonerId
        {
            get { return summonerId; }
            set { summonerId = value; }
        }
        private int leaguePoints;

        public int LeaguePoints
        {
            get { return leaguePoints; }
            set { leaguePoints = value; }
        }
    }
}
