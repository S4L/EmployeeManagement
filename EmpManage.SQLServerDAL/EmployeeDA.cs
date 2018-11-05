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
            string connectionString = null;

            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["LaptopDBCS"].ConnectionString;
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
                    SqlCommand command = new SqlCommand("spInsertEmployee", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    //command.Parameters.Add("@ID", SqlDbType.Int).Value = employee.Id;
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
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employeeCommons = new List<Employee>();

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spGetEmployees", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
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

                        return employeeCommons;
                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }

        public Employee GetEmployeeByID(Guid employeeID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmployee(Guid employeeID, Employee employee)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetSpecificEmployees(Func<Employee, bool> func)
        {
            throw new NotImplementedException();
        }
    }
}
