using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using employeeManagmentAppLachlan.Model;

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




        public void DisplayLocations(List<LocationTblLocation> locationTblLocations)
        {
            foreach (LocationTblLocation location in locationTblLocations)
            {
                Console.WriteLine($"{"Location ID: " + location.Location_ID}\t{"Location Name: " + location.Location_Name}");
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
