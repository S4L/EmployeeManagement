using EMS.Models;
using System;
using System.Collections.Generic;

namespace EMS.Interfaces
{
    public interface IDepartment
    {
        List<Department> GetAllDepartments();
        string GetDepartmentNameByID(Guid id);
        //void AddDepartment(Department department);
        Guid GetDepartmentIDByName(string name);
    }
}
