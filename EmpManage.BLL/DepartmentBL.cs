using EmpManage.Interfaces;
using EmpManage.Models;
using System;
using System.Collections.Generic;

namespace EmpManage.BLL
{
    public class DepartmentBL : IDepartmentDataAccess
    {
        private IDepartmentDataAccess _departmentProvider;

        public DepartmentBL ()
        {
            //TODO: Figure out how to resole the Type.GetType returns null issue
            //var providerType = Type.GetType(configString);
            //_employeeProvider = (IEmployeeProvider)Activator.CreateInstance(providerType);
            _departmentProvider = new EmpManage.InMemoryDAL.DepartmentDA();
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
