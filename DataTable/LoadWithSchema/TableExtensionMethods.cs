using System;
using System.Data;
using System.Data.SqlClient;

namespace LoadWithSchema
{
    static class TableExtensionMethods
    {
        public static void LoadWithSchema(this DataTable table, SqlDataReader reader)
        {
            table.CreateSchemaFromReader(reader);
            table.Load(reader);
        }

        private static void CreateSchemaFromReader(this DataTable table, SqlDataReader reader)
        {
            DataTable schema = reader.GetSchemaTable();

            foreach (DataRow row in schema.Rows)
            {
                var column = new DataColumn((string)row["ColumnName"]);
                column.AllowDBNull = (bool)row["AllowDBNull"];
                column.DataType = (Type)row["DataType"];
                column.Unique = (bool)row["IsUnique"];
                column.ReadOnly = (bool)row["IsReadOnly"];
                column.AutoIncrement = (bool)row["IsIdentity"];

                if (column.DataType == typeof(string)) column.MaxLength = (int)row["ColumnSize"];
                if (column.AutoIncrement == true)
                {
                    column.AutoIncrementStep = -1;
                    column.AutoIncrementSeed = 0;//start from 0
                }

                table.Columns.Add(column);
            }
        }
    }
}
