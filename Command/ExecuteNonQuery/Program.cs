using System;
using System.Data.SqlClient;

namespace ExecuteNonQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            var conStr = @"Data Source = .\SQLexpress; initial catalog = shopdb; integrated security = true";
            var connection = new SqlConnection(conStr);
            connection.Open();

            //insert
            var command = connection.CreateCommand();
            command.CommandText = "insert Customers values ('Petr','Yermolaev','Vasilevich','somewhere in Russia',null,'Alushta','(099)1234567',null)";

            int rowsAffected = command.ExecuteNonQuery(); //will return amount of rows affected
            Console.WriteLine($"Rows affected: {rowsAffected}");

            //delete
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "delete customers where address1 = 'somewhere in Russia'";

            rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine($"Rows affected: {rowsAffected}");

            Console.ReadKey();
        }
    }
}
