using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_system
{
    public partial class Form3 : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\nilud\Desktop\POS system\POS system\POS system\POS system.mdf"";Integrated Security=True";

        public Form3()
        {
            InitializeComponent();
            LoadCategories();
        }
         private void LoadCategories()
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = "SELECT * FROM Categories";

            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }



        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = "INSERT INTO Categories (CategoryName, Description) VALUES (@name, @description)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@description", textBox3.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Category added");

            LoadCategories();
            ClearFields();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = "UPDATE Category SET CategoryName=@name, Description=@description WHERE CategoryID=@id";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@description", textBox3.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Category updated");

            LoadCategories();
            ClearFields();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = "DELETE FROM Category WHERE CategoryID=@id";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Category deleted");

            LoadCategories();
            ClearFields();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = "SELECT * FROM Category WHERE CategoryName LIKE @search";

            SqlDataAdapter da = new SqlDataAdapter(query, con);

            da.SelectCommand.Parameters.AddWithValue("@search", "%" + textBox4 + "%");

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
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Description"].Value.ToString();
            }
        }
    }
}
