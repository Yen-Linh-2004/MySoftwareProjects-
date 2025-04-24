using Quan_Ly_Nha_Hang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Nha_Hang
{
    public partial class Order_Main_UserControl : UserControl
    {
        private BAN Ban;
        private HOADON HoaDon;
        public TrangChu_Form.CapNhatTrangThaiBanDelegate CapNhatUI;


        public Order_Main_UserControl()
        {
            InitializeComponent();
            var trangChuForm = Application.OpenForms.OfType<TrangChu_Form>().FirstOrDefault();
            if (trangChuForm != null)
            {
                this.CapNhatUI = trangChuForm.CapNhatUIBan;
            }
        }
        public Order_Main_UserControl(BAN ban, HOADON hoaDon)
        {
            InitializeComponent();
            this.Ban = ban;
            LoadMonAnDaDat();
            TinhTongTien();
            this.HoaDon = hoaDon;
            var trangChuForm = Application.OpenForms.OfType<TrangChu_Form>().FirstOrDefault();
            if (trangChuForm != null)
            {
                this.CapNhatUI = trangChuForm.CapNhatUIBan;
            }
        }

        private void btn_ThemMon_Click(object sender, EventArgs e)
        {

            Order_Form.Instance.TopLevel = false;
            Order_ThemMon_UserControl uc = new Order_ThemMon_UserControl(Ban, HoaDon);
            Order_Form.Instance.Container_panel.Controls.Add(uc);
            Order_Form.Instance.Container_panel.BringToFront();

            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            uc.Show();

            Order_Form.Instance.Container_panel.Controls["Order_ThemMon_UserControl"].BringToFront();
            Order_Form.Instance.BackButton.Visible = true;
        }
        public void LoadMonAnDaDat()
        {
            if (TrangChu_Form.monAnCuaBan.ContainsKey(Ban.IDBan))
            {

                var dsmonandadat = TrangChu_Form.monAnCuaBan[Ban.IDBan]
                    .Select(item => new
                    {
                        TenMon = item.Key.TenMon,
                        DonGia = item.Key.DonGia,
                        SoLuong = item.Value
                    })
                    .ToList();

                Order_HoaDon_DG.AutoGenerateColumns = false;
                Order_HoaDon_DG.ForeColor = Color.Black;


                if (Order_HoaDon_DG.Columns.Count == 0)
                {
                    Order_HoaDon_DG.Columns.Add("TenMon", "Tên món");
                    Order_HoaDon_DG.Columns["TenMon"].DataPropertyName = "TenMon";

                    Order_HoaDon_DG.Columns.Add("DonGia", "Đơn giá");
                    Order_HoaDon_DG.Columns["DonGia"].DataPropertyName = "DonGia";

                    Order_HoaDon_DG.Columns.Add("SoLuong", "Số lượng");
                    Order_HoaDon_DG.Columns["SoLuong"].DataPropertyName = "SoLuong";
                }
                Order_HoaDon_DG.DataSource = null;
                Order_HoaDon_DG.DataSource = dsmonandadat;
                Order_HoaDon_DG.Refresh();
            }
            else
            {
                Order_HoaDon_DG.DataSource = null;
            }
        }
        private void Order_Main_UserControl_Load(object sender, EventArgs e)
        {
            LoadMonAnDaDat();
        }

        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            if (!Order_Form.Instance.Container_panel.Controls.ContainsKey("Order_ChinhSua_UserControl"))
            {
                Order_Form.Instance.TopLevel = false;
                Order_ChinhSua_UserControl uc = new Order_ChinhSua_UserControl(Ban);
                Order_Form.Instance.Container_panel.Controls.Add(uc);
                Order_Form.Instance.Container_panel.BringToFront();

                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
                uc.Show();
            }
            Order_Form.Instance.Container_panel.Controls["Order_ChinhSua_UserControl"].BringToFront();
            Order_Form.Instance.BackButton.Visible = true;
        }

        private void btn_ChuyenBan_Click(object sender, EventArgs e)
        {
            if (!Order_Form.Instance.Container_panel.Controls.ContainsKey("Order_ChuyenBan_UserControl"))
            {
                Order_Form.Instance.TopLevel = false;
                Order_ChuyenBan_UserControl uc = new Order_ChuyenBan_UserControl(Ban, HoaDon);
                Order_Form.Instance.Container_panel.Controls.Add(uc);
                Order_Form.Instance.Container_panel.BringToFront();

                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
                uc.Show();
            }
            Order_Form.Instance.Container_panel.Controls["Order_ChuyenBan_UserControl"].BringToFront();
            Order_Form.Instance.BackButton.Visible = true;
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            if (!TrangChu_Form.monAnCuaBan.ContainsKey(Ban.IDBan))
            {
                int idhd = TrangChu_Form.dsbanvahoadon[Ban.IDBan].IDHoaDon;
                var remove = Main_Form.data.HOADON.FirstOrDefault(t => t.IDHoaDon == idhd);
                Main_Form.data.HOADON.Remove(remove);
                Main_Form.data.BAN.Find(Ban.IDBan).TrangThai = "Bàn trống";
                TrangChu_Form.dsbanvakhach.Remove(Ban.IDBan);
                TrangChu_Form.dsbanvahoadon.Remove(Ban.IDBan);
                Main_Form.data.SaveChanges();
                CapNhatUI?.Invoke();
                this.ParentForm.Close();
                return;
            }
            Order_Form.Instance.TopLevel = false;
            var existingThanhToan = Order_Form.Instance.Container_panel.Controls["Order_ThanhToan_UserControl"];
            if (existingThanhToan != null)
            {
                existingThanhToan.Dispose();
                Order_Form.Instance.Container_panel.Controls.Remove(existingThanhToan);
            };
            Order_ThanhToan_UserControl uc = new Order_ThanhToan_UserControl(Ban, HoaDon);
            Order_Form.Instance.Container_panel.Controls.Add(uc);
            Order_Form.Instance.Container_panel.BringToFront();

            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            uc.Show();
            Order_Form.Instance.Container_panel.Controls["Order_ThanhToan_UserControl"].BringToFront();
            Order_Form.Instance.BackButton.Visible = true;
        }

        private void Order_Main_UserControl_VisibleChanged(object sender, EventArgs e)
        {
            LoadMonAnDaDat();
            TinhTongTien();
        }
        internal double TinhTongTien()
        {
            double tongTien = 0;

            foreach (DataGridViewRow row in Order_HoaDon_DG.Rows)
            {

                if (!row.IsNewRow)
                {

                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    double donGia = Convert.ToDouble(row.Cells["DonGia"].Value);


                    tongTien += soLuong * donGia;
                }
            }
            txt_TongTien.Text = tongTien.ToString("#,##0") + " VNĐ";
            return tongTien;
        }
    }
}
