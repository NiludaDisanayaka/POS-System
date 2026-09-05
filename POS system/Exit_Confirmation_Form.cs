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
    public partial class Exit_Confirmation_Form : Form
    {
        public Exit_Confirmation_Form()
        {
            InitializeComponent();
            ApplyModernStyling();
        }

        // ---------- Visual styling (no image files needed) ----------
        private void ApplyModernStyling()
        {
            ApplyRoundedCorners(pnlCard, 18);
            ApplyRoundedCorners(pnlCardShadow, 18);
            ApplyRoundedCorners(button1, 10);
            ApplyRoundedCorners(button2, 10);
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
            DialogResult result = MessageBox.Show(
       "Are you sure you want to exit?",
       "Exit",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Thank you for using the POS System.");
                Application.Exit();
            }
        }

        // "Cancel" now actually closes this dialog and returns to the app
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Exit_Confirmation_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
