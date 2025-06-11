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
        public bool active { get; set; }
        public tblCityID(int CityID, string CityName, bool Active)
        {
            cityID = CityID;
            cityName = CityName;
            active = Active;
        }
    }
}
