using Guna.UI2.WinForms;
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
    public partial class Order_Form : Form
    {
        static Order_Form instance;
        private BAN Ban;
        private HOADON HoaDon;
        private KHACHHANG KhachHang;
        public static Order_Form Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Order_Form();
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }
        public Panel Container_panel
        {
            get { return Order_change_panel; }
            set { Order_change_panel = value; }
        }
        public Guna2ImageButton BackButton
        {
            get { return btn_Back; }
            set { btn_Back = value; }
        }
        public Order_Form()
        {
            InitializeComponent();
            this.btn_Back.Visible = true;
        }
        public Order_Form(BAN ban)
        {
            InitializeComponent();
            this.Ban = ban;
            txt_Table_Name.Text = Ban.TenBan;
            this.btn_Back.Visible = true;
        } 
        public Order_Form(BAN ban, HOADON hoaDon, KHACHHANG khachHang)
        {
            InitializeComponent();
            this.Ban = ban;
            txt_Table_Name.Text = Ban.TenBan;
            this.HoaDon = hoaDon;
            this.KhachHang = khachHang;
        }
        private void Order_Form_Load(object sender, EventArgs e)
        {
            if (HoaDon != null)
            {
                btn_Back.Visible = false;
                instance = this;
                Order_Main_UserControl uc = new Order_Main_UserControl(Ban, HoaDon);
                uc.Dock = DockStyle.Fill;
                Container_panel.Controls.Add(uc);
            }
            else
            {
                Order_DatBan_UserControl uc = new Order_DatBan_UserControl(Ban);
                uc.Dock = DockStyle.Fill;
                Container_panel.Controls.Add(uc);
                btn_Back.Visible = false ;
            }

        }
        private void btn_Back_Click(object sender, EventArgs e)
        {
            var currentControl = Container_panel.Controls[0];

            if (currentControl.Name == "Order_TienMat_UserControl"
                || currentControl.Name == "Order_QR_UserControl"
                || currentControl.Name == "Order_The_UserControl")
            {
                Container_panel.Controls["Order_ThanhToan_UserControl"].BringToFront();
            }
            else
            {
                Container_panel.Controls["Order_Main_UserControl"].BringToFront();
                btn_Back.Visible = false;
            }

        }
        public void VoHieuHoa_btn_Back()
        {
            this.btn_Back.Visible = false;
        }
    }
}
