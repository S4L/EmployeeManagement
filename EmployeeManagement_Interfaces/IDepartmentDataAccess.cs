using EmMana.Models;
using System.Collections.Generic;

namespace EmMana.DALInterfaces
{
    public interface IDepartmentDataAccess
    {
        void OpenConnection();
        List<DepartmentCommon> GetAllDepartments();
    }
}
