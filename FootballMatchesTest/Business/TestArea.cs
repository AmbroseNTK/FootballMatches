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
    public class TestArea
    {
        [TestMethod]
        public void AsiaRateIsCorrect()
        {
            Assert.AreEqual(true, AreaUtil.GetRateFromArea(Area.Asia) == 5.5d);
        }
        [TestMethod]
        public void EuropeRateIsCorrect()
        {
            Assert.AreEqual(true, AreaUtil.GetRateFromArea(Area.Europe) == 13d);
        }
        [TestMethod]
        public void AfricaRateIsCorrect()
        {
            Assert.AreEqual(true, AreaUtil.GetRateFromArea(Area.Africa) == 5d);
        }
        [TestMethod]
        public void NorthAmericaRateIsCorrect()
        {
            Assert.AreEqual(true, AreaUtil.GetRateFromArea(Area.NorthAmerica) == 3.5d);
        }
        [TestMethod]
        public void SouthAmericaRateIsCorrect()
        {
            Assert.AreEqual(true, AreaUtil.GetRateFromArea(Area.SouthAmerica) == 3.5d);
        }
        [TestMethod]
        public void OceaniaRateIsCorrect()
        {
            Assert.AreEqual(true, AreaUtil.GetRateFromArea(Area.Oceania) == 0.5d);
        }
        [TestMethod]
        public void GetAreaFromString()
        {
            Assert.AreEqual(AreaUtil.GetAreaFromString("Asia"), Area.Asia);
        }
    }
}
