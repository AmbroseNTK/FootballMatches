using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLib.Rounds
{
    public class OctRound : Round
    {

        Random rand = new Random();
        public override List<Team> Play()
        {
            List<Team> result = new List<Team>();
            CreateMatches();
            foreach(Match match in MatchList)
            {
                match.Play(rand);
                result.Add(match.Winner);
            }
            return result;
        }

        public void CreateMatches()
        {
            MatchList = new List<Match>();
            List<Team> tempList = InputTeams;
            while (tempList.Count > 1)
            {
                int selection = rand.Next(0, tempList.Count);
                Team teamA = tempList[selection];
                tempList.RemoveAt(selection);
                selection = rand.Next(0, tempList.Count);
                Team teamB = tempList[selection];
                tempList.RemoveAt(selection);
                MatchList.Add(new Match()
                {
                    TeamA = teamA,
                    TeamB = teamB,
                    Date = DateTime.Now,
                    Location = new Location()
                });
            }
        }
    }
}
