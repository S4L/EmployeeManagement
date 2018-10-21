using EmpManage.Interfaces;
using EmpManage.Models;
using System;
using System.Collections.Generic;

namespace EmpManage.BLL
{
    public class EmployeeBL : IEmployeeDataAccess 
    {
        private IEmployeeDataAccess _employeeProvider;

        public EmployeeBL ()
        {
            //TODO: Figure out how to resolve the Type.GetType returns null issue
            //var providerType = Type.GetType(configString);
            //_employeeProvider = (IEmployeeProvider)Activator.CreateInstance(providerType);
            _employeeProvider = new EmpManage.InMemoryDAL.EmployeeDA();
        }
       

        public List<Employee> GetAllEmployees()
        {
           return _employeeProvider.GetAllEmployees();
        }

        public Employee GetEmployeeByID(Guid employeeID)
        {
            return _employeeProvider.GetEmployeeByID(employeeID);
        }

        public bool AddEmployee(Employee employee)
        {
            return _employeeProvider.AddEmployee(employee);
        }

        public bool UpdateEmployee(Guid employeeID, Employee employee)
        {
            return _employeeProvider.UpdateEmployee(employeeID, employee);
        }

        public bool DeleteEmployee(Guid employeeID)
        {
             return _employeeProvider.DeleteEmployee(employeeID);
        }

        public List<Employee> GetEmployee(Func<Employee, bool> func)
        {
            throw new NotImplementedException();
        }
    }
}
