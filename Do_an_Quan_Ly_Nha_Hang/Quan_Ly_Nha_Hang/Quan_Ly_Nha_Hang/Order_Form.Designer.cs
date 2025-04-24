namespace Quan_Ly_Nha_Hang
{
    partial class Order_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order_Form));
            this.txt_Table_Name = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Order_change_panel = new System.Windows.Forms.Panel();
            this.btn_Back = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
            // 
            // txt_Table_Name
            // 
            this.txt_Table_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Table_Name.BackColor = System.Drawing.Color.Transparent;
            this.txt_Table_Name.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Table_Name.ForeColor = System.Drawing.Color.SteelBlue;
            this.txt_Table_Name.Location = new System.Drawing.Point(397, 43);
            this.txt_Table_Name.Margin = new System.Windows.Forms.Padding(0);
            this.txt_Table_Name.Name = "txt_Table_Name";
            this.txt_Table_Name.Size = new System.Drawing.Size(186, 79);
            this.txt_Table_Name.TabIndex = 1;
            this.txt_Table_Name.Text = "Bàn 3";
            this.txt_Table_Name.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Order_change_panel
            // 
            this.Order_change_panel.BackColor = System.Drawing.Color.Transparent;
            this.Order_change_panel.Location = new System.Drawing.Point(2, 197);
            this.Order_change_panel.Margin = new System.Windows.Forms.Padding(0);
            this.Order_change_panel.Name = "Order_change_panel";
            this.Order_change_panel.Size = new System.Drawing.Size(1032, 1666);
            this.Order_change_panel.TabIndex = 4;
            // 
            // btn_Back
            // 
            this.btn_Back.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btn_Back.HoverState.ImageSize = new System.Drawing.Size(42, 42);
            this.btn_Back.Image = ((System.Drawing.Image)(resources.GetObject("btn_Back.Image")));
            this.btn_Back.ImageOffset = new System.Drawing.Point(0, 0);
            this.btn_Back.ImageRotate = 0F;
            this.btn_Back.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_Back.Location = new System.Drawing.Point(32, 26);
            this.btn_Back.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.PressedState.ImageSize = new System.Drawing.Size(42, 42);
            this.btn_Back.Size = new System.Drawing.Size(111, 97);
            this.btn_Back.TabIndex = 3;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // Order_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1022, 1922);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.Order_change_panel);
            this.Controls.Add(this.txt_Table_Name);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Order_Form";
            this.Text = "Order_Form";
            this.Load += new System.EventHandler(this.Order_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel txt_Table_Name;
        private Guna.UI2.WinForms.Guna2ImageButton btn_Back;
        private System.Windows.Forms.Panel Order_change_panel;
    }
}