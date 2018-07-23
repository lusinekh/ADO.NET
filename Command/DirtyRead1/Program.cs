using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyRead1
{
    class Program
    {
        static void Main(string[] args)
        {
            var conString = @"Data Source = localhost\SqlExpress; initial catalog = shopdb; integrated security = true;";
            var connection = new SqlConnection(conString);

            var command = new SqlCommand("update customers set phone = 'test' where customerNo = 1", connection);
            //command = new SqlCommand("update customers set phone = '(091)1234567' where customerNo = 1", connection);

            Console.WriteLine("Step1. press any key to execute command");
            Console.ReadKey();

            connection.Open();

            command.Transaction = connection.BeginTransaction();
            command.ExecuteNonQuery();

            Console.WriteLine("Step3. press any key to rollback transaction");
            Console.ReadKey();

            command.Transaction.Rollback();
            connection.Close();
            Console.WriteLine("transaction rolled back");

            Console.ReadKey();
        }
    }
}
