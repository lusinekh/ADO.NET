using System;
using System.Data;

namespace Constraints1Readonly
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new DataTable("MyTable");

            var column = new DataColumn("ReadonlyColumn",typeof(int));
            //column.ReadOnly = true; //uncomment this property and you'll have an exception on 26th line as you'll try to change the value of a readonly column
            table.Columns.Add(column);

            var row = table.NewRow();
            row[0] = 10; //value to readonlycolumn
            table.Rows.Add(row);

            Console.WriteLine(table.Rows[0][0]);

            table.Rows[0][0] = 20;

            Console.WriteLine(table.Rows[0][0]);

            Console.ReadKey();
        }
    }
}
