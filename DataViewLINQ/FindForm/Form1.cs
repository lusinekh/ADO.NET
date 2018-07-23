using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FindForm
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
            adapter.TableMappings.Add("Table", "Customers");
            adapter.Fill(customers);

            customersView = new DataView(customers, "", "CustomerNo", DataViewRowState.CurrentRows);
            dataGridView1.DataSource = customersView;
            label1.Text = customers.TableName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var index = customersView.Find(textBox1.Text);

            if (index != -1)
            {
                var row = customers.Rows[index];

                textBox2.Text = row["CustomerNo"].ToString();
                textBox3.Text = row["Lname"].ToString();
                textBox4.Text = row["Fname"].ToString();
                textBox5.Text = row["Address1"].ToString();
                textBox6.Text = row["City"].ToString();
                textBox7.Text = row["Phone"].ToString();
            }
            else
            {
                MessageBox.Show($"There is no customer with id {index}");
            }
        }
    }
}
