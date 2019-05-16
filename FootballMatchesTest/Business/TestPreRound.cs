using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FootballLib;

namespace FootballMatchesTest.Business
{
    [TestClass]
    public class TestPreRound
    {
        private static List<Team> GetPreRoundResult()
        {
            WorldCup worldCup = new WorldCup();
            worldCup.TeamProvider = new FootballLib.DataProviders.TextProvider("test.txt");
            FootballLib.Rounds.PreRound preRound = new FootballLib.Rounds.PreRound();
            preRound.InputTeams = worldCup.TeamList;
            List<Team> result = preRound.Play();
            return result;
        }

        [TestMethod]
        public void NumberOfTeamIs32()
        {
            List<Team> result = GetPreRoundResult();

            Assert.AreEqual(result.Count, 32);
        }

        [TestMethod]
        public void AsiaHas5To6Team()
        {

            List<Team> result = GetPreRoundResult();

            int countAsia = result.Where((team) => team.Area == Area.Asia).ToList().Count;
            Assert.AreEqual(countAsia > 4 && countAsia < 7, true);
         }
        
    }
}
