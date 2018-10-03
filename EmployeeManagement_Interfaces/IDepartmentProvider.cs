using EmployeeManagement_Models;
using System.Collections.Generic;

namespace EmployeeManagement_Interfaces
{
    public interface IDepartmentProvider
    {
        void OpenConnection();
        List<Department> GetAllItems();
    }
}
