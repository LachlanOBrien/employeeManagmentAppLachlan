using Azure;
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

        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!");
            //scl connectionString
            //string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\AC147303\\ONEDRIVE - AVONDALE COLLEGE\\DOCUMENTS\\12TPI\\SQL\\DB\\DB2V2.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            //home connectionString
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=db2v2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            storageManager = new StorageManager(connectionString);
            view = new consoleView();

            //temp log in / role function
            //Console.WriteLine("enter the role you wish to be 1 for employee 2 for admin");
            //role = Convert.ToInt32(Console.ReadLine());
            //SwitchMainAdmin(); 
            MainMenu();
            storageManager.CloseConnection(); // closes the connection with the database.
        }

        public static void MainMenu()
        {

            bool NotValidMain = true;
            string tblchoice;
            string choice;
            bool loop = true;
            bool logInBool = true;
            string employeeChoice;
            string MainChoice;
            do // loops this until a valid option has been entered 
            {
                view.MainMenu(); // displays the option for the user 
                MainChoice = view.GetInput(); // gets the users input 
                switch (MainChoice)
                {

                    case "1":
                        {
                            Console.Clear();
                            LogIn(); // calls the log in method 
                            loop = false;
                        }
                        break;
                    case "2":
                        {
                            Console.Clear();
                            RegisterEmployee(); // calls the register method 
                            loop = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please enter a valid option");// gives the user a propper error message telling them to enter a valid username or password
                            logInBool = true;
                        }
                        break;
                }
            } while (loop);
        }

        // the main switch case for the program.
        public static void SwitchMainAdmin()
        {

            Console.Clear();
            //int role = Role;
            bool NotValidMain = true;
            string tblchoice;
            string choice;
            bool loop = true;
            bool logInBool = true;
            string employeeChoice;
            logInBool = false;
            Console.WriteLine("welcome admin");
            do
            {
                do
                {
                    view.DisplayQryOrUpdate();
                    string choiceQry = view.GetInput();
                    switch (choiceQry)
                    {
                        case "1":
                            {
                                DisplayQrySwitch();
                                loop = false;
                                NotValidMain = false;
                            }
                            break;
                        case "2":
                            {
                                DisplayUpdatesSwitch();
                                loop = false;
                                NotValidMain = false;
                            }
                            break;
                        case "3":
                            {
                                searchQrySwitch();
                                loop = false;
                                NotValidMain = false;
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("Please enter a valid Username and Password");
                                loop = true;
                                NotValidMain = true;
                            }
                            break;
                    }
                } while (NotValidMain);
                bool MainMenuLoop = true;
                do
                {
                    Console.WriteLine("Do you wish to go back to the main menu enter Y/N");
                    string choiceloopans = view.GetInput().ToUpper();
                    switch (choiceloopans)
                    {
                        case "Y":
                            {
                                MainMenuLoop = false;
                                loop = true;
                            }
                            break;
                        case "N":
                            {
                                Console.Clear();
                                Console.WriteLine("Good-Bye");
                                MainMenuLoop = false;
                                loop = false;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid option please try again.");
                            NotValidMain = false;
                            break;
                    }
                } while (MainMenuLoop);
            } while (loop);
        }

        public static void searchQrySwitch()
        {
            string Table = "";
            string Field = "";
            string choice = "";
            bool NotValidMain = true;
            bool loop = true;
            string TableChoice;
            string FieldChoice; 
            int TableChoiceInt;
            int FieldChoiceInt;
            Console.Clear ();
            do
            {
                view.DisplayTables();
                TableChoiceInt = view.GetIntInput();
                TableChoice = TableChoiceInt.ToString();
                switch (TableChoice)
                {
                    case "1":
                        {
                            NotValidMain = false;
                            Table = "Employee.tblEmployeesDetails";
                            do
                            {
                                view.DisplayEmployeeDetailsFields();
                                FieldChoiceInt = view.GetIntInput();
                                FieldChoice = FieldChoiceInt.ToString();
                                switch (FieldChoice)
                                {
                                    case "1":
                                        {
                                            loop = false;
                                            Field = "EmployeeID";
                                        }
                                        break;
                                    case "2":
                                        {
                                            loop = false;
                                            Field = "FirstName";
                                        }
                                        break;
                                    case "3":
                                        {
                                            loop = false;
                                            Field = "LastName";
                                        }
                                        break;
                                    case "4":
                                        {
                                            loop = false;
                                            Field = "HireDate";
                                        }
                                        break;
                                    case "5":
                                        {
                                            loop = false;
                                            Field = "JobID";
                                        }
                                        break;
                                    case "6":
                                        {
                                            loop = false;
                                            Field = "RoleID";
                                        }
                                        break;
                                    case "7":
                                        {
                                            loop = false;
                                            Field = "Email";
                                        }
                                        break;
                                    case "8":
                                        {
                                            loop = false;
                                            Field = "PhoneNumber";
                                        }
                                        break;
                                    case "9":
                                        {
                                            loop = false;
                                            Field = "Wage";
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("Invalid option please try again.");
                                            loop = true;
                                        }
                                        break;
                                }
                            } while (loop);
                            if (Field.Equals("HireDate"))
                            {
                                Console.WriteLine("what date do you wish to see ");
                                Console.WriteLine("Use the format dd-mm-yyyy");
                                choice = Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine($"what {Field} do you wish to see:");
                                choice = view.GetInput();
                            }
                            List<SearchEmployeeDetails> employee = storageManager.GetSearchQryEmpDet(Table, Field, choice);
                            view.DisplaySearchEmployeeDetailsPages(employee);

                        }
                        break;
                    case "2":
                        {
                            NotValidMain = false;
                            Table = "Location.tblLocation";
                            do
                            {
                                view.DisplayLocationFields();
                                FieldChoiceInt = view.GetIntInput();
                                FieldChoice = FieldChoiceInt.ToString();
                                switch (FieldChoice)
                                {
                                    case "1":
                                        {
                                            loop = false;
                                            Field = "LocationID";
                                        }
                                        break;
                                    case "2":
                                        {
                                            loop = false;
                                            Field = "LocationName";
                                        }
                                        break;
                                    case "3":
                                        {
                                            loop = false;
                                            Field = "CountryID";
                                        }
                                        break;
                                    case "4":
                                        {
                                            loop = false;
                                            Field = "SuburbID";
                                        }
                                        break;
                                    case "5":
                                        {
                                            loop = false;
                                            Field = "StreetID";
                                        }
                                        break;
                                    case "6":
                                        {
                                            loop = false;
                                            Field = "CityID";
                                        }
                                        break;
                                    case "7":
                                        {
                                            loop = false;
                                            Field = "StreetNumber";
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("Invalid option please try again.");
                                            loop = true;
                                        }
                                        break;
                                }
                            } while (loop);
                            Console.WriteLine($"what {Field} do you wish to see:");
                            choice = view.GetInput();
                            List<SearchLocation> locations = storageManager.GetSearchQryLocation(Table, Field, choice);
                            view.DisplaySearchLocationPages(locations);
                        }
                        break;
                    case "3":
                        {
                            NotValidMain = false;
                            Table = "Employee.tblEmployeeRoleName";
                            do
                            {
                                view.DisplayRoleNamesFields();
                                FieldChoiceInt = view.GetIntInput();
                                FieldChoice = FieldChoiceInt.ToString();
                                switch (FieldChoice)
                                {
                                    case "1":
                                        {
                                            loop = false;
                                            Field = "RoleID";
                                        }
                                        break;
                                    case "2":
                                        {
                                            loop = false;
                                            Field = "RoleName";
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("Invalid option please try again.");
                                            loop = true;
                                        }
                                        break;
                                }
                            } while (loop);
                            Console.WriteLine($"what {Field} do you wish to see:");
                            choice = view.GetInput();
                            List<SearchEmployeeRoleName> roleNames = storageManager.GetSearchQryRoleName(Table, Field, choice);
                            view.DisplaySearchRoleNamesPages(roleNames);
                        }
                        break;
                    case "4":
                        {
                            NotValidMain = false;
                            Table = "Location.tblDepartments";
                            do
                            {
                                view.DisplayDepartmentsFields();
                                FieldChoiceInt = view.GetIntInput();
                                FieldChoice = FieldChoiceInt.ToString();
                                switch (FieldChoice)
                                {
                                    case "1":
                                        {
                                            loop = false;
                                            Field = "DepartmentID";
                                        }
                                        break;
                                    case "2":
                                        {
                                            loop = false;
                                            Field = "DepartmentName";
                                        }
                                        break;
                                    case "3":
                                        {
                                            loop = false;
                                            Field = "ManagersID";
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("Invalid option please try again.");
                                            loop = true;
                                        }
                                        break;
                                }
                            } while (loop);
                            Console.WriteLine($"what {Field} do you wish to see:");
                            choice = view.GetInput();
                            List<SearchDepartments> departments = storageManager.GetSearchQryDepartments(Table, Field, choice);
                            view.DisplaySearchDepartmentsPages(departments);
                        }
                        break;
                    case "5":
                        {
                            NotValidMain = false;
                            Table = "Employee.tblJobTitles";
                            do
                            {
                                view.DisplayJobTitlesFields();
                                FieldChoiceInt = view.GetIntInput();
                                FieldChoice = FieldChoiceInt.ToString();
                                switch (FieldChoice)
                                {
                                    case "1":
                                        {
                                            loop = false;
                                            Field = "JobTitleID";
                                        }
                                        break;
                                    case "2":
                                        {
                                            loop = false;
                                            Field = "JobTitleName";
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("Invalid option please try again.");
                                            loop = true;
                                        }
                                        break;
                                }
                            } while (loop);
                            Console.WriteLine($"what {Field} do you wish to see:");
                            choice = view.GetInput();
                            List<SearchJobtitle> jobTittle = storageManager.GetSearchQryJobTitles(Table, Field, choice);
                            view.DisplaySearchJobTittlesPages(jobTittle);
                        }
                        break;
                    case "6":
                        {
                            NotValidMain = false;
                            Table = "location.tblLocationCity";
                            do
                            {
                                view.DisplayCitysFields();
                                FieldChoiceInt = view.GetIntInput();
                                FieldChoice = FieldChoiceInt.ToString();
                                switch (FieldChoice)
                                {
                                    case "1":
                                        {
                                            loop = false;
                                            Field = "CityID";
                                        }
                                        break;
                                    case "2":
                                        {
                                            loop = false;
                                            Field = "CityName";
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("Invalid option please try again.");
                                            loop = true;
                                        }
                                        break;
                                }
                            } while (loop);
                            Console.WriteLine($"what {Field} do you wish to see:");
                            choice = view.GetInput();
                            List<SearchLocationCountry> countries = storageManager.GetSearchQryCountry(Table, Field, choice);
                            view.DisplaySearchCountryPages(countries);

                        }
                        break;
                    case "7":
                        {
                            NotValidMain = false;
                            Table = "Location.tblLocationCountry";
                            do
                            {
                                view.DisplayCountryFields();
                                FieldChoiceInt = view.GetIntInput();
                                FieldChoice = FieldChoiceInt.ToString();
                                switch (FieldChoice)
                                {
                                    case "1":
                                        {
                                            loop = false;
                                            Field = "CountryID";
                                        }
                                        break;
                                    case "2":
                                        {
                                            loop = false;
                                            Field = "CountryName";
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("Invalid option please try again.");
                                            loop = true;
                                        }
                                        break;
                                }
                            } while (loop);
                            Console.WriteLine($"what {Field} do you wish to see:");
                            choice = view.GetInput();
                            List<SearchStreetID> streetIDs = storageManager.GetSearchQryStreet(Table, Field, choice);
                            view.DisplaySearchStreetIDPages(streetIDs);
                        }
                        break;
                    case "8":
                        {
                            NotValidMain = false;
                            Table = "Location.tblLocationStreet";
                            do
                            {
                                view.DisplayStreetsFields();
                                FieldChoiceInt = view.GetIntInput();
                                FieldChoice = FieldChoiceInt.ToString();
                                switch (FieldChoice)
                                {
                                    case "1":
                                        {
                                            loop = false;
                                            Field = "StreetID";
                                        }
                                        break;
                                    case "2":
                                        {
                                            loop = false;
                                            Field = "StreetName";
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("Invalid option please try again.");
                                            loop = true;
                                        }
                                        break;
                                }
                            } while (loop);
                            Console.WriteLine($"what {Field} do you wish to see:");
                            choice = view.GetInput();                          
                            List<SearchStreetID> subrubIDs = storageManager.GetSearchQryStreet(Table, Field, choice);
                            view.DisplaySearchStreetIDPages(subrubIDs);
                        }
                        break;
                    case "9":
                        {
                            NotValidMain = false;
                            Table = "Location.tblLocationSuburb";
                            do
                            {
                                view.DisplaySuburbsFields();
                                FieldChoiceInt = view.GetIntInput();
                                FieldChoice = FieldChoiceInt.ToString();
                                switch (FieldChoice)
                                {
                                    case "1":
                                        {
                                            loop = false;
                                            Field = "SuburbID";
                                        }
                                        break;
                                    case "2":
                                        {
                                            loop = false;
                                            Field = "Suburb";
                                        }
                                        break;
                                    case "3":
                                        {
                                            loop = false;
                                            Field = "PostCode";
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("Invalid option please try again.");
                                            loop = true;
                                        }
                                        break;
                                }
                            } while (loop);
                            Console.WriteLine($"what {Field} do you wish to see:");
                            choice = view.GetInput();
                            storageManager.GetSearchQrySuburb(Table, Field, choice);
                            List<SearchSubrubID> subrubIDs = storageManager.GetSearchQrySuburb(Table, Field, choice);
                            view.DisplaySearchSubrubPages(subrubIDs);

                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Invalid option please try again.");
                            NotValidMain = true;
                        }
                        break;
                }
            } while (NotValidMain);
        }

        // the switch case for employees 
        public static void SwitchMainEmp(int EmployeeID)
        {
            string Choice;
            bool NotValidMain = true;
            bool loop = true;
            int employeeID = EmployeeID;
            Console.Clear();
            //Console.WriteLine("HAHA pleb employee");
            do
            {
                do
                {
                    view.EmpDisplayMenu();
                    Choice = view.GetInput();
                    switch (Choice)
                    {
                        case "1":
                            {
                                List<tblEmployeeDetails> employee = storageManager.GetTblEmployeeDetails();
                                view.DisplayEmpEmployeeDetailsPage(employee, employeeID);
                                NotValidMain = false;
                            }
                            break;
                        case "2":
                            {
                                UpdateEmpEmployeeDetails(EmployeeID);
                                NotValidMain = false;
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("Invalid option please try again.");
                                NotValidMain = true;
                            }
                            break;
                    }
                } while (NotValidMain);
                bool MainMenuLoop = true;
                do
                {
                    Console.WriteLine("Do you wish to go back to the main menu enter Y/N");
                    string choiceloopans = view.GetInput().ToUpper();
                    switch (choiceloopans)
                    {
                        case "Y":
                            {
                                MainMenuLoop = false;
                                NotValidMain = true;
                            }
                            break;
                        case "N":
                            {
                                Console.Clear();
                                Console.WriteLine("Good-Bye");
                                MainMenuLoop = false;
                                NotValidMain = false;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid option please try again.");
                            NotValidMain = false;
                            break;
                    }
                } while (MainMenuLoop);
            } while (NotValidMain);
        }
        // the main switch for the updates 
        public static void DisplayUpdatesSwitch()
        {
            bool NotValidMain = false;
            do
            {
                Console.Clear();
                NotValidMain = false;
                view.TblDisplayMenu();
                string tblchoice = view.GetInput();
                switch (tblchoice)
                {
                    case "1":
                        {
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
                            NotValidMain = true;
                        }
                        break;
                }
                
            } while (NotValidMain);
        }
        // the switch cases for which qry the user wants to access 
        public static void DisplayQrySwitch()
        {
            bool Loop = true;
            do
            {
                view.DisplayQryOptions();
                string Choice = view.GetInput();
                switch (Choice)
                {

                    case "1":
                        {
                            storageManager.AdvancedQuery1();
                            Loop = false;
                        }
                        break;
                    case "2":
                        {
                            storageManager.AdvancedQuery2();
                            Loop = false;
                        }
                        break;
                    case "3":
                        {
                            storageManager.AdvancedQuery3();
                            Loop = false;
                        }
                        break;
                    case "4":
                        {
                            storageManager.AdvancedQuery4();
                            Loop = false;
                        }
                        break;
                    case "5":
                        {
                            storageManager.AdvancedQuery5();
                            Loop = false;
                        }
                        break;
                    case "6":
                        {
                            storageManager.ComplexQuery1();
                            Loop = false;
                        }
                        break;
                    case "7":
                        {
                            storageManager.ComplexQuery2();
                            Loop = false;
                        }
                        break;
                    case "8":
                        {
                            storageManager.ComplexQuery3();
                            Loop = false;
                        }
                        break;
                    case "9":
                        {
                            storageManager.ComplexQuery4();
                            Loop = false;
                        }
                        break;
                    case "10":
                        {
                            storageManager.ComplexQuery5();
                            Loop = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Invalid option please try again.");
                            Loop = true;
                        }
                        break;

                }
            } while (Loop);
        }

        // displays the options for a table 
        public static void displaySwitch1()
        {
            string choice;
            bool Notvalid = true;
            do
            {
                choice = view.GetInput();
                switch (choice)
                {
                    case "1":
                        {
                            List<tblEmployeeDetails> employee = storageManager.GetTblEmployeeDetails();
                            view.DisplayEmployeeDetailsPages(employee);
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
        // displays the options for a table 
        public static void displaySwitch2()
        {
            string choice;
            bool Notvalid = true;
            do
            {
                choice = view.GetInput();
                switch (choice)
                {
                    case "1":
                        {
                            List<tblLocation> locations = storageManager.GetTblLocations();
                            view.DisplayLocationPages(locations);
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
        // displays the options for a table 
        public static void displaySwitch3()
        {
            string choice;
            bool Notvalid = true;
            do
            {
                choice = view.GetInput();
                switch (choice)
                {
                    case "1":
                        {
                            List<tblEmployeeRoleName> roleNames = storageManager.GetTblEmployeeRoleNames();
                            view.DisplayRoleNamesPages(roleNames);
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
        // displays the options for a table 
        public static void displaySwitch4()
        {
            string choice;
            bool Notvalid = true;
            do
            {
                choice = view.GetInput();
                switch (choice)
                {
                    case "1":
                        {
                            List<tblDepartments> departments = storageManager.GetTblDepartments();
                            view.DisplayDepartmentsPages(departments);
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
        // displays the options for a table 
        public static void displaySwitch5()
        {
            string choice;
            bool Notvalid = true;
            do
            {
                choice = view.GetInput();
                switch (choice)
                {
                    case "1":
                        {
                            List<tblJobtitle> jobTittle = storageManager.GetEmployeeTblJobTittles();
                            view.DisplaytblJobTittlesPages(jobTittle);
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
        // displays the options for a table 
        public static void displaySwitch6()
        {
            string choice;
            bool Notvalid = true;
            do
            {
                choice = view.GetInput();
                switch (choice)
                {
                    case "1":
                        {
                            List<tblLocationCountry> countries = storageManager.GetTblLocationCountries();
                            view.DisplayCountryPages(countries);
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
        // displays the options for a table 
        public static void displaySwitch7()
        {
            string choice;
            bool Notvalid = true;
            do
            {
                choice = view.GetInput();
                switch (choice)
                {
                    case "1":
                        {
                            List<tblStreetID> streetIDs = storageManager.GetTblStreetIDs();
                            view.DisplayStreetIDPages(streetIDs);
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
        // displays the options for a table 
        public static void displaySwitch8()
        {
            string choice;
            bool Notvalid = true;
            do
            {
                choice = view.GetInput();
                switch (choice)
                {
                    case "1":
                        {
                            List<tblSubrubID> subrubIDs = storageManager.GetTblSubrubIDs();
                            view.DisplaySubrubPages(subrubIDs);
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
        // displays the options for a table 
        public static void displaySwitch9()
        {
            string choice;
            bool Notvalid = true;
            do
            {
                choice = view.GetInput();
                switch (choice)
                {
                    case "1":
                        {
                            List<tblCityID> cityIDs = storageManager.GetTblCityIDs();
                            view.DisplayCityPages(cityIDs);
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




        //updates the RoleName table in the database
        private static void UpdateRoleName()
        {
            List<tblEmployeeRoleName> employee = storageManager.GetTblEmployeeRoleNames();
            view.DisplayRoleNames(employee);
            view.DisplayMessage("Enter the Role Name to update");
            Console.WriteLine("(Refrence data above)");
            string roleName = view.GetInput();
            view.DisplayMessage($"What do you want to change {roleName} to:");
            string RoleNameChange = view.GetInput();
            string rowsAffected = storageManager.UpdateRoleName(roleName, RoleNameChange);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
        //updates the JobTitle table in the database 
        private static void UpdateJobTitle()
        {
            List<tblJobtitle> employee = storageManager.GetEmployeeTblJobTittles();
            view.DisplaytblJobTittles(employee);
            view.DisplayMessage("Enter the Job Title to update");
            Console.WriteLine("(Refrence data above)");
            string JobTitle = view.GetInput();
            view.DisplayMessage($"What do you want to change {JobTitle} to:");
            string JobTitleChange = view.GetInput();
            string rowsAffected = storageManager.UpdateJobTitle(JobTitle, JobTitleChange);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
        //updates the LocationStreet table in the database
        private static void UpdateLocationStreet()
        {
            List<tblStreetID> employee = storageManager.GetTblStreetIDs();
            view.DisplayStreetID(employee);
            view.DisplayMessage("Enter the Street Name to update");
            Console.WriteLine("(Refrence data above)");
            string StreetName = view.GetInput();
            view.DisplayMessage($"What do you want to change {StreetName} to:");
            string StreetNameChange = view.GetInput();
            string rowsAffected = storageManager.UpdateLocationStreet(StreetName, StreetNameChange);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
        //updates the Country table in the database
        private static void UpdateLocationCountry()
        {
            List<tblLocationCountry> employee = storageManager.GetTblLocationCountries();
            view.DisplayCountry(employee);
            view.DisplayMessage("Enter the Country Name to update");
            Console.WriteLine("(Refrence data above)");
            string CountryName = view.GetInput();
            view.DisplayMessage($"What do you want to change {CountryName} to:");
            string CountryNameChange = view.GetInput();
            string rowsAffected = storageManager.UpdateLocationCountry(CountryName, CountryNameChange);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
        //updates the City table in the database
        private static void UpdateLocationCity()
        {
            List<tblCityID> employee = storageManager.GetTblCityIDs();
            view.DisplayCity(employee);
            view.DisplayMessage("Enter the City Name to update");
            Console.WriteLine("(Refrence data above)");
            string CityName = view.GetInput();
            view.DisplayMessage($"What do you want to change {CityName} to:");
            string CityNameChange = view.GetInput();
            string rowsAffected = storageManager.UpdateLocationCity(CityName, CityNameChange);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
        //updates the EmployeeDetails table in the database
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
                            view.DisplayMessage($"What do you want to change {EmployeeID}'s Email to:");
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
                            view.DisplayMessage($"What do you want to change {EmployeeID}'s Phone Number to:");
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

        private static void UpdateEmpEmployeeDetails(int EmployeeID)
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
                            view.DisplayMessage($"What do you want to change Your First Name to:");
                            string FirstNameChange = view.GetInput();
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, EmployeeID, FirstNameChange);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "2":
                        {
                            loop = false;
                            string FieldChoiceName = "LastName";
                            view.DisplayMessage($"What do you want to change Your Last Name to:");
                            string Change = view.GetInput();
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, EmployeeID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "3":
                        {
                            loop = false;
                            string FieldChoiceName = "Gender";
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
                            view.DisplayMessage($"What do you want to change your Email to:");
                            string Change = view.GetInput();
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, EmployeeID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "5":
                        {
                            loop = false;
                            string FieldChoiceName = "Phonenumber";
                            view.DisplayMessage($"What do you want to change Your Phone Number to:");
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
        //updates the Location table in the database
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
        //updates the subrub table in the database
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
        //updates the Dept table in the database
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


        //Deletes a City in the database
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
        //Deletes a Department in the database
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
        //Deletes a EmployeeDetails in the database
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
        //Deletes a RoleName in the database
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
        //Deletes a Jobtitle in the database
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
        //Deletes a ---- in the database
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
        //Deletes a Suburb in the database
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
        //Deletes a Country in the database
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
        //Deletes a Location in the database
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




        //creates a new Location in the database
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
        //creates a new EmployeeDetails in the database
        private static void InsertEmployeeDetails()
        {
            bool Active = true;
            view.DisplayMessage("Enter the First Name of the new Employee");
            string FirstName = view.GetInput();
            view.DisplayMessage("Enter the Last Name of the new Employee");
            string LastName = view.GetInput();
            DateTime HireDate = DateTime.Now;
            view.DisplayMessage("Enter The Gender of the New Employee ");
            view.DisplayMessage("F for a Female Employee  M for a Male Employee");
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
        //creates a new RoleName in the database
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
        //creates a new Jobtitle in the database
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
        //creates a new Department in the database
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
        //creates a new City in the database
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
        //creates a new Street in the database
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
        //creates a new Suburb in the database
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
        //creates a new Country in the database
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



        private static void RegisterEmployee()
        {
            Console.WriteLine("register function");// temp add a proper method 
            Console.WriteLine("Enter A Username");
            string RegUsername = view.GetInput();
            Console.WriteLine("Enter A Password");
            string RegPassword = view.GetInput();
            int GenerateID = storageManager.RegisterEmployee(RegUsername, RegPassword);
            view.DisplayMessage($"new Employee Created with ID {GenerateID}");
            bool loop = true;
            string choice;
            do
            {
                Console.WriteLine("do you wish to go to the Log in screen Enter Y/N");
                choice = view.GetInput().ToUpper();
                switch (choice)
                {
                    case "Y":
                        {
                            LogIn();
                            loop = false;
                        }
                        break;
                    case "N":
                        {
                            Console.Clear();
                            Console.WriteLine("Good-Bye");
                           
                            loop = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option please try again.");
                        loop = false;
                        break;
                }
            } while (loop);

        }

        private static void LogIn()
        {

            bool NotValidMain = true;
            string tblchoice;
            string choice;
            bool loop = true;
            bool logInBool = true;
            string employeeChoice;

            do          //loops the log in function untill they enter a valid username or password
             {
                Console.Clear();
                 Console.WriteLine("Enter your Username");
                 string inputedUsername = view.GetInput();// gets the username
                 string Username = inputedUsername; // gets the username 
                 int EmployeeID = storageManager.getEmployeeID(inputedUsername);//gets the username 
                 string password = storageManager.getPassword(inputedUsername);//gets the password
                 role = storageManager.getRole(inputedUsername);// gets the role 
                 Console.WriteLine("Please enter your Password");
                 string inputedPassword = view.GetInput(); // gets the inputted password
                 Console.Clear();
                 if (inputedUsername.Equals( Username) && inputedPassword.Equals( password)) // checks if the employees username and password are valid 
                 {
                     if (role == 1) // checks if they are an employee
                     {
                         logInBool = false; // disables the loop
                         SwitchMainEmp(EmployeeID); // displays the switch case for employees
                     }
                     else
                     {
                         if (role == 2) // checks if they are an admin
                         {
                             logInBool = false; // disables the loop
                             SwitchMainAdmin(); // displays the switchcases for amdmins
                         }
                     }
                 }
                 else
                 {
                     Console.WriteLine("Please enter a valid Username and Password");// gives the user a propper error message telling them to enter a valid username or password
                     logInBool = true;
                 }
             } while (logInBool);
        }
    }
}