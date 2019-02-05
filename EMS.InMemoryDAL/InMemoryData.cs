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
            new Employee{ID= new Guid("F4B7685B-6BC6-49EA-ADFF-BBE8A32CD133"), FirstName="Jarvis",LastName="Vision",Email="jarvis@gmail.com",Phone="234-432-5645",DepartmentId=new Guid("5C87B6AD-4A6D-48E5-80AA-561BBE861774"),Gender="Male"},
            new Employee{ID = new Guid("2461B020-F141-4B3F-8FB2-F480B52D852A"), FirstName="Jean",LastName="Grey",Email="jGrey@yahoo.com",Phone="458-789-2365",DepartmentId= new Guid("79F1CDAF-CAD9-49C4-BC04-D991480F7CF2"),Gender="Female"},
            new Employee{ID = new Guid("EB453F17-7BD6-4B8C-A06D-F2976FBB960C"), FirstName="Jon",LastName="Snow",Email="jonsnow@gmail.com",Phone="365-458-2563",DepartmentId=new Guid("04CEEA7B-A771-4584-B9A7-BB465672E629"),Gender="Male"},
            new Employee{ID = new Guid("965CD684-8078-44A4-8186-E2E5F4B31A6E"), FirstName="Kha",LastName="Tran",Email="khatran@hotmail.com",Phone="714-285-7695",DepartmentId=new Guid("C094B719-B0B8-4501-BD61-BC6EAC2442B4"),Gender="Male"},
            new Employee{ID = new Guid("F50C56E8-0EBC-4103-A9CA-8E9E88C998CB"), FirstName="Tony",LastName="Stark",Email="ironman@gmail.com",Phone="125-745-2365",DepartmentId=new Guid("EB0B3BA2-C0C8-4EA4-9287-B9DE848A668D"),Gender="Male"},
            new Employee{ID = new Guid("F71E2833-4531-461C-89D8-9576D2811D72"), FirstName="Christine",LastName="Lopez",Email="christlopez@gmail.com",Phone="452-125-6589",DepartmentId=new Guid("EB0B3BA2-C0C8-4EA4-9287-B9DE848A668D"),Gender="Female"}
        };

        public List<Department> Departments => new List<Department>() {
             new Department{ID = new Guid("C094B719-B0B8-4501-BD61-BC6EAC2442B4"), Name ="Sales"},
            new Department{ID = new Guid("5C87B6AD-4A6D-48E5-80AA-561BBE861774"), Name ="Customer Support"},
            new Department{ID = new Guid("EB0B3BA2-C0C8-4EA4-9287-B9DE848A668D"), Name ="IT"},
            new Department{ID = new Guid("79F1CDAF-CAD9-49C4-BC04-D991480F7CF2"), Name ="Quality Assurance"},
            new Department{ID = new Guid("04CEEA7B-A771-4584-B9A7-BB465672E629"), Name ="Finance"}
        };
    }
}
