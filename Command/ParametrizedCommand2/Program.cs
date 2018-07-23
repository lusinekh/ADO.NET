using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametrizedCommand2
{
    class Program
    {
        static void Main(string[] args)
        {
            var conStr = @"Data Source = (local)\SqlExpress; integrated security = true; initial Catalog = shopDB;";
            var connection = new SqlConnection(conStr);

            Console.WriteLine("Enter Client ID");

            var id = Console.ReadLine(); //

            var commandStr = $"select * from customers where customerNo = @custNo";

            using (connection)
            {
                connection.Open();
                var command = new SqlCommand(commandStr, connection);
                command.Parameters.AddWithValue("custNo", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read()) //if you try to reproduce what we tried in previous example you'll get an exception saying that it can't convert 1 or customerNo = 2 to an int
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine($"{reader.GetName(i)}: {reader[i]}");
                        }
                        Console.WriteLine(new string('-', 20));
                    }
                }//reader.Close();
            }//connection.Close();

            Console.ReadKey();
        }
    }
}
