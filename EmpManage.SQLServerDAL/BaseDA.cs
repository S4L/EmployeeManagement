using System.Configuration;
using System.Diagnostics;

namespace EMS.SQLServerDAL
{
    public class BaseDA
    {
        public BaseDA()
        {
            GetConnectionString();
        }

        public string ConnectionString { get; set; }

        private string GetConnectionString()
        {
            string connectionString = "";

            try
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString;
                return connectionString;
            }
            catch (ConfigurationErrorsException ex)
            {
                Debug.WriteLine(ex.ToString());
                return connectionString;
            }
        }
    }
}
