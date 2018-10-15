using System.Collections.Generic;
using EmMana.DALInterfaces;
using EmMana.Models;

namespace EmMana.DepartmentMemoryProvider
{
    public class DepartmentInMemory : IDepartmentDataAccess
    {
        public List<DepartmentCommon> GetAllDepartments()
        {
            return new List<DepartmentCommon>
            {
                new DepartmentCommon{ID = 1, Name ="Sales"},
                new DepartmentCommon{ID = 2, Name ="Customer Support"},
                new DepartmentCommon{ID = 3, Name ="IT"},
                new DepartmentCommon{ID = 4, Name ="Production & Quality Assurance"},
                new DepartmentCommon{ID = 5, Name ="Finance"}
            };
        }

        public void OpenConnection()
        {
            throw new System.NotImplementedException();
        }
    }
}
