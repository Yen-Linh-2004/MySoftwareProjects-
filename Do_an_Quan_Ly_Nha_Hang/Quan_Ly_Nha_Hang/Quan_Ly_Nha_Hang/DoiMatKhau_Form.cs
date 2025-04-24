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
    public partial class DoiMatKhau_Form : Form
    {
        NGUOIDUNG nguoidung;
        public DoiMatKhau_Form(NGUOIDUNG ngdung)
        {
            InitializeComponent();
            this.nguoidung = ngdung;
            
        }

        private void DoiMatKhau()
        {
            // Kiểm tra các trường rỗng
            if (string.IsNullOrEmpty(txt_MatKhau.Text))
            {
                MessageBox.Show("Hãy nhập mật khẩu cũ", "Mật khẩu rỗng",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MatKhau.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txt_MatKhauMoi.Text))
            {
                MessageBox.Show("Hãy nhập mật khẩu mới", "Mật khẩu mới rỗng",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MatKhauMoi.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txt_MatKhauXacNhan.Text)) // Giả sử tên textbox xác nhận là txt_XacNhanMK
            {
                MessageBox.Show("Hãy xác nhận mật khẩu", "Xác nhận mật khẩu rỗng",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MatKhauXacNhan.Focus();
                return;
            }

            if (txt_MatKhau.Text != nguoidung.MatKhau)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_MatKhau.Focus();
                return;
            }

           
            if (txt_MatKhauMoi.Text != txt_MatKhauXacNhan.Text)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_MatKhauMoi.Focus();
                return;
            }

          
            if (txt_MatKhauMoi.Text == txt_MatKhau.Text)
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu cũ", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_MatKhauMoi.Focus();
                return;
            }

            try
            {
                using (var context = new QL_NHAHANGEntities()) 
                {
                   
                    var user = context.NGUOIDUNG.FirstOrDefault(t => t.TenTK == nguoidung.TenTK);
                    if (user != null)
                    {
                        user.MatKhau = txt_MatKhauMoi.Text;
                        context.SaveChanges();

                        var taiKhoan = DangNhap_Form.TaiKhoangDangNhap
                            .FirstOrDefault(t => t.TenTK == nguoidung.TenTK);
                        if (taiKhoan != null)
                        {
                            taiKhoan.MatKhau = txt_MatKhauMoi.Text;
                        }

                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_DoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau();
        }

        private void ckb_HienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_MatKhau.PasswordChar == '⚫')
            {
                txt_MatKhau.PasswordChar = '\0';
                txt_MatKhauMoi.PasswordChar = '\0';
                txt_MatKhauXacNhan.PasswordChar = '\0';
            }
            else
            {
                txt_MatKhau.PasswordChar = '⚫';
                txt_MatKhauMoi.PasswordChar = '⚫';
                txt_MatKhauXacNhan.PasswordChar = '⚫';
            }
        }
    }
}
