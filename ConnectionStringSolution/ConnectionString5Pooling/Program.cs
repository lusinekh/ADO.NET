using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionString5Pooling
{
    class Program
    {
        static void Main(string[] args)
        {
            var conStr = @"Data Source= .\SqlExpress; Initial Catalog = ShopDB; integrated security = true; pooling = false";
            var connection = new SqlConnection();

            var sw = new Stopwatch();
            var start = DateTime.Now;
            sw.Start();

            for (int i = 0; i < 1000; i++)
            {
                connection = new SqlConnection(conStr);
                connection.Open();
                connection.Close();
            }
            sw.Stop();
            var end = DateTime.Now - start;
            Console.WriteLine($"Time passed for 1000 iteration is {end.TotalSeconds}");
            Console.WriteLine($"Time passed for 1000 iteration is {sw.Elapsed.TotalSeconds}");
            //with pooling=true 1000 iterations lasted only 150ms
            //with pooling=false 1000 iterations lasted 8.5 seconds => way too long! so if you can use pooling => use it!

            Console.ReadKey();
        }
    }
}
