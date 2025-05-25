using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class EmployeeTblEmployeeContact
    {
        public int employeeid { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }

        public EmployeeTblEmployeeContact(int EmployeeID, string Email, string PhoneNumber)
        {
            employeeid = EmployeeID;
            email = Email;
            phonenumber = PhoneNumber;
        }
    }
}
