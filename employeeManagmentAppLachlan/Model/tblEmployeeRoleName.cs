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

        public tblEmployeeRoleName(int RoleID, string RoleName)
        {
            roleID = RoleID;
            roleName = RoleName;
        }
    }
}
