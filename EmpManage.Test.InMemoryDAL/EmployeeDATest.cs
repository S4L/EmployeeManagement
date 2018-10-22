using System;
using System.Collections.Generic;
using System.Diagnostics;
using EmpManage.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmpManage.Test.InMemoryDAL
{
    [TestClass]
    public class EmployeeDATest
    {
        private List<Employee> employees = new List<Employee>
        {
            new Employee{ID= new Guid("F4B7685B-6BC6-49EA-ADFF-BBE8A32CD133"), FirstName="Jarvis",LastName="Vision",Email="jarvis@gmail.com",Phone="234-432-5645",DepartmentId=2,Gender="Male"},
            new Employee{ID = new Guid("2461B020-F141-4B3F-8FB2-F480B52D852A"), FirstName="Jean",LastName="Grey",Email="jGrey@yahoo.com",Phone="458-789-2365",DepartmentId=4,Gender="Female"},
            new Employee{ID = new Guid("EB453F17-7BD6-4B8C-A06D-F2976FBB960C"), FirstName="Jon",LastName="Snow",Email="jonsnow@gmail.com",Phone="365-458-2563",DepartmentId=5,Gender="Male"},
            new Employee{ID = new Guid("965CD684-8078-44A4-8186-E2E5F4B31A6E"), FirstName="Kha",LastName="Tran",Email="khatran@hotmail.com",Phone="714-285-7695",DepartmentId=1,Gender="Male"},
            new Employee{ID = new Guid("F50C56E8-0EBC-4103-A9CA-8E9E88C998CB"), FirstName="Tony",LastName="Stark",Email="ironman@gmail.com",Phone="125-745-2365",DepartmentId=3,Gender="Male"},
            new Employee{ID = new Guid("F71E2833-4531-461C-89D8-9576D2811D72"), FirstName="Christine",LastName="Lopez",Email="christlopez@gmail.com",Phone="452-125-6589",DepartmentId=3,Gender="Female"}
        };

        [TestMethod]
        [DataRow("{854BFB46-A862-49B4-8AA0-896D7E05232F}", "Lion", "King", "lame@gmail.com", "456-432-5645")]
        public void AddEmployee_True_ReturnTrueWhenEmployeeIsAdded(string guidStr, string firstName, string lastName, string email, string phone)
        {
            var employee = new Employee
            {
                ID = new Guid(guidStr),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                DepartmentId = 2,
                Gender = "Male"
            };

            bool isAdded = false;

            if (!employees.Exists(e => e.ID == employee.ID || (e.FirstName == employee.FirstName && e.LastName == employee.LastName) || e.Email == employee.Email || e.Phone == employee.Phone))
            {
                employees.Add(employee);
                isAdded = true;
            }

            Assert.AreEqual(true, isAdded);
        }

        [TestMethod]
        [DataRow("F4B7685B-6BC6-49EA-ADFF-BBE8A32CD133", "Jarvis", "Vision", "jarvis@gmail.com", "234-432-5645")] //Same All with existed employee
        [DataRow("34637D83-F45E-4742-B65C-0E95B9F4827E", "Jarvis", "Vision", "lame@gmail.com", "456-246-5645")] // Same first & last name with existed employee 
        [DataRow("854BFB46-A862-49B4-8AA0-896D7E05232F", "Lion", "King", "jarvis@gmail.com", "456-246-5645")] // Same email with existed employee 
        [DataRow("8C9B8A0B-28CC-422C-AA40-35602DEE9F9A", "Dell", "Roney", "dell@gmail.com", "234-432-5645")] // Same phone number with existed employee
        [DataRow("F4B7685B-6BC6-49EA-ADFF-BBE8A32CD133", "Jarvis", "Vision", "lame@gmail.com", "456-432-5645")] // Same ID, firstname, lastname
        [DataRow("8C9B8A0B-28CC-422C-AA40-35602DEE9F9A", "Rock", "Johnson", "jarvis@gmail.com", "234-432-5645")] // Same email, phone
        public void AddEmployee_False_EmployeeAlreadyExist(string guidStr, string firstName, string lastName, string email, string phone)
        {
            var employee = new Employee
            {
                ID = new Guid(guidStr),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                DepartmentId = 2,
                Gender = "Male"
            };

            bool isAdded = false;

            if (!employees.Exists(e => e.ID == employee.ID || (e.FirstName == employee.FirstName && e.LastName == employee.LastName) || e.Email == employee.Email || e.Phone == employee.Phone))
            {
                employees.Add(employee);
                isAdded = true;
            }

            Assert.AreEqual(false, isAdded);
        }

        [TestMethod]
        [DataRow("F4B7685B-6BC6-49EA-ADFF-BBE8A32CD133")]
        [DataRow("2461B020-F141-4B3F-8FB2-F480B52D852A")]
        [DataRow("F50C56E8-0EBC-4103-A9CA-8E9E88C998CB")]
        public void DeleteEmployee_True_TrueWhenEmployeeIsDeleted(string guidStr)
        {
            bool isDeleted = false;

            var employeeID = new Guid(guidStr);

            if (employees.Exists(e => e.ID == employeeID))
            {
                employees.Remove(employees.Find(e => e.ID == employeeID));
                isDeleted = true;
            }

            Assert.AreEqual(true, isDeleted);
        }

        [TestMethod]
        [DataRow("8C9B8A0B-28CC-422C-AA40-35602DEE9F9A")]
        [DataRow("{496B0AC8-8337-4548-AC14-8A47112A78B8}")]
        [DataRow("{B896A6A1-E5A8-43F5-BBFD-E1554F3816FA}")]
        public void DeleteEmployee_False_EmployeeNotExistedToBeDeleted(string guidStr)
        {
            bool isDeleted = false;

            var employeeID = new Guid(guidStr);

            if (employees.Exists(e => e.ID == employeeID))
            {
                employees.Remove(employees.Find(e => e.ID == employeeID));
                isDeleted = true;
            }

            Assert.AreEqual(false, isDeleted);
        }

        [TestMethod]
        [DataRow("F4B7685B-6BC6-49EA-ADFF-BBE8A32CD133", "Draco", "Malfoy", "draco@gmail.com", "983-239-2398", 2, "Male")]
        public void UpdateEmployee_True_EmployeeIsUpdated(string guidStr, string firstName, string lastName, string email, string phone, int departmentID, string gender)
        {
            bool isUpdated = false;
            var employeeID = new Guid(guidStr);

            var updatedEmployee = new Employee
            {
                ID = new Guid(guidStr),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                DepartmentId = departmentID,
                Gender = gender
            };

            var oldEmployee = new Employee
            {
                ID = new Guid(guidStr),
                FirstName = employees.Find(e => e.ID == employeeID).FirstName,
                LastName = employees.Find(e => e.ID == employeeID).LastName,
                Email = employees.Find(e => e.ID == employeeID).Email,
                Phone = employees.Find(e => e.ID == employeeID).Phone,
                DepartmentId = employees.Find(e => e.ID == employeeID).DepartmentId,
                Gender = employees.Find(e => e.ID == employeeID).Gender
            };

            

            employees.Find(e => e.ID == employeeID).FirstName = updatedEmployee.FirstName;
            employees.Find(e => e.ID == employeeID).LastName = updatedEmployee.LastName;
            employees.Find(e => e.ID == employeeID).Email = updatedEmployee.Email;
            employees.Find(e => e.ID == employeeID).Phone = updatedEmployee.Phone;
            employees.Find(e => e.ID == employeeID).DepartmentId = updatedEmployee.DepartmentId;
            employees.Find(e => e.ID == employeeID).Gender = updatedEmployee.Gender;

            var resultEmployee = employees.Find(e => e.ID == employeeID);

            if (employees.Exists(e => e.ID == updatedEmployee.ID && e.FirstName == updatedEmployee.FirstName && e.LastName == updatedEmployee.LastName && e.Email == updatedEmployee.Email && e.Phone == updatedEmployee.Phone))
            {
                isUpdated = true;
            }

            if (employees.Exists(e => e.ID == oldEmployee.ID && e.FirstName == oldEmployee.FirstName && e.LastName == oldEmployee.LastName && e.Email == oldEmployee.Email && e.Phone == oldEmployee.Phone))
            {
                isUpdated = false;
            }

            Assert.AreEqual(true, isUpdated);
        }

        [TestMethod]
        [DataRow("{6A8B8B19-EDDA-49FC-99DF-1037F1E51CD8}", "Draco", "Malfoy", "draco@gmail.com", "983-239-2398", 2, "Male")]
        public void UpdateEmployee_False_CannotFindEmployeeToUpdateAndThrowException(string guidStr, string firstName, string lastName, string email, string phone, int departmentID, string gender)
        {
            bool isUpdated = false;
            var employeeID = new Guid(guidStr);
            var updatedEmployee = new Employee
            {
                ID = new Guid(guidStr),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                DepartmentId = departmentID,
                Gender = gender
            };
            
            try
            {
                employees.Find(e => e.ID == employeeID).FirstName = updatedEmployee.FirstName;
                employees.Find(e => e.ID == employeeID).LastName = updatedEmployee.LastName;
                employees.Find(e => e.ID == employeeID).Email = updatedEmployee.Email;
                employees.Find(e => e.ID == employeeID).Phone = updatedEmployee.Phone;
                employees.Find(e => e.ID == employeeID).DepartmentId = updatedEmployee.DepartmentId;
                employees.Find(e => e.ID == employeeID).Gender = updatedEmployee.Gender;

                var resultEmployee = employees.Find(e => e.ID == employeeID);

                if (employees.Exists(e => e.ID == updatedEmployee.ID && e.FirstName == updatedEmployee.FirstName && e.LastName == updatedEmployee.LastName && e.Email == updatedEmployee.Email && e.Phone == updatedEmployee.Phone))
                {
                    isUpdated = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                isUpdated = false;
            }

            Assert.AreEqual(false, isUpdated);
        }

        //[TestMethod]
        //[DataRow(Employee => Employee.Name)]
        //public void GetSpecificEmployeesByFirstName_True_GetCorrectEmployees(Func<Employee,bool> func)
        //{
        //    var employeesByFirstName = new List<Employee>
        //    {
        //        new Employee{ID = new Guid("965CD684-8078-44A4-8186-E2E5F4B31A6E"), FirstName="Kha",LastName="Tran",Email="khatran@hotmail.com",Phone="714-285-7695",DepartmentId=1,Gender="Male"},
        //        new Employee{ID=new Guid("{22B443AD-F9C1-43D7-8D06-97B5475BC197}"),FirstName ="Kha", LastName="Nguyen",Email="drago@hotmail.com",Phone="713-298-7982",DepartmentId=4, Gender="Male"},
        //         new Employee{ID=new Guid("{BD780E3E-408F-4A6B-85D0-0BC1108BA8AA}"),FirstName ="Kha", LastName="Thao",Email="kthao@hotmail.com",Phone="452-789-1254",DepartmentId=3, Gender="Female"},
        //          new Employee{ID=new Guid("{79BC72B3-469F-4DD5-A484-DDF776C0B4A5}"),FirstName ="Kha", LastName="Do",Email="dokha@hotmail.com",Phone="458-129-7531",DepartmentId=2, Gender="Female"},
        //    };
        //}

    }
}
