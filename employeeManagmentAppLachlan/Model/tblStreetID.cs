using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class tblStreetID
    {
        public int streetID { get; set; }
        public string streetName { get; set; }
        public tblStreetID(int StreetID, string StreetName)
        {
            streetID = StreetID;
            streetName = StreetName;
        }
    }
}
