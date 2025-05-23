using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class EmployeeTblJobTittles
    {
        public int jobtitleid { get; set; }
        public string jobtitlename { get; set; }

        public EmployeeTblJobTittles(int jobtitleID, string JobTitleName)
        {
            jobtitleid = jobtitleID;
            jobtitlename = JobTitleName;
        }
    }
}
