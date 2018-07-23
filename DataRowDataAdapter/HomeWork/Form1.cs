using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HomeWork
{
    public partial class Form1 : Form
    {
        string connectionString =
            @"data source = (local)\sqlexpress; integrated security = true; initial catalog = shopdb;";

        string commandString = "select * from customers";
        SqlDataAdapter adapter;
        DataTable mainTable;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainTable = new DataTable();
            adapter = new SqlDataAdapter(commandString,connectionString);
            //adapter.TableMappings.Add("Table", "Customers");
            adapter.Fill(mainTable);
            label1.Text = mainTable.TableName;
            dataGridView1.DataSource = mainTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var changeTable = mainTable.Clone();
            foreach (DataRow row in mainTable.Rows)
            {
                if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Deleted || row.RowState == DataRowState.Added)
                {
                    changeTable.ImportRow(row);
                }
            }
            dataGridView2.DataSource = changeTable;
        }
    }
}
