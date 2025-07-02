using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class AdvQry1
    {
        public int wage { get; set; }
        public string firstName { get; set; }
        public string lastname { get; set; }
        public DateTime hiredate { get; set; }

        public AdvQry1(int Wage, string FirstName,string LastName, DateTime HireDate)
        {
            wage = Wage;
            firstName = FirstName;
            lastname = LastName;
            hiredate = HireDate;
        }
    }
}
