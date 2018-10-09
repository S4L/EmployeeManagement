using System;
using System.Collections.Generic;
using EmployeeMemoryProvider;
using EmployeeManagement_Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeManagement_DAL_Test.InMemory
{
    [TestClass]
    public class EmployeeInMemoryTest
    {
        public List<EmployeeCommon> employeesTest = new List<EmployeeCommon>
            {
                new EmployeeCommon{Id=1, FirstName="Jarvis",LastName="Vision",Email="jarvis@gmail.com",Phone="234-432-5645",DepartmentId=2,GenderId=1},
                new EmployeeCommon{Id=2, FirstName="Jean",LastName="Grey",Email="jGrey@yahoo.com",Phone="458-789-2365",DepartmentId=4,GenderId=1},
                new EmployeeCommon{Id=3, FirstName="Jon",LastName="Snow",Email="jonsnow@gmail.com",Phone="365-458-2563",DepartmentId=5,GenderId=2},
                new EmployeeCommon{Id=4, FirstName="Kha",LastName="Tran",Email="khatran@hotmail.com",Phone="714-285-7695",DepartmentId=1,GenderId=1},
                new EmployeeCommon{Id=5, FirstName="Tony",LastName="Stark",Email="ironman@gmail.com",Phone="125-745-2365",DepartmentId=3,GenderId=1}
            };

        private EmployeeInMemory employeeInMemory = new EmployeeInMemory();

        [TestMethod]
        public void GetAllItems_SameResults_GetAllItemsFromList()
        {
            CollectionAssert.AreEqual(employeesTest, employeeInMemory.GetAllEmployees());
        }

        [TestMethod]
        public void GetAllItems_NotSameResults_GetAllItemsFromList()
        {
            EmployeeInMemory employeeInMemory = new EmployeeInMemory();
            List<EmployeeCommon> employeesTest2 = new List<EmployeeCommon>
            {
                new EmployeeCommon{Id=1, FirstName="Hulk",LastName="Vision",Email="jarvis@gmail.com",Phone="234-432-5645",DepartmentId=2,GenderId=1},
                new EmployeeCommon{Id=2, FirstName="Jean",LastName="Grey",Email="jGrey@yahoo.com",Phone="458-789-2365",DepartmentId=4,GenderId=1},
                new EmployeeCommon{Id=3, FirstName="Moon",LastName="Snow",Email="jonsnow@gmail.com",Phone="458-458-2563",DepartmentId=5,GenderId=2},
                new EmployeeCommon{Id=4, FirstName="Kha",LastName="Tran",Email="khatran@hotmail.com",Phone="714-285-7695",DepartmentId=1,GenderId=1},
                new EmployeeCommon{Id=5, FirstName="Peter",LastName="Stark",Email="ironman@gmail.com",Phone="125-745-2365",DepartmentId=4,GenderId=1}
            };

            List<EmployeeCommon> resultList = employeeInMemory.GetAllEmployees();

            for (int index = 0; index < employeesTest2.Count; index++)
            {
                Assert.IsFalse(employeesTest2[index] == resultList[index]);
            }
        }


        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        public void GetItemById_Same_GetItemFromList(int targetID)
        {
            Assert.AreEqual(targetID, employeeInMemory.GetEmployeeByID(targetID).Id);
        }
    }
}
