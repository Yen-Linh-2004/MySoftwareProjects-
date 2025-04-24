namespace Quan_Ly_Nha_Hang
{
    partial class Order_ChinhSua_UserControl
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_HoTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_Email = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_SoDienThoai = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_Luu = new Guna.UI2.WinForms.Guna2Button();
            this.c = new System.Windows.Forms.Label();
            this.txt_DiaChi = new Guna.UI2.WinForms.Guna2TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(40, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ && Tên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(40, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 45);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(40, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 45);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số ĐT:";
            // 
            // txt_HoTen
            // 
            this.txt_HoTen.AutoRoundedCorners = true;
            this.txt_HoTen.BorderColor = System.Drawing.Color.SlateGray;
            this.txt_HoTen.BorderRadius = 26;
            this.txt_HoTen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_HoTen.DefaultText = "";
            this.txt_HoTen.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_HoTen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_HoTen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_HoTen.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_HoTen.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_HoTen.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HoTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_HoTen.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_HoTen.Location = new System.Drawing.Point(276, 6);
            this.txt_HoTen.Margin = new System.Windows.Forms.Padding(6);
            this.txt_HoTen.Name = "txt_HoTen";
            this.txt_HoTen.PasswordChar = '\0';
            this.txt_HoTen.PlaceholderText = "";
            this.txt_HoTen.SelectedText = "";
            this.txt_HoTen.Size = new System.Drawing.Size(674, 55);
            this.txt_HoTen.TabIndex = 0;
            // 
            // txt_Email
            // 
            this.txt_Email.AutoRoundedCorners = true;
            this.txt_Email.BorderColor = System.Drawing.Color.SlateGray;
            this.txt_Email.BorderRadius = 26;
            this.txt_Email.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Email.DefaultText = "";
            this.txt_Email.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Email.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_Email.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Email.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Email.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Email.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Email.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Email.Location = new System.Drawing.Point(276, 115);
            this.txt_Email.Margin = new System.Windows.Forms.Padding(6);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.PasswordChar = '\0';
            this.txt_Email.PlaceholderText = "";
            this.txt_Email.SelectedText = "";
            this.txt_Email.Size = new System.Drawing.Size(674, 55);
            this.txt_Email.TabIndex = 1;
            this.txt_Email.TextChanged += new System.EventHandler(this.txt_Email_TextChanged);
            // 
            // txt_SoDienThoai
            // 
            this.txt_SoDienThoai.AutoRoundedCorners = true;
            this.txt_SoDienThoai.BorderColor = System.Drawing.Color.SlateGray;
            this.txt_SoDienThoai.BorderRadius = 26;
            this.txt_SoDienThoai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_SoDienThoai.DefaultText = "";
            this.txt_SoDienThoai.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_SoDienThoai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_SoDienThoai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_SoDienThoai.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_SoDienThoai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_SoDienThoai.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SoDienThoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_SoDienThoai.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_SoDienThoai.Location = new System.Drawing.Point(276, 232);
            this.txt_SoDienThoai.Margin = new System.Windows.Forms.Padding(6);
            this.txt_SoDienThoai.Name = "txt_SoDienThoai";
            this.txt_SoDienThoai.PasswordChar = '\0';
            this.txt_SoDienThoai.PlaceholderText = "";
            this.txt_SoDienThoai.SelectedText = "";
            this.txt_SoDienThoai.Size = new System.Drawing.Size(674, 55);
            this.txt_SoDienThoai.TabIndex = 2;
            this.txt_SoDienThoai.TextChanged += new System.EventHandler(this.txt_SoDienThoai_TextChanged);
            this.txt_SoDienThoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SoDienThoai_KeyPress);
            // 
            // btn_Luu
            // 
            this.btn_Luu.AutoRoundedCorners = true;
            this.btn_Luu.BorderRadius = 42;
            this.btn_Luu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Luu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Luu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Luu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Luu.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_Luu.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Bold);
            this.btn_Luu.ForeColor = System.Drawing.Color.White;
            this.btn_Luu.Image = global::Quan_Ly_Nha_Hang.Properties.Resources.Luu;
            this.btn_Luu.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_Luu.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.btn_Luu.IndicateFocus = true;
            this.btn_Luu.Location = new System.Drawing.Point(48, 479);
            this.btn_Luu.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(902, 87);
            this.btn_Luu.TabIndex = 10;
            this.btn_Luu.Text = "Lưu ";
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // c
            // 
            this.c.AutoSize = true;
            this.c.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c.ForeColor = System.Drawing.Color.SteelBlue;
            this.c.Location = new System.Drawing.Point(40, 352);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(166, 45);
            this.c.TabIndex = 11;
            this.c.Text = "Địa Chỉ:";
            // 
            // txt_DiaChi
            // 
            this.txt_DiaChi.AutoRoundedCorners = true;
            this.txt_DiaChi.BorderColor = System.Drawing.Color.SlateGray;
            this.txt_DiaChi.BorderRadius = 26;
            this.txt_DiaChi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_DiaChi.DefaultText = "";
            this.txt_DiaChi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_DiaChi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_DiaChi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_DiaChi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_DiaChi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_DiaChi.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DiaChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_DiaChi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_DiaChi.Location = new System.Drawing.Point(276, 342);
            this.txt_DiaChi.Margin = new System.Windows.Forms.Padding(7);
            this.txt_DiaChi.Name = "txt_DiaChi";
            this.txt_DiaChi.PasswordChar = '\0';
            this.txt_DiaChi.PlaceholderText = "";
            this.txt_DiaChi.SelectedText = "";
            this.txt_DiaChi.Size = new System.Drawing.Size(674, 55);
            this.txt_DiaChi.TabIndex = 3;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Order_ChinhSua_UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txt_DiaChi);
            this.Controls.Add(this.c);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.txt_SoDienThoai);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.txt_HoTen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Order_ChinhSua_UserControl";
            this.Size = new System.Drawing.Size(1018, 1504);
            this.Load += new System.EventHandler(this.Order_ChinhSua_UserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txt_HoTen;
        private Guna.UI2.WinForms.Guna2TextBox txt_Email;
        private Guna.UI2.WinForms.Guna2TextBox txt_SoDienThoai;
        private Guna.UI2.WinForms.Guna2Button btn_Luu;
        private System.Windows.Forms.Label c;
        private Guna.UI2.WinForms.Guna2TextBox txt_DiaChi;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
