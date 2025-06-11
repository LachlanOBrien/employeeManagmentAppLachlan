using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class tblLocationCountry
    {
        public int countryId { get; set; }
        public string countryName { get; set; }
        public bool active { get; set; }
        public tblLocationCountry(int CountryID, string Countryname, bool Active)
        {
            countryId = CountryID;
            countryName = Countryname;
            active = Active;
        }
    }
}
