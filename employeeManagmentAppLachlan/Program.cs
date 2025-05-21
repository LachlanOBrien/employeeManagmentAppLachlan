using employeeManagmentAppLachlan.Model;
using employeeManagmentAppLachlan.Repositories;
using employeeManagmentAppLachlan.View;

namespace employeeManagmentAppLachlan
{
    public class Program //saved in onedrive>docc>12tpi>C#>oop>employeeManagmentAppLachlan OR .......oop>WorkPLS
    {                    // .mdf is saved in the DB folder onedrive>docc>12tpi>sql>DB
        private static StorageManager storageManager;
        private static consoleView view;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\AC147303\\ONEDRIVE - AVONDALE COLLEGE\\DOCUMENTS\\12TPI\\SQL\\DB\\EMPLOYEEMANAGMENT.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            storageManager = new StorageManager(connectionString);
            view = new consoleView();
            string choice = view.DisplayMenu();

            switch (choice)
            {
                case "1":
                    {
                        List<LocationTblLocation> locations = storageManager.GetLocationTblLocations();
                        view.DisplayLocations(locations);
                    }break;
                case "2":
                    {
                        UpdateLocationName();
                    }break;
                case "3":
                    {
                        //insertNewLocation();
                    }break;
                case "4":
                    {
                        //DeleteLocationByName();
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
            int LocationID = view.GetIntInput();
            view.DisplayMessage("Enter the Location Name");
            string LocationName = view.GetInput();
            int rowsAffected = storageManager.UpdateLocationName(LocationID, LocationName);
            view.DisplayMessage($"Rows affected {rowsAffected}");
        }
    }
}
