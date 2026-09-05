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
    public partial class New_Sale_Form : Form
    {

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\nilud\Desktop\POS system\POS system\POS system\POS system.mdf"";Integrated Security=True";

        decimal subtotal = 0;
        decimal discount = 0;
        decimal grandTotal = 0;

        public New_Sale_Form()
        {
            InitializeComponent();
            ApplyModernStyling();

            LoadCustomers();
            LoadProducts();
            SetupCart();

            textBox2.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox7.ReadOnly = true;

        }

        // ---------- Visual styling (no image files needed) ----------
        private void ApplyModernStyling()
        {
            ApplyRoundedCorners(pnlOrder, 18);
            ApplyRoundedCorners(pnlOrderShadow, 18);
            ApplyRoundedCorners(pnlCart, 18);
            ApplyRoundedCorners(pnlCartShadow, 18);
            ApplyRoundedCorners(pnlTotals, 18);
            ApplyRoundedCorners(pnlTotalsShadow, 18);

            ApplyRoundedCorners(button1, 10);
            ApplyRoundedCorners(button2, 10);
            ApplyRoundedCorners(button3, 10);
            ApplyRoundedCorners(button4, 10);
            ApplyRoundedCorners(button5, 8);
            ApplyRoundedCorners(button6, 8);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 34;

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

        private void LoadCustomers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT CustomerID, CustomerName FROM Customers";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "CustomerName";
                comboBox1.ValueMember = "CustomerID";
            }
        }

        private void LoadProducts()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductID, ProductName FROM Products";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "ProductName";
                comboBox2.ValueMember = "ProductID";
            }
        }

        private void SetupCart()
        {
            dataGridView1.Columns.Add("No", "No");
            dataGridView1.Columns.Add("ProductID", "Product ID");
            dataGridView1.Columns.Add("ProductName", "Product Name");
            dataGridView1.Columns.Add("Quantity", "Qty");
            dataGridView1.Columns.Add("UnitPrice", "Unit Price");
            dataGridView1.Columns.Add("LineTotal", "Line Total");
            dataGridView1.Columns["ProductID"].Visible = false;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void New_Sale_Form_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue == null)
            {
                return;
            }

            int productID;

            if (!int.TryParse(comboBox2.SelectedValue.ToString(), out productID))
            {
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Note: table name corrected to "Products" to match LoadProducts()
                string query = "SELECT UnitPrice, StockQuantity FROM Products WHERE ProductID=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", productID);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Note: previously the stock value was written into textBox3 (Quantity)
                        // instead of textBox4 (Available Stock) - corrected here
                        textBox2.Text = reader["UnitPrice"].ToString();
                        textBox4.Text = reader["StockQuantity"].ToString();
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Note: table name corrected to "Products"
                string query = "SELECT ProductID, ProductName FROM Products WHERE ProductName LIKE @search";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@search", "%" + textBox1.Text + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "ProductName";
                comboBox2.ValueMember = "ProductID";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Enter quantity");
                return;
            }

            int quantity = int.Parse(textBox3.Text);
            int stock = int.Parse(textBox4.Text);

            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than zero");
                return;
            }

            if (quantity > stock)
            {
                MessageBox.Show("Not enough stock");
                return;
            }

            int productID = Convert.ToInt32(comboBox2.SelectedValue);

            string productName = comboBox2.Text;

            decimal unitPrice = decimal.Parse(textBox2.Text);

            decimal lineTotal = quantity * unitPrice;

            int number = dataGridView1.Rows.Count + 1;

            dataGridView1.Rows.Add(
                number,
                productID,
                productName,
                quantity,
                unitPrice,
                lineTotal);

            CalculateTotal();

            textBox3.Clear();
        }

        private void CalculateTotal()
        {
            subtotal = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                subtotal = subtotal +
                    Convert.ToDecimal(row.Cells["LineTotal"].Value);
            }

            textBox5.Text = subtotal.ToString("0.00");

            if (textBox6.Text == "")
            {
                discount = 0;
            }
            else
            {
                discount = decimal.Parse(textBox6.Text);
            }

            grandTotal = subtotal - discount;

            if (grandTotal < 0)
            {
                grandTotal = 0;
            }

            textBox7.Text = grandTotal.ToString("0.00");
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                discount = 0;
            }
            else
            {
                discount = decimal.Parse(textBox6.Text);
            }

            grandTotal = subtotal - discount;

            if (grandTotal < 0)
            {
                grandTotal = 0;
            }

            textBox7.Text = grandTotal.ToString("0.00");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearBill();
        }

        private void ClearBill()
        {
            dataGridView1.Rows.Clear();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

            subtotal = 0;
            discount = 0;
            grandTotal = 0;


        }

        private void UpdateNumbers()
        {
            int number = 1;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells["No"].Value = number;
                    number++;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Add at least one product");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string saleQuery = @"INSERT INTO Sale
                        (SaleDate, CustomerID, GrandTotal)
                        OUTPUT INSERTED.SaleID
                        VALUES
                        (@date, @customer, @total)";

                SqlCommand saleCommand = new SqlCommand(saleQuery, con);

                if (comboBox1.SelectedValue == null)
                {
                    saleCommand.Parameters.AddWithValue("@customer", DBNull.Value);
                }
                else
                {
                    saleCommand.Parameters.AddWithValue(
                        "@customer",
                        comboBox1.SelectedValue);
                }

                saleCommand.Parameters.AddWithValue("@total", grandTotal);

                int saleID = (int)saleCommand.ExecuteScalar();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow)
                    {
                        continue;
                    }

                    int productID =
                        Convert.ToInt32(row.Cells["ProductID"].Value);

                    int quantity =
                        Convert.ToInt32(row.Cells["Quantity"].Value);

                    decimal unitPrice =
                        Convert.ToDecimal(row.Cells["UnitPrice"].Value);

                    decimal lineTotal =
                        Convert.ToDecimal(row.Cells["LineTotal"].Value);

                    string detailQuery = @"INSERT INTO SaleDetails
                              (SaleID, ProductID, Quantity, UnitPrice, LineTotal)
                              VALUES
                              (@saleID, @productID, @quantity, @price, @lineTotal)";

                    SqlCommand detailCommand =
                        new SqlCommand(detailQuery, con);

                    detailCommand.Parameters.AddWithValue("@saleID", saleID);
                    detailCommand.Parameters.AddWithValue("@productID", productID);
                    detailCommand.Parameters.AddWithValue("@quantity", quantity);
                    detailCommand.Parameters.AddWithValue("@price", unitPrice);
                    detailCommand.Parameters.AddWithValue("@lineTotal", lineTotal);

                    detailCommand.ExecuteNonQuery();

                    // Note: table name corrected to "Products"
                    string stockQuery =
                        "UPDATE Products SET StockQuantity = StockQuantity - @quantity WHERE ProductID=@productID";

                    SqlCommand stockCommand =
                        new SqlCommand(stockQuery, con);

                    stockCommand.Parameters.AddWithValue("@quantity", quantity);
                    stockCommand.Parameters.AddWithValue("@productID", productID);

                    stockCommand.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "Bill saved successfully.\nBill No: " + saleID);
            }

            ClearBill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearBill();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

            UpdateNumbers();

            CalculateTotal();
        }
    }
}
