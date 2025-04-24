namespace Quan_Ly_Nha_Hang
{
    partial class ThongKe_Form
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea41 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend41 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series41 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title41 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea42 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend42 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series42 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title42 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea43 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend43 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series43 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title43 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea44 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend44 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series44 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title44 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.comboBox_Tuan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.comboBox_Nam = new Guna.UI2.WinForms.Guna2ComboBox();
            this.comboBox_Thang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.comboBox_ngayKetThuc = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.comboBox_ngayBatDau = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btn_trongNgay = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btn_Nam = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btn_khoangTG = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btn_Thang = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btn_Tuan = new Guna.UI2.WinForms.Guna2GradientButton();
            this.chart_doanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_monAn = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_khachHang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_nguyenLieu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart_doanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_monAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_khachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_nguyenLieu)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_Tuan
            // 
            this.comboBox_Tuan.AutoRoundedCorners = true;
            this.comboBox_Tuan.BackColor = System.Drawing.Color.Transparent;
            this.comboBox_Tuan.BorderRadius = 17;
            this.comboBox_Tuan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Tuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Tuan.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_Tuan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_Tuan.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Tuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBox_Tuan.ItemHeight = 30;
            this.comboBox_Tuan.Items.AddRange(new object[] {
            "Chọn tuần",
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_Tuan.Location = new System.Drawing.Point(819, 180);
            this.comboBox_Tuan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_Tuan.Name = "comboBox_Tuan";
            this.comboBox_Tuan.Size = new System.Drawing.Size(264, 36);
            this.comboBox_Tuan.TabIndex = 29;
            this.comboBox_Tuan.SelectedIndexChanged += new System.EventHandler(this.comboBox_ValueChanged);
            this.comboBox_Tuan.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox_Validating);
            // 
            // comboBox_Nam
            // 
            this.comboBox_Nam.AutoRoundedCorners = true;
            this.comboBox_Nam.BackColor = System.Drawing.Color.Transparent;
            this.comboBox_Nam.BorderRadius = 17;
            this.comboBox_Nam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Nam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Nam.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_Nam.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_Nam.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Nam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBox_Nam.ItemHeight = 30;
            this.comboBox_Nam.Items.AddRange(new object[] {
            "Chọn năm"});
            this.comboBox_Nam.Location = new System.Drawing.Point(1575, 180);
            this.comboBox_Nam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_Nam.Name = "comboBox_Nam";
            this.comboBox_Nam.Size = new System.Drawing.Size(264, 36);
            this.comboBox_Nam.TabIndex = 27;
            this.comboBox_Nam.SelectedIndexChanged += new System.EventHandler(this.comboBox_ValueChanged);
            this.comboBox_Nam.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox_Validating);
            // 
            // comboBox_Thang
            // 
            this.comboBox_Thang.AutoRoundedCorners = true;
            this.comboBox_Thang.BackColor = System.Drawing.Color.Transparent;
            this.comboBox_Thang.BorderRadius = 17;
            this.comboBox_Thang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Thang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Thang.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_Thang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_Thang.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Thang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBox_Thang.ItemHeight = 30;
            this.comboBox_Thang.Items.AddRange(new object[] {
            "Chọn tháng",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBox_Thang.Location = new System.Drawing.Point(1209, 180);
            this.comboBox_Thang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_Thang.Name = "comboBox_Thang";
            this.comboBox_Thang.Size = new System.Drawing.Size(264, 36);
            this.comboBox_Thang.TabIndex = 28;
            this.comboBox_Thang.SelectedIndexChanged += new System.EventHandler(this.comboBox_ValueChanged);
            this.comboBox_Thang.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox_Validating);
            // 
            // comboBox_ngayKetThuc
            // 
            this.comboBox_ngayKetThuc.AutoRoundedCorners = true;
            this.comboBox_ngayKetThuc.BackColor = System.Drawing.Color.Transparent;
            this.comboBox_ngayKetThuc.BorderRadius = 40;
            this.comboBox_ngayKetThuc.Checked = true;
            this.comboBox_ngayKetThuc.FillColor = System.Drawing.Color.White;
            this.comboBox_ngayKetThuc.FocusedColor = System.Drawing.Color.White;
            this.comboBox_ngayKetThuc.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_ngayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.comboBox_ngayKetThuc.Location = new System.Drawing.Point(471, 180);
            this.comboBox_ngayKetThuc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_ngayKetThuc.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.comboBox_ngayKetThuc.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.comboBox_ngayKetThuc.Name = "comboBox_ngayKetThuc";
            this.comboBox_ngayKetThuc.Size = new System.Drawing.Size(266, 83);
            this.comboBox_ngayKetThuc.TabIndex = 25;
            this.comboBox_ngayKetThuc.Value = new System.DateTime(2024, 11, 1, 17, 36, 30, 82);
            this.comboBox_ngayKetThuc.ValueChanged += new System.EventHandler(this.comboBox_ValueChanged);
            this.comboBox_ngayKetThuc.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox_Validating);
            // 
            // comboBox_ngayBatDau
            // 
            this.comboBox_ngayBatDau.AutoRoundedCorners = true;
            this.comboBox_ngayBatDau.BackColor = System.Drawing.Color.Transparent;
            this.comboBox_ngayBatDau.BorderRadius = 40;
            this.comboBox_ngayBatDau.Checked = true;
            this.comboBox_ngayBatDau.FillColor = System.Drawing.Color.White;
            this.comboBox_ngayBatDau.FocusedColor = System.Drawing.Color.White;
            this.comboBox_ngayBatDau.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_ngayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.comboBox_ngayBatDau.Location = new System.Drawing.Point(98, 180);
            this.comboBox_ngayBatDau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_ngayBatDau.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.comboBox_ngayBatDau.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.comboBox_ngayBatDau.Name = "comboBox_ngayBatDau";
            this.comboBox_ngayBatDau.Size = new System.Drawing.Size(266, 83);
            this.comboBox_ngayBatDau.TabIndex = 26;
            this.comboBox_ngayBatDau.Value = new System.DateTime(2024, 11, 1, 17, 36, 30, 82);
            this.comboBox_ngayBatDau.ValueChanged += new System.EventHandler(this.comboBox_ValueChanged);
            this.comboBox_ngayBatDau.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox_Validating);
            // 
            // btn_trongNgay
            // 
            this.btn_trongNgay.AutoRoundedCorners = true;
            this.btn_trongNgay.BorderRadius = 48;
            this.btn_trongNgay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_trongNgay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_trongNgay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_trongNgay.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_trongNgay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_trongNgay.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_trongNgay.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.btn_trongNgay.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_trongNgay.ForeColor = System.Drawing.Color.White;
            this.btn_trongNgay.Location = new System.Drawing.Point(84, 48);
            this.btn_trongNgay.Name = "btn_trongNgay";
            this.btn_trongNgay.Size = new System.Drawing.Size(302, 98);
            this.btn_trongNgay.TabIndex = 20;
            this.btn_trongNgay.Text = "Trong ngày";
            this.btn_trongNgay.Click += new System.EventHandler(this.btn_trongNgay_Click);
            // 
            // btn_Nam
            // 
            this.btn_Nam.AutoRoundedCorners = true;
            this.btn_Nam.BorderRadius = 48;
            this.btn_Nam.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Nam.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Nam.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Nam.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Nam.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Nam.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_Nam.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.btn_Nam.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Nam.ForeColor = System.Drawing.Color.White;
            this.btn_Nam.Location = new System.Drawing.Point(1554, 48);
            this.btn_Nam.Name = "btn_Nam";
            this.btn_Nam.Size = new System.Drawing.Size(302, 98);
            this.btn_Nam.TabIndex = 21;
            this.btn_Nam.Text = "Năm";
            this.btn_Nam.Click += new System.EventHandler(this.btn_Nam_Click);
            // 
            // btn_khoangTG
            // 
            this.btn_khoangTG.AutoRoundedCorners = true;
            this.btn_khoangTG.BorderRadius = 48;
            this.btn_khoangTG.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_khoangTG.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_khoangTG.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_khoangTG.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_khoangTG.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_khoangTG.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_khoangTG.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.btn_khoangTG.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_khoangTG.ForeColor = System.Drawing.Color.White;
            this.btn_khoangTG.Location = new System.Drawing.Point(452, 48);
            this.btn_khoangTG.Name = "btn_khoangTG";
            this.btn_khoangTG.Size = new System.Drawing.Size(302, 98);
            this.btn_khoangTG.TabIndex = 22;
            this.btn_khoangTG.Text = "Khoảng thời gian";
            this.btn_khoangTG.Click += new System.EventHandler(this.btn_khoangTG_Click);
            // 
            // btn_Thang
            // 
            this.btn_Thang.AutoRoundedCorners = true;
            this.btn_Thang.BorderRadius = 48;
            this.btn_Thang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Thang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Thang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Thang.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Thang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Thang.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_Thang.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.btn_Thang.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Thang.ForeColor = System.Drawing.Color.White;
            this.btn_Thang.Location = new System.Drawing.Point(1186, 48);
            this.btn_Thang.Name = "btn_Thang";
            this.btn_Thang.Size = new System.Drawing.Size(302, 98);
            this.btn_Thang.TabIndex = 23;
            this.btn_Thang.Text = "Tháng";
            this.btn_Thang.Click += new System.EventHandler(this.btn_Thang_Click);
            // 
            // btn_Tuan
            // 
            this.btn_Tuan.AutoRoundedCorners = true;
            this.btn_Tuan.BorderRadius = 48;
            this.btn_Tuan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Tuan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Tuan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Tuan.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Tuan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Tuan.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_Tuan.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.btn_Tuan.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tuan.ForeColor = System.Drawing.Color.White;
            this.btn_Tuan.Location = new System.Drawing.Point(819, 48);
            this.btn_Tuan.Name = "btn_Tuan";
            this.btn_Tuan.Size = new System.Drawing.Size(302, 98);
            this.btn_Tuan.TabIndex = 24;
            this.btn_Tuan.Text = "Tuần";
            this.btn_Tuan.Click += new System.EventHandler(this.btn_Tuan_Click);
            // 
            // chart_doanhThu
            // 
            chartArea41.Name = "ChartArea1";
            this.chart_doanhThu.ChartAreas.Add(chartArea41);
            legend41.Name = "Legend1";
            this.chart_doanhThu.Legends.Add(legend41);
            this.chart_doanhThu.Location = new System.Drawing.Point(34, 318);
            this.chart_doanhThu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart_doanhThu.Name = "chart_doanhThu";
            this.chart_doanhThu.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series41.ChartArea = "ChartArea1";
            series41.Legend = "Legend1";
            series41.Name = "Doanh thu";
            this.chart_doanhThu.Series.Add(series41);
            this.chart_doanhThu.Size = new System.Drawing.Size(1076, 575);
            this.chart_doanhThu.TabIndex = 30;
            title41.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title41.Name = "doanhThu";
            title41.Text = "Doanh Thu";
            this.chart_doanhThu.Titles.Add(title41);
            // 
            // chart_monAn
            // 
            chartArea42.Name = "ChartArea1";
            this.chart_monAn.ChartAreas.Add(chartArea42);
            legend42.Name = "Legend1";
            this.chart_monAn.Legends.Add(legend42);
            this.chart_monAn.Location = new System.Drawing.Point(34, 934);
            this.chart_monAn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart_monAn.Name = "chart_monAn";
            this.chart_monAn.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series42.ChartArea = "ChartArea1";
            series42.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series42.Legend = "Legend1";
            series42.Name = "Series1";
            this.chart_monAn.Series.Add(series42);
            this.chart_monAn.Size = new System.Drawing.Size(1076, 575);
            this.chart_monAn.TabIndex = 30;
            title42.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title42.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title42.Name = "Title1";
            title42.Text = "Món ăn bán chạy nhất";
            this.chart_monAn.Titles.Add(title42);
            // 
            // chart_khachHang
            // 
            chartArea43.Name = "ChartArea1";
            this.chart_khachHang.ChartAreas.Add(chartArea43);
            legend43.Name = "Legend2";
            this.chart_khachHang.Legends.Add(legend43);
            this.chart_khachHang.Location = new System.Drawing.Point(1145, 318);
            this.chart_khachHang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart_khachHang.Name = "chart_khachHang";
            series43.ChartArea = "ChartArea1";
            series43.Legend = "Legend2";
            series43.Name = "Khách hàng";
            this.chart_khachHang.Series.Add(series43);
            this.chart_khachHang.Size = new System.Drawing.Size(1076, 575);
            this.chart_khachHang.TabIndex = 30;
            title43.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title43.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title43.Name = "khachHang";
            title43.Text = "Khách hàng";
            this.chart_khachHang.Titles.Add(title43);
            // 
            // chart_nguyenLieu
            // 
            chartArea44.Name = "ChartArea1";
            this.chart_nguyenLieu.ChartAreas.Add(chartArea44);
            legend44.Name = "Legend1";
            this.chart_nguyenLieu.Legends.Add(legend44);
            this.chart_nguyenLieu.Location = new System.Drawing.Point(1145, 934);
            this.chart_nguyenLieu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart_nguyenLieu.Name = "chart_nguyenLieu";
            this.chart_nguyenLieu.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series44.ChartArea = "ChartArea1";
            series44.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series44.Legend = "Legend1";
            series44.Name = "Nguyên liệu";
            this.chart_nguyenLieu.Series.Add(series44);
            this.chart_nguyenLieu.Size = new System.Drawing.Size(1076, 575);
            this.chart_nguyenLieu.TabIndex = 30;
            title44.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title44.Name = "nguyenLieu";
            title44.Text = "Nguyên liệu dùng nhiều nhất";
            this.chart_nguyenLieu.Titles.Add(title44);
            // 
            // ThongKe_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(2275, 1533);
            this.Controls.Add(this.chart_nguyenLieu);
            this.Controls.Add(this.chart_monAn);
            this.Controls.Add(this.chart_khachHang);
            this.Controls.Add(this.chart_doanhThu);
            this.Controls.Add(this.comboBox_Tuan);
            this.Controls.Add(this.comboBox_Nam);
            this.Controls.Add(this.comboBox_Thang);
            this.Controls.Add(this.comboBox_ngayKetThuc);
            this.Controls.Add(this.comboBox_ngayBatDau);
            this.Controls.Add(this.btn_trongNgay);
            this.Controls.Add(this.btn_Nam);
            this.Controls.Add(this.btn_khoangTG);
            this.Controls.Add(this.btn_Thang);
            this.Controls.Add(this.btn_Tuan);
            this.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "ThongKe_Form";
            this.Text = "ThongKe_Form";
            this.Load += new System.EventHandler(this.ThongKe_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_doanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_monAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_khachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_nguyenLieu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox comboBox_Tuan;
        private Guna.UI2.WinForms.Guna2ComboBox comboBox_Nam;
        private Guna.UI2.WinForms.Guna2ComboBox comboBox_Thang;
        private Guna.UI2.WinForms.Guna2DateTimePicker comboBox_ngayKetThuc;
        private Guna.UI2.WinForms.Guna2DateTimePicker comboBox_ngayBatDau;
        private Guna.UI2.WinForms.Guna2GradientButton btn_trongNgay;
        private Guna.UI2.WinForms.Guna2GradientButton btn_Nam;
        private Guna.UI2.WinForms.Guna2GradientButton btn_khoangTG;
        private Guna.UI2.WinForms.Guna2GradientButton btn_Thang;
        private Guna.UI2.WinForms.Guna2GradientButton btn_Tuan;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_doanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_monAn;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_khachHang;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_nguyenLieu;
    }
}