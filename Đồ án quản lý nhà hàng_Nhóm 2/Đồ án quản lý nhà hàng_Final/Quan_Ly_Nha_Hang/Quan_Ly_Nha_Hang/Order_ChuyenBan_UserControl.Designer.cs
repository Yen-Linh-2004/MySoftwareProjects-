namespace Quan_Ly_Nha_Hang
{
    partial class Order_ChuyenBan_UserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox_ChuyenBan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ChuyenBan = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // comboBox_ChuyenBan
            // 
            this.comboBox_ChuyenBan.AutoRoundedCorners = true;
            this.comboBox_ChuyenBan.BackColor = System.Drawing.Color.Transparent;
            this.comboBox_ChuyenBan.BorderColor = System.Drawing.Color.SlateGray;
            this.comboBox_ChuyenBan.BorderRadius = 17;
            this.comboBox_ChuyenBan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_ChuyenBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ChuyenBan.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_ChuyenBan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_ChuyenBan.Font = new System.Drawing.Font("Tahoma", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_ChuyenBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBox_ChuyenBan.ItemHeight = 30;
            this.comboBox_ChuyenBan.Items.AddRange(new object[] {
            ""});
            this.comboBox_ChuyenBan.Location = new System.Drawing.Point(308, 0);
            this.comboBox_ChuyenBan.Name = "comboBox_ChuyenBan";
            this.comboBox_ChuyenBan.Size = new System.Drawing.Size(662, 36);
            this.comboBox_ChuyenBan.StartIndex = 0;
            this.comboBox_ChuyenBan.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(77, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn Bàn:";
            // 
            // btn_ChuyenBan
            // 
            this.btn_ChuyenBan.AutoRoundedCorners = true;
            this.btn_ChuyenBan.BorderRadius = 42;
            this.btn_ChuyenBan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ChuyenBan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_ChuyenBan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_ChuyenBan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_ChuyenBan.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_ChuyenBan.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Bold);
            this.btn_ChuyenBan.ForeColor = System.Drawing.Color.White;
            this.btn_ChuyenBan.Image = global::Quan_Ly_Nha_Hang.Properties.Resources.DoiBan;
            this.btn_ChuyenBan.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_ChuyenBan.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.btn_ChuyenBan.IndicateFocus = true;
            this.btn_ChuyenBan.Location = new System.Drawing.Point(68, 257);
            this.btn_ChuyenBan.Margin = new System.Windows.Forms.Padding(6);
            this.btn_ChuyenBan.Name = "btn_ChuyenBan";
            this.btn_ChuyenBan.Size = new System.Drawing.Size(902, 87);
            this.btn_ChuyenBan.TabIndex = 11;
            this.btn_ChuyenBan.Text = "Chuyển Bàn";
            this.btn_ChuyenBan.Click += new System.EventHandler(this.btn_ChuyenBan_Click);
            // 
            // Order_ChuyenBan_UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btn_ChuyenBan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_ChuyenBan);
            this.Name = "Order_ChuyenBan_UserControl";
            this.Size = new System.Drawing.Size(1018, 1422);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox comboBox_ChuyenBan;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_ChuyenBan;
    }
}
