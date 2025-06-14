using employeeManagmentAppLachlan.Model;
using employeeManagmentAppLachlan.Repositories;
using employeeManagmentAppLachlan.View;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Numerics;
using System.Threading.Channels;

namespace employeeManagmentAppLachlan
{
    public class Program //saved in onedrive>docc>12tpi>C#>oop>employeeManagmentAppLachlan OR .......oop>WorkPLS
    {                    // .mdf is saved in the DB folder onedrive>docc>12tpi>sql>DB
        private static StorageManager storageManager;
        private static consoleView view;
        static int role;
        //to do list
        /*
            Make the querys for admins and employees
            add the register funcation
            add the try catches for where required
            finish the emp switch case
            add comments 
            
        */

        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!");
            //scl connectionString
            //string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\AC147303\\ONEDRIVE - AVONDALE COLLEGE\\DOCUMENTS\\12TPI\\SQL\\DB\\DATABASE2.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            //home connectionString
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=db2v2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            storageManager = new StorageManager(connectionString);
            view = new consoleView();
            bool NotValidMain = true;
            string tblchoice;
            string choice;
            bool loop = true;
            bool logInBool = true;
            string employeeChoice;

            //temp log in / role function
            //Console.WriteLine("enter the role you wish to be 1 for employee 2 for admin");
            //role = Convert.ToInt32(Console.ReadLine());
            //SwitchMainAdmin(); 
            do
            {
                Console.WriteLine("Enter your Username");
                string inputedUsername = Console.ReadLine();
                string Username = inputedUsername;
                int EmployeeID = storageManager.getEmployeeID(inputedUsername);
                string password = storageManager.getPassword(inputedUsername);
                role = storageManager.getRole(inputedUsername);
                Console.WriteLine("Please enter your Password");
                string inputedPassword = Console.ReadLine();
                Console.Clear();
                // Console.WriteLine("EmployeeID: " + EmployeeID);
                //Console.WriteLine("username: " + Username);
                // Console.WriteLine("Password: " + password);
                // Console.WriteLine("role: " + role);
                if (inputedUsername == Username && inputedPassword == password)
                {
                    if (role == 1)
                    {
                        logInBool = false;
                        SwitchMainEmp(EmployeeID);
                    }
                    else
                    {
                        if (role == 2)
                        {
                            logInBool = false;
                            SwitchMainAdmin();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid Username and Password");
                    logInBool = true;
                }
            } while (logInBool);
        }

        public static void SwitchMainAdmin()
        {
            //int role = Role;
            bool NotValidMain = true;
            string tblchoice;
            string choice;
            bool loop = true;
            bool logInBool = true;
            string employeeChoice;

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
                                NotValidMain = false;
                                displaySwitch1();


                            }
                            break;
                        case "2":
                            {
                                view.tblEmployeeLocations();
                                //display location
                                NotValidMain = false;
                                displaySwitch2();

                            }
                            break;
                        case "3":
                            {
                                view.tblRoleName();
                                NotValidMain = false;
                                displaySwitch3();

                            }
                            break;
                        case "4":
                            {
                                view.tblDepartments();
                                NotValidMain = false;
                                displaySwitch4();

                            }
                            break;
                        case "5":
                            {
                                view.tblJobTittles();
                                NotValidMain = false;
                                displaySwitch5();

                            }
                            break;
                        case "6":
                            {
                                view.tblLocationCountry();
                                NotValidMain = false;
                                displaySwitch6();

                            }
                            break;
                        case "7":
                            {
                                view.tblStreet();
                                NotValidMain = false;
                                displaySwitch7();

                            }
                            break;
                        case "8":
                            {
                                view.tblSuburb();
                                NotValidMain = false;
                                displaySwitch8();
                            }
                            break;
                        case "9":
                            {
                                view.tblCity();
                                NotValidMain = false;
                                displaySwitch9();

                            }
                            break;
                        default:
                            {
                                Console.WriteLine("Invalid option please try again.");
                                NotValidMain = false;
                            }
                            break;
                    }
                } while (NotValidMain);
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

        public static void SwitchMainEmp(int EmployeeID)
        {
            string Choice;
            bool NotValidMain = false;
            int employeeID = EmployeeID;
            Console.Clear();
            Console.WriteLine("HAHA pleb employee");
            do
            {
                view.EmployeeDisplayMenu();
                Choice = Console.ReadLine();
                switch (Choice)
                {
                    case "1":
                        {
                            List<tblEmployeeDetails> employee = storageManager.GetTblEmployeeDetails();
                            view.DisplayEmpEmployeeDetails(employee, employeeID);
                        }
                        break;
                    case "2":
                        {
                            SwitchMainEmp(employeeID);
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Invalid option please try again.");
                            NotValidMain = false;
                        }
                        break;
                }
            } while (NotValidMain = false);
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
                            UpdateEmployeeDetails();
                            Notvalid = false;

                        }
                        break;
                    case "3":
                        {
                            DeleteEmployeeDetails();
                            Notvalid = false;

                        }
                        break;
                    case "4":
                        {
                            InsertEmployeeDetails();
                            Notvalid = false;

                        }
                        break;
                    case "5":
                        {
                            SwitchMainAdmin();
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
                            UpdateLocation();
                            Notvalid = false;

                        }
                        break;
                    case "3":
                        {
                            DeleteLocation();
                            Notvalid = false;

                        }
                        break;
                    case "4":
                        {
                            InsertLocation();
                            Notvalid = false;

                        }
                        break;
                    case "5":
                        {
                            SwitchMainAdmin();
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
                        {
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
                    case "3":
                        {
                            DeleteRoleName();
                            Notvalid = false;

                        }
                        break;
                    case "4":
                        {
                            InsertRoleName();
                            Notvalid = false;

                        }
                        break;
                    case "5":
                        {
                            SwitchMainAdmin();
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
                            UpdateDept();
                            Notvalid = false;

                        }
                        break;
                    case "3":
                        {
                            DeleteDepartment();
                            Notvalid = false;

                        }
                        break;
                    case "4":
                        {
                            InsertDepartment();
                            Notvalid = false;

                        }
                        break;
                    case "5":
                        {
                            SwitchMainAdmin();
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
                    case "3":
                        {
                            DeleteJobtitle();
                            Notvalid = false;

                        }
                        break;
                    case "4":
                        {
                            InsertJobtitle();
                            Notvalid = false;

                        }
                        break;
                    case "5":
                        {
                            SwitchMainAdmin();
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
                    case "3":
                        {
                            DeleteCountry();
                            Notvalid = false;

                        }
                        break;
                    case "4":
                        {
                            InsertCountry();
                            Notvalid = false;

                        }
                        break;
                    case "5":
                        {
                            SwitchMainAdmin();
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
                            DeleteStreet();
                            Notvalid = false;

                        }
                        break;
                    case "4":
                        {
                            InsertStreet();
                            Notvalid = false;

                        }
                        break;
                    case "5":
                        {
                            SwitchMainAdmin();
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
                            Updatesubrub();
                            Notvalid = false;

                        }
                        break;
                    case "3":
                        {
                            DeleteSuburb();
                            Notvalid = false;

                        }
                        break;
                    case "4":
                        {
                            InsertSuburb();
                            Notvalid = false;

                        }
                        break;
                    case "5":
                        {
                            SwitchMainAdmin();
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
                    case "4":
                        {
                            InsertCity();
                            Notvalid = false;

                        }
                        break;
                    case "5":
                        {
                            SwitchMainAdmin();
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

        private static void UpdateEmployeeDetails()
        {
            bool loop = true;
            do
            {
                view.DisplayUpdateEmployeeDetails();
                string FieldChoice = view.GetInput();
                switch (FieldChoice) // change the grammar error in the switch cases of update to update to and change of to that relates to the 
                {
                    case "1":
                        {
                            loop = false;
                            string FieldChoiceName = "FirstName";
                            List<tblEmployeeDetails> employee = storageManager.GetTblEmployeeDetails();
                            view.DisplayEmployeeDetails(employee);
                            view.DisplayMessage("Enter the Employee ID that relates to the First Name you wish to update ");
                            Console.WriteLine("(Refrence data above)");
                            int EmployeeID = view.GetIntInput();
                            view.DisplayMessage($"What do you want to change {EmployeeID}'s First Name to:");
                            string FirstNameChange = view.GetInput();
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, EmployeeID, FirstNameChange);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "2":
                        {
                            loop = false;
                            string FieldChoiceName = "LastName";
                            List<tblEmployeeDetails> employee = storageManager.GetTblEmployeeDetails();
                            view.DisplayEmployeeDetails(employee);
                            view.DisplayMessage("Enter the Employee ID that relates to the Last Name you wish to update");
                            Console.WriteLine("(Refrence data above)");
                            int EmployeeID = view.GetIntInput();
                            view.DisplayMessage($"What do you want to change {EmployeeID}'s Last Name to:");
                            string Change = view.GetInput();
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, EmployeeID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "3":
                        {
                            loop = false;
                            string FieldChoiceName = "Gender";
                            List<tblEmployeeDetails> employee = storageManager.GetTblEmployeeDetails();
                            view.DisplayEmployeeDetails(employee);
                            view.DisplayMessage("Enter the Employee ID that relates to the Employee's Gender you wish to update");
                            Console.WriteLine("(Refrence data above)");
                            int EmployeeID = view.GetIntInput();
                            view.DisplayMessage($"What do you want to change {EmployeeID}'s Gender to:");
                            string Change = view.GetInput();
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, EmployeeID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "4":
                        {
                            loop = false;
                            string FieldChoiceName = "Email";
                            List<tblEmployeeDetails> employee = storageManager.GetTblEmployeeDetails();
                            view.DisplayEmployeeDetails(employee);
                            view.DisplayMessage("Enter the Employee ID that relates to the Email you wish to update");
                            Console.WriteLine("(Refrence data above)");
                            int EmployeeID = view.GetIntInput();
                            view.DisplayMessage($"What do you want to change {EmployeeID}'s Gender to:");
                            string Change = view.GetInput();
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, EmployeeID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "5":
                        {
                            loop = false;
                            string FieldChoiceName = "Phonenumber";
                            List<tblEmployeeDetails> employee = storageManager.GetTblEmployeeDetails();
                            view.DisplayEmployeeDetails(employee);
                            view.DisplayMessage("Enter the Employee ID that relates to the Phonenumber you wish to update");
                            Console.WriteLine("(Refrence data above)");
                            int EmployeeID = view.GetIntInput();
                            view.DisplayMessage($"What do you want to change {EmployeeID}'s Gender to:");
                            string Change = view.GetInput();
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, EmployeeID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option please try again.");
                        loop = true;
                        break;
                }
            }
            while (loop);
        }

        private static void UpdateLocation()
        {
            bool loop = true;
            do
            {
                view.DisplayUpdateLocation();
                string FieldChoice = view.GetInput();
                switch (FieldChoice)
                {
                    case "1":
                        {
                            loop = false;
                            string FieldChoiceName = "LocationName";
                            List<tblLocation> locations = storageManager.GetTblLocations();
                            view.DisplayLocation(locations);
                            view.DisplayMessage("Enter the Location ID that relates to the Location Name you wish to update");
                            Console.WriteLine("(Refrence data above)");
                            int LocationID = view.GetIntInput();
                            view.DisplayMessage($"What do you want to change {LocationID}'s Name to:");
                            string Change = view.GetInput();
                            string rowsAffected = storageManager.UpdateLocation(FieldChoiceName, LocationID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "2":
                        {
                            loop = false;
                            string FieldChoiceName = "CityID";
                            List<tblLocation> locations = storageManager.GetTblLocations();
                            view.DisplayLocation(locations);
                            List<tblCityID> cityIDs = storageManager.GetTblCityIDs();
                            view.DisplayCity(cityIDs);
                            view.DisplayMessage("Enter the Location ID that relates to the City ID you wish to update");
                            Console.WriteLine("(Refrence data above)");
                            int CityID = view.GetIntInput();
                            view.DisplayMessage($"What do you want to change {CityID}'s ID to:");
                            string Change = view.GetInput();
                            string rowsAffected = storageManager.UpdateLocation(FieldChoiceName, CityID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "3":
                        {
                            loop = false;
                            string FieldChoiceName = "SuburbID";
                            List<tblLocation> locations = storageManager.GetTblLocations();
                            view.DisplayLocation(locations);
                            List<tblSubrubID> subrubIDs = storageManager.GetTblSubrubIDs();
                            view.DisplaySubrub(subrubIDs);
                            view.DisplayMessage("Enter the Location ID that relates to the Suburb ID you wish to update");
                            Console.WriteLine("(Refrence data above)");
                            int SuburbID = view.GetIntInput();
                            view.DisplayMessage($"What do you want to change {SuburbID}'s ID to:");
                            string Change = view.GetInput();
                            string rowsAffected = storageManager.UpdateLocation(FieldChoiceName, SuburbID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "4":
                        {
                            loop = false;
                            string FieldChoiceName = "StreetID";
                            List<tblLocation> locations = storageManager.GetTblLocations();
                            view.DisplayLocation(locations);
                            List<tblStreetID> streetIDs = storageManager.GetTblStreetIDs();
                            view.DisplayStreetID(streetIDs);
                            view.DisplayMessage("Enter the Location ID that relates to the Street ID you wish to update");
                            Console.WriteLine("(Refrence data above)");
                            int StreetID = view.GetIntInput();
                            view.DisplayMessage($"What do you want to change {StreetID}'s ID to:");
                            string Change = view.GetInput();
                            string rowsAffected = storageManager.UpdateLocation(FieldChoiceName, StreetID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "5":
                        {
                            loop = false;
                            string FieldChoiceName = "CountryID";
                            List<tblLocation> locations = storageManager.GetTblLocations();
                            view.DisplayLocation(locations);
                            List<tblLocationCountry> countries = storageManager.GetTblLocationCountries();
                            view.DisplayCountry(countries);
                            view.DisplayMessage("Enter the Location ID that relates to the Country ID you wish to update");
                            Console.WriteLine("(Refrence data above)");
                            int CountryID = view.GetIntInput();
                            view.DisplayMessage($"What do you want to change {CountryID}'s ID to:");
                            string Change = view.GetInput();
                            string rowsAffected = storageManager.UpdateLocation(FieldChoiceName, CountryID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "6":
                        {
                            loop = false;
                            string FieldChoiceName = "StreetNumber ";
                            List<tblLocation> locations = storageManager.GetTblLocations();
                            view.DisplayLocation(locations);
                            List<tblLocationCountry> countries = storageManager.GetTblLocationCountries();
                            view.DisplayCountry(countries);
                            view.DisplayMessage("Enter the Location ID that relates to the Street Number  you wish to update");
                            Console.WriteLine("(Refrence data above)");
                            int StreetNumber = view.GetIntInput();
                            view.DisplayMessage($"What do you want to change {StreetNumber}'s ID to:");
                            string Change = view.GetInput();
                            string rowsAffected = storageManager.UpdateLocation(FieldChoiceName, StreetNumber, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option please try again.");
                        loop = true;
                        break;
                }
            }
            while (loop);
        }

        private static void Updatesubrub()
        {
            bool loop = true;
            do
            {
                view.DisplayUpdatesubrub();
                string FieldChoice = view.GetInput();
                switch (FieldChoice)
                {
                    case "1":
                        {
                            loop = false;
                            string FieldChoiceName = "Subrub";
                            List<tblSubrubID> subrubIDs = storageManager.GetTblSubrubIDs();
                            view.DisplaySubrub(subrubIDs);
                            view.DisplayMessage("Enter the Suburb ID that relates to the Subrub Name you wish to update");
                            Console.WriteLine("(Refrence data above)");
                            int LocationID = view.GetIntInput();
                            view.DisplayMessage($"What do you want to change {LocationID}'s Name to:");
                            string Change = view.GetInput();
                            string rowsAffected = storageManager.Updatesubrub(FieldChoiceName, LocationID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "2":
                        {
                            loop = false;
                            string FieldChoiceName = "PostCode";
                            List<tblSubrubID> subrubIDs = storageManager.GetTblSubrubIDs();
                            view.DisplaySubrub(subrubIDs);
                            view.DisplayMessage("Enter the Suburb ID that relates to the Post Code you wish to update");
                            Console.WriteLine("(Refrence data above)");
                            int CityID = view.GetIntInput();
                            view.DisplayMessage($"What do you want to change {CityID}'s ID to:");
                            string Change = view.GetInput();
                            string rowsAffected = storageManager.Updatesubrub(FieldChoiceName, CityID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option please try again.");
                        loop = true;
                        break;
                }
            }
            while (loop);
        }

        private static void UpdateDept()
        {
            bool loop = true;
            do
            {
                view.DisplayUpdateDept();
                string FieldChoice = view.GetInput();
                switch (FieldChoice)
                {
                    case "1":
                        {
                            loop = false;
                            string FieldChoiceName = "Departments";
                            List<tblDepartments> departments = storageManager.GetTblDepartments();
                            view.DisplayDepartments(departments);
                            view.DisplayMessage("Enter the Department ID that relates to the Department Name you wish to update");
                            Console.WriteLine("(Refrence data above)");
                            int LocationID = view.GetIntInput();
                            view.DisplayMessage($"What do you want to change {LocationID}'s Name to:");
                            string Change = view.GetInput();
                            string rowsAffected = storageManager.UpdateDept(FieldChoiceName, LocationID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "2":
                        {
                            loop = false;
                            string FieldChoiceName = "ManagersID";
                            List<tblLocation> locations = storageManager.GetTblLocations();
                            view.DisplayLocation(locations);
                            view.DisplayMessage("Enter the Department ID that relates to the Managers ID you wish to update");
                            Console.WriteLine("(Refrence data above)");
                            int CityID = view.GetIntInput();
                            view.DisplayMessage($"What do you want to change {CityID}'s ID to:");
                            string Change = view.GetInput();
                            string rowsAffected = storageManager.UpdateDept(FieldChoiceName, CityID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option please try again.");
                        loop = true;
                        break;
                }
            }
            while (loop);
        }



        private static void DeleteCity()
        {
            List<tblCityID> cityIDs = storageManager.GetTblCityIDs();
            view.DisplayCity(cityIDs);
            view.DisplayMessage("Enter the City id you wish to Delete");
            Console.WriteLine("(Refrence data above)");
            int CityName = view.GetIntInput();
            int rowsAffected = storageManager.DeleteCity(CityName);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void DeleteDepartment()
        {
            List<tblDepartments> departments = storageManager.GetTblDepartments();
            view.DisplayDepartments(departments);
            view.DisplayMessage("Enter the Department ID you wish to Delete");
            Console.WriteLine("(Refrence data above)");
            int DepartmentID = view.GetIntInput();
            int rowsAffected = storageManager.DeleteDepartment(DepartmentID);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void DeleteEmployeeDetails()
        {
            List<tblEmployeeDetails> employee = storageManager.GetTblEmployeeDetails();
            view.DisplayEmployeeDetails(employee);
            view.DisplayMessage("Enter the Employee ID you wish to Delete");
            Console.WriteLine("(Refrence data above)");
            int EmployeeID = view.GetIntInput();
            int rowsAffected = storageManager.DeleteEmployeeDetails(EmployeeID);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void DeleteRoleName()
        {
            List<tblEmployeeRoleName> roleNames = storageManager.GetTblEmployeeRoleNames();
            view.DisplayRoleNames(roleNames);
            view.DisplayMessage("Enter the Role ID you wish to Delete");
            Console.WriteLine("(Refrence data above)");
            int RoleID = view.GetIntInput();
            int rowsAffected = storageManager.DeleteRoleName(RoleID);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void DeleteJobtitle()
        {
            List<tblJobtitle> jobTittle = storageManager.GetEmployeeTblJobTittles();
            view.DisplaytblJobTittles(jobTittle);
            view.DisplayMessage("Enter the Job Title ID you wish to Delete");
            Console.WriteLine("(Refrence data above)");
            int JobTitleID = view.GetIntInput();
            int rowsAffected = storageManager.DeleteJobtitle(JobTitleID);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void DeleteStreet()
        {
            List<tblStreetID> streetIDs = storageManager.GetTblStreetIDs();
            view.DisplayStreetID(streetIDs);
            view.DisplayMessage("Enter the Street ID you wish to Delete");
            Console.WriteLine("(Refrence data above)");
            int StreetID = view.GetIntInput();
            int rowsAffected = storageManager.DeleteStreet(StreetID);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void DeleteSuburb()
        {
            List<tblSubrubID> subrubIDs = storageManager.GetTblSubrubIDs();
            view.DisplaySubrub(subrubIDs);
            view.DisplayMessage("Enter the Suburb ID you wish to Delete");
            Console.WriteLine("(Refrence data above)");
            int SuburbID = view.GetIntInput();
            int rowsAffected = storageManager.DeleteSuburb(SuburbID);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void DeleteCountry()
        {
            List<tblLocationCountry> countries = storageManager.GetTblLocationCountries();
            view.DisplayCountry(countries);
            view.DisplayMessage("Enter the Country ID you wish to Delete");
            Console.WriteLine("(Refrence data above)");
            int CountryID = view.GetIntInput();
            int rowsAffected = storageManager.DeleteCountry(CountryID);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void DeleteLocation()
        {
            List<tblLocation> locations = storageManager.GetTblLocations();
            view.DisplayLocation(locations);
            view.DisplayMessage("Enter the Location ID you wish to Delete");
            Console.WriteLine("(Refrence data above)");
            int LocationID = view.GetIntInput();
            int rowsAffected = storageManager.DeleteLocation(LocationID);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }





        private static void InsertLocation()
        {
            bool Active = true;
            view.DisplayMessage("Enter the new Location Name");
            string LocationName = view.GetInput();
            view.DisplayMessage("Enter the Country ID's of the Location");
            int CountryID = view.GetIntInput();
            view.DisplayMessage("Enter the Suburb ID's of the Location");
            int SuburbID = view.GetIntInput();
            view.DisplayMessage("Enter the Street ID's of the Location");
            int StreetID = view.GetIntInput();
            view.DisplayMessage("Enter the City ID's of the Location");
            int CityID = view.GetIntInput();
            view.DisplayMessage("Enter the Street Number's of the Location");
            int StreetNumber = view.GetIntInput();
            int LocationID = 0;
            tblLocation location1 = new tblLocation(LocationID, LocationName, CountryID, SuburbID, StreetID, CityID, StreetNumber, Active);
            int GenerateID = storageManager.InsertLocation(LocationName, CountryID, SuburbID, StreetID, CityID, StreetNumber);
            view.DisplayMessage($"new Location Created with ID {GenerateID}");
        }

        private static void InsertEmployeeDetails()
        {
            bool Active = true;
            view.DisplayMessage("Enter the First Name of the new Employee");
            string FirstName = view.GetInput();
            view.DisplayMessage("Enter the Last Name of the new Employee");
            string LastName = view.GetInput();
            view.DisplayMessage("Enter the Hire Date of New Employee");
            DateTime HireDate = Convert.ToDateTime(Console.ReadLine());
            view.DisplayMessage("Enter The Gender of the New Employee ");
            view.DisplayMessage("F for a Female Employee \t M for a Male Employee");
            string Gender = view.GetInput().ToUpper();
            view.DisplayMessage("Enter the Job ID of the New Employee");
            int JobID = view.GetIntInput();
            view.DisplayMessage("Enter the Username of the New Employee");
            string Username = view.GetInput();
            view.DisplayMessage("Enter the Password of the New Employee ");
            string Password = view.GetInput();
            view.DisplayMessage("Enter the Role Of the New Employee");
            view.DisplayMessage("1 For Employee\t 2 For Admin ");
            int Role = view.GetIntInput();
            view.DisplayMessage("Enter the Email of the New Employee");
            string Email = view.GetInput();
            view.DisplayMessage("Enter the Phone Number of the New Employee");
            int Phonenumber = view.GetIntInput();
            view.DisplayMessage("Enter the Wage for the New Employee");
            int wage = view.GetIntInput();
            int EmployeeID = 0;
            tblEmployeeDetails location1 = new tblEmployeeDetails(EmployeeID, FirstName, LastName, HireDate, Gender, JobID, Role, Password, Username, Active, Email, Phonenumber, wage);
            int GenerateID = storageManager.InsertEmployeeDetails(FirstName, LastName, HireDate, Gender, JobID, Role, Password, Username, Email, Phonenumber, wage);
            view.DisplayMessage($"new Employee Created with ID {GenerateID}");
        }

        private static void InsertRoleName()
        {
            bool Active = true;
            view.DisplayMessage("Enter the new Role Name");
            string StreetName = view.GetInput();
            int StreetID = 0;
            tblEmployeeRoleName location1 = new tblEmployeeRoleName(StreetID, StreetName, Active);
            int GenerateID = storageManager.InsertRoleName(StreetName);
            view.DisplayMessage($"new Role Created with ID {GenerateID}");
        }

        private static void InsertJobtitle()
        {
            bool Active = true;
            view.DisplayMessage("Enter the new Job Title Name");
            string StreetName = view.GetInput();
            int StreetID = 0;
            tblJobtitle location1 = new tblJobtitle(StreetID, StreetName, Active);
            int GenerateID = storageManager.InsertJobtitle(StreetName);
            view.DisplayMessage($"new department Created with ID {GenerateID}");
        }

        private static void InsertDepartment()
        {
            bool Active = true;
            view.DisplayMessage("Enter the new Department Name");
            string StreetName = view.GetInput();
            view.DisplayMessage("Enter the Manager's Employee ID of the Department");
            int postcode = view.GetIntInput();
            int StreetID = 0;
            tblDepartments location1 = new tblDepartments(StreetName, StreetID, postcode, Active);
            int GenerateID = storageManager.InsertDepartment(StreetName, postcode);
            view.DisplayMessage($"new department Created with ID {GenerateID}");
        }

        private static void InsertCity()
        {
            bool Active = true;
            view.DisplayMessage("Enter the new City Name");
            string StreetName = view.GetInput();
            int StreetID = 0;
            tblCityID location1 = new tblCityID(StreetID, StreetName, Active);
            int GenerateID = storageManager.InsertCity(StreetName);
            view.DisplayMessage($"new City Created with ID {GenerateID}");
        }

        private static void InsertStreet()
        {
            bool Active = true;
            view.DisplayMessage("Enter the new Street Name");
            string StreetName = view.GetInput();
            int StreetID = 0;
            tblStreetID location1 = new tblStreetID(StreetID, StreetName, Active);
            int GenerateID = storageManager.InsertStreet(StreetName);
            view.DisplayMessage($"new Street Created with ID {GenerateID}");
        }

        private static void InsertSuburb()
        {
            bool Active = true;
            view.DisplayMessage("Enter the new suburb Name");
            string StreetName = view.GetInput();
            view.DisplayMessage("Enter the Post Code of the suburb");
            int postcode = view.GetIntInput();
            int StreetID = 0;
            tblSubrubID location1 = new tblSubrubID(StreetID, StreetName, postcode, Active);
            int GenerateID = storageManager.InsertSuburb(StreetName, postcode);
            view.DisplayMessage($"new subrub Created with ID {GenerateID}");
        }

        private static void InsertCountry()
        {
            bool Active = true;
            view.DisplayMessage("Enter the new Country Name");
            string StreetName = view.GetInput();
            int StreetID = 0;
            tblLocationCountry location1 = new tblLocationCountry(StreetID, StreetName, Active);
            int GenerateID = storageManager.InsertCountry(StreetName);
            view.DisplayMessage($"new Country Created with ID {GenerateID}");
        }
    }
}