using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOLAPI
{
    public partial class FrmSummoner : Form
    {
        private string summonerName;

        public string SummonerName
        {
            get { return summonerName; }
            set { summonerName = value; }
        }

        int playTimeIndex;
        string searchName;
        string json;
        string json2;
        string summonerRankJson;
        string matchJson;
        string playerJson;
        private List<Summoner> lstV4 = new List<Summoner>();
        private List<SummonerV3> lstV3 = new List<SummonerV3>();
        private List<SummonerRank> lstRank = new List<SummonerRank>();
        private List<Matches> lstMatches = new List<Matches>();
        private List<Player> lstPlayer = new List<Player>();
        private List<MatchInf> lstMatInf = new List<MatchInf>();
        private List<TimeStamp> lstTime = new List<TimeStamp>();
        private DataTable resultTab;
        string apiKey = "RGAPI-8de1f423-1520-47e7-b52a-33c66f07dd2c";


        public FrmSummoner()
        {
            InitializeComponent();
        }
        public FrmSummoner(string summonerName) : this()
        {
            this.label1.Text = summonerName + " 님의 전적";
            searchName = summonerName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSummoner_Load(object sender, EventArgs e)
        {
            ParsingSummonerCode();
            if (!ParsingSummonerRank())
            {
                return;
            }
            ParsingMatches();
            ParsingPlayer();
            ParsingTimeStamp();
            this.txtLevel.Text = "레벨 : " + lstV4[0].SummonerLevel;

            for (int i = 0; i < lstRank.Count; i++)
            {
                if (lstRank[i].QueueType == "RANKED_SOLO_5x5")
                {
                    this.txtWinLose.Text = "랭크 : " + lstRank[i].Wins + " 승  " + lstRank[i].Losses + "패";
                    this.txtGrade.Text = "등급 : " + lstRank[i].Tier + "  " + lstRank[i].Rank;
                    this.txtLeguePoints.Text = "리그 포인트 : " + lstRank[i].LeaguePoints;
                    this.txtLeagueName.Text = lstRank[i].LeagueName;
                }
                if (lstRank[i].QueueType == "RANKED_FLEX_SR")
                {
                    this.txtTeamWinLose.Text = "랭크 : " + lstRank[i].Wins + " 승  " + lstRank[i].Losses + "패";
                    this.txtTeamGrade.Text = "등급 : " + lstRank[i].Tier + "  " + lstRank[i].Rank;
                    this.txtTeamLeaguePoints.Text = "리그 포인트 : " + lstRank[i].LeaguePoints;
                    this.txtTeamLeagueName.Text = lstRank[i].LeagueName;
                }
            }
            resultTab = new DataTable();
            resultTab.Columns.Add("플레이");
            resultTab.Columns.Add("승/패");
            resultTab.Columns.Add("타입");
            resultTab.Columns.Add("챔피언");
            resultTab.Columns.Add("K / D / A");
            resultTab.Columns.Add("스펠");
            resultTab.Columns.Add("아이템");
            resultTab.Columns.Add("골드수급");
            resultTab.Columns.Add("딜량");
            resultTab.Columns.Add("피해량");




            for (int i = 0; i < lstPlayer.Count; i++)
            {
                playTimeIndex = i / 10;
                if (lstPlayer[i].SummonerName == searchName)
                {
                    DataRow row = resultTab.NewRow();
                    if (lstPlayer[i].Win == true)
                    {
                        row["승/패"] = "승";
                    }
                    else if(lstPlayer[i].Win == false)
                    {
                        row["승/패"] = "패";
                    }
                    row["타입"] = lstMatches[i].Queue;
                    row["챔피언"] = lstPlayer[i].ChampionId;
                    row["K / D / A"] = lstPlayer[i].Kills + " / " + lstPlayer[i].Deaths + " / " + lstPlayer[i].Assists;
                    row["스펠"] = lstPlayer[i].Spell1Id + " / " + lstPlayer[i].Spell2Id;
                    row["아이템"] = lstPlayer[i].Item0 + " / " + lstPlayer[i].Item1 + " / " + lstPlayer[i].Item2 + " / " + lstPlayer[i].Item3 + " / " + lstPlayer[i].Item4 + " / " + lstPlayer[i].Item5 + " / " + lstPlayer[i].Item6;
                    row["골드수급"] = lstPlayer[i].GoldEarned + " Gold";
                    row["딜량"] = lstPlayer[i].TotalDamageDealtToChampions;
                    row["피해량"] = lstPlayer[i].TotalDamageTaken;

                    resultTab.Rows.Add(row);

                    //dataGridView1.Rows.Add(row);
                }
            }
            try
            {
                for (int i = 0; i <= playTimeIndex; i++)
                {
                    resultTab.Rows[i]["플레이"] = UnixTimeStampToDateTime((double)lstMatches[i].Timestamp);
                }
                this.dataGridView1.DataSource = resultTab;
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("공백 및 대소문자를 구별해주세요");
                return;
            }
            for (int i = 0; i <= playTimeIndex; i++)
            {
                for (int j = 0; j < resultTab.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[1].Value.ToString() == "승")
                    {
                        this.dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.SkyBlue;
                        this.dataGridView1.Rows[i].Cells[1].Style.Font = new Font("Verdana", 13, FontStyle.Bold);
                        this.dataGridView1.Rows[i].Cells[3].Style.Font = new Font("Verdana", 9, FontStyle.Bold);
                    }
                    else if (dataGridView1.Rows[i].Cells[1].Value.ToString() == "패")
                    {
                        this.dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Pink;
                        this.dataGridView1.Rows[i].Cells[1].Style.Font = new Font("Verdana", 13, FontStyle.Bold);
                        this.dataGridView1.Rows[i].Cells[3].Style.Font = new Font("Verdana", 9, FontStyle.Bold);
                    }
                    else
                    {
                        this.dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.SlateGray;
                    }
                }
            }
            dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightYellow;
        }

        private void ParsingTimeStamp()
        {
            string endTime = "";
            TimeStamp s = new TimeStamp();
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    var url = "https://kr.api.riotgames.com/lol/match/v4/timelines/by-match/" + lstMatches[i].GameId + "?api_key=" + apiKey;
                    var req = (HttpWebRequest)WebRequest.Create(url);
                    var res = (HttpWebResponse)req.GetResponse();
                    var stream = res.GetResponseStream();
                    var sr = new StreamReader(stream, Encoding.UTF8);
                    playerJson = sr.ReadToEnd();
                }
                catch (ArgumentOutOfRangeException)
                {
                    //경기기록에 경기시간이 없을 수 있나?
                    return;
                }
                var jObj = JObject.Parse(playerJson);
                var itemsArr = JArray.Parse(jObj["frames"].ToString());

                //var itemsArr = jObj["frames"]["timestamp"].ToString();

                foreach (JObject item in itemsArr)
                {
                    endTime = item["timestamp"].ToString();

                    s = new TimeStamp
                    {
                        EndTime = ReturnGameTime(endTime)
                        //timeEvent
                    };
                }
                lstTime.Add(s);
            }
        }
        public static string ReturnGameTime(string time)
        {
            int a= Int32.Parse(time);
            int b = a / 1000;
            //int sec = b % 60;
            int min = b / 60;
            //string returnTime = min + "분 " + sec + "초";
            string returnTime = min + "분";
            return returnTime;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            DateTime dt = new DateTime();
            dt = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            return dt;
        }

        private void ParsingPlayer()
        {
            string currentPlatformId;
            string summonerName;
            string matchHistoryUri;
            string platformId;
            string currentAccountId;
            int profileIcon;
            string summonerId;
            string accountId;
            int participantId;
            int kills;
            int assists;
            int deaths;
            int goldEarned;
            int totalDamageDealtToChampions;
            int totalDamageTaken;
            int item0;
            int item1;
            int item2;
            int item3;
            int item4;
            int item5;
            int item6;
            int perk0;
            int perk1;
            int perk2;
            int perk3;
            int perk4;
            int perk5;
            bool playerwin;
            int spell1Id;
            int spell2Id;
            int championId;

            List<Player> lstplayer2 = new List<Player>();

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    var url = "https://kr.api.riotgames.com/lol/match/v4/matches/" + lstMatches[i].GameId + "?api_key=" + apiKey;
                    var req = (HttpWebRequest)WebRequest.Create(url);
                    var res = (HttpWebResponse)req.GetResponse();
                    var stream = res.GetResponseStream();
                    var sr = new StreamReader(stream, Encoding.UTF8);
                    playerJson = sr.ReadToEnd();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("매치기록이 오래되었거나 없는 사용자입니다");
                    return;
                }


                var jObj = JObject.Parse(playerJson);
                var itemsArr = JArray.Parse(jObj["participantIdentities"].ToString());
                foreach (JObject item in itemsArr)
                {
                    currentPlatformId = item["player"]["currentPlatformId"].ToString();
                    summonerName = item["player"]["summonerName"].ToString();
                    matchHistoryUri = item["player"]["matchHistoryUri"].ToString();
                    platformId = item["player"]["platformId"].ToString();
                    currentAccountId = item["player"]["currentAccountId"].ToString();
                    profileIcon = Int32.Parse(item["player"]["profileIcon"].ToString());
                    summonerId = item["player"]["summonerId"].ToString();
                    accountId = item["player"]["accountId"].ToString();
                    participantId = Int32.Parse(item["participantId"].ToString());

                    Player p = new Player
                    {
                        CurrentPlatformId = currentPlatformId,
                        SummonerName = summonerName,
                        MatchHistoryUri = matchHistoryUri,
                        PlatformId = platformId,
                        CurrentAccountId = currentAccountId,
                        ProfileIcon = profileIcon,
                        SummonerId = summonerId,
                        AccountId = accountId,
                        ParticipantId = participantId
                    };

                    lstPlayer.Add(p);
                }
                var itemsArr3 = JArray.Parse(jObj["participants"].ToString());
                foreach (JObject item in itemsArr3)
                {
                    kills = Int32.Parse(item["stats"]["kills"].ToString());
                    assists = Int32.Parse(item["stats"]["assists"].ToString());
                    deaths = Int32.Parse(item["stats"]["deaths"].ToString());
                    goldEarned = Int32.Parse(item["stats"]["goldEarned"].ToString());
                    totalDamageDealtToChampions = Int32.Parse(item["stats"]["totalDamageDealtToChampions"].ToString());
                    totalDamageTaken = Int32.Parse(item["stats"]["totalDamageTaken"].ToString());
                    item0 = Int32.Parse(item["stats"]["item0"].ToString());
                    item1 = Int32.Parse(item["stats"]["item1"].ToString());
                    item2 = Int32.Parse(item["stats"]["item2"].ToString());
                    item3 = Int32.Parse(item["stats"]["item3"].ToString());
                    item4 = Int32.Parse(item["stats"]["item4"].ToString());
                    item5 = Int32.Parse(item["stats"]["item5"].ToString());
                    item6 = Int32.Parse(item["stats"]["item6"].ToString());
                    try
                    {
                        perk0 = Int32.Parse(item["stats"]["perk0"].ToString());
                        perk1 = Int32.Parse(item["stats"]["perk1"].ToString());
                        perk2 = Int32.Parse(item["stats"]["perk2"].ToString());
                        perk3 = Int32.Parse(item["stats"]["perk3"].ToString());
                        perk4 = Int32.Parse(item["stats"]["perk4"].ToString());
                        perk5 = Int32.Parse(item["stats"]["perk5"].ToString());
                    }
                    catch (NullReferenceException)
                    {
                        continue;
                    }
                    playerwin = bool.Parse(item["stats"]["win"].ToString());
                    spell1Id = Int32.Parse(item["spell1Id"].ToString());
                    spell2Id = Int32.Parse(item["spell2Id"].ToString());
                    championId = Int32.Parse(item["championId"].ToString());

                    Player p1 = new Player
                    {
                        Kills = kills,
                        Assists = assists,
                        Deaths = deaths,
                        GoldEarned = goldEarned,
                        TotalDamageDealtToChampions = totalDamageDealtToChampions,
                        TotalDamageTaken = totalDamageTaken,
                        Item0 = item0,
                        Item1 = item1,
                        Item2 = item2,
                        Item3 = item3,
                        Item4 = item4,
                        Item5 = item5,
                        Item6 = item6,
                        Perk0 = perk0,
                        Perk1 = perk1,
                        Perk2 = perk2,
                        Perk3 = perk3,
                        Perk4 = perk4,
                        Perk5 = perk5,
                        Win = playerwin,
                        Spell1Id = spell1Id,
                        Spell2Id = spell2Id,
                        ChampionId = championId
                    };
                    lstplayer2.Add(p1);
                }



                List<Bans> banList = new List<Bans>();
                var itemsArr2 = JArray.Parse(jObj["teams"].ToString());
                foreach (JObject item in itemsArr2)
                {
                    bool firstDragon = bool.Parse(item["firstDragon"].ToString());

                    foreach (var banArr in JArray.Parse(item["bans"].ToString()))
                    {
                        Bans ban = new Bans();
                        ban.PickTurn = Int32.Parse(banArr["pickTurn"].ToString());
                        ban.ChampionId = Int32.Parse(banArr["championId"].ToString());
                        //textBox2.Text += ban.PickTurn + " ";
                        //textBox2.Text += ban.ChampionId + " \r\n";
                        banList.Add(ban);
                    }
                    bool firstInhibitor = bool.Parse(item["firstInhibitor"].ToString());
                    string win = item["win"].ToString();
                    bool firstRiftHerald = bool.Parse(item["firstRiftHerald"].ToString());
                    bool firstBaron = bool.Parse(item["firstBaron"].ToString());
                    int baronKills = Int32.Parse(item["baronKills"].ToString());
                    int riftHeraldKills = Int32.Parse(item["riftHeraldKills"].ToString());
                    bool firstBlood = bool.Parse(item["firstBlood"].ToString());
                    int teamId = Int32.Parse(item["teamId"].ToString());
                    bool firstTower = bool.Parse(item["firstTower"].ToString());
                    int vilemawKills = Int32.Parse(item["vilemawKills"].ToString());
                    int inhibitorKills = Int32.Parse(item["inhibitorKills"].ToString());
                    int towerKills = Int32.Parse(item["towerKills"].ToString());
                    int dominionVictoryScore = Int32.Parse(item["dominionVictoryScore"].ToString());
                    int dragonKills = Int32.Parse(item["dragonKills"].ToString());

                    MatchInf m = new MatchInf
                    {
                        FirstDragon = firstDragon,
                        Bans = banList,
                        FirstInhibitor = firstInhibitor,
                        Win = win,
                        FirstRiftHerald = firstRiftHerald,
                        FirstBaron = firstBaron,
                        BaronKills = baronKills,
                        RiftHeraldKills = riftHeraldKills,
                        FirstBlood = firstBlood,
                        TeamId = teamId,
                        FirstTower = firstTower,
                        VilemawKills = vilemawKills,
                        InhibitorKills = inhibitorKills,
                        TowerKills = towerKills,
                        DominionVictoryScore = dominionVictoryScore,
                        DragonKills = dragonKills
                    };

                    lstMatInf.Add(m);
                }
            }
            for (int i = 0; i < lstPlayer.Count; i++)
            {// 따로 파싱한 플레이어 정보 하나로 합침 (수정..)
                lstPlayer[i].Kills = lstplayer2[i].Kills;
                lstPlayer[i].Assists = lstplayer2[i].Assists;
                lstPlayer[i].Deaths = lstplayer2[i].Deaths;
                lstPlayer[i].GoldEarned = lstplayer2[i].GoldEarned;
                lstPlayer[i].TotalDamageDealtToChampions = lstplayer2[i].TotalDamageDealtToChampions;
                lstPlayer[i].TotalDamageTaken = lstplayer2[i].TotalDamageTaken;
                lstPlayer[i].Item0 = lstplayer2[i].Item0;
                lstPlayer[i].Item1 = lstplayer2[i].Item1;
                lstPlayer[i].Item2 = lstplayer2[i].Item2;
                lstPlayer[i].Item3 = lstplayer2[i].Item3;
                lstPlayer[i].Item4 = lstplayer2[i].Item4;
                lstPlayer[i].Item5 = lstplayer2[i].Item5;
                lstPlayer[i].Item6 = lstplayer2[i].Item6;
                lstPlayer[i].Perk0 = lstplayer2[i].Perk0;
                lstPlayer[i].Perk1 = lstplayer2[i].Perk1;
                lstPlayer[i].Perk2 = lstplayer2[i].Perk2;
                lstPlayer[i].Perk3 = lstplayer2[i].Perk3;
                lstPlayer[i].Perk4 = lstplayer2[i].Perk4;
                lstPlayer[i].Perk5 = lstplayer2[i].Perk5;
                lstPlayer[i].Win = lstplayer2[i].Win;
                lstPlayer[i].Spell1Id = lstplayer2[i].Spell1Id;
                lstPlayer[i].Spell2Id = lstplayer2[i].Spell2Id;
                lstPlayer[i].ChampionId = lstplayer2[i].ChampionId;
            }
            //this.dataGridView1.DataSource = lstMatInf;
            //this.dataGridView1.DataSource = lstPlayer;
        }


        private void ParsingMatches()
        {
            string lane;

            var url = "https://kr.api.riotgames.com/lol/match/v4/matchlists/by-account/" + lstV4[0].AccountId + "?api_key=" + apiKey;
            var req = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                var res = (HttpWebResponse)req.GetResponse();
                var statusCode = res.StatusCode.ToString();
                if (statusCode == "OK")
                {
                    var stream = res.GetResponseStream();
                    var sr = new StreamReader(stream, Encoding.UTF8);
                    matchJson = sr.ReadToEnd();
                    //this.textBox2.Text = matchJson;
                }
                else
                {
                    MessageBox.Show("매치에러" + statusCode);
                }
            }
            catch (WebException)
            {
                MessageBox.Show("매치기록이 오래되었거나 없는 사용자입니다");
                return;
            }

            var jObj = JObject.Parse(matchJson);
            var itemsArr = JArray.Parse(jObj["matches"].ToString());

            foreach (JObject item in itemsArr)
            {
                try
                {
                    lane = item["lane"].ToString();

                }
                catch (NullReferenceException)
                {
                    continue;
                }
                string gameId = item["gameId"].ToString();
                int champion = Int32.Parse(item["champion"].ToString());
                string platformId = item["platformId"].ToString();
                double timestamp = Double.Parse(item["timestamp"].ToString());
                int queue = Int32.Parse(item["queue"].ToString());
                string role = item["role"].ToString();
                int season = Int32.Parse(item["season"].ToString());

                Matches m = new Matches
                {
                    Lane = lane,
                    GameId = gameId,
                    Champion = champion,
                    PlatformId = platformId,
                    Timestamp = timestamp,
                    Queue = queue,
                    Role = role,
                    Season = season
                };
                lstMatches.Add(m);
            }
            //this.dataGridView1.DataSource = lstMatches;
        }
        private bool ParsingSummonerRank()
        {
            try
            {
                var url = "https://kr.api.riotgames.com/lol/league/v4/positions/by-summoner/" + lstV4[0].Id + "?api_key=" + apiKey;
                var req = (HttpWebRequest)WebRequest.Create(url);
                var res = (HttpWebResponse)req.GetResponse();
                var statusCode = res.StatusCode.ToString();
                if (statusCode == "OK")
                {
                    var stream = res.GetResponseStream();
                    var sr = new StreamReader(stream, Encoding.UTF8);

                    summonerRankJson = sr.ReadToEnd();
                    //this.textBox2.Text = summonerRankJson;
                }
                else
                {
                    MessageBox.Show("에러" + statusCode);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("찾으시는 소환사의 랭크정보가 없습니다");

                return false;
            }

            var jObj = JToken.Parse(summonerRankJson);

            var itemsArr = JArray.Parse(jObj.ToString());


            if (jObj.First != null)
            {
                string queueType = jObj.First["queueType"].ToString();
                string summonerName = jObj.First["summonerName"].ToString();
                int wins = Int32.Parse(jObj.First["wins"].ToString());
                int losses = Int32.Parse(jObj.First["losses"].ToString());
                string rank = jObj.First["rank"].ToString();
                string leagueName = jObj.First["leagueName"].ToString();
                string leagueId = jObj.First["leagueId"].ToString();
                string tier = jObj.First["tier"].ToString();
                string summonerId = jObj.First["summonerId"].ToString();
                int leaguePoints = Int32.Parse(jObj.First["leaguePoints"].ToString());
                SummonerRank sumr = new SummonerRank
                {
                    QueueType = queueType,
                    SummonerName = summonerName,
                    Wins = wins,
                    Losses = losses,
                    Rank = rank,
                    LeagueName = leagueName,
                    LeagueId = leagueId,
                    Tier = tier,
                    SummonerId = summonerId,
                    LeaguePoints = leaguePoints
                };
                lstRank.Add(sumr);

                if (jObj.First.Next != null)
                {
                    queueType = jObj.Last["queueType"].ToString();
                    summonerName = jObj.Last["summonerName"].ToString();
                    wins = Int32.Parse(jObj.Last["wins"].ToString());
                    losses = Int32.Parse(jObj.Last["losses"].ToString());
                    rank = jObj.Last["rank"].ToString();
                    leagueName = jObj.Last["leagueName"].ToString();
                    leagueId = jObj.Last["leagueId"].ToString();
                    tier = jObj.Last["tier"].ToString();
                    summonerId = jObj.Last["summonerId"].ToString();
                    leaguePoints = Int32.Parse(jObj.Last["leaguePoints"].ToString());

                    sumr = new SummonerRank
                    {
                        QueueType = queueType,
                        SummonerName = summonerName,
                        Wins = wins,
                        Losses = losses,
                        Rank = rank,
                        LeagueName = leagueName,
                        LeagueId = leagueId,
                        Tier = tier,
                        SummonerId = summonerId,
                        LeaguePoints = leaguePoints
                    };
                    lstRank.Add(sumr);
                }

                //this.dataGridView1.DataSource = lstRank;
            }
            return true;

        }

        private void ParsingSummonerCode()
        {
            var url = "https://kr.api.riotgames.com/lol/summoner/v4/summoners/by-name/" + searchName + "?api_key=" + apiKey;
            var url2 = "https://kr.api.riotgames.com/lol/summoner/v3/summoners/by-name/" + searchName + "?api_key=" + apiKey;
            var req = (HttpWebRequest)WebRequest.Create(url);
            var req2 = (HttpWebRequest)WebRequest.Create(url2);

            try
            {
                var res = (HttpWebResponse)req.GetResponse();
                var res2 = (HttpWebResponse)req2.GetResponse();

                var statusCode = res.StatusCode.ToString();
                var statusCode2 = res2.StatusCode.ToString();

                if (statusCode == "OK" && statusCode2 == "OK")
                {
                    var stream = res.GetResponseStream();
                    var sr = new StreamReader(stream, Encoding.UTF8);
                    var stream2 = res2.GetResponseStream();
                    var sr2 = new StreamReader(stream2, Encoding.UTF8);

                    string v1 = sr.ReadToEnd();
                    string v2 = sr2.ReadToEnd();

                    //this.textBox2.Text = v1 + v2;
                    json = v1;
                    json2 = v2;
                }
                else
                {
                    MessageBox.Show("에러" + statusCode);
                }
            }
            catch (WebException)
            {
                this.label1.Text = "찾으시는 소환사가 없습니다";
                return;
            }


            var jObj = JObject.Parse(json);
            //var itemsArr = JArray.Parse(jObj.Root.ToString());
            int profileIconId = Int32.Parse(jObj["profileIconId"].ToString());
            string name = jObj["name"].ToString();
            string puuid = jObj["puuid"].ToString();
            int summonerLevel = Int32.Parse(jObj["summonerLevel"].ToString());
            string accountId = jObj["accountId"].ToString();
            string id = jObj["id"].ToString();
            string revisionDate = jObj["revisionDate"].ToString();

            Summoner s = new Summoner
            {
                ProfileIconId = profileIconId,
                Name = name,
                Puuid = puuid,
                SummonerLevel = summonerLevel,
                AccountId = accountId,
                Id = id,
                RevisionDate = revisionDate
            };

            lstV4.Add(s);


            var jobj2 = JObject.Parse(json2);
            int profileIconId2 = Int32.Parse(jobj2["profileIconId"].ToString());
            string name2 = jobj2["name"].ToString();
            int summonerLevel2 = Int32.Parse(jobj2["summonerLevel"].ToString());
            string accountId2 = jobj2["accountId"].ToString();
            string id2 = jobj2["id"].ToString();
            string revisionDate2 = jobj2["revisionDate"].ToString();

            SummonerV3 s2 = new SummonerV3
            {
                ProfileIconId = profileIconId2,
                Name = name2,
                SummonerLevel = summonerLevel2,
                AccountId = accountId2,
                Id = id2,
                RevisionDate = revisionDate2
            };

            lstV3.Add(s2);

            //this.dataGridView1.DataSource = lstV3;
            //this.dataGridView1.DataSource = lstV4;
        }

        private DataTable matchBlueTab;
        private DataTable matchRedTab;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.controlMatchInfo1.Visible = true;
            this.controlMatchDetail1.Visible = true;

            this.controlMatchInfo1.button1.Click += Button1_Click;

            matchBlueTab = new DataTable();
            matchBlueTab.Columns.Add("챔피언");
            matchBlueTab.Columns.Add("소환사");
            matchBlueTab.Columns.Add("K / D / A");
            matchBlueTab.Columns.Add("스펠");
            matchBlueTab.Columns.Add("아이템");
            matchBlueTab.Columns.Add("골드수급");
            matchBlueTab.Columns.Add("딜량");
            matchBlueTab.Columns.Add("피해량");

            matchRedTab = new DataTable();
            matchRedTab.Columns.Add("챔피언");
            matchRedTab.Columns.Add("소환사");
            matchRedTab.Columns.Add("K / D / A");
            matchRedTab.Columns.Add("스펠");
            matchRedTab.Columns.Add("아이템");
            matchRedTab.Columns.Add("골드수급");
            matchRedTab.Columns.Add("딜량");
            matchRedTab.Columns.Add("피해량");


            int a = e.RowIndex * 10;
            int blueSumGold = 0;
            int blueSumDeal = 0;
            int blueSumDamTaken = 0;
            int blueSumKills = 0;
            int blueSumDeaths = 0;
            int blueSumAssists = 0;
            for (int j = 0; j < 5; j++)
            {
                DataRow rowBlue = matchBlueTab.NewRow();
                int b = a + j;
                rowBlue["챔피언"] = lstPlayer[b].ChampionId;
                rowBlue["소환사"] = lstPlayer[b].SummonerName;
                rowBlue["K / D / A"] = lstPlayer[b].Kills + " / " + lstPlayer[b].Deaths + " / " + lstPlayer[b].Assists;
                rowBlue["스펠"] = lstPlayer[b].Spell1Id + " / " + lstPlayer[b].Spell2Id;
                rowBlue["아이템"] = lstPlayer[b].Item0 + "/" + lstPlayer[b].Item1 + "/" + lstPlayer[b].Item2 + "/" + lstPlayer[b].Item3 + "/" + lstPlayer[b].Item4 + "/" + lstPlayer[b].Item5 + "/" + lstPlayer[b].Item6;
                rowBlue["골드수급"] = lstPlayer[b].GoldEarned;
                rowBlue["딜량"] = lstPlayer[b].TotalDamageDealtToChampions;
                rowBlue["피해량"] = lstPlayer[b].TotalDamageTaken;

                blueSumGold = blueSumGold + lstPlayer[b].GoldEarned;
                blueSumDeal = blueSumDeal + lstPlayer[b].TotalDamageTaken;
                blueSumDamTaken = blueSumDamTaken + lstPlayer[b].TotalDamageTaken;
                blueSumKills = blueSumKills + lstPlayer[b].Kills;
                blueSumDeaths = blueSumDeaths + lstPlayer[b].Deaths;
                blueSumAssists = blueSumAssists + lstPlayer[b].Assists;

                matchBlueTab.Rows.Add(rowBlue);
            }


            int redSumGold = 0;
            int redSumDeal = 0;
            int redSumDamTaken = 0;
            int redSumKills = 0;
            int redSumDeaths = 0;
            int redSumAssists = 0;

            for (int k = 5; k < 10; k++)
            {
                DataRow rowRed = matchRedTab.NewRow();

                int c = a + k;

                rowRed["챔피언"] = lstPlayer[c].ChampionId;
                rowRed["소환사"] = lstPlayer[c].SummonerName;
                rowRed["K / D / A"] = lstPlayer[c].Kills + " / " + lstPlayer[c].Deaths + " / " + lstPlayer[c].Assists;
                rowRed["스펠"] = lstPlayer[c].Spell1Id + " / " + lstPlayer[c].Spell2Id;
                rowRed["아이템"] = lstPlayer[c].Item0 + "/" + lstPlayer[c].Item1 + "/" + lstPlayer[c].Item2 + "/" + lstPlayer[c].Item3 + "/" + lstPlayer[c].Item4 + "/" + lstPlayer[c].Item5 + "/" + lstPlayer[c].Item6;
                rowRed["골드수급"] = lstPlayer[c].GoldEarned;
                rowRed["딜량"] = lstPlayer[c].TotalDamageDealtToChampions;
                rowRed["피해량"] = lstPlayer[c].TotalDamageTaken;

                redSumGold = redSumGold + lstPlayer[c].GoldEarned;
                redSumDeal = redSumDeal + lstPlayer[c].TotalDamageTaken;
                redSumDamTaken = redSumDamTaken + lstPlayer[c].TotalDamageTaken;
                redSumKills = redSumKills + lstPlayer[c].Kills;
                redSumDeaths = redSumDeaths + lstPlayer[c].Deaths;
                redSumAssists = redSumAssists + lstPlayer[c].Assists;

                matchRedTab.Rows.Add(rowRed);
            }

            controlMatchInfo1.dgvBlueTeam.DataSource = matchBlueTab;
            controlMatchInfo1.dgvRedTeam.DataSource = matchRedTab;


            this.controlMatchInfo1.lblBlueSumDeal.Text = "총 입힌피해량 : " + blueSumDeal;
            this.controlMatchInfo1.lblBlueSumDTaken.Text = "총 입은피해량 : " + blueSumDamTaken;
            this.controlMatchInfo1.lblBlueSumGold.Text = "총 골드획득 : " + blueSumGold + " G";
            this.controlMatchInfo1.lblBlueSumKDA.Text = blueSumKills + " K / " + blueSumDeaths + " D / " + blueSumAssists + " A";
            this.controlMatchInfo1.lblBlueSumKDA.ForeColor = Color.GreenYellow;

            this.controlMatchInfo1.lblRedSumDeal.Text = "총 입힌피해량 : " + redSumDeal;
            this.controlMatchInfo1.lblRedSumDTaken.Text = "총 입은피해량 : " + redSumDamTaken;
            this.controlMatchInfo1.lblRedSumGold.Text = "총 골드획득 : " + redSumGold + " G";
            this.controlMatchInfo1.lblRedSumKDA.Text = redSumKills + " K / " + redSumDeaths + " D / " + redSumAssists + " A";
            this.controlMatchInfo1.lblRedSumKDA.ForeColor = Color.GreenYellow;
            this.controlMatchInfo1.txtGameTime.Text = "\r\n 플레이 시간  "+"\r\n      " + lstTime[e.RowIndex].EndTime;


            for (int i = 0; i < controlMatchInfo1.dgvBlueTeam.RowCount; i++)
            {
                for (int j = 0; j < controlMatchInfo1.dgvBlueTeam.ColumnCount; j++)
                {
                    this.controlMatchInfo1.dgvBlueTeam.Rows[i].Cells[j].Style.BackColor = Color.CornflowerBlue;
                    this.controlMatchInfo1.dgvRedTeam.Rows[i].Cells[j].Style.BackColor = Color.PaleVioletRed;
                }
            }
            this.controlMatchInfo1.dgvBlueTeam.EnableHeadersVisualStyles = false;
            this.controlMatchInfo1.dgvBlueTeam.ColumnHeadersDefaultCellStyle.BackColor = Color.LightYellow;
            this.controlMatchInfo1.dgvRedTeam.EnableHeadersVisualStyles = false;
            this.controlMatchInfo1.dgvRedTeam.ColumnHeadersDefaultCellStyle.BackColor = Color.LightYellow;


            int matchIndexNum = e.RowIndex * 2;
            if (lstMatInf[matchIndexNum].Win == "Win")
            {
                controlMatchInfo1.lblWin.Text = "블루팀 승리";
                controlMatchInfo1.lblWin.ForeColor = Color.CornflowerBlue;
            }
            else if (lstMatInf[matchIndexNum + 1].Win == "Win")
            {
                controlMatchInfo1.lblWin.Text = "레드팀 승리";
                controlMatchInfo1.lblWin.ForeColor = Color.PaleVioletRed;
            }
            else
            {
                controlMatchInfo1.lblWin.Text = "다시하기 및 탈주";
            }

            int sumDragon = lstMatInf[matchIndexNum].DragonKills + lstMatInf[matchIndexNum + 1].DragonKills;
            int sumBaron = lstMatInf[matchIndexNum].BaronKills + lstMatInf[matchIndexNum + 1].BaronKills;
            int sumTower = lstMatInf[matchIndexNum].TowerKills + lstMatInf[matchIndexNum + 1].TowerKills;
            int sumInhibitor = lstMatInf[matchIndexNum].InhibitorKills + lstMatInf[matchIndexNum + 1].InhibitorKills;

            this.controlMatchDetail1.label10.Text = "총 드래곤 : " + sumDragon;
            this.controlMatchDetail1.label12.Text = " 총 바론 : " + sumBaron;
            this.controlMatchDetail1.label9.Text = "총 타워파괴 : " + sumTower;
            this.controlMatchDetail1.label11.Text = " 총 억제기 파괴 : " + sumInhibitor;

            this.controlMatchDetail1.lblBlueDragon.Text = "드래곤 : " + lstMatInf[matchIndexNum].DragonKills;
            this.controlMatchDetail1.lblBlueBaron.Text = "바론 : " + lstMatInf[matchIndexNum].BaronKills;
            this.controlMatchDetail1.lblBlueTower.Text = "타워 : " + lstMatInf[matchIndexNum].TowerKills;
            this.controlMatchDetail1.lblBlueInhibitor.Text = "억제기 : " + lstMatInf[matchIndexNum].InhibitorKills;

            this.controlMatchDetail1.lblRedDragon.Text = "드래곤 : " + lstMatInf[matchIndexNum + 1].DragonKills;
            this.controlMatchDetail1.lblRedBaron.Text = "바론 : " + lstMatInf[matchIndexNum + 1].BaronKills;
            this.controlMatchDetail1.lblRedTower.Text = "타워 : " + lstMatInf[matchIndexNum + 1].TowerKills;
            this.controlMatchDetail1.lblRedInhibitor.Text = "억제기 : " + lstMatInf[matchIndexNum + 1].InhibitorKills;

            if (lstMatInf[matchIndexNum].FirstDragon)
            {
                this.controlMatchDetail1.lblDragon.Text = "첫 드래곤 : 블루팀";
                this.controlMatchDetail1.lblDragon.ForeColor = Color.Blue;
            }
            else if (lstMatInf[matchIndexNum + 1].FirstDragon)
            {
                this.controlMatchDetail1.lblDragon.Text = "첫 드래곤 : 레드팀";
                this.controlMatchDetail1.lblDragon.ForeColor = Color.Red;
            }
            else
            {
                this.controlMatchDetail1.lblDragon.Text = "첫 드래곤 : X";
                this.controlMatchDetail1.lblDragon.ForeColor = Color.GreenYellow;
            }

            if (lstMatInf[matchIndexNum].FirstBaron)
            {
                this.controlMatchDetail1.lblBaron.Text = "첫 바론 : 블루팀";
                this.controlMatchDetail1.lblBaron.ForeColor = Color.Blue;
            }
            else if (lstMatInf[matchIndexNum + 1].FirstBaron)
            {
                this.controlMatchDetail1.lblBaron.Text = "첫 바론 : 레드팀";
                this.controlMatchDetail1.lblBaron.ForeColor = Color.Red;
            }
            else
            {
                this.controlMatchDetail1.lblBaron.Text = "첫 바론 : X";
                this.controlMatchDetail1.lblBaron.ForeColor = Color.GreenYellow;

            }

            if (lstMatInf[matchIndexNum].FirstTower)
            {
                this.controlMatchDetail1.lblTower.Text = "첫 타워 : 블루팀";
                this.controlMatchDetail1.lblTower.ForeColor = Color.Blue;
            }
            else if (lstMatInf[matchIndexNum + 1].FirstTower)
            {
                this.controlMatchDetail1.lblTower.Text = "첫 타워 : 레드팀";
                this.controlMatchDetail1.lblTower.ForeColor = Color.Red;
            }
            else
            {
                this.controlMatchDetail1.lblTower.Text = "첫 타워 : X";
                this.controlMatchDetail1.lblTower.ForeColor = Color.GreenYellow;
            }

            if (lstMatInf[matchIndexNum].FirstInhibitor)
            {
                this.controlMatchDetail1.lblInhibitor.Text = "첫 억제기 : 블루팀";
                this.controlMatchDetail1.lblInhibitor.ForeColor = Color.Blue;
            }
            else if (lstMatInf[matchIndexNum + 1].FirstInhibitor)
            {
                this.controlMatchDetail1.lblInhibitor.Text = "첫 억제기 : 레드팀";
                this.controlMatchDetail1.lblInhibitor.ForeColor = Color.Red;
            }
            else
            {
                this.controlMatchDetail1.lblInhibitor.Text = "첫 억제기 : X";
                this.controlMatchDetail1.lblInhibitor.ForeColor = Color.GreenYellow;
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            this.controlMatchDetail1.Visible = false;
        }
    }
}
