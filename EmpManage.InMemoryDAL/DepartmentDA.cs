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
        static List<Department> departments = new List<Department>
        {
            new Department{ID = 1, Name ="Sales"},
                new Department{ID = 2, Name ="Customer Support"},
                new Department{ID = 3, Name ="IT"},
                new Department{ID = 4, Name ="Production & Quality Assurance"},
                new Department{ID = 5, Name ="Finance"}
        };

        public void AddDepartment(Department department)
        {
            departments.Add(department);
        }

        public List<Department> GetAllDepartments()
        {
            return departments;
        }

        public Department GetDepartmentByDepartmentID(int id)
        {
            try
            {
                return departments.FirstOrDefault(department => department.ID == id);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
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

        public void OpenConnection()
        {
            throw new System.NotImplementedException();
        }
    }
}
