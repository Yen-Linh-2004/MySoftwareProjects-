using Quan_Ly_Nha_Hang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Nha_Hang
{
    public partial class ThucDon_ChiTietMonAn_UserControl : UserControl
    {
        private MON mon;
        bool themmoi = false;

        public ThucDon_ChiTietMonAn_UserControl()
        {
            mon = new MON();
            InitializeComponent();
            LoadDanhMucMonAn();
            LoadNguyenLieuChinh();
            themmoi = true;
        }

        public ThucDon_ChiTietMonAn_UserControl(MON MON)
        {
            InitializeComponent();
            this.mon = MON;
            LoadDanhMucMonAn();
            LoadNguyenLieuChinh();
            LoadDuLieuMonAn();
        }
        private void LoadDanhMucMonAn()
        {
            comboBox_DanhMuc.DataSource = Main_Form.data.LOAIMON.ToList();
            comboBox_DanhMuc.DisplayMember = "TenLoaiMon";
            comboBox_DanhMuc.ValueMember = "IDLoaiMon";
        }
        private void LoadNguyenLieuChinh()
        {
            comboBox_NguyenLieuChinh.DataSource = Main_Form.data.NGUYENLIEU.ToList();
            comboBox_NguyenLieuChinh.ValueMember = "IDNguyenLieu";
            comboBox_NguyenLieuChinh.DisplayMember = "TenNguyenLieu";
        }
        private void LoadDuLieuMonAn()
        {
            if (mon != null && themmoi == false)
            {
                txt_TenMon.Text = mon.TenMon;
                txt_GiaMon.Text = mon.DonGia.ToString();
                txt_MoTa.Text = mon.MoTa;
                txt_TenAnh.Text = mon.HinhAnh;
                comboBox_DanhMuc.Text = mon.LOAIMON.TenLoaiMon;
                var chiTietMon = Main_Form.data.CHITIETMON.Find(mon.IDMon);
                if (chiTietMon != null)
                {
                    var nguyenLieu = Main_Form.data.NGUYENLIEU.FirstOrDefault(nl => nl.IDNguyenLieu == chiTietMon.IDNguyenLieu);
                    if (nguyenLieu != null)
                    {
                        comboBox_NguyenLieuChinh.Text = nguyenLieu.TenNguyenLieu;
                        txt_SoLuong.Text = chiTietMon.Soluong.ToString();
                    }
                }
                string imgFolderPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\QLNHimg"));
                try
                {
                    guna2PictureBox1.Image = Image.FromFile(Path.Combine(imgFolderPath, mon.HinhAnh));
                }
                catch
                {
                    guna2PictureBox1.Image = Image.FromFile(Path.Combine(imgFolderPath, "Gà nướng.jpg"));
                }

                if (mon.TrangThai == "Có sẵn")
                {
                    rbtn_ConMon.Checked = true;
                }
                else { rbtn_HetMon.Checked = true; }

            }
        }
        private void btn_ChonAnh_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Image Files|*.png;*.jpg;*.jpeg";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFile.FileName;
                    string imgFolderPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\QLNHimg"));
                    if (!Directory.Exists(imgFolderPath))
                    {
                        Directory.CreateDirectory(imgFolderPath);
                    }
                    if (guna2PictureBox1.Image != null)
                    {
                        guna2PictureBox1.Image.Dispose();
                        guna2PictureBox1.Image = null;
                    }
                    string fileName = Path.GetFileName(openFile.FileName);
                    string destinationPath = Path.Combine(imgFolderPath, fileName);
                    if (File.Exists(destinationPath))
                    {
                        MessageBox.Show("Ảnh này đã tồn tại trong thư mục!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    guna2PictureBox1.Image = Image.FromFile(selectedFilePath);
                    txt_TenAnh.Text = fileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Themmonmoi()
        {
            if (string.IsNullOrEmpty(txt_TenMon.Text))
            {
                MessageBox.Show("Hãy nhập tên món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txt_GiaMon.Text))
            {
                MessageBox.Show("Hãy nhập giá món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txt_MoTa.Text))
            {
                MessageBox.Show("Hãy nhập mô tả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txt_SoLuong.Text))
            {
                MessageBox.Show("Hãy nhập số lượng của nguyên liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                mon = new MON();
                if (Main_Form.data.MON.Any(t => t.TenMon == txt_TenMon.Text))
                {
                    MessageBox.Show("Tên món đã được sử dụng!", "Thông báo",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                mon.TenMon = txt_TenMon.Text;
                mon.MoTa = txt_MoTa.Text;
                mon.DonGia = double.TryParse(txt_GiaMon.Text.Replace(" VNĐ", "").Replace(",", ""), out double giaMon) ? giaMon : 0;
                if (rbtn_ConMon.Checked)
                {
                    mon.TrangThai = "Có sẵn";
                }
                else
                {
                    mon.TrangThai = "Hết món";
                }
                try
                {
                    if (string.IsNullOrEmpty(txt_TenAnh.Text))
                    {
                        MessageBox.Show("Vui lòng chọn ảnh trước khi lưu!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra tên file hợp lệ
                    if (txt_TenAnh.Text.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                    {
                        MessageBox.Show("Tên file ảnh không hợp lệ!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string imgFolderPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\QLNHimg"));
                    if (!Directory.Exists(imgFolderPath))
                    {
                        Directory.CreateDirectory(imgFolderPath);
                    }

                    string imagePath = Path.Combine(imgFolderPath, txt_TenAnh.Text);

                    if (guna2PictureBox1.Image != null)
                    {
                        // Kiểm tra xem ảnh có tồn tại chưa
                        try
                        {
                            if (File.Exists(imagePath))
                            {
                                File.Delete(imagePath);
                            }

                            // Xử lý ảnh để giữ độ trong suốt
                            using (Bitmap originalBitmap = new Bitmap(guna2PictureBox1.Image))
                            {
                                // Tạo một bitmap mới với định dạng 32bit ARGB để hỗ trợ độ trong suốt
                                using (Bitmap newBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                                {
                                    using (Graphics g = Graphics.FromImage(newBitmap))
                                    {
                                        // Thiết lập chất lượng vẽ
                                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                                        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                                        // Vẽ ảnh gốc lên bitmap mới
                                        g.DrawImage(originalBitmap, 0, 0);
                                    }

                                    // Lưu ảnh với định dạng PNG để giữ độ trong suốt
                                    newBitmap.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
                                }
                            }
                            MessageBox.Show("Lưu ảnh thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Có lỗi xảy ra khi lưu ảnh: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    mon.HinhAnh = txt_TenAnh.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi xử lý ảnh: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LOAIMON selectedLoaiMon = (LOAIMON)comboBox_DanhMuc.SelectedItem;
                mon.IDLoaiMon = selectedLoaiMon.IDLoaiMon;


                Main_Form.data.MON.Add(mon);
                Main_Form.data.SaveChanges();

                CHITIETMON ct = new CHITIETMON();
                ct.IDMon = mon.IDMon;
                NGUYENLIEU selectNGuyenLieu = (NGUYENLIEU)comboBox_NguyenLieuChinh.SelectedItem;
                ct.IDNguyenLieu = selectNGuyenLieu.IDNguyenLieu;
                ct.Soluong = Convert.ToDouble(txt_SoLuong.Text);
                Main_Form.data.CHITIETMON.Add(ct);
                Main_Form.data.SaveChanges();
                MessageBox.Show("Đã thêm món thành công!", "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm món không thành công! Có lỗi xảy ra trong quá trình lưu!", "Thông báo",
     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SuaMon()
        {
            if (string.IsNullOrEmpty(txt_TenMon.Text))
            {
                MessageBox.Show("Hãy nhập tên món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txt_GiaMon.Text))
            {
                MessageBox.Show("Hãy nhập giá món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txt_MoTa.Text))
            {
                MessageBox.Show("Hãy nhập mô tả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txt_SoLuong.Text))
            {
                MessageBox.Show("Hãy nhập số lượng của nguyên liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var monsua = Main_Form.data.MON.Find(mon.IDMon);
                if (Main_Form.data.MON.Any(t => t.TenMon == txt_TenMon.Text && t.IDMon != monsua.IDMon))
                {
                    MessageBox.Show("Tên món đã được sử dụng!", "Thông báo",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                monsua.TenMon = txt_TenMon.Text;
                monsua.MoTa = txt_MoTa.Text;
                monsua.DonGia = double.TryParse(txt_GiaMon.Text.Replace(" VNĐ", "").Replace(",", ""), out double giaMon) ? giaMon : 0;
                string anhcu = monsua.HinhAnh;
                if (rbtn_ConMon.Checked)
                {
                    monsua.TrangThai = "Có sẵn";
                }
                else
                {
                    monsua.TrangThai = "Hết món";
                }
                try
                {
                    if (txt_TenAnh.Text != monsua.HinhAnh)
                    {
                        if (txt_TenAnh.Text.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                        {
                            MessageBox.Show("Tên file ảnh không hợp lệ!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string imgFolderPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\QLNHimg"));
                        if (!Directory.Exists(imgFolderPath))
                        {
                            Directory.CreateDirectory(imgFolderPath);
                        }

                        string imagePath = Path.Combine(imgFolderPath, txt_TenAnh.Text);

                        if (guna2PictureBox1.Image != null)
                        {
                            // Kiểm tra xem ảnh có tồn tại chưa
                            try
                            {
                                if (File.Exists(imagePath))
                                {
                                    File.Delete(imagePath);
                                }
                                using (Bitmap originalBitmap = new Bitmap(guna2PictureBox1.Image))
                                {
                                    using (Bitmap newBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                                    {
                                        using (Graphics g = Graphics.FromImage(newBitmap))
                                        {

                                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                                            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;


                                            g.DrawImage(originalBitmap, 0, 0);
                                        }

                                        newBitmap.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
                                    }
                                }
                                MessageBox.Show("Lưu ảnh thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Có lỗi xảy ra khi lưu ảnh: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    monsua.HinhAnh = txt_TenAnh.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi xử lý ảnh: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                monsua.IDLoaiMon = (int)comboBox_DanhMuc.SelectedValue;
                var cthdcu = Main_Form.data.CHITIETMON.FirstOrDefault(t => t.IDMon == monsua.IDMon);
                if (cthdcu != null)
                {
                    Main_Form.data.CHITIETMON.Remove(cthdcu);
                }
                CHITIETMON ctmmoi = new CHITIETMON();
                ctmmoi.IDMon = monsua.IDMon;
                ctmmoi.Soluong = Convert.ToDouble(txt_SoLuong.Text);
                ctmmoi.IDNguyenLieu = (int)comboBox_NguyenLieuChinh.SelectedValue;
                Main_Form.data.CHITIETMON.Add(ctmmoi);
                Main_Form.data.SaveChanges();
                MessageBox.Show("Đã sửa món thành công!", "Thông báo",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Sửa món không thành công! Có lỗi xảy ra trong quá trình lưu!", "Thông báo",
     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (themmoi)
                {
                    Themmonmoi();
                }
                else
                {
                    SuaMon();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi lưu ảnh: " + ex.Message, "Lỗi",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txt_GiaMon_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txt_GiaMon.Text.Replace(" VNĐ", "").Replace(",", ""), out double value))
            {
                txt_GiaMon.Text = value.ToString("#,##0") + " VNĐ";
                txt_GiaMon.SelectionStart = txt_GiaMon.TextLength;

            }
            else
            {
                txt_GiaMon.Text = string.Empty;
            }
        }

        private void txt_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError((Control)sender, "Chỉ được nhập số");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txt_GiaMon_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
