using System;
using System.Data;

namespace Constraints3MaxLength
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new DataTable("MyTable");

            var column = new DataColumn("ColumnWithMaxLength", typeof(string));
            //column.MaxLength = 5; //uncomment and you'll violete maxlength constraint by 21th line as its length is more than MaxLength
            table.Columns.Add(column);

            var row = table.NewRow();
            row[0] = "my value";
            table.Rows.Add(row);

            Console.ReadKey();
        }
    }
}
