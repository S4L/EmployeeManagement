using EMS.Interfaces;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EMS.Logics
{
    public class EmployeeLogic
    {

        public EmployeeLogic ()
        {
            //_employeeData = TypeProvider.GetEmployeeDataProvider();
        }

        static object _lock = new object();

        private IEmployee _employeeData;
        private IEmployee EmployeeData
        {
            get
            {
                if (_employeeData == null)
                {
                    lock (_lock)
                    {
                        if (_employeeData == null)
                        {
                            _employeeData = TypeProvider.GetEmployeeDataProvider();
                            if (_employeeData == null)
                            {
                                // log error...

                                throw new NullReferenceException("Failed to instantiate ...");
                            }
                        }
                    }
                }
                return _employeeData;
            }
        }

        public List<Employee> GetAllEmployees()
        {
            return EmployeeData.GetAllEmployees();
        }

        //public Employee GetEmployeeByID(Guid employeeID)
        //{
        //    return _employeeProvider.GetEmployeeByID(employeeID);
        //}

        public bool AddEmployee(Employee employee)
        {
            return EmployeeData.AddEmployee(employee);
        }

        public bool UpdateEmployee(Guid employeeID, Employee employee)
        {
            return EmployeeData.UpdateEmployee(employeeID, employee);
        }

        public bool DeleteEmployee(Guid employeeID)
        {
            return EmployeeData.DeleteEmployee(employeeID);
        }

        public List<Employee> GetSpecificEmployees(Func<Employee, bool> func)
        {
            throw new NotImplementedException();
        }
    }
}
