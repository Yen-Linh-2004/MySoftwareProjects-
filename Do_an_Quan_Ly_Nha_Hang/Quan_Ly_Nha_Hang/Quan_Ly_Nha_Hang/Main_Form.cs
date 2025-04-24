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
    public partial class Main_Form : Form
    {
        private NGUOIDUNG taikhoannguoidung;
        public static QL_NHAHANGEntities data = new QL_NHAHANGEntities();
        internal static TrangChu_Form TrangChu_Form;
        private static NhanVien_Form NhanVien_Form;
        private bool thoat = true;
        private bool nlbtn = true;
        public static Main_Form Instance { get; private set; }


        public NGUOIDUNG TaiKhoanNguoiDung
        {
            get { return taikhoannguoidung; }
            set {taikhoannguoidung = value; }
        }
        public Main_Form(NGUOIDUNG tknguoidung)
        {
            InitializeComponent();
            Instance = this; 
            TrangChu_Form = new TrangChu_Form();
            NhanVien_Form = new NhanVien_Form();
            NguyenLieu_Panel.Visible = false;
            this.taikhoannguoidung = tknguoidung;
            PhanQuyen();
        }

        private void PhanQuyen()
        {
            NHANVIEN nv = data.NHANVIEN.Find(taikhoannguoidung.IDNhanVien);
            txt_TenNV.Text = nv.HotenNV.ToString();
            if (nv != null)
            {
                if (nv.IdChucVu == 1)
                {
                    btn_TrangChu.Enabled = true;
                    btn_ThucDon.Enabled = true;
                    btn_NhanVien.Enabled = true;
                    btn_ThongKe.Enabled = true;
                    btn_NguyenLieu.Enabled = true;
                }
                else if (nv.IdChucVu == 3)
                {
                    btn_TrangChu.Enabled = true;
                    btn_ThucDon.Enabled = true;
                    btn_NguyenLieu.Enabled = true;
                    btn_NhanVien.Enabled = false;
                    btn_ThongKe.Enabled = false;
                }
                else
                {
                    btn_TrangChu.Enabled = false;
                    btn_ThucDon.Enabled = false;
                    btn_NhanVien.Enabled = false;
                    btn_ThongKe.Enabled = false;
                }
            }
        }
        private void Main_Form_Load(object sender, EventArgs e)
        {
            TrangChu_Click_panel.Visible = ThucDon_Click_panel.Visible = NhanVien_Click_panel.Visible = ThongKe_Click_panel.Visible = NguyenLieu_Click_panel.Visible = false;
        }
        private void btn_TrangChu_Click(object sender, EventArgs e)
        {
            ThucDon_Click_panel.Visible = NhanVien_Click_panel.Visible = ThongKe_Click_panel.Visible = NguyenLieu_Click_panel.Visible = false;
            TrangChu_Click_panel.Visible = true;
            NguyenLieu_Panel.Visible = false;

            Work.OpenFormChild(TrangChu_Form, Function_Panel);
        }
        private void btn_ThucDon_Click(object sender, EventArgs e)
        {
            TrangChu_Click_panel.Visible = NhanVien_Click_panel.Visible = ThongKe_Click_panel.Visible = NguyenLieu_Click_panel.Visible = false;
            ThucDon_Click_panel.Visible = true;
            NguyenLieu_Panel.Visible = false;

            Work.OpenFormChild(new ThucDon_Form(), Function_Panel);
        }

        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            TrangChu_Click_panel.Visible = ThucDon_Click_panel.Visible = ThongKe_Click_panel.Visible = NguyenLieu_Click_panel.Visible = false;
            NhanVien_Click_panel.Visible = true;
            NguyenLieu_Panel.Visible = false;

            Work.OpenFormChild(NhanVien_Form, Function_Panel);
        }

        private void btn_Thaot_Click(object sender, EventArgs e)
        {
            if (thoat == true)
            {
                if (MessageBox.Show("Bạn muốn thoát ứng dụng?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Application.Exit();
            }
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            TrangChu_Click_panel.Visible = ThucDon_Click_panel.Visible = NhanVien_Click_panel.Visible = NguyenLieu_Click_panel.Visible = false;
            ThongKe_Click_panel.Visible = true;
            NguyenLieu_Panel.Visible = false;

            Work.OpenFormChild(new ThongKe_Form(), Function_Panel);
        }

        private void btn_NguyenLieu_Click(object sender, EventArgs e)
        {
            if(nlbtn)
            {
                TrangChu_Click_panel.Visible = ThucDon_Click_panel.Visible = NhanVien_Click_panel.Visible = ThongKe_Click_panel.Visible = false;
                NguyenLieu_Click_panel.Visible = true;
                NguyenLieu_Panel.Visible = true;
                nlbtn = false;

            }
            else
            {
                NguyenLieu_Panel.Visible = false;
                nlbtn=true;
            }    
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void btn_XemNguyenLieu_Click(object sender, EventArgs e)
        {
            Work.OpenFormChild(new XemNguyenLieu(), Function_Panel);
        }

        private void btn_NhapNguyenLieu_Click(object sender, EventArgs e)
        {
            Work.OpenFormChild(new NhapNguyenLieu(taikhoannguoidung), Function_Panel);
        }

        private void txt_DangXuat_Click(object sender, EventArgs e)
        {

            thoat = false;
            this.Close();
            DangNhap_Form mf = new DangNhap_Form();
            mf.Show();
        }

    }
}
