using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class tblSubrubID
    {
        public int suburbID { get; set; }
        public string suburbName { get; set; }
        public int postcode { get; set; }
        public tblSubrubID(int SuburbID, string SuburbName, int Postcode)
        {
            suburbID = SuburbID;
            suburbName = SuburbName;
            postcode = Postcode;
        }
    }
}
