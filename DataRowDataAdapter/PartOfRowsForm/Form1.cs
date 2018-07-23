using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PartOfRowsForm
{
    public partial class Form1 : Form
    {
        string connectionString = @"data source = .\sqlexpress; initial catalog = shopdb; integrated security = true;";
        string commandString = "select * from Customers";
        SqlDataAdapter adapter;
        int i = 0, step = 2;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var table = new DataTable();
            adapter = new SqlDataAdapter(commandString, connectionString);
            adapter.TableMappings.Add("Table", "MyExample");
            adapter.Fill(i, step, table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.NextPage(-step);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.NextPage(step);
        }

        private void NextPage(int step)
        {
            var table = new DataTable();

            try
            {
                if (step > 0) adapter.Fill(i += step, step, table);
                else adapter.Fill(i += step, -step, table);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            dataGridView1.DataSource = table;
        }
    }
}
