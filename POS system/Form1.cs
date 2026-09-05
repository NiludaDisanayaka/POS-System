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
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\nilud\Desktop\POS system\POS system\POS system\POS system.mdf"";Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            ApplyModernStyling();
        }

        // ---------- Visual styling (no image files needed) ----------
        private void ApplyModernStyling()
        {
            ApplyRoundedCorners(button1, 10);
            ApplyRoundedCorners(button3, 10);
            ApplyRoundedCorners(button2, 8);
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

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Login WHERE Username=@username AND Password=@password";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);

                con.Open();

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Login successful");

                    Form2 dashboard = new Form2();
                    dashboard.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.Show();
        }
    }
}
