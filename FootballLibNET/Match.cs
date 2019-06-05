using System;

namespace FootballLib
{
    public class Match
    {
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public DateTime Date { get; set; }
        public Location Location { get; set; }
        public string Tag { get; set; }
        public int AScore { get; set; }
        public int BScore { get; set; }

        int status;

        private Random rand = new Random();

        public void Play(Random rand)
        {
            status = rand.Next(0, 3);
            int winScore = rand.Next(1, 6);
            int loseScore = rand.Next(0, winScore);

            if (status == 0)
            {
                TeamA.TotalScore += 3;
                AScore = winScore;
                BScore = loseScore;
            }
            else if (status == 1)
            {
                TeamB.TotalScore += 3;
                BScore = winScore;
                AScore = winScore;
            }
            else
            {
                TeamA.TotalScore += 1;
                TeamB.TotalScore += 1;
                AScore = winScore;
                BScore = winScore;
            }
            DistribScore(TeamA, AScore);
            DistribScore(TeamB, BScore);
        }

        public Team Winner
        {
            get
            {
                return status == 0 ? TeamA : TeamB;
            }
        }

        public void DistribScore(Team team, int score)
        {
            while (score > 0)
            {
                int selectedPlayer = rand.Next(0, team.PlayerList.Count);
                int s = rand.Next(1, score);
                team.PlayerList[selectedPlayer].Score = s;
                score -= s;
            }
        }
        
    }
}