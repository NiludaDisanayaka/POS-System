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
    public partial class Sales_History_Form : Form
    {

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\nilud\Desktop\POS system\POS system\POS system\POS system.mdf"";Integrated Security=True";

        public Sales_History_Form()
        {
            InitializeComponent();
            LoadSales();
        }

        private void LoadSales()
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = @"SELECT 
                            Sales.SaleID,
                            Sales.SaleDate,
                            Customers.CustomerName,
                            Sales.GrandTotal
                            FROM Sales
                            INNER JOIN Customers
                            ON Sales.CustomerID = Customers.CustomerID";

            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int saleID = Convert.ToInt32(
                    dataGridView1.CurrentRow.Cells["SaleID"].Value);

                Sale_Details_Form details = new Sale_Details_Form(saleID);

                details.Show();
            }
        }

        private void Sales_History_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = @"SELECT 
                            Sales.SaleID,
                            Sales.SaleDate,
                            Customers.CustomerName,
                            Sales.GrandTotal
                            FROM Sales
                            INNER JOIN Customers
                            ON Sale.CustomerID = Customers.CustomerID
                            WHERE Sales.SaleID LIKE @search";

            SqlDataAdapter da = new SqlDataAdapter(query, con);

            da.SelectCommand.Parameters.AddWithValue(
                "@search",
                "%" + textBox1.Text + "%");

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
