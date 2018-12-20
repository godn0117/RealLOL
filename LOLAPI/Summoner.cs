using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI
{
    class Summoner
    {
        // "profileIconId": 779,
        // "name": "YGYU",
        // "puuid": "wZI59yI93EJoqC6W9mGQ7D3OIzqufkskI7aG5oLx8LFumlg6bYu1dvUFfQ62vyZ81uB4GDnj1ojQsg",
        // "summonerLevel": 92,
        // "accountId": "msBUN0YwzvyZA2yq6Z-5IBhh2lsE7F7pGZOnZ33kQVRVlHY",
        // "id": "hDCNqnmY6cUp-hHYrT514N1JaIxbTKzdvcl-wwR6ggwgQeg",
        // "revisionDate": 1544076865000

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

        private string puuid;

        public string Puuid
        {
            get { return puuid; }
            set { puuid = value; }
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
