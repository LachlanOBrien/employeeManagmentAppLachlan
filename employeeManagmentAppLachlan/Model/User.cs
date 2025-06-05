using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class User
    {
        public int employeeID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int role { get; set; }

        public User(int EmployeeID, string Username, string Password, int Role)
        {
            employeeID = EmployeeID;
            username = Username;
            password = Password;
            role = Role;
        }
    }
}
