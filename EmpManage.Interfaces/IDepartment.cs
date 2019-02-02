using EMS.Models;
using System.Collections.Generic;

namespace EMS.Interfaces
{
    public interface IDepartment
    {
        List<Department> GetAllDepartments();
        string GetDepartmentNameByID(int id);
        //void AddDepartment(Department department);
        int GetDepartmentIDByName(string name);
    }
}
