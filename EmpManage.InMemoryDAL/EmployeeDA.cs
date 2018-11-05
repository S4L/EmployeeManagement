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
        private InMemoryData inMemoryData;

        public bool AddEmployee(Employee employee)
        {
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
            bool isDeleted = false;

            if (inMemoryData.employees.Exists(e => e.ID == employeeID))
            {
                inMemoryData.employees.Remove(inMemoryData.employees.Find(e => e.ID == employeeID));
                isDeleted = true;
            }

            return isDeleted;
        }

        public Employee GetEmployeeByID(Guid employeeID)
        {
            try
            {
                return inMemoryData.employees.Find(e => e.ID == employeeID);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new ArgumentNullException();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            if(inMemoryData.employees != null)
            {
                return inMemoryData.employees;
            }
            return null;
        }

        public bool UpdateEmployee(Guid employeeID, Employee employee)
        {
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

        //public List<Employee> GetSpecificEmployees(Func<Employee, bool> func)
        //{
        //    return null;
        //}
    }
}
