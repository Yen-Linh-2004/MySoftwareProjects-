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
    public partial class Order_ChuyenBan_UserControl : UserControl
    {
        private BAN Ban;
        private HOADON HoaDon;
        private KHACHHANG Khach;
        private TrangChu_Form.CapNhatTrangThaiBanDelegate CapNhatUI;

        public Order_ChuyenBan_UserControl(BAN bAN,HOADON hOADON)
        {
            InitializeComponent();
            this.Ban = bAN;
            this.HoaDon = hOADON;
            this.Khach = TrangChu_Form.dsbanvakhach[Ban.IDBan];
            var trangChuForm = Application.OpenForms.OfType<TrangChu_Form>().FirstOrDefault();
            if (trangChuForm != null)
            {
                this.CapNhatUI = trangChuForm.CapNhatUIBan;
            }
            LoadBanTrong();
        }
        public Order_ChuyenBan_UserControl()
        {
            InitializeComponent();
            LoadBanTrong();
        }
        private void LoadBanTrong()
        {
            var bantrong = Main_Form.data.BAN.Where(t => t.TrangThai == "Bàn trống").ToList();
            comboBox_ChuyenBan.Items.Clear(); 
            foreach (BAN ban in bantrong)
            {
                comboBox_ChuyenBan.Items.Add(ban);
            }
            comboBox_ChuyenBan.ValueMember = "IDBan";
            comboBox_ChuyenBan.DisplayMember = "TenBan";
        }

        private void btn_ChuyenBan_Click(object sender, EventArgs e)
        {
            if (comboBox_ChuyenBan.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn bàn cần chuyển đến!");
                return;
            }


            BAN banMoi = (BAN)comboBox_ChuyenBan.SelectedItem;
            int idBanMoi = banMoi.IDBan;

            if (TrangChu_Form.monAnCuaBan.ContainsKey(Ban.IDBan))
            {
                try
                {

                    TrangChu_Form.monAnCuaBan[idBanMoi] = new List<KeyValuePair<MON, int>>(
                    TrangChu_Form.monAnCuaBan[Ban.IDBan]);
                    
                   
                    TrangChu_Form.monAnCuaBan.Remove(Ban.IDBan);

                 
                    var banCu = Main_Form.data.BAN.Find(Ban.IDBan);
                    if (banCu != null)
                        banCu.TrangThai = "Bàn trống";

                    var banMoiDB = Main_Form.data.BAN.Find(idBanMoi);
                    if (banMoiDB != null)
                        banMoiDB.TrangThai = "Bàn đang ăn";
                    Main_Form.data.SaveChanges();



                    MessageBox.Show($"Đã chuyển món từ {Ban.TenBan} sang {banMoi.TenBan} thành công!");
                    CapNhatUI?.Invoke();
                    TrangChu_Form.dsbanvahoadon[banMoi.IDBan] = HoaDon;
                    TrangChu_Form.dsbanvakhach[banMoi.IDBan] = Khach;
                    TrangChu_Form.dsbanvakhach.Remove(Ban.IDBan);
                    TrangChu_Form.dsbanvahoadon.Remove(Ban.IDBan);

                    var chiTietHDs = Main_Form.data.CHITIETHD.Where(t => t.IDHoaDon == HoaDon.IDHoaDon).ToList();
                    var parent = this.Parent;

                    foreach (var chiTiet in chiTietHDs)
                    {
                        Main_Form.data.CHITIETHD.Remove(chiTiet);
                        var newcthd = new CHITIETHD
                        {
                            IDHoaDon = HoaDon.IDHoaDon,
                            IDBan = idBanMoi,
                            IDMon = chiTiet.IDMon,
                            SoLuong = chiTiet.SoLuong,
                            DonGia = chiTiet.DonGia

                        };
                        Main_Form.data.CHITIETHD.Add(newcthd);
                        Main_Form.data.SaveChanges();

                    }
                    Main_Form.data.SaveChanges();
                    if (this.ParentForm is Order_Form pr)
                    {
                        pr.VoHieuHoa_btn_Back();
                    }
                    this.btn_ChuyenBan.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi chuyển bàn: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Không có món ăn nào để chuyển!");
            }
        }
    }
}
