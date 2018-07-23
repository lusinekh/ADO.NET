using System;
using System.Data;
using TableAdapter1.ShopDbTableAdapters;

namespace TableAdapter1
{
    class Program
    {
        static void Main(string[] args)
        {
            var shopDB = new ShopDb();
            var customersTableAdapter = new CustomersTableAdapter();

            customersTableAdapter.Fill(shopDB.Customers); //this will fill shopdb.customers table with data, so easy!

            foreach (DataRow row in shopDB.Customers.Rows)
            {
                foreach (DataColumn column in shopDB.Customers.Columns)
                {
                    Console.WriteLine($"{column.ColumnName}: {row[column]}");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
