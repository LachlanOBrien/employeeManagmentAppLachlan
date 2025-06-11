using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class tblDepartments
    {
        public string department { get; set; }
        public int managersID { get; set; }
        public int departmentID { get; set; }
        public bool active { get; set; }

        public tblDepartments( string Department, int ManagersID, int DepartmentID, bool Active)
        {
            department = Department;
            managersID = ManagersID;
            departmentID = DepartmentID;
            active = Active;
        }
    }
}
