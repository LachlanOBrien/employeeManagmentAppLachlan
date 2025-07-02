using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class AdvQry3
    {
        public int wage { get; set; }
        public int employeeID { get; set; }
        public string gender { get; set; }

        public AdvQry3(int Wage, int EmployeeID, string Gender)
        {
            wage = Wage;
            employeeID = EmployeeID;
            gender = Gender;
        }
    }
}
