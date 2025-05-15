using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using employeeManagmentAppLachlan.Model;
using Microsoft.Data.SqlClient;

namespace employeeManagmentAppLachlan.Repositories
{

    public class StorageManager
    {
        private SqlConnection conn;

        public StorageManager(string connectionString)
            
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                Console.WriteLine("Connection succsesfull");
            }
            catch (SqlException e)
            {
                Console.WriteLine("The connections is Unsuccessfull");
                Console.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("The connections is Unsuccessfull");
                Console.WriteLine(ex.Message);
            }
        }

        public List<LocationTblLocation> GetLocationsTblLocations()
        {
            List<LocationTblLocation> locations = new List<LocationTblLocation>();
            string sqlString = "SELECT * From Location.tblLocation";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {

            }
        }
    }
}
