using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CommandAsync
{
    public partial class Form1 : Form
    {
        private string conStr = @"Data Source = (local)\SqlExpress; initial catalog = shopdb; integrated security = true;";
        public Form1()
        {
            InitializeComponent();
        }

        private void executeButton_Click(object sender, EventArgs e) //if we perform an operation synchronously, the progress bars will freeze until our query is finished
        {
            using (var connection = new SqlConnection(conStr))
            {
                connection.Open();

                var command = new SqlCommand("waitfor delay '00:00:10'", connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Query executed");
            }
        }

        private async void executeAsyncButton_Click(object sender, EventArgs e) //in asynchronous variant our query will be performed behind scenes, so progress bars will run as usual
        {
            using (var connection = new SqlConnection(conStr))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("waitfor delay '00:00:10'", connection);
                await command.ExecuteNonQueryAsync();
                MessageBox.Show("Query executed asynchronously");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value >= 100) progressBar1.Value = 0;
            if (progressBar2.Value >= 100) progressBar2.Value = 0;
            if (progressBar3.Value >= 100) progressBar3.Value = 0;
            progressBar1.Value += 1;
            progressBar2.Value += 2;
            progressBar3.Value += 5;

        }
    }
}
