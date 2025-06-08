using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class tblEmployeeLocations
    {
        public int locationID { get; set; }
        public int employeeID { get; set; }
        public tblEmployeeLocations(int LocationID, int EmployeeID)
        {
            this.locationID = LocationID;
            this.employeeID = EmployeeID;
        }
    }
}
