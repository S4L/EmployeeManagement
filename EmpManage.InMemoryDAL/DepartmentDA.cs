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
        private InMemoryData inMemoryData = new InMemoryData();

        public List<Department> GetAllDepartments()
        {
            return inMemoryData.departments;
        }

        public string GetDepartmentNameByDepartmentID(int id)
        {
            try
            {
                return inMemoryData.departments.FirstOrDefault(department => department.ID == id).Name;
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
                return inMemoryData.departments.FirstOrDefault(d => d.Name == name).ID;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return 0;
            }
        }
    }
}
