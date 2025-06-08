using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class tblLocation
    {
        public int locationID { get; set; }
        public string locationName { get; set; }
        public int countryID { get; set; }
        public int suburbID { get; set; }
        public int streetID { get; set; }
        public int cityID { get; set; }
        public int streetNumber { get; set; }

        public tblLocation(int LocationID, string LocationName, int CountryID, int SuburbID, int StreetID, int CityID, int StreetNumber)
        {
            locationID = LocationID;
            locationName = LocationName;
            countryID = CountryID;
            suburbID = SuburbID;
            streetID = StreetID;
            cityID = CityID;
            streetNumber = StreetNumber;
        }
    }
}
