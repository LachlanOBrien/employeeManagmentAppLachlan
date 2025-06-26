using Azure;
using Azure.Core.GeoJson;
using employeeManagmentAppLachlan.Model;
using employeeManagmentAppLachlan.View;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace employeeManagmentAppLachlan.Repositories
{

    public class StorageManager
    {
        private SqlConnection conn;
        private static consoleView view;
        static int tableWidth = 232;
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


        // displays the lines for the box that the data is displayed in
        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        // displays the rows for the box that the data is displayed in 
        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        //aligns the text in the boxes for the display methods
        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }



        // gets the data from the advancedQuery1 and returns it as the return of the method 
        public void AdvancedQuery1()
        {
            string sqlString = "SELECT Em.FirstName, Em.LastName, Em.HireDate, Em.Wage FROM Employee.tblEmployeesDetails as EM  where Active = 1 and (Em.Wage >= 80000.00 and Em.HireDate >= '2018-01-01') order by Em.FirstName, Em.LastName, Em.Wage, Em.HireDate;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    PrintLine();
                    PrintRow("First Name ", " Last Name", "Hire Date", " Wage");
                    while (reader.Read())
                    {
                        int wage = Convert.ToInt32(reader["Wage"]);
                        string firstName = reader["Firstname"].ToString();
                        string LastName = reader["Lastname"].ToString();
                        DateTime HireDate = Convert.ToDateTime(reader["HireDate"]);
                        PrintLine();
                        PrintRow($"{firstName}",$"{LastName}",$"{HireDate}",$"{wage}");
                        PrintLine();
                    }
                }
            }
        }
        // gets the data from the advancedQuery2 and returns it as the return of the method 
        public void AdvancedQuery2() 
        {
            string sqlString = "Select Em.FirstName, Em.LastName, Em.HireDate, LC.CountryName   from Employee.tblEmployeesDetails as Em, Location.tblLocation as LO, Employee.tblEmployeeLocations AS EMLO, Location.tblLocationCountry AS LC  where EMLO.LocationID = LO.LocationID   and EMLO.EmployeeID = Em.EmployeeID and LC.CountryID = LO.CountryID   and (LC.CountryName = 'United Kingdom' And Em.HireDate >= '2019-03-09 16:05:07.123')   order by 1,2,3,4;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    PrintLine();
                    PrintRow(" First Name ", " Last Name  ", "Hire Date ", " Country Name");
                    while (reader.Read())
                    {
                        string FirstName = reader["Firstname"].ToString();
                        string LastName = reader["Lastname"].ToString();
                        DateTime HireDate = Convert.ToDateTime(reader["HireDate"]);
                        string CountryName = reader["CountryName"].ToString();
                        int count = 0;
                        count ++;
                        PrintLine();
                        PrintRow($"{FirstName}", $"{LastName}", $"{HireDate}", $"{CountryName}");
                        PrintLine();

                    }
                }
            }
        }
        // gets the data from the advancedQuery3 and returns it as the return of the method 
        public void AdvancedQuery3()
        {
            string sqlString = "Select EM.EmployeeID, EM.Gender, EM.Wage from Employee.tblEmployeesDetails as EM where  (Gender = 'M') order by 1,2,3; ";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    PrintLine();
                    PrintRow(" Employee ID", " Gender", " Wage");
                    while (reader.Read())
                    {
                        int Wage = Convert.ToInt32(reader["Wage"]);
                        int EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                        string Gender = reader["Gender"].ToString();
                        PrintLine();
                        PrintRow($"{EmployeeID}", $"{Gender}", $"{Wage}");
                        PrintLine();
                    }
                }
            }
        }
        // gets the data from the advancedQuery4 and returns it as the return of the method 
        public void AdvancedQuery4()
            // smh need to link emp det > bridging table for location > location > coutry
        {
            string sqlString = " Select EM.FirstName, EM.LastName, LC.CountryName   from Employee.tblEmployeesDetails as EM,Location.tblLocation AS LO, Employee.tblEmployeeLocations AS EMLO, Location.tblLocationCountry as LC  Where EMLO.EmployeeID = EM.EmployeeID   and EMLO.LocationID = LO.LocationID  and LO.CountryID = LC.CountryID    and (EM.Gender = 'M' and LC.CountryName ='United States') Order by 1,2,3;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    PrintLine();
                    PrintRow(" First Name", " Last Name ", " country");
                    while (reader.Read())
                    {
                        string FirstName = reader["Firstname"].ToString();
                        string LastName = reader["Lastname"].ToString();
                        string country = reader["CountryName"].ToString();
                        PrintLine();
                        PrintRow($"{FirstName}", $"{LastName}", $"{country}");
                        PrintLine();
                    }
                }
            }
        }
        // gets the data from the advancedQuery5 and returns it as the return of the method 
        public void AdvancedQuery5()
        {
            string sqlString = " select EM.EmployeeID,EM.FirstName,EM.LastName,JT.JobtitleName  from Employee.tblEmployeesDetails as EM,Employee.tblJobTitles as JT where EM.JobID = JT.jobtitleID   and JobtitleName = ('Data Scientist')  order by 1,2,3,4;  ";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    PrintLine();
                    PrintRow("Employee ID", " First Name ", "Last Name ", " Job title Name");
                    while (reader.Read())
                    {
                        string FirstName = reader["Firstname"].ToString();
                        string LastName = reader["Lastname"].ToString();
                        int EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                        string JobtitleName = reader["JobtitleName"].ToString();
                        PrintLine();
                        PrintRow($"{EmployeeID}", $"{FirstName}", $"{LastName}", $"{JobtitleName}");
                        PrintLine();
                    }
                }
            }
        }

        // gets the data from the ComplexQuery1 and returns it as the return of the method 
        public void ComplexQuery1()
        {
            string sqlString = "select Count(ED.EmployeeID) as totalEmployees ,JT.jobtitleName  from Employee.tblEmployeesDetails as ED, Employee.tblJobTitles as JT where ED.JobID = JT.JobTitleID   and JT.JobtitleName = 'Software Engineer'  group by JobtitleName order by totalEmployees, JT.JobtitleName; ";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    PrintLine();
                    PrintRow("total Employees", " jobtitleName ");
                    while (reader.Read())
                    {
                        int totalEmployees = Convert.ToInt32(reader["totalEmployees"]);
                        string jobtitleName = reader["jobtitleName"].ToString();
                        PrintLine();
                        PrintRow($"{totalEmployees}", $"{jobtitleName}");
                        PrintLine();
                    }
                }
            }
        }
        // gets the data from the ComplexQuery2 and returns it as the return of the method
        public void ComplexQuery2()
        {
            string sqlString = "select Round(AVG(Wage),2) as avgWage    from Employee.tblEmployeesDetails   order by avgWage; ";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    PrintLine();
                    PrintRow("avg Wage");
                    while (reader.Read())
                    {
                        int avgWage = Convert.ToInt32(reader["avgWage"]);
                        PrintLine();
                        PrintRow($"{avgWage}");
                        PrintLine();
                    }
                }
            }
        }
        // gets the data from the ComplexQuery3 and returns it as the return of the method
        public void ComplexQuery3()
        {
            string sqlString = "select Count(lo.LocationID) as totalLocation, LC.CountryName    from Location.tblLocation as LO, Location.tblLocationCountry as LC  where LO.CountryID = LC.CountryID and LC.CountryName = 'United Kingdom'      group by LC.CountryName order by totalLocation;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    PrintLine();
                    PrintRow("total Locations", " Country ");
                    while (reader.Read())
                    {
                        string totalLocation = reader["totalLocation"].ToString();
                        string Country = reader["CountryName"].ToString();
                        PrintLine();
                        PrintRow($"{totalLocation}", $"{Country}");
                        PrintLine();
                    }
                }
            }
        }
        // gets the data from the ComplexQuery4 and returns it as the return of the method
        public void ComplexQuery4()
        {
            string sqlString = "select count(EmployeeID) AS total, Gender   from Employee.tblEmployeesDetails as ED    where gender = 'M'   group by gender order by total; ";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    PrintLine();
                    PrintRow("total", "Gender");
                    while (reader.Read())
                    {
                        int total = Convert.ToInt32(reader["total"]);
                        string Gender = reader["Gender"].ToString();
                        PrintLine();
                        PrintRow($"{total}", $"{Gender}");
                        PrintLine();
                    }
                }
            }
        }
        // gets the data from the ComplexQuery5 and returns it as the return of the method
        public void ComplexQuery5()
        {
            string sqlString = "select distinct count(JobTitleName ) as total, ED.Wage,JT.JobTitleName   from Employee.tblJobTitles as JT, Employee.tblEmployeesDetails as ED where JT.JobTitleID = ED.JobID  and wage >= '90000.00'  Group by ED.Wage, JT.JobTitleName  order by 1,3,2; ";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    PrintLine();
                    PrintRow("total", " wage ", " JobTitleName ");
                    while (reader.Read())
                    {
                        int total = Convert.ToInt32(reader["total"]);
                        int wage = Convert.ToInt32(reader["Wage"]);
                        string JobTitleName = reader["JobTitleName"].ToString();
                        PrintLine();
                        PrintRow($"{total}", $"{wage}", $"{JobTitleName}");
                        PrintLine();
                    }
                }
            }
        }



        //gets the employees id and returns it in the method
        public int getEmployeeID(string Username)
        {
            int EmployeeID = 0;
            string sqlString = "SELECT EmployeeID FROM Employee.tblEmployeesDetails WHERE Username = @Username AND Active = 1";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                cmd.Parameters.AddWithValue("@Username", Username);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                        //Console.WriteLine("Password: " + password);

                    }
                }
            }
            return EmployeeID;
        }


        //gets the employees password and returns it in the method
        public string getPassword(string Username)
        {
            string password = "";
            string sqlString = "SELECT Password FROM Employee.tblEmployeesDetails WHERE Username = @Username AND Active = 1";

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


        //gets the employee roles and returns it in the method
        public int getRole(string Username)
        {
            int Role = 0;
            string sqlString = "SELECT RoleID FROM Employee.tblEmployeesDetails WHERE Username = @Username AND Active = 1";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                cmd.Parameters.AddWithValue("@Username", Username);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Role = Convert.ToInt32(reader["RoleID"]);
                        //Console.WriteLine("Role: " + Role);

                    }
                }
            }
            return Role;
        }



        //gets the data from City and displays it in a list which can be refrenced
        public List<tblCityID> GetTblCityIDs()
        {
            List<tblCityID> city = new List<tblCityID>();
            string sqlString = "SELECT * FROM location.tblLocationCity WHERE Active = 1";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int CityID = Convert.ToInt32(reader["CityID"]);
                        string CityName = reader["CityName"].ToString();
                        bool Active = Convert.ToBoolean(reader["Active"]);
                        city.Add(new tblCityID(CityID, CityName, Active));
                    }
                }
            }
            return city;
        }


        //gets the data from Departments and displays it in a list which can be refrenced
        public List<tblDepartments> GetTblDepartments()
        {
            List<tblDepartments> departments = new List<tblDepartments>();
            string sqlString = "SELECT * FROM Location.tblDepartments WHERE Active = 1";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Departments = reader["DepartmentName"].ToString();
                        int ManagersID = Convert.ToInt32(reader["ManagersID"]);
                        int DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                        bool Active = Convert.ToBoolean(reader["Active"]);
                        departments.Add(new tblDepartments(Departments,ManagersID,DepartmentID, Active));
                    }
                }
            }
            return departments;
        }


        //gets the data from EmployeeDetail and displays it in a list which can be refrenced
        public List<tblEmployeeDetails> GetTblEmployeeDetails() 
        {
            List<tblEmployeeDetails> employeeDetails = new List<tblEmployeeDetails>();
            string sqlString = "SELECT * FROM Employee.tblEmployeesDetails WHERE Active = 1";
            string JobIDStr;
            string PhoneNumberStr;
            string WageStr;
            bool isNullJobID = false;
            bool isNullPhoneNumber = false;
            bool isNullWage = false;
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        JobIDStr = reader["JobID"].ToString();
                        if (JobIDStr.IsNullOrEmpty())
                        {
                            isNullJobID = true;
                        }
                        PhoneNumberStr = reader["Phonenumber"].ToString();
                        if (PhoneNumberStr.IsNullOrEmpty())
                        {
                            isNullPhoneNumber = true;
                        }
                        WageStr = reader["Wage"].ToString();
                        if (WageStr.IsNullOrEmpty())
                        {
                            isNullWage = true;
                        }
                        int EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                        string Firstname = reader["Firstname"].ToString();
                        string Lastname = reader["Lastname"].ToString();
                        DateTime Hiredate = Convert.ToDateTime(reader["HireDate"]);
                        string Gender = reader["Gender"].ToString();
                        int JobID = 0;
                        if (isNullJobID == false)
                        {
                            JobID = Convert.ToInt32(reader["JobID"]);
                        }
                        int RoleID = Convert.ToInt32(reader["RoleID"]);
                        string Username = reader["Username"].ToString();
                        string Password = reader["Password"].ToString();
                        bool Active = Convert.ToBoolean(reader["Active"]);
                        string Email = reader["Email"].ToString();
                        int PhoneNumber = 0;
                        if (isNullPhoneNumber == false)
                        {
                            PhoneNumber = Convert.ToInt32(reader["Phonenumber"]);
                        }
                        int Wage = 0;
                        if (isNullWage == false)
                        {
                            Wage = Convert.ToInt32(reader["Wage"]);
                        }
                        employeeDetails.Add(new tblEmployeeDetails(EmployeeID, Firstname, Lastname, Hiredate, Gender, JobID, RoleID, Username, Password, Active, Email, PhoneNumber, Wage));
                    }
                }
            }
            return employeeDetails;
        }


        //gets the data from RoleNames and displays it in a list which can be refrenced
        public List<tblEmployeeRoleName> GetTblEmployeeRoleNames()
        {
            List<tblEmployeeRoleName> EmployeeRole = new List<tblEmployeeRoleName>();
            string sqlString = "SELECT * FROM Employee.tblEmployeeRoleName WHERE Active = 1";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int RoleID = Convert.ToInt32(reader["RoleID"]);
                        string RoleName = reader["RoleName"].ToString();
                        bool Active = Convert.ToBoolean(reader["Active"]);
                        EmployeeRole.Add(new tblEmployeeRoleName(RoleID, RoleName, Active));
                    }
                    int count = EmployeeRole.Count;
                    Console.WriteLine(count);
                    //get the count then divides it by ten and declares as an float > checks if it is greater than 1> can try using that number as the amt of pages and display it in pages of 10. 
                }
            }
            return EmployeeRole;
        }


        //gets the data from JobTittles and displays it in a list which can be refrenced
        public List<tblJobtitle> GetEmployeeTblJobTittles()
        {
            List<tblJobtitle> jobTittles = new List<tblJobtitle>();
            string sqlString = "SELECT * FROM Employee.tblJobTitles WHERE Active = 1";
            using (SqlCommand cmd = new SqlCommand(sqlString,conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int jobtitleid = Convert.ToInt32(reader["jobtitleID"]);
                        string JobtitleName = reader["JobtitleName"].ToString();
                        bool Active = Convert.ToBoolean(reader["Active"]);
                        jobTittles.Add(new tblJobtitle(jobtitleid, JobtitleName, Active));
                    }
                }
            }
            return jobTittles;
        }


        //gets the data from Locations and displays it in a list which can be refrenced
        public List<tblLocation> GetTblLocations()
        {
            List<tblLocation> locations = new List<tblLocation>();
            string sqlString = "SELECT * FROM Location.tblLocation WHERE Active = 1";
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
                        bool Active = Convert.ToBoolean(reader["Active"]);
                        locations.Add(new tblLocation(LocationID,  LocationName,  CountryID,  SuburbID, StreetID, CityID, StreetNumber, Active));
                    }
                }
            }
            return locations;
        }


        //gets the data from LocationCountries and displays it in a list which can be refrenced
        public List<tblLocationCountry> GetTblLocationCountries()
        {
            List<tblLocationCountry> LocationCountry = new List<tblLocationCountry>();
            string sqlString = "SELECT * From Location.tblLocationCountry WHERE Active = 1";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int CountryID = Convert.ToInt32(reader["CountryID"]);
                        string CountryName = reader["CountryName"].ToString();
                        bool Active = Convert.ToBoolean(reader["Active"]);
                        LocationCountry.Add(new tblLocationCountry(CountryID, CountryName, Active));
                    }
                }
            }
            return LocationCountry;
        }


        //gets the data from Street and displays it in a list which can be refrenced
        public List<tblStreetID> GetTblStreetIDs()
        {
            List<tblStreetID> street = new List<tblStreetID>();
            string sqlString = "SELECT * From Location.tblLocationStreet WHERE Active = 1";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int StreetID = Convert.ToInt32(reader["StreetID"]);
                        string StreetName = reader["StreetName"].ToString();
                        bool Active = Convert.ToBoolean(reader["Active"]);
                        street.Add(new tblStreetID(StreetID, StreetName, Active));
                    }
                }
            }
            return street;
        }


        //gets the data from SubrubID and displays it in a list which can be refrenced
        public List<tblSubrubID> GetTblSubrubIDs()
        {
            List<tblSubrubID> subrub = new List<tblSubrubID>();
            string sqlString = "SELECT * FROM Location.tblLocationSuburb WHERE Active = 1";  
            using (SqlCommand cmd = new SqlCommand(sqlString,conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    /*string[] suburbColumns = new string[reader.FieldCount];
                    for (int col = 0; col < reader.FieldCount; col++)
                    {
                        suburbColumns[col] = reader.GetName(col);
                        Console.WriteLine(suburbColumns[col]);
                    }*/ 

                    while (reader.Read())
                    {
                        int SubrubID = Convert.ToInt32(reader["SuburbID"]);
                        string SuburbName = reader["Suburb"].ToString();
                        int Postcode = Convert.ToInt32(reader["PostCode"]);
                        bool Active = Convert.ToBoolean(reader["Active"]);
                        subrub.Add(new tblSubrubID(SubrubID,SuburbName,Postcode,Active));
                    }
                }
            }
            return subrub;
        }



        //updates the RoleName table in the database
        public string UpdateRoleName(string RoleName,string RoleNameChange)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Employee.tblEmployeeRoleName SET RoleName = @RoleNameChange Where RoleName = @RoleName", conn))
            {
                cmd.Parameters.AddWithValue("@RoleName", RoleName);
                cmd.Parameters.AddWithValue("@RoleNameChange", RoleNameChange);
                return cmd.ExecuteNonQuery().ToString();
            }
        }


        //updates the JobTitl table in the database
        public string UpdateJobTitle(string JobTitle, string JobTitleChange)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Employee.tblJobTitles SET JobTitleName = @JobTitleChange Where JobTitle = @JobTitle", conn))
            {
                cmd.Parameters.AddWithValue("@JobTitle", JobTitle);
                cmd.Parameters.AddWithValue("@JobTitleChange", JobTitleChange);
                return cmd.ExecuteNonQuery().ToString();
            }
        }


        //updates the LocationCountry table in the database
        public string UpdateLocationCountry(string CountryName, string CountryNameChange)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.tblLocationCountry SET CountryName = @CountryName Where CountryName = @CountryName", conn))
            {
                cmd.Parameters.AddWithValue("@CountryName", CountryName);
                cmd.Parameters.AddWithValue("@CountryNameChange", CountryNameChange);
                return cmd.ExecuteNonQuery().ToString();
            }
        }


        //updates the LocationStreet table in the database
        public string UpdateLocationStreet(string StreetName, string StreetNameChange)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.tblLocationStreet SET StreetName = @StreetName Where StreetName = @StreetName", conn))
            {
                cmd.Parameters.AddWithValue("@StreetName", StreetName);
                cmd.Parameters.AddWithValue("@StreetNameChange", StreetNameChange);
                return cmd.ExecuteNonQuery().ToString();
            }
        }


        //updates the LocationCity table in the database
        public string UpdateLocationCity(string CityName, string CityNameChange)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.tblLocationStreet SET CityName = @CityName Where CityName = @CityName", conn))
            {
                cmd.Parameters.AddWithValue("@CityName", CityName);
                cmd.Parameters.AddWithValue("@CityNameChange", CityNameChange);
                return cmd.ExecuteNonQuery().ToString();
            }
        }


        //updates the EmployeeDetails table in the database
        public string UpdateEmployeeDetails(string fieldChoice, int EmployeeID, string Change)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Employee.tblEmployeesDetails SET @fieldChoice = @Change Where EmployeeID = @EmployeeID", conn))
            {
                cmd.Parameters.AddWithValue("@fieldChoice", fieldChoice);
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                cmd.Parameters.AddWithValue("@Change", Change);
                return cmd.ExecuteNonQuery().ToString();
            }
        }

        public string UpdateEmpEmployeeDetails(string fieldChoice, int EmployeeID, string Change)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Employee.tblEmployeesDetails SET @fieldChoice = @Change Where EmployeeID = @EmployeeID", conn))
            {
                cmd.Parameters.AddWithValue("@fieldChoice", fieldChoice);
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                cmd.Parameters.AddWithValue("@Change", Change);
                return cmd.ExecuteNonQuery().ToString();
            }
        }


        //updates the Location table in the database
        public string UpdateLocation(string fieldChoice, int LocationID, string Change)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.tblLocation SET @fieldChoice = @Change Where LocationID = @LocationID", conn))
            {
                cmd.Parameters.AddWithValue("@fieldChoice", fieldChoice);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@Change", Change);
                return cmd.ExecuteNonQuery().ToString();
            }
        }


        //updates the subrub table in the database
        public string Updatesubrub(string fieldChoice, int LocationID, string Change)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.tblLocationSubrub SET @fieldChoice = @Change Where LocationID = @LocationID", conn))
            {
                cmd.Parameters.AddWithValue("@fieldChoice", fieldChoice);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@Change", Change);
                return cmd.ExecuteNonQuery().ToString();
            }
        }


        //updates the Department table in the database
        public string UpdateDept(string fieldChoice, int LocationID, string Change)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.tblDepartments SET @fieldChoice = @Change Where LocationID = @LocationID", conn))
            {
                cmd.Parameters.AddWithValue("@fieldChoice", fieldChoice);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@Change", Change);
                return cmd.ExecuteNonQuery().ToString();
            }
        }



        //Deletes a City in the database
        public int DeleteCity(int CityID)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.tblLocationCity SET Active = 0 WHERE CityID = @CityID", conn))
            {
                cmd.Parameters.AddWithValue("@CityID", CityID);
                return cmd.ExecuteNonQuery();
            }
        }


        //Deletes a Department in the database
        public int DeleteDepartment(int DepartmentID)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.tblDepartments SET Active = 0 WHERE DepartmentID = @DepartmentID", conn))
            {
                cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                return cmd.ExecuteNonQuery();
            }
        }


        //Deletes a EmployeeDetails in the database
        public int DeleteEmployeeDetails(int EmployeeID)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Employee.tblEmployeesDetails SET Active = 0 WHERE EmployeeID  = @EmployeeID ", conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeID ", EmployeeID);
                return cmd.ExecuteNonQuery();
            }
        }


        //Deletes a RoleName in the database
        public int DeleteRoleName(int RoleID)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Employee.tblEmployeeRoleName SET Active = 0 WHERE RoleID  = @RoleID ", conn))
            {
                cmd.Parameters.AddWithValue("@RoleID ", RoleID);
                return cmd.ExecuteNonQuery();
            }
        }


        //Deletes a Jobtitle in the database
        public int DeleteJobtitle(int JobTitleID)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Employee.tblJobTitles SET Active = 0 WHERE JobTitleID  = @JobTitleID ", conn))
            {
                cmd.Parameters.AddWithValue("@JobTitleID ", JobTitleID);
                return cmd.ExecuteNonQuery();
            }
        }


        //Deletes a Street in the database
        public int DeleteStreet(int StreetID)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.tblLocationStreet SET Active = 0 WHERE StreetID  = @JobTitlStreetIDeID ", conn))
            {
                cmd.Parameters.AddWithValue("@StreetID ", StreetID);
                return cmd.ExecuteNonQuery();
            }
        }


        //Deletes a Suburb in the database
        public int DeleteSuburb(int SuburbID)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.tblLocationSuburb SET Active = 0 WHERE SuburbID  = @SuburbID ", conn))
            {
                cmd.Parameters.AddWithValue("@SuburbID ", SuburbID);
                return cmd.ExecuteNonQuery();
            }
        }


        //Deletes a Country in the database
        public int DeleteCountry(int CountryID)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.tblLocationCountry SET Active = 0 WHERE CountryID  = @CountryID ", conn))
            {
                cmd.Parameters.AddWithValue("@CountryID ", CountryID);
                return cmd.ExecuteNonQuery();
            }
        }


        //Deletes a Location in the database
        public int DeleteLocation(int LocationID)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.tblLocation SET Active = 0 WHERE LocationID  = @LocationID ", conn))
            {
                cmd.Parameters.AddWithValue("@LocationID ", LocationID);
                return cmd.ExecuteNonQuery();
            }
        }







        //creates a new Location in the database
        public int InsertLocation(string LocationName, int CountryID, int SuburbID, int StreetID, int CityID, int StreetNumber)
        {
            bool Active = true;
            using (SqlCommand cmd = new SqlCommand($"INSERT INTO Location.tblLocation (locationName, CountryID, SuburbID, StreetID, CityID, StreetNumber, Active) VALUES (@LocationName ,@CountryID  @SuburbID ,@StreetID ,@CityID ,@StreetNumber ); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@LocationName ", LocationName);
                cmd.Parameters.AddWithValue("@CountryID  ", CountryID);
                cmd.Parameters.AddWithValue("@SuburbID", SuburbID); 
                cmd.Parameters.AddWithValue("@StreetID ", StreetID);
                cmd.Parameters.AddWithValue("@CityID  ", CityID);
                cmd.Parameters.AddWithValue("@StreetNumber", StreetNumber);
                cmd.Parameters.AddWithValue("@Active", Active);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        //creates a new EmployeeDetails in the database
        public int InsertEmployeeDetails(string FirstName, string LastName, DateTime HireDate, string Gender, int JobID, int RoleID, string Username, string Password, string Email, int PhoneNumber, int Wage)
        {
            bool Active = true;
            using (SqlCommand cmd = new SqlCommand($"INSERT INTO Employee.tblEmployeesDetails (FirstName, LastName, Hiredate, Gender, JobID, Username, Password, RoleID, Active, Email, Phonenumber, Wage) VALUES (@FirstName, @LastName, @HireDate, @Gender, @JobID, @Username, @Password, @RoleID, @Active, @Email, @Phonenumber, @Wage); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@FirstName  ", FirstName);
                cmd.Parameters.AddWithValue("@LastName   ", LastName);
                cmd.Parameters.AddWithValue("@HireDate ", HireDate); 
                cmd.Parameters.AddWithValue("@Gender  ", Gender);
                cmd.Parameters.AddWithValue("@JobID   ", JobID);
                cmd.Parameters.AddWithValue("@Username ", Username); 
                cmd.Parameters.AddWithValue("@Password  ", Password);
                cmd.Parameters.AddWithValue("@RoleID   ", RoleID);
                cmd.Parameters.AddWithValue("@Active", Active);
                cmd.Parameters.AddWithValue("@Email  ", Email);
                cmd.Parameters.AddWithValue("@PhoneNumber   ", PhoneNumber);
                cmd.Parameters.AddWithValue("@Active", Active);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        //creates a new RoleName in the database
        public int InsertRoleName(string RoleName)
        {
            bool Active = true;
            using (SqlCommand cmd = new SqlCommand($"INSERT INTO  Location.tblEmployeeRoleName (RoleName ,Active ) VALUES (@RoleName ,@Active); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@RoleName ", RoleName);
                cmd.Parameters.AddWithValue("@Active", Active);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        //creates a new Jobtitle in the database
        public int InsertJobtitle(string JobTitleName)
        {
            bool Active = true;
            using (SqlCommand cmd = new SqlCommand($"INSERT INTO  Employee.tblJobTitles  (JobTitleName ,Active ) VALUES (@JobTitleName,@Active); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@JobTitleName  ", JobTitleName);
                cmd.Parameters.AddWithValue("@Active", Active);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        //creates a new Department in the database
        public int InsertDepartment(string DepartmentName, int ManagersID)
        {
            bool Active = true;
            using (SqlCommand cmd = new SqlCommand($"INSERT INTO  Location.tblDepartments  (DepartmentName ,Active ) VALUES (@RoleName ,@Active); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@DepartmentName ", DepartmentName);
                cmd.Parameters.AddWithValue("@ManagersID  ", ManagersID);
                cmd.Parameters.AddWithValue("@Active", Active);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        //creates a new City in the database
        public int InsertCity(string CityName)
        {
            bool Active = true;
            using (SqlCommand cmd = new SqlCommand($"INSERT INTO  Location.tblLocationCity  (CityName,Active ) VALUES (@CityName,@Active); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@CityName", CityName);
                cmd.Parameters.AddWithValue("@Active", Active);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        //creates a new Street in the database
        public int InsertStreet(string StreetName)
        {
            bool Active = true;
            using (SqlCommand cmd = new SqlCommand($"INSERT INTO  Location.tblLocationStreet (StreetName,Active ) VALUES (@StreetName,@Active); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@StreetName", StreetName);
                cmd.Parameters.AddWithValue("@Active", Active);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        //creates a new Suburb in the database
        public int InsertSuburb(string Suburb, int PostCode)
        {
            bool Active = true;
            using (SqlCommand cmd = new SqlCommand($"INSERT INTO  Location.tblLocationSuburb  (Suburb ,Active ,PostCode ) VALUES (@StreetName,@Active),(@PostCode); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@Suburb", Suburb);
                cmd.Parameters.AddWithValue("@Active", Active);
                cmd.Parameters.AddWithValue("@PostCode", PostCode);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        //creates a new country in the database
        public int InsertCountry(string CountryName)
        {
            bool Active = true;
            using (SqlCommand cmd = new SqlCommand($"INSERT INTO  Location.tblLocationCountry (CountryName ,Active ) VALUES (@CountryName ,@Active); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@CountryName ", CountryName);
                cmd.Parameters.AddWithValue("@Active", Active);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int RegisterEmployee(string username,string password)
        {
            bool Active = true;
            int Role = 1;
            DateTime date = DateTime.Now;
            using (SqlCommand cmd = new SqlCommand($"INSERT INTO  Employee.tblEmployeesDetails(Username ,Password, RoleID ,Active ,HireDate ) VALUES (@Username ,@Password ,@Active , @RoleID,@HireDate); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@Username ", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Active", Active);
                cmd.Parameters.AddWithValue("@RoleID", Role);
                cmd.Parameters.AddWithValue("@HireDate", date);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        //closes the connection if it is still open
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
