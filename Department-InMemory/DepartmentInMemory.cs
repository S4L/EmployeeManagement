using System.Collections.Generic;
using EmployeeManagement_Interfaces;
using EmployeeManagement_Models;

namespace Department_InMemory
{
    public class DepartmentInMemory : IDepartmentProvider
    {
        public List<Department> GetAllItems()
        {
            return new List<Department>
            {
                new Department{ID = 1, Name ="Sales"},
                new Department{ID = 2, Name ="Customer Support"},
                new Department{ID = 3, Name ="IT"},
                new Department{ID = 4, Name ="Production & Quality Assurance"},
                new Department{ID = 5, Name ="Finance"}
            };
        }

        public void OpenConnection()
        {
            throw new System.NotImplementedException();
        }
    }
}
