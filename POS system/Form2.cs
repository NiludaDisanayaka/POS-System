using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_system
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "Are you sure you want to exit?",
              "Exit",
              MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Thank you for using the POS System.");
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 category = new Form3();
            category.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductManagementForm product = new ProductManagementForm();
            product.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customer_Management_Form customer = new Customer_Management_Form();
            customer.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            New_Sale_Form billing = new New_Sale_Form();
            billing.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sales_History_Form history = new Sales_History_Form();
            history.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
