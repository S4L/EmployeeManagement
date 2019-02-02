using EMS.Interfaces;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace EMS.SQLServerDAL
{
    public class DepartmentDA : BaseDA, IDepartment
    {
        public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand("spGetDepartments", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                departments.Add(new Department
                                {
                                    ID = (int)reader["ID"],
                                    Name = (string)reader["Name"]
                                });
                            }
                        }
                    }
                    return departments;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return new List<Department>();
                }
            }
        }

        public int GetDepartmentIDByName(string name)
        {
            int id = 0;
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand("spGetDepartmentIDByName", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;

                    id = (int)command.ExecuteScalar();
                    return id;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return id;
                }
            }


        }

        public string GetDepartmentNameByID(int id)
        {
            string departmentName = "";
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand("spGetDepartmentNameByID", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = id;

                    return (string)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return departmentName;
                }
            }
        }
    }
}
