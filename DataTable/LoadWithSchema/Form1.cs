using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoadWithSchema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const string conStr = @"data source =(local)\SqlExpress; integrated security = true; initial catalog = shopdb;";

            var dataSet = new DataSet();
            var customers = new DataTable("Customers");
            var orders = new DataTable("Orders");

            dataSet.Tables.AddRange(new DataTable[] { customers, orders });

            using (var connection = new SqlConnection(conStr))
            {
                connection.Open();

                var customerCommand = new SqlCommand("select * from customers", connection);
                var orderCommand = new SqlCommand("select * from orders", connection);

                using (var customerReader = customerCommand.ExecuteReader())
                {
                    customers.LoadWithSchema(customerReader);
                }
                using (var orderReader = orderCommand.ExecuteReader())
                {
                    orders.LoadWithSchema(orderReader);
                }
            }

            //DataReader doesn't know if there are constraints in tables => you must add them manually

            //customers.Constraints.Add(new UniqueConstraint(customers.Columns[0], true));
            customers.PrimaryKey = new DataColumn[] { customers.Columns[0] };

            var fk_CustomersOrders = new ForeignKeyConstraint(customers.Columns["CustomerNo"], orders.Columns["CustomerNo"]);
            orders.Constraints.Add(fk_CustomersOrders);

            dataGridView1.DataSource = customers;
            dataGridView2.DataSource = orders;
        }
    }
}
