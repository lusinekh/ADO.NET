using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametrizedCommand1
{
    class Program
    {
        static void Main(string[] args)
        {
            var conStr = @"Data Source = (local)\SqlExpress; integrated security = true; initial Catalog = shopDB;";
            var connection = new SqlConnection(conStr);

            Console.WriteLine("Enter Client ID");

            var id = Console.ReadLine(); //here user may write 1 or customerNo = 7 and will collect other user info => user can modify query structure!

            var commandStr = $"select * from customers where customerNo = {id}";

            using (connection)
            {
                connection.Open();
                var command = new SqlCommand(commandStr, connection);

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
                }//reader.Close();
            }//connection.Close();

            Console.ReadKey();
        }
    }
}
