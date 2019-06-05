using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SQLite;
using System.Data.SQLite.Linq;

namespace FootballLib.DataProviders
{
    public class SqlProvider: IProvider
    {
        SQLiteConnection connection;
        SQLiteDataReader dataReader;
        SQLiteCommand command;

        public int MaximumPlayer = 22;

        Random rand = new Random();

        public SqlProvider(string db = "FootballDB.db")
        {
            connection = new SQLiteConnection("Data Source=" + db + ";Version=3;");
            connection.Open();
        }

        public List<Team> TeamProvide()
        {
            List<Team> result = new List<Team>();
            List<Player> players = new List<Player>();
            command = new SQLiteCommand("SELECT * FROM Players",connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                players.Add(new Player()
                {
                    Name = dataReader.GetValue(0).ToString(),
                    Nation = dataReader.GetValue(1).ToString(),
                    Role = dataReader.GetValue(2).ToString(),
                });
            }

            command = new SQLiteCommand("SELECT * FROM Countries", connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                string[] tokens = new string[] { dataReader.GetValue(0).ToString(), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString() };
                    List<Player> listPlayer = players.Where(player => player.Nation.Trim().ToLower() == tokens[1].Trim().ToLower()).ToList();
                while (listPlayer.Count < MaximumPlayer)
                {
                    listPlayer.Add(new Player()
                    {
                        Name = "PPlayer#" + (1000 + rand.Next(0, 9999)),
                        Nation = tokens[1],
                        Score = 0,
                        Role = tokens[2]
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
                result.Add(team);
            }

            connection.Close();

            return result;
        }
    }
}
