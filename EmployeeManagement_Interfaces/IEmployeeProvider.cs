using EmployeeManagement_Models;
using System.Collections.Generic;

namespace EmployeeManagement_Interfaces
{
    public interface IEmployeeProvider
    {
        void OpenConnection();
        List<Employee> GetAllEmployees();
        Employee GetEmployeeByID(int targetID);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(int targetID, Employee employee);
        void DeleteEmployee(int targetID);
    }
}
