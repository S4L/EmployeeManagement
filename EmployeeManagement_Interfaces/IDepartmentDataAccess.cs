using EmMana.Models;
using System.Collections.Generic;

namespace EmMana.DALInterfaces
{
    public interface IDepartmentDataAccess
    {
        void OpenConnection();
        List<DepartmentCommon> GetAllDepartments();
        DepartmentCommon GetDepartmentByDepartmentID(int id);
        void AddDepartment(DepartmentCommon department);
        int GetDepartmentIDByName(string name);
    }
}
