using EmMana.Models;
using System.Collections.Generic;

namespace EmMana.DALInterfaces
{
    public interface IEmployeeDataAccess
    {
        void OpenConnection();
        List<EmployeeCommon> GetAllEmployees();
        EmployeeCommon GetEmployeeByID(int targetID);
        EmployeeCommon GetEmployeeByFirstName(string firstname);
        void CreateEmployee(EmployeeCommon employee);
        void UpdateEmployee(int targetID, EmployeeCommon employee);
        void DeleteEmployee(int targetID);
        bool IsEmployeeExisted(int targetID);
        int GetEmployeeCountTotal();
        
    }
}
