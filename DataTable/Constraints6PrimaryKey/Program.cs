using System;
using System.Data;

namespace Constraints6PrimaryKey
{
    class Program //there's no PrimaryKey class in Ado.net
    {
        static void Main(string[] args)
        {
            var table = new DataTable("MyTable");

            var column = new DataColumn("PrimaryColumn", typeof(string));
            table.Columns.Add(column);

            var pk_firstColumn = new UniqueConstraint(column, false); //isPrimaryKey = true
            table.Constraints.Add(pk_firstColumn);

            Console.WriteLine(table.Columns[0].Unique); //primary key gives uniquity
            Console.WriteLine(table.PrimaryKey.Length); //how much primary keys are there
            //Console.WriteLine(table.PrimaryKey[0].ColumnName); //which column is primary key

            Console.WriteLine(table.PrimaryKey.Length == 0
                ? "there's no primary key"
                : $"{table.PrimaryKey[0].ColumnName} is primary key column");

            Console.ReadKey();
        }
    }
}
