using EmpManage.Interfaces;
using EmpManage.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EmpManage.BLL
{
    public class EmployeeBL : IEmployeeDataAccess 
    {
        private IEmployeeDataAccess _employeeProvider;

        public EmployeeBL (string configString)
        {
            GetEmployeeDataProvider(configString);
        }
       
        private void GetEmployeeDataProvider(string configStr)
        {
            try
            {
                var providerType = Type.GetType(configStr);
                _employeeProvider = (IEmployeeDataAccess)Activator.CreateInstance(providerType);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
            
        }

        public List<Employee> GetAllEmployees()
        {
           return _employeeProvider.GetAllEmployees();
        }

        //public Employee GetEmployeeByID(Guid employeeID)
        //{
        //    return _employeeProvider.GetEmployeeByID(employeeID);
        //}

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

        public List<Employee> GetSpecificEmployees(Func<Employee, bool> func)
        {
            throw new NotImplementedException();
        }
    }
}
