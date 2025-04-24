using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Quan_Ly_Nha_Hang
{
    public partial class ThongKe_Form : Form
    {
        bool tk = false;
        public ThongKe_Form()
        {
            InitializeComponent();
            var yearsList = Main_Form.data.FC_DANHSACHNAM().ToList();

            foreach (var year in yearsList)
            {
                if(year.NAM!=null)
                {
                    if (!comboBox_Nam.Items.Contains(year.NAM))
                    {
                        comboBox_Nam.Items.Add(year.NAM);
                    }
                }    
               
            }
            
        }

        private void setUp()
        {
            comboBox_ngayBatDau.Visible = false;
            comboBox_ngayKetThuc.Visible = false;
            comboBox_Tuan.Visible = false;
            comboBox_Thang.Visible = false;
            comboBox_Nam.Visible = false;
        }
        private void ThongKe_Form_Load(object sender, EventArgs e)
        {
            setUp();
        }

        private void btn_trongNgay_Click(object sender, EventArgs e)
        {
            setUp();
            comboBox_ngayBatDau.Visible = true;
            
            
        }

        private void btn_khoangTG_Click(object sender, EventArgs e)
        {
            setUp();
            comboBox_ngayBatDau.Visible = true;
            comboBox_ngayKetThuc.Visible = true;
        }

        private void btn_Tuan_Click(object sender, EventArgs e)
        {
            setUp();
            comboBox_Tuan.Visible = true;
            comboBox_Thang.Visible = true;
            comboBox_Nam.Visible = true;
            comboBox_Tuan.SelectedIndex = 0;
            comboBox_Thang.SelectedIndex = 0;
            comboBox_Nam.SelectedIndex = 0;
        }

        private void btn_Thang_Click(object sender, EventArgs e)
        {
            setUp();
            comboBox_Nam.Visible = true;
            comboBox_Thang.Visible=true;
            comboBox_Nam.SelectedIndex = 0;
            comboBox_Thang.SelectedIndex=0;
        }

        private void btn_banChay_Click(object sender, EventArgs e)
        {
            setUp();
        }


        private void comboBox_ValueChanged(object sender, EventArgs e)
        {
            comboBox_Validating(sender, new CancelEventArgs());
        }

        void setUpBarChart(Chart chart, DataTable dt, string s)
        {
            chart.DataSource = dt;
            chart.Series[s].XValueMember = "TENTHANHPHAN";
            chart.Series[s].YValueMembers = "TONGDONVI";
            chart.DataBind();
        }
        void setUpPieChart(Chart chart, DataTable dt)
        {
            chart.Series.Clear();
            Series series = new Series
            {
                Name = "Series1",
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true
            };

            foreach (DataRow r in dt.Rows)
            {
                series.Points.AddXY(r["TENTHANHPHAN"], r["TONGDONVI"]);
            }

            chart.Series.Add(series);
            chart.DataBind();
        }

        private void comboBox_Validating(object sender, CancelEventArgs e)
        {
            chart_doanhThu.Controls.Clear();
            DataTable dtDoanhThu = new DataTable();
            DataTable dtKhachHang = new DataTable();
            DataTable dtMonAn = new DataTable();
            DataTable dtNguyenLieu = new DataTable();

            if (comboBox_ngayBatDau.Visible && !comboBox_ngayKetThuc.Visible && !comboBox_Tuan.Visible 
                && !comboBox_Thang.Visible && !comboBox_Nam.Visible)
            {
                dtDoanhThu = Work.setDataTable(Main_Form.data.FC_DOANHTHUTRONGNGAY, 
                    Convert.ToDateTime(comboBox_ngayBatDau.Text));

                dtKhachHang = Work.setDataTable(Main_Form.data.FC_KHACHHANG_TRONGNGAY,
                    Convert.ToDateTime(comboBox_ngayBatDau.Text));

                dtMonAn = Work.setDataTable(Main_Form.data.FC_MONAN_BANCHAY_TRONGNGAY,
                    Convert.ToDateTime(comboBox_ngayBatDau.Text));

                dtNguyenLieu = Work.setDataTable(Main_Form.data.FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGNGAY,
                    Convert.ToDateTime(comboBox_ngayBatDau.Text));

            }
            else if (comboBox_ngayBatDau.Visible && comboBox_ngayKetThuc.Visible && !comboBox_Tuan.Visible 
                && !comboBox_Thang.Visible && !comboBox_Nam.Visible)
            {
                dtDoanhThu = Work.setDataTable(Main_Form.data.FC_DOANHTHUTRONGKHOANGTG, 
                    Convert.ToDateTime(comboBox_ngayBatDau.Text),
                    Convert.ToDateTime(comboBox_ngayKetThuc.Text));

                dtKhachHang = Work.setDataTable(Main_Form.data.FC_KHACHHANG_TRONGKHOANGTG,
                   Convert.ToDateTime(comboBox_ngayBatDau.Text),
                   Convert.ToDateTime(comboBox_ngayKetThuc.Text));

                dtMonAn = Work.setDataTable(Main_Form.data.FC_MONAN_BANCHAY_TRONGKHOANGTG,
                   Convert.ToDateTime(comboBox_ngayBatDau.Text),
                   Convert.ToDateTime(comboBox_ngayKetThuc.Text));

                dtNguyenLieu = Work.setDataTable(Main_Form.data.FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGKHOANGTG,
                   Convert.ToDateTime(comboBox_ngayBatDau.Text),
                   Convert.ToDateTime(comboBox_ngayKetThuc.Text));
            }
            else if(!comboBox_ngayBatDau.Visible && !comboBox_ngayKetThuc.Visible
                && comboBox_Tuan.Visible && comboBox_Thang.Visible && comboBox_Nam.Visible)
            {
                if (comboBox_Nam.Text != "Chọn năm" && comboBox_Thang.Text != "Chọn tháng" && comboBox_Tuan.Text != "Chọn tuần")
                {
                    dtDoanhThu = Work.setDataTable(Main_Form.data.FC_DANHTHUTRONGTUAN, 
                        Convert.ToUInt16(comboBox_Tuan.Text), 
                        Convert.ToUInt16(comboBox_Thang.Text), 
                        Convert.ToUInt16(comboBox_Nam.Text));

                    dtKhachHang = Work.setDataTable(Main_Form.data.FC_KHACHHANG_TRONGTUAN,
                        Convert.ToUInt16(comboBox_Tuan.Text),
                        Convert.ToUInt16(comboBox_Thang.Text),
                        Convert.ToUInt16(comboBox_Nam.Text));

                    dtMonAn = Work.setDataTable(Main_Form.data.FC_MONAN_BANCHAY_TRONGTUAN,
                        Convert.ToUInt16(comboBox_Tuan.Text),
                        Convert.ToUInt16(comboBox_Thang.Text),
                        Convert.ToUInt16(comboBox_Nam.Text));

                    dtNguyenLieu = Work.setDataTable(Main_Form.data.FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGTUAN,
                        Convert.ToUInt16(comboBox_Tuan.Text),
                        Convert.ToUInt16(comboBox_Thang.Text),
                        Convert.ToUInt16(comboBox_Nam.Text));

                }
            }
            else if (!comboBox_ngayBatDau.Visible && !comboBox_ngayKetThuc.Visible
                && !comboBox_Tuan.Visible && comboBox_Thang.Visible && comboBox_Nam.Visible)
            {
                if (comboBox_Nam.Text != "Chọn năm" && !comboBox_Thang.Text.Contains("Chọn tháng"))
                {
                    dtDoanhThu = Work.setDataTable(Main_Form.data.FC_DANHTHUTRONGTHANG, 
                        Convert.ToInt16(comboBox_Thang.Text), 
                        Convert.ToInt16(comboBox_Nam.Text));

                    dtKhachHang = Work.setDataTable(Main_Form.data.FC_KHACHHANG_TRONGTHANG,
                        Convert.ToInt16(comboBox_Thang.Text),
                        Convert.ToInt16(comboBox_Nam.Text));

                    dtMonAn = Work.setDataTable(Main_Form.data.FC_MONAN_BANCHAY_TRONGTHANG,
                        Convert.ToInt16(comboBox_Thang.Text),
                        Convert.ToInt16(comboBox_Nam.Text));

                    dtNguyenLieu = Work.setDataTable(Main_Form.data.FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGTHANG,
                        Convert.ToInt16(comboBox_Thang.Text),
                        Convert.ToInt16(comboBox_Nam.Text));
                }
            }
            else if (!comboBox_ngayBatDau.Visible && !comboBox_ngayKetThuc.Visible
                && !comboBox_Tuan.Visible && !comboBox_Thang.Visible && comboBox_Nam.Visible)
            {
                if (comboBox_Nam.Text != "Chọn năm")
                {
                    dtDoanhThu = Work.setDataTable(Main_Form.data.FC_DANHTHUTRONGNAM,
                        Convert.ToInt16(comboBox_Nam.Text));

                    dtKhachHang = Work.setDataTable(Main_Form.data.FC_KHACHHANG_TRONGNAM,
                        Convert.ToInt16(comboBox_Nam.Text));

                    dtMonAn = Work.setDataTable(Main_Form.data.FC_MONAN_BANCHAY_TRONGNAM,
                        Convert.ToInt16(comboBox_Nam.Text));

                    dtNguyenLieu = Work.setDataTable(Main_Form.data.FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGNAM,
                        Convert.ToInt16(comboBox_Nam.Text));
                }
            }

            setUpBarChart(chart_doanhThu, dtDoanhThu, "Doanh thu");
            setUpBarChart(chart_khachHang, dtKhachHang, "Khách hàng");
            setUpPieChart(chart_monAn, dtMonAn);
            setUpBarChart(chart_nguyenLieu, dtNguyenLieu, "Nguyên liệu");
            
        }

        private void btn_Nam_Click(object sender, EventArgs e)
        {
            setUp();
            comboBox_Nam.Visible = true;
            comboBox_Nam.SelectedIndex = 0;
        }
    }
}
