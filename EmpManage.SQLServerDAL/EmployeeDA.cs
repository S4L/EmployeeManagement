using EmpManage.Interfaces;
using EmpManage.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace EmpManage.SQLServerDAL
{
    public class EmployeeDA : IEmployeeDataAccess
    {
        private string _connectionString;

        public EmployeeDA()
        {
            _connectionString = GetConnectionString();
        }

        private string GetConnectionString()
        {
            string connectionString = "";

            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString;
                return connectionString;
            }
            catch (ConfigurationErrorsException ex)
            {
                Debug.WriteLine(ex.ToString());
                return connectionString;
            }
        }

        public bool AddEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spInsertEmployee", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = employee.ID;
                    command.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = employee.FirstName;
                    command.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = employee.LastName;
                    command.Parameters.Add("@Email", SqlDbType.VarChar).Value = employee.Email;
                    command.Parameters.Add("@Phone", SqlDbType.VarChar).Value = employee.Phone;
                    command.Parameters.Add("@DeparmentID", SqlDbType.Int).Value = employee.DepartmentId;
                    
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public bool DeleteEmployee(Guid employeeID)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand("spDeleteEmployee", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = employeeID;

                    command.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
                
            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spGetEmployees", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                employees.Add(new Employee
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
                        return employees;
                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }

        public bool UpdateEmployee(Guid employeeID, Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spUpdateEmployee", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = employee.ID;
                    command.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = employee.FirstName;
                    command.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = employee.LastName;
                    command.Parameters.Add("@Email", SqlDbType.VarChar).Value = employee.Email;
                    command.Parameters.Add("@Phone", SqlDbType.VarChar).Value = employee.Phone;
                    command.Parameters.Add("@DeparmentID", SqlDbType.Int).Value = employee.DepartmentId;

                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
            }
        }
    }
}
