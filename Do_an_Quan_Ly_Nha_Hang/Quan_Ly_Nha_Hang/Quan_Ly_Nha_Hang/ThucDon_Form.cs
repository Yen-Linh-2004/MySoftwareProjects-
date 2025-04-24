using Guna.UI2.WinForms;
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
    public partial class ThucDon_Form : Form
    {
        static ThucDon_Form instance;

        public static ThucDon_Form Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ThucDon_Form();
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
            get { return ThucDon_panel; }
            set { ThucDon_panel = value; }
        }

        public Guna2ImageButton BackButton
        {
            get { return btn_Back; }
            set { btn_Back = value; }
        }

        public ThucDon_Form()
        {
            InitializeComponent();
            btn_Back.Visible = false;
            instance = this;
            ThucDon_All_UserControl uc = new ThucDon_All_UserControl();
            uc.Dock = DockStyle.Fill;
            Container_panel.Controls.Add(uc);

        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Container_panel.Controls["ThucDon_All_UserControl"].BringToFront();
            btn_Back.Visible = false;
        }
    }
}
