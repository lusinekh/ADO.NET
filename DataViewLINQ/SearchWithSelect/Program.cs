using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWithSelect
{
    class Program
    {
        static void Main(string[] args)
        {
            var conStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
            var shopDB = new DataSet("ShopDB");
            var adapter = new SqlDataAdapter("select * from Customers", conStr);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.TableMappings.Add("Table", "Customers");
            adapter.Fill(shopDB);

            var customers = shopDB.Tables[0];
            //var customersRows = customers.Select("City = 'Chernigov'"); //in select write a filter expression
            //var customersRows = customers.Select("lname like 'vij%'");
            //var customersRows = customers.Select("city = 'chernigov' or city = 'kiev'");
            var customersRows = customers.Select("address1 like 'luj%'", "customerno asc"); //second parameter specifys ordering column

            foreach (DataRow row in customersRows)
            {
                foreach (DataColumn column in customers.Columns)
                {
                    Console.WriteLine($"{column.ColumnName}: {row[column]}");
                }
                Console.WriteLine(new string('-', 30));
            }

            Console.ReadKey();
        }
    }
}
