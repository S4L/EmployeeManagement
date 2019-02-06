using EMS.Interfaces;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.InMemoryDAL
{
    public class EmployeeDA : IEmployee
    {
        private InMemoryData _employees;

        public EmployeeDA()
        {
            _employees = new InMemoryData();
        }

        public bool AddEmployee(Employee employee)
        {
            bool isAdded = false;

            if (!_employees.Employees.Exists(e => e.ID == employee.ID || (e.FirstName == employee.FirstName && e.LastName == employee.LastName) || e.Email == employee.Email || e.Phone == employee.Phone))
            {
                _employees.Employees.Add(employee);
                isAdded = true;
            }

            return isAdded;
        }

        public bool DeleteEmployee(Guid employeeID)
        {
            if (_employees.Employees.Exists(e => e.ID == employeeID))
            {
                _employees.Employees.Remove(_employees.Employees.Find(e => e.ID == employeeID));
                return true;
            }

            return false;
        }

        public List<Employee> GetAllEmployees()
        {
            if (_employees != null)
            {
                return _employees.Employees;
            }
            return null;
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                int index = _employees.Employees.FindIndex(e => e.ID == employee.ID);
                if(index != -1)
                {
                    _employees.Employees[index] = employee;
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                return false;
            }            
        } 
    }
}
