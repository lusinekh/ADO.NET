using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableFromView
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new DataTable();

            table.Columns.Add("Column1", typeof(int));
            table.Columns.Add("Column2", typeof(string));

            table.LoadDataRow(new object[] { 1, "one" }, true);
            table.LoadDataRow(new object[] { 2, "two" }, true);
            table.LoadDataRow(new object[] { 3, "three" }, true);
            table.LoadDataRow(new object[] { 3, "three" }, true);
            table.LoadDataRow(new object[] { 4, "four" }, true);

            var view = new DataView(table, "Column1 > 2", "Column1 asc", DataViewRowState.CurrentRows);
            var tableFromView = view.ToTable(false, "Column1", "Column2"); //bool - distinct or not?

            foreach (DataRow row in tableFromView.Rows)
            {
                foreach (DataColumn column in tableFromView.Columns)
                {
                    Console.WriteLine($"{column.ColumnName}: {row[column]}");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
