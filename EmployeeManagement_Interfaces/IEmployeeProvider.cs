using EmployeeManagement_Models;
using System.Collections.Generic;

namespace EmployeeManagement_Interfaces
{
    public interface IEmployeeProvider
    {
        void OpenConnection();
        List<EmployeeCommon> GetAllEmployees();
        EmployeeCommon GetEmployeeByID(int targetID);
        void CreateEmployee(EmployeeCommon employee);
        void UpdateEmployee(int targetID, EmployeeCommon employee);
        void DeleteEmployee(int targetID);
    }
}
