using employeeManagmentAppLachlan.Model;
using employeeManagmentAppLachlan.Repositories;

namespace employeeManagmentAppLachlan
{
    public class Program //saved in onedrive>docc>12tpi>C#>oop>employeeManagmentAppLachlan OR .......oop>WorkPLS
                         // .mdf is saved in the DB folder onedrive>docc>12tpi>sql>DB
    {
        private static StorageManager storageManager;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\AC147303\\ONEDRIVE - AVONDALE COLLEGE\\DOCUMENTS\\12TPI\\SQL\\DB\\EMPLOYEEMANAGMENT.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            storageManager = new StorageManager(connectionString);

            storageManager = new StorageManager(connectionString);
            //get list from storage manager
            List<LocationTblLocation> locationTblLocations = storageManager.GetLocationTblLocations();
            foreach (LocationTblLocation location in locationTblLocations)
            {
                Console.WriteLine($"{location.Location_ID}\t{location.Location_Name}");
            }
        }
    }
}
