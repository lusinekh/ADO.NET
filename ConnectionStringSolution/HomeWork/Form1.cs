using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HomeWork
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        public Form1()
        {
            InitializeComponent();
        }
        //TODO: checkstate doesn't work
        private void loginButton_Click(object sender, EventArgs e)
        {
            var conStrBdr = new SqlConnectionStringBuilder();
            conStrBdr.DataSource = @"localhost\SQLExpress";
            conStrBdr.InitialCatalog = "ShopDB";
            conStrBdr.UserID = useridTextBox.Text;
            conStrBdr.Password = passwordTextBox.Text;

            using (connection = new SqlConnection(conStrBdr.ConnectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show($"Connection to {connection.Database} is {connection.State}");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void checkStateButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Connection is {connection.State}");
        }
    }
}
