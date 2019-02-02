using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Interfaces
{
    public static class TypeProvider
    {
        private static string EmployeeDataType => ConfigurationManager.AppSettings["EmployeeDAProvider"];
        private static string DepartmentDataType => ConfigurationManager.AppSettings["DepartmentDAProvider"];

        #region GetTypeFromConfigString
        private static Type _employeeDataProvider = Type.GetType(EmployeeDataType);
        private static Type _departmentDataProvider = Type.GetType(DepartmentDataType);
        #endregion

        public static IEmployee EmployeeDataProvider => Activator.CreateInstance(_employeeDataProvider) as IEmployee;
        public static IDepartment DepartmentDataProvider => Activator.CreateInstance(_departmentDataProvider) as IDepartment;
    }
}
