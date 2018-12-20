using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI
{
    class SummonerV3
    {
        private int profileIconId;

        public int ProfileIconId
        {
            get { return profileIconId; }
            set { profileIconId = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int summonerLevel;

        public int SummonerLevel
        {
            get { return summonerLevel; }
            set { summonerLevel = value; }
        }

        private string accountId;

        public string AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }

        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string revisionDate;

        public string RevisionDate
        {
            get { return revisionDate; }
            set { revisionDate = value; }
        }

    }
}
