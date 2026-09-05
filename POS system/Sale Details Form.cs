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
    public partial class Sale_Details_Form : Form
    {

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\nilud\Desktop\POS system\POS system\POS system\POS system.mdf"";Integrated Security=True";
        int saleID;
        public Sale_Details_Form(int id)
        {
            InitializeComponent();
            saleID = id;

            LoadSaleDetails();
        }

        private void LoadSaleDetails()
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = @"SELECT
                            Sale.SaleID,
                            Sale.SaleDate,
                            Customer.CustomerName,
                            Product.ProductName,
                            SaleDetails.Quantity,
                            SaleDetails.UnitPrice,
                            SaleDetails.LineTotal,
                            Sale.GrandTotal
                            FROM Sale
                            INNER JOIN Customer
                            ON Sale.CustomerID = Customer.CustomerID
                            INNER JOIN SaleDetails
                            ON Sale.SaleID = SaleDetails.SaleID
                            INNER JOIN Product
                            ON SaleDetails.ProductID = Product.ProductID
                            WHERE Sale.SaleID=@id";

            SqlDataAdapter da = new SqlDataAdapter(query, con);

            da.SelectCommand.Parameters.AddWithValue("@id", saleID);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                label1.Text = "Bill ID: " + dt.Rows[0]["SaleID"].ToString();

                label2.Text = "Date: " +
                    Convert.ToDateTime(dt.Rows[0]["SaleDate"]).ToString("dd/MM/yyyy");

                label3.Text = "Customer: " +
                    dt.Rows[0]["CustomerName"].ToString();

                label4.Text = "Grand Total: Rs. " +
                    Convert.ToDecimal(dt.Rows[0]["GrandTotal"]).ToString("0.00");
            }
        }

        private void Sale_Details_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
