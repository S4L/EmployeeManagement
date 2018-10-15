using EmMana.DALInterfaces;
using EmMana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmMana.DepartmentBLL
{
    public class DepartmentLogic: IDepartmentDataAccess
    {
        private IDepartmentDataAccess _departmentProvider;

        public DepartmentLogic()
        {
            //TODO: Figure out how to resole the Type.GetType returns null issue
            //var providerType = Type.GetType(configString);
            //_employeeProvider = (IEmployeeProvider)Activator.CreateInstance(providerType);
            _departmentProvider = new EmMana.DepartmentMemoryProvider.DepartmentInMemory();
        }

        public void AddDepartment(DepartmentCommon department)
        {
            _departmentProvider.AddDepartment(department);
        }

        public List<DepartmentCommon> GetAllDepartments()
        {
            return _departmentProvider.GetAllDepartments();
        }

        public DepartmentCommon GetDepartmentByDepartmentID(int id)
        {
            return _departmentProvider.GetDepartmentByDepartmentID(id);
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
