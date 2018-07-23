using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcedure1
{
    class Program
    {
        static void Main(string[] args)
        {
            var conStr = @"integrated security= true; data source = localhost\sqlExpress; initial catalog = shopDB;";
            var connection = new SqlConnection(conStr);

            //var command = new SqlCommand("execute selectEmp", connection);
            var command = new SqlCommand("selectEmp");
            command.CommandType = CommandType.StoredProcedure;

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
                        Console.WriteLine(new string('_', 20));
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
