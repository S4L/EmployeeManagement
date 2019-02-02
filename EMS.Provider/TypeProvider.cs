using EMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Provider
{
    public static class TypeProvider
    {
        private static string EmployeeDataType => ConfigurationManager.AppSettings["EmployeeSQLServer"];
        private static string DepartmentDataType => ConfigurationManager.AppSettings["DepartmentSQLServer"];
        private static Type _employeeDataProvider = Type.GetType(EmployeeDataType);
        private static Type _departmentDataProvider = Type.GetType(DepartmentDataType);

        public static IEmployeeDA EmployeeDataProvider => Activator.CreateInstance(_employeeDataProvider) as IEmployeeDA;
        public static IDepartmentDA DepartmentDataProvider => Activator.CreateInstance(_departmentDataProvider) as IDepartmentDA;
    }
}
