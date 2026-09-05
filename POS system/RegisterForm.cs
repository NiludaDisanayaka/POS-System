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

namespace POS_system
{
    public partial class RegisterForm : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\nilud\Desktop\POS system\POS system\POS system\POS system.mdf"";Integrated Security=True";

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" ||
               textBox2.Text == "" ||
               textBox3.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }

            SqlConnection con = new SqlConnection(connectionString);

            string checkQuery =
                "SELECT COUNT(*) FROM dbo.Login WHERE Username=@username";

            SqlCommand checkCommand =
                new SqlCommand(checkQuery, con);

            checkCommand.Parameters.AddWithValue(
                "@username",
                textBox1.Text);

            con.Open();

            int count = Convert.ToInt32(
                checkCommand.ExecuteScalar());

            con.Close();

            if (count > 0)
            {
                MessageBox.Show("Username already exists");
                return;
            }

            string query =
                "INSERT INTO dbo.Login (Username, Password) VALUES (@username, @password)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue(
                "@username",
                textBox1.Text);

            cmd.Parameters.AddWithValue(
                "@password",
                textBox2.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Registration successful");

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
