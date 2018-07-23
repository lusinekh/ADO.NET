using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinWithLINQ1
{
    class Program
    {
        static void Main(string[] args)
        {
            var shopDB = new DataSet();
            shopDB.ReadXmlSchema(@"C:\Users\HP\Desktop\Test\shopdbschema.xml");
            shopDB.ReadXml(@"C:\Users\HP\Desktop\Test\shopdbdata.xml");

            var customers = shopDB.Tables["Customers"];
            var orders = shopDB.Tables["Orders"];

            var inner = from customer in customers.AsEnumerable() //inner join
                        join order in orders.AsEnumerable()
                            on customer["CustomerNo"] equals order["CustomerNo"]
                        select new { FName = customer["Fname"], LName = customer["LName"], OrderDate = order["OrderDate"] };

            foreach (var item in inner)
            {
                Console.WriteLine($"{item.OrderDate:D} {item.FName} {item.LName}");
            }
            Console.WriteLine(new string('-', 30));

            var outer = from customer in customers.AsEnumerable() //left outer join
                        join order in orders.AsEnumerable()
                            on customer["CustomerNo"] equals order["CustomerNo"] into joinGroup
                        select new {FName = customer["Fname"], LName = customer["LName"], OrderDate = joinGroup};

            foreach (var item in outer)
            {
                Console.WriteLine($"{item.FName} {item.LName}");
                foreach (var variable in item.OrderDate)
                {
                    Console.WriteLine($"\t{variable["OrderDate"]}");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
