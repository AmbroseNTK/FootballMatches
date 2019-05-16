using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLib.Rounds
{
    public abstract class Round
    {
        public List<Match> MatchList { get; set; }
        public List<Team> InputTeams { get; set; }
        public abstract List<Team> Play();
    }
}
