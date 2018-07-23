using System;
using System.Data;
using System.Data.SqlClient;

namespace FindWithComplexKey
{
    class Program
    {
        static void Main(string[] args)
        {
            var conStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
            var shopDB = new DataSet("ShopDB");
            var adapter = new SqlDataAdapter("select * from OrderDetails",conStr);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.TableMappings.Add("Table", "OrderDetails");
            adapter.Fill(shopDB);

            var orderDetails = shopDB.Tables[0];
            var orderDetailsRow = orderDetails.Rows.Find(new object[] {1, 3});//complex key (order id with line item)

            foreach (DataColumn column in orderDetails.Columns)
            {
                Console.WriteLine($"{column.ColumnName}: {orderDetailsRow[column]}");
            }

            Console.ReadKey();
        }
    }
}
