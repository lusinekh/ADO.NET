using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace FindRowsForm
{
    public partial class Form1 : Form
    {
        string conStr = @"data source = localhost\sqlexpress; initial catalog = shopdb; integrated security = true;";
        string commandString = "select * from customers";
        DataTable customers = new DataTable();
        DataView customersView;
        SqlDataAdapter adapter;

        public Form1()
        {
            InitializeComponent();

            adapter = new SqlDataAdapter(commandString, conStr);
            adapter.Fill(customers);

            customersView = new DataView(customers, "", "City", DataViewRowState.CurrentRows); //we'll sort by cities

            dataGridView1.DataSource = customers;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rows = customersView.FindRows(textBox1.Text);
            dataGridView2.DataSource = rows.ToList(); //should absolutely be .ToList(); as without it datagridview won't show anything
        }
    }
}
