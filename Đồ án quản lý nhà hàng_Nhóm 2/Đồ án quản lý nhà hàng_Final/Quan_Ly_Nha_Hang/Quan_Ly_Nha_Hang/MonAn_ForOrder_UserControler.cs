using Quan_Ly_Nha_Hang.Data;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Quan_Ly_Nha_Hang
{
    public partial class MonAn_ForOrder_UserControler : UserControl
    {
        private int mamon;
        private string tenmon;
        private string giamon;
        private Image anhmon;


        public string SoLuongCon
        {
            get { return txt_SLConLai.Text; }
            set
            {

                txt_SLConLai.Text = "x "+value;
                txt_SLConLai.Visible = int.Parse(value) >=0;
            }
        }
        public string SoLuong
        {
            get { return txt_SoLuong.Text; }
            set 
            { 
                txt_SoLuong.Text = value;
                txt_SoLuong.Visible = int.Parse(value) > 0;
            }
        }

        [Category("Custom Properties")]
        public int MaMon
        {
            get { return mamon; }
            set
            {
                mamon = value;
            }
        }

        [Category("Custom Properties")]
        public string TenMon
        {
            get { return tenmon; }
            set
            {
                tenmon = value;
                txt_TenMonAn.Text = tenmon;
            }
        }

        [Category("Custom Properties")]
        public string GiaMon
        {
            get { return giamon; }
            set
            {
                giamon = value;
                int giaMonAnSo;
                int.TryParse(giamon, out giaMonAnSo);
                txt_GiaMonAn.Text = giaMonAnSo.ToString("#,##0") + " VNĐ"; 
            }
        }

        [Category("Custom Properties")]
        public Image AnhMon
        {
            get { return anhmon; }
            set
            {
                anhmon = value;
                HinhAnhMon.Image = anhmon;
            }
        }
        public MonAn_ForOrder_UserControler()
        {
            InitializeComponent();
            if (int.Parse(txt_SoLuong.Text) == 0)
            {
                txt_SoLuong.Visible = false;
            }
            else
            {
                txt_SoLuong.Visible = true;
            }
            
            DrawBorderRadius.paintBR(this, 30, 30);
        }


        private void MonAn_ForOrder_UserControler_Click(object sender, EventArgs e)
        {
            try
            {
                int soLuongHienTai = int.Parse(txt_SoLuong.Text);
                int soLuongConLai = int.Parse(txt_SLConLai.Text.Replace("x ", ""));

                if (soLuongHienTai + 1 <= soLuongConLai)
                {
                    this.txt_SoLuong.Text = (soLuongHienTai + 1).ToString();
                    var monthem = Main_Form.data.MON.FirstOrDefault(t => t.IDMon == MaMon);
                    Order_ThemMon_UserControl.DanhSachThem.Add(monthem);
                    txt_SoLuong.Visible = true;
                }
                else
                {
                    MessageBox.Show("Số lượng món không đủ để thêm!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }

        }
        private void MonAn_ForOrder_UserControler_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }

        private void MonAn_ForOrder_UserControler_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.SteelBlue;
        }
    }
}
