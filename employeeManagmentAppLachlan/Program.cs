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
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\GAMING LACHY\\ONEDRIVE - AVONDALE COLLEGE\\DOCUMENTS\\12TPI\\SQL\\DB\\EMPLOYEEMANAGMENT.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            storageManager = new StorageManager(connectionString);
            view = new consoleView();
           // string tblChoice = view.TblDisplayMenu();
            string choice = view.DisplayMenu();
            bool NotValid = true;

            do
            {
                view.DisplayMenu();
                switch (choice)
                {
                    case "1":
                        {
                            List<LocationTblLocation> locations = storageManager.GetLocationTblLocations();
                            view.DisplayLocations(locations);
                            NotValid = false;
                        }
                        break;
                    case "2":
                        {
                            UpdateLocationName();
                            NotValid = false;
                        }
                        break;
                    case "3":
                        {
                            InsertNewLocation();
                            NotValid = false;
                        }
                        break;
                    case "4":
                        {
                            DeleteByName();
                            NotValid = false;
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Invalid option please try again.");
                            NotValid = false;
                        }
                        break;
                }
            } while (NotValid); 

            
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

        private static void InsertNewLocation()
        {
            view.DisplayMessage("Enter the new Location Name");
            string locationName = view.GetInput();
            int locationID = 0;
            LocationTblLocation location1 = new LocationTblLocation(locationID, locationName);
            int generateID = storageManager.InsertLocation(location1);
            view.DisplayMessage($"new Location inserted with ID {generateID}");
        }

        public static void DeleteByName()
        {
            view.DisplayMessage("Enter the Location Name to delete");
            string locationName = view.GetInput();
            int rowsaffected = storageManager.DeleteLocationByName(locationName);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }

    }
}




/*
            do
            {
                view.TblDisplayMenu();
                switch (tblChoice)
                {
                    case "1":
                        {
                            //DiplayMenu();
                            NotValid = true;
                            
                        }
                        break;
                    case "2":
                        {
                            //DiplayMenu();
                            NotValid = true;
                        }
                        break;
                    case "3":
                        {
                            //DiplayMenu();
                            NotValid = true;
                        }
                        break;
                    case "4":
                        {
                            //DiplayMenu();
                            NotValid = true;
                        }
                        break;
                    case "5":
                        {
                            //DiplayMenu();
                            NotValid = true;
                        }
                        break;
                    case "6":
                        {
                            //DiplayMenu();
                            NotValid = true;
                        }
                        break;
                    case "7":
                        {
                            view.DisplayMenu();
                            NotValid = false;
                        }
                        break;
                    case "8":
                        {
                            //DiplayMenu();
                            NotValid = true;
                        }
                        break;
                    case "9":
                        {
                            //DiplayMenu();
                            NotValid = true;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Invalid option please try again.");
                            NotValid = false;
                        }
                        break;
                }
            } while (NotValid);
           */
