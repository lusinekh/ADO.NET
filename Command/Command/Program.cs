using System;
using System.Data.SqlClient;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            var conStr = @"Data Source = (local)\SQLExpress; initial catalog = ShopDB; integrated security = true";
            var connection = new SqlConnection {ConnectionString = conStr};

            //there are 3 methods to create a command
            //1.
            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "T-SQL command";
            //2.
            command = connection.CreateCommand();
            command.CommandText = "Some T-SQL command";
            //3.
            command = new SqlCommand("your sql command",connection);

            Console.ReadKey();
        }
    }
}
