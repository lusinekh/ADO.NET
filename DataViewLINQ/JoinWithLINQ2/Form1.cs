using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace JoinWithLINQ2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var shopDB = new DataSet();

            shopDB.ReadXmlSchema(@"C:\Users\HP\Desktop\Test\shopdbschema.xml");
            shopDB.ReadXml(@"C:\Users\HP\Desktop\Test\shopdbdata.xml");

            var customers = shopDB.Tables["Customers"];
            var orders = shopDB.Tables["Orders"];
            var orderDetails = shopDB.Tables["OrderDetails"];
            var products = shopDB.Tables["Products"];

            var query = from customer in customers.AsEnumerable()
                        from order in orders.AsEnumerable()
                        from orderDetail in orderDetails.AsEnumerable()
                        from product in products.AsEnumerable()

                        where
                            (int) customer["CustomerNo"] == (int) order["CustomerNo"] &&
                            (int) order["OrderID"] == (int) orderDetail["OrderID"] &&
                            (int) orderDetail["ProdID"] == (int) product["ProdID"]
                        select new
                        {
                            Customer = $"{customer["LName"]} {customer["FName"]}",
                            OrderDate = order["OrderDate"],
                            LineItem = orderDetail["LineItem"],
                            TotalPrice = orderDetail["TotalPrice"],
                            Description = product["Description"].ToString().Trim()
                        };

            dataGridView1.DataSource = query.ToList();
        }
    }
}
