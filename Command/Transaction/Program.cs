using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction
{
    class Program
    {
        static void Main(string[] args)
        {
            var conString = @"Data Source = localhost\SqlExpress; initial catalog = shopdb; integrated security = true;";
            var connection = new SqlConnection(conString);

            var command = new SqlCommand("update customers set phone = 'test' where customerno = 1", connection);
            command = new SqlCommand("update customers set phone = '(091)1234567' where customerno = 1", connection);

            try
            {
                connection.Open();

                command.Transaction = connection.BeginTransaction();
                command.ExecuteNonQuery();

                //throw new Exception();

                command.Transaction.Commit();

                Console.WriteLine("transaction commited");
            }
            catch (Exception)
            {
                command.Transaction.Rollback();
                Console.WriteLine("transaction rolled back");
            }

            Console.ReadKey();
        }
    }
}
