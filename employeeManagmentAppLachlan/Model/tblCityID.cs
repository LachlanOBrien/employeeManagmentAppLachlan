using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class tblCityID
    {
        public int cityID { get; set; }
        public string cityName { get; set; }
        public tblCityID(int CityID, string CityName)
        {
            cityID = CityID;
            cityName = CityName;
        }
    }
}
