using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class EmployeeTblEmployeeRole
    {
        public int employeeid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int role { get; set; }

        public EmployeeTblEmployeeRole(int employeeID, string Username, string Password, int Role)
        {
            employeeid = employeeID;
            username = Username;
            password = Password;
            role = Role;
        }
    }
}
