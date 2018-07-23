using System;
using STDataSet5.ShopDBTableAdapters;

namespace STDataSet5
{
    class Program
    {
        static void Main(string[] args)
        {
            var shopDB = new ShopDB();

            new CustomersTableAdapter().Fill(shopDB.Customers);
            new OrdersTableAdapter().Fill(shopDB.Orders);
            new OrderDetailsTableAdapter().Fill(shopDB.OrderDetails);
            new ProductsTableAdapter().Fill(shopDB.Products);

            foreach (ShopDB.CustomersRow customer in shopDB.Customers)
            {
                var orders = customer.GetOrdersRows();

                if (orders.Length > 0) //if customer has ordered anything
                {
                    Console.WriteLine($"{customer.LName} {customer.FName} {customer.MName}");
                    Console.WriteLine();

                    foreach (ShopDB.OrdersRow order in orders)
                    {
                        Console.WriteLine($"\tOrderID: {order.OrderID}, {order.OrderDate}");
                        foreach (ShopDB.OrderDetailsRow orderDetail in order.GetOrderDetailsRows())
                        {
                            var product = orderDetail.ProductsRow;
                            Console.WriteLine($"\t\tLine: {orderDetail.LineItem} - {product.Description.Trim()}, {orderDetail.TotalPrice:C}");
                        }
                        Console.WriteLine();
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
