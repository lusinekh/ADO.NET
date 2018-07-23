using System;
using System.Data;
using System.Data.SqlClient;

namespace HomeWork //need revising
{
    static class TableExtension
    {
        public static void LoadWithSchema(this DataTable table, SqlDataReader reader)
        {
            DataTable scheme = reader.GetSchemaTable();

            foreach (DataRow row in scheme.Rows)
            {
                var column = new DataColumn((string)row["ColumnName"]);
                column.AllowDBNull = (bool)row["AllowDBNull"];
                column.AutoIncrement = (bool)row["IsIdentity"];
                column.ReadOnly = (bool)row["IsReadOnly"];
                column.DataType = (Type)row["DataType"];
                column.Unique = (bool)row["IsUnique"];

                if (column.DataType == typeof(string)) column.MaxLength = (int)row["ColumnSize"];
                if (column.AutoIncrement == true)
                {
                    column.AutoIncrementStep = -1;
                    column.AutoIncrementSeed = 0;//start from 0
                }
            }
        }
    }

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
            var conStr = @"data source = localhost\SqlExpress; integrated security= true; initial catalog = shopdb;";

            var shopDB = new DataSet();

            var orders = new DataTable("Orders");
            var customers = new DataTable("Customers");
            var employees = new DataTable("Employees");
            var orderDetails = new DataTable("OrderDetails");
            var products = new DataTable("Products");

            var tableArray = new DataTable[] { orders, customers, employees, orderDetails, products };

            using (var connection = new SqlConnection(conStr))
            {
                connection.Open();
                SqlCommand command;

                for (int i = 0; i < tableArray.Length; i++)
                {
                    command = new SqlCommand($"select * from {tableArray[i].TableName}", connection);
                    using (var reader = command.ExecuteReader())
                    {
                        tableArray[i] = CreateSchemaFromReader(reader, tableArray[i].TableName);
                        WriteDataFromReader(reader, tableArray[i]);
                    }
                }
            }
            shopDB.Tables.AddRange(tableArray);

            /*
             products = tableArray[4];
             orderDetails = tableArray[3];
             orders = tableArray[0];
             employees = tableArray[2];
             customers = tableArray[1];
             */

            tableArray[4].Constraints.Add(new UniqueConstraint(tableArray[4].Columns[0], true));
            //products.PrimaryKey = new DataColumn[] { products.Columns[0] };

            tableArray[3].Constraints.Add(
                new UniqueConstraint(new DataColumn[] { tableArray[3].Columns[0], tableArray[3].Columns[1] }, true));
            tableArray[3].Constraints.Add(new ForeignKeyConstraint(tableArray[4].Columns["ProdID"],
                tableArray[3].Columns["ProdID"]));
            tableArray[3].Constraints.Add(new ForeignKeyConstraint(tableArray[0].Columns["OrderID"],
                tableArray[3].Columns["OrderID"]));

            tableArray[0].Constraints.Add(new UniqueConstraint(tableArray[0].Columns[0], true));
            tableArray[0].Constraints.Add(new ForeignKeyConstraint(tableArray[2].Columns["EmployeeID"],
                tableArray[0].Columns["EmployeeID"]));
            tableArray[0].Constraints.Add(new ForeignKeyConstraint(tableArray[1].Columns["CustomerNo"],
                tableArray[0].Columns["CustomerNo"]));

            tableArray[2].Constraints.Add(new UniqueConstraint(tableArray[2].Columns[0], true));
            tableArray[2].Constraints.Add(new ForeignKeyConstraint(tableArray[2].Columns["EmployeeID"],
                tableArray[2].Columns["ManagerEmpID"]));

            tableArray[1].Constraints.Add(new UniqueConstraint(tableArray[1].Columns[0], true));

            Console.ReadKey();
        }
    }
}
