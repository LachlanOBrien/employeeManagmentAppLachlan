using employeeManagmentAppLachlan.Model;
using employeeManagmentAppLachlan.Repositories;
using employeeManagmentAppLachlan.View;
using Microsoft.Data.SqlClient;
using System.Threading.Channels;

namespace employeeManagmentAppLachlan
{
    public class user
    {
        public int EmployeeID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int role { get; set; }
    }
    public class Program //saved in onedrive>docc>12tpi>C#>oop>employeeManagmentAppLachlan OR .......oop>WorkPLS
        {                    // .mdf is saved in the DB folder onedrive>docc>12tpi>sql>DB
            private static StorageManager storageManager;
            private static consoleView view;

        static void Main(string[] args)
        {
           
            Console.WriteLine("Hello, World!");
            //scl connectionString
            //string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\AC147303\\ONEDRIVE - AVONDALE COLLEGE\\DOCUMENTS\\12TPI\\SQL\\DB\\EMPLOYEEMANAGMENT.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            //home connectionString
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\GAMING LACHY\\ONEDRIVE - AVONDALE COLLEGE\\DOCUMENTS\\12TPI\\SQL\\DB\\EMPLOYEEMANAGMENT.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            storageManager = new StorageManager(connectionString);
            view = new consoleView();
            bool Notvalid = true;
            string tblchoice;
            string choice;
            /*
            works
            tbl1
            tbl2
            tbl7
            dont 
            tbl 3
            tbl 4
            tbl 5
            tbl 6
            tbl 8
            tbl 9
            */


            //view.displayusername();
            //int EmployeeID = view.GetIntInput();
            //string username = storageManager.getUserName(username);
            Console.WriteLine("Enter your Username");
            string inputedUsername = Console.ReadLine();
            string Username = inputedUsername;
            int EmployeeID = storageManager.getEmployeeID(inputedUsername);
            string password = storageManager.getPassword(inputedUsername);
            int role = storageManager.getRole(inputedUsername);
            Console.WriteLine("EmployeeID: " + EmployeeID);
            Console.WriteLine("username: " + Username);
            Console.WriteLine("Password: " + password);
            Console.WriteLine("role: " + role);
            Console.WriteLine("Please enter your Password");
            string inputedPassword = Console.ReadLine();

            if (inputedUsername == Username && inputedPassword == password)
            {
                if (role == 1)
                {
                    Console.WriteLine("HAHA pleb employee");
                }
                else
                {
                    if (role == 2)
                    {
                        do //commented out for testing purposes uncomment later to use the program 
                        {
                            view.TblDisplayMenu();
                            tblchoice = Console.ReadLine();
                            switch (tblchoice)
                            {
                                case "1":
                                    {
                                        view.tblEmployeeContact();
                                        Notvalid = false;
                                        displaySwitch1();


                                    }
                                    break;
                                case "2":
                                    {
                                        view.tblEmployeeLocations();
                                        Notvalid = false;
                                        displaySwitch2();

                                    }
                                    break;
                                case "3": //doesnt display
                                    {
                                        view.tblEmployeesDetails();
                                        Notvalid = false;
                                        displaySwitch3();

                                    }
                                    break;
                                case "4":// doesnt display
                                    {
                                        view.tblEmployeeWage();
                                        Notvalid = false;
                                        displaySwitch4();

                                    }
                                    break;
                                case "5":// doesnt display
                                    {
                                        view.tblJobTittles();
                                        Notvalid = false;
                                        displaySwitch5();

                                    }
                                    break;
                                case "6":// doesnt display
                                    {
                                        view.tblDepartments();
                                        Notvalid = false;
                                        displaySwitch6();

                                    }
                                    break;
                                case "7":
                                    {
                                        view.tblLocation();
                                        Notvalid = false;
                                        displaySwitch7();

                                    }
                                    break;
                                case "8": // doesnt display
                                    {
                                        view.tblLocationAdress();
                                        Notvalid = false;
                                        displaySwitch8();

                                    }
                                    break;
                                case "9":
                                    {
                                        view.tblLocationCity();
                                        Notvalid = false;
                                        displaySwitch9();

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
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid Username and Password");
            }




        }


        public static void displaySwitch1()
        {
            string choice;
            bool Notvalid = true;
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

        public static void displaySwitch2()
        {
            string choice;
            bool Notvalid = true;
            do
            {
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            List<EmployeeTblEmployeeLocations> employee = storageManager.GetEmployeeTblEmployeeLocations();
                            view.DisplaytblEmployeeLocations(employee);
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

        public static void displaySwitch3()
        {
            string choice;
            bool Notvalid = true;
            do
            {
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        { // doesnt display the list
                            List<EmployeeTblEmployeesDetails> employee = storageManager.GetEmployeeTblEmployeesDetails();
                            view.DisplaytblEmployeesDetails(employee);
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

        public static void displaySwitch4()
        {
            string choice;
            bool Notvalid = true;
            do
            {
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            List<EmployeeTblEmployeeWage> employee = storageManager.GetEmployeeTblEmployeeWages();
                            view.DisplaytblEmployeeWage(employee);
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

        public static void displaySwitch5()
        {
            string choice;
            bool Notvalid = true;
            do
            {
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            List<EmployeeTblJobTittles> jobTittle = storageManager.GetEmployeeTblJobTittles();
                            view.DisplaytblJobTittles(jobTittle);
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

        public static void displaySwitch6()
        {
            string choice;
            bool Notvalid = true;
            do
            {
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            List<LocationTblDepartments> locations = storageManager.GetLocationTblDepartments();
                            view.DisplaytblDepartments(locations);
                            Notvalid = false;
                        }
                        break;
                    case "2":
                        {
                            // UpdateLocationName();
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

        public static void displaySwitch7()
        {
            string choice;
            bool Notvalid = true;
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
                            // UpdateLocationName();
                            Notvalid = false;

                        }
                        break;
                    case "3":
                        {
                            // InsertNewLocation();
                            Notvalid = false;

                        }
                        break;
                    case "4":
                        {
                            // DeleteByName();
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

        public static void displaySwitch8()
        {
            string choice;
            bool Notvalid = true;
            do
            {
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            List<LocationTblLocationAdress> locations = storageManager.GetLocationTblLocationAdresses();
                            view.DisplaytblLocationAdress(locations);
                            Notvalid = false;
                        }
                        break;
                    case "2":
                        {
                            // UpdateLocationName();
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

        public static void displaySwitch9()
        {
            string choice;
            bool Notvalid = true;
            do
            {
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            List<LocationTblLocationCity> locations = storageManager.GetLocationTblLocationCities();
                            view.DisplaytblLocationCity(locations);
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

       /* public static int getEmployeeID()
        {
            view.displayusername();
            int EmployeeID = view.GetIntInput();
            //int employeeID = storageManager.get
            return EmployeeID;
        }

        public static string Getusername()
        {
                view.displayusername();
                int EmployeeID = view.GetIntInput();
                string username = storageManager.getUserName(EmployeeID);
                return username;
        }

        public static string GetPassword()
        {
            string password =
            return password;
        }

        public static int GetRole()
        {
            int Role = 
            return Role;
        }
       */
    }
}