using employeeManagmentAppLachlan.Model;
using employeeManagmentAppLachlan.Repositories;
using employeeManagmentAppLachlan.View;
using System.Threading.Channels;

namespace employeeManagmentAppLachlan
{
        public class Program //saved in onedrive>docc>12tpi>C#>oop>employeeManagmentAppLachlan OR .......oop>WorkPLS
        {                    // .mdf is saved in the DB folder onedrive>docc>12tpi>sql>DB
            private static StorageManager storageManager;
            private static consoleView view;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //scl connectionString
            //string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\AC147303\\ONEDRIVE - AVONDALE COLLEGE\\DOCUMENTS\\12TPI\\SQL\\DB\\EMPLOYEEMANAGMENT.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            //Home ConnectionString
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\GAMING LACHY\\ONEDRIVE - AVONDALE COLLEGE\\DOCUMENTS\\12TPI\\SQL\\DB\\EMPLOYEEMANAGMENT.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            storageManager = new StorageManager(connectionString);
            view = new consoleView();
           // string tblchoice = view.TblDisplayMenu();
           // string choice = view.DisplayMenu();
            bool Notvalid = true;
            string tblchoice;
            string choice;

            do
            {
                view.TblDisplayMenu();
                tblchoice = Console.ReadLine();
                switch (tblchoice)
                {
                    case "1":
                        {
                            view.tblEmployeeContact();
                            Notvalid = false;
                            do
                            {
                                choice = Console.ReadLine();
                                switch (choice)
                                {
                                    case "1":
                                        {
                                            List<EmployeeTblEmployeeContact> employee = storageManager.GetEmployeeTblEmployeeContacts();
                                            view.DisplaytblEmployeeContact(employee);
                                            Notvalid = false;
                                        }
                                        break;
                                    case "2":
                                        {
                                            //UpdateLocationName();
                                            Notvalid = false;

                                        }
                                        break;

                                    default:
                                        {
                                            Console.WriteLine("Invalid option please try again.");
                                            Notvalid = true;
                                        }
                                        break;
                                }
                            } while (Notvalid);

                        }
                        break;
                    case "2":
                        {
                            view.tblEmployeeLocations();
                            Notvalid = false;
                        }
                        break;
                    case "3":
                        {
                            view.tblEmployeesDetails();
                            Notvalid = false;
                        }
                        break;
                    case "4":
                        {
                            view.tblEmployeeWage();
                            Notvalid = false;
                        }
                        break;
                    case "5":
                        {
                            view.tblJobTittles();
                            Notvalid = false;
                        }
                        break;
                    case "6":
                        {
                            view.tblDepartments();
                            Notvalid = false;
                        }
                        break;
                    case "7":
                        {
                            view.tblLocation();
                            Notvalid = false;
                            do
                            {
                                choice = Console.ReadLine();
                                switch (choice)
                                {
                                    case "1":
                                        {
                                            List<LocationTblLocation> locations = storageManager.GetLocationTblLocations();
                                            view.DisplayLocations(locations);
                                            Notvalid = false;
                                        }
                                        break;
                                    case "2":
                                        {
                                            UpdateLocationName();
                                            Notvalid = false;

                                        }
                                        break;
                                    case "3":
                                        {
                                            InsertNewLocation();
                                            Notvalid = false;

                                        }
                                        break;
                                    case "4":
                                        {
                                            DeleteByName();
                                            Notvalid = false;

                                        }
                                        break;

                                    default:
                                        {
                                            Console.WriteLine("Invalid option please try again.");
                                            Notvalid = true;
                                        }
                                        break;
                                }
                            } while (Notvalid);
                        }
                        break;
                    case "8":
                        {
                            view.tblLocationAdress();
                            Notvalid = false;
                        }
                        break;
                    case "9":
                        {
                            view.tblLocationCity();
                            Notvalid = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Invalid option please try again.");
                            Notvalid = false;
                        }
                        break;
                }
            } while (Notvalid);


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
                if (choice == "1")
                {
                    List<LocationTblLocation> locations = storageManager.GetLocationTblLocations();
                    view.DisplayLocations(locations);
                }
                else
                {
                    if (choice == "2")
                    {
                        UpdateLocationName();
                    }
                    else
                    {
                        if (choice == "3")
                        {
                            InsertNewLocation();
                        }
                        else
                        {
                            if (choice == "4")
                            {
                                DeleteByName();
                            }
                            else
                            {
                                Notvalid = false;
                                Console.WriteLine("Invalid option please try again.");
                            }
                        }
                    }
                }
            } while (Notvalid);                     
        }
    }*/



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
