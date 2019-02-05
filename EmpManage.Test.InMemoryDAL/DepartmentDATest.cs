using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMS.Models;
using System.Linq;

namespace EmpManage.Test.InMemoryDAL
{
    /// <summary>
    /// Summary description for DepartmentDATest
    /// </summary>
    [TestClass]
    public class DepartmentDATest
    {
        List<Department> departments = new List<Department>
        {
            new Department{ID = new Guid("C094B719-B0B8-4501-BD61-BC6EAC2442B4"), Name ="Sales"},
            new Department{ID = new Guid("5C87B6AD-4A6D-48E5-80AA-561BBE861774"), Name ="Customer Support"},
            new Department{ID = new Guid("EB0B3BA2-C0C8-4EA4-9287-B9DE848A668D"), Name ="IT"},
            new Department{ID = new Guid("79F1CDAF-CAD9-49C4-BC04-D991480F7CF2"), Name ="Quality Assurance"},
            new Department{ID = new Guid("04CEEA7B-A771-4584-B9A7-BB465672E629"), Name ="Finance"}
        };
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        [DataRow("Sales",1)]
        [DataRow("Customer Support", 2)]
        [DataRow("IT", 3)]
        [DataRow("Quality Assurance", 4)]
        [DataRow("Finance", 5)]
        public void GetDepartmentNameByDepartmentID_SameDepartmentName_CorrectDepartmentID(string expectedName, Guid departmentID)
        {
            Assert.AreEqual(expectedName, departments.Find(d => d.ID == departmentID)?.Name ?? "");
        }

        [TestMethod]
        [DataRow(6)]
        [DataRow(8)]
        [DataRow(7)]
        [DataRow(9)]
        public void GetDepartmentNameByDepartmentID_ReturnEmptyString_IncorrectDepartmentID(Guid departmentID)
        {
            Assert.AreEqual("", departments.Find(d => d.ID == departmentID)?.Name ?? "");
        }
    }
}
