using System;
using System.Data.SqlClient;

namespace ReaderWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString =
                @"Data Source = localhost\SqlExpress; initial catalog = shopdb; integrated security = true";
            var connection = new SqlConnection(connectionString);

            var command = connection.CreateCommand();
            command.CommandText = "select * from customers";

            connection.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader.GetFieldValue<int>(0)); //gets the value of 0-th column of specified type
                Console.WriteLine($"{reader.GetString(1)} {reader.GetString(3)} {reader.GetString(2)}");//gets string value of i-th column
                Console.WriteLine($"Phone: {reader.GetFieldValue<string>(7)}");
                Console.WriteLine($"Date in system: {reader.GetDateTime(8):D}");

                Console.WriteLine(new string('-',20));
            }

            reader.Close();
            connection.Close();

            Console.ReadKey();
        }
    }
}
