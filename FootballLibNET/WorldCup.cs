using System;
using System.Collections.Generic;
using System.Text;

using FootballLib.DataProviders;

namespace FootballLib
{
    public class WorldCup
    {
        public IProvider TeamProvider { get; set; }
        public List<Rounds.Round> RoundList { get; set; }

        public List<Team> TeamList {
            get
            {
                return TeamProvider.TeamProvide();
            }
        }
        public Team Championship
        {
            get
            {
                return championship;
            }
        }

        private Team championship;
        
        public WorldCup()
        {
            RoundList = new List<Rounds.Round>();
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
