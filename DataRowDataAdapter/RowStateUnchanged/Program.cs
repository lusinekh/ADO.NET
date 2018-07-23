using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowStateUnchanged
{
    class Program
    {
        static void Main(string[] args)
        {
            var conString = @"data source =.\sqlexpress; initial catalog = ShopDB; integrated security =true";
            var commandString = "select * from Customers";

            var customers = new DataTable("Customers");

            LoadData(conString, commandString, customers); //when table.Load() => rowState = unchanged
            for (int i = 0; i < customers.Rows.Count; i++)
            {
                Console.WriteLine($"Row {i}: {customers.Rows[i].RowState}");
            }

            customers.Clear();
            Console.WriteLine(new string('_',20));

            SimpleLoadData(conString, commandString, customers); //rowState = Added => need to do AcceptChanges()
            for (int i = 0; i < customers.Rows.Count; i++)
            {
                Console.WriteLine($"Row {i}: {customers.Rows[i].RowState}");
            }

            Console.ReadKey();
        }

        private static void SimpleLoadData(string conString, string commandString, DataTable table)
        {
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();
                var command = new SqlCommand { CommandText = commandString, Connection = connection };
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var row = table.NewRow();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[i] = reader[i];
                        }

                        table.Rows.Add(row);
                    }
                }
            }
        }

        private static void LoadData(string conString, string commandString, DataTable table)
        {
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();
                var command = new SqlCommand {CommandText = commandString, Connection = connection};
                using (var reader = command.ExecuteReader())
                {
                    table.Load(reader); //fills data into table from SQLDataReader
                }
            }
        }
    }
}
