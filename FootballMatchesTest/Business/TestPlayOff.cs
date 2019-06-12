using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FootballLib;
using FootballLib.DataProviders;
using FootballLib.Rounds;

namespace FootballMatchesTest.Business
{
    [TestClass]
    public class TestPlayOff
    {
        string[] groups = new string[]{ "A", "B", "C", "D", "E", "F", "G", "H" };

        WorldCup worldCup;
        PreRound preRound;
        PlayOff playOff;

        public TestPlayOff()
        {
           
        }

        public void Init(IProvider provider)
        {
            worldCup = new WorldCup();
            worldCup.TeamProvider = provider;

            preRound = new PreRound();
            preRound.InputTeams = worldCup.TeamList;


            playOff = new PlayOff();
            playOff.InputTeams = preRound.Play();
        }

        private void Check8Group()
        {
            playOff.Play();

            List<Match> matches = new List<Match>();

            foreach (string groupID in groups)
            {
                matches = playOff.MatchList.Where(match => match.Tag == groupID).ToList();
                if (matches.Count != 6)
                {
                    Assert.Fail("Group " + groupID + " has " + matches.Count + " match(es)");
                }
            }
        }

        private void Check22Player()
        {
            playOff.Play();
            foreach(Team team in playOff.InputTeams)
            {
                if (team.PlayerList.Count != 22)
                {
                    Assert.Fail(team.Name + " did not have enough 22 players: " + team.PlayerList.Count);
                }
            }
        }
        

        [TestMethod]
        public void Has8Groups()
        {
            Init(new TextProvider());
            Check8Group();
        }
        [TestMethod]
        public void Has8GroupsWithSql()
        {
            Init(new SqlProvider());
            Check8Group();
        }
        [TestMethod]
        public void Has8WonTeam()
        {
            Init(new TextProvider());
            List<Team> result = playOff.Play();
            Assert.AreEqual(8, result.Count);
        }
        [TestMethod]
        public void Has8WonTeamWithSql()
        {
            Init(new SqlProvider());
            List<Team> result = playOff.Play();
            Assert.AreEqual(8, result.Count);
        }
        [TestMethod]
        public void EachTeamHas22Player()
        {
            Init(new TextProvider());
            Check22Player();
        }

        [TestMethod]
        public void EachTeamHas22PlayerWithSql()
        {
            Init(new SqlProvider());
            Check22Player();
        }

        [TestMethod]
        public void MaximumScoreLessOrEqual9()
        {
            Init(new TextProvider());
            List<Team> result = playOff.Play();
            foreach(Team team in result)
            {
                if(team.TotalScore > 9)
                {
                    Assert.Fail("Total score greater than 9");
                }
            }
        }
       
    }
}
