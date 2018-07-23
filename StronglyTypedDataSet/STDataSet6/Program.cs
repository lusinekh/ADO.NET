using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STDataSet6
{
    class Program
    {
        static void Main(string[] args)
        {
            var simpleShopDB = new DataSet();
            simpleShopDB.ReadXmlSchema(@"C:\Users\HP\Desktop\Test\ShopDbSchema.xml");
            simpleShopDB.ReadXml(@"C:\Users\HP\Desktop\Test\ShopDBData.xml");

            var strongShopDB = new ShopDB();
            strongShopDB.Customers.Merge(simpleShopDB.Tables["Customers"]);
            strongShopDB.AcceptChanges();

            var selectedCustomer = strongShopDB.Customers.FindByCustomerNo(1);
            selectedCustomer.Phone = "testValue";

            DataSet dataSetWithChanges = strongShopDB.GetChanges(); //returns dataset with all the changes made on strongshopdb

            var instance = dataSetWithChanges as ShopDB;//we can downcast data set to shopdb as shopdb is a dataset

            foreach (DataRow row in dataSetWithChanges.Tables["Customers"].Rows)
            {
                foreach (DataColumn column in dataSetWithChanges.Tables["Customers"].Columns)
                {
                    Console.WriteLine($"{column.ColumnName}: {row[column]}");
                }
            }

            Console.ReadKey();
        }
    }
}
