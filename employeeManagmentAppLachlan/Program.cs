using employeeManagmentAppLachlan.Model;
using employeeManagmentAppLachlan.Repositories;
using employeeManagmentAppLachlan.View;

namespace employeeManagmentAppLachlan
{
    public class Program //saved in onedrive>docc>12tpi>C#>oop>employeeManagmentAppLachlan OR .......oop>WorkPLS
    {                    // .mdf is saved in the DB folder onedrive>docc>12tpi>sql>DB
        private static StorageManager storageManager;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\AC147303\\ONEDRIVE - AVONDALE COLLEGE\\DOCUMENTS\\12TPI\\SQL\\DB\\EMPLOYEEMANAGMENT.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            storageManager = new StorageManager(connectionString);
            consoleView View = new consoleView();
            View.DisplayMenu();
            string choice = View.DisplayMenu();

            switch (choice)
            {
                case "1":
                    {
                        List<LocationTblLocation> locations = storageManager.GetLocationTblLocations();
                        View.DisplayLocations(locations);
                    }break;
                case "2":
                    {
                        UpdateLocationName();
                    }break;
                case "3":
                    {
                        insertNewLocation();
                    }break;
                case "4":
                    {
                        DeleteLocationByName();
                    }break;

                default:
                    {
                        Console.WriteLine("Invalid option please try again.");
                    }break;
            }

        }

        private static void UpdateLocationName()
        {
            view.DisplayMessage("Enter the Location_id to update");
            int LocationID = view.GetIntInput;
            View.DisplayMessage("Enter the Location Name");
            string LocationName = view.getInput();
            int rowsAffected = storageManager.UpdateLocationName(int LocationID, string LocationName);
            View.DisplayMessage($"Rows affected {rowsAffected}");
        }
    }
}
