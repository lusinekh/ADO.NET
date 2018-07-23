using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableAdapter2.ShopDBTableAdapters;

namespace TableAdapter2
{
    class Program
    {
        static void Main(string[] args)
        {
            var customersTableAdapter = new CustomersTableAdapter();
            var customers = customersTableAdapter.GetData(); //creates a customersdatatable

            foreach (DataRow row in customers.Rows)
            {
                foreach (DataColumn column in customers.Columns)
                {
                    Console.WriteLine($"{column.ColumnName}: {row[column]}");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
