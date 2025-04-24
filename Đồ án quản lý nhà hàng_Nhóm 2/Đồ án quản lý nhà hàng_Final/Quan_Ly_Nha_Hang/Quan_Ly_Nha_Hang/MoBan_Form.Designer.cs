namespace Quan_Ly_Nha_Hang
{
    partial class MoBan_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoBan_Form));
            this.Changefunction_MoBan_panel = new Guna.UI2.WinForms.Guna2Panel();
            this.ck_Banhong = new System.Windows.Forms.CheckBox();
            this.txt_Table_Name = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btn_DatBan = new Guna.UI2.WinForms.Guna2Button();
            this.btn_MoBan = new Guna.UI2.WinForms.Guna2Button();
            this.Changefunction_MoBan_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Changefunction_MoBan_panel
            // 
            this.Changefunction_MoBan_panel.AutoRoundedCorners = true;
            this.Changefunction_MoBan_panel.BackColor = System.Drawing.Color.Gainsboro;
            this.Changefunction_MoBan_panel.BorderRadius = 508;
            this.Changefunction_MoBan_panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.Changefunction_MoBan_panel.Controls.Add(this.ck_Banhong);
            this.Changefunction_MoBan_panel.Controls.Add(this.txt_Table_Name);
            this.Changefunction_MoBan_panel.Controls.Add(this.btn_DatBan);
            this.Changefunction_MoBan_panel.Controls.Add(this.btn_MoBan);
            this.Changefunction_MoBan_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Changefunction_MoBan_panel.Location = new System.Drawing.Point(0, 0);
            this.Changefunction_MoBan_panel.Margin = new System.Windows.Forms.Padding(0);
            this.Changefunction_MoBan_panel.Name = "Changefunction_MoBan_panel";
            this.Changefunction_MoBan_panel.Size = new System.Drawing.Size(1018, 1466);
            this.Changefunction_MoBan_panel.TabIndex = 1;
            // 
            // ck_Banhong
            // 
            this.ck_Banhong.AutoSize = true;
            this.ck_Banhong.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_Banhong.ForeColor = System.Drawing.Color.SteelBlue;
            this.ck_Banhong.Location = new System.Drawing.Point(12, 42);
            this.ck_Banhong.Name = "ck_Banhong";
            this.ck_Banhong.Size = new System.Drawing.Size(199, 43);
            this.ck_Banhong.TabIndex = 4;
            this.ck_Banhong.Text = "Bàn hỏng";
            this.ck_Banhong.UseVisualStyleBackColor = true;
            this.ck_Banhong.CheckedChanged += new System.EventHandler(this.ck_Banhong_CheckedChanged);
            // 
            // txt_Table_Name
            // 
            this.txt_Table_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Table_Name.BackColor = System.Drawing.Color.Transparent;
            this.txt_Table_Name.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Table_Name.ForeColor = System.Drawing.Color.SteelBlue;
            this.txt_Table_Name.Location = new System.Drawing.Point(396, 42);
            this.txt_Table_Name.Margin = new System.Windows.Forms.Padding(0);
            this.txt_Table_Name.Name = "txt_Table_Name";
            this.txt_Table_Name.Size = new System.Drawing.Size(186, 79);
            this.txt_Table_Name.TabIndex = 3;
            this.txt_Table_Name.Text = "Bàn 3";
            this.txt_Table_Name.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_DatBan
            // 
            this.btn_DatBan.AutoRoundedCorners = true;
            this.btn_DatBan.BorderRadius = 59;
            this.btn_DatBan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_DatBan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_DatBan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_DatBan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_DatBan.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_DatBan.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.btn_DatBan.ForeColor = System.Drawing.Color.White;
            this.btn_DatBan.Image = ((System.Drawing.Image)(resources.GetObject("btn_DatBan.Image")));
            this.btn_DatBan.ImageSize = new System.Drawing.Size(50, 50);
            this.btn_DatBan.Location = new System.Drawing.Point(161, 467);
            this.btn_DatBan.Name = "btn_DatBan";
            this.btn_DatBan.ShadowDecoration.Color = System.Drawing.Color.White;
            this.btn_DatBan.Size = new System.Drawing.Size(653, 121);
            this.btn_DatBan.TabIndex = 2;
            this.btn_DatBan.Text = "Đặt bàn";
            this.btn_DatBan.Click += new System.EventHandler(this.btn_DatBan_Click);
            // 
            // btn_MoBan
            // 
            this.btn_MoBan.AutoRoundedCorners = true;
            this.btn_MoBan.BorderRadius = 59;
            this.btn_MoBan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_MoBan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_MoBan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_MoBan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_MoBan.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_MoBan.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.btn_MoBan.ForeColor = System.Drawing.Color.White;
            this.btn_MoBan.Image = global::Quan_Ly_Nha_Hang.Properties.Resources.icons8_plus_50;
            this.btn_MoBan.ImageSize = new System.Drawing.Size(50, 50);
            this.btn_MoBan.Location = new System.Drawing.Point(168, 208);
            this.btn_MoBan.Name = "btn_MoBan";
            this.btn_MoBan.ShadowDecoration.Color = System.Drawing.Color.White;
            this.btn_MoBan.Size = new System.Drawing.Size(646, 121);
            this.btn_MoBan.TabIndex = 1;
            this.btn_MoBan.Text = "Mở bàn";
            this.btn_MoBan.Click += new System.EventHandler(this.btn_MoBan_Click);
            // 
            // MoBan_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1018, 1466);
            this.Controls.Add(this.Changefunction_MoBan_panel);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MoBan_Form";
            this.Text = "MoBan_Form";
            this.Changefunction_MoBan_panel.ResumeLayout(false);
            this.Changefunction_MoBan_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel Changefunction_MoBan_panel;
        private Guna.UI2.WinForms.Guna2Button btn_DatBan;
        private Guna.UI2.WinForms.Guna2HtmlLabel txt_Table_Name;
        private Guna.UI2.WinForms.Guna2Button btn_MoBan;
        private System.Windows.Forms.CheckBox ck_Banhong;
    }
}