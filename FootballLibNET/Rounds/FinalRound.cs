using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLib.Rounds
{
    public class FinalRound : Round
    {
        Random rand = new Random();
        public override List<Team> Play()
        {
            MatchList = new List<Match>()
            {
                new Match()
                {
                    TeamA = InputTeams[0],
                    TeamB = InputTeams[1],
                    Date = DateTime.Now,
                    Location = new Location()
                }
            };
            return new List<Team>() { rand.Next(0, 2) == 0 ? MatchList[0].TeamA : MatchList[0].TeamB };
        }
    }
}
