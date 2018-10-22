using EmpManage.Interfaces;
using EmpManage.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EmpManage.InMemoryDAL
{
    public class DepartmentDA : IDepartmentDataAccess
    {
        List<Department> departments = new List<Department>
        {
            new Department{ID = 1, Name ="Sales"},
            new Department{ID = 2, Name ="Customer Support"},
            new Department{ID = 3, Name ="IT"},
            new Department{ID = 4, Name ="Production & Quality Assurance"},
            new Department{ID = 5, Name ="Finance"}
        };

        public List<Department> GetAllDepartments()
        {
            return departments;
        }

        public string GetDepartmentNameByDepartmentID(int id)
        {
            try
            {
                return departments.FirstOrDefault(department => department.ID == id).Name;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return "";
            }
            
        }

        public int GetDepartmentIDByName(string name)
        {
            try
            {
                return departments.FirstOrDefault(d => d.Name == name).ID;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return 0;
            }
        }
    }
}
