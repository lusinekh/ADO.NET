using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleCommands
{
    class Program
    {
        static void Main(string[] args)
        {
            var conString = @"Data Source = localhost\SqlExpress; initial catalog = shopdb; integrated security = true;";
            var connection = new SqlConnection();
            connection.ConnectionString = conString;

            var command = new SqlCommand();
            command.CommandText = "select * from customers where customerno = 1; select * from employees where employeeid = 1";
            command.Connection = connection;

            connection.Open();

            var reader = command.ExecuteReader();

            WriteData(reader);

            Console.ReadKey();

            reader.NextResult();//returns bool value whether there is a place to look for a next result or not

            WriteData(reader);

            Console.ReadKey();
        }

        static void WriteData(SqlDataReader reader)
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
}
