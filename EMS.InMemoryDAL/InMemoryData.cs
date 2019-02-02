using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.InMemoryDAL
{
    public class InMemoryData
    {
        public List<Employee> Employees => new List<Employee>()
        {
            new Employee{ID= new Guid("F4B7685B-6BC6-49EA-ADFF-BBE8A32CD133"), FirstName="Jarvis",LastName="Vision",Email="jarvis@gmail.com",Phone="234-432-5645",DepartmentId=2,Gender="Male"},
            new Employee{ID = new Guid("2461B020-F141-4B3F-8FB2-F480B52D852A"), FirstName="Jean",LastName="Grey",Email="jGrey@yahoo.com",Phone="458-789-2365",DepartmentId=4,Gender="Female"},
            new Employee{ID = new Guid("EB453F17-7BD6-4B8C-A06D-F2976FBB960C"), FirstName="Jon",LastName="Snow",Email="jonsnow@gmail.com",Phone="365-458-2563",DepartmentId=5,Gender="Male"},
            new Employee{ID = new Guid("965CD684-8078-44A4-8186-E2E5F4B31A6E"), FirstName="Kha",LastName="Tran",Email="khatran@hotmail.com",Phone="714-285-7695",DepartmentId=1,Gender="Male"},
            new Employee{ID = new Guid("F50C56E8-0EBC-4103-A9CA-8E9E88C998CB"), FirstName="Tony",LastName="Stark",Email="ironman@gmail.com",Phone="125-745-2365",DepartmentId=3,Gender="Male"},
            new Employee{ID = new Guid("F71E2833-4531-461C-89D8-9576D2811D72"), FirstName="Christine",LastName="Lopez",Email="christlopez@gmail.com",Phone="452-125-6589",DepartmentId=3,Gender="Female"}
        };

        public List<Department> Departments => new List<Department>() {
             new Department{ID = 1, Name ="Sales"},
             new Department{ID = 2, Name ="Customer Support"},
             new Department{ID = 3, Name ="IT"},
             new Department{ID = 4, Name ="Production & Quality Assurance"},
             new Department{ID = 5, Name ="Finance"}
        };
    }
}
