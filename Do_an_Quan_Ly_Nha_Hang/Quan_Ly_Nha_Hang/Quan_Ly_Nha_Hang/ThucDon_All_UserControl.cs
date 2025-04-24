using Quan_Ly_Nha_Hang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Quan_Ly_Nha_Hang
{
    public partial class ThucDon_All_UserControl : UserControl
    {
        private List<MON> DsMonAN = Main_Form.data.MON.ToList();
        public ThucDon_All_UserControl()
        {
            InitializeComponent();
            LoadMonAn();
            LoadDanhMuc();
        }

        private void btn_ThemMon_Click(object sender, EventArgs e)
        {

            ThucDon_Form.Instance.TopLevel = false;
            ThucDon_ChiTietMonAn_UserControl uc = new ThucDon_ChiTietMonAn_UserControl();
            ThucDon_Form.Instance.Container_panel.Controls.Add(uc);
            ThucDon_Form.Instance.Container_panel.BringToFront();

            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            uc.Show();

            ThucDon_Form.Instance.Container_panel.Controls["ThucDon_ChiTietMonAn_UserControl"].BringToFront();
            ThucDon_Form.Instance.BackButton.Visible = true;
        }
        private void LoadMonAnVaoFlowlayoutpanel(List<MON> ds)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string imageFolder = Path.Combine(baseDirectory, @"..\..\QLNHimg\");
            foreach (MON mon in ds)
            {
                MonAn_ForThucDon_UserControl monAn_ForThucDon = new MonAn_ForThucDon_UserControl(mon);
                monAn_ForThucDon.MaMon = mon.IDMon;
                monAn_ForThucDon.TenMon = mon.TenMon;
                monAn_ForThucDon.GiaMon = mon.DonGia.ToString();
                try
                {
                    string imagePath = Path.GetFullPath(Path.Combine(imageFolder, mon.HinhAnh));
                    monAn_ForThucDon.AnhMon = System.Drawing.Image.FromFile(imagePath);
                }
                catch (Exception)
                {
                    string defaultImagePath = Path.GetFullPath(Path.Combine(imageFolder, "Gà nướng.jpg"));
                    monAn_ForThucDon.AnhMon = System.Drawing.Image.FromFile(defaultImagePath);
                }
                flp_ThucDon.Controls.Add(monAn_ForThucDon);
            }
        }

        private void LoadMonAn()
        {
            var dsbandau = DsMonAN.Where(t => t.TrangThai == comboBox_TrangThai.SelectedItem.ToString()).ToList();
            if (comboBox_Gia.SelectedItem == "Giảm dần")
            {
                dsbandau = dsbandau.OrderByDescending(t => t.DonGia).ToList();
            }
            else
            {
                dsbandau = dsbandau.OrderBy(t => t.DonGia).ToList();
            }
            LoadMonAnVaoFlowlayoutpanel(dsbandau);

        }
        private void LoadDanhMuc()
        {
            foreach (LOAIMON loaimon in Main_Form.data.LOAIMON.ToList())
            {
                comboBox_DanhMuc.Items.Add(loaimon);
            }
            comboBox_DanhMuc.DisplayMember = "TenLoaiMon";
            comboBox_DanhMuc.ValueMember = "IDLoaiMon";
            comboBox_DanhMuc.SelectedIndex = 0;

        }

        private void comboBox_DanhMuc_SelectedValueChanged(object sender, EventArgs e)
        {
            flp_ThucDon.Controls.Clear();

            if (comboBox_DanhMuc.SelectedIndex == 0)
            {
                LoadMonAn();
                return;
            }
            LOAIMON selectedLoaiMon = (LOAIMON)comboBox_DanhMuc.SelectedItem;
            string trangthai = comboBox_TrangThai.SelectedItem.ToString();

            var listmonan = DsMonAN.Where(t => t.IDLoaiMon == selectedLoaiMon.IDLoaiMon && t.TrangThai == trangthai).ToList();
            if (comboBox_Gia.SelectedItem == "Giảm dần")
            {
                listmonan = listmonan.OrderByDescending(t => t.DonGia).ToList();
            }
            else
            {
                listmonan = listmonan.OrderBy(t => t.DonGia).ToList();
            }
            LoadMonAnVaoFlowlayoutpanel(listmonan);
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            flp_ThucDon.Controls.Clear();
            string tuKhoa = txt_TimKiem.Text.ToLower();

            var ketQua = DsMonAN.Where(mon =>
                mon.TenMon.ToLower().Contains(tuKhoa)
            ).ToList();
            LoadMonAnVaoFlowlayoutpanel(ketQua);
        }

      
    }
}
