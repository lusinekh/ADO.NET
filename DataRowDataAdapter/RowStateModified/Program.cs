using System;
using System.Data;

namespace RowStateModified
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new DataTable();
            table.Columns.Add("Column1");

            table.LoadDataRow(new object[] { "Value" }, true); //true = accept changes, turn this into false and on 17th line you'll get Added
            Console.WriteLine(table.Rows.Count);

            table.Rows[0][0] = "New Value";
            Console.WriteLine(table.Rows[0].RowState);

            table.AcceptChanges(); //after accepting modifications it'll become unchanged
            Console.WriteLine(table.Rows.Count);
            Console.WriteLine(table.Rows[0].RowState);

            //table.Rows[0].SetModified(); //you can manually set row state to modified
            //Console.WriteLine(table.Rows[0].RowState);

            Console.ReadKey();
        }
    }
}
