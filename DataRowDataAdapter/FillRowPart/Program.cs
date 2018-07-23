using System;
using System.Data;
using System.Data.SqlClient;

namespace FillRowPart
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"data source = .\sqlexpress; initial catalog = shopdb; integrated security = true;";
            var commandString = "select * from Customers";
            var adapter = new SqlDataAdapter(commandString,connectionString);
            var table = new DataTable();
            var step = 2;

            for (int i = 0; adapter.Fill(i,step,table) >0; i+=step)
            {
                Console.WriteLine(table.Rows.Count);

                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        Console.WriteLine($"{column.ColumnName} {row[column]}");
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
            }
            Console.ReadKey();
        }
    }
}
