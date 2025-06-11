using employeeManagmentAppLachlan.Model;
using employeeManagmentAppLachlan.Repositories;
using employeeManagmentAppLachlan.View;
using Microsoft.Data.SqlClient;
using System.Threading.Channels;

namespace employeeManagmentAppLachlan
{
    public class Program //saved in onedrive>docc>12tpi>C#>oop>employeeManagmentAppLachlan OR .......oop>WorkPLS
    {                    // .mdf is saved in the DB folder onedrive>docc>12tpi>sql>DB
        private static StorageManager storageManager;
        private static consoleView view;
        
         //get explanation on how to convert the bit from the database into a true or false running assumption read the result of the bit then if statement to declare if 1 then true if 0 then false and just delcare it as an int in the list. 
         
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!");
            //scl connectionString
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\AC147303\\ONEDRIVE - AVONDALE COLLEGE\\DOCUMENTS\\12TPI\\SQL\\DB\\DATABASE2.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            //home connectionString
            //string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=database2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            storageManager = new StorageManager(connectionString);
            view = new consoleView();
            bool Notvalid = true;
            string tblchoice;
            string choice;
            bool loop = true;
            bool logInBool = true;
            string employeeChoice;
            
            //temp log in / role function
            Console.WriteLine("enter the role you wish to be 1 for employee 2 for admin");
            int role = Convert.ToInt32(Console.ReadLine());
            //do
            //{

             /*Console.WriteLine("Enter your Username");
             string inputedUsername = Console.ReadLine();
             string Username = inputedUsername;
             int EmployeeID = storageManager.getEmployeeID(inputedUsername);
             string password = storageManager.getPassword(inputedUsername);
             int role = storageManager.getRole(inputedUsername);
             Console.WriteLine("Please enter your Password");
             string inputedPassword = Console.ReadLine();
             Console.Clear();
             // Console.WriteLine("EmployeeID: " + EmployeeID);
             //Console.WriteLine("username: " + Username);
             // Console.WriteLine("Password: " + password);
             // Console.WriteLine("role: " + role);
             */
            //if (inputedUsername == Username && inputedPassword == password)
            //{
            if (role == 1)
            {
                logInBool = false;
                Console.Clear();
                Console.WriteLine("HAHA pleb employee");
                view.EmployeeDisplayMenu();
                
                //view.DisplayEmpEmployeeDetails();
                employeeChoice = Console.ReadLine();
                switch (employeeChoice)
                {
                    default:
                        {
                            Console.WriteLine("Invalid option please try again.");
                            Notvalid = false;
                        }
                        break;
                }
            }
            else
            {
                if (role == 2)
                {
                    logInBool = false;
                    Console.Clear();
                    Console.WriteLine("welcome admin");
                    do
                    {
                        do
                        {
                            view.TblDisplayMenu();
                            tblchoice = Console.ReadLine();
                            switch (tblchoice)
                            {
                                case "1":
                                    {
                                        //view.tblEmployeeContact();
                                        view.tblEmployeesDetails();
                                        // display details
                                        Notvalid = false;
                                        displaySwitch1();


                                    }
                                    break;
                                case "2":
                                    {
                                        view.tblEmployeeLocations();
                                        //display location
                                        Notvalid = false;
                                        displaySwitch2();

                                    }
                                    break;
                                case "3":
                                    {
                                        view.tblRoleName();
                                        Notvalid = false;
                                        displaySwitch3();

                                    }
                                    break;
                                case "4":
                                    {
                                        view.tblDepartments();
                                        Notvalid = false;
                                        displaySwitch4();

                                    }
                                    break;
                                case "5":
                                    {
                                        view.tblJobTittles();
                                        Notvalid = false;
                                        displaySwitch5();

                                    }
                                    break;
                                case "6":
                                    {
                                        view.tblLocationCountry();
                                        Notvalid = false;
                                        displaySwitch6();

                                    }
                                    break;
                                case "7":
                                    {
                                        view.tblStreet();
                                        Notvalid = false;
                                        displaySwitch7();

                                    }
                                    break;
                                case "8":
                                    {
                                        view.tblSuburb();
                                        Notvalid = false;
                                        displaySwitch8();
                                    }
                                    break;
                                case "9":
                                    {
                                        view.tblCity();
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
                        Console.WriteLine("Do you wish to go back to the main menu enter Y/N");
                        string choiceloopans = Console.ReadLine().ToUpper();
                        if (choiceloopans == "Y")
                        {
                            loop = true; ;
                        }
                        else
                        {
                            loop = false;
                        }
                        Console.Clear();
                    } while (loop);
                }
            }
            /* }
             else
             {
                 Console.WriteLine("Please enter a valid Username and Password");
                 loginbool = true;
             }
         } while (loginbool);*/
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
                            List<tblEmployeeDetails> employee = storageManager.GetTblEmployeeDetails();
                            view.DisplayEmployeeDetails(employee);
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
                            List<tblLocation> locations = storageManager.GetTblLocations();
                            view.DisplayLocation(locations);
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
                            List<tblEmployeeRoleName> roleNames = storageManager.GetTblEmployeeRoleNames();
                            view.DisplayRoleNames(roleNames);
                            //List<EmployeeTblEmployeesDetails> employee1 = storageManager.GetEmployeeTblEmployeesDetails();
                            //view.DisplaytblEmployeesDetails(employee1);
                            Notvalid = false;
                        }
                        break;
                    case "2":
                        {
                            UpdateRoleName();
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
                            List<tblDepartments> departments = storageManager.GetTblDepartments();
                            view.DisplayDepartments(departments);
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
                            List<tblJobtitle> jobTittle = storageManager.GetEmployeeTblJobTittles();
                            view.DisplaytblJobTittles(jobTittle);
                            Notvalid = false;
                        }
                        break;
                    case "2":
                        {
                            UpdateJobTitle();
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
                            List<tblLocationCountry> countries = storageManager.GetTblLocationCountries();
                            view.DisplayCountry(countries);
                            Notvalid = false;
                        }
                        break;
                    case "2":
                        {
                            UpdateLocationCountry();
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
                            List<tblStreetID> streetIDs = storageManager.GetTblStreetIDs();
                            view.DisplayStreetID(streetIDs);
                            Notvalid = false;
                        }
                        break;
                    case "2":
                        {
                            UpdateLocationStreet();
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
                            List<tblSubrubID> subrubIDs = storageManager.GetTblSubrubIDs();
                            view.DisplaySubrub(subrubIDs);
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
                            List<tblCityID> cityIDs = storageManager.GetTblCityIDs();
                            view.DisplayCity(cityIDs);
                            Notvalid = false;
                        }
                        break;
                    case "2":
                        {
                            UpdateLocationCity();
                            Notvalid = false;

                        }
                        break;
                    case "3":
                        {
                            DeleteCity();
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

        private static void UpdateRoleName()
        {
            view.DisplayMessage("Enter the Role Name to update");
            string roleName = view.GetInput();
            view.DisplayMessage($"What do you want to change {roleName} to:");
            string RoleNameChange = view.GetInput();
            string rowsAffected = storageManager.UpdateRoleName(roleName, RoleNameChange);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void UpdateJobTitle()
        {
            view.DisplayMessage("Enter the Job Title to update");
            string JobTitle = view.GetInput();
            view.DisplayMessage($"What do you want to change {JobTitle} to:");
            string JobTitleChange = view.GetInput();
            string rowsAffected = storageManager.UpdateJobTitle(JobTitle, JobTitleChange);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void UpdateLocationStreet()
        {
            view.DisplayMessage("Enter the Street Name to update");
            string StreetName = view.GetInput();
            view.DisplayMessage($"What do you want to change {StreetName} to:");
            string StreetNameChange = view.GetInput();
            string rowsAffected = storageManager.UpdateLocationStreet(StreetName, StreetNameChange);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void UpdateLocationCountry()
        {
            view.DisplayMessage("Enter the Country Name to update");
            string CountryName = view.GetInput();
            view.DisplayMessage($"What do you want to change {CountryName} to:");
            string CountryNameChange = view.GetInput();
            string rowsAffected = storageManager.UpdateLocationCountry(CountryName, CountryNameChange);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void UpdateLocationCity()
        {
            view.DisplayMessage("Enter the City Name to update");
            string CityName = view.GetInput();
            view.DisplayMessage($"What do you want to change {CityName} to:");
            string CityNameChange = view.GetInput();
            string rowsAffected = storageManager.UpdateLocationCity(CityName, CityNameChange);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
        /* tables to do
            add the emp det
            add the loc det
            add the subrub
            add the dept 
            get clarification on how to it with multiple lines such as 
            dept has multiple lines to update do you get a display method to ask what feild do you wish to update then call the update method for that.
            get display the data from the table then ask them to enter the id or use a wildcard operator for name eg enter human and it would display human resources etc 
            have display show active or inactive yes
            make the querys???? yes 
        */
        private static void DeleteCity()
        {
            view.DisplayMessage("Enter the City Name to Delte");
            string CityName = view.GetInput();
            string rowsAffected = storageManager.DeleteCity(CityName);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }




        /*
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
        */
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