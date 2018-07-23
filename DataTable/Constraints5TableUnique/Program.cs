using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constraints5TableUnique
{
    class Program
    {//table constraint differs from column constraint by that it table can have a complex constraint (f.e by 2 columns)
        static void Main(string[] args)
        {
            var table = new DataTable("MyTable");

            var column1 = new DataColumn("FirstColumn", typeof(string));
            var column2 = new DataColumn("SecondColumn", typeof(int));
            table.Columns.AddRange(new DataColumn[] { column1, column2 });

            table.Constraints.Add("tableUniqueConstraint", new[] { column1, column2 }, false); //if you put true you'll have primary key

            var row = table.NewRow();
            row[0] = "Andy";
            row[1] = 5;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "Andy";
            row[1] = 5;
            table.Rows.Add(row); //value "Andy, 5" already presents in the table => change either string or int part

            Console.ReadKey();
        }
    }
}
