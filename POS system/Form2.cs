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

namespace POS_system
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            ApplyModernStyling();
        }

        // ---------- Visual styling (no image files needed) ----------
        private void ApplyModernStyling()
        {
            ApplyRoundedCorners(button1, 16);
            ApplyRoundedCorners(button2, 16);
            ApplyRoundedCorners(button3, 16);
            ApplyRoundedCorners(button4, 16);
            ApplyRoundedCorners(button5, 16);
            ApplyRoundedCorners(button6, 22); // fully round "power" button
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
