using EmpManage.Interfaces;
using EmpManage.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EmpManage.BLL
{
    public class DepartmentBL : IDepartmentDataAccess
    {
        private IDepartmentDataAccess _departmentProvider;

        public DepartmentBL (string configString)
        {
            GetDepartmentDataProvider(configString);
        }

        private void GetDepartmentDataProvider(string configStr)
        {
            try
            {
                var providerType = Type.GetType(configStr);
                _departmentProvider = (IDepartmentDataAccess)Activator.CreateInstance(providerType);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }

        }

        public List<Department> GetAllDepartments()
        {
            return _departmentProvider.GetAllDepartments();
        }

        public string GetDepartmentNameByDepartmentID(int id)
        {
            return _departmentProvider.GetDepartmentNameByDepartmentID(id);
        }

        public int GetDepartmentIDByName(string name)
        {
            return _departmentProvider.GetDepartmentIDByName(name);
        }

        public void OpenConnection()
        {
            throw new NotImplementedException();
        }
    }
}
