using System;
using System.Data;

namespace Constraint4Unique
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new DataTable("MyTable");

            var column = new DataColumn("UniqueColumn", typeof(string));
            column.Unique = true;
            table.Columns.Add(column);

            var row = table.NewRow();
            row[0] = "Unique";
            table.Rows.Add(row);

            row = table.NewRow(); //comment and you'll hear that this row already belongs to table
            row[0] = "NonUnique";
            table.Rows.Add(row);

            row = table.NewRow();
            table.Rows.Add(row);
            row[0] = "NonUnique"; //nonUnique value already exists in the column that is meant to be unique

            Console.ReadKey();
        }
    }
}
