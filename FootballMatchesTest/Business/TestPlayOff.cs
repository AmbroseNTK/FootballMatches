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
            worldCup = new WorldCup();
            worldCup.TeamProvider = new TextProvider("countries.txt");

            preRound = new PreRound();
            preRound.InputTeams = worldCup.TeamList;


            playOff = new PlayOff();
            playOff.InputTeams = preRound.Play();
        }
        

        [TestMethod]
        public void Has8Groups()
        {

            playOff.Play();

            List<Match> matches = new List<Match>();

            foreach(string groupID in groups)
            {
                matches = playOff.MatchList.Where(match => match.Tag == groupID).ToList();
                if (matches.Count != 12)
                {
                    Assert.Fail("Group " + groupID + " has " + matches.Count + " match(es)");
                }
            }
        }
        [TestMethod]
        public void Has8WonTeam()
        {
            List<Team> result = playOff.Play();
            Assert.AreEqual(8, result.Count);
        }
    }
}
