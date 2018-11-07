using EmpManage.Interfaces;
using EmpManage.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EmpManage.InMemoryDAL
{
    public class EmployeeDA : IEmployeeDataAccess
    {
        public bool AddEmployee(Employee employee)
        {
            InMemoryData inMemoryData = new InMemoryData();
            bool isAdded = false;

            if (!inMemoryData.employees.Exists(e => e.ID == employee.ID || (e.FirstName == employee.FirstName && e.LastName == employee.LastName) || e.Email == employee.Email || e.Phone == employee.Phone))
            {
                inMemoryData.employees.Add(employee);
                isAdded = true;
            }

            return isAdded;
        }

        public bool DeleteEmployee(Guid employeeID)
        {
            InMemoryData inMemoryData = new InMemoryData();
            bool isDeleted = false;

            if (inMemoryData.employees.Exists(e => e.ID == employeeID))
            {
                inMemoryData.employees.Remove(inMemoryData.employees.Find(e => e.ID == employeeID));
                isDeleted = true;
            }

            return isDeleted;
        }

        public List<Employee> GetAllEmployees()
        {
            InMemoryData inMemoryData = new InMemoryData();
            if (inMemoryData.employees != null)
            {
                return inMemoryData.employees;
            }
            return null;
        }

        public bool UpdateEmployee(Guid employeeID, Employee employee)
        {
            InMemoryData inMemoryData = new InMemoryData();
            bool isUpdated = false;
            try
            {
                inMemoryData.employees.Find(e => e.ID == employeeID).FirstName = employee.FirstName;
                inMemoryData.employees.Find(e => e.ID == employeeID).LastName = employee.LastName;
                inMemoryData.employees.Find(e => e.ID == employeeID).Email = employee.Email;
                inMemoryData.employees.Find(e => e.ID == employeeID).Phone = employee.Phone;
                inMemoryData.employees.Find(e => e.ID == employeeID).DepartmentId = employee.DepartmentId;
                inMemoryData.employees.Find(e => e.ID == employeeID).Gender = employee.Gender;

                var resultEmployee = inMemoryData.employees.Find(e => e.ID == employeeID);

                if (inMemoryData.employees.Exists(e => e.ID == employee.ID && e.FirstName == employee.FirstName && e.LastName == employee.LastName && e.Email == employee.Email && e.Phone == employee.Phone))
                {
                    isUpdated = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                isUpdated = false;
            }

            return isUpdated;
        }
    }
}
