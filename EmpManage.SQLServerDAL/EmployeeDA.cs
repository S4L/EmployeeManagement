using EMS.Interfaces;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace EMS.SQLServerDAL
{
    public class EmployeeDA : BaseDA,IEmployee
    {
        public bool AddEmployee(Employee employee)
        {
            bool isAdded = false;
            using (var connection = new SqlConnection(ConnectionString))
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

                    //command.Parameters.Add("@Email", SqlDbType.VarChar).Value = employee.Email;
                    if (employee.Email == null)
                        command.Parameters.Add("@Email", SqlDbType.VarChar).Value = DBNull.Value;
                    else
                        command.Parameters.Add("@Email", SqlDbType.VarChar).Value = employee.Email;

                    command.Parameters.Add("@Phone", SqlDbType.VarChar).Value = employee.Phone;
                    command.Parameters.Add("@Gender", SqlDbType.VarChar).Value = employee.Gender;
                    command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = employee.DepartmentId;
                    
                    int rowAffected = command.ExecuteNonQuery();

                    if (rowAffected > 0)
                        isAdded = true;

                    return isAdded;
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
            bool isDeleted = false;
            using(var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand("spDeleteEmployee", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = employeeID;

                    int rowAffected = command.ExecuteNonQuery();

                    if (rowAffected > 0)
                        isDeleted = true;

                    return isDeleted;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return isDeleted;
                }
                
            }
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns>
        ///   1. List of employee, may be empty.
        ///   2. null - DB error (DB inaccessible, etc.)
        /// </returns>
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (var connection = new SqlConnection(ConnectionString))
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
                                    Email = (string)reader["Email"], // DBNull.Value
                                    Phone = (string)reader["Phone"],
                                    DepartmentId = new Guid((string)reader["DepartmentID"]),
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

        //public bool UpdateEmployee(Guid employeeID, Employee employee)
        //{
        //    using (var connection = new SqlConnection(ConnectionString))
        //    {
        //        try
        //        {
        //            connection.Open();
        //            SqlCommand command = new SqlCommand("spUpdateEmployee", connection)
        //            {
        //                CommandType = System.Data.CommandType.StoredProcedure
        //            };

        //            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = employee.ID;
        //            command.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = employee.FirstName;
        //            command.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = employee.LastName;
        //            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = employee.Email;
        //            command.Parameters.Add("@Phone", SqlDbType.VarChar).Value = employee.Phone;
        //            command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = employee.DepartmentId;

        //            command.ExecuteNonQuery();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine(ex.ToString());
        //            return false;
        //        }
        //    }
        //}

        public bool UpdateEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(ConnectionString))
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
                    command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = employee.DepartmentId;

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
