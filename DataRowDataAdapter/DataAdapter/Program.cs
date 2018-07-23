using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            string conString =
                @"data source = (local)\sqlexpress; integrated security = true; initial catalog = shopdb;";
            SqlConnection connection = new SqlConnection(conString);
            SqlCommand command = new SqlCommand("select * from customers", connection);

            DataTable customers = new DataTable("Customers");

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(customers); //adapter fills customer datatable with original database Customers table data

            foreach (DataRow row in customers.Rows)
            {
                foreach (DataColumn column in customers.Columns)
                {
                    Console.WriteLine($"{column.ColumnName}: {row[column]}");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
