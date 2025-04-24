namespace Quan_Ly_Nha_Hang
{
    partial class ThucDon_All_UserControl
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
            this.flp_ThucDon = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBox_Gia = new Guna.UI2.WinForms.Guna2ComboBox();
            this.comboBox_DanhMuc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txt_TimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_ThemMon = new Guna.UI2.WinForms.Guna2Button();
            this.comboBox_TrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.SuspendLayout();
            // 
            // flp_ThucDon
            // 
            this.flp_ThucDon.AutoScroll = true;
            this.flp_ThucDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flp_ThucDon.Location = new System.Drawing.Point(64, 315);
            this.flp_ThucDon.Name = "flp_ThucDon";
            this.flp_ThucDon.Size = new System.Drawing.Size(2048, 1062);
            this.flp_ThucDon.TabIndex = 23;
            // 
            // comboBox_Gia
            // 
            this.comboBox_Gia.AutoRoundedCorners = true;
            this.comboBox_Gia.BackColor = System.Drawing.Color.Transparent;
            this.comboBox_Gia.BorderColor = System.Drawing.Color.SlateGray;
            this.comboBox_Gia.BorderRadius = 17;
            this.comboBox_Gia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Gia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Gia.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_Gia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_Gia.Font = new System.Drawing.Font("Tahoma", 9F);
            this.comboBox_Gia.ForeColor = System.Drawing.Color.Black;
            this.comboBox_Gia.ItemHeight = 30;
            this.comboBox_Gia.Items.AddRange(new object[] {
            "Tăng dần",
            "Giảm dần"});
            this.comboBox_Gia.Location = new System.Drawing.Point(459, 195);
            this.comboBox_Gia.Name = "comboBox_Gia";
            this.comboBox_Gia.Size = new System.Drawing.Size(315, 36);
            this.comboBox_Gia.StartIndex = 0;
            this.comboBox_Gia.TabIndex = 21;
            this.comboBox_Gia.SelectedValueChanged += new System.EventHandler(this.comboBox_DanhMuc_SelectedValueChanged);
            // 
            // comboBox_DanhMuc
            // 
            this.comboBox_DanhMuc.AutoRoundedCorners = true;
            this.comboBox_DanhMuc.BackColor = System.Drawing.Color.Transparent;
            this.comboBox_DanhMuc.BorderColor = System.Drawing.Color.SlateGray;
            this.comboBox_DanhMuc.BorderRadius = 17;
            this.comboBox_DanhMuc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_DanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DanhMuc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_DanhMuc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_DanhMuc.Font = new System.Drawing.Font("Tahoma", 9F);
            this.comboBox_DanhMuc.ForeColor = System.Drawing.Color.Black;
            this.comboBox_DanhMuc.ItemHeight = 30;
            this.comboBox_DanhMuc.Items.AddRange(new object[] {
            "Tất cả"});
            this.comboBox_DanhMuc.Location = new System.Drawing.Point(70, 195);
            this.comboBox_DanhMuc.Name = "comboBox_DanhMuc";
            this.comboBox_DanhMuc.Size = new System.Drawing.Size(315, 36);
            this.comboBox_DanhMuc.StartIndex = 0;
            this.comboBox_DanhMuc.TabIndex = 19;
            this.comboBox_DanhMuc.SelectedValueChanged += new System.EventHandler(this.comboBox_DanhMuc_SelectedValueChanged);
            // 
            // txt_TimKiem
            // 
            this.txt_TimKiem.AutoRoundedCorners = true;
            this.txt_TimKiem.BorderColor = System.Drawing.Color.SlateGray;
            this.txt_TimKiem.BorderRadius = 37;
            this.txt_TimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TimKiem.DefaultText = "";
            this.txt_TimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_TimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_TimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_TimKiem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_TimKiem.Location = new System.Drawing.Point(70, 45);
            this.txt_TimKiem.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_TimKiem.Name = "txt_TimKiem";
            this.txt_TimKiem.PasswordChar = '\0';
            this.txt_TimKiem.PlaceholderText = "Tìm kiếm . . .";
            this.txt_TimKiem.SelectedText = "";
            this.txt_TimKiem.Size = new System.Drawing.Size(931, 77);
            this.txt_TimKiem.TabIndex = 20;
            this.txt_TimKiem.TextChanged += new System.EventHandler(this.txt_TimKiem_TextChanged);
            // 
            // btn_ThemMon
            // 
            this.btn_ThemMon.AutoRoundedCorners = true;
            this.btn_ThemMon.BorderRadius = 42;
            this.btn_ThemMon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThemMon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThemMon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_ThemMon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_ThemMon.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_ThemMon.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Bold);
            this.btn_ThemMon.ForeColor = System.Drawing.Color.White;
            this.btn_ThemMon.Image = global::Quan_Ly_Nha_Hang.Properties.Resources.icons8_plus_50;
            this.btn_ThemMon.ImageSize = new System.Drawing.Size(40, 40);
            this.btn_ThemMon.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.btn_ThemMon.IndicateFocus = true;
            this.btn_ThemMon.Location = new System.Drawing.Point(1756, 144);
            this.btn_ThemMon.Margin = new System.Windows.Forms.Padding(6);
            this.btn_ThemMon.Name = "btn_ThemMon";
            this.btn_ThemMon.Size = new System.Drawing.Size(356, 87);
            this.btn_ThemMon.TabIndex = 24;
            this.btn_ThemMon.Text = "Thêm Món";
            this.btn_ThemMon.Click += new System.EventHandler(this.btn_ThemMon_Click);
            // 
            // comboBox_TrangThai
            // 
            this.comboBox_TrangThai.AutoRoundedCorners = true;
            this.comboBox_TrangThai.BackColor = System.Drawing.Color.Transparent;
            this.comboBox_TrangThai.BorderColor = System.Drawing.Color.SlateGray;
            this.comboBox_TrangThai.BorderRadius = 17;
            this.comboBox_TrangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_TrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TrangThai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_TrangThai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_TrangThai.Font = new System.Drawing.Font("Tahoma", 9F);
            this.comboBox_TrangThai.ForeColor = System.Drawing.Color.Black;
            this.comboBox_TrangThai.ItemHeight = 30;
            this.comboBox_TrangThai.Items.AddRange(new object[] {
            "Có sẵn",
            "Hết món"});
            this.comboBox_TrangThai.Location = new System.Drawing.Point(859, 195);
            this.comboBox_TrangThai.Name = "comboBox_TrangThai";
            this.comboBox_TrangThai.Size = new System.Drawing.Size(315, 36);
            this.comboBox_TrangThai.StartIndex = 0;
            this.comboBox_TrangThai.TabIndex = 22;
            this.comboBox_TrangThai.SelectedValueChanged += new System.EventHandler(this.comboBox_DanhMuc_SelectedValueChanged);
            // 
            // ThucDon_All_UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.comboBox_TrangThai);
            this.Controls.Add(this.flp_ThucDon);
            this.Controls.Add(this.comboBox_Gia);
            this.Controls.Add(this.comboBox_DanhMuc);
            this.Controls.Add(this.txt_TimKiem);
            this.Controls.Add(this.btn_ThemMon);
            this.Name = "ThucDon_All_UserControl";
            this.Size = new System.Drawing.Size(2176, 1422);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_ThucDon;
        private Guna.UI2.WinForms.Guna2ComboBox comboBox_Gia;
        private Guna.UI2.WinForms.Guna2ComboBox comboBox_DanhMuc;
        private Guna.UI2.WinForms.Guna2TextBox txt_TimKiem;
        private Guna.UI2.WinForms.Guna2Button btn_ThemMon;
        private Guna.UI2.WinForms.Guna2ComboBox comboBox_TrangThai;
    }
}
