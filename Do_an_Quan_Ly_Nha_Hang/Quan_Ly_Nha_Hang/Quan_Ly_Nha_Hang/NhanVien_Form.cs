using Newtonsoft.Json.Linq;
using Quan_Ly_Nha_Hang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Nha_Hang
{
    public partial class NhanVien_Form : Form
    {
        private bool DangThem = false;
        private bool DangSua = false;
        private int? IdNhanVienDangChon = null;
        public NhanVien_Form()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadNhanVien();
            LoadChucVu();
            ThietLapTrangThai();
        }
        private void SetControlState(bool enabled)
        {
            txt_Hoten.Enabled = enabled;
            txt_DiaChi.Enabled = enabled;
            txt_Email.Enabled = enabled;
            txt_NgaySinh.Enabled = enabled;
            txt_Sdt.Enabled = enabled;
            txt_Luong.Enabled = enabled;
            txt_GioiTinh.Enabled = enabled;
            txt_NgayVL.Enabled = enabled;
            txt_ChucVu.Enabled = enabled;
        }
        private bool EmailHopLe(string email)
        { 
            int atIndex = email.IndexOf('@');
            int dotIndex = email.LastIndexOf('.');
            return atIndex > 0
                && dotIndex > atIndex + 1
                && dotIndex < email.Length - 1;
        }
        public void ThietLapTrangThai()
        {
            SetControlState(false);

            btn_Them.Enabled = true;
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_Luu.Enabled = false;
            btn_Huy.Visible = false;
        }
        private void ClearInput()
        {
            txt_Hoten.Clear();
            txt_DiaChi.Clear();
            txt_Email.Clear();
            txt_Sdt.Clear();
            txt_Luong.Clear();
            txt_GioiTinh.SelectedIndex = -1;
            txt_NgayVL.Clear();
            txt_ChucVu.SelectedIndex = -1;
        }
        private void LoadNhanVien()
        {
            dataGridView1.DataSource = Main_Form.data.NHANVIEN.Select(t => new
            {
                t.IDNhanVien,
                t.HotenNV,
                t.NgaySinh,
                t.SDT,
                t.DiaChi,
                t.Email,
                t.NgayVL,
                t.LuongCoBan,
                t.GioiTinh,
                TenChucVu = t.CHUCVU.TenChucVu
            }).ToList();
        }
        private void LoadChucVu()
        {
           
            foreach (CHUCVU cv in Main_Form.data.CHUCVU.ToList())
            {
                txt_ChucVu.Items.Add(cv);
                cbb_ChucVu.Items.Add(cv);
            }
            txt_ChucVu.DisplayMember = cbb_ChucVu.DisplayMember = "TenChucVu";
            txt_ChucVu.ValueMember = cbb_ChucVu.ValueMember = "IDChucVu";
        }
        private void SetupDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("IDNhanVien", "ID");
            dataGridView1.Columns.Add("HotenNV", "Họ tên");
            dataGridView1.Columns.Add("NgaySinh", "Ngày sinh");
            dataGridView1.Columns.Add("SDT", "Số điện thoại");
            dataGridView1.Columns.Add("DiaChi", "Địa chỉ");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("NgayVL", "Ngày vào làm");
            dataGridView1.Columns.Add("LuongCoBan", "Lương cơ bản");
            dataGridView1.Columns.Add("GioiTinh", "Giới tính");
            dataGridView1.Columns.Add("TenChucVu", "Chức vụ");

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DataPropertyName = col.Name;
                if (col.Name == "IDNhanVien")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                else if (col.Name == "TenChucVu")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(!DangThem)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    IdNhanVienDangChon = Convert.ToInt32(row.Cells["IDNhanVien"].Value);
                    txt_Hoten.Text = dataGridView1.Rows[e.RowIndex].Cells["HoTenNV"].Value?.ToString();
                    txt_Sdt.Text = dataGridView1.Rows[e.RowIndex].Cells["SDT"].Value?.ToString();
                    txt_NgaySinh.Text = dataGridView1.Rows[e.RowIndex].Cells["NgaySinh"].Value?.ToString();
                    txt_DiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells["DiaChi"].Value?.ToString();
                    txt_Email.Text = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value?.ToString();
                    txt_Luong.Text = dataGridView1.Rows[e.RowIndex].Cells["LuongCoBan"].Value?.ToString();
                    txt_NgayVL.Text = dataGridView1.Rows[e.RowIndex].Cells["NgayVL"].Value?.ToString();
                    txt_GioiTinh.Text = dataGridView1.Rows[e.RowIndex].Cells["GioiTinh"].Value?.ToString();
                    txt_ChucVu.Text = dataGridView1.Rows[e.RowIndex].Cells["TenChucVu"].Value?.ToString();

                    if (!DangSua && !DangThem)
                    {
                        btn_Sua.Enabled = true;
                        btn_Xoa.Enabled = true;
                    }
                }
            }    
           
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            DangThem = true;
            DangSua = false;
            IdNhanVienDangChon = null;
            btn_Huy.Visible = true;

            ClearInput();
            SetControlState(true);

            btn_Them.Enabled = true;
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_Luu.Enabled = true;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (IdNhanVienDangChon.HasValue)
            {
                btn_Huy.Visible = true;
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?'", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var nhanVien = Main_Form.data.NHANVIEN.Find(IdNhanVienDangChon.Value);
                        var nguoidung = Main_Form.data.NGUOIDUNG.FirstOrDefault(t => t.IDNhanVien == IdNhanVienDangChon);
                        if (nguoidung != null)
                        {
                            Main_Form.data.NGUOIDUNG.Remove(nguoidung);
                            Main_Form.data.SaveChanges();
                        }
                        if (nhanVien != null)
                        {
                            Main_Form.data.NHANVIEN.Remove(nhanVien);
                            Main_Form.data.SaveChanges();
                            LoadNhanVien();
                            ClearInput();
                            ThietLapTrangThai();
                            MessageBox.Show("Xóa nhân viên thành công!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra khi xóa nhân viên!\nNhân viên có tên trong lịch làm hoặc phiếu nhập nguyên liệu");
                    }

                }
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (IdNhanVienDangChon.HasValue)
            {
                btn_Huy.Visible = true;
                DangSua = true;
                DangThem = false;
                SetControlState(true);
                btn_Them.Enabled = false;
                btn_Sua.Enabled = false;
                btn_Xoa.Enabled = false;
                btn_Luu.Enabled = true;
            }
        }
        private bool ValidateEmployee()
        {
            if (string.IsNullOrWhiteSpace(txt_Hoten.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!string.IsNullOrEmpty(txt_Sdt.Text) && txt_Sdt.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_DiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!EmailHopLe(txt_Email.Text))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!DateTime.TryParseExact(txt_NgaySinh.Text, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int tuoi = DateTime.Now.Year - ngaySinh.Year;
            if (DateTime.Now.DayOfYear < ngaySinh.DayOfYear) tuoi--;

            if (tuoi < 18)
            {
                MessageBox.Show("Nhân viên phải đủ 18 tuổi!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!decimal.TryParse(txt_Luong.Text, out decimal luong) || luong <= 0)
            {
                MessageBox.Show("Lương không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!DateTime.TryParseExact(txt_NgayVL.Text, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngayVL))
            {
                MessageBox.Show("Ngày vào làm không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (ngayVL <= ngaySinh)
            {
                MessageBox.Show("Ngày vào làm phải sau ngày sinh!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } 
            if (txt_ChucVu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chức vụ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateEmployee())
                {
                    return;
                }
                DateTime ngaySinh = DateTime.ParseExact(txt_NgaySinh.Text, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);
                DateTime ngayVL = DateTime.ParseExact(txt_NgayVL.Text, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);
                if (DangThem)
                {
                    NHANVIEN nhavienmoi = new NHANVIEN();

                    nhavienmoi.HotenNV = txt_Hoten.Text;
                    if (Main_Form.data.NHANVIEN.Any(t => t.SDT == txt_Sdt.Text))
                    {
                        MessageBox.Show("Số điện thoại đã được sử dụng!");
                        return;
                    }
                    nhavienmoi.SDT = txt_Sdt.Text;
                    nhavienmoi.DiaChi = txt_DiaChi.Text;
                    nhavienmoi.NgaySinh = DateTime.Parse(txt_NgaySinh.Text);
                    nhavienmoi.Email = txt_Email.Text;
                    nhavienmoi.LuongCoBan = double.Parse(txt_Luong.Text);
                    nhavienmoi.NgayVL = DateTime.Parse(txt_NgayVL.Text);
                    nhavienmoi.GioiTinh = txt_GioiTinh.Text;
                    nhavienmoi.IdChucVu = ((CHUCVU)txt_ChucVu.SelectedItem).IDChucVu;
                    Main_Form.data.NHANVIEN.Add(nhavienmoi);
                    Main_Form.data.SaveChanges();
                    NGUOIDUNG nguoidungmoi = new NGUOIDUNG();
                    nguoidungmoi.IDNhanVien = nhavienmoi.IDNhanVien;
                    nguoidungmoi.TenTK = nhavienmoi.HotenNV;
                    nguoidungmoi.MatKhau = "123";
                    Main_Form.data.NGUOIDUNG.Add(nguoidungmoi);
                    Main_Form.data.SaveChanges();
                }
                else if (DangSua)
                {
                    var nhanvien = Main_Form.data.NHANVIEN.Find(IdNhanVienDangChon.Value);
                    if (nhanvien != null)
                    {
                        nhanvien.HotenNV = txt_Hoten.Text;
                        if (Main_Form.data.NHANVIEN.Any(t => (t.SDT == txt_Sdt.Text && t.IDNhanVien != nhanvien.IDNhanVien)))
                        {
                            MessageBox.Show("Số điện thoại đã được sử dụng!");
                            return;
                        }
                        nhanvien.SDT = txt_Sdt.Text;
                        nhanvien.DiaChi = txt_DiaChi.Text;
                        nhanvien.NgaySinh = DateTime.Parse(txt_NgaySinh.Text);
                        nhanvien.Email = txt_Email.Text;
                        nhanvien.LuongCoBan = double.Parse(txt_Luong.Text);
                        nhanvien.NgayVL = DateTime.Parse(txt_NgayVL.Text);
                        nhanvien.GioiTinh = txt_GioiTinh.Text;
                        nhanvien.IdChucVu = ((CHUCVU)txt_ChucVu.SelectedItem).IDChucVu;
                    }
                }
                Main_Form.data.SaveChanges();
                LoadNhanVien();

                DangThem = false;
                DangSua = false;
                IdNhanVienDangChon = null;
                ThietLapTrangThai();
                ClearInput();
                MessageBox.Show("Lưu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            ClearInput();
            ThietLapTrangThai();
            DangSua = DangThem = false;
        }

        private void cbb_ChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
                if (cbb_ChucVu.SelectedIndex == 0)
                {
                    LoadNhanVien();
                }
                else
                {
                    CHUCVU selectedChucVu = (CHUCVU)cbb_ChucVu.SelectedItem;
                    dataGridView1.DataSource = Main_Form.data.NHANVIEN
                        .Where(t => t.IdChucVu == selectedChucVu.IDChucVu)
                        .Select(t => new
                        {
                            t.IDNhanVien,
                            t.HotenNV,
                            t.NgaySinh,
                            t.SDT,
                            t.DiaChi,
                            t.Email,
                            t.NgayVL,
                            t.LuongCoBan,
                            t.GioiTinh,
                            TenChucVu = t.CHUCVU.TenChucVu
                        })
                        .ToList();
                }
        }

        private void btn_XepLich_Click(object sender, EventArgs e)
        {
            Work.OpenFormChild(new XepLich_Form(), (Panel)this.Parent);
        }

        private void txt_Sdt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_Luong_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_Email_TextChanged(object sender, EventArgs e)
        {
            txt_Email.TextChanged -= txt_Email_TextChanged;
            if (string.IsNullOrWhiteSpace(txt_Email.Text))
            {
                txt_Email.TextChanged += txt_Email_TextChanged;
                return;
            }

            string userInput = txt_Email.Text.Replace("@gmail.com", "");

            txt_Email.Text = userInput + "@gmail.com";

            txt_Email.SelectionStart = userInput.Length;
            txt_Email.SelectionLength = 0;

            txt_Email.TextChanged += txt_Email_TextChanged;
        }
    }
}
