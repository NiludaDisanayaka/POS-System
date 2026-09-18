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
    public partial class Customer_Management_Form : Form
    {

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\nilud\Desktop\POS system\POS system\POS system\POS system.mdf"";Integrated Security=True";

        public Customer_Management_Form()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = "SELECT * FROM Customers";

            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }


        private void Customer_Management_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = "INSERT INTO Customers (CustomerName, ContactNumber, Address) VALUES (@name, @contact, @address)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@contact", textBox3.Text);
            cmd.Parameters.AddWithValue("@address", textBox4.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Customer added");

            LoadCustomers();
            ClearFields();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = "UPDATE Customer SET CustomerName=@name, ContactNumber=@contact, Address=@address WHERE CustomerID=@id";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@contact", textBox3.Text);
            cmd.Parameters.AddWithValue("@address", textBox4.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Customer updated");

            LoadCustomers();
            ClearFields();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = "DELETE FROM Customer WHERE CustomerID=@id";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Customer deleted");

            LoadCustomers();
            ClearFields();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = "SELECT * FROM Customer WHERE CustomerName LIKE @search";

            SqlDataAdapter da = new SqlDataAdapter(query, con);

            da.SelectCommand.Parameters.AddWithValue("@search", "%" + textBox5.Text + "%");

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["CustomerID"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["ContactNumber"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            }
        }
    }
}
