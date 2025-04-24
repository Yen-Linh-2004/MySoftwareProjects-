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

namespace Quan_Ly_Nha_Hang
{
    public partial class Order_ChinhSua_UserControl : UserControl
    {
        KHACHHANG khach;
        BAN Ban;
        public Order_ChinhSua_UserControl(BAN ban)
        {
            InitializeComponent();
            this.Ban = ban;
            LoadKhachHang();
        }

        private void LoadKhachHang()
        {
            if (!TrangChu_Form.dsbanvakhach.ContainsKey(Ban.IDBan))
            {
                khach = Main_Form.data.KHACHHANG.FirstOrDefault(t => t.IDKhachHang == 1);
            }
            else
                this.khach = TrangChu_Form.dsbanvakhach[Ban.IDBan];
        }

        private void Order_ChinhSua_UserControl_Load(object sender, EventArgs e)
        {
            txt_HoTen.Text = khach.HotenKH;
            txt_SoDienThoai.Text = khach.SDT;
            txt_Email.Text = khach.Email;
            txt_DiaChi.Text = khach.DiaChi;
        }

        private KHACHHANG TimkiemkhachHang()
        {
            var sdt = txt_SoDienThoai.Text;
            var Khach = Main_Form.data.KHACHHANG.FirstOrDefault(t => t.SDT == sdt);
            if (Khach != null)
            {
                if (Khach.HotenKH != null)
                {
                    txt_HoTen.Text = Khach.HotenKH.ToString();

                }
                if (Khach.Email != null)
                {

                    txt_Email.Text = Khach.Email;
                }
            }
            return Khach;
        }

        private void txt_SoDienThoai_TextChanged(object sender, EventArgs e)
        {
            khach = TimkiemkhachHang();
            if (khach != null)
            {
                txt_HoTen.Text = khach.HotenKH;
                txt_Email.Text = khach.Email;
                txt_DiaChi.Text = khach.DiaChi;
            }

        }
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_HoTen.Text))
                {
                    MessageBox.Show("Không được bỏ trống tên", "Bỏ trống thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txt_SoDienThoai.Text))
                {
                    MessageBox.Show("Không được bỏ trống số điện thoại", "Bỏ trống thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txt_SoDienThoai.Text.Length != 10)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ", "Sai thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!string.IsNullOrEmpty(txt_Email.Text) && !txt_Email.Text.EndsWith("@gmail.com"))
                {
                    MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (khach == null)
                {
                    khach = new KHACHHANG();
                    khach.HotenKH = txt_HoTen.Text;
                    khach.LoaiKH = "Khách hàng mới";
                    khach.SDT = txt_SoDienThoai.Text;
                    khach.Email = txt_Email.Text;
                    khach.DiaChi = txt_DiaChi.Text;
                    if (Main_Form.data.KHACHHANG.FirstOrDefault(t => t.Email == khach.Email && khach.Email != " ") != null)
                    {
                        MessageBox.Show("Email đã sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        khach = null;
                        return;
                    }
                    if (Main_Form.data.KHACHHANG.FirstOrDefault(t => t.SDT == txt_SoDienThoai.Text) != null)
                    {
                        MessageBox.Show("Số điện thoại đã được sử dụng", "Sai thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        khach = null;
                        return;
                    }
                    Main_Form.data.KHACHHANG.Add(khach);
                    Main_Form.data.SaveChanges();
                }
                TrangChu_Form.dsbanvakhach[Ban.IDBan] = khach;
                var hd = TrangChu_Form.dsbanvahoadon[Ban.IDBan];
                Main_Form.data.HOADON.FirstOrDefault(t => t.IDHoaDon == hd.IDHoaDon).IDKhachHang = khach.IDKhachHang;
                Main_Form.data.SaveChanges();
                MessageBox.Show("Lưu thành công", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                khach = null;
            }

        }

        private void txt_SoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
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
