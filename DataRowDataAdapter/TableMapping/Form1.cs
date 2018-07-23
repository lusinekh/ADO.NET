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

namespace TableMapping
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var conStr = @"data source = localhost\SQLExpress; integrated security = true; initial catalog = shopdb;";

            var ds = new DataSet();
            var adapter = new SqlDataAdapter("select * from Customers; select * from Employees", conStr);
            adapter.TableMappings.Add("Table", "Customers");
            adapter.TableMappings.Add("Table1", "Something"); //table1 will be renamed to Something

            adapter.Fill(ds);

            label1.Text = ds.Tables[0].TableName;
            label2.Text = ds.Tables[1].TableName;

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView2.DataSource = ds.Tables[1];
        }
    }
}
