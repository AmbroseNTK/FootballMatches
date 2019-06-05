using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FootballLib;
using System.Collections.Generic;

namespace FootballMatchesTest.Structure
{
    [TestClass]
    public class TestMatches
    {
        private Match match;
        private int maximumNumOfTeam = 3;
        public TestMatches()
        {
            match = new Match();
        }
        
        public PropertyInfo[] GetProperties(object target, Type type)
        {
            PropertyInfo[] props = target.GetType().GetProperties();
            List<PropertyInfo> result = new List<PropertyInfo>();
            for (int i = 0; i < props.Length; i++)
            {
                if(props[i].PropertyType == type)
                {
                    result.Add(props[i]);
                }
            }
            return result.ToArray();
        }

        [TestMethod]
        public void TestTeamProperties()
        {
            PropertyInfo[] result = GetProperties(new Match(), typeof(Team));
            Assert.AreEqual(maximumNumOfTeam,result.Length);
        }

        [TestMethod]
        public void TestMatchDate()
        {
            PropertyInfo[] result = GetProperties(new Match(), typeof(DateTime));
            Assert.AreEqual(1, result.Length);
        }

        [TestMethod]
        public void TestMatchLocation()
        {
            PropertyInfo[] result = GetProperties(match, typeof(Location));
            Assert.AreEqual(1, result.Length);
        }
    }
}
