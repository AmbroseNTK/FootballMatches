using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FootballLib.DataProviders
{
    public class TextProvider : IProvider
    {
        private string fileCountriesName;
        private string filePlayerName;

        public int MaximumPlayer = 22;

        private Random rand = new Random();

        public TextProvider(string fileCountriesName = "countries.txt", string filePlayerName="players.txt")
        {
            this.fileCountriesName = fileCountriesName;
            this.filePlayerName = filePlayerName;
        }

        public List<Team> TeamProvide()
        {
            string playerRaw = System.IO.File.ReadAllText(filePlayerName);
            string[] playerLines = playerRaw.Split('\n');
            List<Player> players = new List<Player>();
            for(int i = 0; i < playerLines.Length; i++)
            {
                string[] tokens = playerLines[i].Split(';');
                players.Add(new Player()
                {
                    Name = tokens[0],
                    Nation = tokens[1],
                    Score = 0
                });
            }

            string data = System.IO.File.ReadAllText(fileCountriesName);
            string[] lines = data.Split('\n');
            List<Team> teamList = new List<Team>();
            for (int i = 0; i < lines.Length; i++)
            {
                string[] tokens = lines[i].Split(';');
                List<Player> listPlayer = players.Where(player => player.Nation.Trim().ToLower() == tokens[1].Trim().ToLower()).ToList();
                while(listPlayer.Count< MaximumPlayer)
                {
                    listPlayer.Add(new Player()
                    {
                        Name = "PPlayer#" + (1000 + rand.Next(0, 9999)),
                        Nation = tokens[1],
                        Role=tokens[2],
                        Score = 0
                    });
                }
                while (listPlayer.Count > MaximumPlayer)
                {
                    listPlayer.RemoveAt(rand.Next(0, listPlayer.Count));
                }
                Team team = new Team()
                {
                    Code = tokens[0],
                    Name = tokens[1],
                    Area = AreaUtil.GetAreaFromString(tokens[2].Trim()),
                    TotalScore = 0,
                    PlayerList = listPlayer
                };
                teamList.Add(team);

            }
            return teamList;
        }

    }
}
