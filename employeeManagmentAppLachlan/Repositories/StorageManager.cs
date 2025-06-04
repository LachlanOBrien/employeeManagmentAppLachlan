using employeeManagmentAppLachlan.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

       
        public List<EmployeeTblEmployeeContact> GetEmployeeTblEmployeeContacts()
        {
            List<EmployeeTblEmployeeContact> employeeContatct = new List<EmployeeTblEmployeeContact>();
            string sqlString = "SELECT * FROM Employee.tblEmployeeContact";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int employeeid = Convert.ToInt32(reader["EmployeeID"]);
                        string email = reader["Email"].ToString();
                        string phonenumber = reader["Phonenumber"].ToString();
                        employeeContatct.Add(new EmployeeTblEmployeeContact(employeeid, email, phonenumber));
                    }
                }
            }
            return employeeContatct;
        }

        public List<EmployeeTblEmployeeLocations> GetEmployeeTblEmployeeLocations()
        {
            List<EmployeeTblEmployeeLocations> employeeLocations = new List<EmployeeTblEmployeeLocations>();
            string sqlString = "SELECT * FROM Employee.tblEmployeeLocations";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int employeeid = Convert.ToInt32(reader["EmployeeID"]);
                        int locationid = Convert.ToInt32(reader["LocationID"]);
                        employeeLocations.Add(new EmployeeTblEmployeeLocations(employeeid, locationid));
                    }
                }
            }
            return employeeLocations;
        }

        /*  public string getUserPass(int EmployeeID)
          {
              /*string username = "";
              string sqlString = "SELECT Username FROM Employee.tblEmployeeRole WHERE EmployeeID = @EmployeeID";
              using (SqlCommand cmd = new SqlCommand(sqlString, conn))
              {
                  using (SqlDataReader reader = cmd.ExecuteReader())
                  {
                      while (reader.Read())
                      {
                          int
                      }
                  }
              }
              EmployeeID = 3;
              string username = "";
              using (SqlCommand cmd = new SqlCommand($"SELECT Username, Password FROM Employee.tblEmployeeRole WHERE EmployeeID =  @EmployeeID", conn))
              {
                  cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
              }
              Console.WriteLine(username);
              return username;
          }*/
        public string getUserPass(int EmployeeID)
        {
            string username = "";
            string password = "";

            using (SqlCommand cmd = new SqlCommand("SELECT Username, Password FROM Employee.tblEmployeeRole WHERE EmployeeID = @EmployeeID", conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        username = reader["Username"].ToString();
                        password = reader["Password"].ToString(); 
                        Console.WriteLine("Username: " + username);
                        Console.WriteLine("Password: " + password);
                    }
                    else
                    {
                        Console.WriteLine("No user found with EmployeeID = " + EmployeeID);
                    }
                }
            }
            //possibly change it so it filter by username later so the user doesnt have to so it then gets the username and then gets the password that relates to that username then we can relate it to the users input and check if its a match and if it is then let them in with some work to get the admin and then display the proper switch case / method
            // also might have to split this method into 2. 1 for username, 1 for password so the return isnt returning 2 variables then i can declare each variable with their own method.
            //return username + password ;
            return username;
        }



        /*
        public int UpdateLocationName(int LocationID, string LocationName)//change it from searching id to name
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.tblLocation SET LocationName = @LocationName Where LocationID = @LocationID", conn))
            {
                cmd.Parameters.AddWithValue("@LocationName", LocationName);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                return cmd.ExecuteNonQuery();
            }
        }
        */


        public List<EmployeeTblEmployeeRole> GetEmployeeTblEmployeeRoles()
        {
            List<EmployeeTblEmployeeRole> employeeRole = new List<EmployeeTblEmployeeRole>();
            string sqlString = "SELECT * FROM Employee.tblEmployeeRole";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //int employeeid = Convert.ToInt32(reader["EmployeeID"]);
                        //int locationid = Convert.ToInt32(reader["LocationID"]);
                        int employeeID = Convert.ToInt32(reader["EmployeeID"]);
                        string username = reader["Username"].ToString();
                        string password = reader["Password"].ToString();
                        int role = Convert.ToInt32(reader["role"]);
                        employeeRole.Add(new EmployeeTblEmployeeRole(employeeID, username, password, role));
                    }
                }
            }
            return employeeRole;
        }

        public List<EmployeeTblEmployeesDetails> GetEmployeeTblEmployeesDetails()
        {
            List<EmployeeTblEmployeesDetails> employeeDetails = new List<EmployeeTblEmployeesDetails>();
            string sqlString = "SELECT * FROM Employee.tblEmployeesDetails";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                        string firstname = reader["FirstName"].ToString();
                        string lastname = reader["LastName"].ToString();
                        DateTime hiredate = Convert.ToDateTime(reader["HireDate"]);
                        string gender = reader["Gender"].ToString();
                        int jobid = Convert.ToInt32(reader["JobID"]);
                    }
                }
            }
            return employeeDetails;
        }

        public List<EmployeeTblEmployeeWage> GetEmployeeTblEmployeeWages()
        {
            List<EmployeeTblEmployeeWage> employeeWages = new List<EmployeeTblEmployeeWage>();
            string sqlString = "SELECT * FROM Employee.tblEmployeeWage";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int employeeid = Convert.ToInt32(reader["EmployeeID"]);
                        int jobtitleid = Convert.ToInt32(reader["JobtitleID"]);
                        int wage = Convert.ToInt32(reader["Wage"]);
                    }
                }
            }
            return employeeWages;
        }

        public List<EmployeeTblJobTittles> GetEmployeeTblJobTittles()
        {
            List<EmployeeTblJobTittles> jobTittles = new List<EmployeeTblJobTittles>();
            string sqlString = "SELECT * FROM Employee.tblJobTittles";
            using (SqlCommand cmd = new SqlCommand(sqlString,conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int jobtitleid = Convert.ToInt32(reader["jobtitleID"]);
                        string JobtitleName = reader["JobtitleName"].ToString();
                    }
                }
            }
            return jobTittles;
        }

        public List<LocationTblDepartments> GetLocationTblDepartments()
        {
            List<LocationTblDepartments> Departments = new List<LocationTblDepartments>();
            string sqlString = "SELECT * FROM Location.tblDepartments";
            using (SqlCommand cmd = new SqlCommand(sqlString,conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int LocationID = Convert.ToInt32(reader["LocationID"]);
                        string deparments = (reader["Departments"]).ToString();
                        int managersID = Convert.ToInt32(reader["ManagersID"]);
                    }
                }
            }
            return Departments;
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

        public List<LocationTblLocationAdress> GetLocationTblLocationAdresses()
        {
            List<LocationTblLocationAdress> locationAdresses = new List<LocationTblLocationAdress>();
            string sqlString = "SELECT * FROM Location.tblLocationAdress";
            using (SqlCommand cmd = new SqlCommand(sqlString,conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int LocationID = Convert.ToInt32(reader["LocationID"]);
                        int cityID = Convert.ToInt32(reader["CityID"]);
                        string country = reader["country"].ToString();
                    }
                }
            }
            return locationAdresses;
        }

        public List<LocationTblLocationCity> GetLocationTblLocationCities()
        {
            List<LocationTblLocationCity> locationCities = new List<LocationTblLocationCity>();
            string sqlString = "SELECT * FROM Location.tblLocationCity";
            using (SqlCommand cmd = new SqlCommand(sqlString,conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int CityID = Convert.ToInt32(reader["CityID"]);
                        string suburb = reader["suburb"].ToString();
                        string postcode = reader["postcode"].ToString();
                        string street = reader["street"].ToString();
                        string city = reader["city"].ToString();
                    }
                }
            }
            return locationCities;
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
