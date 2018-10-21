using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmMana.DALInterfaces;
using EmMana.Models;

namespace EmMana.EmployeeSQLServer
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

        public void AddEmployee(EmployeeCommon employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spInsertEmployee", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@ID", SqlDbType.Int).Value = employee.Id;
                    command.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = employee.FirstName;
                    command.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = employee.LastName;
                    command.Parameters.Add("@Email", SqlDbType.VarChar).Value = employee.Email;
                    command.Parameters.Add("@Phone", SqlDbType.VarChar).Value = employee.Phone;
                    command.Parameters.Add("@DeparmentID", SqlDbType.Int).Value = employee.DepartmentId;
                   
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
        }

        public void DeleteEmployee(int targetID)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeCommon> GetAllEmployees()
        {
            List<EmployeeCommon> employeeCommons = new List<EmployeeCommon>();

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
                            employeeCommons.Add(new EmployeeCommon
                            {
                                Id = (int)reader["ID"],
                                FirstName = reader["Firstname"].ToString(),
                                LastName = (string)reader["Lastname"],
                                Email = (string)reader["Email"],
                                Phone = (string)reader["Phone"],
                                DepartmentId = (int)reader["DepartmentID"],
                                GenderId = (int)reader["GenderID"]
                            });
                        }

                        return employeeCommons;
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }

        public EmployeeCommon GetEmployeeByID(int targetID)
        {
            throw new NotImplementedException();
        }

        public EmployeeCommon GetEmployeeByFirstName(string firstname)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(int targetID, EmployeeCommon employee)
        {
            throw new NotImplementedException();
        }

        public bool IsEmployeeExisted(int targetID)
        {
            throw new NotImplementedException();
        }

        public int GetNextAvailableEmployeeID()
        {
            throw new NotImplementedException();
        }

        public void OpenConnection()
        {
            throw new NotImplementedException();
        }

        
    }
}
