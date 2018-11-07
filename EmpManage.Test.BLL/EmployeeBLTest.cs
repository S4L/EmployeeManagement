using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmpManage.Test.BLL
{
    [TestClass]
    public class EmployeeBLTest
    {
        [TestMethod]
        public void GetTypeFromConfigString_True_ValueNotNull()
        {
            var configStr = "EmpManage.SQLServerDAL.EmployeeDA, EmpManage.SQLServerDAL";
            var providerType = Type.GetType(configStr);

            Assert.IsTrue(providerType != null);
        }
    }
}
