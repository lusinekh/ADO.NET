using System;
using System.Data;
using System.Data.SqlClient;

namespace StoredProcedure3
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"initial catalog = shopDB; integrated security = true; data source = .\sqlExpress;";
            var connection = new SqlConnection { ConnectionString = connectionString };

            var command = new SqlCommand("proc_ret_value", connection) { CommandType = CommandType.StoredProcedure };
            var param = command.Parameters.Add(new SqlParameter());
            param.Direction = ParameterDirection.ReturnValue;

            using (connection)
            {
                connection.Open();

                command.ExecuteNonQuery();

                Console.WriteLine(param.Value);
            }

            Console.ReadKey();
        }
    }
}
