using EmployeeManagement_Interfaces;
using EmployeeManagement_Models;
using System;
using System.Collections.Generic;

namespace EmployeeManagement_EmployeeBLL
{
    public class EmployeeBLL
    {
        private IEmployeeProvider _employeeProvider;

        public EmployeeBLL(string configString)
        {
            var providerType = Type.GetType("EmployeeMemoryProvider.MemoryProvider, Employee-MemoryProvider");
            _employeeProvider = (IEmployeeProvider)Activator.CreateInstance(providerType);
        }


        public List<Employee> GetAllEmployess()
        {
           return _employeeProvider.GetAllEmployees();
        }

        public Employee GetEmployeeByID(int targetID)
        {
            return _employeeProvider.GetEmployeeByID(targetID);
        }

        public void CreateEmployee(Employee employee)
        {
            _employeeProvider.CreateEmployee(employee);
        }

        public void UpdateEmployee(int targetID, Employee employee)
        {
            _employeeProvider.UpdateEmployee(targetID, employee);
        }

        public void DeleteEmployee(int targetID)
        {
            _employeeProvider.DeleteEmployee(targetID);
        }

       

    }
}
