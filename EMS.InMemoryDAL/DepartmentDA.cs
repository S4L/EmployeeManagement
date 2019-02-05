using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Interfaces;
using EMS.Models;

namespace EMS.InMemoryDAL
{
    public class DepartmentDA : IDepartment
    {
        private InMemoryData _departments;

        public DepartmentDA()
        {
            _departments = new InMemoryData();
        }

        public List<Department> GetAllDepartments()
        {
            return _departments.Departments;
        }

        public string GetDepartmentNameByID(Guid departmentID)
        {
            try
            {
                return _departments.Departments.FirstOrDefault(department => department.ID == departmentID).Name;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return "";
            }

        }

        public Guid GetDepartmentIDByName(string name)
        {
            try
            {
                return _departments.Departments.FirstOrDefault(d => d.Name == name).ID;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return Guid.Empty;
            }
        }
    }
}
