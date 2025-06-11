using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeManagmentAppLachlan.Model
{
    public class tblJobtitle
    {
        public int jobtitleID { get; set; }
        public string jobtitleName { get; set; }
        public bool active { get; set; }

        public tblJobtitle(int JobtitleID, string JobtitleName, bool Active)
        {
            jobtitleID = JobtitleID;
            jobtitleName = JobtitleName;
            active = Active;
        }
    }
}
