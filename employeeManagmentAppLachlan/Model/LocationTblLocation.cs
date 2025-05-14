using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    internal class LocationTblLocation
    {
        /*  private string Location_Name;
          private int Location_id;

          public LocationTblLocation(string inLocation_Name, int inLocation_id) //constuctor 
          {
              Location_Name = inLocation_Name;
              Location_id = inLocation_id;
          }*/

        public int Location_ID { get; set; }
        public string Location_Name { get; set; }

        public LocationTblLocation(int LocationID, string LocationName)
        {
            Location_ID = LocationID;
            Location_Name = LocationName; 
        }
    }
}
    