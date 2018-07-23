using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            var conStr = @"data source = .\sqlexpress; integrated security = true; initial catalog = shopdb";

            Console.WriteLine("Enter product id");
            int id = int.Parse(Console.ReadLine());

            var command = new SqlCommand("spprodbyid");
            command.CommandType = CommandType.StoredProcedure;
            //var parameter = command.Parameters.Add(new SqlParameter("prodid", SqlDbType.Int));
            //parameter.Direction = ParameterDirection.Input;
            command.Parameters.AddWithValue("prodid", id);

            using (var connection = new SqlConnection(conStr))
            {
                connection.OpenAsync();
                command.Connection = connection;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine($"{reader.GetName(i)}: {reader[i]}");
                        }
                        Console.WriteLine(new string('-',20));
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
