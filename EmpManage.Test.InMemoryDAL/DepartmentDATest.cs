using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmpManage.Models;
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
            new Department{ID = 1, Name ="Sales"},
            new Department{ID = 2, Name ="Customer Support"},
            new Department{ID = 3, Name ="IT"},
            new Department{ID = 4, Name ="Quality Assurance"},
            new Department{ID = 5, Name ="Finance"}
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
        public void GetDepartmentNameByDepartmentID_SameDepartmentName_CorrectDepartmentID(string expectedName, int departmentID)
        {
            Assert.AreEqual(expectedName, departments.Find(d => d.ID == departmentID)?.Name ?? "");
        }

        [TestMethod]
        [DataRow(6)]
        [DataRow(8)]
        [DataRow(7)]
        [DataRow(9)]
        public void GetDepartmentNameByDepartmentID_ReturnEmptyString_IncorrectDepartmentID(int departmentID)
        {
            Assert.AreEqual("", departments.Find(d => d.ID == departmentID)?.Name ?? "");
        }
    }
}
