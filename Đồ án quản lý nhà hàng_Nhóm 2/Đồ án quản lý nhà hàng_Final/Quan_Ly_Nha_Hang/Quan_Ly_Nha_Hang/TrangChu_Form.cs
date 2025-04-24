using Guna.UI2.WinForms;
using Quan_Ly_Nha_Hang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_Ly_Nha_Hang.Data;
using System.Security.Cryptography;
using System.Data.Entity;
using System.ComponentModel.Design;

namespace Quan_Ly_Nha_Hang
{
    public partial class TrangChu_Form : Form
    {
        public static Dictionary<int, List<KeyValuePair<MON, int>>> monAnCuaBan =
        new Dictionary<int, List<KeyValuePair<MON, int>>>();
        public static Dictionary<int, HOADON> dsbanvahoadon = new Dictionary<int, HOADON>();
        public static Dictionary<int, KHACHHANG> dsbanvakhach = new Dictionary<int, KHACHHANG>();

        public delegate void CapNhatTrangThaiBanDelegate();
        public CapNhatTrangThaiBanDelegate CapNhatUIBan;
        int timeCheckCount = 5;
        public TrangChu_Form()
        {
            InitializeComponent();
            LoadBan();
            CapNhatUIBan = new CapNhatTrangThaiBanDelegate(LoadBan);
        }
        private void LoadBan()
        {
            foreach (Guna2GradientButton btn in Ban_panel.Controls.OfType<Guna2GradientButton>())
            {

                int id_ban = int.Parse(btn.Name.Substring(7));
                var ban = Main_Form.data.BAN.FirstOrDefault(b => b.IDBan == id_ban);
                if (ban != null)
                {
                    btn.Text = ban.TenBan;
                    switch (ban.TrangThai)
                    {
                        case "Bàn trống":
                            btn.FillColor = Color.FromArgb(96, 139, 193);
                            btn.FillColor2 = Color.FromArgb(50, 72, 140);
                            break;
                        case "Bàn đang ăn":
                            btn.FillColor2 = Color.Maroon;
                            btn.FillColor = Color.FromArgb(255, 128, 128);
                            break;
                        case "Bàn đã đặt trong ngày":
                            btn.FillColor = Color.FromArgb(245, 199, 250);
                            btn.FillColor2 = Color.FromArgb(208, 148, 241);
                            break;
                        case "Đã đặt trong 3 tiếng":
                            btn.FillColor = Color.FromArgb(237, 201, 105);
                            btn.FillColor2 = Color.FromArgb(222, 162, 48);
                            break;
                        default:
                            btn.FillColor = Color.Gray;
                            btn.FillColor2 = Color.Gray;
                            break;
                    }
                }
            }
        }
        private void DieuKienMoBan(int idBan, EventArgs e)
        {
            MouseEventArgs mouseEventArgs = e as MouseEventArgs;
            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                var banDuocChon = Main_Form.data.BAN.Where(b => b.IDBan == idBan).FirstOrDefault();
                if (banDuocChon.TrangThai == "Bàn trống")
                {
                    Work.OpenFormChild(new MoBan_Form(banDuocChon), Function_Table_Panel);
                }
                else if (banDuocChon.TrangThai == "Bàn đang ăn")
                {
                    Work.OpenFormChild(new Order_Form(banDuocChon, dsbanvahoadon[banDuocChon.IDBan], dsbanvakhach[banDuocChon.IDBan]), Function_Table_Panel);
                }
                else// if(banDuocChon.TrangThai =="Bàn đã đặt trong ngày" ||banDuocChon.TrangThai=="Đã đặt trong 3 tiếng")
                {
                    Work.OpenFormChild(new MoBan_Form(banDuocChon), Function_Table_Panel);
                } 
            }

        }
        private void TrangChu_Form_Load(object sender, EventArgs e)
        {
            LoadBan();
        }
        private void btn_Ban1_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(1, e);
        }
        private void btn_Ban2_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(2, e);
        }

        private void btn_Ban3_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(3, e);
        }

        private void btn_Ban4_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(4, e);
        }

        private void btn_Ban5_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(5, e);
        }

        private void btn_Ban6_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(6, e);
        }

        private void btn_Ban7_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(7, e);
        }

        private void btn_Ban8_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(8, e);
        }

        private void btn_Ban9_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(9, e);
        }

        private void btn_Ban10_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(10, e);
        }

        private void btn_Ban11_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(11, e);
        }

        private void btn_Ban12_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(12, e);
        }

        private void btn_Ban13_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(13, e);
        }

        private void btn_Ban14_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(14, e);
        }

        private void btn_Ban15_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(15, e);
        }

        private void btn_Ban16_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(16, e);
        }

        private void btn_Ban17_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(17, e);
        }

        private void btn_Ban18_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(18, e);
        }

        private void btn_Ban19_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(19, e);
        }

        private void btn_Ban20_Click(object sender, EventArgs e)
        {
            DieuKienMoBan(20, e);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeCheckCount == 0)
            {
                timeCheckCount = 5;
                Main_Form.data = new QL_NHAHANGEntities();
                Main_Form.data.SP_UpdateStatementTable();
                LoadBan();
            }
            else
            {
                timeCheckCount--;
            }
            time.Text = DateTime.Now.ToString("HH:mm:ss") + "\n" + DateTime.Now.ToString("dd/MM/yyyy");
        }

      
        private void ThongTinDatBan(object sender)
        {
            using (var context = new QL_NHAHANGEntities()) 
            {
                var gunaButton = (Guna.UI2.WinForms.Guna2GradientButton)sender;
                int banId = int.Parse(gunaButton.Name.Replace("btn_Ban", ""));

                var danhSachDatBan = (from ct in context.CHITIETDB
                                      join db in context.DATBAN on ct.IDDatBan equals db.IDDatBan
                                      join kh in context.KHACHHANG on db.IDKhachHang equals kh.IDKhachHang
                                      where ct.IDBan == banId
                                      && DbFunctions.TruncateTime(db.NgayDB) == DbFunctions.TruncateTime(DateTime.Now)
                                      orderby db.GioBD // Sắp xếp theo thời gian
                                      select new
                                      {
                                          TenKhachHang = kh.HotenKH,
                                          SDT = kh.SDT,
                                          GioDat = db.GioBD,
                                          YeuCau = ct.YeuCauDB
                                      }).ToList(); // Sử dụng ToList() thay vì FirstOrDefault()

                if (danhSachDatBan.Any())
                {
                    StringBuilder messageBuilder = new StringBuilder();
                    messageBuilder.AppendLine($"Thông tin đặt bàn {banId} trong ngày:");
                    messageBuilder.AppendLine("----------------------------------------");

                    foreach (var datBan in danhSachDatBan)
                    {
                        TimeSpan giodat = datBan.GioDat;
                        messageBuilder.AppendLine($"Thời gian: {giodat.Hours:D2}:{giodat.Minutes:D2}");
                        messageBuilder.AppendLine($"Khách hàng: {datBan.TenKhachHang}");
                        messageBuilder.AppendLine($"Số điện thoại: {datBan.SDT}");
                        if (!string.IsNullOrWhiteSpace(datBan.YeuCau))
                        {
                            messageBuilder.AppendLine($"Yêu cầu: {datBan.YeuCau}");
                        }
                        messageBuilder.AppendLine("----------------------------------------");
                    }

                    MessageBox.Show(messageBuilder.ToString(),
                                  $"Danh sách đặt bàn {banId}",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Không có thông tin đặt bàn {banId} cho ngày hôm nay!",
                                  "Thông báo",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
        }

        private void btn_Ban1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }
        }

        private void btn_Ban2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }
        }

        private void btn_Ban3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }
        }
        private void btn_Ban4_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }

        }
        private void btn_Ban5_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }
        }

        private void btn_Ban6_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }
        }

        private void btn_Ban7_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }
        }

        private void btn_Ban8_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }
        }

        private void btn_Ban9_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }
        }

        private void btn_Ban10_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }
        }

        private void btn_Ban11_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }
        }

        private void btn_Ban12_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }
        }

        private void btn_Ban13_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }
        }

        private void btn_Ban14_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }
        }

        private void btn_Ban15_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }
        }

        private void btn_Ban16_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }
        }

        private void btn_Ban17_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }
        }

        private void btn_Ban18_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }
        }

        private void btn_Ban19_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }
        }

        private void btn_Ban20_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ThongTinDatBan(sender);
            }
        }
    }
}
