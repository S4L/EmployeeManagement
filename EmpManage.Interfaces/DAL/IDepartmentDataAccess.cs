using EmpManage.Models;
using System.Collections.Generic;

namespace EmpManage.Interfaces
{
    public interface IDepartmentDataAccess
    {
        List<Department> GetAllDepartments();
        string GetDepartmentNameByDepartmentID(int id);
        //void AddDepartment(Department department);
        int GetDepartmentIDByName(string name);
    }
}
