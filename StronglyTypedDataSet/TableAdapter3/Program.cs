using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableAdapter3.ShopDBTableAdapters;

namespace TableAdapter3
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new ShopDB.CustomersDataTable();

            var customersTableAdapter = new CustomersTableAdapter();
            customersTableAdapter.ClearBeforeFill = true;
            customersTableAdapter.Insert("test", "test", "test", "test", "test", "test", "test", new DateTime(9999 / 12 / 31));
            //var insertedRowNumber = customersTableAdapter.Insert("test", "test", "test", "test", "test", "test", "test", new DateTime(9999 / 12 / 31));

            customers = customersTableAdapter.GetData();

            DataRow[] testRows = customers.Select("Phone='test'");

            foreach (DataRow testRow in testRows)
            {
                foreach (DataColumn column in customers.Columns)
                {
                    Console.WriteLine($"{column.ColumnName}: {testRow[column]}");
                }
                Console.WriteLine();
            }

            //now we're going to delete rows with test phone numbers
            Console.WriteLine(new string('*', 30));
            Console.WriteLine($"Total test row(s) deleted: {DeleteTestRows()}");
            //customersTableAdapter.Delete(insertedRowNumber); //doesn't work with sole int
            customers = customersTableAdapter.GetData();
            testRows = customers.Select("Phone = 'test'");

            foreach (DataRow testRow in testRows)
            {
                foreach (DataColumn column in customers.Columns)
                {
                    Console.WriteLine($"{column.ColumnName}: {testRow[column]}");
                }
            }

            Console.ReadKey();
        }

        private static int DeleteTestRows()
        {
            var connectionString =
                @"data source = localhost\sqlexpress; initial catalog =ShopDB; integrated security = true;";
            var commandString = "delete Customers where Phone = 'test'";

            var connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();
                var deleteCommand = new SqlCommand(commandString, connection);
                var rowsAffected = deleteCommand.ExecuteNonQuery();
                return rowsAffected;
            }
        }
    }
}
