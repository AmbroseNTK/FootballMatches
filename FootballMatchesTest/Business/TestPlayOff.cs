using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FootballLib.Rounds;
using System.Collections.Generic;

namespace FootballMatchesTest.Business
{
    [TestClass]
    public class TestPlayOff
    {
        [TestMethod]
        public void NumberOfTeamIs32()
        {
            PlayOff playOff = new PlayOff();
            Assert.AreEqual(32, playOff.MatchList.Count);
        }
    }
}
