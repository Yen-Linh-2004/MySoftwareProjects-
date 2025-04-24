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
    public partial class MonAn_ForThucDon_UserControl : UserControl
    {
        private int mamon;
        private string tenmon;
        private string giamon;
        private Image anhmon;
        private MON mon;

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
                txt_TenMon.Text = tenmon;
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
                txt_GiaMon.Text = giaMonAnSo.ToString("#,##0") + " VNĐ";
            }
        }

        [Category("Custom Properties")]
        public Image AnhMon
        {
            get { return anhmon; }
            set
            {
                anhmon = value;
                img_MonAn.Image = anhmon;
            }
        }
        public MonAn_ForThucDon_UserControl(MON MON)
        {
            InitializeComponent();
            this.mon = MON;
            DrawBorderRadius.paintBR(this, 30, 30);

        }

        private void MonAn_ForThucDon_UserControl_Click(object sender, EventArgs e)
        {
            ThucDon_Form.Instance.TopLevel = false;
            ThucDon_ChiTietMonAn_UserControl uc = new ThucDon_ChiTietMonAn_UserControl(mon);
            ThucDon_Form.Instance.Container_panel.Controls.Add(uc);
            ThucDon_Form.Instance.Container_panel.BringToFront();
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            uc.Show();

            ThucDon_Form.Instance.BackButton.Visible = true;

        }


    }
}
