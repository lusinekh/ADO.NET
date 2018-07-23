using System;
using System.Data;
using System.Data.SqlClient;

namespace ConnectionString2using
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\SQLExpress; Initial Catalog = ShopDB; Integrated Security = True";
            SqlConnection connection = new SqlConnection(conStr);

            using (connection) //may write using(var connection = new SqlConnection(constr))
            {
                connection.StateChange += connection_StateChange; //we add an event

                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }// here dispose() method is called to close our connection

            Console.ReadKey();
        }

        private static void connection_StateChange(object sender, StateChangeEventArgs e) //event handler
        {
            var connection = sender as SqlConnection;

            Console.WriteLine();

            Console.WriteLine($"Connected to{Environment.NewLine}Data Source: {connection?.DataSource}{Environment.NewLine}Database: {connection?.Database}{Environment.NewLine}State: {connection?.State}");
        }
    }
}
