using EmployeeManagement_Models;
using System.Collections.Generic;

namespace EmployeeManagement_Interfaces
{
    public interface IEmployeeProvider
    {
        void OpenConnection();
        List<Employee> GetAllItems();
        Employee GetAllItemById(int targetID);
        void AddItem(Employee employee);
        void UpdateItem(int targetID, Employee employee);
        void DeleteItem(int targetID);
    }
}
