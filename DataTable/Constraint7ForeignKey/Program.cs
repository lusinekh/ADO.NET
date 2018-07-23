using System;
using System.Data;

namespace Constraint7ForeignKey
{
    class Program //foreign key means that every child table record references to an existing record in parent table
    {
        static void Main(string[] args)//in order to operate foreign key you need parent and child tables be in the same dataset
        {
            var dataSet = new DataSet();

            var parentTable = new DataTable("Parent");
            var childTable = new DataTable("Child");

            dataSet.Tables.AddRange(new DataTable[] { parentTable, childTable });

            var parentColumn = new DataColumn("PrimaryColumn", typeof(int));
            parentTable.Columns.Add(parentColumn);
            var childColumn = new DataColumn("ChildColumn", typeof(int));
            childTable.Columns.Add(childColumn);

            parentTable.Constraints.Add(new UniqueConstraint(parentColumn, true));
            childTable.Constraints.Add(new ForeignKeyConstraint(parentColumn, childColumn));

            var row = parentTable.NewRow();
            row[0] = 1;
            parentTable.Rows.Add(row);

            row = childTable.NewRow();
            row[0] = 2; //child key values must exist in parent table => you'll get an exception
            childTable.Rows.Add(row);

            Console.ReadKey();
        }
    }
}
