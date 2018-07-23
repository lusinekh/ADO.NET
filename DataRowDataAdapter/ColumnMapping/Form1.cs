using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ColumnMapping
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
            DataTableMapping customersMapping = adapter.TableMappings.Add("Table", "Customers");

            var customersColumnMappings = new DataColumnMapping[]
            {
                new DataColumnMapping("CustomerNo", "ID"),
                new DataColumnMapping("MName", "Second name") //case sensitivity!!!
            };
            customersMapping.ColumnMappings.AddRange(customersColumnMappings);

            DataTableMapping employeesMapping = adapter.TableMappings.Add("Table1", "Employees");
            var employeesColumnMapping = new DataColumnMapping[]
            {
                new DataColumnMapping("EmployeeID","ID"), 
                new DataColumnMapping("PriorSalary","Prime")
            };
            employeesMapping.ColumnMappings.AddRange(employeesColumnMapping);

            adapter.Fill(ds);

            label1.Text = ds.Tables[0].TableName;
            label2.Text = ds.Tables[1].TableName;

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView2.DataSource = ds.Tables[1];
        }
    }
}
