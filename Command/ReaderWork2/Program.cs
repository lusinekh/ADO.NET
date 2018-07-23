using System;
using System.Data.SqlClient;

namespace ReaderWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            var conStrBdr = new SqlConnectionStringBuilder();
            conStrBdr.DataSource = @".\SqlExpress";
            conStrBdr.InitialCatalog = "ShopDB";
            conStrBdr.IntegratedSecurity = true;

            var connection = new SqlConnection(conStrBdr.ConnectionString);
            var command = new SqlCommand("select * from customers", connection);

            connection.Open();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader[0]);//gets 0 based column value
                    Console.WriteLine($"{reader["fname"]} {reader["mname"]} {reader["lname"]}"); //gets column value by its name
                    Console.WriteLine(reader[7]);
                    Console.WriteLine(reader.GetFieldValue<DateTime>(8));

                    Console.WriteLine(new string('-', 20));
                }
            }//here reader will be closed

            Console.ReadKey();
        }
    }
}
