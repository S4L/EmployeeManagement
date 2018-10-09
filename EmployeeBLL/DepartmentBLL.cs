using EmployeeManagement_Interfaces;
using EmployeeManagement_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementBLL
{
    public class DepartmentBLL
    {
        private IDepartmentProvider _departmentProvider;

        public DepartmentBLL()
        {
            //TODO: Figure out how to resole the Type.GetType returns null issue
            //var providerType = Type.GetType(configString);
            //_employeeProvider = (IEmployeeProvider)Activator.CreateInstance(providerType);
            _departmentProvider = new DepartmentMemoryProvider.DepartmentInMemory();
        }

        public List<DepartmentCommon> GetAllDepartments()
        {
            return _departmentProvider.GetAllDepartments();
        }
    }
}
