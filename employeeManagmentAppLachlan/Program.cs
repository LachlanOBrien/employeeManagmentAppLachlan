using employeeManagmentAppLachlan.Repositories;

namespace employeeManagmentAppLachlan
{
    public class Program //saved in onedrive>docc>12tpi>oop>employeeManagmentAppLachlan
    {
        private static StorageManager storageManager;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeManagment;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            storageManager = new StorageManager(connectionString);
        }
    }
}
