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
    public class TestOctRound
    {
        [TestMethod]
        public void Has4WonTeam()
        {
            WorldCup worldCup = new WorldCup();
            worldCup.TeamProvider = new TextProvider("countries.txt");
            PreRound preRound = new PreRound();
            PlayOff playOff = new PlayOff();
            OctRound octRound = new OctRound();

            preRound.InputTeams = worldCup.TeamList;
            playOff.InputTeams = preRound.Play();
            octRound.InputTeams = playOff.Play();

            Assert.AreEqual(4, octRound.Play().Count);

        }
    }
}
