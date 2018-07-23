using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowVersionWhenDelete
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new DataTable();
            table.Columns.Add(new DataColumn("FirstColumn", typeof(string)));

            table.LoadDataRow(new object[] { "One" }, true);
            table.LoadDataRow(new object[] { "Two" }, true);
            table.LoadDataRow(new object[] { "Three" }, true);

            table.Rows[0].Delete();

            try
            {
                Console.WriteLine(table.Rows[0][0]); //deleted row information cannot be accessed
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.ForegroundColor =ConsoleColor.Gray;
            }

            Console.WriteLine();
            Console.WriteLine(table.Rows[0][0,DataRowVersion.Original]); //since, original value can be viewed

            Console.ReadKey();
        }
    }
}
