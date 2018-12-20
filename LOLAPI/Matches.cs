using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI
{
    class Matches
    {
        private string lane;

        public string Lane
        {
            get { return lane; }
            set { lane = value; }
        }
        private string gameId;

        public string GameId
        {
            get { return gameId; }
            set { gameId = value; }
        }
        private int champion;

        public int Champion
        {
            get { return champion; }
            set { champion = value; }
        }
        private string platformId;

        public string PlatformId
        {
            get { return platformId; }
            set { platformId = value; }
        }
        private double timestamp;

        public double Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }
        private int queue;

        public int Queue
        {
            get { return queue; }
            set { queue = value; }
        }
        private string role;

        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        private int season;

        public int Season
        {
            get { return season; }
            set { season = value; }
        }

    }
}
