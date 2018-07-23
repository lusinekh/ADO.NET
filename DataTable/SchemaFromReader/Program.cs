using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaFromReader
{
    class Program
    {
        static DataTable CreateSchemaFromReader(SqlDataReader reader, string tableName)
        {
            var table = new DataTable(tableName);

            for (int i = 0; i < reader.FieldCount; i++)
            {
                table.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
            }

            return table;
        }

        static void WriteDataFromReader(SqlDataReader reader, DataTable table)
        {
            while (reader.Read())
            {
                DataRow row = table.NewRow();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[i] = reader[i];
                }

                table.Rows.Add(row);
            }
        }

        static void Main(string[] args)
        {
            var conStr = @"data source = .\sqlExpress; integrated security = true; initial catalog = shopDb;";
            var connection = new SqlConnection(conStr);

            var command = new SqlCommand("select * from customers", connection);

            using (connection)
            {
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    DataTable table = CreateSchemaFromReader(reader, "Customers"); //create table
                    WriteDataFromReader(reader, table); //write date into table from reader

                    foreach (DataRow dataRow in table.Rows)
                    {
                        foreach (DataColumn column in table.Columns)
                        {
                            Console.WriteLine($"{column.ColumnName}: {dataRow[column]}");
                        }
                        Console.WriteLine(new string('-', 20));
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
