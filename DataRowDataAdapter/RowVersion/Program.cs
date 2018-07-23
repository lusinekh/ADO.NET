using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new DataTable();
            table.Columns.Add(new DataColumn("FirstColumn", typeof(string)));

            table.LoadDataRow(new object[] {"One"}, true);
            table.LoadDataRow(new object[] {"Two"}, true);
            table.LoadDataRow(new object[] {"Three"}, true);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i][0] = "Changed value";
            }

            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"Current value: {row[0,DataRowVersion.Current]}");
                Console.WriteLine($"Original value: {row[0,DataRowVersion.Original]}"); //we can get row's initial value (before changes)
                Console.WriteLine($"Row State = {row.RowState}");
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
