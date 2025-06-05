using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class EmployeeTblEmployeesDetails
    {
        public int employeeid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime hiredate { get; set; }
        public string gender { get; set; }
        public int jobid { get; set; }

        public EmployeeTblEmployeesDetails(int EmployeeID, string FirstName, string LastName, DateTime HireDate, string Gender, int JobID)
        {
            employeeid = EmployeeID;
            firstname = FirstName;
            lastname = LastName;
            hiredate = HireDate;
            gender = Gender;
            jobid = JobID;
        }
    }
}
