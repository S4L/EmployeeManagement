using EMS.Interfaces;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EMS.Logics
{
    public class EmployeeLogic
    {
        private IEmployee _employeeData;
        private IEmployee EmployeeData
        {
            get
            {
                if (_employeeData == null)
                {
                    _employeeData = TypeProvider.EmployeeDataProvider;
                    if (_employeeData == null)
                    {
                        // log error...

                        throw new NullReferenceException("Failed to instantiate ...");
                    }
                }
                return _employeeData;
            }
        }

        public List<Employee> GetAllEmployees()
        {
            return EmployeeData.GetAllEmployees();
        }

        public bool AddEmployee(Employee employee)
        {
            return EmployeeData.AddEmployee(employee);
        }

        //public bool UpdateEmployee(Guid employeeID, Employee employee)
        //{
        //    return EmployeeData.UpdateEmployee(employeeID, employee);
        //}

        public bool UpdateEmployee(Employee employee)
        {
            return EmployeeData.UpdateEmployee(employee);
        }

        public bool DeleteEmployee(Guid employeeID)
        {
            return EmployeeData.DeleteEmployee(employeeID);
        }
    }
}
