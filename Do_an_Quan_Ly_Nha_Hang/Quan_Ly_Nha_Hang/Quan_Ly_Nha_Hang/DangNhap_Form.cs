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
namespace Quan_Ly_Nha_Hang
{
    public partial class DangNhap_Form : Form
    {
        internal static List<NGUOIDUNG> TaiKhoangDangNhap = new QL_NHAHANGEntities().NGUOIDUNG.ToList();
        public DangNhap_Form()
        {
            InitializeComponent();
            CenterToScreen();
            this.btn_Back.Visible = false;
            TaiKhoangDangNhap = new QL_NHAHANGEntities().NGUOIDUNG.ToList();

        }

        private void btn_Thaot_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn muốn thoát ứng dụng?","Thoát",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                this.Close();
        }
        private void KiemTraDangNhap()
        {
            if (string.IsNullOrEmpty(txt_TenDangNhap.Text))
            {
                MessageBox.Show("Hãy nhập tên đăng nhập!");
                return;
            }
            if (string.IsNullOrEmpty(txt_MatKhau.Text))
            {
                MessageBox.Show("Hãy nhập mật khẩu!");
                return;
            }
            var nguoidung = TaiKhoangDangNhap.FirstOrDefault(t=>t.TenTK==txt_TenDangNhap.Text);
            if (nguoidung != null)
            {
                if(nguoidung.MatKhau == txt_MatKhau.Text)
                {
                    this.Hide();
                    new Main_Form(nguoidung).ShowDialog();
                }
                else
                {
                    MessageBox.Show("Mật khẩu không chính xác","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }    
            }else
            {
                MessageBox.Show("Tài khoản không hợp lệ");
            }    
        }
        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            KiemTraDangNhap();
        }

        private void ckb_HienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if(txt_MatKhau.PasswordChar == '⚫')
            {
                txt_MatKhau.PasswordChar = '\0';
            }
            else
            {
                txt_MatKhau.PasswordChar = '⚫';
            }    
        }

        private void txt_QuenMatKhau_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_TenDangNhap.Text))
            {
                MessageBox.Show("Hãy nhập tên đăng nhập", "Tên đăng nhập rỗng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var tk = TaiKhoangDangNhap.FirstOrDefault(t => t.TenTK == txt_TenDangNhap.Text);
            if(tk != null)
            {
                Work.OpenFormChild(new DoiMatKhau_Form(tk), panel_dangnhap);
                this.btn_Back.Visible = true;
            }    
            else
            {
                MessageBox.Show("Tên đăng nhập không tồn tại, xin vui lòng kiểm tra tên đăng nhập", "Tên đăng không tồn tại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    
            
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            foreach (Control control in panel_dangnhap.Controls)
            {
                if (control is DoiMatKhau_Form)
                {
                    panel_dangnhap.Controls.Remove(control);
                    control.Dispose(); 
                    break;
                }
            }
            this.btn_Back.Visible = false; 
        }
    }
}
