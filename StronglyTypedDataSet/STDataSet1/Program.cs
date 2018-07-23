using System;
using System.Data;

namespace STDataSet1
{
    class Program
    {
        static void Main(string[] args)
        {
            var shopDB = new ShopDB();

            var customerRow = shopDB.Customers.NewRow(); //simple dataRow

            customerRow[0] = 1;
            customerRow[1] = "Aleksey";
            customerRow[2] = "Petrov";
            customerRow[3] = "Nikolaevich";
            customerRow[4] = "Lujnaya 7";
            customerRow[5] = DBNull.Value;
            customerRow[6] = "Kiev";
            customerRow[7] = "(095)4578596";
            customerRow[8] = "2009/09/18";

            shopDB.Customers.Rows.Add(customerRow);

            foreach (DataRow row in shopDB.Customers.Rows)
            {
                foreach (DataColumn column in shopDB.Customers.Columns)
                {
                    Console.WriteLine($"{column.ColumnName}: {row[column]}");
                }
            }

            Console.ReadKey();
        }
    }
}
