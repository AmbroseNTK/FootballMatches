using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FootballLib.DataProviders;
using FootballLib.Rounds;
using FootballLib;

namespace FootballMatchesTest.Business
{
    [TestClass]
    public class TestPreRound
    {
        WorldCup worldCup;
        PreRound preRound;
        private void Init(IProvider provider)
        {
            worldCup = new WorldCup();
            worldCup.TeamProvider = provider;
            preRound = new PreRound();
            preRound.InputTeams = worldCup.TeamList;
        }

        private List<Team> GetPreRoundResult(IProvider provider)
        {
            Init(provider);
            List<Team> result = preRound.Play();
            return result;
        }

        [TestMethod]
        public void NumberOfTeamIs32()
        {
            List<Team> result = GetPreRoundResult(new TextProvider());

            Assert.AreEqual(32,result.Count);
        }
        [TestMethod]
        public void NumberOfTeamIs32WithSql()
        {
            List<Team> result = GetPreRoundResult(new SqlProvider());

            Assert.AreEqual(32, result.Count);
        }

        [TestMethod]
        public void AsiaHas5To6Team()
        {
            List<Team> result = GetPreRoundResult(new TextProvider());
            int countAsia = result.Where((team) => team.Area == Area.Asia).ToList().Count;
            Assert.AreEqual(true, countAsia > 4 && countAsia < 7);
        }
        [TestMethod]
        public void AsiaHas5To6TeamWithSql()
        {
            List<Team> result = GetPreRoundResult(new SqlProvider());
            int countAsia = result.Where((team) => team.Area == Area.Asia).ToList().Count;
            Assert.AreEqual(true, countAsia > 4 && countAsia < 7);
        }
        private void Check22Player()
        {
            preRound.Play();
            foreach (Team team in preRound.InputTeams)
            {
                if (team.PlayerList.Count != 22)
                {
                    Assert.Fail(team.Name + " did not have enough 22 players: " + team.PlayerList.Count);
                }
            }
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

    }
}
