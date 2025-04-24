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
using OfficeOpenXml;
using OfficeOpenXml.ConditionalFormatting.Contracts;

namespace Quan_Ly_Nha_Hang
{

    public partial class XepLich_Form : Form
    {
        public XepLich_Form()
        {
            InitializeComponent();
            LoadNhanVienvaCa();
        }

        private void LoadNhanVienvaCa()
        {
            cbb_Ban1_2.DataSource = Main_Form.data.NHANVIEN.Where(nv => nv.IdChucVu == 2).ToList();
            cbb_Ban3_4.DataSource = Main_Form.data.NHANVIEN.Where(nv => nv.IdChucVu == 2).ToList();
            cbb_Ban5_6.DataSource = Main_Form.data.NHANVIEN.Where(nv => nv.IdChucVu == 2).ToList();
            cbb_Ban7_8.DataSource = Main_Form.data.NHANVIEN.Where(nv => nv.IdChucVu == 2).ToList();
            cbb_Ban9_10.DataSource = Main_Form.data.NHANVIEN.Where(nv => nv.IdChucVu == 2).ToList();
            cbb_Ban11_12.DataSource = Main_Form.data.NHANVIEN.Where(nv => nv.IdChucVu == 2).ToList();
            cbb_Ban13_14.DataSource = Main_Form.data.NHANVIEN.Where(nv => nv.IdChucVu == 2).ToList();
            cbb_Ban15_16.DataSource = Main_Form.data.NHANVIEN.Where(nv => nv.IdChucVu == 2).ToList();
            cbb_Ban17_18.DataSource = Main_Form.data.NHANVIEN.Where(nv => nv.IdChucVu == 2).ToList();
            cbb_Ban19_20.DataSource = Main_Form.data.NHANVIEN.Where(nv => nv.IdChucVu == 2).ToList();

            cbb_Ban1_2.ValueMember = "IDNhanVien";
            cbb_Ban3_4.ValueMember = "IDNhanVien";
            cbb_Ban5_6.ValueMember = "IDNhanVien";
            cbb_Ban7_8.ValueMember = "IDNhanVien";
            cbb_Ban9_10.ValueMember = "IDNhanVien";
            cbb_Ban11_12.ValueMember = "IDNhanVien";
            cbb_Ban13_14.ValueMember = "IDNhanVien";
            cbb_Ban15_16.ValueMember = "IDNhanVien";
            cbb_Ban17_18.ValueMember = "IDNhanVien";
            cbb_Ban19_20.ValueMember = "IDNhanVien";

            cbb_Ban1_2.DisplayMember = "HoTenNV";
            cbb_Ban3_4.DisplayMember = "HoTenNV";
            cbb_Ban5_6.DisplayMember = "HoTenNV";
            cbb_Ban7_8.DisplayMember = "HoTenNV";
            cbb_Ban9_10.DisplayMember = "HoTenNV";
            cbb_Ban11_12.DisplayMember = "HoTenNV";
            cbb_Ban13_14.DisplayMember = "HoTenNV";
            cbb_Ban15_16.DisplayMember = "HoTenNV";
            cbb_Ban17_18.DisplayMember = "HoTenNV";
            cbb_Ban19_20.DisplayMember = "HoTenNV";

            cbb_Ban1_2.SelectedIndex = -1;
            cbb_Ban3_4.SelectedIndex = -1;
            cbb_Ban5_6.SelectedIndex = -1;
            cbb_Ban7_8.SelectedIndex = -1;
            cbb_Ban9_10.SelectedIndex = -1;
            cbb_Ban11_12.SelectedIndex = -1;
            cbb_Ban13_14.SelectedIndex = -1;
            cbb_Ban15_16.SelectedIndex = -1;
            cbb_Ban17_18.SelectedIndex = -1;
            cbb_Ban19_20.SelectedIndex = -1;

            cbb_CaLam.DataSource = Main_Form.data.CALAMVIEC.ToList();
            cbb_CaLam.DisplayMember = "TenCaLam";
            cbb_CaLam.ValueMember = "IDCaLamViec";
            cbb_CaLam.SelectedIndex = -1;
        }
        private void LuuLichLam()
        {
            try
            {
                if (!string.IsNullOrEmpty(cbb_Ban1_2.Text))
                {
                    for (int i = 1; i < 3; i++)
                    {
                        PHANCONG pc = new PHANCONG();
                        pc.IDNhanVien = (int)cbb_Ban1_2.SelectedValue;
                        pc.IDCaLamViec = (int)cbb_CaLam.SelectedValue;
                        pc.IDBan = i;
                        pc.NgayLV = ThoiGian.Value;
                        pc.PhuTrachCV = "Phu trach ban " + i;
                        Main_Form.data.PHANCONG.Add(pc);
                        Main_Form.data.SaveChanges();
                    }
                }
                if (!string.IsNullOrEmpty(cbb_Ban3_4.Text))
                {
                    for (int i = 3; i < 5; i++)
                    {
                        PHANCONG pc = new PHANCONG();
                        pc.IDNhanVien = (int)cbb_Ban3_4.SelectedValue;
                        pc.IDCaLamViec = (int)cbb_CaLam.SelectedValue;
                        pc.IDBan = i;
                        pc.NgayLV = ThoiGian.Value;
                        pc.PhuTrachCV = "Phu trach ban " + i;
                        Main_Form.data.PHANCONG.Add(pc);
                        Main_Form.data.SaveChanges();
                    }
                }
                if (!string.IsNullOrEmpty(cbb_Ban5_6.Text))
                {
                    for (int i = 5; i < 7; i++)
                    {
                        PHANCONG pc = new PHANCONG();
                        pc.IDNhanVien = (int)cbb_Ban5_6.SelectedValue;
                        pc.IDCaLamViec = (int)cbb_CaLam.SelectedValue;
                        pc.IDBan = i;
                        pc.NgayLV = ThoiGian.Value;
                        pc.PhuTrachCV = "Phu trach ban " + i;
                        Main_Form.data.PHANCONG.Add(pc);
                        Main_Form.data.SaveChanges();
                    }
                }
                if (!string.IsNullOrEmpty(cbb_Ban7_8.Text))
                {
                    for (int i = 7; i < 9; i++)
                    {
                        PHANCONG pc = new PHANCONG();
                        pc.IDNhanVien = (int)cbb_Ban7_8.SelectedValue;
                        pc.IDCaLamViec = (int)cbb_CaLam.SelectedValue;
                        pc.IDBan = i;
                        pc.NgayLV = ThoiGian.Value;
                        pc.PhuTrachCV = "Phu trach ban " + i;
                        Main_Form.data.PHANCONG.Add(pc);
                        Main_Form.data.SaveChanges();
                    }
                }
                if (!string.IsNullOrEmpty(cbb_Ban9_10.Text))
                {
                    for (int i = 9; i < 11; i++)
                    {
                        PHANCONG pc = new PHANCONG();
                        pc.IDNhanVien = (int)cbb_Ban9_10.SelectedValue;
                        pc.IDCaLamViec = (int)cbb_CaLam.SelectedValue;
                        pc.IDBan = i;
                        pc.NgayLV = ThoiGian.Value;
                        pc.PhuTrachCV = "Phu trach ban " + i;
                        Main_Form.data.PHANCONG.Add(pc);
                        Main_Form.data.SaveChanges();
                    }
                }
                if (!string.IsNullOrEmpty(cbb_Ban11_12.Text))
                {
                    for (int i = 11; i < 13; i++)
                    {
                        PHANCONG pc = new PHANCONG();
                        pc.IDNhanVien = (int)cbb_Ban11_12.SelectedValue;
                        pc.IDCaLamViec = (int)cbb_CaLam.SelectedValue;
                        pc.IDBan = i;
                        pc.NgayLV = ThoiGian.Value;
                        pc.PhuTrachCV = "Phu trach ban " + i;
                        Main_Form.data.PHANCONG.Add(pc);
                        Main_Form.data.SaveChanges();
                    }
                }
                if (!string.IsNullOrEmpty(cbb_Ban13_14.Text))
                {
                    for (int i = 13; i < 15; i++)
                    {
                        PHANCONG pc = new PHANCONG();
                        pc.IDNhanVien = (int)cbb_Ban13_14.SelectedValue;
                        pc.IDCaLamViec = (int)cbb_CaLam.SelectedValue;
                        pc.IDBan = i;
                        pc.NgayLV = ThoiGian.Value;
                        pc.PhuTrachCV = "Phu trach ban " + i;
                        Main_Form.data.PHANCONG.Add(pc);
                        Main_Form.data.SaveChanges();
                    }
                }
                if (!string.IsNullOrEmpty(cbb_Ban15_16.Text))
                {
                    for (int i = 15; i < 17; i++)
                    {
                        PHANCONG pc = new PHANCONG();
                        pc.IDNhanVien = (int)cbb_Ban15_16.SelectedValue;
                        pc.IDCaLamViec = (int)cbb_CaLam.SelectedValue;
                        pc.IDBan = i;
                        pc.NgayLV = ThoiGian.Value;
                        pc.PhuTrachCV = "Phu trach ban " + i;
                        Main_Form.data.PHANCONG.Add(pc);
                        Main_Form.data.SaveChanges();
                    }
                }
                if (!string.IsNullOrEmpty(cbb_Ban17_18.Text))
                {
                    for (int i = 17; i < 19; i++)
                    {
                        PHANCONG pc = new PHANCONG();
                        pc.IDNhanVien = (int)cbb_Ban17_18.SelectedValue;
                        pc.IDCaLamViec = (int)cbb_CaLam.SelectedValue;
                        pc.IDBan = i;
                        pc.NgayLV = ThoiGian.Value;
                        pc.PhuTrachCV = "Phu trach ban " + i;
                        Main_Form.data.PHANCONG.Add(pc);
                        Main_Form.data.SaveChanges();
                    }
                }
                if (!string.IsNullOrEmpty(cbb_Ban19_20.Text))
                {
                    for (int i = 19; i < 21; i++)
                    {
                        PHANCONG pc = new PHANCONG();
                        pc.IDNhanVien = (int)cbb_Ban19_20.SelectedValue;
                        pc.IDCaLamViec = (int)cbb_CaLam.SelectedValue;
                        pc.IDBan = i;
                        pc.NgayLV = ThoiGian.Value;
                        pc.PhuTrachCV = "Phu trach ban " + i;
                        Main_Form.data.PHANCONG.Add(pc);
                        Main_Form.data.SaveChanges();
                    }
                }
                MessageBox.Show("Lưu ca làm thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {

                MessageBox.Show("Nhân viên, ca làm và ngày bị trùng nhau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbb_CaLam.Text))
            {
                LuuLichLam();
            }
            else
            {
                MessageBox.Show("Hãy chọn ca làm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void XuatLichLamViecTheoTuan(DateTime ngayDauTuan)
        {

            try
            {
                // Tính ngày cuối tuần
                DateTime ngayCuoiTuan = ngayDauTuan.AddDays(6);

                // Truy vấn dữ liệu lịch làm việc trong tuần
                var lichLamViec = Main_Form.data.PHANCONG
                    .Where(pc => pc.NgayLV >= ngayDauTuan && pc.NgayLV <= ngayCuoiTuan)
                    .Select(pc => new
                    {
                        TenNhanVien = pc.NHANVIEN.HotenNV,
                        CaLam = pc.CALAMVIEC.TenCaLam,
                        Ban = pc.BAN.TenBan,
                        NgayLamViec = pc.NgayLV,
                        NhiemVu = pc.PhuTrachCV
                    })
                    .OrderBy(x => x.NgayLamViec)
                    .ThenBy(x => x.TenNhanVien)
                    .ToList();

                // Kiểm tra có dữ liệu không
                if (!lichLamViec.Any())
                {
                    MessageBox.Show("Không có lịch làm việc cho tuần này!");
                    return;
                }

                // Xuất Excel
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Lịch Làm Việc Theo Tuần");

                    // Tiêu đề chung
                    worksheet.Cells[1, 1, 1, 6].Merge = true; // Gộp ô từ cột 1 đến cột 6
                    worksheet.Cells[1, 1].Value = $"Lịch Làm Việc Từ {ngayDauTuan:dd/MM/yyyy} Đến {ngayCuoiTuan:dd/MM/yyyy}";
                    worksheet.Cells[1, 1].Style.Font.Bold = true;
                    worksheet.Cells[1, 1].Style.Font.Size = 16;
                    worksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.Cells[1, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                    string[] headers = { "STT", "Tên Nhân Viên", "Ca Làm", "Bàn", "Ngày Làm Việc", "Nhiệm Vụ" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        var cell = worksheet.Cells[2, i + 1];
                        cell.Value = headers[i];
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        cell.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                        cell.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    }

                    for (int i = 0; i < lichLamViec.Count; i++)
                    {
                        var row = i + 3;
                        worksheet.Cells[row, 1].Value = i + 1;
                        worksheet.Cells[row, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        worksheet.Cells[row, 2].Value = lichLamViec[i].TenNhanVien;
                        worksheet.Cells[row, 3].Value = lichLamViec[i].CaLam;
                        worksheet.Cells[row, 3].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        worksheet.Cells[row, 4].Value = lichLamViec[i].Ban;
                        worksheet.Cells[row, 5].Value = lichLamViec[i].NgayLamViec.ToString("dd/MM/yyyy");
                        worksheet.Cells[row, 6].Value = lichLamViec[i].NhiemVu;

                        // Thêm border cho dòng
                        for (int col = 1; col <= headers.Length; col++)
                        {
                            worksheet.Cells[row, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }
                    }


                    worksheet.Column(1).Width = 8;
                    worksheet.Column(2).Width = 25;
                    worksheet.Column(3).Width = 12;
                    worksheet.Column(4).Width = 10;
                    worksheet.Column(5).Width = 15;
                    worksheet.Column(6).Width = 25;

                    // Lưu file
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx",
                        FileName = $"LichLamViecTuan_{ngayDauTuan:yyyy-MM-dd}.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo file = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(file);
                        MessageBox.Show("Xuất file Excel thành công!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void XuatFileLuong()
        {
            try
            {
                int thang = ThoiGian.Value.Month;
                int nam = ThoiGian.Value.Year;

                int soNgayLamViec = DateTime.DaysInMonth(nam, thang);
                if (thang == DateTime.Now.Month && nam == DateTime.Now.Year)
                {
                    soNgayLamViec = DateTime.Now.Day;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.FileName = $"BangLuong_{thang}_{nam}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var package = new ExcelPackage(new FileInfo(saveFileDialog.FileName)))
                    {
                        var worksheet = package.Workbook.Worksheets.Add("Bảng Lương");

                        var luongNhanVien = Main_Form.data.NHANVIEN
                            .Select(nv => new
                            {
                                nv.IDNhanVien,
                                nv.HotenNV,
                                TenChucVu = nv.CHUCVU.TenChucVu,
                                LuongCoBan = nv.LuongCoBan ?? 0,
                                // Với nhân viên phục vụ, lấy số giờ từ bảng phân công
                                SoGioLam = nv.CHUCVU.TenChucVu == "Nhân viên phục vụ" ?
                                    nv.PHANCONG
                                        .Where(pc => pc.NgayLV.Month == thang &&
                                                   pc.NgayLV.Year == nam && pc.NgayLV <= DateTime.Now)
                                        .Count() * 5 : // Mỗi ca 5 tiếng
                                    soNgayLamViec * 8, // Các chức vụ khác làm 8 tiếng/ngày
                                PhuCap = 0.0,
                                TongLuong = 0.0
                            })
                             .OrderBy(x => x.TenChucVu)
                            .ThenBy(x => x.HotenNV)
                            .ToList()
                            .Select(x =>
                            {

                                double tongLuong = 0.0;
                                double phucap = 0.0;
                                switch (x.TenChucVu)
                                {
                                    case "Nhân viên phục vụ":
                                        tongLuong = (double)(x.LuongCoBan * x.SoGioLam);
                                        if (x.SoGioLam > 0)
                                            phucap = 100000.0;
                                        break;
                                    case "Nhân viên thu ngân":
                                    case "Nhân viên quản lý":
                                    case "Nhân viên bếp":
                                        tongLuong = (double)(x.LuongCoBan * x.SoGioLam);
                                        break;
                                }
                                // Cộng thêm phụ cấp
                                tongLuong += phucap;
                                return new
                                {
                                    x.IDNhanVien,
                                    x.HotenNV,
                                    x.TenChucVu,
                                    x.LuongCoBan,
                                    x.SoGioLam,
                                    PhuCap = phucap,
                                    TongLuong = tongLuong
                                };
                            })
                            .ToList();

                        worksheet.Cells[1, 1, 1, 7].Merge = true; 
                        worksheet.Cells[1, 1].Value = $"Bảng lương tháng {thang}/{nam}  ({ThoiGian.Value:dd/MM/yyyy})";
                        worksheet.Cells[1, 1].Style.Font.Bold = true;
                        worksheet.Cells[1, 1].Style.Font.Size = 16;
                        worksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        worksheet.Cells[1, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Green);
                        // Headers
                        worksheet.Cells[2, 1].Value = "Mã NV";
                        worksheet.Cells[2, 2].Value = "Họ Tên";
                        worksheet.Cells[2, 3].Value = "Chức Vụ";
                        worksheet.Cells[2, 4].Value = "Lương Cơ Bản";
                        worksheet.Cells[2, 5].Value = "Số Giờ Làm";
                        worksheet.Cells[2, 6].Value = "Phụ Cấp";
                        worksheet.Cells[2, 7].Value = "Tổng Lương";

                        // Ghi dữ liệu
                        for (int i = 0; i < luongNhanVien.Count; i++)
                        {
                            worksheet.Cells[i + 3, 1].Value = luongNhanVien[i].IDNhanVien;
                            worksheet.Cells[i + 3, 2].Value = luongNhanVien[i].HotenNV;
                            worksheet.Cells[i + 3, 3].Value = luongNhanVien[i].TenChucVu;

                            worksheet.Cells[i + 3, 4].Value = luongNhanVien[i].LuongCoBan;
                            worksheet.Cells[i + 3, 4].Style.Numberformat.Format = "#,##0₫";

                            worksheet.Cells[i + 3, 5].Value = luongNhanVien[i].SoGioLam;
                            worksheet.Cells[i + 3, 6].Value = luongNhanVien[i].PhuCap;

                            worksheet.Cells[i + 3, 7].Value = luongNhanVien[i].TongLuong;
                            worksheet.Cells[i + 3, 7].Style.Numberformat.Format = "#,##0₫";


                        }

                        worksheet.Cells.AutoFitColumns();
                        package.Save();

                        MessageBox.Show("Xuất file lương thành công!", "Thông Báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_inlichlam_Click(object sender, EventArgs e)
        {
            DateTime ngayDauTuan = ThoiGian.Value.Date;
            while (ngayDauTuan.DayOfWeek != DayOfWeek.Monday)
            {
                ngayDauTuan = ngayDauTuan.AddDays(-1);
            }

            XuatLichLamViecTheoTuan(ngayDauTuan);
        }

        private void btn_tinhluong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn tính lương vào thời điểm hiện tại?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                XuatFileLuong();
            }
        }
    }
}
