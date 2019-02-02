using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.InMemoryDAL;
using EMS.UI.ViewModels;
using System.Configuration;

namespace EmpManage.Test.ViewModel
{
    [TestClass]
    public class MainVMTest
    {
        readonly InMemoryData inMemoryData = new InMemoryData();

        [TestMethod]
        public void GetConfigString_True_ConfigStringNotEmpty()
        {
            var configString = ConfigurationManager.AppSettings["EmployeeSQLServer"];

            Assert.IsTrue(configString != "");
        }

        [TestMethod]
        public void GetConfigString_True_ConfigStringMatchExpected()
        {
            var expectedConfigStr = "EmpManage.SQLServerDAL.EmployeeDA, EmpManage.SQLServerDAL";
            var configString = ConfigurationManager.AppSettings["EmployeeSQLServer"];

            Assert.IsTrue(configString == expectedConfigStr);
        }

        [TestMethod]
        public void GetEmployeesForEach()
        {
            var employeesVM = new List<EmployeeVM>();
            foreach (var employee in inMemoryData.Employees)
                employeesVM.Add(new EmployeeVM
                {
                    ID = employee.ID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    Department = inMemoryData.Departments.FirstOrDefault(department => department.ID == employee.DepartmentId).Name
                });

            Assert.IsTrue(employeesVM.Count > 0);
        }

        [TestMethod]
        public void GetEmployeesLinq()
        {
            var employeesVM = new List<EmployeeVM>();
            var employeeList = from employee in inMemoryData.Employees
                               join department in inMemoryData.Departments
                               on employee.DepartmentId equals department.ID
                               select new EmployeeVM
                               {
                                   ID = employee.ID,
                                   FirstName = employee.FirstName,
                                   LastName = employee.LastName,
                                   Email = employee.Email,
                                   Phone = employee.Phone,
                                   Department = department.Name,
                                   Gender = employee.Gender
                               };

            Assert.IsTrue(employeeList.ToList().Count > 0);
        }
    }
}
