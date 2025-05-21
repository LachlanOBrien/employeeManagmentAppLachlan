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
