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
        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to the Employee Managment Menu");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1 View All recors in Location.TblLocation");
        }

        public void DisplayLocations(List<LocationTblLocation> locationTblLocations)
        {
            foreach (LocationTblLocation location in locationTblLocations)
            {
                Console.WriteLine($"{"Location ID: " + location.Location_ID}\t{"Location Name: " + location.Location_Name}");
            }
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
