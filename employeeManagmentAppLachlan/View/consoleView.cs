using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using employeeManagmentAppLachlan.Model;

namespace employeeManagmentAppLachlan.View
{
    public class consoleView
    {
      /*  public string TblDisplayMenu()
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
            return Console.ReadLine();
        }
         public string tblEmployeeContactDiplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to tblEmployeeContact");
            Console.WriteLine("Choose an option from 1-4");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in Location.tblLocation");
            Console.WriteLine("2: Update a Location's name by LocationID");
            Console.WriteLine("3: Insert a new Location");
            Console.WriteLine("4: Delete a brand by Location name");
            return Console.ReadLine();
        }*/
         public string DisplayMenu()
        {
            Console.WriteLine("Welcome to the Employee Managment Menu");
            Console.WriteLine("Choose an option from 1-4");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in Location.TblLocation");
            Console.WriteLine("2: Update a Location's name by LocationID");
            Console.WriteLine("3: Insert a new Location");
            Console.WriteLine("4: Delete a brand by Location name");

            return Console.ReadLine();
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
