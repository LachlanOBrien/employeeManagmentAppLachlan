using Azure;
using employeeManagmentAppLachlan.Model;
using employeeManagmentAppLachlan.Repositories;
using employeeManagmentAppLachlan.View;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Threading.Channels;

namespace employeeManagmentAppLachlan
{
    public class Program //saved in onedrive>docc>12tpi>C#>oop>employeeManagmentAppLachlan OR .......oop>WorkPLS
    {                    // .mdf is saved in the DB folder onedrive>docc>12tpi>sql>DB        
        //allow nulls in job title id in the ddl 
        //allow nulls in the role id in the ddl 
        // same for job title 
        //remove the view all data from the edit and cascade the methods
        private static StorageManager storageManager;
        private static consoleView view;
        static int role;

        static void Main(string[] args)
        {

            //Console.WriteLine("Hello, World!");
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
                            Console.WriteLine($"what {Field} do you wish to see:");
                            choice = view.GetInput();
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

            view.DisplayMessage($"What do you want to change {RoleID} to:");
            string RoleNameChange = view.GetInputNotUpper();
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
            view.DisplayMessage($"What do you want to change {JobID} to:");
            string JobTitleChange = view.GetInputNotUpper();
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
            view.DisplayMessage($"What do you want to change {StreetID} to:");
            string StreetNameChange = view.GetInputNotUpper();
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
            view.DisplayMessage($"What do you want to change {CountryID} to:");
            string CountryNameChange = view.GetInputNotUpper();
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
            view.DisplayMessage($"What do you want to change {CityID} to:");
            string CityNameChange = view.GetInputNotUpper(); 
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
                            view.DisplayMessage($"What do you want to change {ManagersID}'s First Name to:");
                            string FirstNameChange = view.GetInputNotUpper();
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
                            view.DisplayMessage($"What do you want to change {ManagersID}'s Last Name to:");
                            string Change = view.GetInputNotUpper();
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
                            view.DisplayMessage($"What do you want to change {ManagersID}'s Gender to:");
                            string Change = view.GetInputNotUpper();
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, ManagersID, Change);
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
                            view.DisplayMessage($"What do you want to change {ManagersID}'s Email to:");
                            string Change = view.GetInputNotUpper();
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
                            view.DisplayMessage($"What do you want to change {ManagersID}'s Phone Number to:");
                            string Change = view.GetInputNotUpper();
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
                            view.DisplayMessage($"What do you want to change Your First Name to:");
                            string FirstNameChange = view.GetInputNotUpper();
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, EmployeeID, FirstNameChange);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "2":
                        {
                            loop = false;
                            string FieldChoiceName = "LastName";
                            view.DisplayMessage($"What do you want to change Your Last Name to:");
                            string Change = view.GetInputNotUpper();
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, EmployeeID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "3":
                        {
                            loop = false;
                            string FieldChoiceName = "Gender";
                            view.DisplayMessage($"What do you want to change {EmployeeID}'s Gender to:");
                            string Change = view.GetInputNotUpper();
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, EmployeeID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "4":
                        {
                            loop = false;
                            string FieldChoiceName = "Email";
                            view.DisplayMessage($"What do you want to change your Email to:");
                            string Change = view.GetInputNotUpper();
                            string rowsAffected = storageManager.UpdateEmployeeDetails(FieldChoiceName, EmployeeID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "5":
                        {
                            loop = false;
                            string FieldChoiceName = "Phonenumber";
                            view.DisplayMessage($"What do you want to change Your Phone Number to:");
                            string Change = view.GetInputNotUpper();
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
                            view.DisplayMessage($"What do you want to change {LocationID}'s Name to:");
                            string Change = view.GetInputNotUpper();
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
                            view.DisplayMessage($"What do you want to change {LocationID}'s ID to:");
                            string Change = view.GetInputNotUpper();
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
                            view.DisplayMessage($"What do you want to change {LocationID}'s ID to:");
                            string Change = view.GetInputNotUpper();
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
                            view.DisplayMessage($"What do you want to change {LocationID}'s ID to:");
                            string Change = view.GetInputNotUpper();
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
                            view.DisplayMessage($"What do you want to change {LocationID}'s ID to:");
                            string Change = view.GetInputNotUpper();
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
                            view.DisplayMessage($"What do you want to change {LocationID}'s ID to:");
                            string Change = view.GetInputNotUpper();
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
                            view.DisplayMessage($"What do you want to change {SuburbID}'s Name to:");
                            string Change = view.GetInputNotUpper();
                            string rowsAffected = storageManager.Updatesubrub(FieldChoiceName, SuburbID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "2":
                        {
                            loop = false;
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
                            view.DisplayMessage($"What do you want to change {SuburbID}'s post code to:");
                            string Change = view.GetInputNotUpper();
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
                            view.DisplayMessage($"What do you want to change {ManagersID}'s Name to:");
                            string Change = view.GetInputNotUpper();
                            string rowsAffected = storageManager.UpdateDept(FieldChoiceName, ManagersID, Change);
                            view.DisplayMessage($"Rows Affected: {rowsAffected}");
                        }
                        break;
                    case "2":
                        {
                            loop = false;
                            string FieldChoiceName = "ManagersID";
                            List<tblLocation> locations = storageManager.GetTblLocations();
                            view.DisplayLocation(locations);
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
                            view.DisplayMessage($"What do you want to change {ManagersID}'s ID to:");
                            string Change = view.GetInputNotUpper();
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
        //Deletes a street in the database
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
            bool loopCountryID = true;
            bool loopCityID = true;
            bool loopSuburbID = true;
            bool loopstreetID = true;
            view.DisplayMessage("Enter the new Location Name");
            string LocationName = view.GetInputNotUpper();
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
            bool loopRoleID= true;
            bool loopJobID = true;
            bool loopGender = true;
            bool loopWage = true;
            view.DisplayMessage("Enter the First Name of the new Employee");
            string FirstName = view.GetInputNotUpper();
            view.DisplayMessage("Enter the Last Name of the new Employee");
            string LastName = view.GetInputNotUpper();
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
            view.DisplayMessage("Enter the Username of the New Employee");
            string Username = view.GetInputNotUpper();
            view.DisplayMessage("Enter the Password of the New Employee ");
            string Password = view.GetInputNotUpper();
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
            view.DisplayMessage("Enter the Email of the New Employee");
            string Email = view.GetInputNotUpper();
            view.DisplayMessage("Enter the Phone Number of the New Employee");
            int Phonenumber = view.GetIntInput();
            int wage = 0;
            do
            {
                view.DisplayMessage("Enter the Wage for the New Employee");
                int wageInput = view.GetIntInput();
                if (wageInput > 0)
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
            tblEmployeeDetails location1 = new tblEmployeeDetails(EmployeeID, FirstName, LastName, HireDate, Gender, JobID, Role, Password, Username, Active, Email, Phonenumber, wage);
            int GenerateID = storageManager.InsertEmployeeDetails(FirstName, LastName, HireDate, Gender, JobID, Role, Password, Username, Email, Phonenumber, wage);
            view.DisplayMessage($"new Employee Created with ID {GenerateID}");
        }
        //creates a new RoleName in the database
        private static void InsertRoleName()
        {
            bool Active = true;
            view.DisplayMessage("Enter the new Role Name");
            string StreetName = view.GetInputNotUpper();
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
            string StreetName = view.GetInputNotUpper();
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
            view.DisplayMessage("Enter the new Department Name");
            string StreetName = view.GetInputNotUpper();
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
            view.DisplayMessage("Enter the new City Name");
            string StreetName = view.GetInputNotUpper();
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
            string StreetName = view.GetInputNotUpper();
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
            string StreetName = view.GetInputNotUpper();
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
            string StreetName = view.GetInputNotUpper();
            int StreetID = 0;
            tblLocationCountry location1 = new tblLocationCountry(StreetID, StreetName, Active);
            int GenerateID = storageManager.InsertCountry(StreetName);
            view.DisplayMessage($"new Country Created with ID {GenerateID}");
        }


        // the register function for the employees 
        private static void RegisterEmployee()
        {
            Console.WriteLine("register function");// temp add a proper method 
            Console.WriteLine("Enter A Username");
            string RegUsername = view.GetInputNotUpper();
            Console.WriteLine("Enter A Password");
            string RegPassword = view.GetInputNotUpper();
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
                
                 Console.WriteLine("Enter your Username");
                 string inputedUsername = view.GetInputNotUpper();// gets the username
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