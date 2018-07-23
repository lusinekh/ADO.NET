using System;
using System.Data;
using System.Data.SqlClient;

namespace ParametrizedCommand3
{
    class Program
    {
        static void Main(string[] args)
        {
            var conStr = @"Data Source = (local)\SqlExpress; integrated security = true; initial Catalog = shopDB;";
            var connection = new SqlConnection(conStr);

            using (connection)
            {
                var command = new SqlCommand("set @myVar = 2", connection);
                SqlParameter myParameter = command.Parameters.Add(new SqlParameter("myVar", SqlDbType.Int));
                myParameter.Direction = ParameterDirection.Output; //must write mandatory!

                connection.Open();

                command.ExecuteNonQuery();
                Console.WriteLine(myParameter.Value);
            }//connection.Close();

            Console.ReadKey();
        }
    }
}
