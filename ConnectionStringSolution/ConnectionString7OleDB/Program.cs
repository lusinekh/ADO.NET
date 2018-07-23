using System;
using System.Data.OleDb;

namespace ConnectionString7OleDB
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectToAccessDB();
            ConnectToExcelDB();

            Console.ReadKey();
        }

        private static void ConnectToAccessDB()
        {
            var connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Users\HP\Desktop\Campaign_Template.mdb");
            /*
             * for accdb files:
             * https://www.microsoft.com/en-us/download/details.aspx?id=23734
             * https://www.microsoft.com/en-us/download/details.aspx?displaylang=en&id=4438
             * "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\marcelo.accdb;Jet OLEDB:Database Password=MyDbPassword;"
             */

            try
            {
                connection.Open();
                Console.WriteLine($"Connection to {connection.Database} is {connection.State}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine($"Connection to {connection.Database} is {connection.State}");
            }
        }

        private static void ConnectToExcelDB()
        {
            var connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\HP\\Desktop\\New Microsoft Office Excel Worksheet.xls; Extended properties=\"Excel 8.0\"");
            //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Docs\\Book2.xlsx;Extended Properties='Excel 12.0 xml;HDR=YES;'"); for xlsx files

            try
            {
                connection.Open();
                Console.WriteLine($"Connection to {connection.Database} is {connection.State}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine($"Connection to {connection.Database} is {connection.State}");
            }
        }
    }
}