using employeeManagmentAppLachlan.Model;
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
       public void TblDisplayMenu()
        {
            Console.WriteLine("Welcome to the Employee Managment Menu");
            Console.WriteLine("Choose an option from 1-9");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1.tblEmployeeContact ");
            Console.WriteLine("2.tblEmployeeLocations ");
            Console.WriteLine("3.tblEmployeesDetails ");
            Console.WriteLine("4.tblEmployeeWage ");
            Console.WriteLine("5.tblJobTittles ");
            Console.WriteLine("6.tblDepartments ");
            Console.WriteLine("7.tblLocation ");
            Console.WriteLine("8.tblLocationAdress");
            Console.WriteLine("9.tblLocationCity ");
        }

        public void tblEmployeeContact()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tblEmployeeContact");
            Console.WriteLine("Choose an option from 1-2");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in Employee.tblEmployeeContact");
            Console.WriteLine("2: Update an Employee's details by EmployeeID");
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

        public void tblEmployeeWage()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tblEmptblEmployeeWage");
            Console.WriteLine("Choose an option from 1-2");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in Employee.tblEmployee");
            Console.WriteLine("2: Update an employee's location by employeeID");
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

        public void tblLocation()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tblLocation");
            Console.WriteLine("Choose an option from 1-4");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in Location.tblEmployeeLocations");
            Console.WriteLine("2: Update a location by locationID");
            Console.WriteLine("3: Insert a new Location");
            Console.WriteLine("4: Delete a location by Location name");
        }

        public void tblLocationAdress()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tblLocationAdress");
            Console.WriteLine("Choose an option from 1-2");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in Location.tblLocationAdress");
            Console.WriteLine("2: Update a location by locationID");
        }
        
        public void tblLocationCity()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tblLocationCity");
            Console.WriteLine("Choose an option from 1-2");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in Location.tblLocationCity");
            Console.WriteLine("2: Update a location by locationID");
        }

        static int tableWidth = 73;
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
        public void DisplaytblEmployeeContact(List<EmployeeTblEmployeeContact> employeeTblEmployeeContacts)
        {
           
            PrintLine();
            PrintRow("employee ID ", " email", " phonenumber");
            /* Console.Clear();
            PrintLine();
            PrintRow("Column 1", "Column 2", "Column 3", "Column 4");
             PrintLine();
            PrintRow("test", "test", "test", "test");
            PrintRow("test", "test", "test", "test");
            PrintLine();
             Console.ReadLine(); */
            foreach (EmployeeTblEmployeeContact employee in employeeTblEmployeeContacts)
            {

                //Console.WriteLine($"{"Employee ID: " + employee.employeeid}\t\t{"Email: " + employee.email}\t\t{"Phone Number: " + employee.phonenumber}");
                //Console.WriteLine($"{ employee.employeeid}\t\t{ + employee.email}\t\t{ + employee.phonenumber}");
                PrintLine();
                PrintRow($"{employee.employeeid}", $"{employee.email}", $"{employee.phonenumber}");
                PrintLine();
            }
        }
        
        public void DisplaytblEmployeeLocations(List<EmployeeTblEmployeeLocations> employeeTblEmployeeLocations)
        {
            PrintLine();
            PrintRow(" Employee ID ", " Location ID");
            foreach (EmployeeTblEmployeeLocations employee in employeeTblEmployeeLocations)
            {
                PrintLine();
                PrintRow($"{employee.employeeid}", $"{employee.locationid}");
                PrintLine();
            }
        }

        public void DisplaytblEmployeesDetails(List<EmployeeTblEmployeesDetails> employeeTblEmployeesDetails)
        {
            PrintLine();
            PrintRow("employee ID ", " firstname", " lastname", " gender", " jobid");
            foreach (EmployeeTblEmployeesDetails employee in employeeTblEmployeesDetails)
            {
                PrintLine();
                PrintRow($"{employee.employeeid}", $"{employee.firstname}", $"{employee.lastname}", $"{employee.gender}", $"{employee.jobid}");
                PrintLine();
                //Console.WriteLine($"{"Employee ID: " + employee.employeeid}\t{"First Name: " + employee.firstname}\t{"Last Name: " + employee.lastname}\t{"Gender: " + employee.gender}\t{"Job ID: " + employee.jobid}");
            }
        }

        public void DisplaytblEmployeeWage(List<EmployeeTblEmployeeWage> employeeTblEmployeeWages)
        {
            PrintLine();
            PrintRow("employee ID ", " email", " wage");
            foreach (EmployeeTblEmployeeWage employee in employeeTblEmployeeWages)
            {
                PrintLine();
                PrintRow($"{employee.employeeid}", $"{employee.jobtitleid}", $"{employee.wage}");
                PrintLine();
                //Console.WriteLine($"{"Employee ID: " + employee.employeeid}\t{"Job title ID: " + employee.jobtitleid}\t{"Wage: " + employee.wage}");
            }
        }

        public void DisplaytblJobTittles(List<EmployeeTblJobTittles> jobTblJobTittles)
        {
            PrintLine();
            PrintRow("jobtitle ID ", " jobtitlename");
            foreach (EmployeeTblJobTittles jobTittle in jobTblJobTittles)
            {
                PrintLine();
                PrintRow($"{jobTittle.jobtitleid}", $"{jobTittle.jobtitlename}");
                PrintLine();
               // Console.WriteLine($"{"Job title ID: " + jobTittle.jobtitleid}\t{"Job title Name: " + jobTittle.jobtitlename}");
            }
        }

        public void DisplaytblDepartments(List<LocationTblDepartments> locationTblDepartments)
        {
            PrintLine();
            PrintRow("location ID ", " department", " managers ID");
            foreach (LocationTblDepartments location in locationTblDepartments)
            {
                PrintLine();
                PrintRow($"{location.locationid}", $"{location.department}", $"{location.managersid}");
                PrintLine();
                //Console.WriteLine($"{"location ID: " + location.locationid}\t{"Departments: " + location.department}\t{"Managers ID: " + location.managersid}");
            }
        }

        public void DisplayLocations(List<LocationTblLocation> locationTblLocations)
        {
            PrintLine();
            PrintRow("location ID ", " Location Name");
            foreach (LocationTblLocation location in locationTblLocations)
            {
                PrintLine();
                PrintRow($"{location.Location_ID}", $"{location.Location_Name}");
                PrintLine();
                //Console.WriteLine($"{"Location ID: " + location.Location_ID}\t{"Location Name: " + location.Location_Name}");
            }
        }

        public void DisplaytblLocationAdress(List<LocationTblLocationAdress> locationTblLocationAdresses)
        {
            PrintLine();
            PrintRow("location ID ", " city ID ", " country ");
            foreach (LocationTblLocationAdress location in locationTblLocationAdresses)
            {
                PrintLine();
                PrintRow($"{location.locationid}", $"{location.cityid}", $"{location.country}");
                PrintLine();
                //Console.WriteLine($"{"location ID: " + location.locationid}\t{"city ID: " + location.cityid}\t{"Country: " + location.country}");
            }
        }

        public void DisplaytblLocationCity(List<LocationTblLocationCity> locationTblLocationCities)
        {
            PrintLine();
            PrintRow("City ID ", " suburb", " postcode", " suburb ", " street ", "city");
            foreach (LocationTblLocationCity city in locationTblLocationCities)
            {
                PrintLine();
                PrintRow($"{city.City_ID}", $"{city.suburb}", $"{city.postcode}", $"{city.suburb}", $"{city.street}", $"{city.city}");
                PrintLine();
                //Console.WriteLine($"{"City ID: " + city.City_ID}\t{"Suburb: " + city.suburb}\t{"Post Code: " + city.postcode}\t{"Street: " + city.street}\t{"City: " + city.city}");
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
