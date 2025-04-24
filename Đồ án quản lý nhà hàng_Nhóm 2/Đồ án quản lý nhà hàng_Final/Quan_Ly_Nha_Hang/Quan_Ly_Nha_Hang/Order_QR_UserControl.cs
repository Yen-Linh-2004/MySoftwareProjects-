using Newtonsoft.Json;
using Quan_Ly_Nha_Hang.Data;
using RestSharp;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Nha_Hang
{
    public partial class Order_QR_UserControl : UserControl
    {
        private int countDown = 90;
        private double soTien;
        KHUYENMAI KhuyenMai;
        HOADON HoaDon;
        BAN Ban;
        private TrangChu_Form.CapNhatTrangThaiBanDelegate CapNhatUI;
        List<KeyValuePair<MON, int>> value;

        public Order_QR_UserControl(double soTien,KHUYENMAI kHUYENMAI,HOADON hoadon,BAN ban)
        {
            InitializeComponent();
            this.soTien = soTien;
            this.KhuyenMai = kHUYENMAI;
            this.HoaDon = hoadon;
            this.Ban = ban;
            txt_QR_TongTien.Text = soTien.ToString("#,##0") + " VNĐ"; ;
            var trangChuForm = Application.OpenForms.OfType<TrangChu_Form>().FirstOrDefault();
            if (trangChuForm != null)
            {
                this.CapNhatUI = trangChuForm.CapNhatUIBan;
            }
            this.btn_inHoaDon.Visible = false;
            this.txt_ThongBaoTinNhan.Visible = false;
            value = TrangChu_Form.monAnCuaBan[Ban.IDBan].ToList();
        }
        private void Order_QR_UserControl_Load(object sender, EventArgs e)
        {
            setUpBank(soTien);
        }
        void setUpBank(double soTien)
        {
            Bank bank = new Bank();
            APIRequest APIrequest = new APIRequest();
            APIrequest.acqId = Convert.ToInt32(bank.data.bin);
            APIrequest.accountNo = 00941544797;
            APIrequest.accountName = "NHA HANG NHOM ";
            APIrequest.amount = (int)soTien;
            APIrequest.format = "text";
            APIrequest.template = "print";
            var json = JsonConvert.SerializeObject(APIrequest);

            var client = new RestClient("https://api.vietqr.io/v2/generate");
            var request = new RestRequest();

            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content; // raw content as string  
            var dataResult = JsonConvert.DeserializeObject<APIResponse>(content);

            var image = Base64ToImage(dataResult.data.qrDataURL);
            pictureBox_QRCode.Image = image;
        }

        public Image Base64ToImage(string base64String)
        {
            // Remove the prefix if it exists
            if (base64String.Contains(","))
            {
                base64String = base64String.Split(',')[1];
            }

            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }
        private void KetQuaThanhToan()
        {
            var hoadon = Main_Form.data.HOADON.FirstOrDefault(t => t.IDHoaDon == HoaDon.IDHoaDon);
            hoadon.PhuongThucTT = "Chuyển khoản";
            hoadon.NgayThanhToan = DateTime.Now;
            if (KhuyenMai.IDKhuyenMai > 0)
                hoadon.IDKhuyenMai = KhuyenMai.IDKhuyenMai;
            hoadon.ThanhTien = soTien;
            hoadon.TrangThaiTT = "Đã thanh toán";
            Main_Form.data.SaveChanges();
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
            this.btn_inHoaDon.Enabled = true;
            this.btn_inHoaDon.Visible = true;
            this.btn_The_ThanhToan.Enabled = false;
        }
        private void btn_The_ThanhToan_Click(object sender, EventArgs e)
        {
            KetQuaThanhToan();
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
            string text = soTien.ToString("#,##0") + " VNĐ";
            SizeF textSize = e.Graphics.MeasureString(text, subTitleFont);

            e.Graphics.DrawString("Tổng Tiền: ", normalFont, brush, new PointF(450, yPosition + 50));
            e.Graphics.DrawString(text, subTitleFont, brush, new PointF(e.PageBounds.Width - textSize.Width - 50, yPosition + 50));

            text = soTien.ToString("#,##0") + " VNĐ";
            textSize = e.Graphics.MeasureString(text, subTitleFont);
            e.Graphics.DrawString("Tiền Khách Trả: ", normalFont, brush, new PointF(450, yPosition + 80));
            e.Graphics.DrawString(text, subTitleFont, brush, new PointF(e.PageBounds.Width - textSize.Width - 50, yPosition + 80));

            text = "0 VNĐ";
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

        private void btn_inHoaDon_Click_1(object sender, EventArgs e)
        {
            btn_The_ThanhToan.Enabled = false;
            btn_inHoaDon.Enabled = false;
            runPrintBill();
        }
    }
}
