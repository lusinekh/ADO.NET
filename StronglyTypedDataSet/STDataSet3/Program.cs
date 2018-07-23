using System;
using System.Data;

namespace STDataSet3
{
    class Program
    {
        static void Main(string[] args)
        {
            var simpleShopDB = new DataSet();
            simpleShopDB.ReadXmlSchema(@"C:\Users\HP\Desktop\Test\ShopDbSchema.xml");
            simpleShopDB.ReadXml(@"C:\Users\HP\Desktop\Test\ShopDBData.xml");

            var strongShopDB = new ShopDB();

            strongShopDB.Customers.Merge(simpleShopDB.Tables["Customers"]); //merged customers table from simple data set with strongly typed data set shopdb

            foreach (DataRow row in strongShopDB.Customers.Rows)
            {
                foreach (DataColumn column in strongShopDB.Customers.Columns)
                {
                    Console.WriteLine($"{column.ColumnName}: {row[column]}");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
