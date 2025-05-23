using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class EmployeeTblEmployeeWage
    {
        public int employeeid { get; set; }
        public int jobtitleid { get; set; }
        public int wage { get; set; }
        
        public EmployeeTblEmployeeWage(int EmployeeID, int JobTitleID, int Wage)
        {
            employeeid = EmployeeID;
            jobtitleid = JobTitleID;
            wage = Wage;
        }
    }
}
