using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballLib.DataProviders;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FootballMatchesTest.Structure
{
    [TestClass]
    public class TestSqlProvider
    {
        [TestMethod]
        public void CheckConnection()
        {
            try
            {
                SqlProvider provider = new SqlProvider();
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
