using System;
using System.Data;

namespace RowStateDeleted
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new DataTable();
            table.Columns.Add(new DataColumn("Column1"));

            var row = table.NewRow();
            row[0] = "Value";
            Console.WriteLine(table.Rows.Count);
            Console.WriteLine(row.RowState);

            table.Rows.Add(row);
            Console.WriteLine(table.Rows.Count);
            Console.WriteLine(row.RowState);

            table.Rows[0].Delete(); //goes from Added to Detached
            Console.WriteLine(table.Rows.Count);
            Console.WriteLine(row.RowState);

            table.AcceptChanges(); //renders added to unchanged
            //table.RejectChanges(); //denies changes made after last AcceptChanges()
            Console.WriteLine(table.Rows.Count);
            Console.WriteLine(row.RowState);

            Console.ReadKey();
        }
    }
}
