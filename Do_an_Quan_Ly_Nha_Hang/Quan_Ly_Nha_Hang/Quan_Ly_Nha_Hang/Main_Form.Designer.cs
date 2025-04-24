namespace Quan_Ly_Nha_Hang
{
    partial class Main_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.Function_Panel = new System.Windows.Forms.Panel();
            this.SideBar_Panel = new System.Windows.Forms.Panel();
            this.txt_DangXuat = new System.Windows.Forms.Label();
            this.txt_TenNV = new System.Windows.Forms.Label();
            this.NguyenLieu_Panel = new System.Windows.Forms.Panel();
            this.btn_NhapNguyenLieu = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btn_XemNguyenLieu = new Guna.UI2.WinForms.Guna2GradientButton();
            this.NguyenLieu_Click_panel = new System.Windows.Forms.Panel();
            this.ThongKe_Click_panel = new System.Windows.Forms.Panel();
            this.NhanVien_Click_panel = new System.Windows.Forms.Panel();
            this.ThucDon_Click_panel = new System.Windows.Forms.Panel();
            this.TrangChu_Click_panel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_NguyenLieu = new Guna.UI2.WinForms.Guna2Button();
            this.btn_ThongKe = new Guna.UI2.WinForms.Guna2Button();
            this.btn_NhanVien = new Guna.UI2.WinForms.Guna2Button();
            this.btn_ThucDon = new Guna.UI2.WinForms.Guna2Button();
            this.btn_TrangChu = new Guna.UI2.WinForms.Guna2Button();
            this.Avatar_TaiKhoan = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Thaot = new Guna.UI2.WinForms.Guna2ImageButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SideBar_Panel.SuspendLayout();
            this.NguyenLieu_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar_TaiKhoan)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Function_Panel
            // 
            this.Function_Panel.AccessibleDescription = "";
            this.Function_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Function_Panel.AutoScroll = true;
            this.Function_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(234)))));
            this.Function_Panel.Location = new System.Drawing.Point(313, 57);
            this.Function_Panel.Name = "Function_Panel";
            this.Function_Panel.Size = new System.Drawing.Size(1151, 1289);
            this.Function_Panel.TabIndex = 1;
            // 
            // SideBar_Panel
            // 
            this.SideBar_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SideBar_Panel.Controls.Add(this.txt_DangXuat);
            this.SideBar_Panel.Controls.Add(this.txt_TenNV);
            this.SideBar_Panel.Controls.Add(this.NguyenLieu_Panel);
            this.SideBar_Panel.Controls.Add(this.NguyenLieu_Click_panel);
            this.SideBar_Panel.Controls.Add(this.ThongKe_Click_panel);
            this.SideBar_Panel.Controls.Add(this.NhanVien_Click_panel);
            this.SideBar_Panel.Controls.Add(this.ThucDon_Click_panel);
            this.SideBar_Panel.Controls.Add(this.TrangChu_Click_panel);
            this.SideBar_Panel.Controls.Add(this.panel2);
            this.SideBar_Panel.Controls.Add(this.pictureBox1);
            this.SideBar_Panel.Controls.Add(this.btn_NguyenLieu);
            this.SideBar_Panel.Controls.Add(this.btn_ThongKe);
            this.SideBar_Panel.Controls.Add(this.btn_NhanVien);
            this.SideBar_Panel.Controls.Add(this.btn_ThucDon);
            this.SideBar_Panel.Controls.Add(this.btn_TrangChu);
            this.SideBar_Panel.Controls.Add(this.Avatar_TaiKhoan);
            this.SideBar_Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SideBar_Panel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.SideBar_Panel.Location = new System.Drawing.Point(0, 0);
            this.SideBar_Panel.Name = "SideBar_Panel";
            this.SideBar_Panel.Size = new System.Drawing.Size(313, 1346);
            this.SideBar_Panel.TabIndex = 0;
            // 
            // txt_DangXuat
            // 
            this.txt_DangXuat.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txt_DangXuat.AutoSize = true;
            this.txt_DangXuat.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DangXuat.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.txt_DangXuat.Location = new System.Drawing.Point(106, 1275);
            this.txt_DangXuat.Name = "txt_DangXuat";
            this.txt_DangXuat.Size = new System.Drawing.Size(275, 58);
            this.txt_DangXuat.TabIndex = 0;
            this.txt_DangXuat.Text = "Đăng xuất";
            this.txt_DangXuat.Click += new System.EventHandler(this.txt_DangXuat_Click);
            // 
            // txt_TenNV
            // 
            this.txt_TenNV.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txt_TenNV.AutoEllipsis = true;
            this.txt_TenNV.AutoSize = true;
            this.txt_TenNV.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenNV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_TenNV.Location = new System.Drawing.Point(108, 1229);
            this.txt_TenNV.MaximumSize = new System.Drawing.Size(210, 0);
            this.txt_TenNV.Name = "txt_TenNV";
            this.txt_TenNV.Size = new System.Drawing.Size(72, 45);
            this.txt_TenNV.TabIndex = 10;
            this.txt_TenNV.Text = "tên";
            // 
            // NguyenLieu_Panel
            // 
            this.NguyenLieu_Panel.Controls.Add(this.btn_NhapNguyenLieu);
            this.NguyenLieu_Panel.Controls.Add(this.btn_XemNguyenLieu);
            this.NguyenLieu_Panel.Location = new System.Drawing.Point(3, 660);
            this.NguyenLieu_Panel.Margin = new System.Windows.Forms.Padding(0);
            this.NguyenLieu_Panel.Name = "NguyenLieu_Panel";
            this.NguyenLieu_Panel.Size = new System.Drawing.Size(310, 112);
            this.NguyenLieu_Panel.TabIndex = 0;
            // 
            // btn_NhapNguyenLieu
            // 
            this.btn_NhapNguyenLieu.BackColor = System.Drawing.Color.Transparent;
            this.btn_NhapNguyenLieu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_NhapNguyenLieu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_NhapNguyenLieu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_NhapNguyenLieu.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_NhapNguyenLieu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_NhapNguyenLieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_NhapNguyenLieu.FillColor = System.Drawing.Color.DimGray;
            this.btn_NhapNguyenLieu.FillColor2 = System.Drawing.Color.DimGray;
            this.btn_NhapNguyenLieu.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NhapNguyenLieu.ForeColor = System.Drawing.Color.White;
            this.btn_NhapNguyenLieu.Location = new System.Drawing.Point(0, 53);
            this.btn_NhapNguyenLieu.Margin = new System.Windows.Forms.Padding(0);
            this.btn_NhapNguyenLieu.Name = "btn_NhapNguyenLieu";
            this.btn_NhapNguyenLieu.Size = new System.Drawing.Size(310, 53);
            this.btn_NhapNguyenLieu.TabIndex = 10;
            this.btn_NhapNguyenLieu.Text = "Nhập nguyên liệu";
            this.btn_NhapNguyenLieu.Click += new System.EventHandler(this.btn_NhapNguyenLieu_Click);
            // 
            // btn_XemNguyenLieu
            // 
            this.btn_XemNguyenLieu.BackColor = System.Drawing.Color.DimGray;
            this.btn_XemNguyenLieu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_XemNguyenLieu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_XemNguyenLieu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_XemNguyenLieu.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_XemNguyenLieu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_XemNguyenLieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_XemNguyenLieu.FillColor = System.Drawing.Color.DimGray;
            this.btn_XemNguyenLieu.FillColor2 = System.Drawing.Color.DimGray;
            this.btn_XemNguyenLieu.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XemNguyenLieu.ForeColor = System.Drawing.Color.White;
            this.btn_XemNguyenLieu.Location = new System.Drawing.Point(0, 0);
            this.btn_XemNguyenLieu.Margin = new System.Windows.Forms.Padding(0);
            this.btn_XemNguyenLieu.Name = "btn_XemNguyenLieu";
            this.btn_XemNguyenLieu.Size = new System.Drawing.Size(310, 53);
            this.btn_XemNguyenLieu.TabIndex = 0;
            this.btn_XemNguyenLieu.Text = "Xem nguyên liệu";
            this.btn_XemNguyenLieu.Click += new System.EventHandler(this.btn_XemNguyenLieu_Click);
            // 
            // NguyenLieu_Click_panel
            // 
            this.NguyenLieu_Click_panel.BackColor = System.Drawing.Color.SteelBlue;
            this.NguyenLieu_Click_panel.Location = new System.Drawing.Point(305, 579);
            this.NguyenLieu_Click_panel.Name = "NguyenLieu_Click_panel";
            this.NguyenLieu_Click_panel.Size = new System.Drawing.Size(10, 78);
            this.NguyenLieu_Click_panel.TabIndex = 9;
            // 
            // ThongKe_Click_panel
            // 
            this.ThongKe_Click_panel.BackColor = System.Drawing.Color.SteelBlue;
            this.ThongKe_Click_panel.Location = new System.Drawing.Point(305, 504);
            this.ThongKe_Click_panel.Name = "ThongKe_Click_panel";
            this.ThongKe_Click_panel.Size = new System.Drawing.Size(10, 78);
            this.ThongKe_Click_panel.TabIndex = 3;
            // 
            // NhanVien_Click_panel
            // 
            this.NhanVien_Click_panel.BackColor = System.Drawing.Color.SteelBlue;
            this.NhanVien_Click_panel.Location = new System.Drawing.Point(305, 426);
            this.NhanVien_Click_panel.Name = "NhanVien_Click_panel";
            this.NhanVien_Click_panel.Size = new System.Drawing.Size(10, 78);
            this.NhanVien_Click_panel.TabIndex = 2;
            // 
            // ThucDon_Click_panel
            // 
            this.ThucDon_Click_panel.BackColor = System.Drawing.Color.SteelBlue;
            this.ThucDon_Click_panel.Location = new System.Drawing.Point(305, 348);
            this.ThucDon_Click_panel.Name = "ThucDon_Click_panel";
            this.ThucDon_Click_panel.Size = new System.Drawing.Size(10, 78);
            this.ThucDon_Click_panel.TabIndex = 1;
            // 
            // TrangChu_Click_panel
            // 
            this.TrangChu_Click_panel.BackColor = System.Drawing.Color.SteelBlue;
            this.TrangChu_Click_panel.Location = new System.Drawing.Point(305, 270);
            this.TrangChu_Click_panel.Name = "TrangChu_Click_panel";
            this.TrangChu_Click_panel.Size = new System.Drawing.Size(10, 78);
            this.TrangChu_Click_panel.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 57);
            this.panel2.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(32, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(235, 207);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btn_NguyenLieu
            // 
            this.btn_NguyenLieu.BackColor = System.Drawing.Color.Transparent;
            this.btn_NguyenLieu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_NguyenLieu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_NguyenLieu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_NguyenLieu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_NguyenLieu.FillColor = System.Drawing.Color.Transparent;
            this.btn_NguyenLieu.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NguyenLieu.ForeColor = System.Drawing.Color.White;
            this.btn_NguyenLieu.HoverState.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_NguyenLieu.Image = ((System.Drawing.Image)(resources.GetObject("btn_NguyenLieu.Image")));
            this.btn_NguyenLieu.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_NguyenLieu.ImageSize = new System.Drawing.Size(60, 60);
            this.btn_NguyenLieu.Location = new System.Drawing.Point(-1, 579);
            this.btn_NguyenLieu.Margin = new System.Windows.Forms.Padding(0);
            this.btn_NguyenLieu.Name = "btn_NguyenLieu";
            this.btn_NguyenLieu.Size = new System.Drawing.Size(316, 78);
            this.btn_NguyenLieu.TabIndex = 6;
            this.btn_NguyenLieu.Text = "Nguyên liệu";
            this.btn_NguyenLieu.Click += new System.EventHandler(this.btn_NguyenLieu_Click);
            // 
            // btn_ThongKe
            // 
            this.btn_ThongKe.BackColor = System.Drawing.Color.Transparent;
            this.btn_ThongKe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThongKe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThongKe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_ThongKe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_ThongKe.FillColor = System.Drawing.Color.Transparent;
            this.btn_ThongKe.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThongKe.ForeColor = System.Drawing.Color.White;
            this.btn_ThongKe.HoverState.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_ThongKe.Image = global::Quan_Ly_Nha_Hang.Properties.Resources.Acounting;
            this.btn_ThongKe.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_ThongKe.ImageSize = new System.Drawing.Size(60, 60);
            this.btn_ThongKe.Location = new System.Drawing.Point(-1, 504);
            this.btn_ThongKe.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ThongKe.Name = "btn_ThongKe";
            this.btn_ThongKe.Size = new System.Drawing.Size(316, 74);
            this.btn_ThongKe.TabIndex = 5;
            this.btn_ThongKe.Text = "Thống Kê";
            this.btn_ThongKe.Click += new System.EventHandler(this.btn_ThongKe_Click);
            // 
            // btn_NhanVien
            // 
            this.btn_NhanVien.BackColor = System.Drawing.Color.Transparent;
            this.btn_NhanVien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_NhanVien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_NhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_NhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_NhanVien.FillColor = System.Drawing.Color.Transparent;
            this.btn_NhanVien.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NhanVien.ForeColor = System.Drawing.Color.White;
            this.btn_NhanVien.HoverState.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_NhanVien.Image = global::Quan_Ly_Nha_Hang.Properties.Resources.staff;
            this.btn_NhanVien.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_NhanVien.ImageSize = new System.Drawing.Size(60, 60);
            this.btn_NhanVien.Location = new System.Drawing.Point(1, 426);
            this.btn_NhanVien.Margin = new System.Windows.Forms.Padding(0);
            this.btn_NhanVien.Name = "btn_NhanVien";
            this.btn_NhanVien.Size = new System.Drawing.Size(312, 78);
            this.btn_NhanVien.TabIndex = 4;
            this.btn_NhanVien.Text = "Nhân Viên";
            this.btn_NhanVien.Click += new System.EventHandler(this.btn_NhanVien_Click);
            // 
            // btn_ThucDon
            // 
            this.btn_ThucDon.BackColor = System.Drawing.Color.Transparent;
            this.btn_ThucDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThucDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThucDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_ThucDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_ThucDon.FillColor = System.Drawing.Color.Transparent;
            this.btn_ThucDon.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThucDon.ForeColor = System.Drawing.Color.White;
            this.btn_ThucDon.HoverState.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_ThucDon.Image = global::Quan_Ly_Nha_Hang.Properties.Resources.menu;
            this.btn_ThucDon.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_ThucDon.ImageSize = new System.Drawing.Size(60, 60);
            this.btn_ThucDon.Location = new System.Drawing.Point(0, 348);
            this.btn_ThucDon.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ThucDon.Name = "btn_ThucDon";
            this.btn_ThucDon.Size = new System.Drawing.Size(313, 78);
            this.btn_ThucDon.TabIndex = 3;
            this.btn_ThucDon.Text = "Thực Đơn";
            this.btn_ThucDon.Click += new System.EventHandler(this.btn_ThucDon_Click);
            // 
            // btn_TrangChu
            // 
            this.btn_TrangChu.BackColor = System.Drawing.Color.Transparent;
            this.btn_TrangChu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_TrangChu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_TrangChu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_TrangChu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_TrangChu.FillColor = System.Drawing.Color.Transparent;
            this.btn_TrangChu.Font = new System.Drawing.Font("Tahoma", 18F);
            this.btn_TrangChu.ForeColor = System.Drawing.Color.White;
            this.btn_TrangChu.HoverState.BorderColor = System.Drawing.Color.White;
            this.btn_TrangChu.HoverState.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_TrangChu.Image = global::Quan_Ly_Nha_Hang.Properties.Resources.Home;
            this.btn_TrangChu.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_TrangChu.ImageSize = new System.Drawing.Size(60, 60);
            this.btn_TrangChu.Location = new System.Drawing.Point(0, 270);
            this.btn_TrangChu.Margin = new System.Windows.Forms.Padding(0);
            this.btn_TrangChu.Name = "btn_TrangChu";
            this.btn_TrangChu.Size = new System.Drawing.Size(313, 78);
            this.btn_TrangChu.TabIndex = 2;
            this.btn_TrangChu.Text = "Trang Chủ";
            this.btn_TrangChu.Click += new System.EventHandler(this.btn_TrangChu_Click);
            // 
            // Avatar_TaiKhoan
            // 
            this.Avatar_TaiKhoan.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Avatar_TaiKhoan.Image = global::Quan_Ly_Nha_Hang.Properties.Resources.avatar;
            this.Avatar_TaiKhoan.ImageRotate = 0F;
            this.Avatar_TaiKhoan.Location = new System.Drawing.Point(8, 1220);
            this.Avatar_TaiKhoan.Name = "Avatar_TaiKhoan";
            this.Avatar_TaiKhoan.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Avatar_TaiKhoan.Size = new System.Drawing.Size(95, 98);
            this.Avatar_TaiKhoan.TabIndex = 1;
            this.Avatar_TaiKhoan.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(72)))), ((int)(((byte)(140)))));
            this.panel1.Controls.Add(this.btn_Thaot);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(313, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1151, 57);
            this.panel1.TabIndex = 2;
            // 
            // btn_Thaot
            // 
            this.btn_Thaot.BackColor = System.Drawing.Color.Transparent;
            this.btn_Thaot.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btn_Thaot.HoverState.ImageSize = new System.Drawing.Size(23, 23);
            this.btn_Thaot.Image = ((System.Drawing.Image)(resources.GetObject("btn_Thaot.Image")));
            this.btn_Thaot.ImageOffset = new System.Drawing.Point(0, 0);
            this.btn_Thaot.ImageRotate = 0F;
            this.btn_Thaot.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_Thaot.IndicateFocus = true;
            this.btn_Thaot.Location = new System.Drawing.Point(1055, 0);
            this.btn_Thaot.Name = "btn_Thaot";
            this.btn_Thaot.PressedState.ImageSize = new System.Drawing.Size(23, 23);
            this.btn_Thaot.Size = new System.Drawing.Size(61, 64);
            this.btn_Thaot.TabIndex = 1;
            this.btn_Thaot.UseTransparentBackground = true;
            this.btn_Thaot.Click += new System.EventHandler(this.btn_Thaot_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Main_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1464, 1346);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Function_Panel);
            this.Controls.Add(this.SideBar_Panel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main_Form";
            this.Text = "Main_Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.SideBar_Panel.ResumeLayout(false);
            this.SideBar_Panel.PerformLayout();
            this.NguyenLieu_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar_TaiKhoan)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Function_Panel;
        private System.Windows.Forms.Panel SideBar_Panel;
        private Guna.UI2.WinForms.Guna2CirclePictureBox Avatar_TaiKhoan;
        private Guna.UI2.WinForms.Guna2Button btn_TrangChu;
        private Guna.UI2.WinForms.Guna2Button btn_ThucDon;
        private Guna.UI2.WinForms.Guna2Button btn_ThongKe;
        private Guna.UI2.WinForms.Guna2Button btn_NhanVien;
        private Guna.UI2.WinForms.Guna2Button btn_NguyenLieu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2ImageButton btn_Thaot;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel TrangChu_Click_panel;
        private System.Windows.Forms.Panel NguyenLieu_Click_panel;
        private System.Windows.Forms.Panel ThongKe_Click_panel;
        private System.Windows.Forms.Panel NhanVien_Click_panel;
        private System.Windows.Forms.Panel ThucDon_Click_panel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel NguyenLieu_Panel;
        private Guna.UI2.WinForms.Guna2GradientButton btn_NhapNguyenLieu;
        private Guna.UI2.WinForms.Guna2GradientButton btn_XemNguyenLieu;
        private System.Windows.Forms.Label txt_TenNV;
        private System.Windows.Forms.Label txt_DangXuat;
    }
}