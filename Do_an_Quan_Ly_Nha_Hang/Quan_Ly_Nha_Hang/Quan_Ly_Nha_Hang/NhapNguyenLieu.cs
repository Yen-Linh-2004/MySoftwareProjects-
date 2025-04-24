using Quan_Ly_Nha_Hang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Nha_Hang
{
    public partial class NhapNguyenLieu : Form
    {
        NGUOIDUNG nguoidung;
        private List<CHITIETPN> dsnhap;
        private PHIEUNHAP phieunhap;
        public NhapNguyenLieu(NGUOIDUNG nGUOIDUNG)
        {
            InitializeComponent();
            this.nguoidung = nGUOIDUNG;
            LoadNhaCungCap();
            LoadNguyenLieu();
            setup();
        }
        private void LoadNhaCungCap()
        {
            cbb_NhaCungCap.DataSource = Main_Form.data.NHACUNGCAP.ToList();
            cbb_NhaCungCap.ValueMember = "IDNhaCungCap";
            cbb_NhaCungCap.DisplayMember = "TenNhaCungCap";
            cbb_NhaCungCap.SelectedIndex = -1;
        }
        private void LoadNguyenLieu()
        {
            cbb_NguyenLieu.DataSource = Main_Form.data.NGUYENLIEU.ToList();
            cbb_NguyenLieu.ValueMember = "IDNguyenLieu";
            cbb_NguyenLieu.DisplayMember = "TenNguyenLieu";
            cbb_NguyenLieu.SelectedIndex = -1;
        }
        private void setup()
        {
            btn_NhapNguyenLieu.Enabled = false;
            btn_HoanThanh.Enabled = false;
            cbb_NguyenLieu.Enabled = false;
            txt_GiaNhap.Enabled = false;
            txt_SoLuong.Enabled = false;

            btn_TaoPhieuNhap.Enabled = true;
            cbb_NhaCungCap.Enabled = true;
            cbb_ThanhToan.Enabled = true;
        }

        private void Loaddanhsachthem()
        {
            if (dsnhap != null)
            {
                guna2DataGridView1.DataSource = dsnhap.Select(t => new { t.NGUYENLIEU.TenNguyenLieu, t.SoLuong, t.GiaNhap }).ToList();
            }
        }

        private void btn_TaoPhieuNhap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn tạo phiếu nhập không !", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(cbb_ThanhToan.Text) && !string.IsNullOrEmpty(cbb_NhaCungCap.Text))
                {
                    phieunhap = new PHIEUNHAP()
                    {
                        NgayNhap = DateTime.Now,
                        PhuongThucTT = cbb_ThanhToan.SelectedItem.ToString(),
                        TrangThai = "Đã thanh toán",
                        NgayThanhToan = DateTime.Now,
                        IDNhanVien = nguoidung.IDNhanVien,
                        IDNhaCungCap = (int)cbb_NhaCungCap.SelectedValue
                    };

                }
                if (phieunhap != null)
                {
                    Main_Form.data.PHIEUNHAP.Add(phieunhap);
                    Main_Form.data.SaveChanges();
                    dsnhap = new List<CHITIETPN>();
                    btn_TaoPhieuNhap.Enabled = false;
                    cbb_NhaCungCap.Enabled = false;
                    cbb_ThanhToan.Enabled = false;

                    txt_GiaNhap.Enabled = true;
                    txt_SoLuong.Enabled = true;
                    cbb_NguyenLieu.Enabled = true;
                    btn_NhapNguyenLieu.Enabled = true;
                    btn_HoanThanh.Enabled = true;
                }
            }
        }
        private void btn_NhapNguyenLieu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbb_NguyenLieu.Text) && !string.IsNullOrEmpty(txt_GiaNhap.Text) && !string.IsNullOrEmpty(txt_SoLuong.Text))
            {
                CHITIETPN ctph = new CHITIETPN()
                {
                    IDPhieuNhap = phieunhap.IDPhieuNhap,
                    IDNguyenLieu = (int)cbb_NguyenLieu.SelectedValue,
                    SoLuong = Convert.ToInt32(txt_SoLuong.Text),
                    GiaNhap = Convert.ToDouble(txt_GiaNhap.Text),

                };
                ctph.NGUYENLIEU = (NGUYENLIEU)cbb_NguyenLieu.SelectedItem;
                dsnhap.Add(ctph);
                Loaddanhsachthem();
            }
        }
        private void btn_HoanThanh_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in dsnhap)
                {
                    CHITIETPN ctphieunhap = new CHITIETPN()
                    {
                        IDPhieuNhap= phieunhap.IDPhieuNhap,
                        IDNguyenLieu= item.IDNguyenLieu,
                        GiaNhap = item.GiaNhap,
                        SoLuong= item.SoLuong,
                    };
                    Main_Form.data.CHITIETPN.Add(ctphieunhap);
                    Main_Form.data.SaveChanges();
                }
                var tongtien = Main_Form.data.Database.SqlQuery<double>(
        "SELECT dbo.Fc_TinhTongTien1PhieuNhap(@IDPhieuNhap)",
        new SqlParameter("@IDPhieuNhap", phieunhap.IDPhieuNhap)
    ).FirstOrDefault(); ;

                var pn = Main_Form.data.PHIEUNHAP.Find(phieunhap.IDPhieuNhap);
                pn.TongTien = tongtien;
                Main_Form.data.SaveChanges();
                txt_GiaNhap.Clear();
                txt_SoLuong.Clear();
                guna2DataGridView1.DataSource = null;
                dsnhap.Clear();
                setup();
                MessageBox.Show("Nhập kho hoàn tất", "Thành công", MessageBoxButtons.OK);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txt_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_GiaNhap_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
