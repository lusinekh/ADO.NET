using System;
using System.Data;

namespace AddingDataRow
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new DataTable("MyTable");

            table.Columns.Add("Number", typeof(int));
            table.Columns.Add("EnglishName");

            DataRow newRow = table.NewRow();
            //newRow[0] = 1;
            //newRow[1] = "One"; //these two variations will bring the same result
            newRow["Number"] = 1;
            newRow["EnglishName"] = "One";

            Console.WriteLine(table.Rows.Count); //row isn't added until you add it by table.rows.add() method

            table.Rows.Add(newRow);

            Console.WriteLine(table.Rows.Count);

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.WriteLine($"{column.ColumnName}: {row[column]}");
                }
                Console.WriteLine(new string('-',20));
            }
        }
    }
}
