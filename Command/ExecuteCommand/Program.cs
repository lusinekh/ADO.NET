using System;
using System.Data.SqlClient;

namespace ExecuteScalar
{
    class Program
    {
        static void Main(string[] args)
        {
            var conStr = @"Data Source=localhost\SQLExpress;initial catalog = ShopDB;integrated security =true;";
            var connection = new SqlConnection(conStr);
            connection.Open();

            var command = new SqlCommand("select phone from Customers where customerNo = 7", connection);
            var phoneNumber = command.ExecuteScalar() as string;//returns an object

            Console.WriteLine(phoneNumber);

            Console.ReadKey();
        }
    }
}
