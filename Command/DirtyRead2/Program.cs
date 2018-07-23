using System;
using System.Data;
using System.Data.SqlClient;

namespace DirtyRead2
{
    class Program
    {
        static void Main(string[] args)
        {
            var conString = @"Data Source = localhost\SqlExpress; initial catalog = shopdb; integrated security = true;";
            var connection = new SqlConnection(conString);

            var command = new SqlCommand("select lname, fname, phone from customers", connection);

            Console.WriteLine("Step2. press any key to read Customers");
            Console.ReadKey();

            connection.Open();

            command.Transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);//in IsolationLevel.ReadUncommited we'll get wrong data as in step 1 we change our information, but rollback after => meanwhile anyone who access to data will get wrong information
            //IsolationLevel.ReadCommited waits until the first step executes entirely and then continues its work => we get right information
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} {reader[1]} {reader[2]}");
            }

            Console.ReadKey();
        }
    }
}
