using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class LocationTblDepartments
    {
        public int locationid { get; set; }
        public string department { get; set; }
        public int managersid { get; set; }

        public LocationTblDepartments(int LocationID, string Department, int ManagersID)
        {
            locationid = LocationID;
            department = Department;
            managersid = ManagersID;
        }
    }
}
