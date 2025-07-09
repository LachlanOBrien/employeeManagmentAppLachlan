using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class ComplexQry5
    {
        public int wage { get; set; }
        public string jobTitleName { get; set; }
        public ComplexQry5( int Wage, string JobTitleName)
        {
            wage = Wage;
            jobTitleName = JobTitleName;
        }
    }
}
