using Quan_Ly_Nha_Hang.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_Ly_Nha_Hang.Data;
namespace Quan_Ly_Nha_Hang
{
    public static class Work
    {
        public static void OpenFormChild(Form child,Panel parent_panel)
        {
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            parent_panel.Controls.Add(child);
            parent_panel.Tag = child;
            parent_panel.BringToFront();
            child.Dock = DockStyle.Fill;
            child.BringToFront();
            child.Show();
        }
        //khoi tao danh thu
        public delegate IQueryable<FC_DOANHTHUTRONGNGAY_Result> DoanhThuTrongNgay(DateTime? date);
        public delegate IQueryable<FC_DOANHTHUTRONGKHOANGTG_Result> DoanhThuiTrongKhoangTG(DateTime? date1, DateTime? date2);
        public delegate IQueryable<FC_DANHTHUTRONGTUAN_Result> DoanhThuTrongTuan(int? week, int? month, int? year);
        public delegate IQueryable<FC_DANHTHUTRONGTHANG_Result> DoanhThuTrongThang(int? month, int? year);
        public delegate IQueryable<FC_DANHTHUTRONGNAM_Result> DoanhThuTrongNam(int? year);

        public static DataTable setDataForDataTable(List<Thongke> data)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TONGDONVI", typeof(double));
            dt.Columns.Add("TENTHANHPHAN", typeof(string));
            foreach (var dthu in data)
            {
                DataRow row = dt.NewRow();
                if (dthu.TongDonVi != null)
                {
                    row["TONGDONVI"] = dthu.TongDonVi;
                    row["TENTHANHPHAN"] = dthu.TenThanhPhan;
                    dt.Rows.Add(row);
                }
                else
                {
                    row["TONGDONVI"] = 0;
                    row["TENTHANHPHAN"] = dthu.TenThanhPhan;
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }

        public static DataTable setDataTable(DoanhThuTrongNgay data, DateTime date)
        {

            List<Thongke> doanhThu = data(date).ToList().Select(x => new Thongke()
            {
                TongDonVi = Convert.ToDouble(x.TONGDONVI),
                TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
            }).ToList();


            return setDataForDataTable(doanhThu);
        }

        public static DataTable setDataTable(DoanhThuiTrongKhoangTG data, DateTime date1, DateTime date2)
        {

            List<Thongke> doanhThu = data(date1, date2).ToList().Select(x => new Thongke()
            {
                TongDonVi = Convert.ToDouble(x.TONGDONVI),
                TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
            }).ToList();


            return setDataForDataTable(doanhThu);
        }

        public static DataTable setDataTable(DoanhThuTrongTuan data, int week, int month, int year)
        {

            List<Thongke> doanhThu = data(week, month, year).ToList().Select(x => new Thongke()
            {
                TongDonVi = Convert.ToDouble(x.TONGDONVI),
                TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
            }).ToList();


            return setDataForDataTable(doanhThu);
        }

        public static DataTable setDataTable(DoanhThuTrongThang data, int month, int year)
        {

            List<Thongke> doanhThu = data(month, year).ToList().Select(x => new Thongke()
            {
                TongDonVi = Convert.ToDouble(x.TONGDONVI),
                TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
            }).ToList();


            return setDataForDataTable(doanhThu);
        }

        public static DataTable setDataTable(DoanhThuTrongNam data, int year)
        {

            List<Thongke> doanhThu = data(year).ToList().Select(x => new Thongke()
            {
                TongDonVi = Convert.ToDouble(x.TONGDONVI),
                TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
            }).ToList();


            return setDataForDataTable(doanhThu);
        }

        //khoi tao khach hang
        public delegate IQueryable<FC_KHACHHANG_TRONGNGAY_Result> KhacHang_TrongNgay(DateTime? date);
        public delegate IQueryable<FC_KHACHHANG_TRONGKHOANGTG_Result> KhacHang_TrongKhoangTG(DateTime? date1, DateTime? date2);
        public delegate IQueryable<FC_KHACHHANG_TRONGTUAN_Result> KhacHang_TrongTuan(int? week, int? month, int? year);
        public delegate IQueryable<FC_KHACHHANG_TRONGTHANG_Result> KhacHang_TrongThang(int? month, int? year);
        public delegate IQueryable<FC_KHACHHANG_TRONGNAM_Result> KhacHang_TrongNam(int? year);
        public static DataTable setDataTable(KhacHang_TrongNgay data, DateTime date)
        {

            List<Thongke> khachHang = data(date).ToList().Select(x => new Thongke()
            {
                TongDonVi = Convert.ToDouble(x.TONGDONVI),
                TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
            }).ToList();


            return setDataForDataTable(khachHang);
        }

        public static DataTable setDataTable(KhacHang_TrongKhoangTG data, DateTime date1, DateTime date2)
        {

            List<Thongke> khachHang = data(date1, date2).ToList().Select(x => new Thongke()
            {
                TongDonVi = Convert.ToDouble(x.TONGDONVI),
                TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
            }).ToList();


            return setDataForDataTable(khachHang);
        }

        public static DataTable setDataTable(KhacHang_TrongTuan data, int week, int month, int year)
        {

            List<Thongke> khachHang = data(week, month, year).ToList().Select(x => new Thongke()
            {
                TongDonVi = Convert.ToDouble(x.TONGDONVI),
                TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
            }).ToList();


            return setDataForDataTable(khachHang);
        }

        public static DataTable setDataTable(KhacHang_TrongThang data, int month, int year)
        {

            List<Thongke> khachHang = data(month, year).ToList().Select(x => new Thongke()
            {
                TongDonVi = Convert.ToDouble(x.TONGDONVI),
                TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
            }).ToList();


            return setDataForDataTable(khachHang);
        }

        public static DataTable setDataTable(KhacHang_TrongNam data, int year)
        {

            List<Thongke> doanhThu = data(year).ToList().Select(x => new Thongke()
            {
                TongDonVi = Convert.ToDouble(x.TONGDONVI),
                TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
            }).ToList();


            return setDataForDataTable(doanhThu);
        }

        public delegate IQueryable<FC_MONAN_BANCHAY_TRONGNGAY_Result> MonAn_TrongNgay(DateTime? date);
        public delegate IQueryable<FC_MONAN_BANCHAY_TRONGKHOANGTG_Result> MonAn_TrongKhoangTG(DateTime? date1, DateTime? date2);
        public delegate IQueryable<FC_MONAN_BANCHAY_TRONGTUAN_Result> MonAn_TrongTuan(int? week, int? month, int? year);
        public delegate IQueryable<FC_MONAN_BANCHAY_TRONGTHANG_Result> MonAn_TrongThang(int? month, int? year);
        public delegate IQueryable<FC_MONAN_BANCHAY_TRONGNAM_Result> MonAn_TrongNam(int? year);

        public static DataTable setDataTable(MonAn_TrongNgay data, DateTime date)
        {
            double sum = Convert.ToDouble(Main_Form.data.FC_MONAN_TONGSOLUONG_TRONGNGAY(date).SingleOrDefault());

            List<Thongke> monAn = data(date).ToList().Select(x =>
            {
                sum -= Convert.ToDouble(x.TONGDONVI);
                return new Thongke()
                {
                    TongDonVi = Convert.ToDouble(x.TONGDONVI),
                    TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
                };
            }).ToList();


            return setDataForDataTable(monAn);
        }

        public static DataTable setDataTable(MonAn_TrongKhoangTG data, DateTime date1, DateTime date2)
        {
            double sum = Convert.ToDouble(Main_Form.data.FC_MONAN_TONGSOLUONG_TRONGKHOANGTG(date1, date2).SingleOrDefault());

            List<Thongke> monAn = data(date1, date2).ToList().Select(x =>
            {
                sum -= Convert.ToDouble(x.TONGDONVI);
                return new Thongke()
                {
                    TongDonVi = Convert.ToDouble(x.TONGDONVI),
                    TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
                };
            }).ToList();


            Thongke thongke = new Thongke()
            {
                TenThanhPhan = "Khác",
                TongDonVi = sum
            };
            monAn.Add(thongke);


            return setDataForDataTable(monAn);
        }

        public static DataTable setDataTable(MonAn_TrongTuan data, int week, int month, int year)
        {
            double sum = Convert.ToDouble(Main_Form.data.FC_MONAN_TONGSOLUONG_TRONGTUAN(week, month, year).SingleOrDefault());

            List<Thongke> monAn = data(week, month, year).ToList().Select(x =>
            {
                sum -= Convert.ToDouble(x.TONGDONVI);
                return new Thongke()
                {
                    TongDonVi = Convert.ToDouble(x.TONGDONVI),
                    TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
                };
            }).ToList();


            Thongke thongke = new Thongke()
            {
                TenThanhPhan = "Khác",
                TongDonVi = sum
            };
            monAn.Add(thongke);

            return setDataForDataTable(monAn);
        }

        public static DataTable setDataTable(MonAn_TrongThang data, int month, int year)
        {
            double sum = Convert.ToDouble(Main_Form.data.FC_MONAN_TONGSOLUONG_TRONGTHANG(month, year).SingleOrDefault());

            List<Thongke> monAn = data(month, year).ToList().Select(x =>
            {
                sum -= Convert.ToDouble(x.TONGDONVI);
                return new Thongke()
                {
                    TongDonVi = Convert.ToDouble(x.TONGDONVI),
                    TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
                };
            }).ToList();


            Thongke thongke = new Thongke()
            {
                TenThanhPhan = "Khác",
                TongDonVi = sum
            };
            monAn.Add(thongke);

            return setDataForDataTable(monAn);
        }

        public static DataTable setDataTable(MonAn_TrongNam data, int year)
        {
            double sum = Convert.ToDouble(Main_Form.data.FC_MONAN_TONGSOLUONG_TRONGNAM(year).SingleOrDefault());

            List<Thongke> monAn = data(year).ToList().Select(x =>
            {
                sum -= Convert.ToDouble(x.TONGDONVI);
                return new Thongke()
                {
                    TongDonVi = Convert.ToDouble(x.TONGDONVI),
                    TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
                };
            }).ToList();


            Thongke thongke = new Thongke()
            {
                TenThanhPhan = "Khác",
                TongDonVi = sum
            };
            monAn.Add(thongke);


            return setDataForDataTable(monAn);
        }

        public delegate IQueryable<FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGNGAY_Result> NguyenLieu_TrongNgay(DateTime? date);
        public delegate IQueryable<FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGKHOANGTG_Result> NguyenLieu_TrongKhoangTG(DateTime? date1, DateTime? date2);
        public delegate IQueryable<FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGTUAN_Result> NguyenLieu_TrongTuan(int? week, int? month, int? year);
        public delegate IQueryable<FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGTHANG_Result> NguyenLieu_TrongThang(int? month, int? year);
        public delegate IQueryable<FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGNAM_Result> NguyenLieu_TrongNam(int? year);

        public static DataTable setDataTable(NguyenLieu_TrongNgay data, DateTime date)
        {
            List<Thongke> nguyenLieu = data(date).ToList().Select(x =>
            {
                return new Thongke()
                {
                    TongDonVi = Convert.ToDouble(x.TONGDONVI),
                    TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
                };
            }).ToList();


            return setDataForDataTable(nguyenLieu);
        }

        public static DataTable setDataTable(NguyenLieu_TrongKhoangTG data, DateTime date1, DateTime date2)
        {
            List<Thongke> nguyenLieu = data(date1, date2).ToList().Select(x =>
            {
                return new Thongke()
                {
                    TongDonVi = Convert.ToDouble(x.TONGDONVI),
                    TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
                };
            }).ToList();


            return setDataForDataTable(nguyenLieu);
        }

        public static DataTable setDataTable(NguyenLieu_TrongTuan data, int week, int month, int year)
        {
            List<Thongke> nguyenLieu = data(week, month, year).ToList().Select(x =>
            {
                return new Thongke()
                {
                    TongDonVi = Convert.ToDouble(x.TONGDONVI),
                    TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
                };
            }).ToList();


            return setDataForDataTable(nguyenLieu);
        }

        public static DataTable setDataTable(NguyenLieu_TrongThang data, int month, int year)
        {
            List<Thongke> nguyenLieu = data(month, year).ToList().Select(x =>
            {
                return new Thongke()
                {
                    TongDonVi = Convert.ToDouble(x.TONGDONVI),
                    TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
                };
            }).ToList();


            return setDataForDataTable(nguyenLieu);
        }

        public static DataTable setDataTable(NguyenLieu_TrongNam data, int year)
        {
            List<Thongke> nguyenLieu = data(year).ToList().Select(x =>
            {
                return new Thongke()
                {
                    TongDonVi = Convert.ToDouble(x.TONGDONVI),
                    TenThanhPhan = Convert.ToString(x.TENTHANHPHAN)
                };
            }).ToList();

            return setDataForDataTable(nguyenLieu);
        }
    }
}
