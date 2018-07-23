using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissingSchemaAction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ds = new DataSet();
            var conStr = @"data source = localhost\SQLExpress; integrated security = true; initial catalog = shopdb;";
            var adapter = new SqlDataAdapter("select * from customers; select * from orders", conStr);

            //missingschemaaction will force all columns to take their constraints, except foreign key constraints which has to be created manually
            adapter.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
            adapter.TableMappings.Add("Table", "Customers");
            adapter.TableMappings.Add("Table1", "Orders");

            adapter.Fill(ds);

            var fk_CustomersOrders = new ForeignKeyConstraint(ds.Tables[0].Columns["CustomerNo"],ds.Tables[1].Columns["CustomerNo"]);
            ds.Tables[1].Constraints.Add(fk_CustomersOrders);

            label1.Text = ds.Tables[0].TableName;
            label2.Text = ds.Tables[1].TableName;

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView2.DataSource = ds.Tables[1];
        }
    }
}
