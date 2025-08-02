using Azure;
using employeeManagmentAppLachlan.Model;
using employeeManagmentAppLachlan.Repositories;
using employeeManagmentAppLachlan.View;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
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

            //Console.WriteLine("Hello, World!");
            string mdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db2v2.mdf");
            //string mdfPath = Path("..\\db2v2.mdf");
            //string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\"));
            //string mdfPath = Path.Combine(projectRoot, "db2v2.mdf");
            Console.WriteLine(mdfPath);
            string connectionString = $@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename ={mdfPath}; Integrated Security = True; Connect Timeout = 30;";

            storageManager = new StorageManager(connectionString);
            view = new consoleView();

            //temp log in / role function
            //Console.WriteLine("enter the role you wish to be 1 for employee 2 for admin");
            //role = Convert.ToInt32(Console.ReadLine());
            //SwitchMainAdmin();
            MainMenu();
            storageManager.CloseConnection(); // closes the connection with the database.
        }
        //the main menu which displays when the program is enabled
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
        //the switch case for the search function in the admin view
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
                               
                                choice = view.WithinBoundary($"what {Field} do you wish to see:", 2, 20);
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
                            
                            choice = view.WithinBoundary($"what {Field} do you wish to see:", 2, 20);
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
                            
                            choice = view.WithinBoundary($"what {Field} do you wish to see:", 2, 20);
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
                            
                            choice = view.WithinBoundary($"what {Field} do you wish to see:", 2, 20);
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
                            
                            choice = view.WithinBoundary($"what {Field} do you wish to see:", 2, 20);
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
                            
                            choice = view.WithinBoundary($"what {Field} do you wish to see:", 2, 20);
                            List<SearchCityID> countries = storageManager.GetSearchQryCity(Table, Field, choice);
                            view.DisplaySearchCityPages(countries);

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
                            
                            choice = view.WithinBoundary($"what {Field} do you wish to see:", 2, 20);
                            List<SearchLocationCountry> streetIDs = storageManager.GetSearchQryCountry(Table, Field, choice);
                            view.DisplaySearchCountryPages(streetIDs);
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
                            
                            choice = view.WithinBoundary($"what {Field} do you wish to see:", 2, 20);
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
                            
                            choice = view.WithinBoundary($"what {Field} do you wish to see:",2,20);
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
            do
            {
                do
                {
                    view.EmployeeDisplayMenu();
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
            Console.Clear();
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
                            List<AdvQry1> employee = storageManager.AdvancedQuery1();
                            view.DisplayAdvQry1(employee);
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
                            List<AdvQry3> employee = storageManager.AdvancedQuery3();
                            view.DisplayAdvQry3(employee);
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
                            List<ComplexQry5> employee = storageManager.ComplexQuery5();
                            view.DisplayComplexQry5(employee);
                        }
                        break;
                    case "11":
                        {
                            List<tblEmployeeDetails> employee = storageManager.GetTblEmployeeDetails();
                            view.DisplayEmployeeDetailsPages(employee);
                            Loop = false;
                        }
                        break;
                    case "12":
                        {
                            List<tblLocation> locations = storageManager.GetTblLocations();
                            view.DisplayLocationPages(locations);
                            Loop = false;
                        }
                        break;
                    case "13":
                        {
                            List<tblEmployeeRoleName> roleNames = storageManager.GetTblEmployeeRoleNames();
                            view.DisplayRoleNamesPages(roleNames);
                            //List<EmployeeTblEmployeesDetails> employee1 = storageManager.GetEmployeeTblEmployeesDetails();
                            //view.DisplaytblEmployeesDetails(employee1);
                            Loop = false;
                        }
                        break;
                    case "14":
                        {
                            List<tblDepartments> departments = storageManager.GetTblDepartments();
                            view.DisplayDepartmentsPages(departments);
                            Loop = false;
                        }
                        break;
                    case "15":
                        {
                            List<tblJobtitle> jobTittle = storageManager.GetEmployeeTblJobTittles();
                            view.DisplaytblJobTittlesPages(jobTittle);
                            Loop = false;
                        }
                        break;
                    case "16":
                        {
                            List<tblLocationCountry> countries = storageManager.GetTblLocationCountries();
                            view.DisplayCountryPages(countries);
                            Loop = false;
                        }
                        break;
                    case "17":
                        {
                            List<tblStreetID> streetIDs = storageManager.GetTblStreetIDs();
                            view.DisplayStreetIDPages(streetIDs);
                            Loop = false;
                        }
                        break;
                    case "18":
                        {
                            List<tblSubrubID> subrubIDs = storageManager.GetTblSubrubIDs();
                            view.DisplaySubrubPages(subrubIDs);
                            Loop = false;
                        }
                        break;
                    case "19":
                        {
                            List<tblCityID> cityIDs = storageManager.GetTblCityIDs();
                            view.DisplayCityPages(cityIDs);
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
                            UpdateEmployeeDetails();
                            Notvalid = false;

                        }
                        break;
                    case "2":
                        {
                            DeleteEmployeeDetails();
                            Notvalid = false;

                        }
                        break;
                    case "3":
                        {
                            InsertEmployeeDetails();
                            Notvalid = false;

                        }
                        break;
                    case "4":
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
                            UpdateLocation();
                            Notvalid = false;

                        }
                        break;
                    case "2":
                        {
                            DeleteLocation();
                            Notvalid = false;

                        }
                        break;
                    case "3":
                        {
                            InsertLocation();
                            Notvalid = false;

                        }
                        break;
                    case "4":
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
                            UpdateRoleName();
                            Notvalid = false;

                        }
                        break;
                    case "2":
                        {
                            DeleteRoleName();
                            Notvalid = false;

                        }
                        break;
                    case "3":
                        {
                            InsertRoleName();
                            Notvalid = false;

                        }
                        break;
                    case "4":
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
                            UpdateDept();
                            Notvalid = false;

                        }
                        break;
                    case "2":
                        {
                            DeleteDepartment();
                            Notvalid = false;

                        }
                        break;
                    case "3":
                        {
                            InsertDepartment();
                            Notvalid = false;

                        }
                        break;
                    case "4":
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
                            UpdateJobTitle();
                            Notvalid = false;

                        }
                        break;
                    case "2":
                        {
                            DeleteJobtitle();
                            Notvalid = false;

                        }
                        break;
                    case "3":
                        {
                            InsertJobtitle();
                            Notvalid = false;

                        }
                        break;
                    case "4":
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
                            UpdateLocationCountry();
                            Notvalid = false;

                        }
                        break;
                    case "2":
                        {
                            DeleteCountry();
                            Notvalid = false;

                        }
                        break;
                    case "3":
                        {
                            InsertCountry();
                            Notvalid = false;

                        }
                        break;
                    case "4":
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
                            UpdateLocationStreet();
                            Notvalid = false;

                        }
                        break;
                    case "2":
                        {
                            DeleteStreet();
                            Notvalid = false;

                        }
                        break;
                    case "3":
                        {
                            InsertStreet();
                            Notvalid = false;

                        }
                        break;
                    case "4":
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
                            Updatesubrub();
                            Notvalid = false;

                        }
                        break;
                    case "2":
                        {
                            DeleteSuburb();
                            Notvalid = false;

                        }
                        break;
                    case "3":
                        {
                            InsertSuburb();
                            Notvalid = false;

                        }
                        break;
                    case "4":
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
                            UpdateLocationCity();
                            Notvalid = false;

                        }
                        break;
                    case "2":
                        {
                            DeleteCity();
                            Notvalid = false;

                        }
                        break;
                    case "3":
                        {
                            InsertCity();
                            Notvalid = false;

                        }
                        break;
                    case "4":
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
            bool loopRoleID = true;
            string FieldChoiceName = "RoleName";
            List<tblEmployeeRoleName> employee = storageManager.GetTblEmployeeRoleNames();
            view.DisplayRoleNames(employee);
            int RoleID = 0;
            do
            {
                List<int> RoleIds = new List<int>();
                RoleIds = storageManager.getRoleIds();
                view.DisplayMessage("Enter the Role ID to update");
                Console.WriteLine("(Refrence data above)");
                int RoleInput = view.GetIntInput();
                if (RoleIds.Contains(RoleInput))
                {
                    loopRoleID = false;
                    RoleID = RoleInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }
            } while (loopRoleID);

            string RoleNameChange = view.WithinBoundary($"What do you want to change {RoleID}'s Name to:", 2, 20);
            string rowsAffected = storageManager.UpdateRoleName(FieldChoiceName, RoleID, RoleNameChange);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
        //updates the JobTitle table in the database 
        private static void UpdateJobTitle()
        {
            bool loopJobID = true;
            string FieldChoiceName = "JobTitleName";
            List<tblJobtitle> employee = storageManager.GetEmployeeTblJobTittles();
            view.DisplaytblJobTittles(employee);
            int JobID = 0;
            do
            {
                List<int> JobIds = new List<int>();
                JobIds = storageManager.getJobIds();
                view.DisplayMessage("Enter the Job Title ID to update");
                Console.WriteLine("(Refrence data above)");
                int JobIDinput = view.GetIntInput();
                if (JobIds.Contains(JobIDinput))
                {
                    loopJobID = false;
                    JobID = JobIDinput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }
            } while (loopJobID);
            string JobTitleChange = view.WithinBoundary($"What do you want to change {JobID}'s Name to:", 2, 20);
            string rowsAffected = storageManager.UpdateJobTitle(FieldChoiceName, JobID, JobTitleChange);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
        //updates the LocationStreet table in the database
        private static void UpdateLocationStreet()
        {
            bool loopstreetID = true;
            string FieldChoiceName = "StreetName";
            List<tblStreetID> employee = storageManager.GetTblStreetIDs();
            view.DisplayStreetID(employee);
            int StreetID = 0;
            do
            {
                List<int> streetIDs = new List<int>();
                streetIDs = storageManager.getStreetIds();
                view.DisplayMessage("Enter the Street ID to update");
                Console.WriteLine("(Refrence data above)");
                int StreetIDInput = view.GetIntInput();
                if (streetIDs.Contains(StreetIDInput))
                {
                    loopstreetID = false;
                    StreetID = StreetIDInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }

            } while (loopstreetID);
            string StreetNameChange = view.WithinBoundary($"What do you want to change {StreetID}'s Name to:", 2, 20);
            string rowsAffected = storageManager.UpdateLocationStreet(FieldChoiceName, StreetID, StreetNameChange);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
        //updates the Country table in the database
        private static void UpdateLocationCountry()
        {
            bool loopCountryID = true;
            string FieldChoiceName = "CountryName";
            List<tblLocationCountry> employee = storageManager.GetTblLocationCountries();
            view.DisplayCountry(employee);
            int CountryID = 0;
            do
            {
                List<int> CountryIDs = new List<int>();
                CountryIDs = storageManager.getCountryIds();
                view.DisplayMessage("Enter the Country ID to update");
                Console.WriteLine("(Refrence data above)");
                int CountryIDInput = view.GetIntInput();
                if (CountryIDs.Contains(CountryIDInput))
                {
                    loopCountryID = false;
                    CountryID = CountryIDInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }

            } while (loopCountryID);
            string CountryNameChange = view.WithinBoundary($"What do you want to change {CountryID}'s Name to:", 2, 20);
            string rowsAffected = storageManager.UpdateLocationCountry(FieldChoiceName, CountryID, CountryNameChange);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
        //updates the City table in the database
        private static void UpdateLocationCity()
        {
            string FieldChoiceName = "CityName";
            bool loopCityID = true;
            List<tblCityID> employee = storageManager.GetTblCityIDs();
            view.DisplayCity(employee);
            int CityID = 0;
            do
            {
                List<int> CityIds = new List<int>();
                CityIds = storageManager.getCityIds();
                view.DisplayMessage("Enter the City ID to update");
                Console.WriteLine("(Refrence data above)");
                int CityIDInput = view.GetIntInput();
                if (CityIds.Contains(CityIDInput))
                {
                    loopCityID = false;
                    CityID = CityIDInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }

            } while (loopCityID);
            string CityNameChange = view.WithinBoundary($"What do you want to change {CityID}'s Name to:", 2, 20);
            string rowsAffected = storageManager.UpdateLocationCity(FieldChoiceName, CityID, CityNameChange);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
        //updates the EmployeeDetails table in the database
        private static void UpdateEmployeeDetails()
        {
            bool loop = true;
            bool loopManagersID = true;
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
                            int ManagersID = 0;
                            do
                            {
                                List<int> ManagersIDs = new List<int>();
                                ManagersIDs = storageManager.getemployeeIds();
                                view.DisplayMessage("Enter the Employee ID that relates to the First Name you wish to update ");
                                Console.WriteLine("(Refrence data above)");
                                int ManagersIDInput = view.GetIntInput();
                                if (ManagersIDs.Contains(ManagersIDInput))
                                {
                                    loopManagersID = false;
                                    ManagersID = ManagersIDInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (loopManagersID);
                            string FirstNameChange = view.WithinBoundary($"What do you want to change {ManagersID}'s First Name to:", 2, 20);
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, ManagersID, FirstNameChange);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "2":
                        {
                            loop = false;
                            string FieldChoiceName = "LastName";
                            List<tblEmployeeDetails> employee = storageManager.GetTblEmployeeDetails();
                            view.DisplayEmployeeDetails(employee);
                            int ManagersID = 0;
                            do
                            {
                                List<int> ManagersIDs = new List<int>();
                                ManagersIDs = storageManager.getemployeeIds();
                                view.DisplayMessage("Enter the Employee ID that relates to the Last Name you wish to update");
                                Console.WriteLine("(Refrence data above)");
                                int ManagersIDInput = view.GetIntInput();
                                if (ManagersIDs.Contains(ManagersIDInput))
                                {
                                    loopManagersID = false;
                                    ManagersID = ManagersIDInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (loopManagersID);
                            
                            string Change = view.WithinBoundary($"What do you want to change {ManagersID}'s Last Name to:", 2, 20);
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, ManagersID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "3":
                        {
                            loop = false;
                            string FieldChoiceName = "Gender";
                            List<tblEmployeeDetails> employee = storageManager.GetTblEmployeeDetails();
                            view.DisplayEmployeeDetails(employee);
                            int ManagersID = 0;
                            do
                            {
                                List<int> ManagersIDs = new List<int>();
                                ManagersIDs = storageManager.getemployeeIds();
                                view.DisplayMessage("Enter the Employee ID that relates to the Employee's Gender you wish to update");
                                Console.WriteLine("(Refrence data above)");
                                int ManagersIDInput = view.GetIntInput();
                                if (ManagersIDs.Contains(ManagersIDInput))
                                {
                                    loopManagersID = false;
                                    ManagersID = ManagersIDInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (loopManagersID);

                            bool loopGender = true;
                            loop = false;
                           
                            string Gender = "";
                            do
                            {
                                view.DisplayMessage($"What do you want to change {ManagersID}'s Gender to:");
                                view.DisplayMessage("F for a Female Employee  M for a Male Employee");
                                string Genderinput = view.GetInput();
                                if (Genderinput.Equals("F") || Genderinput.Equals("M"))
                                {
                                    Gender = Genderinput;
                                    loopGender = false;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (loopGender);
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, ManagersID, Gender);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "4":
                        {
                            loop = false;
                            string FieldChoiceName = "Email";
                            List<tblEmployeeDetails> employee = storageManager.GetTblEmployeeDetails();
                            view.DisplayEmployeeDetails(employee);
                            int ManagersID = 0;
                            do
                            {
                                List<int> ManagersIDs = new List<int>();
                                ManagersIDs = storageManager.getemployeeIds();
                                view.DisplayMessage("Enter the Employee ID that relates to the Email you wish to update");
                                Console.WriteLine("(Refrence data above)");
                                int ManagersIDInput = view.GetIntInput();
                                if (ManagersIDs.Contains(ManagersIDInput))
                                {
                                    loopManagersID = false;
                                    ManagersID = ManagersIDInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (loopManagersID);
                            
                            string Change = view.WithinBoundaryWithoutInvalid($"What do you want to change {ManagersID}'s Email to:", 2, 20);
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, ManagersID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "5":
                        {
                            loop = false;
                            string FieldChoiceName = "Phonenumber";
                            List<tblEmployeeDetails> employee = storageManager.GetTblEmployeeDetails();
                            view.DisplayEmployeeDetails(employee);
                            int ManagersID = 0;
                            do
                            {
                                List<int> ManagersIDs = new List<int>();
                                ManagersIDs = storageManager.getemployeeIds();
                                view.DisplayMessage("Enter the Employee ID that relates to the Phonenumber you wish to update");
                                Console.WriteLine("(Refrence data above)");
                                int ManagersIDInput = view.GetIntInput();
                                if (ManagersIDs.Contains(ManagersIDInput))
                                {
                                    loopManagersID = false;
                                    ManagersID = ManagersIDInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (loopManagersID);
                            
                            string Change = view.WithinBoundary($"What do you want to change {ManagersID}'s Phone Number to:", 9, 12);
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, ManagersID, Change);
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
        //updates the employee details for the employee switch side of the program 
        private static void UpdateEmpEmployeeDetails(int EmployeeID)
        {
            bool loop = true;
            Console.Clear();
            do
            {
                view.DisplayUpdateEmployeeDetails();
                string FieldChoice = view.GetInput();
                switch (FieldChoice) 
                {
                    case "1":
                        {
                            loop = false;
                            string FieldChoiceName = "FirstName";

                            string FirstNameChange = view.WithinBoundary($"What do you want to change Your First Name to:", 2, 20);
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, EmployeeID, FirstNameChange);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "2":
                        {
                            loop = false;
                            string FieldChoiceName = "LastName";

                            string Change = view.WithinBoundary($"What do you want to change Your Last Name to:", 2, 20);
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, EmployeeID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "3":
                        {
                            bool loopGender = true;
                            loop = false;
                            string FieldChoiceName = "Gender";
                            string Gender = "";
                            do
                            {
                                view.DisplayMessage($"What do you want to change {EmployeeID}'s Gender to:");
                                view.DisplayMessage("F for a Female Employee  M for a Male Employee");
                                string Genderinput = view.GetInput();
                                if (Genderinput.Equals("F") || Genderinput.Equals("M"))
                                {
                                    Gender = Genderinput;
                                    loopGender = false;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (loopGender);

                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, EmployeeID, Gender);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "4":
                        {
                            loop = false;
                            string FieldChoiceName = "Email";

                            string Change = view.WithinBoundaryWithoutInvalid($"What do you want to change your Email to:", 2, 20);
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, EmployeeID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "5":
                        {
                            loop = false;
                            string FieldChoiceName = "Phonenumber";
                            string Change = view.WithinBoundary($"What do you want to change Your Phone Number to:", 9, 12);
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, EmployeeID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Invalid option please try again.");
                            loop = true;
                        }
                        break;
                }
            }
            while (loop);
        }
        //updates the Location table in the database
        private static void UpdateLocation()
        {
            bool loop = true;
            bool loopManagersID = true;
            bool Changeloop = true;
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
                            int LocationID = 0;
                            do
                            {
                                List<int> ManagersIDs = new List<int>();
                                ManagersIDs = storageManager.getLocationIds();
                                view.DisplayMessage("Enter the Location ID that relates to the Location Name you wish to update");
                                Console.WriteLine("(Refrence data above)");
                                int ManagersIDInput = view.GetIntInput();
                                if (ManagersIDs.Contains(ManagersIDInput))
                                {
                                    loopManagersID = false;
                                    LocationID = ManagersIDInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (loopManagersID);
                            string Change = view.WithinBoundary($"What do you want to change {LocationID}'s Name to:", 2, 20);
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
                            int LocationID = 0;
                            do
                            {
                                List<int> ManagersIDs = new List<int>();
                                ManagersIDs = storageManager.getLocationIds();
                                view.DisplayMessage("Enter the Location ID that relates to the City ID you wish to update");
                                Console.WriteLine("(Refrence data above)");
                                int ManagersIDInput = view.GetIntInput();
                                if (ManagersIDs.Contains(ManagersIDInput))
                                {
                                    loopManagersID = false;
                                    LocationID = ManagersIDInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (loopManagersID);
                            int CountryID = 0;
                            do
                            {
                                List<int> ManagersIDs = new List<int>();
                                ManagersIDs = storageManager.getCityIds();
                                Console.WriteLine($"What do you want to change {LocationID}'s ID to:");
                                int ManagersIDInput = view.GetIntInput();
                                if (ManagersIDs.Contains(ManagersIDInput))
                                {
                                    Changeloop = false;
                                    CountryID = ManagersIDInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (loopManagersID);
                            string Change = Convert.ToString(CountryID);
                            string rowsAffected = storageManager.UpdateLocation(FieldChoiceName, LocationID, Change);
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
                            int LocationID = 0;
                            do
                            {
                                List<int> ManagersIDs = new List<int>();
                                ManagersIDs = storageManager.getLocationIds();
                                view.DisplayMessage("Enter the Location ID that relates to the Suburb ID you wish to update");
                                Console.WriteLine("(Refrence data above)");
                                int ManagersIDInput = view.GetIntInput();
                                if (ManagersIDs.Contains(ManagersIDInput))
                                {
                                    loopManagersID = false;
                                    LocationID = ManagersIDInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (loopManagersID);
                            int CountryID = 0;
                            do
                            {
                                List<int> ManagersIDs = new List<int>();
                                ManagersIDs = storageManager.getSubrubIds();
                                Console.WriteLine($"What do you want to change {LocationID}'s ID to:");
                                int ManagersIDInput = view.GetIntInput();
                                if (ManagersIDs.Contains(ManagersIDInput))
                                {
                                    Changeloop = false;
                                    CountryID = ManagersIDInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (loopManagersID);
                            string Change = Convert.ToString(CountryID);
                            string rowsAffected = storageManager.UpdateLocation(FieldChoiceName, LocationID, Change);
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
                            int LocationID = 0;
                            do
                            {
                                List<int> ManagersIDs = new List<int>();
                                ManagersIDs = storageManager.getLocationIds();
                                view.DisplayMessage("Enter the Location ID that relates to the Street ID you wish to update");
                                Console.WriteLine("(Refrence data above)");
                                int ManagersIDInput = view.GetIntInput();
                                if (ManagersIDs.Contains(ManagersIDInput))
                                {
                                    loopManagersID = false;
                                    LocationID = ManagersIDInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (loopManagersID);
                            int CountryID = 0;
                            do
                            {
                                List<int> ManagersIDs = new List<int>();
                                ManagersIDs = storageManager.getStreetIds();
                                Console.WriteLine($"What do you want to change {LocationID}'s ID to:");
                                int ManagersIDInput = view.GetIntInput();
                                if (ManagersIDs.Contains(ManagersIDInput))
                                {
                                    Changeloop = false;
                                    CountryID = ManagersIDInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (loopManagersID);
                            string Change = Convert.ToString(CountryID);
                            string rowsAffected = storageManager.UpdateLocation(FieldChoiceName, LocationID, Change);
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
                            int LocationID = 0;
                            do
                            {
                                List<int> ManagersIDs = new List<int>();
                                ManagersIDs = storageManager.getLocationIds();
                                view.DisplayMessage("Enter the Location ID that relates to the Country ID you wish to update");
                                Console.WriteLine("(Refrence data above)");
                                int ManagersIDInput = view.GetIntInput();
                                if (ManagersIDs.Contains(ManagersIDInput))
                                {
                                    loopManagersID = false;
                                    LocationID = ManagersIDInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (loopManagersID);
                            int CountryID = 0;
                            do
                            {
                                List<int> ManagersIDs = new List<int>();
                                ManagersIDs = storageManager.getCountryIds();
                                Console.WriteLine($"What do you want to change {LocationID}'s ID to:");
                                int ManagersIDInput = view.GetIntInput();
                                if (ManagersIDs.Contains(ManagersIDInput))
                                {
                                    Changeloop = false;
                                    CountryID = ManagersIDInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (loopManagersID);
                            string Change = Convert.ToString(CountryID);
                            string rowsAffected = storageManager.UpdateLocation(FieldChoiceName, LocationID, Change);
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
                            int LocationID = 0;
                            do
                            {
                                List<int> ManagersIDs = new List<int>();
                                ManagersIDs = storageManager.getLocationIds();
                                view.DisplayMessage("Enter the Location ID that relates to the Street Number  you wish to update");
                                Console.WriteLine("(Refrence data above)");
                                int ManagersIDInput = view.GetIntInput();
                                if (ManagersIDs.Contains(ManagersIDInput))
                                {
                                    loopManagersID = false;
                                    LocationID = ManagersIDInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (loopManagersID);
                            string Change = view.WithinBoundary($"What do you want to change {LocationID}'s StreetNumber to:", 1, 4);
                            string rowsAffected = storageManager.UpdateLocation(FieldChoiceName, LocationID, Change);
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
            bool loopSuburbID = true;
            do
            {
                view.DisplayUpdatesubrub();
                string FieldChoice = view.GetInput();
                switch (FieldChoice)
                {
                    case "1":
                        {
                            loop = false;
                            string FieldChoiceName = "SubrubName";
                            List<tblSubrubID> subrubIDs = storageManager.GetTblSubrubIDs();
                            view.DisplaySubrub(subrubIDs);
                            int SuburbID = 0;
                            do
                            {
                                List<int> SuburbIDs = new List<int>();
                                SuburbIDs = storageManager.getSubrubIds();
                                view.DisplayMessage("Enter the Suburb ID that relates to the Subrub Name you wish to update");
                                Console.WriteLine("(Refrence data above)");
                                int SuburbIDInput = view.GetIntInput();
                                if (SuburbIDs.Contains(SuburbIDInput))
                                {
                                    loopSuburbID = false;
                                    SuburbID = SuburbIDInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }

                            } while (loopSuburbID);
                            
                            string Change = view.WithinBoundary($"What do you want to change {SuburbID}'s Name to:", 2, 20);
                            string rowsAffected = storageManager.Updatesubrub(FieldChoiceName, SuburbID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "2":
                        {
                            loop = false;
                            bool looppostcode = true;
                            string FieldChoiceName = "PostCode";
                            List<tblSubrubID> subrubIDs = storageManager.GetTblSubrubIDs();
                            view.DisplaySubrub(subrubIDs);                           
                            int SuburbID = 0;
                            do
                            {
                                List<int> SuburbIDs = new List<int>();
                                SuburbIDs = storageManager.getSubrubIds();
                                view.DisplayMessage("Enter the Suburb ID that relates to the Post Code you wish to update");
                                Console.WriteLine("(Refrence data above)");
                                int SuburbIDInput = view.GetIntInput();
                                if (SuburbIDs.Contains(SuburbIDInput))
                                {
                                    loopSuburbID = false;
                                    SuburbID = SuburbIDInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }

                            } while (loopSuburbID);
                            int postcode = 0;
                            do
                            {
                                view.DisplayMessage("Enter the Street Number's of the Location");
                                int postcodeInput = view.GetIntInput();
                                if (postcodeInput > 0 && postcodeInput < 9999)
                                {
                                    looppostcode = false;
                                    postcode = postcodeInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (looppostcode);
                            string Change = Convert.ToString(postcode);
                            string rowsAffected = storageManager.Updatesubrub(FieldChoiceName, SuburbID, Change);
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
            bool loopDepartmentID = true;
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
                            int ManagersID = 0;
                            do
                            {
                                List<int> ManagersIDs = new List<int>();
                                ManagersIDs = storageManager.getDepartmentsIds();
                                view.DisplayMessage("Enter the Department ID that relates to the Department Name you wish to update");
                                Console.WriteLine("(Refrence data above)");
                                int ManagersIDInput = view.GetIntInput();
                                if (ManagersIDs.Contains(ManagersIDInput))
                                {
                                    loopDepartmentID = false;
                                    ManagersID = ManagersIDInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (loopDepartmentID);
                            string Change = view.WithinBoundary($"What do you want to change {ManagersID}'s Name to:",2,20);
                            string rowsAffected = storageManager.UpdateDept(FieldChoiceName, ManagersID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "2":
                        {
                            loop = false;
                            string FieldChoiceName = "ManagersID";
                            List<tblDepartments> depts = storageManager.GetTblDepartments();
                            view.DisplayDepartments(depts);
                            int ManagersID = 0;
                            do
                            {
                                List<int> ManagersIDs = new List<int>();
                                ManagersIDs = storageManager.getDepartmentsIds();
                                view.DisplayMessage("Enter the Department ID that relates to the Managers ID you wish to update");
                                Console.WriteLine("(Refrence data above)");
                                int ManagersIDInput = view.GetIntInput();
                                if (ManagersIDs.Contains(ManagersIDInput))
                                {
                                    loopDepartmentID = false;
                                    ManagersID = ManagersIDInput;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid options");
                                }
                            } while (loopDepartmentID);
                            
                            string Change = view.WithinBoundary($"What do you want to change {ManagersID}'s ID to:", 2, 20);
                            string rowsAffected = storageManager.UpdateDept(FieldChoiceName, ManagersID, Change);
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
            bool loopCityID = true;
            List<tblCityID> cityIDs = storageManager.GetTblCityIDs();
            view.DisplayCity(cityIDs);
            int CityID = 0;
            do
            {
                List<int> CityIds = new List<int>();
                CityIds = storageManager.getCityIds();
                view.DisplayMessage("Enter the City id you wish to Delete");
                Console.WriteLine("(Refrence data above)");
                int CityIDInput = view.GetIntInput();
                if (CityIds.Contains(CityIDInput))
                {
                    loopCityID = false;
                    CityID = CityIDInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }
            } while (loopCityID);
            int rowsAffected = storageManager.DeleteCity(CityID);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
        //Deletes a Department in the database
        private static void DeleteDepartment()
        {
            bool loopDepartmentID = true;
            List<tblDepartments> departments = storageManager.GetTblDepartments();
            view.DisplayDepartments(departments);
            int ManagersID = 0;
            do
            {
                List<int> ManagersIDs = new List<int>();
                ManagersIDs = storageManager.getDepartmentsIds();
                view.DisplayMessage("Enter the Department ID you wish to Delete");
                Console.WriteLine("(Refrence data above)");
                int ManagersIDInput = view.GetIntInput();
                if (ManagersIDs.Contains(ManagersIDInput))
                {
                    loopDepartmentID = false;
                    ManagersID = ManagersIDInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }
            } while (loopDepartmentID);
            int rowsAffected = storageManager.DeleteDepartment(ManagersID);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
        //Deletes a EmployeeDetails in the database
        private static void DeleteEmployeeDetails()
        {
            bool loopManagersID = true;
            List<tblEmployeeDetails> employee = storageManager.GetTblEmployeeDetails();
            view.DisplayEmployeeDetails(employee);
            int EmployeeID = 0;
            do
            {
                List<int> ManagersIDs = new List<int>();
                ManagersIDs = storageManager.getemployeeIds();
                view.DisplayMessage("Enter the Employee ID you wish to Delete");
                Console.WriteLine("(Refrence data above)");
                int ManagersIDInput = view.GetIntInput();
                if (ManagersIDs.Contains(ManagersIDInput))
                {
                    loopManagersID = false;
                    EmployeeID = ManagersIDInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }
            } while (loopManagersID);
            int rowsAffected = storageManager.DeleteEmployeeDetails(EmployeeID);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
        //Deletes a RoleName in the database
        private static void DeleteRoleName()
        {
            bool loopRoleID = true;
            List<tblEmployeeRoleName> roleNames = storageManager.GetTblEmployeeRoleNames();
            view.DisplayRoleNames(roleNames);
            int Role = 0;
            do
            {
                List<int> RoleIds = new List<int>();
                RoleIds = storageManager.getRoleIds();
                view.DisplayMessage("Enter the Role ID you wish to Delete");
                Console.WriteLine("(Refrence data above)");
                int RoleInput = view.GetIntInput();
                if (RoleIds.Contains(RoleInput))
                {
                    loopRoleID = false;
                    Role = RoleInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }
            } while (loopRoleID);
            int rowsAffected = storageManager.DeleteRoleName(Role);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
        //Deletes a Jobtitle in the database
        private static void DeleteJobtitle()
        {
            bool loopJobID = true;
            List<tblJobtitle> jobTittle = storageManager.GetEmployeeTblJobTittles();
            view.DisplaytblJobTittles(jobTittle);
            int JobID = 0;
            do
            {
                List<int> JobIds = new List<int>();
                JobIds = storageManager.getJobIds();
                view.DisplayMessage("Enter the Job Title ID you wish to Delete");
                Console.WriteLine("(Refrence data above)");
                int JobIDinput = view.GetIntInput();
                if (JobIds.Contains(JobIDinput))
                {
                    loopJobID = false;
                    JobID = JobIDinput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }
            } while (loopJobID);
            int rowsAffected = storageManager.DeleteJobtitle(JobID);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
        //Deletes a street in the database
        private static void DeleteStreet()
        {
            bool loopstreetID = true;
            List<tblStreetID> streetIDs = storageManager.GetTblStreetIDs();
            view.DisplayStreetID(streetIDs);
            int StreetID = 0;
            do
            {
                List<int> streetID = new List<int>();
                streetID = storageManager.getStreetIds();
                view.DisplayMessage("Enter the Street ID you wish to Delete");
                Console.WriteLine("(Refrence data above)");
                int StreetIDInput = view.GetIntInput();
                if (streetID.Contains(StreetIDInput))
                {
                    loopstreetID = false;
                    StreetID = StreetIDInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }

            } while (loopstreetID);
            int rowsAffected = storageManager.DeleteStreet(StreetID);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
        //Deletes a Suburb in the database
        private static void DeleteSuburb()
        {
            bool loopSuburbID = true;
            List<tblSubrubID> subrubIDs = storageManager.GetTblSubrubIDs();
            view.DisplaySubrub(subrubIDs);
            int SuburbID = 0;
            do
            {
                List<int> SuburbIDs = new List<int>();
                SuburbIDs = storageManager.getSubrubIds();
                view.DisplayMessage("Enter the Suburb ID you wish to Delete");
                Console.WriteLine("(Refrence data above)");
                int SuburbIDInput = view.GetIntInput();
                if (SuburbIDs.Contains(SuburbIDInput))
                {
                    loopSuburbID = false;
                    SuburbID = SuburbIDInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }

            } while (loopSuburbID);
            int rowsAffected = storageManager.DeleteSuburb(SuburbID);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
        //Deletes a Country in the database
        private static void DeleteCountry()
        {
            bool loopCountryID = true;
            List<tblLocationCountry> countries = storageManager.GetTblLocationCountries();
            view.DisplayCountry(countries);    
            int CountryID = 0;
            do
            {
                List<int> CountryIDs = new List<int>();
                CountryIDs = storageManager.getCountryIds();
                view.DisplayMessage("Enter the Country ID you wish to Delete");
                Console.WriteLine("(Refrence data above)");
                int CountryIDInput = view.GetIntInput();
                if (CountryIDs.Contains(CountryIDInput))
                {
                    loopCountryID = false;
                    CountryID = CountryIDInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }

            } while (loopCountryID);
            int rowsAffected = storageManager.DeleteCountry(CountryID);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
        //Deletes a Location in the database
        private static void DeleteLocation()
        {
            bool loopManagersID = true;
            List<tblLocation> locations = storageManager.GetTblLocations();
            view.DisplayLocation(locations);
            int LocationID = 0;
            do
            {
                List<int> ManagersIDs = new List<int>();
                ManagersIDs = storageManager.getLocationIds();
                view.DisplayMessage("Enter the Location ID you wish to Delete");
                Console.WriteLine("(Refrence data above)");
                int ManagersIDInput = view.GetIntInput();
                if (ManagersIDs.Contains(ManagersIDInput))
                {
                    loopManagersID = false;
                    LocationID = ManagersIDInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }
            } while (loopManagersID);
            int rowsAffected = storageManager.DeleteLocation(LocationID);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }




        //creates a new Location in the database
        private static void InsertLocation()
        {
            bool Active = true;
            bool loopCountryID = true;
            bool loopCityID = true;
            bool loopSuburbID = true;
            bool loopstreetID = true;
            bool loopStreetNumber = true;
            string LocationName = view.WithinBoundary("Enter the new Location Name", 5, 40);
            int CountryID = 0;
            do
            {
                List<int> CountryIDs = new List<int>();
                CountryIDs = storageManager.getCountryIds();
                view.DisplayMessage("Enter the Country ID's of the Location");
                int CountryIDInput = view.GetIntInput();
                if (CountryIDs.Contains(CountryIDInput))
                {
                    loopCountryID = false;
                    CountryID = CountryIDInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }

            } while (loopCountryID);
            int SuburbID = 0;
            do
            {
                List<int> SuburbIDs = new List<int>();
                SuburbIDs = storageManager.getSubrubIds();
                view.DisplayMessage("Enter the Suburb ID's of the Location");
                int SuburbIDInput = view.GetIntInput();
                if (SuburbIDs.Contains(SuburbIDInput))
                {
                    loopSuburbID = false;
                    SuburbID = SuburbIDInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }

            } while (loopSuburbID);
            int StreetID = 0;
            do
            {
                List<int> streetIDs = new List<int>();
                streetIDs = storageManager.getStreetIds();
                view.DisplayMessage("Enter the Street ID's of the Location");
                int StreetIDInput = view.GetIntInput();
                if (streetIDs.Contains(StreetIDInput))
                {
                    loopstreetID = false;
                    StreetID = StreetIDInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }

            } while (loopstreetID);
            int CityID = 0;
            do
            {
                List<int> CityIds = new List<int>();
                CityIds = storageManager.getCityIds();
                view.DisplayMessage("Enter the City ID's of the Location");
                int CityIDInput = view.GetIntInput();
                if (CityIds.Contains(CityIDInput))
                {
                    loopCityID = false;
                    CityID = CityIDInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }

            } while (loopCityID);
            int StreetNumber = 0;
            do
            {
                view.DisplayMessage("Enter the Street Number's of the Location");
                int streetNumberInput = view.GetIntInput();
                if (streetNumberInput > 0 && streetNumberInput < 300)
                {
                    loopStreetNumber = false;
                    StreetNumber = streetNumberInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }
            } while (loopStreetNumber);
            int LocationID = 0;
            tblLocation location1 = new tblLocation(LocationID, LocationName, CountryID, SuburbID, StreetID, CityID, StreetNumber, Active);
            int GenerateID = storageManager.InsertLocation(LocationName, CountryID, SuburbID, StreetID, CityID, StreetNumber);
            view.DisplayMessage($"new Location Created with ID {GenerateID}");
        }
        //creates a new EmployeeDetails in the database
        private static void InsertEmployeeDetails()
        {
            bool Active = true;
            bool loopRoleID= true;
            bool loopJobID = true;
            bool loopGender = true;
            bool loopWage = true;
            bool loopEmail = true;
            bool loopPhonenumber = true;    
            string FirstName = view.WithinBoundary("Enter the First Name of the new Employee", 2, 20);
            string LastName = view.WithinBoundary("Enter the Last Name of the new Employee", 2, 20);
            DateTime HireDate = DateTime.Now;
            string Gender = "";
            do
            {
                view.DisplayMessage("Enter The Gender of the New Employee ");
                view.DisplayMessage("F for a Female Employee  M for a Male Employee");
                string Genderinput = view.GetInput();
                if (Genderinput.Equals("F")||Genderinput.Equals("M"))
                {
                    Gender = Genderinput;
                    loopGender = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }
            } while (loopGender);
            int JobID = 0;
            do
            {
                List<int> JobIds = new List<int>();
                JobIds = storageManager.getJobIds();
                view.DisplayMessage("Enter the Job ID of the New Employee");
                int JobIDinput = view.GetIntInput();
                if (JobIds.Contains(JobIDinput))
                {
                    loopJobID = false;
                    JobID = JobIDinput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }
            } while (loopJobID);
            string Username = view.WithinBoundary("Enter the Username of the New Employee", 2, 20);
            string Password = view.WithinBoundary("Enter the Password of the New Employee ", 2, 20);
            int Role = 0;
            do
            {
                List<int> RoleIds = new List<int>();
                RoleIds = storageManager.getRoleIds();
                view.DisplayMessage("Enter the Role Of the New Employee");
                view.DisplayMessage("1 For Employee\t 2 For Admin ");
                int RoleInput = view.GetIntInput();
                if (RoleIds.Contains(RoleInput))
                {
                    loopRoleID = false;
                    Role = RoleInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }
            } while (loopRoleID);
                
            string EmailInput = view.WithinBoundaryWithoutInvalid("Enter the Email of the New Employee",2,20);
            int Phonenumber = 0;
            do
            {
                view.DisplayMessage("Enter the Phone Number of the New Employee using the format 021 123 1234");
                int PhonenumberInput = view.GetIntInput();
                int PhonenumberInputLength = PhonenumberInput.ToString().Length;
                if (PhonenumberInputLength >= 9 && PhonenumberInputLength<= 12)
                {
                    loopPhonenumber = false;
                    Phonenumber = PhonenumberInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }
            } while (loopPhonenumber);
            int wage = 0;
            do
            {
                view.DisplayMessage("Enter the Wage for the New Employee");
                int wageInput = view.GetIntInput();
                if (wageInput > 0 && wageInput < 999999999)
                {
                    loopWage = false;
                    wage = wageInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }
            } while (loopWage);
            int EmployeeID = 0;
            tblEmployeeDetails location1 = new tblEmployeeDetails(EmployeeID, FirstName, LastName, HireDate, Gender, JobID, Role, Password, Username, Active, EmailInput, Phonenumber, wage);
            int GenerateID = storageManager.InsertEmployeeDetails(FirstName, LastName, HireDate, Gender, JobID, Role, Password, Username, EmailInput, Phonenumber, wage);
            view.DisplayMessage($"new Employee Created with ID {GenerateID}");
        }
        //creates a new RoleName in the database
        private static void InsertRoleName()
        {
            bool Active = true;
            string StreetName = view.WithinBoundary("Enter the new Role Name", 2,20);    
            int StreetID = 0;
            tblEmployeeRoleName location1 = new tblEmployeeRoleName(StreetID, StreetName, Active);
            int GenerateID = storageManager.InsertRoleName(StreetName);
            view.DisplayMessage($"new Role Created with ID {GenerateID}");
        }
        //creates a new Jobtitle in the database
        private static void InsertJobtitle()
        {
            bool Active = true;
            string StreetName = view.WithinBoundary("Enter the new Job Title Name", 2, 40);
            int StreetID = 0;
            tblJobtitle location1 = new tblJobtitle(StreetID, StreetName, Active);
            int GenerateID = storageManager.InsertJobtitle(StreetName);
            view.DisplayMessage($"new department Created with ID {GenerateID}");
        }
        //creates a new Department in the database
        private static void InsertDepartment()
        {
            bool Active = true;
            bool loopManagersID = true;
            string StreetName = view.WithinBoundary("Enter the new Department Name", 2, 40);
            int ManagersID = 0;
            do
            {
                List<int> ManagersIDs = new List<int>();
                ManagersIDs = storageManager.getemployeeIds();
                view.DisplayMessage("Enter the Manager's Employee ID of the Department");
                int ManagersIDInput = view.GetIntInput();
                if (ManagersIDs.Contains(ManagersIDInput))
                {
                    loopManagersID = false;
                    ManagersID = ManagersIDInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }
            } while (loopManagersID);            
            int StreetID = 0;
            tblDepartments location1 = new tblDepartments(StreetName, StreetID, ManagersID, Active);
            int GenerateID = storageManager.InsertDepartment(StreetName, ManagersID);
            view.DisplayMessage($"new department Created with ID {GenerateID}");
        }
        //creates a new City in the database
        private static void InsertCity()
        {
            bool Active = true;
            string StreetName = view.WithinBoundary("Enter the new City Name", 2, 40);
            int StreetID = 0;
            tblCityID location1 = new tblCityID(StreetID, StreetName, Active);
            int GenerateID = storageManager.InsertCity(StreetName);
            view.DisplayMessage($"new City Created with ID {GenerateID}");
        }
        //creates a new Street in the database
        private static void InsertStreet()
        {
            bool Active = true;
            string StreetName = view.WithinBoundary("Enter the new Street Name", 2, 40);
            int StreetID = 0;
            tblStreetID location1 = new tblStreetID(StreetID, StreetName, Active);
            int GenerateID = storageManager.InsertStreet(StreetName);
            view.DisplayMessage($"new Street Created with ID {GenerateID}");
        }
        //creates a new Suburb in the database
        private static void InsertSuburb()
        {
            bool Active = true;
            bool looppostcode = true;
            string StreetName = view.WithinBoundary("Enter the new suburb Name", 2, 40); 
            int postcode = 0;
            do
            {
                view.DisplayMessage("Enter the Street Number's of the Location");
                int postcodeInput = view.GetIntInput();
                if (postcodeInput > 0 && postcodeInput < 9999)
                {
                    looppostcode = false;
                    postcode = postcodeInput;
                }
                else
                {
                    Console.WriteLine("Please enter a valid options");
                }
            } while (looppostcode);
            int StreetID = 0;
            tblSubrubID location1 = new tblSubrubID(StreetID, StreetName, postcode, Active);
            int GenerateID = storageManager.InsertSuburb(StreetName, postcode);
            view.DisplayMessage($"new subrub Created with ID {GenerateID}");
        }
        //creates a new Country in the database
        private static void InsertCountry()
        {
            bool Active = true;
            string StreetName = view.WithinBoundary("Enter the new Country Name", 2, 40);    
            int StreetID = 0;
            tblLocationCountry location1 = new tblLocationCountry(StreetID, StreetName, Active);
            int GenerateID = storageManager.InsertCountry(StreetName);
            view.DisplayMessage($"new Country Created with ID {GenerateID}");
        }


        // the register function for the employees 
        private static void RegisterEmployee()
        {
            Console.WriteLine("register function");
            string Username = view.WithinBoundary("Enter the Username of the New Employee", 2, 20);
            string Password = view.WithinBoundary("Enter the Password of the New Employee ", 2, 20);
            int GenerateID = storageManager.RegisterEmployee(Username, Password);
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
        // checks if the users log in was valid and either gives them the employee view or admin view based of their role 
        private static void LogIn()
        {

            bool NotValidMain = true;
            string tblchoice;
            string choice;
            bool loop = true;
            bool logInBool = true;
            string employeeChoice;
            Console.Clear();
            do          //loops the log in function untill they enter a valid username or password
             {
                
                 
                 string inputedUsername = view.WithinBoundary("Enter your Username",2,20);// gets the username
                 string Username = inputedUsername; // gets the username 
                 int EmployeeID = storageManager.getEmployeeID(inputedUsername);//gets the username 
                 string password = storageManager.getPassword(inputedUsername);//gets the password
                 role = storageManager.getRole(inputedUsername);// gets the role 
                string inputedPassword = view.WithinBoundary("Please enter your Password", 2, 20); // gets the inputted password
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