namespace Quan_Ly_Nha_Hang
{
    partial class Order_QR_UserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order_QR_UserControl));
            this.txt_QR_TongTien = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ThongBaoTinNhan = new System.Windows.Forms.Label();
            this.btn_The_ThanhToan = new Guna.UI2.WinForms.Guna2Button();
            this.lab_1 = new System.Windows.Forms.Label();
            this.pictureBox_QRCode = new System.Windows.Forms.PictureBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btn_inHoaDon = new Guna.UI2.WinForms.Guna2Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_QRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_QR_TongTien
            // 
            this.txt_QR_TongTien.AutoRoundedCorners = true;
            this.txt_QR_TongTien.BorderColor = System.Drawing.Color.SlateGray;
            this.txt_QR_TongTien.BorderRadius = 28;
            this.txt_QR_TongTien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_QR_TongTien.DefaultText = "";
            this.txt_QR_TongTien.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_QR_TongTien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_QR_TongTien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_QR_TongTien.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_QR_TongTien.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(234)))));
            this.txt_QR_TongTien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_QR_TongTien.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_QR_TongTien.ForeColor = System.Drawing.Color.ForestGreen;
            this.txt_QR_TongTien.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_QR_TongTien.Location = new System.Drawing.Point(298, 0);
            this.txt_QR_TongTien.Margin = new System.Windows.Forms.Padding(6);
            this.txt_QR_TongTien.Name = "txt_QR_TongTien";
            this.txt_QR_TongTien.PasswordChar = '\0';
            this.txt_QR_TongTien.PlaceholderText = "";
            this.txt_QR_TongTien.ReadOnly = true;
            this.txt_QR_TongTien.SelectedText = "";
            this.txt_QR_TongTien.Size = new System.Drawing.Size(688, 58);
            this.txt_QR_TongTien.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(46, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 52);
            this.label1.TabIndex = 24;
            this.label1.Text = "Tổng tiền:";
            // 
            // txt_ThongBaoTinNhan
            // 
            this.txt_ThongBaoTinNhan.Font = new System.Drawing.Font("Tahoma", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ThongBaoTinNhan.ForeColor = System.Drawing.Color.LimeGreen;
            this.txt_ThongBaoTinNhan.Location = new System.Drawing.Point(56, 1317);
            this.txt_ThongBaoTinNhan.Name = "txt_ThongBaoTinNhan";
            this.txt_ThongBaoTinNhan.Size = new System.Drawing.Size(930, 52);
            this.txt_ThongBaoTinNhan.TabIndex = 27;
            this.txt_ThongBaoTinNhan.Text = "Thông Báo Thanh Toán";
            this.txt_ThongBaoTinNhan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_The_ThanhToan
            // 
            this.btn_The_ThanhToan.AutoRoundedCorners = true;
            this.btn_The_ThanhToan.BorderRadius = 96;
            this.btn_The_ThanhToan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_The_ThanhToan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_The_ThanhToan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_The_ThanhToan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_The_ThanhToan.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_The_ThanhToan.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Bold);
            this.btn_The_ThanhToan.ForeColor = System.Drawing.Color.White;
            this.btn_The_ThanhToan.Image = global::Quan_Ly_Nha_Hang.Properties.Resources.ThanhToan;
            this.btn_The_ThanhToan.ImageSize = new System.Drawing.Size(90, 90);
            this.btn_The_ThanhToan.Location = new System.Drawing.Point(56, 842);
            this.btn_The_ThanhToan.Margin = new System.Windows.Forms.Padding(6);
            this.btn_The_ThanhToan.Name = "btn_The_ThanhToan";
            this.btn_The_ThanhToan.Size = new System.Drawing.Size(942, 194);
            this.btn_The_ThanhToan.TabIndex = 26;
            this.btn_The_ThanhToan.Text = "Thanh Toán";
            this.btn_The_ThanhToan.Click += new System.EventHandler(this.btn_The_ThanhToan_Click);
            // 
            // lab_1
            // 
            this.lab_1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_1.ForeColor = System.Drawing.Color.Black;
            this.lab_1.Location = new System.Drawing.Point(108, 64);
            this.lab_1.Name = "lab_1";
            this.lab_1.Size = new System.Drawing.Size(839, 128);
            this.lab_1.TabIndex = 28;
            this.lab_1.Text = "Hãy quét mã để thanh toán";
            this.lab_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox_QRCode
            // 
            this.pictureBox_QRCode.Location = new System.Drawing.Point(56, 197);
            this.pictureBox_QRCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_QRCode.Name = "pictureBox_QRCode";
            this.pictureBox_QRCode.Size = new System.Drawing.Size(943, 608);
            this.pictureBox_QRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_QRCode.TabIndex = 29;
            this.pictureBox_QRCode.TabStop = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // btn_inHoaDon
            // 
            this.btn_inHoaDon.AutoRoundedCorners = true;
            this.btn_inHoaDon.BorderRadius = 100;
            this.btn_inHoaDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_inHoaDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_inHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_inHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_inHoaDon.Enabled = false;
            this.btn_inHoaDon.FillColor = System.Drawing.Color.SteelBlue;
            this.btn_inHoaDon.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Bold);
            this.btn_inHoaDon.ForeColor = System.Drawing.Color.White;
            this.btn_inHoaDon.Image = ((System.Drawing.Image)(resources.GetObject("btn_inHoaDon.Image")));
            this.btn_inHoaDon.ImageSize = new System.Drawing.Size(90, 90);
            this.btn_inHoaDon.Location = new System.Drawing.Point(55, 1058);
            this.btn_inHoaDon.Margin = new System.Windows.Forms.Padding(6);
            this.btn_inHoaDon.Name = "btn_inHoaDon";
            this.btn_inHoaDon.Size = new System.Drawing.Size(943, 202);
            this.btn_inHoaDon.TabIndex = 30;
            this.btn_inHoaDon.Text = "In hóa đơn";
            this.btn_inHoaDon.Click += new System.EventHandler(this.btn_inHoaDon_Click_1);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // Order_QR_UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btn_inHoaDon);
            this.Controls.Add(this.pictureBox_QRCode);
            this.Controls.Add(this.lab_1);
            this.Controls.Add(this.txt_ThongBaoTinNhan);
            this.Controls.Add(this.btn_The_ThanhToan);
            this.Controls.Add(this.txt_QR_TongTien);
            this.Controls.Add(this.label1);
            this.Name = "Order_QR_UserControl";
            this.Size = new System.Drawing.Size(1018, 1420);
            this.Load += new System.EventHandler(this.Order_QR_UserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_QRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txt_QR_TongTien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txt_ThongBaoTinNhan;
        private Guna.UI2.WinForms.Guna2Button btn_The_ThanhToan;
        private System.Windows.Forms.Label lab_1;
        private System.Windows.Forms.PictureBox pictureBox_QRCode;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Guna.UI2.WinForms.Guna2Button btn_inHoaDon;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}
