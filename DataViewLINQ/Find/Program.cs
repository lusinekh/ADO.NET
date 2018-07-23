using System;
using System.Data;
using System.Data.SqlClient;

// запись схемы и данных базы данных в XML файл

namespace Find
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataSet shopDB = CreateShopDBDataSet(); // создание базы данных ShopDB

            //shopDB.WriteXmlSchema(@"C:\Users\HP\Desktop\Test\ShopDbSchema.xml"); // запсиь схемы ShopDB в XML файл
            //shopDB.WriteXml(@"C:\Users\HP\Desktop\Test\ShopDBData.xml"); // запись данных ShopDB в XML файл

            var shopDB = new DataSet();
            shopDB.DataSetName = "ShopDB";

            var conStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
            var adapter = new SqlDataAdapter("select * from customers",conStr);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(shopDB);

            var customers = shopDB.Tables[0];
            var customersRow = customers.Rows.Find(6); //need to specify a primary key value!

            foreach (DataColumn column in customers.Columns)
            {
                Console.WriteLine($"{column.ColumnName}: {customersRow[column]}");
            }

            Console.ReadKey();
        }

        private static DataSet CreateShopDBDataSet()
        {

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";

            string commandString = "SELECT * FROM Customers;" +
                                    "SELECT * FROM Orders;" +
                                    "SELECT * FROM OrderDetails;" +
                                    "SELECT * FROM Products";

            DataSet shopDB = new DataSet("ShopDB");

            // создание адаптера данных для базы данных ShopDB
            SqlDataAdapter adapter = new SqlDataAdapter(commandString, connectionString);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            // Маппинг таблиц для ShopDB
            adapter.TableMappings.Add("Table", "Customers");
            adapter.TableMappings.Add("Table1", "Orders");
            adapter.TableMappings.Add("Table2", "OrderDetails");
            adapter.TableMappings.Add("Table3", "Products");

            // получение аднных с помощью адаптера данных
            adapter.Fill(shopDB);

            // получение ссылок на таблицы
            var customers = shopDB.Tables["Customers"];
            var orders = shopDB.Tables["Orders"];
            var orderDetails = shopDB.Tables["OrderDetails"];
            var products = shopDB.Tables["Products"];

            // создание связей для таблиц
            shopDB.Relations.Add("Customers_Orders", customers.Columns["CustomerNo"], orders.Columns["CustomerNo"]);
            shopDB.Relations.Add("Orders_OrderDetails", orders.Columns["OrderID"], orderDetails.Columns["OrderID"]);
            shopDB.Relations.Add("Products_OrderDetails", products.Columns["ProdID"], orderDetails.Columns["ProdID"]);

            return shopDB;
        }

    }
}
