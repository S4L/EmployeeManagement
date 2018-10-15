using EmMana.DALInterfaces;
using EmMana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmMana.EmployeeMemoryProvider
{
    public class EmployeeInMemory: IEmployeeDataAccess
    {
        private List<EmployeeCommon> employees = new List<EmployeeCommon>
        {
            new EmployeeCommon{Id=1, FirstName="Jarvis",LastName="Vision",Email="jarvis@gmail.com",Phone="234-432-5645",DepartmentId=2,GenderId=1},
            new EmployeeCommon{Id=2, FirstName="Jean",LastName="Grey",Email="jGrey@yahoo.com",Phone="458-789-2365",DepartmentId=4,GenderId=1},
            new EmployeeCommon{Id=3, FirstName="Jon",LastName="Snow",Email="jonsnow@gmail.com",Phone="365-458-2563",DepartmentId=5,GenderId=2},
            new EmployeeCommon{Id=4, FirstName="Kha",LastName="Tran",Email="khatran@hotmail.com",Phone="714-285-7695",DepartmentId=1,GenderId=1},
            new EmployeeCommon{Id=5, FirstName="Tony",LastName="Stark",Email="ironman@gmail.com",Phone="125-745-2365",DepartmentId=3,GenderId=1},
            new EmployeeCommon{Id=6, FirstName="Christine",LastName="Lopez",Email="christlopez@gmail.com",Phone="452-125-6589",DepartmentId=3,GenderId=2}
        };

        public void CreateEmployee(EmployeeCommon employee)
        {
            employees.Add(employee);
        }

        public void DeleteEmployee(int targetID)
        {
            employees.RemoveAt(targetID);
        }

        public EmployeeCommon GetEmployeeByID(int targetID)
        {
            try
            {
                return employees.Find(x => x.Id == targetID);
            }
            catch
            {
                throw new IndexOutOfRangeException();
            }
        }

        public List<EmployeeCommon> GetAllEmployees()
        {
            return employees;
        }

        public void OpenConnection()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEmployee(int targetID, EmployeeCommon employee)
        {
            try
            {
                employees[targetID] = employee;
            }
            catch
            {
                throw;
            }
        }
    }
}
