using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class LocationTblLocationCity
    {
        public int City_ID { get; set; }
        public string suburb { get; set; }
        public string postcode { get; set; }
        public string street { get; set; }
        public string city { get; set; }

        public LocationTblLocationCity(int CityID, string Suburb, string Postcode, string Street, string City)
        {
            City_ID = CityID;
            suburb = Suburb;
            postcode = Postcode;
            street = Street;
            city = City;
        }
    }
}
