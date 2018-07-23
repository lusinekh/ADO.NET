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

namespace ConnectionString4SqlConnectionStringBuilder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var csb = new SqlConnectionStringBuilder();
            //csb.DataSource = @"Spectre\SqlExpress";
            csb["Data Source"] = @"Spectre\SqlExpress"; //we can write others like this too
            csb.InitialCatalog = "ShopDB"; //cbs["Initial Catalog"] = "ShopDb";
            csb.UserID = userNameTextBox.Text; //cbs["User ID"] = userNameTextBox.Text;
            csb.Password = passwordTextBox.Text; //cbs["Password"] = passwordTextBox.Text;

            using (var connection = new SqlConnection(csb.ConnectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show($"Connection to {connection.Database} is open");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
