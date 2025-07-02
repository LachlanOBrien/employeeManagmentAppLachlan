using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class SearchLocationCountry
    {
        public int countryId { get; set; }
        public string countryName { get; set; }
        public bool active { get; set; }
        public SearchLocationCountry(int CountryID, string Countryname, bool Active)
        {
            countryId = CountryID;
            countryName = Countryname;
            active = Active;
        }
    }
}
