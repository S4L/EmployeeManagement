using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmMana.DALInterfaces;
using EmMana.Models;

namespace EmMana.EmployeeSQLServer
{
    public class EmployeeSQLServer : IEmployeeDataAccess
    {
        public EmployeeSQLServer()
        {

        }

        public void CreateEmployee(EmployeeCommon employee)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int targetID)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeCommon> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public EmployeeCommon GetEmployeeByFirstName(string firstname)
        {
            throw new NotImplementedException();
        }

        public EmployeeCommon GetEmployeeByID(int targetID)
        {
            throw new NotImplementedException();
        }

        public int GetEmployeeCountTotal()
        {
            throw new NotImplementedException();
        }

        public bool IsEmployeeExisted(int targetID)
        {
            throw new NotImplementedException();
        }

        public void OpenConnection()
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(int targetID, EmployeeCommon employee)
        {
            throw new NotImplementedException();
        }
    }
}
