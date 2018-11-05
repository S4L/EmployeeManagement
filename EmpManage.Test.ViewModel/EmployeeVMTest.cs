using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpManage.InMemoryDAL;
using EmMana.WPF.Model;

namespace EmpManage.Test.ViewModel
{
    [TestClass]
    public class EmployeeVMTest
    {
        readonly InMemoryData inMemoryData = new InMemoryData();

        [TestMethod]
        public void GetEmployeesForEach()
        {
            var employeesVM = new List<Employee>();
            foreach (var employee in inMemoryData.employees)
                employeesVM.Add(new Employee
                {
                    ID = employee.ID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    Department = inMemoryData.departments.FirstOrDefault(department => department.ID == employee.DepartmentId).Name
                });

            Assert.IsTrue(employeesVM.Count > 0);
        }

        [TestMethod]
        public void GetEmployeesLinq()
        {
            var employeesVM = new List<Employee>();
            var employeeList = from employee in inMemoryData.employees
                               join department in inMemoryData.departments
                               on employee.DepartmentId equals department.ID
                               select new Employee
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
