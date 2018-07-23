using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataView2
{
    public partial class Form1 : Form
    {
        string conStr = @"data source = .\sqlexpress; initial catalog = shopdb; integrated security = true;";
        string commandString = "select * from customers";
        DataTable customers = new DataTable();
        DataView view;
        public Form1()
        {
            InitializeComponent();

            var adapter = new SqlDataAdapter(commandString, conStr);
            adapter.Fill(customers);

            view = new DataView(customers);

            dataGridView1.DataSource = customers;
            dataGridView2.DataSource = view;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customers.AcceptChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            view.RowFilter = textBox1.Text;
            view.Sort = textBox2.Text;
            view.RowStateFilter = (DataViewRowState) Enum.Parse(typeof (DataViewRowState), comboBox1.Text, true);
        }
    }
}