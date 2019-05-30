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
            bool isWon = false;
            foreach (string groupID in groups)
            {
                matchesInGroup = MatchList.Where(match => match.Tag == groupID).ToList();
                foreach(Match match in matchesInGroup)
                {
                    isWon = rand.Next(0, 2) == 0 ? false : true;
                    if (isWon)
                    {
                        match.TeamA.TotalScore += 1;
                    }
                    else
                    {
                        match.TeamB.TotalScore += 1;
                    }
                }
                roundResult.Add(GetHighestScoreTeam(CalculateTotalScore(matchesInGroup)));
            }
            return roundResult;
        }

        public List<Team> CalculateTotalScore(List<Match> matches)
        {
            List<Team> result = new List<Team>();
            List<string> codes = new List<string>();
            List<Match> matchesOfThisTeam = new List<Match>();
            List<Team> twoTeam = new List<Team>();
            foreach(Match match in matches)
            {
                twoTeam = new List<Team>() { match.TeamA, match.TeamB };
                foreach (Team selectedTeam in twoTeam)
                {
                    if (!codes.Contains(selectedTeam.Code))
                    {
                        int total = 0;
                        matchesOfThisTeam = matches.Where(m => m.TeamA.Code == selectedTeam.Code || m.TeamB.Code == selectedTeam.Code).ToList();
                        foreach (Match m in matchesOfThisTeam)
                        {
                            if (m.TeamA.Code == selectedTeam.Code)
                            {
                                total += m.TeamA.TotalScore;
                            }
                            else
                            {
                                total += m.TeamB.TotalScore;
                            }
                        }
                        codes.Add(selectedTeam.Code);
                        selectedTeam.TotalScore = total;
                        result.Add(selectedTeam);
                    }
                }
            }
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
            foreach(string groupID in groups)
            {
                group = new List<Team>();
                //Set 4 team for 1 group
                for(int i = 0; i < 4; i++)
                {
                    selection = rand.Next(0, tempList.Count - 1);
                    group.Add(tempList[selection]);
                    tempList.RemoveAt(selection);
                }
                // Create matches for a group
                for(int i = 0; i < 4; i++)
                {
                    for(int j = 0; j < 4; j++)
                    {
                        if (i != j)
                        {
                            MatchList.Add(new Match()
                            {
                                TeamA = group[i],
                                TeamB = group[j],
                                Location = new Location(),
                                Date = DateTime.Now,
                                Tag = groupID
                            });
                        }
                    }
                }
            }
        }
    }
}
