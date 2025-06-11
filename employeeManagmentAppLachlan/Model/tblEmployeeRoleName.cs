using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class tblEmployeeRoleName
    {
        public int roleID { get; set; }
        public string roleName { get; set; }
        public bool active { get; set; }

        public tblEmployeeRoleName(int RoleID, string RoleName, bool Active)
        {
            roleID = RoleID;
            roleName = RoleName;
            active = Active;
        }
    }
}
