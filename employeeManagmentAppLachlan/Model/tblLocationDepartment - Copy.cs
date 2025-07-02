using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class tblLocationDepartment
    {
        public int departmentID { get; set; }
        public int locationID { get; set; }

        public tblLocationDepartment(int DepartmentID, int LocationID)
        {
            departmentID = DepartmentID;
            locationID = LocationID;
        }
    }
}
