using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class SearchStreetID
    {
        public int streetID { get; set; }
        public string streetName { get; set; }
        public bool active { get; set; }
        public SearchStreetID(int StreetID, string StreetName, bool Active)
        {
            streetID = StreetID;
            streetName = StreetName;
            active = Active;
        }
    }
}
