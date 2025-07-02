using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class SearchSubrubID
    {
        public int suburbID { get; set; }
        public string suburbName { get; set; }
        public int postcode { get; set; }
        public bool active { get; set; }
        public SearchSubrubID(int SuburbID, string SuburbName, int Postcode, bool Active)
        {
            suburbID = SuburbID;
            suburbName = SuburbName;
            postcode = Postcode;
            active = Active;
        }
    }
}
