using System;
using System.Data;

namespace AsEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            var shopDB = new DataSet();

            shopDB.ReadXmlSchema(@"C:\Users\HP\Desktop\Test\shopdbschema.xml");
            shopDB.ReadXml(@"C:\Users\HP\Desktop\Test\shopdbdata.xml");

            var customers = shopDB.Tables["Customers"];

            var query = from customer in customers.AsEnumerable() //to iterate on a table as it doesn't implement IEnumerable interface
                        select new {Fname = customer["Fname"], Lname = customer["Lname"]};

            foreach (var customerInfo in query)
            {
                Console.WriteLine($"{customerInfo.Fname} {customerInfo.Lname}");
            }

            Console.ReadKey();
        }
    }
}
