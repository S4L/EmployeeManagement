using EMS.Interfaces;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EMS.Logics
{
    public class EmployeeLogic
    {
        private IEmployee _employeeData;

        public EmployeeLogic ()
        {
            _employeeData = TypeProvider.EmployeeDataProvider;
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeData.GetAllEmployees();
        }

        //public Employee GetEmployeeByID(Guid employeeID)
        //{
        //    return _employeeProvider.GetEmployeeByID(employeeID);
        //}

        public bool AddEmployee(Employee employee)
        {
            return _employeeData.AddEmployee(employee);
        }

        public bool UpdateEmployee(Guid employeeID, Employee employee)
        {
            return _employeeData.UpdateEmployee(employeeID, employee);
        }

        public bool DeleteEmployee(Guid employeeID)
        {
            return _employeeData.DeleteEmployee(employeeID);
        }

        public List<Employee> GetSpecificEmployees(Func<Employee, bool> func)
        {
            throw new NotImplementedException();
        }
    }
}
