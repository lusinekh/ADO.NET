using System;
using System.Data;

namespace DataColumn
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new DataTable(); //you can also use ctor new DataTable("MyFirstTable");
            table.TableName = "MyFirstTable";

            var firstColumn = new System.Data.DataColumn();
            firstColumn.ColumnName = "FirstColumn";
            firstColumn.DataType = typeof(int);
            var secondColumn = new System.Data.DataColumn("SecondColumn", typeof(string)); //if you don't mention type, it'll take string by default

            DataColumnCollection columns = table.Columns;
            columns.AddRange(new System.Data.DataColumn[] { firstColumn, secondColumn });

            foreach (System.Data.DataColumn column in table.Columns)
            {
                Console.WriteLine($"{column.ColumnName}: {column.DataType}");
            }

            Console.ReadKey();
        }
    }
}
