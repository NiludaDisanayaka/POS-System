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
    public partial class Exit_Confirmation_Form : Form
    {
        public Exit_Confirmation_Form()
        {
            InitializeComponent();
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

        private void Exit_Confirmation_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
