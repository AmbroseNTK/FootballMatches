using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLib
{
    public class WorldCup
    {
        public List<Rounds.Round> RoundList { get; set; }
        public List<Team> TeamList { get; set; }
        public Team Championship
        {
            get
            {
                return championship;
            }
        }

        private Team championship;
        
        public List<Team> GenerateInputTeam()
        {
            return null;
        }

        public void Play()
        {
            List<Team> previousResult = TeamList;
            foreach (Rounds.Round round in RoundList)
            {
                round.InputTeams = previousResult;
                previousResult = round.Play();
            }
            this.championship = previousResult[0];
        }
    }
}
