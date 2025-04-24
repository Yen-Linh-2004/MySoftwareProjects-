using Quan_Ly_Nha_Hang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Nha_Hang
{
    public partial class Order_TienMat_UserControl : UserControl
    {
        BAN Ban;
        HOADON HoaDon;
        double TongTien;
        KHUYENMAI KhuyenMai;
        private TrangChu_Form.CapNhatTrangThaiBanDelegate CapNhatUI;
        List<KeyValuePair<MON, int>> value;

        public Order_TienMat_UserControl(BAN bAN, HOADON hoaDon, double tongTien, KHUYENMAI khuyenmai)
        {
            InitializeComponent();
            this.Ban = bAN;
            this.HoaDon = hoaDon;
            this.TongTien = tongTien;
            this.KhuyenMai = khuyenmai;
            this.txt_TienMat_TongTien.Text = tongTien.ToString("#,##0") + " VNĐ";
            btn_inHoaDon.Visible = false;
            txt_ThongBaoTinNhan.Visible = false;
            var trangChuForm = Application.OpenForms.OfType<TrangChu_Form>().FirstOrDefault();
            {
                this.CapNhatUI = trangChuForm.CapNhatUIBan;
            }
            value = TrangChu_Form.monAnCuaBan[Ban.IDBan].ToList();
        }
        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                double.TryParse(txt_TienNhan.Text.Replace(" VNĐ", "").Replace(",", ""), out double value);
                double.TryParse(txt_TienThua.Text.Replace(" VNĐ", "").Replace(",", ""), out double value1);
                if (string.IsNullOrEmpty(txt_TienNhan.Text) || value1 < 0)
                {
                    MessageBox.Show("Số tiền nhận không hợp lệ");
                    return;
                }
                if (!string.IsNullOrEmpty(txt_TienNhan.Text) && value > 0)
                {
                    var hoadon = Main_Form.data.HOADON.FirstOrDefault(t => t.IDHoaDon == HoaDon.IDHoaDon);
                    hoadon.PhuongThucTT = "Tiền mặt";
                    hoadon.NgayThanhToan = DateTime.Now;
                    if (KhuyenMai.IDKhuyenMai > 0)
                        hoadon.IDKhuyenMai = KhuyenMai.IDKhuyenMai;
                    hoadon.ThanhTien = TongTien;
                    hoadon.TrangThaiTT = "Đã thanh toán";
                    Main_Form.data.SaveChanges();
                    btn_ThanhToan.Enabled = false;
                    btn_inHoaDon.Enabled = true;
                    btn_inHoaDon.Visible = true;
                    Main_Form.data.SP_CapNhatLoaiKhachHang();
                    Main_Form.data.KHACHHANG.Load();
                    CapNhatUI.Invoke();
                    txt_ThongBaoTinNhan.Text = "Thanh toán thành công";
                    txt_ThongBaoTinNhan.Visible = true;
                    if (this.ParentForm is Order_Form parent)
                    {
                        parent.VoHieuHoa_btn_Back();
                    }
                    TrangChu_Form.monAnCuaBan[Ban.IDBan].Clear();
                }
                txt_TienNhan.Enabled = false;
            }
            catch
            {
                txt_ThongBaoTinNhan.Text = "Thanh toán không thành công";
                txt_ThongBaoTinNhan.ForeColor = Color.Red;
                txt_ThongBaoTinNhan.Visible = true;
            }

        }

        private void txt_TienNhan_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txt_TienNhan.Text.Replace(" VNĐ", "").Replace(",", ""), out double value))
            {
                txt_TienNhan.Text = value.ToString("#,##0") + " VNĐ";
                double tienthua = value - TongTien;
                txt_TienThua.Text = tienthua.ToString("#,##0") + " VNĐ";
                txt_TienNhan.SelectionStart = txt_TienNhan.Text.Length;
            }
            else
            {
                txt_TienThua.Text = string.Empty;
            }
        }

        private void txt_TienNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError((Control)sender, "Chỉ được nhập số");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font titleFont = new Font("Arial", 24, FontStyle.Bold);
            Font subTitleFont = new Font("Arial", 14, FontStyle.Bold);
            Font normalFont = new Font("Arial", 14);
            Brush brush = Brushes.Black;

            float pageCenterX = e.PageBounds.Width / 2;

            string title = "NHÀ HÀNG SPICE & SOUL";
            string subtitle = "HÓA ĐƠN THANH TOÁN";

            SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
            SizeF subTitleSize = e.Graphics.MeasureString(subtitle, subTitleFont);
            int ypos = 120;
            Pen pen = new Pen(Color.Black, 2);
            int xStart = 30;
            int width = 790;

            // Draw centered text
            e.Graphics.DrawString(title, titleFont, brush, pageCenterX - (titleSize.Width / 2), 40);
            e.Graphics.DrawString(subtitle, normalFont, brush, pageCenterX - (subTitleSize.Width / 2), 90);
            e.Graphics.DrawLine(pen, xStart, ypos + 10, xStart + width, ypos + 10);


            e.Graphics.DrawString("Mã hóa đơn: ", normalFont, brush, new PointF(50, ypos + 30));
            e.Graphics.DrawString(HoaDon.IDHoaDon.ToString(), subTitleFont, brush, new PointF(250, ypos + 30));

            e.Graphics.DrawString("Ngày Lập: ", normalFont, brush, new PointF(520, ypos + 30));
            e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy    HH:mm:ss"), subTitleFont, brush, new PointF(620, ypos + 30));

            e.Graphics.DrawString("Nhân viên lập:", normalFont, brush, new PointF(50, ypos + 60));
            e.Graphics.DrawString(Main_Form.data.NHANVIEN.Find(Main_Form.Instance.TaiKhoanNguoiDung.IDNhanVien).HotenNV, subTitleFont, brush, new PointF(250, ypos + 60));

            e.Graphics.DrawString("Tên khách hàng: ", normalFont, brush, new PointF(50, ypos + 90));
            e.Graphics.DrawString(TrangChu_Form.dsbanvakhach[Ban.IDBan].HotenKH, subTitleFont, brush, new PointF(250, ypos + 90));

            // Table headers
            e.Graphics.DrawString("STT", subTitleFont, brush, new PointF(50, ypos + 120));
            e.Graphics.DrawString("Tên Sản Phẩm", subTitleFont, brush, new PointF(100, ypos + 120));
            e.Graphics.DrawString("Đơn Giá", subTitleFont, brush, new PointF(300, ypos + 120));
            e.Graphics.DrawString("Số Lượng", subTitleFont, brush, new PointF(400, ypos + 120));
            e.Graphics.DrawString("Khuyến Mãi", subTitleFont, brush, new PointF(550, ypos + 120));
            e.Graphics.DrawString("Thành Tiền", subTitleFont, brush, new PointF(700, ypos + 120));

            // Table content 
            int yPosition = 300;
            int i = 1;
            foreach (var item in value)
            {
                e.Graphics.DrawString(i.ToString(), normalFont, brush, new PointF(50, yPosition));
                e.Graphics.DrawString(item.Key.TenMon, normalFont, brush, new PointF(100, yPosition));
                e.Graphics.DrawString(item.Key.DonGia.ToString(), normalFont, brush, new PointF(300, yPosition));
                e.Graphics.DrawString(item.Value.ToString(), normalFont, brush, new PointF(400, yPosition));
                e.Graphics.DrawString(0.ToString(), normalFont, brush, new PointF(550, yPosition));
                e.Graphics.DrawString((item.Key.DonGia * item.Value).ToString(), normalFont, brush, new PointF(700, yPosition));
                yPosition += 30;
                i++;
            }

            // Main
            string text = TongTien.ToString("#,##0") + " VNĐ";
            SizeF textSize = e.Graphics.MeasureString(text, subTitleFont);

            e.Graphics.DrawString("Tổng Tiền: ", normalFont, brush, new PointF(450, yPosition + 50));
            e.Graphics.DrawString(text, subTitleFont, brush, new PointF(e.PageBounds.Width - textSize.Width - 50, yPosition + 50));

            text = txt_TienNhan.Text;
            textSize = e.Graphics.MeasureString(text, subTitleFont);
            e.Graphics.DrawString("Tiền Khách Trả: ", normalFont, brush, new PointF(450, yPosition + 80));
            e.Graphics.DrawString(text, subTitleFont, brush, new PointF(e.PageBounds.Width - textSize.Width - 50, yPosition + 80));

            text = txt_TienThua.Text;
            textSize = e.Graphics.MeasureString(text, subTitleFont);
            e.Graphics.DrawString("Tiền Thừa: ", normalFont, brush, new PointF(450, yPosition + 110));
            e.Graphics.DrawString(text, subTitleFont, brush, new PointF(e.PageBounds.Width - textSize.Width - 50, yPosition + 110));

            // Footer
            string titleFooter = "Cảm ơn quý khách đã sử dụng dịch vụ của nhà hàng chúng tôi!";
            SizeF titleSizeFooter = e.Graphics.MeasureString(titleFooter, subTitleFont);

            e.Graphics.DrawLine(pen, xStart, yPosition + 150, xStart + width, yPosition + 150);
            e.Graphics.DrawString(titleFooter, subTitleFont, brush, new PointF(pageCenterX - (titleSizeFooter.Width / 2), yPosition + 170));
        }

        private void runPrintBill()
        {
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDocument1;

            previewDialog.Width = 800;
            previewDialog.Height = 600;

            ((Form)previewDialog).Controls.OfType<PrintPreviewControl>().First().Zoom = 0.9;

            if (btn_inHoaDon.Enabled)
                btn_inHoaDon.Enabled = false;
            previewDialog.ShowDialog();
        }

        private void btn_inHoaDon_Click(object sender, EventArgs e)
        {
             runPrintBill();
        }
    }
}
