using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcedure2
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"initial catalog = shopDB; integrated security = true; data source = .\sqlExpress;";
            var connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            Console.WriteLine("Enter employee id");
            int empId = int.Parse(Console.ReadLine());

            var command = new SqlCommand("proc_p1", connection) { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddWithValue("empid", empId);

            using (connection)
            {
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine($"{reader.GetName(i)}: {reader[i]}");
                    }
                    Console.WriteLine(new string('-', 20));
                }

                reader.Close();
            }//connection.Close();

            Console.ReadKey();
        }
    }
}
