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
        public bool active { get; set; }
        public tblStreetID(int StreetID, string StreetName, bool Active)
        {
            streetID = StreetID;
            streetName = StreetName;
            active = Active;
        }
    }
}
