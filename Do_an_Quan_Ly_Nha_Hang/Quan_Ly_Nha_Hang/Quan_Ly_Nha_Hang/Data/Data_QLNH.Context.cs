﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quan_Ly_Nha_Hang.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class QL_NHAHANGEntities : DbContext
    {
        public QL_NHAHANGEntities()
            : base("name=QL_NHAHANGEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BAN> BAN { get; set; }
        public virtual DbSet<CALAMVIEC> CALAMVIEC { get; set; }
        public virtual DbSet<CHITIETDB> CHITIETDB { get; set; }
        public virtual DbSet<CHITIETMON> CHITIETMON { get; set; }
        public virtual DbSet<CHITIETPN> CHITIETPN { get; set; }
        public virtual DbSet<CHITIETHD> CHITIETHD { get; set; }
        public virtual DbSet<CHUCVU> CHUCVU { get; set; }
        public virtual DbSet<DATBAN> DATBAN { get; set; }
        public virtual DbSet<HOADON> HOADON { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANG { get; set; }
        public virtual DbSet<KHUYENMAI> KHUYENMAI { get; set; }
        public virtual DbSet<LOAIMON> LOAIMON { get; set; }
        public virtual DbSet<MON> MON { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNG { get; set; }
        public virtual DbSet<NGUYENLIEU> NGUYENLIEU { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAP { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIEN { get; set; }
        public virtual DbSet<PHANCONG> PHANCONG { get; set; }
        public virtual DbSet<PHIEUNHAP> PHIEUNHAP { get; set; }
    
        [DbFunction("QL_NHAHANGEntities", "FC_DANHSACHNAM")]
        public virtual IQueryable<FC_DANHSACHNAM_Result> FC_DANHSACHNAM()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_DANHSACHNAM_Result>("[QL_NHAHANGEntities].[FC_DANHSACHNAM]()");
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_DANHTHUTRONGNAM")]
        public virtual IQueryable<FC_DANHTHUTRONGNAM_Result> FC_DANHTHUTRONGNAM(Nullable<int> nAM)
        {
            var nAMParameter = nAM.HasValue ?
                new ObjectParameter("NAM", nAM) :
                new ObjectParameter("NAM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_DANHTHUTRONGNAM_Result>("[QL_NHAHANGEntities].[FC_DANHTHUTRONGNAM](@NAM)", nAMParameter);
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_DANHTHUTRONGTHANG")]
        public virtual IQueryable<FC_DANHTHUTRONGTHANG_Result> FC_DANHTHUTRONGTHANG(Nullable<int> tHANG, Nullable<int> nAM)
        {
            var tHANGParameter = tHANG.HasValue ?
                new ObjectParameter("THANG", tHANG) :
                new ObjectParameter("THANG", typeof(int));
    
            var nAMParameter = nAM.HasValue ?
                new ObjectParameter("NAM", nAM) :
                new ObjectParameter("NAM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_DANHTHUTRONGTHANG_Result>("[QL_NHAHANGEntities].[FC_DANHTHUTRONGTHANG](@THANG, @NAM)", tHANGParameter, nAMParameter);
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_DANHTHUTRONGTUAN")]
        public virtual IQueryable<FC_DANHTHUTRONGTUAN_Result> FC_DANHTHUTRONGTUAN(Nullable<int> tUAN, Nullable<int> tHANG, Nullable<int> nAM)
        {
            var tUANParameter = tUAN.HasValue ?
                new ObjectParameter("TUAN", tUAN) :
                new ObjectParameter("TUAN", typeof(int));
    
            var tHANGParameter = tHANG.HasValue ?
                new ObjectParameter("THANG", tHANG) :
                new ObjectParameter("THANG", typeof(int));
    
            var nAMParameter = nAM.HasValue ?
                new ObjectParameter("NAM", nAM) :
                new ObjectParameter("NAM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_DANHTHUTRONGTUAN_Result>("[QL_NHAHANGEntities].[FC_DANHTHUTRONGTUAN](@TUAN, @THANG, @NAM)", tUANParameter, tHANGParameter, nAMParameter);
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_DOANHTHUTRONGKHOANGTG")]
        public virtual IQueryable<FC_DOANHTHUTRONGKHOANGTG_Result> FC_DOANHTHUTRONGKHOANGTG(Nullable<System.DateTime> dAYX, Nullable<System.DateTime> dAYY)
        {
            var dAYXParameter = dAYX.HasValue ?
                new ObjectParameter("DAYX", dAYX) :
                new ObjectParameter("DAYX", typeof(System.DateTime));
    
            var dAYYParameter = dAYY.HasValue ?
                new ObjectParameter("DAYY", dAYY) :
                new ObjectParameter("DAYY", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_DOANHTHUTRONGKHOANGTG_Result>("[QL_NHAHANGEntities].[FC_DOANHTHUTRONGKHOANGTG](@DAYX, @DAYY)", dAYXParameter, dAYYParameter);
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_DOANHTHUTRONGNGAY")]
        public virtual IQueryable<FC_DOANHTHUTRONGNGAY_Result> FC_DOANHTHUTRONGNGAY(Nullable<System.DateTime> dAY)
        {
            var dAYParameter = dAY.HasValue ?
                new ObjectParameter("DAY", dAY) :
                new ObjectParameter("DAY", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_DOANHTHUTRONGNGAY_Result>("[QL_NHAHANGEntities].[FC_DOANHTHUTRONGNGAY](@DAY)", dAYParameter);
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_KHACHHANG_TRONGKHOANGTG")]
        public virtual IQueryable<FC_KHACHHANG_TRONGKHOANGTG_Result> FC_KHACHHANG_TRONGKHOANGTG(Nullable<System.DateTime> dAYX, Nullable<System.DateTime> dAYY)
        {
            var dAYXParameter = dAYX.HasValue ?
                new ObjectParameter("DAYX", dAYX) :
                new ObjectParameter("DAYX", typeof(System.DateTime));
    
            var dAYYParameter = dAYY.HasValue ?
                new ObjectParameter("DAYY", dAYY) :
                new ObjectParameter("DAYY", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_KHACHHANG_TRONGKHOANGTG_Result>("[QL_NHAHANGEntities].[FC_KHACHHANG_TRONGKHOANGTG](@DAYX, @DAYY)", dAYXParameter, dAYYParameter);
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_KHACHHANG_TRONGNAM")]
        public virtual IQueryable<FC_KHACHHANG_TRONGNAM_Result> FC_KHACHHANG_TRONGNAM(Nullable<int> nAM)
        {
            var nAMParameter = nAM.HasValue ?
                new ObjectParameter("NAM", nAM) :
                new ObjectParameter("NAM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_KHACHHANG_TRONGNAM_Result>("[QL_NHAHANGEntities].[FC_KHACHHANG_TRONGNAM](@NAM)", nAMParameter);
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_KHACHHANG_TRONGNGAY")]
        public virtual IQueryable<FC_KHACHHANG_TRONGNGAY_Result> FC_KHACHHANG_TRONGNGAY(Nullable<System.DateTime> dAY)
        {
            var dAYParameter = dAY.HasValue ?
                new ObjectParameter("DAY", dAY) :
                new ObjectParameter("DAY", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_KHACHHANG_TRONGNGAY_Result>("[QL_NHAHANGEntities].[FC_KHACHHANG_TRONGNGAY](@DAY)", dAYParameter);
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_KHACHHANG_TRONGTHANG")]
        public virtual IQueryable<FC_KHACHHANG_TRONGTHANG_Result> FC_KHACHHANG_TRONGTHANG(Nullable<int> tHANG, Nullable<int> nAM)
        {
            var tHANGParameter = tHANG.HasValue ?
                new ObjectParameter("THANG", tHANG) :
                new ObjectParameter("THANG", typeof(int));
    
            var nAMParameter = nAM.HasValue ?
                new ObjectParameter("NAM", nAM) :
                new ObjectParameter("NAM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_KHACHHANG_TRONGTHANG_Result>("[QL_NHAHANGEntities].[FC_KHACHHANG_TRONGTHANG](@THANG, @NAM)", tHANGParameter, nAMParameter);
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_KHACHHANG_TRONGTUAN")]
        public virtual IQueryable<FC_KHACHHANG_TRONGTUAN_Result> FC_KHACHHANG_TRONGTUAN(Nullable<int> tUAN, Nullable<int> tHANG, Nullable<int> nAM)
        {
            var tUANParameter = tUAN.HasValue ?
                new ObjectParameter("TUAN", tUAN) :
                new ObjectParameter("TUAN", typeof(int));
    
            var tHANGParameter = tHANG.HasValue ?
                new ObjectParameter("THANG", tHANG) :
                new ObjectParameter("THANG", typeof(int));
    
            var nAMParameter = nAM.HasValue ?
                new ObjectParameter("NAM", nAM) :
                new ObjectParameter("NAM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_KHACHHANG_TRONGTUAN_Result>("[QL_NHAHANGEntities].[FC_KHACHHANG_TRONGTUAN](@TUAN, @THANG, @NAM)", tUANParameter, tHANGParameter, nAMParameter);
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_MONAN_BANCHAY_TRONGKHOANGTG")]
        public virtual IQueryable<FC_MONAN_BANCHAY_TRONGKHOANGTG_Result> FC_MONAN_BANCHAY_TRONGKHOANGTG(Nullable<System.DateTime> dAY1, Nullable<System.DateTime> dAY2)
        {
            var dAY1Parameter = dAY1.HasValue ?
                new ObjectParameter("DAY1", dAY1) :
                new ObjectParameter("DAY1", typeof(System.DateTime));
    
            var dAY2Parameter = dAY2.HasValue ?
                new ObjectParameter("DAY2", dAY2) :
                new ObjectParameter("DAY2", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_MONAN_BANCHAY_TRONGKHOANGTG_Result>("[QL_NHAHANGEntities].[FC_MONAN_BANCHAY_TRONGKHOANGTG](@DAY1, @DAY2)", dAY1Parameter, dAY2Parameter);
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_MONAN_BANCHAY_TRONGNAM")]
        public virtual IQueryable<FC_MONAN_BANCHAY_TRONGNAM_Result> FC_MONAN_BANCHAY_TRONGNAM(Nullable<int> nAM)
        {
            var nAMParameter = nAM.HasValue ?
                new ObjectParameter("NAM", nAM) :
                new ObjectParameter("NAM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_MONAN_BANCHAY_TRONGNAM_Result>("[QL_NHAHANGEntities].[FC_MONAN_BANCHAY_TRONGNAM](@NAM)", nAMParameter);
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_MONAN_BANCHAY_TRONGNGAY")]
        public virtual IQueryable<FC_MONAN_BANCHAY_TRONGNGAY_Result> FC_MONAN_BANCHAY_TRONGNGAY(Nullable<System.DateTime> dAY)
        {
            var dAYParameter = dAY.HasValue ?
                new ObjectParameter("DAY", dAY) :
                new ObjectParameter("DAY", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_MONAN_BANCHAY_TRONGNGAY_Result>("[QL_NHAHANGEntities].[FC_MONAN_BANCHAY_TRONGNGAY](@DAY)", dAYParameter);
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_MONAN_BANCHAY_TRONGTHANG")]
        public virtual IQueryable<FC_MONAN_BANCHAY_TRONGTHANG_Result> FC_MONAN_BANCHAY_TRONGTHANG(Nullable<int> tHANG, Nullable<int> nAM)
        {
            var tHANGParameter = tHANG.HasValue ?
                new ObjectParameter("THANG", tHANG) :
                new ObjectParameter("THANG", typeof(int));
    
            var nAMParameter = nAM.HasValue ?
                new ObjectParameter("NAM", nAM) :
                new ObjectParameter("NAM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_MONAN_BANCHAY_TRONGTHANG_Result>("[QL_NHAHANGEntities].[FC_MONAN_BANCHAY_TRONGTHANG](@THANG, @NAM)", tHANGParameter, nAMParameter);
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_MONAN_BANCHAY_TRONGTUAN")]
        public virtual IQueryable<FC_MONAN_BANCHAY_TRONGTUAN_Result> FC_MONAN_BANCHAY_TRONGTUAN(Nullable<int> tUAN, Nullable<int> tHANG, Nullable<int> nAM)
        {
            var tUANParameter = tUAN.HasValue ?
                new ObjectParameter("TUAN", tUAN) :
                new ObjectParameter("TUAN", typeof(int));
    
            var tHANGParameter = tHANG.HasValue ?
                new ObjectParameter("THANG", tHANG) :
                new ObjectParameter("THANG", typeof(int));
    
            var nAMParameter = nAM.HasValue ?
                new ObjectParameter("NAM", nAM) :
                new ObjectParameter("NAM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_MONAN_BANCHAY_TRONGTUAN_Result>("[QL_NHAHANGEntities].[FC_MONAN_BANCHAY_TRONGTUAN](@TUAN, @THANG, @NAM)", tUANParameter, tHANGParameter, nAMParameter);
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGKHOANGTG")]
        public virtual IQueryable<FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGKHOANGTG_Result> FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGKHOANGTG(Nullable<System.DateTime> dAY1, Nullable<System.DateTime> dAY2)
        {
            var dAY1Parameter = dAY1.HasValue ?
                new ObjectParameter("DAY1", dAY1) :
                new ObjectParameter("DAY1", typeof(System.DateTime));
    
            var dAY2Parameter = dAY2.HasValue ?
                new ObjectParameter("DAY2", dAY2) :
                new ObjectParameter("DAY2", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGKHOANGTG_Result>("[QL_NHAHANGEntities].[FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGKHOANGTG](@DAY1, @DAY2)", dAY1Parameter, dAY2Parameter);
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGNAM")]
        public virtual IQueryable<FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGNAM_Result> FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGNAM(Nullable<int> nAM)
        {
            var nAMParameter = nAM.HasValue ?
                new ObjectParameter("NAM", nAM) :
                new ObjectParameter("NAM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGNAM_Result>("[QL_NHAHANGEntities].[FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGNAM](@NAM)", nAMParameter);
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGNGAY")]
        public virtual IQueryable<FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGNGAY_Result> FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGNGAY(Nullable<System.DateTime> dAY)
        {
            var dAYParameter = dAY.HasValue ?
                new ObjectParameter("DAY", dAY) :
                new ObjectParameter("DAY", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGNGAY_Result>("[QL_NHAHANGEntities].[FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGNGAY](@DAY)", dAYParameter);
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGTHANG")]
        public virtual IQueryable<FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGTHANG_Result> FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGTHANG(Nullable<int> tHANG, Nullable<int> nAM)
        {
            var tHANGParameter = tHANG.HasValue ?
                new ObjectParameter("THANG", tHANG) :
                new ObjectParameter("THANG", typeof(int));
    
            var nAMParameter = nAM.HasValue ?
                new ObjectParameter("NAM", nAM) :
                new ObjectParameter("NAM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGTHANG_Result>("[QL_NHAHANGEntities].[FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGTHANG](@THANG, @NAM)", tHANGParameter, nAMParameter);
        }
    
        [DbFunction("QL_NHAHANGEntities", "FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGTUAN")]
        public virtual IQueryable<FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGTUAN_Result> FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGTUAN(Nullable<int> tUAN, Nullable<int> tHANG, Nullable<int> nAM)
        {
            var tUANParameter = tUAN.HasValue ?
                new ObjectParameter("TUAN", tUAN) :
                new ObjectParameter("TUAN", typeof(int));
    
            var tHANGParameter = tHANG.HasValue ?
                new ObjectParameter("THANG", tHANG) :
                new ObjectParameter("THANG", typeof(int));
    
            var nAMParameter = nAM.HasValue ?
                new ObjectParameter("NAM", nAM) :
                new ObjectParameter("NAM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGTUAN_Result>("[QL_NHAHANGEntities].[FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGTUAN](@TUAN, @THANG, @NAM)", tUANParameter, tHANGParameter, nAMParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> FC_MONAN_TONGSOLUONG_TRONGKHOANGTG(Nullable<System.DateTime> dAY1, Nullable<System.DateTime> dAY2)
        {
            var dAY1Parameter = dAY1.HasValue ?
                new ObjectParameter("DAY1", dAY1) :
                new ObjectParameter("DAY1", typeof(System.DateTime));
    
            var dAY2Parameter = dAY2.HasValue ?
                new ObjectParameter("DAY2", dAY2) :
                new ObjectParameter("DAY2", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("FC_MONAN_TONGSOLUONG_TRONGKHOANGTG", dAY1Parameter, dAY2Parameter);
        }
    
        public virtual ObjectResult<Nullable<int>> FC_MONAN_TONGSOLUONG_TRONGNAM(Nullable<int> nAM)
        {
            var nAMParameter = nAM.HasValue ?
                new ObjectParameter("NAM", nAM) :
                new ObjectParameter("NAM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("FC_MONAN_TONGSOLUONG_TRONGNAM", nAMParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> FC_MONAN_TONGSOLUONG_TRONGNGAY(Nullable<System.DateTime> dAY)
        {
            var dAYParameter = dAY.HasValue ?
                new ObjectParameter("DAY", dAY) :
                new ObjectParameter("DAY", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("FC_MONAN_TONGSOLUONG_TRONGNGAY", dAYParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> FC_MONAN_TONGSOLUONG_TRONGTHANG(Nullable<int> tHANG, Nullable<int> nAM)
        {
            var tHANGParameter = tHANG.HasValue ?
                new ObjectParameter("THANG", tHANG) :
                new ObjectParameter("THANG", typeof(int));
    
            var nAMParameter = nAM.HasValue ?
                new ObjectParameter("NAM", nAM) :
                new ObjectParameter("NAM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("FC_MONAN_TONGSOLUONG_TRONGTHANG", tHANGParameter, nAMParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> FC_MONAN_TONGSOLUONG_TRONGTUAN(Nullable<int> tUAN, Nullable<int> tHANG, Nullable<int> nAM)
        {
            var tUANParameter = tUAN.HasValue ?
                new ObjectParameter("TUAN", tUAN) :
                new ObjectParameter("TUAN", typeof(int));
    
            var tHANGParameter = tHANG.HasValue ?
                new ObjectParameter("THANG", tHANG) :
                new ObjectParameter("THANG", typeof(int));
    
            var nAMParameter = nAM.HasValue ?
                new ObjectParameter("NAM", nAM) :
                new ObjectParameter("NAM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("FC_MONAN_TONGSOLUONG_TRONGTUAN", tUANParameter, tHANGParameter, nAMParameter);
        }
    
        public virtual int SP_CapNhatLoaiKhachHang()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_CapNhatLoaiKhachHang");
        }
    
        public virtual int SP_CapNhatSoLuongTonKho(Nullable<int> iDNguyenLieu)
        {
            var iDNguyenLieuParameter = iDNguyenLieu.HasValue ?
                new ObjectParameter("IDNguyenLieu", iDNguyenLieu) :
                new ObjectParameter("IDNguyenLieu", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_CapNhatSoLuongTonKho", iDNguyenLieuParameter);
        }
    
        public virtual int SP_CapNhatThongTinKhachHang(Nullable<int> iDKhachHang, string hotenKH, string diaChi, string sDT, string email, string loaiKH)
        {
            var iDKhachHangParameter = iDKhachHang.HasValue ?
                new ObjectParameter("IDKhachHang", iDKhachHang) :
                new ObjectParameter("IDKhachHang", typeof(int));
    
            var hotenKHParameter = hotenKH != null ?
                new ObjectParameter("HotenKH", hotenKH) :
                new ObjectParameter("HotenKH", typeof(string));
    
            var diaChiParameter = diaChi != null ?
                new ObjectParameter("DiaChi", diaChi) :
                new ObjectParameter("DiaChi", typeof(string));
    
            var sDTParameter = sDT != null ?
                new ObjectParameter("SDT", sDT) :
                new ObjectParameter("SDT", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var loaiKHParameter = loaiKH != null ?
                new ObjectParameter("LoaiKH", loaiKH) :
                new ObjectParameter("LoaiKH", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_CapNhatThongTinKhachHang", iDKhachHangParameter, hotenKHParameter, diaChiParameter, sDTParameter, emailParameter, loaiKHParameter);
        }
    
        public virtual int SP_CapNhatThongTinNhanVien(Nullable<int> iDNhanVien, string hotenNV, Nullable<System.DateTime> ngaySinh, string sDT, string diaChi, string email, Nullable<System.DateTime> ngayVL, Nullable<double> luongCoBan, string gioiTinh, Nullable<int> idChucVu)
        {
            var iDNhanVienParameter = iDNhanVien.HasValue ?
                new ObjectParameter("IDNhanVien", iDNhanVien) :
                new ObjectParameter("IDNhanVien", typeof(int));
    
            var hotenNVParameter = hotenNV != null ?
                new ObjectParameter("HotenNV", hotenNV) :
                new ObjectParameter("HotenNV", typeof(string));
    
            var ngaySinhParameter = ngaySinh.HasValue ?
                new ObjectParameter("NgaySinh", ngaySinh) :
                new ObjectParameter("NgaySinh", typeof(System.DateTime));
    
            var sDTParameter = sDT != null ?
                new ObjectParameter("SDT", sDT) :
                new ObjectParameter("SDT", typeof(string));
    
            var diaChiParameter = diaChi != null ?
                new ObjectParameter("DiaChi", diaChi) :
                new ObjectParameter("DiaChi", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var ngayVLParameter = ngayVL.HasValue ?
                new ObjectParameter("NgayVL", ngayVL) :
                new ObjectParameter("NgayVL", typeof(System.DateTime));
    
            var luongCoBanParameter = luongCoBan.HasValue ?
                new ObjectParameter("LuongCoBan", luongCoBan) :
                new ObjectParameter("LuongCoBan", typeof(double));
    
            var gioiTinhParameter = gioiTinh != null ?
                new ObjectParameter("GioiTinh", gioiTinh) :
                new ObjectParameter("GioiTinh", typeof(string));
    
            var idChucVuParameter = idChucVu.HasValue ?
                new ObjectParameter("IdChucVu", idChucVu) :
                new ObjectParameter("IdChucVu", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_CapNhatThongTinNhanVien", iDNhanVienParameter, hotenNVParameter, ngaySinhParameter, sDTParameter, diaChiParameter, emailParameter, ngayVLParameter, luongCoBanParameter, gioiTinhParameter, idChucVuParameter);
        }
    
        public virtual ObjectResult<SP_LietKeNhanvien_Chucvu_Result> SP_LietKeNhanvien_Chucvu(string tenChucVu)
        {
            var tenChucVuParameter = tenChucVu != null ?
                new ObjectParameter("TenChucVu", tenChucVu) :
                new ObjectParameter("TenChucVu", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_LietKeNhanvien_Chucvu_Result>("SP_LietKeNhanvien_Chucvu", tenChucVuParameter);
        }
    
        public virtual int SP_Taohoadon(Nullable<int> iDBan, Nullable<int> iDKhachHang, Nullable<int> iDKhuyenMai, string phuongThucTT, Nullable<System.DateTime> ngayThanhToan)
        {
            var iDBanParameter = iDBan.HasValue ?
                new ObjectParameter("IDBan", iDBan) :
                new ObjectParameter("IDBan", typeof(int));
    
            var iDKhachHangParameter = iDKhachHang.HasValue ?
                new ObjectParameter("IDKhachHang", iDKhachHang) :
                new ObjectParameter("IDKhachHang", typeof(int));
    
            var iDKhuyenMaiParameter = iDKhuyenMai.HasValue ?
                new ObjectParameter("IDKhuyenMai", iDKhuyenMai) :
                new ObjectParameter("IDKhuyenMai", typeof(int));
    
            var phuongThucTTParameter = phuongThucTT != null ?
                new ObjectParameter("PhuongThucTT", phuongThucTT) :
                new ObjectParameter("PhuongThucTT", typeof(string));
    
            var ngayThanhToanParameter = ngayThanhToan.HasValue ?
                new ObjectParameter("NgayThanhToan", ngayThanhToan) :
                new ObjectParameter("NgayThanhToan", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Taohoadon", iDBanParameter, iDKhachHangParameter, iDKhuyenMaiParameter, phuongThucTTParameter, ngayThanhToanParameter);
        }
    
        public virtual int SP_ThemDatBan(Nullable<int> iDKhachHang, Nullable<System.TimeSpan> gioBD, Nullable<System.DateTime> ngayDB, Nullable<int> soluongBan)
        {
            var iDKhachHangParameter = iDKhachHang.HasValue ?
                new ObjectParameter("IDKhachHang", iDKhachHang) :
                new ObjectParameter("IDKhachHang", typeof(int));
    
            var gioBDParameter = gioBD.HasValue ?
                new ObjectParameter("GioBD", gioBD) :
                new ObjectParameter("GioBD", typeof(System.TimeSpan));
    
            var ngayDBParameter = ngayDB.HasValue ?
                new ObjectParameter("NgayDB", ngayDB) :
                new ObjectParameter("NgayDB", typeof(System.DateTime));
    
            var soluongBanParameter = soluongBan.HasValue ?
                new ObjectParameter("SoluongBan", soluongBan) :
                new ObjectParameter("SoluongBan", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ThemDatBan", iDKhachHangParameter, gioBDParameter, ngayDBParameter, soluongBanParameter);
        }
    
        public virtual int SP_ThemHoaDon(Nullable<System.DateTime> ngayLap, Nullable<double> thanhTien, string phuongThucTT, string trangThai, Nullable<System.DateTime> ngayThanhToan, Nullable<int> iDKhachHang, Nullable<int> iDKhuyenMai)
        {
            var ngayLapParameter = ngayLap.HasValue ?
                new ObjectParameter("NgayLap", ngayLap) :
                new ObjectParameter("NgayLap", typeof(System.DateTime));
    
            var thanhTienParameter = thanhTien.HasValue ?
                new ObjectParameter("ThanhTien", thanhTien) :
                new ObjectParameter("ThanhTien", typeof(double));
    
            var phuongThucTTParameter = phuongThucTT != null ?
                new ObjectParameter("PhuongThucTT", phuongThucTT) :
                new ObjectParameter("PhuongThucTT", typeof(string));
    
            var trangThaiParameter = trangThai != null ?
                new ObjectParameter("TrangThai", trangThai) :
                new ObjectParameter("TrangThai", typeof(string));
    
            var ngayThanhToanParameter = ngayThanhToan.HasValue ?
                new ObjectParameter("NgayThanhToan", ngayThanhToan) :
                new ObjectParameter("NgayThanhToan", typeof(System.DateTime));
    
            var iDKhachHangParameter = iDKhachHang.HasValue ?
                new ObjectParameter("IDKhachHang", iDKhachHang) :
                new ObjectParameter("IDKhachHang", typeof(int));
    
            var iDKhuyenMaiParameter = iDKhuyenMai.HasValue ?
                new ObjectParameter("IDKhuyenMai", iDKhuyenMai) :
                new ObjectParameter("IDKhuyenMai", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ThemHoaDon", ngayLapParameter, thanhTienParameter, phuongThucTTParameter, trangThaiParameter, ngayThanhToanParameter, iDKhachHangParameter, iDKhuyenMaiParameter);
        }
    
        public virtual int SP_ThemKhachHang(string hotenKH, string diaChi, string sDT, string email, string loaiKH)
        {
            var hotenKHParameter = hotenKH != null ?
                new ObjectParameter("HotenKH", hotenKH) :
                new ObjectParameter("HotenKH", typeof(string));
    
            var diaChiParameter = diaChi != null ?
                new ObjectParameter("DiaChi", diaChi) :
                new ObjectParameter("DiaChi", typeof(string));
    
            var sDTParameter = sDT != null ?
                new ObjectParameter("SDT", sDT) :
                new ObjectParameter("SDT", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var loaiKHParameter = loaiKH != null ?
                new ObjectParameter("LoaiKH", loaiKH) :
                new ObjectParameter("LoaiKH", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ThemKhachHang", hotenKHParameter, diaChiParameter, sDTParameter, emailParameter, loaiKHParameter);
        }
    
        public virtual int SP_ThemNhanVien(string hotenNV, Nullable<System.DateTime> ngaySinh, string sDT, string diaChi, string email, Nullable<System.DateTime> ngayVL, Nullable<double> luongCoBan, string gioiTinh, Nullable<int> idChucVu)
        {
            var hotenNVParameter = hotenNV != null ?
                new ObjectParameter("HotenNV", hotenNV) :
                new ObjectParameter("HotenNV", typeof(string));
    
            var ngaySinhParameter = ngaySinh.HasValue ?
                new ObjectParameter("NgaySinh", ngaySinh) :
                new ObjectParameter("NgaySinh", typeof(System.DateTime));
    
            var sDTParameter = sDT != null ?
                new ObjectParameter("SDT", sDT) :
                new ObjectParameter("SDT", typeof(string));
    
            var diaChiParameter = diaChi != null ?
                new ObjectParameter("DiaChi", diaChi) :
                new ObjectParameter("DiaChi", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var ngayVLParameter = ngayVL.HasValue ?
                new ObjectParameter("NgayVL", ngayVL) :
                new ObjectParameter("NgayVL", typeof(System.DateTime));
    
            var luongCoBanParameter = luongCoBan.HasValue ?
                new ObjectParameter("LuongCoBan", luongCoBan) :
                new ObjectParameter("LuongCoBan", typeof(double));
    
            var gioiTinhParameter = gioiTinh != null ?
                new ObjectParameter("GioiTinh", gioiTinh) :
                new ObjectParameter("GioiTinh", typeof(string));
    
            var idChucVuParameter = idChucVu.HasValue ?
                new ObjectParameter("IdChucVu", idChucVu) :
                new ObjectParameter("IdChucVu", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ThemNhanVien", hotenNVParameter, ngaySinhParameter, sDTParameter, diaChiParameter, emailParameter, ngayVLParameter, luongCoBanParameter, gioiTinhParameter, idChucVuParameter);
        }
    
        public virtual int SP_ThemPhanCong(Nullable<int> iDNhanVien, Nullable<System.DateTime> ngayLamViec, Nullable<int> caLamViec, Nullable<int> ban)
        {
            var iDNhanVienParameter = iDNhanVien.HasValue ?
                new ObjectParameter("IDNhanVien", iDNhanVien) :
                new ObjectParameter("IDNhanVien", typeof(int));
    
            var ngayLamViecParameter = ngayLamViec.HasValue ?
                new ObjectParameter("NgayLamViec", ngayLamViec) :
                new ObjectParameter("NgayLamViec", typeof(System.DateTime));
    
            var caLamViecParameter = caLamViec.HasValue ?
                new ObjectParameter("CaLamViec", caLamViec) :
                new ObjectParameter("CaLamViec", typeof(int));
    
            var banParameter = ban.HasValue ?
                new ObjectParameter("Ban", ban) :
                new ObjectParameter("Ban", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ThemPhanCong", iDNhanVienParameter, ngayLamViecParameter, caLamViecParameter, banParameter);
        }
    
        public virtual int SP_ThemVaoCTHD(Nullable<int> iDHoaDon, Nullable<int> iDBan, Nullable<int> iDMon, Nullable<int> soLuong, Nullable<double> donGia, Nullable<int> giamGia)
        {
            var iDHoaDonParameter = iDHoaDon.HasValue ?
                new ObjectParameter("IDHoaDon", iDHoaDon) :
                new ObjectParameter("IDHoaDon", typeof(int));
    
            var iDBanParameter = iDBan.HasValue ?
                new ObjectParameter("IDBan", iDBan) :
                new ObjectParameter("IDBan", typeof(int));
    
            var iDMonParameter = iDMon.HasValue ?
                new ObjectParameter("IDMon", iDMon) :
                new ObjectParameter("IDMon", typeof(int));
    
            var soLuongParameter = soLuong.HasValue ?
                new ObjectParameter("SoLuong", soLuong) :
                new ObjectParameter("SoLuong", typeof(int));
    
            var donGiaParameter = donGia.HasValue ?
                new ObjectParameter("DonGia", donGia) :
                new ObjectParameter("DonGia", typeof(double));
    
            var giamGiaParameter = giamGia.HasValue ?
                new ObjectParameter("GiamGia", giamGia) :
                new ObjectParameter("GiamGia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ThemVaoCTHD", iDHoaDonParameter, iDBanParameter, iDMonParameter, soLuongParameter, donGiaParameter, giamGiaParameter);
        }
    
        public virtual int SP_UpdateStatementTable()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_UpdateStatementTable");
        }
    
        public virtual int SP_XoaKhachHang(Nullable<int> iDKhachHang)
        {
            var iDKhachHangParameter = iDKhachHang.HasValue ?
                new ObjectParameter("IDKhachHang", iDKhachHang) :
                new ObjectParameter("IDKhachHang", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_XoaKhachHang", iDKhachHangParameter);
        }
    }
}
