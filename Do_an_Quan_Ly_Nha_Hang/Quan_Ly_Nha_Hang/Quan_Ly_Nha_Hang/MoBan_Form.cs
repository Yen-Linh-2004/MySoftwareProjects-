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
    public partial class MoBan_Form : Form
    {
        private BAN Ban;


        public TrangChu_Form.CapNhatTrangThaiBanDelegate CapNhatUI;
        public MoBan_Form(BAN bAN)
        {
            InitializeComponent();
            this.Ban = bAN;
            this.txt_Table_Name.Text = Ban.TenBan;
            if(Ban.TrangThai=="Bàn hỏng")
            {
                ck_Banhong.Checked = true;
                btn_DatBan.Enabled = false;
                btn_MoBan.Enabled = false;  
            }    
            var trangChuForm = Application.OpenForms.OfType<TrangChu_Form>().FirstOrDefault();
            if (trangChuForm != null)
            {
                this.CapNhatUI = trangChuForm.CapNhatUIBan;
            }
        }

        private void btn_MoBan_Click(object sender, EventArgs e)
        {
            try
            {

                var banToUpdate = Main_Form.data.BAN.FirstOrDefault(t => t.IDBan == Ban.IDBan);
                if (banToUpdate != null)
                {
                    if (banToUpdate.TrangThai == "Đã đặt trong 3 tiếng" || banToUpdate.TrangThai == "Bàn đã đặt trong ngày")
                    {
                        if (MessageBox.Show("Bạn chắc chắn muốn mở bàn này?", "Xác nhận mở bàn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            banToUpdate.TrangThai = "Bàn đang ăn";
                            HOADON HoaDonMoi = new HOADON()
                            {
                                NgayLap = DateTime.Today,
                                IDKhachHang = 1,
                                TrangThaiTT = "Chưa thanh toán",
                                VAT = 0.1
                            };

                            Main_Form.data.HOADON.Add(HoaDonMoi);
                            Main_Form.data.SaveChanges();
                            KHACHHANG khachHang = new KHACHHANG();
                            khachHang = Main_Form.data.KHACHHANG.FirstOrDefault(t => t.IDKhachHang == 1);
                            TrangChu_Form.dsbanvahoadon[Ban.IDBan] = HoaDonMoi;
                            TrangChu_Form.dsbanvakhach[Ban.IDBan] = khachHang;
                            Work.OpenFormChild(new Order_Form(Ban, HoaDonMoi, khachHang), Changefunction_MoBan_panel);

                            CapNhatUI?.Invoke();
                        }
                    }
                    else
                    {
                        banToUpdate.TrangThai = "Bàn đang ăn";
                        HOADON HoaDonMoi = new HOADON()
                        {
                            NgayLap = DateTime.Today,
                            IDKhachHang = 1,
                            TrangThaiTT = "Chưa thanh toán",
                            VAT = 0.1
                        };

                        Main_Form.data.HOADON.Add(HoaDonMoi);
                        Main_Form.data.SaveChanges();
                        KHACHHANG khachHang = new KHACHHANG();
                        khachHang = Main_Form.data.KHACHHANG.FirstOrDefault(t => t.IDKhachHang == 1);
                        TrangChu_Form.dsbanvahoadon[Ban.IDBan] = HoaDonMoi;
                        TrangChu_Form.dsbanvakhach[Ban.IDBan] = khachHang;
                        Work.OpenFormChild(new Order_Form(Ban, HoaDonMoi, khachHang), Changefunction_MoBan_panel);

                        CapNhatUI?.Invoke();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra!!!");
            }
        }



        private void btn_DatBan_Click(object sender, EventArgs e)
        {
            Work.OpenFormChild(new Order_Form(Ban), Changefunction_MoBan_panel);
        }

        private void ck_Banhong_CheckedChanged(object sender, EventArgs e)
        {
            var table = Main_Form.data.BAN.Find(Ban.IDBan);

            if (table != null)
            {
                if (ck_Banhong.Checked)
                {
                    table.TrangThai = "Bàn hỏng";
                    this.btn_MoBan.Enabled = false;
                    this.btn_DatBan.Enabled = false;
                }
                else
                {
                    table.TrangThai = "Bàn trống";
                    this.btn_MoBan.Enabled = true;
                    this.btn_DatBan.Enabled = true;
                }
                Main_Form.data.SaveChanges();
                CapNhatUI?.Invoke();
              
            }
            else
            {
                MessageBox.Show("Table not found.");
            }
        }
    }
}
