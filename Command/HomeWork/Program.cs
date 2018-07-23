using System;
using System.Data.SqlClient;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            var conStr = @"data source = .\sqlexpress; integrated security = true; initial catalog = shopdb";
            var connection = new SqlConnection(conStr);

            var command = new SqlCommand("select * from Products");
            command.Connection = connection;

            using (connection)
            {
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine($"{reader.GetName(i)}: {reader[i]}");
                        }
                        Console.WriteLine(new string('-', 20));
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
