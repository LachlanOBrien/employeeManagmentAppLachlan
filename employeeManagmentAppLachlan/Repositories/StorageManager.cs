using Azure;
using employeeManagmentAppLachlan.Model;
using employeeManagmentAppLachlan.View;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Repositories
{

    public class StorageManager
    {
        private SqlConnection conn;
        private static consoleView view;
        //possibly change it so it filter by username later so the user doesnt have to so it then gets the username and then gets the password that relates to that username then we can relate it to the users input and check if its a match and if it is then let them in with some work to get the admin and then display the proper switch case / method
        // also might have to split this method into 2. 1 for username, 1 for password so the return isnt returning 2 variables then i can declare each variable with their own method.
        //return username + password ;

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

        
        public List<tblCityID> GetTblCityIDs()
        {
            List<tblCityID> city = new List<tblCityID>();
            string sqlString = "SELECT * FROM location.tblLocationCity";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int CityID = Convert.ToInt32(reader["CityID"]);
                        string CityName = reader["CityName"].ToString();
                        city.Add(new tblCityID(CityID, CityName));
                    }
                }
            }
            return city;
        }

        public List<tblDepartments> GetTblDepartments()
        {
            List<tblDepartments> departments = new List<tblDepartments>();
            string sqlString = "SELECT * FROM Location.tblDepartments";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int LocationID = Convert.ToInt32(reader["LocationID"]);
                        string Departments = reader["Departments"].ToString();
                        int ManagersID = Convert.ToInt32(reader["ManagersID"]);
                        int DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                        departments.Add(new tblDepartments(LocationID, Departments,ManagersID,DepartmentID));
                    }
                }
            }
            return departments;
        }

       /* public string getUserName(string Username)
        {
            user user = new user();
            string password = "";
            string username = "";
            int Role = 0;
            string sqlString = "SELECT * FROM Employee.tblEmployeeRole WHERE Username = @Username";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // EmployeeID = Convert.ToInt32(reader["Role"]);
                        username = reader["Username"].ToString();
                        password = reader["Password"].ToString();
                        Role = Convert.ToInt32(reader["Role"]);
                        //Console.WriteLine("EmployeeID: " + EmployeeID);
                       // Console.WriteLine("Username: " + username);
//Console.WriteLine("Password: " + password);
                        //Console.WriteLine("Role: " + Role);
                    }
                }
            }
            user.username = username;
            user.password = password;
            //user.EmployeeID = EmployeeID;
            user.role = Role;
            return username;
        }*/ 

        public int getEmployeeID(string Username)
        {
            int username = 0;
            string sqlString = "SELECT EmployeeID FROM Employee.tblEmployeeRole WHERE Username = @Username";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                cmd.Parameters.AddWithValue("@Username", Username);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        username = Convert.ToInt32(reader["EmployeeID"]);
                        //Console.WriteLine("Password: " + password);

                    }
                }
            }
            return username;
        }

        public string getPassword(string Username)
        {
            string password = "";
            string sqlString = "SELECT Password FROM Employee.tblEmployeeRole WHERE Username = @Username";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                cmd.Parameters.AddWithValue("@Username", Username);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        password = reader["Password"].ToString();
                        //Console.WriteLine("Password: " + password);

                    }
                }
            }
            return password;
        }

        public int getRole(string Username)
        {
            int Role = 0;
            string sqlString = "SELECT Role FROM Employee.tblEmployeeRole WHERE Username = @Username";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                cmd.Parameters.AddWithValue("@Username", Username);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Role = Convert.ToInt32(reader["Role"]);
                        //Console.WriteLine("Role: " + Role);

                    }
                }
            }
            return Role;
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



        public List<tblEmployeeDetails> GetTblEmployeeDetails()
        {
            List<tblEmployeeDetails> employeeDetails = new List<tblEmployeeDetails>();
            string sqlString = "SELECT * FROM Employee.tblEmployeesDetails";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                        string Firstname = reader["Firstname"].ToString();
                        string Lastname = reader["Lastname"].ToString();
                        DateTime Hiredate = Convert.ToDateTime(reader["HireDate"]);
                        string Gender = reader["Gender"].ToString();
                        int JobID = Convert.ToInt32(reader["JobID"]);
                        int RoleID = Convert.ToInt32(reader["RoleID"]);
                        string Username = reader["Username"].ToString();
                        string Password = reader["Password"].ToString();
                        string Active = reader["Active"].ToString();
                        string Email = reader["Email"].ToString();
                        int PhoneNumber = Convert.ToInt32(reader["Phonenumber"]);
                        int Wage = Convert.ToInt32(reader["Wage"]);
                        employeeDetails.Add(new tblEmployeeDetails(EmployeeID, Firstname,  Lastname,  Hiredate,  Gender,  JobID,  RoleID,  Username, Password, Active,  Email,  PhoneNumber,  Wage));
                    }
                }
            }
            return employeeDetails;
        }

        public List<tblEmployeeLocations> GetTblEmployeeLocations()
        {
            List<tblEmployeeLocations> employeeLocations = new List<tblEmployeeLocations>();
            string sqlString = "SELECT * FROM Employee.tblEmployeeLocations";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                        int LocationID = Convert.ToInt32(reader["LocationID"]);
                        employeeLocations.Add(new tblEmployeeLocations(EmployeeID,LocationID));
                    }
                }
            }
            return employeeLocations;
        }

        public List<tblEmployeeRoleName> GetTblEmployeeRoleNames()
        {
            List<tblEmployeeRoleName> EmployeeRole = new List<tblEmployeeRoleName>();
            string sqlString = "SELECT * FROM Employee.tblEmployeeRoleName";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int RoleID = Convert.ToInt32(reader["RoleID"]);
                        string RoleName = reader["RoleName"].ToString();
                        EmployeeRole.Add(new tblEmployeeRoleName(RoleID, RoleName));
                    }
                }
            }
            return EmployeeRole;
        }

        public List<tblJobtitle> GetEmployeeTblJobTittles()
        {
            List<tblJobtitle> jobTittles = new List<tblJobtitle>();
            string sqlString = "SELECT * FROM Employee.tblJobTittles";
            using (SqlCommand cmd = new SqlCommand(sqlString,conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int jobtitleid = Convert.ToInt32(reader["jobtitleID"]);
                        string JobtitleName = reader["JobtitleName"].ToString();
                        jobTittles.Add(new tblJobtitle(jobtitleid, JobtitleName));
                    }
                }
            }
            return jobTittles;
        }

        public List<tblLocation> GetTblLocations()
        {
            List<tblLocation> locations = new List<tblLocation>();
            string sqlString = "SELECT * FROM Location.tblLocation";
            using (SqlCommand cmd = new SqlCommand(sqlString,conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int LocationID = Convert.ToInt32(reader["LocationID"]);
                        string LocationName = (reader["LocationName"]).ToString();
                        int CountryID = Convert.ToInt32(reader["CountryID"]);
                        int SuburbID = Convert.ToInt32(reader["SuburbID"]);
                        int StreetID = Convert.ToInt32(reader["StreetID"]);
                        int CityID = Convert.ToInt32(reader["CityID"]);
                        int StreetNumber = Convert.ToInt32(reader["StreetNumber"]);
                        locations.Add(new tblLocation(LocationID,  LocationName,  CountryID,  SuburbID, StreetID, CityID, StreetNumber));
                    }
                }
            }
            return locations;
        }

        public List<tblLocationCountry> GetTblLocationCountries()
        {
            List<tblLocationCountry> LocationCountry = new List<tblLocationCountry>();
            string sqlString = "SELECT * From Location.tblLocationCountry";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int CountryID = Convert.ToInt32(reader["CountryID"]);
                        string CountryName = reader["CountryName"].ToString();
                        LocationCountry.Add(new tblLocationCountry(CountryID, CountryName));
                    }
                }
            }
            return LocationCountry;
        }

        public List<tblStreetID> GetTblStreetIDs()
        {
            List<tblStreetID> street = new List<tblStreetID>();
            string sqlString = "SELECT * From Location.tblLocationStreet";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int StreetID = Convert.ToInt32(reader["StreetID"]);
                        string StreetName = reader["StreetName"].ToString();
                        street.Add(new tblStreetID(StreetID, StreetName));
                    }
                }
            }
            return street;
        }

        public List<tblSubrubID> GetTblSubrubIDs()
        {
            List<tblSubrubID> subrub = new List<tblSubrubID>();
            string sqlString = "SELECT * FROM Location.tblLocationSubrub";
            using (SqlCommand cmd = new SqlCommand(sqlString,conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int SubrubID = Convert.ToInt32(reader["SuburbID"]);
                        string SuburbName = reader["Subrub"].ToString();
                        int Postcode = Convert.ToInt32(reader["PostCode"]);
                        subrub.Add(new tblSubrubID(SubrubID,SuburbName,Postcode));
                    }
                }
            }
            return subrub;
        }

        public List<tblLocationDepartment> GetTblLocationDepartments()
        {
            List<tblLocationDepartment> locationDepartments = new List<tblLocationDepartment>();
            string sqlString = "SELECT * From Location.tblLocation";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int LocationID = Convert.ToInt32(reader["LocationID"]);
                        int DepartMentID = Convert.ToInt32(reader["DepartMentID"]);
                        locationDepartments.Add(new tblLocationDepartment(LocationID, DepartMentID));
                    }
                }
            }
            return locationDepartments;
        }

        public int UpdateLocationName(int LocationID, string LocationName)//change it from searching id to name example 
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.tblLocation SET LocationName = @LocationName Where LocationID = @LocationID", conn))
            {
                cmd.Parameters.AddWithValue("@LocationName", LocationName);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                return cmd.ExecuteNonQuery();
            }
        }

        public string UpdateRoleName(string RoleName,string RoleNameChange)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Employee.tblEmployeeRoleName SET RoleName = @RoleNameChange Where RoleName = @RoleName", conn))
            {
                cmd.Parameters.AddWithValue("@RoleName", RoleName);
                cmd.Parameters.AddWithValue("@RoleNameChange", RoleNameChange);
                return cmd.ExecuteNonQuery().ToString();
            }
        }

        public string UpdateJobTitle(string JobTitle, string JobTitleChange)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Employee.tblJobTitles SET JobTitleName = @JobTitleChange Where JobTitle = @JobTitle", conn))
            {
                cmd.Parameters.AddWithValue("@JobTitle", JobTitle);
                cmd.Parameters.AddWithValue("@JobTitleChange", JobTitleChange);
                return cmd.ExecuteNonQuery().ToString();
            }
        }
        public string UpdateLocationCountry(string CountryName, string CountryNameChange)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.tblLocationCountry SET CountryName = @CountryName Where CountryName = @CountryName", conn))
            {
                cmd.Parameters.AddWithValue("@CountryName", CountryName);
                cmd.Parameters.AddWithValue("@CountryNameChange", CountryNameChange);
                return cmd.ExecuteNonQuery().ToString();
            }
        }
        public string UpdateLocationStreet(string StreetName, string StreetNameChange)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.tblLocationStreet SET StreetName = @StreetName Where StreetName = @StreetName", conn))
            {
                cmd.Parameters.AddWithValue("@StreetName", StreetName);
                cmd.Parameters.AddWithValue("@StreetNameChange", StreetNameChange);
                return cmd.ExecuteNonQuery().ToString();
            }
        }

        public string UpdateLocationCity(string CityName, string CityNameChange)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.tblLocationStreet SET CityName = @CityName Where CityName = @CityName", conn))
            {
                cmd.Parameters.AddWithValue("@CityName", CityName);
                cmd.Parameters.AddWithValue("@CityNameChange", CityNameChange);
                return cmd.ExecuteNonQuery().ToString();
            }
        }




        /*public int InsertLocation(LocationTblLocation LocationName)
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
        }*/

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
