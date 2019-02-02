using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmpManage.Test.BLL
{
    [TestClass]
    public class EmployeeBLTest
    {
        [TestMethod]
        public void GetTypeFromConfigString_True_ValueNotNull()
        {
           // var configString = ConfigurationManager.AppSettings["EmployeeSQLServer"];
            var configStr = "EmpManage.SQLServerDAL.EmployeeDA, EmpManage.SQLServerDAL";
            var providerType = Type.GetType(configStr);

            Assert.AreNotEqual(null,providerType);
        }
    }
}
