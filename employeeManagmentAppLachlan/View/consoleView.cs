using Azure;
using employeeManagmentAppLachlan.Model;
using employeeManagmentAppLachlan.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.View
{
    public class consoleView
    {
        private static StorageManager storageManager;
        static int tableWidth = 232;
        public void MainMenu()
        {
            Console.WriteLine("Welcome to the Employee Managment Menu");
            Console.WriteLine("Choose an option from 1-2");
            Console.WriteLine("1: Log In");
            Console.WriteLine("2. Register");
        }


        // displays the admin menu  
        public void TblDisplayMenu()
        {
            Console.WriteLine("Choose an option from 1-9");
            Console.WriteLine("View the tables:");
            Console.WriteLine("1: Employees Details ");
            Console.WriteLine("2: Employee Locations ");
            Console.WriteLine("3: Role Name ");
            Console.WriteLine("4: Departments ");
            Console.WriteLine("5: Job Titles ");
            Console.WriteLine("6: Country ");
            Console.WriteLine("7: Street ");
            Console.WriteLine("8: Suburb");
            Console.WriteLine("9: City ");
        }

        public void DisplayQryOrUpdate()
        {
            Console.WriteLine("What do you wish to do");
            Console.WriteLine("Please choose an option from 1-2");
            Console.WriteLine("1: Querys");
            Console.WriteLine("Note that to view all the data from a table you must go to edit the data");
            Console.WriteLine("2: Edit The Data");
            Console.WriteLine("3: Search the Database for a specific field");
        }

        public void DisplayQryOptions()
        {
            Console.WriteLine("What Query do you wish to View");
            Console.WriteLine("Please choose an option from 1-10");
            Console.WriteLine("1: Advanced Query 1");
            Console.WriteLine("2: Advanced Query 2");
            Console.WriteLine("3: Advanced Query 3");
            Console.WriteLine("4: Advanced Query 4");
            Console.WriteLine("5: Advanced Query 5");
            Console.WriteLine("6: Complex Query 1");
            Console.WriteLine("7: Complex Query 2");
            Console.WriteLine("8: Complex Query 3");
            Console.WriteLine("9: Complex Query 4");
            Console.WriteLine("10: Complex Query 5");
        }

        // displays the employee text  
        public void EmployeeDisplayMenu()
        {
            Console.WriteLine("Welcome to the Employee Menu");
            Console.WriteLine("Please choose an option from 1-3");
            Console.WriteLine("1: View Your Infomation");
            Console.WriteLine("2: Update your Infomatin");
            Console.WriteLine("3: Return to main Menu");
        }

        public void EmpDisplayMenu()
        {
            Console.WriteLine("Welcome to the Employee Menu");
            Console.WriteLine("Please choose an option from 1-2");
            Console.WriteLine("1: View Your Infomation");
            Console.WriteLine("2: Update your Infomatin");
        }

        //displays the options for the fields you can update in the table employee details 
        public void DisplayUpdateEmployeeDetails()
        {
            Console.Clear();
            Console.WriteLine("What Feild do you wish to update");
            Console.WriteLine("Choose an option from 1-5");
            Console.WriteLine("1: First Name");
            Console.WriteLine("2: Last Name");
            Console.WriteLine("3: Gender");
            Console.WriteLine("4: Email");
            Console.WriteLine("5: Phonenumber");
        }

        //displays the options for the fields you can update in the table location
        public void DisplayUpdateLocation()
        {
            Console.WriteLine("What Feild do you wish to update");
            Console.WriteLine("Choose an option from 1-6");
            Console.WriteLine("1: Location Name");
            Console.WriteLine("2: City ID");
            Console.WriteLine("3: Suburb ID");
            Console.WriteLine("4: Street ID");
            Console.WriteLine("5: Country ID");
            Console.WriteLine("6: Street Number");
        }

        //displays the options for the fields you can update in the table subrub
        public void DisplayUpdatesubrub()
        {
            Console.WriteLine("What Feild do you wish to update");
            Console.WriteLine("Choose an option from 1-2");
            Console.WriteLine("1: subrub Name");
            Console.WriteLine("2: Post Code");
        }

        //displays the options for the fields you can update in the table department
        public void DisplayUpdateDept()
        {
            Console.WriteLine("What Feild do you wish to update");
            Console.WriteLine("Choose an option from 1-2");
            Console.WriteLine("1: Department Name");
            Console.WriteLine("2: Managers ID");
        }



        //displays all the option for the admins in the table EmployeeLocations
        public void tblEmployeeLocations()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Locations");
            Console.WriteLine("Choose an option from 1-5");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in Locations.TblLocations");
            Console.WriteLine("2: Update an employee's location by employeeID");
            Console.WriteLine("3: Delete a Location by job title name");
            Console.WriteLine("4: Insert a new Location ");
            Console.WriteLine("5: Return to the Main Menu");
        }

        //displays all the option for the admins in the table EmployeesDetails
        public void tblEmployeesDetails()
        {
            Console.Clear();
            Console.WriteLine("Welcome to EmployeesDetails");
            Console.WriteLine("Choose an option from 1-5");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in Employee.tblEmployeesDetails");
            Console.WriteLine("2: Update an employee's details by employeeID");
            Console.WriteLine("3: Delete an Employee by Employee ID");
            Console.WriteLine("4: Insert an new Employee ");
            Console.WriteLine("5: Return to the Main Menu");
        }

        //displays all the option for the admins in the table JobTittles
        public void tblJobTittles()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tblJobTitles");
            Console.WriteLine("Choose an option from 1-5");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in Employee.tblJobTittles");
            Console.WriteLine("2: Update a job title by jobtitleID");
            Console.WriteLine("3: Delete a job title by job title name");
            Console.WriteLine("4: Insert a new job title ");
            Console.WriteLine("5: Return to the Main Menu");
        }

        //displays all the option for the admins in the table Departments
        public void tblDepartments()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tblDepartments");
            Console.WriteLine("Choose an option from 1-5");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in Location.tblDepartments");
            Console.WriteLine("2: Update a Departments by DepartmentsID");
            Console.WriteLine("3: Delete a Departments by Departments name");
            Console.WriteLine("4: Insert a new Departments ");
            Console.WriteLine("5: Return to the Main Menu");
        }

        //displays all the option for the admins in the table RoleName
        public void tblRoleName()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tbl Role Name");
            Console.WriteLine("Choose an option from 1-5");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tbl Role Name");
            Console.WriteLine("2: Update a Role by RoleID");
            Console.WriteLine("3: Delete a Role by Rolename");
            Console.WriteLine("4: Insert a new Role ");
            Console.WriteLine("5: Return to the Main Menu");
        }

        //displays all the option for the admins in the table Country
        public void tblLocationCountry()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tbl Location Country");
            Console.WriteLine("Choose an option from 1-5");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tbl Location Country");
            Console.WriteLine("2: Update a country by countryID");
            Console.WriteLine("3: Delete a Country by Country name");
            Console.WriteLine("4: Insert a new Country");
            Console.WriteLine("5: Return to the Main Menu");
        }

        //displays all the option for the admins in the table Street
        public void tblStreet()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tbl Street ");
            Console.WriteLine("Choose an option from 1-5");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tbl Street");
            Console.WriteLine("2: Update a Street by StreetID");
            Console.WriteLine("3: Delete a Street by Street ID");
            Console.WriteLine("4: Insert a new Street");
            Console.WriteLine("5: Return to the Main Menu");
        }

        //displays all the option for the admins in the table Suburb
        public void tblSuburb()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tbl Suburb ");
            Console.WriteLine("Choose an option from 1-5");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tbl Suburb");
            Console.WriteLine("2: Update a Suburb by SuburbID");
            Console.WriteLine("3: Delete a Suburb by Suburb ID");
            Console.WriteLine("4: Insert a new Suburb");
            Console.WriteLine("5: Return to the Main Menu");
        }

        //displays all the option for the admins in the table City
        public void tblCity()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tbl City ");
            Console.WriteLine("Choose an option from 1-5");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tbl City");
            Console.WriteLine("2: Update a City by CityID");
            Console.WriteLine("3: Delete a new City by City Name");
            Console.WriteLine("4: Insert a new City");
            Console.WriteLine("5: Return to the Main Menu");
        }

        public void DisplayTables()
        {
            Console.WriteLine("Which table do you wish to use");
            Console.WriteLine("Choose a table from 1-9");
            Console.WriteLine("1. Table Employee Details ");
            Console.WriteLine("2. Table Location ");
            Console.WriteLine("3. Table Role Names ");
            Console.WriteLine("4. Table Departments ");
            Console.WriteLine("5. Table Job Titles ");
            Console.WriteLine("6. Table Citys ");
            Console.WriteLine("7. Table Country ");
            Console.WriteLine("8. Table Streets ");
            Console.WriteLine("9. Table Suburbs ");           
        }

        public void DisplayEmployeeDetailsFields()
        {
            Console.WriteLine("Which Fields do you wish to use");
            Console.WriteLine("Choose a Field from 1-9");
            Console.WriteLine("1. Employee ID Field");
            Console.WriteLine("2. First Name Field");
            Console.WriteLine("3. Last Name Field");
            Console.WriteLine("4. Hire Date Field");
            Console.WriteLine("5. Job ID Field");
            Console.WriteLine("6. Role ID Field");
            Console.WriteLine("7. Email Field");
            Console.WriteLine("8. Phone Number Field");
            Console.WriteLine("9. Wage Field");
        }

        public void DisplayLocationFields()
        {
            Console.WriteLine("Which Fields do you wish to use");
            Console.WriteLine("Choose a Field from 1-7");
            Console.WriteLine("1. Location ID Field");
            Console.WriteLine("2. Location Name Field");
            Console.WriteLine("3. Country ID Field");
            Console.WriteLine("4. Suburb ID Field");
            Console.WriteLine("5. Street ID Field");
            Console.WriteLine("6. City ID Field");
            Console.WriteLine("7. Street Number Field");

            /*
            LocationID 
            LocationName 
            CountryID 
            SuburbID 
            StreetID 
            CityID 
            StreetNumber 
            */
        }

        public void DisplayRoleNamesFields()
        {
            Console.WriteLine("Which Fields do you wish to use");
            Console.WriteLine("Choose a Field from 1-2");
            Console.WriteLine("1. Role ID Field");
            Console.WriteLine("2. Role Name Field");
        }

        public void DisplayDepartmentsFields()
        {
            Console.WriteLine("Which Fields do you wish to use");
            Console.WriteLine("Choose a Field from 1-3");
            Console.WriteLine("1. Department ID Field");
            Console.WriteLine("2. Department Name Field");
            Console.WriteLine("3. Managers ID Field");
        }

        public void DisplayJobTitlesFields()
        {
            Console.WriteLine("Which Fields do you wish to use");
            Console.WriteLine("Choose a Field from 1-2");
            Console.WriteLine("1. Job Title ID Field");
            Console.WriteLine("2. Job Title Name Field");
        }

        public void DisplayCitysFields()
        {
            Console.WriteLine("Which Fields do you wish to use");
            Console.WriteLine("Choose a Field from 1-2");
            Console.WriteLine("1. City ID Field");
            Console.WriteLine("2. City Name Field");
        }

        public void DisplayCountryFields()
        {
            Console.WriteLine("Which Fields do you wish to use");
            Console.WriteLine("Choose a Field from 1-2");
            Console.WriteLine("1. Country ID Field");
            Console.WriteLine("2. Country Name Field");
        }

        public void DisplayStreetsFields()
        {
            Console.WriteLine("Which Fields do you wish to use");
            Console.WriteLine("Choose a Field from 1-2");
            Console.WriteLine("1. Street ID Field");
            Console.WriteLine("2. Street Name Field");      
        }

        public void DisplaySuburbsFields()
        {
            Console.WriteLine("Which Fields do you wish to use");
            Console.WriteLine("Choose a Field from 1-3");
            Console.WriteLine("1. Suburb ID Field");
            Console.WriteLine("2. Suburb Name Field");
            Console.WriteLine("3. Post Code Field");
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



        //displays the employees data
        public void DisplayEmpEmployeeDetailsPage(List<tblEmployeeDetails> details, int EmployeeID)
        {
            int loopnum = 0;
            bool loop = true;
            int pageNum = 1;
            decimal totalPagesDecimal = details.Count / 10;
            Math.Truncate(totalPagesDecimal);
            int totalPagesNum = Convert.ToInt32(totalPagesDecimal) + 1;
            Console.Clear();
            PrintLine();
            PrintRow("employee ID ", " first Name", " last Name", " Hire Date ", " gender ", " job ID ", "role ", "active", "  email", " phone number ", " Location wage");
            PrintLine();
            if (loop = true)
            {
                foreach (tblEmployeeDetails detail in details)
                {
                    if (detail.employeeID == EmployeeID)
                    {
                        PrintLine();
                        PrintRow($"{detail.employeeID}", $"{detail.firstname}", $"{detail.lastname}", $"{detail.hireDate}", $"{detail.gender}", $"{detail.jobID}", $"{detail.roleID}", $"{detail.active}", $"{detail.email}", $"{detail.phonenumber}", $"{detail.wage}");
                        PrintLine();
                        //Console.WriteLine($"{"Location ID: " + location.Location_ID}\t{"Location Name: " + location.Location_Name}");
                        loopnum++;
                        Console.WriteLine(loopnum);
                        if (loopnum == 10)
                        {
                            Console.WriteLine("do you wish to go to the next page Y/N");
                            Console.WriteLine("You are on page " + pageNum + " Of " + totalPagesNum);
                            string input = GetInput();
                            if (input.Equals("Y"))
                            {
                                loop = true;
                                loopnum = 0;
                                pageNum++;
                            }
                            else
                            {
                                loop = false;
                            }
                        }                   
                    }
                }
            }
        }



        //displays the data for the table City
        public void DisplayCity(List<tblCityID> CityID)
        {

            PrintLine();
            PrintRow("City ID ", " City Name", "Active");
            PrintLine();
            /* Console.Clear();
            PrintLine();
            PrintRow("Column 1", "Column 2", "Column 3", "Column 4");
             PrintLine();
            PrintRow("test", "test", "test", "test");
            PrintRow("test", "test", "test", "test");
            PrintLine();
             Console.ReadLine(); */
            foreach (tblCityID City in CityID)
            {

                //Console.WriteLine($"{"Employee ID: " + employee.employeeid}\t\t{"Email: " + employee.email}\t\t{"Phone Number: " + employee.phonenumber}");
                //Console.WriteLine($"{ employee.employeeid}\t\t{ + employee.email}\t\t{ + employee.phonenumber}");
                PrintLine();
                PrintRow($"{City.cityID}", $"{City.cityName}", $"{City.active}");
                PrintLine();
            }
        }

        public void DisplayCityPages(List<tblCityID> CityID)
        {
            int loopnum = 0;
            bool loop = true;
            int pageNum = 1;
            decimal totalPagesDecimal = CityID.Count / 10;
            Math.Truncate(totalPagesDecimal);
            int totalPagesNum = Convert.ToInt32(totalPagesDecimal) + 1;
            PrintLine();
            PrintRow("City ID ", " City Name", "Active");
            PrintLine();
            if (loop = true)
            {
                foreach (tblCityID City in CityID)
                {
                    PrintLine();
                    PrintRow($"{City.cityID}", $"{City.cityName}", $"{City.active}");
                    PrintLine();
                    //Console.WriteLine($"{"Location ID: " + location.Location_ID}\t{"Location Name: " + location.Location_Name}");
                    loopnum++;
                    Console.WriteLine(loopnum);
                    if (loopnum == 10)
                    {
                        Console.WriteLine("do you wish to go to the next page Y/N");
                        Console.WriteLine("You are on page " + pageNum + " Of " + totalPagesNum);
                        string input = GetInput();
                        if (input.Equals("Y"))
                        {
                            loop = true;
                            loopnum = 0;
                            pageNum++;
                        }
                        else
                        {
                            loop = false;
                        }
                    }
                }
            }
        }



        //displays the data for the table Street
        public void DisplayStreetID(List<tblStreetID> streetID)
        {
            PrintLine();
            PrintRow(" Street ID ", " Street Name", " Active");
            PrintLine();
            foreach (tblStreetID street in streetID)
            {
                PrintLine();
                PrintRow($"{street.streetID}", $"{street.streetName}", $"{street.active}");
                PrintLine();
            }
        }

        public void DisplayStreetIDPages(List<tblStreetID> streetID)
        {
            int loopnum = 0;
            bool loop = true;
            int pageNum = 1;
            decimal totalPagesDecimal = streetID.Count / 10;
            Math.Truncate(totalPagesDecimal);
            int totalPagesNum = Convert.ToInt32(totalPagesDecimal) + 1;
            PrintLine();
            PrintRow(" Street ID ", " Street Name", " Active");
            PrintLine();
            if (loop = true)
            {
                foreach (tblStreetID street in streetID)
                {
                    PrintLine();
                    PrintRow($"{street.streetID}", $"{street.streetName}", $"{street.active}");
                    PrintLine();
                    loopnum++;
                    Console.WriteLine(loopnum);
                    if (loopnum == 10)
                    {
                        Console.WriteLine("do you wish to go to the next page Y/N");
                        Console.WriteLine("You are on page " + pageNum + " Of " + totalPagesNum);
                        string input = GetInput();
                        if (input.Equals("Y"))
                        {
                            loop = true;
                            loopnum = 0;
                            pageNum++;
                        }
                        else
                        {
                            loop = false;
                        }
                    }
                }
            }
        }



        //displays the data for the table Subrub
        public void DisplaySubrub(List<tblSubrubID> subrubID)
        {
            PrintLine();
            PrintRow(" suburb ID ", " subrub Name", " post code", " Active");
            PrintLine();
            foreach (tblSubrubID subrub in subrubID)
            {
                PrintLine();
                PrintRow($"{subrub.suburbID}", $"{subrub.suburbName}", $"{subrub.postcode}", $"{subrub.active}");
                PrintLine();

            }
        }

        public void DisplaySubrubPages(List<tblSubrubID> subrubID)
        {
            int loopnum = 0;
            bool loop = true;
            int pageNum = 1;
            decimal totalPagesDecimal = subrubID.Count / 10;
            Math.Truncate(totalPagesDecimal);
            int totalPagesNum = Convert.ToInt32(totalPagesDecimal) + 1;
            PrintLine();
            PrintRow(" suburb ID ", " subrub Name", " post code", " Active");
            PrintLine();
            if (loop = true)
            {
                foreach (tblSubrubID subrub in subrubID)
                {
                    PrintLine();
                    PrintRow($"{subrub.suburbID}", $"{subrub.suburbName}", $"{subrub.postcode}", $"{subrub.active}");
                    PrintLine();
                    //Console.WriteLine($"{"Location ID: " + location.Location_ID}\t{"Location Name: " + location.Location_Name}");
                    loopnum++;
                    Console.WriteLine(loopnum);
                    if (loopnum == 10)
                    {
                        Console.WriteLine("do you wish to go to the next page Y/N");
                        Console.WriteLine("You are on page " + pageNum + " Of " + totalPagesNum);
                        string input = GetInput();
                        if (input.Equals("Y"))
                        {
                            loop = true;
                            loopnum = 0;
                            pageNum++;
                        }
                        else
                        {
                            loop = false;
                        }
                    }
                }
            }
        }



        //displays the data for the table Country
        public void DisplayCountry(List<tblLocationCountry> countryID)
        {
            PrintLine();
            PrintRow("Country ID ", " Country Name", " Active");
            PrintLine();
            foreach (tblLocationCountry country in countryID)
            {
                PrintLine();
                PrintRow($"{country.countryId}", $"{country.countryName}", $"{country.active}");
                PrintLine();
            }
        }

        public void DisplayCountryPages(List<tblLocationCountry> countryID)
        {
            int loopnum = 0;
            bool loop = true;
            int pageNum = 1;
            decimal totalPagesDecimal = countryID.Count / 10;
            Math.Truncate(totalPagesDecimal);
            int totalPagesNum = Convert.ToInt32(totalPagesDecimal) + 1;
            PrintLine();
            PrintRow("Country ID ", " Country Name", " Active");
            PrintLine();
            if (loop = true)
            {
                foreach (tblLocationCountry country in countryID)
                {
                    PrintLine();
                    PrintRow($"{country.countryId}", $"{country.countryName}", $"{country.active}");
                    PrintLine();
                    loopnum++;
                    Console.WriteLine(loopnum);
                    if (loopnum == 10)
                    {
                        Console.WriteLine("do you wish to go to the next page Y/N");
                        Console.WriteLine("You are on page " + pageNum + " Of " + totalPagesNum);
                        string input = GetInput();
                        if (input.Equals("Y"))
                        {
                            loop = true;
                            loopnum = 0;
                            pageNum++;
                        }
                        else
                        {
                            loop = false;
                        }
                    }
                }
            }
        }



        //displays the data for the table Location
        public void DisplayLocation(List<tblLocation> locations)
        {
            PrintLine();
            PrintRow("Location ID ", " Location Name", " CountryID", " SuburbID", " StreetID", " CityID", " StreetNumber", " Active");
            PrintLine();
            foreach (tblLocation location in locations)
            {
                PrintLine();
                PrintRow($"{location.locationID}", $"{location.locationName}", $"{location.countryID}", $"{location.suburbID}", $"{location.streetID}", $"{location.cityID}", $"{location.streetNumber}", $"{location.active}");
                PrintLine();
            }
        }

        public void DisplayLocationPages(List<tblLocation> locations)
        {
            int loopnum = 0;
            bool loop = true;
            int pageNum = 1;
            decimal totalPagesDecimal = locations.Count / 10;
            Math.Truncate(totalPagesDecimal);
            int totalPagesNum = Convert.ToInt32(totalPagesDecimal) + 1;
            PrintLine();
            PrintRow("Location ID ", " Location Name", " CountryID", " SuburbID", " StreetID", " CityID", " StreetNumber", " Active");
            PrintLine();
            if (loop = true)
            {
                foreach (tblLocation location in locations)
                {
                    PrintLine();
                    PrintRow($"{location.locationID}", $"{location.locationName}", $"{location.countryID}", $"{location.suburbID}", $"{location.streetID}", $"{location.cityID}", $"{location.streetNumber}", $"{location.active}");
                    PrintLine();
                    //Console.WriteLine($"{"Location ID: " + location.Location_ID}\t{"Location Name: " + location.Location_Name}");
                    loopnum++;
                    Console.WriteLine(loopnum);
                    if (loopnum == 10)
                    {
                        Console.WriteLine("do you wish to go to the next page Y/N");
                        Console.WriteLine("You are on page " + pageNum + " Of " + totalPagesNum);
                        string input = GetInput();
                        if (input.Equals("Y"))
                        {
                            loop = true;
                            loopnum = 0;
                            pageNum++;
                        }
                        else
                        {
                            loop = false;
                        }
                    }
                }
            }
        }


        //displays the data for the table JobTittles
        public void DisplaytblJobTittles(List<tblJobtitle> jobtitles)
        {
            PrintLine();
            PrintRow("jobtitle ID ", " jobtitlename", "Active ");
            PrintLine();
            foreach (tblJobtitle jobTittle in jobtitles)
            {
                PrintLine();
                PrintRow($"{jobTittle.jobtitleID}", $"{jobTittle.jobtitleName}", $"{jobTittle.active}");
                PrintLine();
                // Console.WriteLine($"{"Job title ID: " + jobTittle.jobtitleid}\t{"Job title Name: " + jobTittle.jobtitlename}");
            }
        }

        public void DisplaytblJobTittlesPages(List<tblJobtitle> jobtitles)
        {
            int loopnum = 0;
            bool loop = true;
            int pageNum = 1;
            decimal totalPagesDecimal = jobtitles.Count / 10;
            Math.Truncate(totalPagesDecimal);
            int totalPagesNum = Convert.ToInt32(totalPagesDecimal) + 1;
            PrintLine();
            PrintRow("jobtitle ID ", " jobtitlename", "Active ");
            PrintLine();
            if (loop = true)
            {
                foreach (tblJobtitle jobTittle in jobtitles)
                {
                    PrintLine();
                    PrintRow($"{jobTittle.jobtitleID}", $"{jobTittle.jobtitleName}", $"{jobTittle.active}");
                    PrintLine();
                    //Console.WriteLine($"{"Location ID: " + location.Location_ID}\t{"Location Name: " + location.Location_Name}");
                    loopnum++;
                    Console.WriteLine(loopnum);
                    if (loopnum == 10)
                    {
                        Console.WriteLine("do you wish to go to the next page Y/N");
                        Console.WriteLine("You are on page " + pageNum + " Of " + totalPagesNum);
                        string input = GetInput();
                        if (input.Equals("Y"))
                        {
                            loop = true;
                            loopnum = 0;
                            pageNum++;
                        }
                        else
                        {
                            loop = false;
                        }
                    }
                }
            }
        }

        //displays the data for the table RoleNames
        public void DisplayRoleNames(List<tblEmployeeRoleName> Roles)
        {
            PrintLine();
            PrintRow("Role ID ", " Role Name", " Active");
            PrintLine();
            foreach (tblEmployeeRoleName role in Roles)
            {
                PrintLine();
                PrintRow($"{role.roleID}", $"{role.roleName}", $"{role.active}");
                PrintLine();
                //Console.WriteLine($"{"location ID: " + location.locationid}\t{"Departments: " + location.department}\t{"Managers ID: " + location.managersid}");
            }
        }

        public void DisplayRoleNamesPages(List<tblEmployeeRoleName> Roles)
        {
            int loopnum = 0;
            bool loop = true;
            int pageNum = 1;
            decimal totalPagesDecimal = Roles.Count / 10;
            Math.Truncate(totalPagesDecimal);
            int totalPagesNum = Convert.ToInt32(totalPagesDecimal) + 1;
            PrintLine();
            PrintRow("Role ID ", " Role Name", " Active");
            PrintLine();
            if (loop = true)
            {
                foreach (tblEmployeeRoleName role in Roles)
                {
                    PrintLine();
                    PrintRow($"{role.roleID}", $"{role.roleName}", $"{role.active}");
                    PrintLine();
                    //Console.WriteLine($"{"Location ID: " + location.Location_ID}\t{"Location Name: " + location.Location_Name}");
                    loopnum++;
                    Console.WriteLine(loopnum);
                    if (loopnum == 10)
                    {
                        Console.WriteLine("do you wish to go to the next page Y/N");
                        Console.WriteLine("You are on page " + pageNum + " Of " + totalPagesNum);
                        string input = GetInput();
                        if (input.Equals("Y"))
                        {
                            loop = true;
                            loopnum = 0;
                            pageNum++;
                        }
                        else
                        {
                            loop = false;
                        }
                    }
                }

            }
        }

        //displays the data for the table EmployeeDetails
        public void DisplayEmployeeDetailsPages(List<tblEmployeeDetails> details)
        {
            int loopnum = 0;
            bool loop = true;
            int pageNum = 1;
            decimal totalPagesDecimal = details.Count/10;
            Math.Truncate(totalPagesDecimal);
            int totalPagesNum = Convert.ToInt32(totalPagesDecimal)+1;
            Console.Clear();
            PrintLine();
            PrintRow("employee ID ", " first Name", " last Name", " Hire Date ", " gender ", " job ID ", "role ", "active", "  email", " phone number ", " Location wage");
            PrintLine();
            if (loop = true)
            {
                foreach (tblEmployeeDetails detail in details)
                {
                    PrintLine();
                    PrintRow($"{detail.employeeID}", $"{detail.firstname}", $"{detail.lastname}", $"{detail.hireDate}", $"{detail.gender}", $"{detail.jobID}", $"{detail.roleID}", $"{detail.active}", $"{detail.email}", $"{detail.phonenumber}", $"{detail.wage}");
                    PrintLine();
                    //Console.WriteLine($"{"Location ID: " + location.Location_ID}\t{"Location Name: " + location.Location_Name}");
                    loopnum++;
                    Console.WriteLine(loopnum);
                    if (loopnum == 10)
                    {
                        Console.WriteLine("do you wish to go to the next page Y/N");
                        Console.WriteLine("You are on page "+ pageNum + " Of "+  totalPagesNum );
                        string input = GetInput();
                        if (input.Equals("Y"))
                        {
                            loop = true;
                            loopnum = 0;
                            pageNum ++;
                        }
                        else
                        {
                            loop = false;
                        }
                    }
                }
                
            }
        }

        public void DisplayEmployeeDetails(List<tblEmployeeDetails> details)
        {
            Console.Clear();
            PrintLine();
            PrintRow("employee ID ", " first Name", " last Name", " Hire Date ", " gender ", " job ID ", "role ", "active", "  email", " phone number ", " Location wage");
            PrintLine();
            foreach (tblEmployeeDetails detail in details)
                {
                    PrintLine();
                    PrintRow($"{detail.employeeID}", $"{detail.firstname}", $"{detail.lastname}", $"{detail.hireDate}", $"{detail.gender}", $"{detail.jobID}", $"{detail.roleID}", $"{detail.active}", $"{detail.email}", $"{detail.phonenumber}", $"{detail.wage}");
                    PrintLine();
                    //Console.WriteLine($"{"Location ID: " + location.Location_ID}\t{"Location Name: " + location.Location_Name}");
                    
                }
        }



        //displays the data for the table Departments
        public void DisplayDepartments(List<tblDepartments> departments)
        {
            PrintLine();
            PrintRow(" department ", " managers ID ", " Department ID ", " Active");
            PrintLine();
            foreach (tblDepartments department in departments)
            {
                PrintLine();
                PrintRow($"{department.department}", $"{department.managersID}", $"{department.departmentID}", $"{department.active}");
                PrintLine();
            }
        }

        public void DisplayDepartmentsPages(List<tblDepartments> departments)
        {
            int loopnum = 0;
            bool loop = true;
            int pageNum = 1;
            decimal totalPagesDecimal = departments.Count / 10;
            Math.Truncate(totalPagesDecimal);
            int totalPagesNum = Convert.ToInt32(totalPagesDecimal) + 1;
            PrintLine();
            PrintRow(" department ", " managers ID ", " Department ID ", " Active");
            PrintLine();
            if (loop = true)
            {
                foreach (tblDepartments department in departments)
                {
                    PrintLine();
                    PrintRow($"{department.department}", $"{department.managersID}", $"{department.departmentID}", $"{department.active}");
                    PrintLine();
                    loopnum ++;
                    if (loopnum == 10)
                    {
                        Console.WriteLine("do you wish to go to the next page Y/N");
                        Console.WriteLine("You are on page " + pageNum + " Of " + totalPagesNum);
                        string input = GetInput();
                        if (input.Equals("Y"))
                        {
                            loop = true;
                            loopnum = 0;
                            pageNum++;
                        }
                        else
                        {
                            loop = false;
                        }
                    }
                }
            }
        }


        // displays a message 
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        // gets the input of an string variable 
        public string GetInput()
        {
            string input;
            bool loop = true;
            do
            {
                input = Console.ReadLine().ToUpper();
                if (input.IsNullOrEmpty())
                {
                    loop = true;
                    Console.WriteLine("please enter a valid option");
                }
                else
                {
                    loop = false;
                }
            } while (loop);
            
            
            return input;
        }

        //gets the input of an int variable 
        public int GetIntInput()
        {
            string input;
            int IntInput = 0;
            bool loop = true;
            do
            {
                input = Console.ReadLine();
                bool number = IsAllDigits(input);
                if (input.IsNullOrEmpty() | number == false)
                {
                    Console.WriteLine("please input a valid option");
                    loop = true;
                }
                else
                {
                    IntInput = Convert.ToInt32(input);
                    loop = false;
                }
            } while (loop);
            return IntInput;
        }


        public bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}
