using System;
using System.Collections.Generic;
using EmpManage.Models;

namespace EmpManage.Interfaces
{
    public interface IEmployeeDataAccess
    {
        List<Employee> GetAllEmployees();
        //List<Employee> GetSpecificEmployees(Func<Employee,bool> func); //TODO: passing lambda parameter
        bool AddEmployee(Employee employee); 
        bool UpdateEmployee(Guid employeeID, Employee employee);
        bool DeleteEmployee(Guid employeeID);
    }
}
