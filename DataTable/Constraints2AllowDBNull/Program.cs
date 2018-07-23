using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constraints2AllowDBNull
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new DataTable("MyTable");

            var column = new DataColumn("ColumnWithNull", typeof(string));
            column.AllowDBNull = true; //if you turn it to false 22nd line will throw you an exception as you'll try to add null to a not null column
            table.Columns.Add(column);

            var row = table.NewRow();
            row[0] = DBNull.Value;
            table.Rows.Add(row);

            Console.WriteLine($"Row value: {table.Rows[0][0]}");

            Console.ReadKey();
        }
    }
}
