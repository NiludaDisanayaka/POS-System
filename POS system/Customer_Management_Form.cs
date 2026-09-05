using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            ApplyModernStyling();
            LoadCustomers();
        }

        // ---------- Visual styling (no image files needed) ----------
        private void ApplyModernStyling()
        {
            // Soft rounded corners on the card and the buttons
            ApplyRoundedCorners(pnlCard, 18);
            ApplyRoundedCorners(pnlCardShadow, 18);
            ApplyRoundedCorners(button1, 10);
            ApplyRoundedCorners(button2, 10);
            ApplyRoundedCorners(button3, 10);
            ApplyRoundedCorners(button4, 10);
            ApplyRoundedCorners(button5, 8);

            // Modern colored header for the results grid
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.ColumnHeadersHeight = 36;

            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);

            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Draws a rounded-rectangle region over a control so it renders with soft corners
        private void ApplyRoundedCorners(Control control, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            Rectangle bounds = new Rectangle(0, 0, control.Width, control.Height);

            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            control.Region = new Region(path);
        }

        private void LoadCustomers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customers";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }


        private void Customer_Management_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Customers (CustomerName, ContactNumber, Address) VALUES (@name, @contact, @address)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@contact", textBox3.Text);
                cmd.Parameters.AddWithValue("@address", textBox4.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Customer added");

            LoadCustomers();
            ClearFields();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Note: table name corrected to "Customers" to match the rest of the app
                string query = "UPDATE Customers SET CustomerName=@name, ContactNumber=@contact, Address=@address WHERE CustomerID=@id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@contact", textBox3.Text);
                cmd.Parameters.AddWithValue("@address", textBox4.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Customer updated");

            LoadCustomers();
            ClearFields();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Note: table name corrected to "Customers"
                string query = "DELETE FROM Customers WHERE CustomerID=@id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", textBox1.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Customer deleted");

            LoadCustomers();
            ClearFields();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Note: table name corrected to "Customers"
                string query = "SELECT * FROM Customers WHERE CustomerName LIKE @search";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@search", "%" + textBox5.Text + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
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
