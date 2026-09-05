namespace POS_system
{
    partial class Exit_Confirmation_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlCardShadow = new System.Windows.Forms.Panel();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblIcon = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlCardShadow
            //
            this.pnlCardShadow.BackColor = System.Drawing.Color.FromArgb(210, 213, 218);
            this.pnlCardShadow.Location = new System.Drawing.Point(24, 24);
            this.pnlCardShadow.Name = "pnlCardShadow";
            this.pnlCardShadow.Size = new System.Drawing.Size(432, 272);
            this.pnlCardShadow.TabIndex = 0;
            //
            // pnlCard
            //
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.lblIcon);
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Controls.Add(this.label1);
            this.pnlCard.Controls.Add(this.button1);
            this.pnlCard.Controls.Add(this.button2);
            this.pnlCard.Location = new System.Drawing.Point(20, 20);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(432, 272);
            this.pnlCard.TabIndex = 1;
            //
            // lblIcon
            //
            this.lblIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 30F);
            this.lblIcon.Location = new System.Drawing.Point(0, 22);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(432, 55);
            this.lblIcon.TabIndex = 0;
            this.lblIcon.Text = "🚪";
            this.lblIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblTitle.Location = new System.Drawing.Point(0, 90);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(432, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Exit Confirmation";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // label1
            //
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(108, 122, 137);
            this.label1.Location = new System.Drawing.Point(20, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 44);
            this.label1.TabIndex = 2;
            this.label1.Text = "Are you sure you want to exit the POS System?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // button1 (YES)
            //
            this.button1.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(56, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "✔️  Yes, Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            //
            // button2 (NO)
            //
            this.button2.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(226, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 45);
            this.button2.TabIndex = 4;
            this.button2.Text = "✖️  Cancel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            //
            // Exit_Confirmation_Form
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(480, 320);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.pnlCardShadow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Exit_Confirmation_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exit Confirmation";
            this.Load += new System.EventHandler(this.Exit_Confirmation_Form_Load);
            this.pnlCard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCardShadow;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
