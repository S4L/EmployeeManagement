using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Data.SqlClient;
using EmpManage.Models;

namespace EmMana.Test.SQLServerProvider
{
    /// <summary>
    /// Summary description for EmployeeDATest
    /// </summary>
    [TestClass]
    public class EmployeeDATest
    {
          #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetConnectionString_True_ConnectionStringNotNull()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString;
            Assert.IsTrue(connectionString != null);
        }

        [TestMethod]
        public void GetConnectionString_True_ConnectionStringMatchWithExpectedResult()
        {
            var expectConnectionStr = "Data Source=SOL-PC;Initial Catalog=EmployeeDB;Integrated Security=True";
            var connectionString = ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString;
            Assert.AreEqual(expectConnectionStr, connectionString);
        }

        [TestMethod]
        public void GetEmployees_True_EmployeeListNotEmpty()
        {
            List<Employee> employeeCommons = new List<Employee>();
            var connectionString = "Data Source=SOL-PC;Initial Catalog=EmployeeDB;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("spGetEmployees", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employeeCommons.Add(new Employee
                            {
                                ID = new Guid(reader["ID"].ToString()),
                                FirstName = (string)reader["Firstname"],
                                LastName = (string)reader["Lastname"],
                                Email = (string)reader["Email"],
                                Phone = (string)reader["Phone"],
                                DepartmentId = (int)reader["DepartmentID"],
                                Gender = (string)reader["Gender"]
                            });
                        }
                    }
                }
                  
            }
            Assert.IsTrue(employeeCommons.Count > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"Invalid Connection String")]
        public void GetEmployees_ThrowArgumentException_InvalidConnectionString()
        {
            List<Employee> employeeCommons = new List<Employee>();
            var connectionString = "Data Source=SOL-PC;Initial Catalog=EmployeeDB; Security=True"; //Missing "Intergrated" before "Security"
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("spGetEmployees", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employeeCommons.Add(new Employee
                            {
                                ID = new Guid(reader["ID"].ToString()),
                                FirstName = (string)reader["Firstname"],
                                LastName = (string)reader["Lastname"],
                                Email = (string)reader["Email"],
                                Phone = (string)reader["Phone"],
                                DepartmentId = (int)reader["DepartmentID"],
                                Gender = (string)reader["Gender"]
                            });
                        }
                    }
                }

            }
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException), "Invalid Command/Cannot find store procedure")]
        public void GetEmployees_ThrowException_InvalidConnectionString()
        {
            List<Employee> employeeCommons = new List<Employee>();
            var connectionString = "Data Source=SOL-PC;Initial Catalog=EmployeeDB; Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("spGetEmployee", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employeeCommons.Add(new Employee
                            {
                                ID = new Guid(reader["ID"].ToString()),
                                FirstName = (string)reader["Firstname"],
                                LastName = (string)reader["Lastname"],
                                Email = (string)reader["Email"],
                                Phone = (string)reader["Phone"],
                                DepartmentId = (int)reader["DepartmentID"],
                                Gender = (string)reader["Gender"]
                            });
                        }
                    }
                }

            }
        }
    }
}
