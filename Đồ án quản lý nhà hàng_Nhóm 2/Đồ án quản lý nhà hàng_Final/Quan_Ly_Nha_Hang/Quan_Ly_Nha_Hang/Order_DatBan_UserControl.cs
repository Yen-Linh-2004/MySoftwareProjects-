using Quan_Ly_Nha_Hang.Data;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Quan_Ly_Nha_Hang
{
    public partial class Order_DatBan_UserControl : UserControl
    {
        BAN Ban;
        KHACHHANG khach;
        public Order_DatBan_UserControl(BAN ban)
        {
            InitializeComponent();
            this.Ban = ban;

        }
        private KHACHHANG TimkiemkhachHang()
        {
            var sdt = txt_SoDienThoai.Text;
            var Khach = Main_Form.data.KHACHHANG.FirstOrDefault(t => t.SDT == sdt);
            if (Khach != null)
            {
                if (Khach.HotenKH != null)
                {
                    txt_HoTen.Text = Khach.HotenKH.ToString();

                }
                if (Khach.Email != null)
                {

                    txt_Email.Text = Khach.Email;
                }
            }
            return Khach;

        }

        private void txt_SoDienThoai_TextChanged(object sender, EventArgs e)
        {
            if (TimkiemkhachHang() != null)
            {
                khach = TimkiemkhachHang();
                txt_HoTen.Text = khach.HotenKH;
                txt_Email.Text = khach.Email;
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_HoTen.Text))
            {
                MessageBox.Show("Hãy nhập tên khách hàng!", "Bỏ trống thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txt_SoDienThoai.Text))
            {
                MessageBox.Show("Hãy nhập số điện thoại!", "Bỏ trống thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txt_SoDienThoai.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrEmpty(txt_Email.Text) && !txt_Email.Text.EndsWith("@gmail.com"))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var transaction = Main_Form.data.Database.BeginTransaction())
            {
                try
                {
                    // Validate thời gian
                    string thoigian = maskedTextBox1.Text;
                    if (!DateTime.TryParse(thoigian, out DateTime thoiGianDat))
                    {
                        MessageBox.Show("Thời gian không hợp lệ!");
                        return;
                    }
                    if (thoiGianDat <= DateTime.Now)
                    {
                        MessageBox.Show("Thời gian đặt bàn phải sau thời điểm hiện tại!");
                        return;
                    }
                    if (thoiGianDat.Hour < 7 || thoiGianDat.Hour >= 20)
                    {
                        MessageBox.Show("Thời gian đặt bàn phải từ 7h sáng đến 8h tối!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Xử lý thông tin khách hàng
                    try
                    {
                        if (khach == null)
                        {
                            khach = new KHACHHANG
                            {
                                HotenKH = txt_HoTen.Text,
                                SDT = txt_SoDienThoai.Text,
                                Email = txt_Email.Text,
                                LoaiKH = "Khách hàng mới"
                            };
                            if (Main_Form.data.KHACHHANG.FirstOrDefault(t => t.Email == khach.Email && khach.Email != " ") != null)
                            {
                                MessageBox.Show("Email đã sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                khach = null;
                                return;
                            }
                            if (Main_Form.data.KHACHHANG.FirstOrDefault(t => t.SDT == txt_SoDienThoai.Text) != null)
                            {
                                MessageBox.Show("Số điện thoại đã được sử dụng", "Sai thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                khach = null;
                                return;
                            }
                            Main_Form.data.KHACHHANG.Add(khach);
                        }
                        khach.HotenKH = txt_HoTen.Text;
                        khach.SDT = txt_SoDienThoai.Text;
                        khach.Email = txt_Email.Text;
                        Main_Form.data.SaveChanges();
                    }
                    catch
                    {
                        khach = null;
                        MessageBox.Show("Lỗi khi lưu thông tin khách hàng", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }

                    // Tạo đặt bàn
                    DATBAN dATBAN = new DATBAN
                    {
                        IDKhachHang = khach.IDKhachHang
                    };

                    if (DateTime.TryParse(thoigian, out DateTime datetime))
                    {
                        TimeSpan time = datetime.TimeOfDay;
                        dATBAN.GioBD = time;
                        dATBAN.NgayDB = datetime;
                    }
                    if (!string.IsNullOrEmpty(txt_SoLuong.Text))
                    {
                        dATBAN.SoluongBan = Convert.ToInt32(txt_SoLuong.Text);
                    }
                    else
                    {
                        dATBAN.SoluongBan = 0;
                    }

                    // Xử lý danh sách bàn
                    List<string> dsbandat = new List<string>();
                    if (!string.IsNullOrEmpty(txt_ChonBan.Text))
                    {
                        dsbandat = txt_ChonBan.Text.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Distinct()
                            .ToList();
                    }
                    dsbandat.Add(Ban.IDBan.ToString());
                    dsbandat = dsbandat.Distinct().ToList();

                    foreach (string ban in dsbandat)
                    {
                        if (!int.TryParse(ban, out int soBan))
                        {
                            MessageBox.Show($"Số bàn '{ban}' không hợp lệ. Vui lòng chỉ nhập số!");
                            return;
                        }
                        if (soBan <= 0 || soBan > 20)
                        {
                            MessageBox.Show($"Số bàn {soBan} không hợp lệ. Số bàn phải từ 1 đến 20!");
                            return;
                        }
                    }

                    // Sau khi validate xong mới thêm DATBAN
                    Main_Form.data.DATBAN.Add(dATBAN);
                    Main_Form.data.SaveChanges();

                    // Thêm chi tiết đặt bàn
                    foreach (string ban in dsbandat)
                    {
                        int soBan = int.Parse(ban);
                        CHITIETDB cHITIETDB = new CHITIETDB
                        {
                            IDBan = soBan,
                            IDDatBan = dATBAN.IDDatBan,
                            Mota = "Không",
                            YeuCauDB = txt_yeucau.Text,
                        };
                        Main_Form.data.CHITIETDB.Add(cHITIETDB);
                    }
                    Main_Form.data.SaveChanges();

                    transaction.Commit();

                    MessageBox.Show("Đã đặt thành công các Bàn: " + string.Join(", ", dsbandat) + " vào lúc: " + maskedTextBox1.Text);
                    Control parent = this.Parent;
                    parent = parent.Parent;
                    parent.Controls.Clear();
                }
                catch (Exception ex)
                {
                    khach = null;
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception rollbackEx)
                    {
                       
                    }
                    finally
                    {
                        MessageBox.Show("Có lỗi xảy ra trong quá trình đặt bàn: Kiểm tra giờ đặt bàn không được trùng nhau " + ex.Message);
                        if (transaction != null)
                        {
                            transaction.Dispose();
                        }
                    }
                }
            }
        }

        private void txt_SoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError((Control)sender, "Chỉ được nhập số");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txt_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError((Control)sender, "Chỉ được nhập số");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txt_ChonBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
                errorProvider1.SetError((Control)sender, "Nhập bàn với định dạng bàn,bàn,...");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txt_Email_TextChanged(object sender, EventArgs e)
        {
            txt_Email.TextChanged -= txt_Email_TextChanged;
            if (string.IsNullOrWhiteSpace(txt_Email.Text))
            {
                txt_Email.TextChanged += txt_Email_TextChanged;
                return;
            }

            string userInput = txt_Email.Text.Replace("@gmail.com", "");

            txt_Email.Text = userInput + "@gmail.com";

            txt_Email.SelectionStart = userInput.Length;
            txt_Email.SelectionLength = 0;

            txt_Email.TextChanged += txt_Email_TextChanged;
        }
    }
}
