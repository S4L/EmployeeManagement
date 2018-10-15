using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EmMana.DALInterfaces;
using EmMana.Models;

namespace EmMana.DepartmentMemoryProvider
{
    public class DepartmentInMemory : IDepartmentDataAccess
    {
        static List<DepartmentCommon> departments = new List<DepartmentCommon>
        {
            new DepartmentCommon{ID = 1, Name ="Sales"},
                new DepartmentCommon{ID = 2, Name ="Customer Support"},
                new DepartmentCommon{ID = 3, Name ="IT"},
                new DepartmentCommon{ID = 4, Name ="Production & Quality Assurance"},
                new DepartmentCommon{ID = 5, Name ="Finance"}
        };

        public void AddDepartment(DepartmentCommon department)
        {
            departments.Add(department);
        }

        public List<DepartmentCommon> GetAllDepartments()
        {
            return departments;
        }

        public DepartmentCommon GetDepartmentByDepartmentID(int id)
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
