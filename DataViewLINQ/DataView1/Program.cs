using System;
using System.Data;
using System.Data.SqlClient;

namespace DataView1
{
    class Program
    {
        static void Main(string[] args)
        {
            var conStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
            var customers = new DataTable();
            customers.TableName = "Customers";
            var adapter = new SqlDataAdapter("select * from customers", conStr);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(customers);

            //var customersView = new DataView(); // same as SQL views
            //customersView.Table = customers; // or like this var customersView = new DataView(customers);
            var customersView = new DataView(customers, "Fname like 'V%'", "city, phone", DataViewRowState.CurrentRows); //currentRows is default choice

            foreach (DataRowView rowView in customersView)
            {
                Console.WriteLine($"{rowView["Fname"]} {rowView["LName"]} {rowView["Mname"]}");
                Console.WriteLine($"{rowView["City"]}");
                Console.WriteLine($"{rowView["phone"]}");
                Console.WriteLine(new string('-', 30));
            }

            Console.ReadKey();
        }
    }
}
