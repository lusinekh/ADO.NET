using System;
using System.Data.SqlClient;

namespace ConnectionString1
{
    class Program
    {
        static void Main(string[] args)
        {
            var conStr = @"Data Source=(local)\SQLExpress; Initial Catalog = ShopDB; Integrated Security=True";
            //these two variants will work equally well
            //var conStr = @"Data Source=.\SQLExpress; Initial Catalog = ShopDB; Integrated Security=True";
            //var conStr = @"Data Source=localhost\SQLExpress; Initial Catalog = ShopDB; Integrated Security=True";
            var connection = new SqlConnection(conStr);

            try
            {
                connection.Open();
                Console.WriteLine(connection.State);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine(connection.State);
            }

            Console.ReadKey();
        }
    }
}
