using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLib.DataProviders
{
    public class TextProvider : IProvider
    {
        private string fileName;

        public TextProvider(string fileName)
        {
            this.fileName = fileName;
        }
        public List<Team> Provide()
        {
            string data = System.IO.File.ReadAllText(fileName);
            string[] lines = data.Split('\n');
            List<Team> teamList = new List<Team>();
            for(int i = 0; i < lines.Length; i++)
            {
                string[] tokens = lines[i].Split(';');
                Team team = new Team()
                {
                    Code = tokens[0],
                    Name = tokens[1],
                    Area = AreaUtil.GetAreaFromString(tokens[2]),
                    TotalScore = 0
                };
                teamList.Add(team);
            }
            return teamList;
        }
    }
}
