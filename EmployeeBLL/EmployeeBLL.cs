using EmployeeManagement_Interfaces;
using EmployeeManagement_Models;
using System;
using System.Collections.Generic;

namespace EmployeeManagementBLL
{
    public class EmployeeBLL
    {
        private IEmployeeProvider _employeeProvider;

        public EmployeeBLL()
        {
            //TODO: Figure out how to resole the Type.GetType returns null issue
            //var providerType = Type.GetType(configString);
            //_employeeProvider = (IEmployeeProvider)Activator.CreateInstance(providerType);
            _employeeProvider = new EmployeeMemoryProvider.EmployeeInMemory();
        }
       

        public List<EmployeeCommon> GetAllEmployess()
        {
           return _employeeProvider.GetAllEmployees();
        }

        public EmployeeCommon GetEmployeeByID(int targetID)
        {
            return _employeeProvider.GetEmployeeByID(targetID);
        }

        public void CreateEmployee(EmployeeCommon employee)
        {
            _employeeProvider.CreateEmployee(employee);
        }

        public void UpdateEmployee(int targetID, EmployeeCommon employee)
        {
            _employeeProvider.UpdateEmployee(targetID, employee);
        }

        public void DeleteEmployee(int targetID)
        {
            _employeeProvider.DeleteEmployee(targetID);
        }

       

    }
}
