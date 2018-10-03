using System;
using System.Collections.Generic;
using Employee_InMemory;
using EmployeeManagement_Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeManagement_DAL_Test.InMemory
{
    [TestClass]
    public class EmployeeInMemoryTest
    {
        [TestMethod]
        public void GetAllItems_SameResults_GetAllItemsFromList()
        {
            EmployeeInMemory employeeInMemory = new EmployeeInMemory();
            var employeesTest = new List<Employee>
            {
                new Employee{Id=1, FirstName="Jarvis",LastName="Vision",Email="jarvis@gmail.com",Phone="234-432-5645",DepartmentId=2,GenderId=1},
                new Employee{Id=2, FirstName="Jean",LastName="Grey",Email="jGrey@yahoo.com",Phone="458-789-2365",DepartmentId=4,GenderId=1},
                new Employee{Id=3, FirstName="Jon",LastName="Snow",Email="jonsnow@gmail.com",Phone="365-458-2563",DepartmentId=5,GenderId=2},
                new Employee{Id=4, FirstName="Kha",LastName="Tran",Email="khatran@hotmail.com",Phone="714-285-7695",DepartmentId=1,GenderId=1},
                new Employee{Id=5, FirstName="Tony",LastName="Stark",Email="ironman@gmail.com",Phone="125-745-2365",DepartmentId=3,GenderId=1}
            };

            var resultList = employeeInMemory.GetAllItems();

            CollectionAssert.AreEqual(employeesTest, resultList);
        }
    }
}
