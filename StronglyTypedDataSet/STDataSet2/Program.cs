using System;
using System.Data;

namespace STDataSet2
{
    class Program
    {
        static void Main(string[] args)
        {
            var shopDB = new ShopDB();

            var customersRow = shopDB.Customers.NewCustomersRow();

            customersRow.FName = "Aleksey";
            customersRow.LName = "Petrov";
            customersRow.MName = "Nikolaevich";
            customersRow.Address1 = "Lujnaya";
            customersRow.Address2 = null; //!!! not DBNull.Value
            customersRow.City = "Kiev";
            customersRow.Phone = "(096)4578956";
            customersRow.DateInSystem = new DateTime(2009,09,18);

            shopDB.Customers.Rows.Add(customersRow);
            shopDB.Customers.AddCustomersRow("Nikolay", "Aleksandrov", "Anatolevich", "Moskovskaya 15", null, "Chernigov",
                "(063)1298445", new DateTime(2010, 12, 30));

            var selectedCustomer = shopDB.Customers.FindByCustomerNo(-2);

            selectedCustomer.BeginEdit();
            //selectedCustomer.Phone = "testPhone";
            selectedCustomer.SetMNameNull();
            selectedCustomer.EndEdit();

            //foreach (DataRow row in shopDB.Customers.Rows)
            //{
            //    foreach (DataColumn column in shopDB.Customers.Columns)
            //    {
            //        Console.WriteLine($"{column.ColumnName}: {row[column]}");
            //    }
            //    Console.WriteLine();
            //}
            Console.WriteLine($"Last name: {selectedCustomer.LName}");
            Console.WriteLine($"First name: {selectedCustomer.FName}");
            //Console.WriteLine($"Phone: {selectedCustomer.Phone}");
            Console.WriteLine(selectedCustomer.IsMNameNull()
                ? "no middle name found"
                : $"Middle name: {selectedCustomer.MName}");


            Console.ReadKey();
        }
    }
}
