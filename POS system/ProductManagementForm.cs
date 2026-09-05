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
    public partial class ProductManagementForm : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\nilud\Desktop\POS system\POS system\POS system\POS system.mdf"";Integrated Security=True";

        public ProductManagementForm()
        {
            InitializeComponent();
            LoadCategories();
            LoadProducts();
        }

        private void LoadCategories()
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = "SELECT CategoryID, CategoryName FROM Categories";

            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryID";
        }

        private void LoadProducts()
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = "SELECT ProductID, ProductName, CategoryID, UnitPrice, StockQuantity FROM Products";

            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void ProductManagementForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = "INSERT INTO Products (ProductName, CategoryID, UnitPrice, StockQuantity) VALUES (@name, @category, @price, @stock)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@category", comboBox1.SelectedValue);
            cmd.Parameters.AddWithValue("@price", decimal.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@stock", int.Parse(textBox4.Text));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Product added");

            LoadProducts();
            ClearFields();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = "UPDATE Product SET ProductName=@name, CategoryID=@category, UnitPrice=@price, StockQuantity=@stock WHERE ProductID=@id";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@category", comboBox1.SelectedValue);
            cmd.Parameters.AddWithValue("@price", decimal.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@stock", int.Parse(textBox4.Text));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Product updated");

            LoadProducts();
            ClearFields();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = "DELETE FROM Product WHERE ProductID=@id";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Product deleted");

            LoadProducts();
            ClearFields();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = "SELECT * FROM Product WHERE ProductName LIKE @search";

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
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["ProductID"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells["CategoryID"].Value;
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["StockQuantity"].Value.ToString();
            }
        }
    }
}
