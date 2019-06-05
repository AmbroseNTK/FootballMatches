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
    public class TestFinalRound
    {
        WorldCup worldCup;
        PreRound preRound;
        PlayOff playOff;
        OctRound octRound;
        QuadRound quadRound;
        FinalRound finalRound;
        private void Init(IProvider provider)
        {
            worldCup = new WorldCup();
            worldCup.TeamProvider = provider;

            preRound = new PreRound();
            playOff = new PlayOff();
            octRound = new OctRound();
            quadRound = new QuadRound();
            finalRound = new FinalRound();

            preRound.InputTeams = worldCup.TeamList;
            playOff.InputTeams = preRound.Play();
            octRound.InputTeams = playOff.Play();
            quadRound.InputTeams = octRound.Play();
            finalRound.InputTeams = quadRound.Play();
        }
        [TestMethod]
        public void Has2TeamInput()
        {
            Init(new TextProvider());
            Assert.AreEqual(2, finalRound.InputTeams.Count);
        }
        [TestMethod]
        public void Has2TeamInputWithSql()
        {
            Init(new SqlProvider());
            Assert.AreEqual(2, finalRound.InputTeams.Count);
        }

        [TestMethod]
        public void HasChampionTeam()
        {
            Init(new TextProvider());
            Assert.AreEqual(1, finalRound.Play().Count);
        }
        [TestMethod]
        public void HasChampionTeamWithSql()
        {
            Init(new SqlProvider());
            Assert.AreEqual(1, finalRound.Play().Count);
        }
    }
}
