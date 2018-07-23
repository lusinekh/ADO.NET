using System;
using System.Data.SqlClient;

namespace DBNullValue
{
    class Program
    {
        static void Main(string[] args)
        {
            var conString = @"Data Source = localhost\SqlExpress; initial catalog = shopdb; integrated security = true;";
            var connection = new SqlConnection(conString);

            var command = new SqlCommand("select * from customers") { Connection = connection };
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetString(1)} {reader.GetString(3)} {reader.GetString(2)}");
                if (reader[5]==DBNull.Value) Console.WriteLine("Address2 - no data");//                             !!! works well !!!
                //reader.GetString(5) == null null check gives nothing
                //reader.IsDBNull(5) checks if the value of i-th column in db is null or not                        !!! works well !!!
                //reader[5]==null won't generate an exception, but will not return anything if value in db in NULL
                else Console.WriteLine(reader[5]);
                Console.WriteLine(new string('-', 20));
            }

            Console.ReadKey();
        }
    }
}
