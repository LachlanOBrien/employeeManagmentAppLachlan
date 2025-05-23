using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class LocationTblLocationAdress
    {
        public int locationid { get; set; }
        public int cityid { get; set; }
        public string country { get; set; }

        public LocationTblLocationAdress(int LocationID,int CityID,string Country)
        {
            locationid = LocationID;
            cityid = CityID;
            country = Country;

        }
    }
}
