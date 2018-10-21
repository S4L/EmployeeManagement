using EmpManage.Interfaces;
using EmpManage.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EmpManage.InMemoryDAL
{
    public class EmployeeDA : IEmployeeDataAccess
    {
        private List<Employee> employees = new List<Employee>
        {
            new Employee{ID= Guid.NewGuid(), FirstName="Jarvis",LastName="Vision",Email="jarvis@gmail.com",Phone="234-432-5645",DepartmentId=2,Gender="Male"},
            new Employee{ID = Guid.NewGuid(), FirstName="Jean",LastName="Grey",Email="jGrey@yahoo.com",Phone="458-789-2365",DepartmentId=4,Gender="Female"},
            new Employee{ID = Guid.NewGuid(), FirstName="Jon",LastName="Snow",Email="jonsnow@gmail.com",Phone="365-458-2563",DepartmentId=5,Gender="Male"},
            new Employee{ID = Guid.NewGuid(), FirstName="Kha",LastName="Tran",Email="khatran@hotmail.com",Phone="714-285-7695",DepartmentId=1,Gender="Male"},
            new Employee{ID = Guid.NewGuid(), FirstName="Tony",LastName="Stark",Email="ironman@gmail.com",Phone="125-745-2365",DepartmentId=3,Gender="Male"},
            new Employee{ID = Guid.NewGuid(), FirstName="Christine",LastName="Lopez",Email="christlopez@gmail.com",Phone="452-125-6589",DepartmentId=3,Gender="Female"}
        };

        public bool AddEmployee(Employee employee)
        {
            employees.Add(employee);
            return employees.Contains(employee);
        }

        public bool DeleteEmployee(Guid employeeID)
        {
            bool isDeleted = false;
            var employee = new Employee();
            employees.Remove(employees.Find(e => e.ID == employeeID));
            if (!employees.Contains(employee))
            {
                isDeleted = true;
            }
            return isDeleted;
        }

        public Employee GetEmployeeByID(Guid employeeID)
        {
            try
            {
                return employees.Find(e => e.ID == employeeID);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new IndexOutOfRangeException();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public bool UpdateEmployee(Guid employeeID, Employee employee)
        {
            try
            {
                employees[employees.FindIndex(e => e.ID == employeeID)] = employee;
                return employees.Contains(employee);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        public List<Employee> GetEmployee(Func<Employee, bool> func)
        {
            return null;
        }

        public int GetNextAvailableEmployeeID()
        {
            return employees.Count();
        }
    }
}
