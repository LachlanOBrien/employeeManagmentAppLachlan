using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class EmployeeTblEmployeeLocations
    {
        public int employeeid { get; set; }
        public int locationid { get; set; }

        public EmployeeTblEmployeeLocations(int EmployeeID, int LocationID)
        {
            employeeid = EmployeeID;
            locationid = LocationID;
        }
    }
}
