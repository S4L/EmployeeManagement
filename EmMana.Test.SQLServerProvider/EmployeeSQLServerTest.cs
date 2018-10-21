using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmMana.Test.SQLServerProvider
{
    [TestClass]
    public class EmployeeSQLServerTest
    {
        [TestMethod]
        public void GetConnectionStringByName_NotNull_GetConnectionStringFromConfigFile()
        {
            var connectionStr = ConfigurationManager.ConnectionStrings["LaptopDBCS"].ConnectionString;
            Assert.IsNotNull(connectionStr);
        }
    }
}
