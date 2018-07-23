using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ConnectionString3userForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string conStr =
                $@"Data Source=.\SQLExpress;Initial Catalog=ShopDB; user id = {userNameTextBox.Text}; password = {passwordTextBox.Text};";
            //in this case the user can write in password textbox 11; initial catalog = eveldb and connect to eveldb. in order not to permit such things we would rather use sqlconnectionstringbuilder which will make some verifications on input text
            using (var connection = new SqlConnection(conStr))
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
