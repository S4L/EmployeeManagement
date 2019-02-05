using EMS.Interfaces;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EMS.Logics
{
    public class DepartmentLogic
    {
        private IDepartment _departmentData;

        public DepartmentLogic ()
        {
            _departmentData = TypeProvider.DepartmentDataProvider;
        }

        public List<Department> GetAllDepartments()
        {
            return _departmentData.GetAllDepartments();
        }

        public string GetDepartmentNameByID(Guid id)
        {
            return _departmentData.GetDepartmentNameByID(id);
        }

        public Guid GetDepartmentIDByName(string name)
        {
            return _departmentData.GetDepartmentIDByName(name);
        }
    }
}
