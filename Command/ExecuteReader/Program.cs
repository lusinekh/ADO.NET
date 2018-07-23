using System;
using System.Data.SqlClient;

namespace ExecuteReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var conStr = @"Data Source = (local)\sqlexpreSS; initial catalog = shopdb; integrated security = true;";
            var connection = new SqlConnection(conStr);
            connection.Open();

            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = "select * from customers"
            };
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) //.Read() advances reader to the next record
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine($"{reader.GetName(i)}: {reader[i]}");//GetName() gets the name of the specified column //reader[i] gets the value of current row where reader is and selects i-th column
                }
                Console.WriteLine(new string('-',20));
            }

            Console.ReadKey();
        }
    }
}
