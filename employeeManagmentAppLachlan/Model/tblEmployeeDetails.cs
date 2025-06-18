using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class tblEmployeeDetails
    {
        public int employeeID { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime hireDate { get; set; }
        public string gender { get; set; }
        public string jobID { get; set; }
        public int roleID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public bool active { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
        public string wage { get; set; }

        public tblEmployeeDetails(int EmployeeID, string Firstname, string Lastname, DateTime Hiredate, string Gender, string JobID, int RoleID, string Username, string Password, bool Active, string Email, string PhoneNumber, string Wage)
        {
            employeeID = EmployeeID;
            firstname = Firstname;
            lastname = Lastname;
            hireDate = Hiredate;
            gender = Gender;
            jobID = JobID;
            roleID = RoleID;
            userName = Username;
            password = Password;
            active = Active;
            email = Email;
            phonenumber = PhoneNumber;
            wage = Wage;
        }
    }
}
