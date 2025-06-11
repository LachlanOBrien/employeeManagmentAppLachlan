using employeeManagmentAppLachlan.Model;
using employeeManagmentAppLachlan.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.View
{
    public class consoleView //plan for adding thingys get the input for each field in employee schema and then spread it out to each table that requires it 
    {
        private static StorageManager storageManager;
        static int tableWidth = 232;
        public void TblDisplayMenu()
        {
            Console.WriteLine("Welcome to the Employee Managment Menu");
            Console.WriteLine("Choose an option from 1-9");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1.tblEmployeesDetails ");
            Console.WriteLine("2.tblEmployeeLocations ");
            Console.WriteLine("3.tblRoleName ");
            Console.WriteLine("4.tblDepartments ");
            Console.WriteLine("5.tblJobTittles ");
            Console.WriteLine("6.tblLocationCountry ");
            Console.WriteLine("7.tblStreet ");
            Console.WriteLine("8.tblSuburb");
            Console.WriteLine("9.tblCity ");
        }

        public void EmployeeDisplayMenu()
        {
            Console.WriteLine("employeeMenu");
        }

        public void DisplayUpdateEmployeeDetails()
        {
            Console.WriteLine("What Feild do you wish to update");
            Console.WriteLine("Choose an option from 1-5");
            Console.WriteLine("1: First Name");
            Console.WriteLine("2: Last Name");
            Console.WriteLine("3: Gender");
            Console.WriteLine("4: Email");
            Console.WriteLine("5: Phonenumber");
        }

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

        public void DisplayUpdatesubrub()
        {
            Console.WriteLine("What Feild do you wish to update");
            Console.WriteLine("Choose an option from 1-5");
            Console.WriteLine("1: subrub Name");
            Console.WriteLine("2: Post Code");
        }

        public void DisplayUpdateDept()
        {
            Console.WriteLine("What Feild do you wish to update");
            Console.WriteLine("Choose an option from 1-5");
            Console.WriteLine("1: Department Name");
            Console.WriteLine("2: Managers ID");
        }

        public void tblEmployeeLocations()
        {
            Console.Clear();
            Console.WriteLine("Welcome to EmployeeLocations");
            Console.WriteLine("Choose an option from 1-2");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in Employee.tblEmployeeLocations");
            Console.WriteLine("2: Update an employee's location by employeeID");
        }

        public void tblEmployeesDetails()
        {
            Console.Clear();
            Console.WriteLine("Welcome to EmployeesDetails");
            Console.WriteLine("Choose an option from 1-2");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in Employee.tblEmployeesDetails");
            Console.WriteLine("2: Update an employee's details by employeeID");
        }

        public void tblJobTittles()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tblJobTittles");
            Console.WriteLine("Choose an option from 1-4");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in Employee.tblJobTittles");
            Console.WriteLine("2: Update a job title by jobtitleID");
            Console.WriteLine("3: Insert a new job title");
            Console.WriteLine("4: Delete a job title by job title name");
        }

        public void tblDepartments()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tblDepartments");
            Console.WriteLine("Choose an option from 1-4");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in Location.tblDepartments");
            Console.WriteLine("2: Update a Departments by DepartmentsID");
            Console.WriteLine("3: Insert a new Departments");
            Console.WriteLine("4: Delete a Departments by Departments name");
        }
        public void tblRoleName()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tbl Role Name");
            Console.WriteLine("Choose an option from 1-4");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tbl Role Name");
            Console.WriteLine("2: Update a Role by RoleID");
            Console.WriteLine("3: Insert a new Role");
            Console.WriteLine("4: Delete a Role by Rolename");
        }

        public void tblLocationCountry()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tbl Location Country");
            Console.WriteLine("Choose an option from 1-4");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tbl Location Country");
            Console.WriteLine("2: Update a country by countryID");
            Console.WriteLine("3: Insert a new Country");
            Console.WriteLine("4: Delete a Country by Country name");
        }

        public void tblStreet()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tbl Street ");
            Console.WriteLine("Choose an option from 1-4");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tbl Street");
            Console.WriteLine("2: Update a Street by StreetID");
            Console.WriteLine("3: Insert a new Street");
            Console.WriteLine("4: Delete a Street by Street ID");
        }

        public void tblSuburb()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tbl Suburb ");
            Console.WriteLine("Choose an option from 1-4");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tbl Suburb");
            Console.WriteLine("2: Update a Suburb by SuburbID");
            Console.WriteLine("3: Insert a new Suburb");
            Console.WriteLine("4: Delete a Suburb by Suburb ID");
        }

        public void tblCity()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tbl City ");
            Console.WriteLine("Choose an option from 1-4");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tbl City");
            Console.WriteLine("2: Update a City by CityID");
            Console.WriteLine("3: Delete a new City by City Name");
            Console.WriteLine("4: Insert a new City");
        }
        public void displayusername()
        {
            Console.Clear();
            Console.WriteLine("enter your UserName");
        }

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

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
        public void DisplayCity(List<tblCityID> CityID)
        {
           
            PrintLine();
            PrintRow("City ID ", " City Name", "Active");
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
        
        public void DisplayStreetID(List<tblStreetID> streetID)
        {
            PrintLine();
            PrintRow(" Street ID ", " Street Name", " Active");
            foreach (tblStreetID street in streetID)
            {
                PrintLine();
                PrintRow($"{street.streetID}", $"{street.streetName}", $"{street.active}");
                PrintLine();
            }
        }

        public void DisplaySubrub(List<tblSubrubID> subrubID)
        {
            PrintLine();
            PrintRow(" suburb ID ", " subrub Name", " post code", " Active");
            foreach (tblSubrubID subrub in subrubID)
            {
                PrintLine();
                PrintRow($"{subrub.suburbID}", $"{subrub.suburbName}", $"{subrub.postcode}", $"{subrub.active}");
                PrintLine();

            }
        }

        public void DisplayCountry(List<tblLocationCountry> countryID)
        {
            PrintLine();
            PrintRow("Country ID ", " Country Name", " Active");
            foreach (tblLocationCountry country in countryID)
            {
                PrintLine();
                PrintRow($"{country.countryId}", $"{country.countryName}", $"{country.active}");
                PrintLine();
            }
        }

        public void DisplayLocation(List<tblLocation> locations)
        {
            PrintLine();
            PrintRow("Location ID ", " Location Name", " CountryID", " SuburbID", " StreetID", " CityID", " StreetNumber", " Active");
            foreach (tblLocation location in locations)
            {
                PrintLine();
                PrintRow($"{location.locationID}", $"{location.locationName}", $"{location.countryID}", $"{location.suburbID}", $"{location.streetID}", $"{location.cityID}", $"{location.streetNumber}", $"{location.active}");
                PrintLine();
            }
        }

        public void DisplaytblJobTittles(List<tblJobtitle> jobtitles)
        {
            PrintLine();
            PrintRow("jobtitle ID ", " jobtitlename", "Active ");
            foreach (tblJobtitle jobTittle in jobtitles)
            {
                PrintLine();
                PrintRow($"{jobTittle.jobtitleID}", $"{jobTittle.jobtitleName}", $"{jobTittle.active}");
                PrintLine();
               // Console.WriteLine($"{"Job title ID: " + jobTittle.jobtitleid}\t{"Job title Name: " + jobTittle.jobtitlename}");
            }
        }

        public void DisplayRoleNames(List<tblEmployeeRoleName> Roles)
        {
            PrintLine();
            PrintRow("Role ID ", " Role Name");
            foreach (tblEmployeeRoleName role in Roles)
            {
                PrintLine();
                PrintRow($"{role.roleID}", $"{role.roleName}");
                PrintLine();
                //Console.WriteLine($"{"location ID: " + location.locationid}\t{"Departments: " + location.department}\t{"Managers ID: " + location.managersid}");
            }
        }

        public void DisplayEmployeeDetails(List<tblEmployeeDetails> details)
        {
            PrintLine();
            PrintRow("employee ID ", " first Name", " last Name", " Hire Date ", " gender ", " job ID ", "role ", "active", "  email", " phone number ", " Location wage");
            foreach (tblEmployeeDetails detail in details)
            {
                PrintLine();
                PrintRow($"{detail.employeeID}", $"{detail.firstname}", $"{detail.lastname}", $"{detail.hireDate}", $"{detail.gender}", $"{detail.jobID}", $"{detail.roleID}", $"{detail.active}", $"{detail.email}", $"{detail.phonenumber}", $"{detail.wage}");
                PrintLine();
                //Console.WriteLine($"{"Location ID: " + location.Location_ID}\t{"Location Name: " + location.Location_Name}");
            }
        }

        public void DisplayDepartments(List<tblDepartments> departments)
        {
            PrintLine();
            PrintRow(" department ", " managers ID ", " Department ID ", " Active");
            foreach (tblDepartments department in departments)
            {
                PrintLine();
                PrintRow($"{department.department}", $"{department.managersID}", $"{department.departmentID}", $"{department.active}");
                PrintLine();
            }
        }

        public void DisplayEmpEmployeeDetails(List<empTblEmployeeDetails> employeeDetails)
        {
            PrintLine();
            PrintRow("employee ID ", " first Name", " last Name", " Hire Date ", " gender ", " job ID ", "role ", "active", "  email", " phone number ", " Location wage");
            foreach (empTblEmployeeDetails EmpDetail in employeeDetails)
            {
                PrintLine();
                PrintRow($"{EmpDetail.employeeID}", $"{EmpDetail.firstname}", $"{EmpDetail.lastname}", $"{EmpDetail.hireDate}", $"{EmpDetail.gender}", $"{EmpDetail.jobID}", $"{EmpDetail.roleID}", $"{EmpDetail.active}", $"{EmpDetail.email}", $"{EmpDetail.phonenumber}", $"{EmpDetail.wage}");
                PrintLine();

            }
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public int GetIntInput()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}
