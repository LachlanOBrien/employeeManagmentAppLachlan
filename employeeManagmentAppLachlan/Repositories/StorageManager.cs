using System;
using System.Collections.Generic;
using System.Data;
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

        public List<LocationTblLocation> GetLocationTblLocations()
        {
            List<LocationTblLocation> locations = new List<LocationTblLocation>();
            string sqlString = "SELECT * From Location.tblLocation";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Location_ID = Convert.ToInt32(reader["LocationID"]);
                        string Location_Name = reader["LocationName"].ToString();
                        locations.Add(new LocationTblLocation(Location_ID, Location_Name));
                    }
                }
            }
            return locations;
        }
        public List<EmployeeTblEmployeeContact> GetEmployeeTblEmployeeContacts()
        {
            List<EmployeeTblEmployeeContact> employeeContatct = new List<EmployeeTblEmployeeContact>();
            string sqlString = "SELECT * FROM Employee.tblEmployeeContacts";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int employeid = Convert.ToInt32(reader["EmployeeID"]);
                        string email = reader["Email"].ToString();
                        string phonenumber = reader["Phonenumber"].ToString();
                        employeeContatct.Add(new EmployeeTblEmployeeContact(employeid, email, phonenumber));
                    }
                }
            }
            return employeeContatct;
        }

        public int UpdateLocationName(int LocationID, string LocationName)//change it from searching id to name
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.tblLocation SET LocationName = @LocationName Where LocationID = @LocationID", conn))
            {
                cmd.Parameters.AddWithValue("@LocationName", LocationName);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertLocation(LocationTblLocation LocationName)
        {
            using (SqlCommand cmd = new SqlCommand($"INSERT INTO Location.tblLocation (LocationName) VALUES (@LocationName); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@LocationName", LocationName.Location_Name);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int DeleteLocationByName(string LocationName)
        {
            using (SqlCommand cmd = new SqlCommand($"DELETE FROM Location.tblLocation WHERE LocationName = @LocationName", conn))
            {
                cmd.Parameters.AddWithValue($"@LocationName", LocationName);
                return cmd.ExecuteNonQuery();
            }
        }

        public void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                Console.WriteLine("connection closed");
            }
        }
    }
}
