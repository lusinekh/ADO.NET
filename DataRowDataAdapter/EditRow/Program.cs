using System;
using System.Data;

namespace EditRow
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new DataTable("MyTable");
            table.Columns.Add("Column1");

            table.LoadDataRow(new object[] { "FirstValue" }, true);
            Console.WriteLine($"Initial value is: {table.Rows[0][0]}");

            table.Rows[0].BeginEdit(); //start editing the row
            table.Rows[0][0] = "New Value";

            Console.WriteLine("Would you like to change the value:");
            var answer = Console.ReadLine();
            switch (answer)
            {
                case "Yes":
                    table.Rows[0].EndEdit(); //end editing and accepting changes
                    break;
                case "No":
                    table.Rows[0].CancelEdit(); //cancel changes made after BeginEdit()
                    break;
                default:
                    table.Rows[0].CancelEdit();
                    break;
            }

            Console.WriteLine($"Final value: {table.Rows[0][0]}");

            Console.ReadKey();
        }
    }
}
