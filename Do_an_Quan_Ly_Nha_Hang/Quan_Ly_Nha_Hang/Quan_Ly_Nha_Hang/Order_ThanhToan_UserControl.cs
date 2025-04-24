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
    public partial class Order_ThanhToan_UserControl : UserControl
    {
        BAN Ban;
        HOADON HoaDon;
        List<KHUYENMAI> dskhuyenmai = new List<KHUYENMAI>();
        double TongTien;

        public Order_ThanhToan_UserControl(BAN bAN, HOADON hoaDon)
        {
            InitializeComponent();
            this.Ban = bAN;
            this.HoaDon = hoaDon;
            LoadMonAnDaDat();
            this.TongTien = TinhTongTien();

        }

        private void btn_TienMat_Click(object sender, EventArgs e)
        {

            Order_Form.Instance.TopLevel = false;
            Order_TienMat_UserControl uc = new Order_TienMat_UserControl(Ban, HoaDon, TongTien, dskhuyenmai.OrderByDescending(t => t.PhanTram).FirstOrDefault());
            Order_Form.Instance.Container_panel.Controls.Add(uc);
            Order_Form.Instance.Container_panel.BringToFront();

            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            uc.Show();

        }

        private void btn_The_Click(object sender, EventArgs e)
        {
            if (!Order_Form.Instance.Container_panel.Controls.ContainsKey("Order_The_UserControl"))
            {
                Order_Form.Instance.TopLevel = false;
                Order_The_UserControl uc = new Order_The_UserControl(TongTien, dskhuyenmai.OrderByDescending(t => t.PhanTram).FirstOrDefault(), HoaDon, Ban);
                Order_Form.Instance.Container_panel.Controls.Add(uc);
                Order_Form.Instance.Container_panel.BringToFront();

                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
                uc.Show();
            }
            Order_Form.Instance.Container_panel.Controls["Order_The_UserControl"].BringToFront();
            Order_Form.Instance.BackButton.Visible = true;
        }

        private void btn_QR_Click(object sender, EventArgs e)
        {

            Order_Form.Instance.TopLevel = false;
            Order_QR_UserControl uc = new Order_QR_UserControl(TongTien, dskhuyenmai.OrderByDescending(t => t.PhanTram).FirstOrDefault(), HoaDon, Ban);
            Order_Form.Instance.Container_panel.Controls.Add(uc);
            Order_Form.Instance.Container_panel.BringToFront();

            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            uc.Show();

            Order_Form.Instance.Container_panel.Controls["Order_QR_UserControl"].BringToFront();
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
        internal double TinhTongTien()
        {
            double tongTien = 0;
            double giamgia = 0;
            double phuthu = 0;
            double tongthanhtoan = 0;

            foreach (DataGridViewRow row in Order_HoaDon_DG.Rows)
            {

                if (!row.IsNewRow)
                {

                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    double donGia = Convert.ToDouble(row.Cells["DonGia"].Value);

                    tongTien += soLuong * donGia;
                }
            }
            giamgia = tongTien * KiemTraKhuyenMai();
            phuthu = (tongTien - giamgia) * 0.1;
            tongthanhtoan += tongTien - giamgia + phuthu;
            txt_TongTien_ThanhToan.Text = tongTien.ToString("#,##0") + " VNĐ";
            txt_GiamGia.Text = giamgia.ToString("#,##0") + " VNĐ";
            txt_PhuThu.Text = phuthu.ToString("#,##0") + " VNĐ";
            txt_TienThanhToan.Text = tongthanhtoan.ToString("#,##0") + " VNĐ";

            return tongthanhtoan;
        }

        private double KiemTraKhuyenMai()
        {

            dskhuyenmai = new List<KHUYENMAI> { new KHUYENMAI { PhanTram = 0.000 } };

            if (TrangChu_Form.monAnCuaBan.ContainsKey(Ban.IDBan))
            {
                if (TrangChu_Form.monAnCuaBan[Ban.IDBan].Count >= 8)
                {
                    var khuyenMai = Main_Form.data.KHUYENMAI.FirstOrDefault(t => t.IDKhuyenMai == 2);
                    if (khuyenMai != null)
                        dskhuyenmai.Add(khuyenMai);
                }
                else if (TrangChu_Form.monAnCuaBan[Ban.IDBan].Count >= 5)
                {
                    var khuyenMai = Main_Form.data.KHUYENMAI.FirstOrDefault(t => t.IDKhuyenMai == 1);
                    if (khuyenMai != null)
                        dskhuyenmai.Add(khuyenMai);
                }
            }

            if (TrangChu_Form.dsbanvakhach.ContainsKey(Ban.IDBan))
            {
                string loaiKH = TrangChu_Form.dsbanvakhach[Ban.IDBan].LoaiKH;
                KHUYENMAI khuyenMaiTheoLoaiKH = null;
                if (loaiKH == "Khách hàng VIP" && TrangChu_Form.dsbanvakhach[Ban.IDBan].IDKhachHang != 1)
                {
                    khuyenMaiTheoLoaiKH = Main_Form.data.KHUYENMAI.FirstOrDefault(t => t.IDKhuyenMai == 3);
                }
                else if (loaiKH == "Khách hàng thành viên" && TrangChu_Form.dsbanvakhach[Ban.IDBan].IDKhachHang != 1)
                {
                    khuyenMaiTheoLoaiKH = Main_Form.data.KHUYENMAI.FirstOrDefault(t => t.IDKhuyenMai == 4);
                }
                if (khuyenMaiTheoLoaiKH != null)
                    dskhuyenmai.Add(khuyenMaiTheoLoaiKH);
            }
            double phanTramCaoNhat = (double)dskhuyenmai.Max(t => t.PhanTram);
            return phanTramCaoNhat;
        }
        private void Order_ThanhToan_UserControl_VisibleChanged(object sender, EventArgs e)
        {
            LoadMonAnDaDat();
        }

        private void Order_ThanhToan_UserControl_Load(object sender, EventArgs e)
        {

        }

    }

}
