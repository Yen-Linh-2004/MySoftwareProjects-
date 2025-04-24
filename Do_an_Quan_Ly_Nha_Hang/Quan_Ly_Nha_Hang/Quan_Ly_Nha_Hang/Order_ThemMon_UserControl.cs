using Quan_Ly_Nha_Hang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Nha_Hang
{
    public partial class Order_ThemMon_UserControl : UserControl
    {
        public static List<MON> DanhSachThem = new List<MON>();
        private BAN Ban;
        private HOADON HoaDon;
        public Order_ThemMon_UserControl(BAN bAN, HOADON hOADON)
        {
            InitializeComponent();
            LoadMonAn();
            this.Ban = bAN;
            this.HoaDon = hOADON;
        }
        private void Order_ThemMon_UserControl_Load(object sender, EventArgs e)
        {
            flp_MonAn.AutoScroll = true;
        }

        private void btn_ThemMon_Click(object sender, EventArgs e)
        {
            try
            {
                if (DanhSachThem.Count > 0)
                {

                    var groupedMons = DanhSachThem
                        .GroupBy(m => m.IDMon)
                        .Select(g => new KeyValuePair<MON, int>(g.First(), g.Count()))
                        .ToList();
                    var danhSachMonFormatted = groupedMons
                        .Select(g => $"{g.Key.TenMon} x{g.Value}")
                        .ToList();
                    string message = string.Join("\n", danhSachMonFormatted);
                    MessageBox.Show($"Danh sách món đã thêm:\n{message}");
                    if (!TrangChu_Form.monAnCuaBan.ContainsKey(Ban.IDBan))
                    {
                        TrangChu_Form.monAnCuaBan[Ban.IDBan] = new List<KeyValuePair<MON, int>>();
                    }
                    foreach (var item in groupedMons)
                    {

                        var existingMon = TrangChu_Form.monAnCuaBan[Ban.IDBan]
                            .FirstOrDefault(m => m.Key.IDMon == item.Key.IDMon);

                        if (existingMon.Key != null)
                        {
                            var index = TrangChu_Form.monAnCuaBan[Ban.IDBan]
                                .IndexOf(existingMon);
                            TrangChu_Form.monAnCuaBan[Ban.IDBan][index] =
                                new KeyValuePair<MON, int>(existingMon.Key, existingMon.Value + item.Value);

                            var chiTietHD = Main_Form.data.CHITIETHD
                        .FirstOrDefault(ct => ct.IDMon == item.Key.IDMon && ct.IDBan == Ban.IDBan && ct.IDHoaDon == HoaDon.IDHoaDon);
                            if (chiTietHD != null)
                            {
                                chiTietHD.SoLuong += item.Value;
                            }
                            Main_Form.data.SaveChanges();
                        }
                        else
                        {
                            var mon = Main_Form.data.MON.FirstOrDefault(m => m.IDMon == item.Key.IDMon);
                            TrangChu_Form.monAnCuaBan[Ban.IDBan].Add(item);
                            var chiTietHD = new CHITIETHD
                            {
                                IDHoaDon = HoaDon.IDHoaDon,
                                IDMon = item.Key.IDMon,
                                IDBan = Ban.IDBan,
                                SoLuong = item.Value,
                                DonGia = mon.DonGia,
                            };
                            Main_Form.data.CHITIETHD.Add(chiTietHD);
                            Main_Form.data.SaveChanges();
                        }
                    }
                    Main_Form.data.SaveChanges();
                    Reset_BangMonAn();
                    Main_Form.data = new QL_NHAHANGEntities();
                    flp_MonAn.Controls.Clear();
                    LoadMonAn();
                }
                else
                {
                    MessageBox.Show("Chưa có món nào được thêm!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm món: {ex.Message}");
            }

            var mainControl = this.Parent.Controls.OfType<Order_Main_UserControl>().FirstOrDefault();
            if (mainControl != null)
            {
                mainControl.LoadMonAnDaDat();
                mainControl.TinhTongTien();
            }
        }
        private void LoadMonAn()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string imageFolder = Path.Combine(baseDirectory, @"..\..\QLNHimg\");
            var listmon = new List<MonAn_ForOrder_UserControler>();
            foreach (MON mon in Main_Form.data.MON.ToList())
            {
                MonAn_ForOrder_UserControler monAn_ForOrder = new MonAn_ForOrder_UserControler();
                monAn_ForOrder.MaMon = mon.IDMon;
                monAn_ForOrder.TenMon = mon.TenMon;
                monAn_ForOrder.GiaMon = mon.DonGia.ToString();
                try
                {
                    CHITIETMON ctm = Main_Form.data.CHITIETMON.FirstOrDefault(t => t.IDMon == mon.IDMon);
                    if (ctm != null)
                    {
                        var nguyenLieu = Main_Form.data.NGUYENLIEU.FirstOrDefault(t => t.IDNguyenLieu == ctm.IDNguyenLieu);
                        if (nguyenLieu != null)
                        {
                            if (ctm.Soluong <= 0)
                            {
                                monAn_ForOrder.SoLuongCon = "0";
                                return;
                            }

                            // Tính số lượng món có thể làm được và làm tròn xuống
                            int sl = (int)(nguyenLieu.SolgTon / ctm.Soluong);
                            monAn_ForOrder.SoLuongCon = sl.ToString();
                        }
                        else
                        {
                            monAn_ForOrder.SoLuongCon = "0";
                        }
                    }
                    else
                    {
                        monAn_ForOrder.SoLuongCon = "0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi tính số lượng: " + ex.Message);
                    monAn_ForOrder.SoLuongCon = "0";
                }
                try
                {
                    string imagePath = Path.GetFullPath(Path.Combine(imageFolder, mon.HinhAnh));
                    monAn_ForOrder.AnhMon = System.Drawing.Image.FromFile(imagePath);
                }
                catch (Exception)
                {
                    // Nếu không tìm thấy ảnh của món ăn, sử dụng ảnh mặc định
                    string defaultImagePath = Path.GetFullPath(Path.Combine(imageFolder, "Gà nướng.jpg"));
                    monAn_ForOrder.AnhMon = System.Drawing.Image.FromFile(defaultImagePath);
                }
                listmon.Add(monAn_ForOrder);
            }
            flp_MonAn.Controls.AddRange(listmon.ToArray());
        }
        private void Reset_BangMonAn()
        {
            foreach (Control control in flp_MonAn.Controls)
            {
                if (control is MonAn_ForOrder_UserControler userControler)
                {
                    userControler.SoLuong = "0";
                }
            }
            DanhSachThem.Clear();
        }
        private void btn_Reset_MonAn_Click(object sender, EventArgs e)
        {
            Reset_BangMonAn();
        }
        public void HienThiDanhSachMon()
        {
            var danhSach = DanhSachThem
                .GroupBy(m => m.TenMon)
                .Select(g => $"{g.Key}: {g.Count()}")
                .ToList();

            if (danhSach.Any())
            {
                MessageBox.Show(string.Join("\n", danhSach), "Danh sách món hiện tại");
            }
            else
            {
                MessageBox.Show("Chưa có món nào được chọn");
            }
        }

        private void txt_TimKiemMon_TextChanged(object sender, EventArgs e)
        {
            flp_MonAn.Controls.Clear();
            string tuKhoa = txt_TimKiemMon.Text.ToLower();

            var ketQua = Main_Form.data.MON.Where(mon =>
                mon.TenMon.ToLower().Contains(tuKhoa)
            ).ToList();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string imageFolder = Path.Combine(baseDirectory, @"..\..\QLNHimg\");
            var listmon = new List<MonAn_ForOrder_UserControler>();
            foreach (MON mon in ketQua)
            {
                MonAn_ForOrder_UserControler monAn_ForOrder = new MonAn_ForOrder_UserControler();
                monAn_ForOrder.MaMon = mon.IDMon;
                monAn_ForOrder.TenMon = mon.TenMon;
                monAn_ForOrder.GiaMon = mon.DonGia.ToString();
                try
                {
                    CHITIETMON ctm = Main_Form.data.CHITIETMON.FirstOrDefault(t => t.IDMon == mon.IDMon);
                    if (ctm != null)
                    {
                        var nguyenLieu = Main_Form.data.NGUYENLIEU.FirstOrDefault(t => t.IDNguyenLieu == ctm.IDNguyenLieu);
                        if (nguyenLieu != null)
                        {
                            if (ctm.Soluong <= 0)
                            {
                                monAn_ForOrder.SoLuongCon = "0";
                                return;
                            }

                            // Tính số lượng món có thể làm được và làm tròn xuống
                            int sl = (int)(nguyenLieu.SolgTon / ctm.Soluong);
                            monAn_ForOrder.SoLuongCon = sl.ToString();
                        }
                        else
                        {
                            monAn_ForOrder.SoLuongCon = "0";
                        }
                    }
                    else
                    {
                        monAn_ForOrder.SoLuongCon = "0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi tính số lượng: " + ex.Message);
                    monAn_ForOrder.SoLuongCon = "0";
                }
                try
                {
                    string imagePath = Path.GetFullPath(Path.Combine(imageFolder, mon.HinhAnh));
                    monAn_ForOrder.AnhMon = System.Drawing.Image.FromFile(imagePath);
                }
                catch (Exception)
                {
                    string defaultImagePath = Path.GetFullPath(Path.Combine(imageFolder, "Gà nướng.jpg"));
                    monAn_ForOrder.AnhMon = System.Drawing.Image.FromFile(defaultImagePath);
                }
                listmon.Add(monAn_ForOrder);
            }
                flp_MonAn.Controls.AddRange(listmon.ToArray());
        }
    }
}
