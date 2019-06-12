using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace FootballLib.Rounds
{
  
    public class PlayOff : Round
    {
        string[] groups = new string[]{ "A", "B", "C", "D", "E", "F", "G", "H" };
        Random rand = new Random();
        public override List<Team> Play()
        {
            List<Team> roundResult = new List<Team>();
            DividedIntoGroup();
            List<Match> matchesInGroup = new List<Match>();
           
            foreach (string groupID in groups)
            {
                matchesInGroup = MatchList.Where(match => match.Tag == groupID).ToList();
                foreach(Match match in matchesInGroup)
                {
                    match.Play(rand);
                }

                List<Team> scored = CalculateTotalScore(matchesInGroup);
                roundResult.Add(scored.Where(t => t.TotalScore == scored.Max(t1 => t1.TotalScore)).ToList()[0]);
                
            }
            return roundResult;
        }


        public List<Team> CalculateTotalScore(List<Match> matches)
        {
            List<Team> result = new List<Team>();
            foreach(Match match in matches)
            {
                result.Add(match.TeamA);
                result.Add(match.TeamB);
            }
            var groups = result.GroupBy(team => team.Code).Select(team => team.Sum(t => t.TotalScore));
            
            
            return result;
        }

        public Team GetHighestScoreTeam(List<Team> teams)
        {
            return teams.Where(team => team.TotalScore == teams.Max(t => t.TotalScore)).ToList()[0];
        }

        public void DividedIntoGroup()
        {
            MatchList = new List<Match>();
            List<Team> tempList = InputTeams;
            List<Team> group = new List<Team>();

            int selection = 0;
            foreach (string groupID in groups)
            {
                group = new List<Team>();
                //Set 4 team for 1 group
                for (int i = 0; i < 4; i++)
                {
                    selection = rand.Next(0, tempList.Count - 1);
                    group.Add(tempList[selection]);
                    tempList.RemoveAt(selection);
                }
                // Create matches for a group

                int[] listA = { 0, 0, 0, 3, 3, 1 };
                int[] listB = { 1, 2, 3, 1, 2, 2 };

                for (int i = 0; i < listA.Length; i++)
                {
                    MatchList.Add(new Match()
                    {
                        TeamA = group[listA[i]],
                        TeamB = group[listB[i]],
                        Location = new Location(),
                        Date = DateTime.Now,
                        Tag = groupID
                    });
                }
            }
        }
    }
}
