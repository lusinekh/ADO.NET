using System;
using System.Data;
using System.Data.SqlClient;

namespace GetSchemaTable
{
    class Program
    {
        static void Main(string[] args) //HOW WE CAN RETRIEVE DATA FROM DATABASE
        {
            var conStr = @"data source = .\sqlExpress; integrated security = true; initial catalog = shopDb;";
            var connection = new SqlConnection(conStr);

            var command = new SqlCommand("select * from customers", connection);

            using (connection)
            {
                connection.Open();

                using (var reader = command.ExecuteReader()) //get table information
                {
                    DataTable schema = reader.GetSchemaTable(); //getting table scheme

                    //what's there in schema table?
                    //foreach (DataRow row in schema.Rows)
                    //{
                    //    foreach (DataColumn dataColumn in schema.Columns)
                    //    {
                    //        Console.WriteLine($"{dataColumn.ColumnName}: {row[dataColumn]}");
                    //    }
                    //}

                    DataTable customers = new DataTable("Customers");

                    foreach (DataRow dataRow in schema.Rows) //for our customer table columns!
                    {
                        var columnToInsert = new DataColumn((string)dataRow["ColumnName"],(Type)dataRow["DataType"]);
                        customers.Columns.Add(columnToInsert);
                    }

                    //we'll see which columns were added from scheme

                    foreach (DataColumn dataColumn in customers.Columns)
                    {
                        Console.WriteLine($"{dataColumn.ColumnName}: {dataColumn.DataType}");
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
