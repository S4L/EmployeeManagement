using EmMana.DALInterfaces;
using EmMana.Models;
using System;
using System.Collections.Generic;

namespace EmMana.EmployeeBLL
{
    public class EmployeeLogic: IEmployeeDataAccess //TODO: 
    {
        private IEmployeeDataAccess _employeeProvider;

        public EmployeeLogic()
        {
            //TODO: Figure out how to resole the Type.GetType returns null issue
            //var providerType = Type.GetType(configString);
            //_employeeProvider = (IEmployeeProvider)Activator.CreateInstance(providerType);
            _employeeProvider = new EmployeeMemoryProvider.EmployeeInMemory();
        }
       

        public List<EmployeeCommon> GetAllEmployees()
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

        public void OpenConnection()
        {
            throw new NotImplementedException();
        }

        public EmployeeCommon GetEmployeeByFirstName(string firstname)
        {
            return _employeeProvider.GetEmployeeByFirstName(firstname);
        }

        public bool IsEmployeeExisted(int targetID)
        {
            return _employeeProvider.IsEmployeeExisted(targetID);
        }

        public int GetEmployeeCountTotal()
        {
            return _employeeProvider.GetEmployeeCountTotal();
        }
    }
}
