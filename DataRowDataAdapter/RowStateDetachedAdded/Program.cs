using System;
using System.Data;

namespace RowStateDetachedAdded
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new DataTable();
            table.Columns.Add(new DataColumn("Column1"));

            var row = table.NewRow();
            row[0] = "MyValue";
            Console.WriteLine(row.RowState); //hung in the air

            table.Rows.Add(row);
            Console.WriteLine(row.RowState); //added into table

            table.AcceptChanges();
            Console.WriteLine(row.RowState); //no changes made after accepting changes

            Console.ReadKey();
        }
    }
}
