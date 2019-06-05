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
    public class TestQuadRound
    {
        WorldCup worldCup;
        PreRound preRound;
        PlayOff playOff;
        OctRound octRound;
        QuadRound quadRound;
        private void Init(IProvider provider)
        {
            worldCup = new WorldCup();
            worldCup.TeamProvider = provider;

            preRound = new PreRound();
            playOff = new PlayOff();
            octRound = new OctRound();
            quadRound = new QuadRound();

            preRound.InputTeams = worldCup.TeamList;
            playOff.InputTeams = preRound.Play();
            octRound.InputTeams = playOff.Play();
            quadRound.InputTeams = octRound.Play();
        }
        [TestMethod]
        public void Has4TeamInput()
        {
            Init(new TextProvider());
            Assert.AreEqual(4, quadRound.InputTeams.Count);
        }
        [TestMethod]
        public void Has4TeamInputWithSql()
        {
            Init(new SqlProvider());
            Assert.AreEqual(4, quadRound.InputTeams.Count);
        }

        [TestMethod]
        public void Has2WonTeam()
        {
            Init(new TextProvider());
            Assert.AreEqual(2, quadRound.Play().Count);
        }
        [TestMethod]
        public void Has2WonTeamWithSql()
        {
            Init(new SqlProvider());
            Assert.AreEqual(2, quadRound.Play().Count);
        }
    }
}
