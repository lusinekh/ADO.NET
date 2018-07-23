using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsDataView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var shopDB = new DataSet();
            shopDB.ReadXmlSchema(@"C:\Users\HP\Desktop\Test\shopdbschema.xml");
            shopDB.ReadXml(@"C:\Users\HP\Desktop\Test\shopdbdata.xml");

            var customers = shopDB.Tables["Customers"];
            //var orders = shopDB.Tables["Orders"];
            //var orderDetails = shopDB.Tables["OrderDetails"];
            //var products = shopDB.Tables["Products"];

            InitializeComponent();

            var query = from customer in customers.AsEnumerable() //customer is a row
                        where customer.Field<int>("CustomerNo") == 1 || customer.Field<int>("CustomerNo") == 2 //by .field we take access to specified column
                        orderby customer["CustomerNo"] descending
                        select customer; //if we took here an anonymous type we wouldn't be able to use method AsDataView();

            dataGridView1.DataSource = customers;
            dataGridView2.DataSource = query.AsDataView();
        }
    }
}
