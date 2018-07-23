using System;
using System.Data;

namespace ProposedVersion
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

            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i].BeginEdit();
                table.Rows[i][0] = "Changed value";
            }

            ShowDataAndMessage("Data after BeginEdit()", table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i].EndEdit();
            }

            ShowDataAndMessage("Data after EndEdit()", table);

            table.AcceptChanges();

            ShowDataAndMessage("Data after AcceptChanges()", table);

            Console.ReadKey();
        }

        private static void ShowDataAndMessage(string message, DataTable table)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
            ShowData(table);
            Console.ReadKey();
        }

        static void ShowData(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                var proposeValue = row.HasVersion(DataRowVersion.Proposed) //proposed value is something intermediate between current and modified values
                    ? row[0, DataRowVersion.Proposed]
                    : "no data";

                Console.WriteLine($"Current value: {row[0, DataRowVersion.Current]}");
                Console.WriteLine($"Original value: {row[0,DataRowVersion.Original]}");
                Console.WriteLine($"Proposed value: {proposeValue}");
                Console.WriteLine($"Row State = {row.RowState}");
                Console.WriteLine();
            }
        }
    }
}
