using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HomeWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var conStr = @"data source = (local)\sqlExpress; integrated security = true; initial catalog = shopDB;";
            var commandString = "select * from Customers";
            var shopDB = new DataSet("ShopDB");
            var adapter = new SqlDataAdapter(commandString, conStr);
            adapter.TableMappings.Add("Table", "Customers");
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(shopDB);
            var customers = shopDB.Tables["Customers"];

            var kievView = new DataView(customers, "City = 'Kiev'", "CustomerNo", DataViewRowState.CurrentRows);

            label1.Text = kievView.Table.TableName;
            dataGridView1.DataSource = kievView;

            var notKievView = new DataView(customers, "City <> 'Kiev'","CustomerNo",DataViewRowState.CurrentRows);

            label2.Text = "Not in Kiev";
            dataGridView2.DataSource = notKievView;
        }
    }
}
