using System;
using System.Data;

namespace STDataSet4
{
    class Program
    {
        static void Main(string[] args)
        {
            var simpleShopDB = new DataSet();

            simpleShopDB.ReadXmlSchema(@"C:\Users\HP\Desktop\Test\ShopDbSchema.xml");
            simpleShopDB.ReadXml(@"C:\Users\HP\Desktop\Test\ShopDBData.xml");

            var strongShopDB = new ShopDb();

            strongShopDB.Customers.Merge(simpleShopDB.Tables["Customers"]);
            strongShopDB.Orders.Merge(simpleShopDB.Tables["Orders"]);

            var selectedCustomer = strongShopDB.Customers.FindByCustomerNo(3);

            Console.WriteLine($"{selectedCustomer.LName} {selectedCustomer.FName} {selectedCustomer.MName}");

            foreach (ShopDb.OrdersRow row in selectedCustomer.GetOrdersRows())
            {
                Console.WriteLine($"\tOrderID: {row.OrderID}");
                Console.WriteLine($"\tOrderDate: {row.OrderDate}");
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
