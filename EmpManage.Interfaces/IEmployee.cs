using System;
using System.Collections.Generic;
using EMS.Models;

namespace EMS.Interfaces
{
    public interface IEmployee
    {
        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns>
        ///   1. List of employee, may be empty.
        ///   2. null - DB error (DB inaccessible, etc.)
        /// </returns>
        List<Employee> GetAllEmployees();

        //List<Employee> GetSpecificEmployees(Func<Employee,bool> func); //TODO: passing lambda parameter
        bool AddEmployee(Employee employee); 
        bool UpdateEmployee(Guid employeeID, Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(Guid employeeID);
    }
}
