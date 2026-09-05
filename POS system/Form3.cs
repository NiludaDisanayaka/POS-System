using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            ApplyModernStyling();
            LoadCategories();
        }

        // ---------- Visual styling (no image files needed) ----------
        private void ApplyModernStyling()
        {
            ApplyRoundedCorners(pnlCard, 18);
            ApplyRoundedCorners(pnlCardShadow, 18);
            ApplyRoundedCorners(button1, 10);
            ApplyRoundedCorners(button2, 10);
            ApplyRoundedCorners(button3, 10);
            ApplyRoundedCorners(button4, 10);
            ApplyRoundedCorners(button5, 8);

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

        private void LoadCategories()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Categories";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Categories (CategoryName, Description) VALUES (@name, @description)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@description", textBox3.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Category added");

            LoadCategories();
            ClearFields();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Note: table name corrected to "Categories" to match the rest of the app
                string query = "UPDATE Categories SET CategoryName=@name, Description=@description WHERE CategoryID=@id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@description", textBox3.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Category updated");

            LoadCategories();
            ClearFields();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Note: table name corrected to "Categories"
                string query = "DELETE FROM Categories WHERE CategoryID=@id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", textBox1.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Category deleted");

            LoadCategories();
            ClearFields();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Note: table name corrected to "Categories", and the search now reads
                // textBox4.Text instead of the textBox object itself
                string query = "SELECT * FROM Categories WHERE CategoryName LIKE @search";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@search", "%" + textBox4.Text + "%");

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
