CREATE DATABASE QL_DIENTHOAI;        
GO
USE QL_DIENTHOAI
GO
-- ======================================== TẠO BẢNG ========================================
-- User 
CREATE TABLE NHANVIEN (
    MaNhanVien INT IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    Email VARCHAR(100) NULL CONSTRAINT DF_NHANVIEN_EMAIL DEFAULT ' ',
    SoDienThoai VARCHAR(20) NOT NULL,
    GioiTinh NVARCHAR(10) NOT NULL,
    DiaChi NVARCHAR(255) CONSTRAINT DF_NHANVIEN_DIACHI DEFAULT '',
	NgayVL DATE NOT NULL,
	LuongCoBan FLOAT NOT NULL,
    NgaySinh DATE NULL CONSTRAINT DF_NHANVIEN_NGAYSINH DEFAULT NULL,
	CONSTRAINT PK_NHANVIEN PRIMARY KEY (MaNhanVien),
	CONSTRAINT UNI_HOTEN_NHANVIEN UNIQUE(HoTen),
	CONSTRAINT UNI_EMAIL_NHANVIEN UNIQUE(Email),
	CONSTRAINT UNI_SDT_NHANVIEN UNIQUE(SoDienThoai),
	CONSTRAINT CHK_GIOITINH_NHANVIEN CHECK(GioiTinh in (N'Nam', N'Nữ')),
	CONSTRAINT CHK_LUONGCONBAN_NHANVIEN CHECK(LuongCoBan > 0)
);
CREATE TABLE KHACHHANG (
    MaKhachHang INT IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    Email VARCHAR(100) NULL CONSTRAINT DF_KHACHHANG_EMAIL DEFAULT ' ',
    SoDienThoai VARCHAR(10) NOT NULL,
    DiaChi NVARCHAR(255) NULL CONSTRAINT DF_KHACHHANG_DIACHI DEFAULT ' ',
	LoaiKH NVARCHAR(255) NULL CONSTRAINT DF_KHACHHANG_LOAIKH DEFAULT N'Khách hàng mới',
	CONSTRAINT PK_KHACHHANG PRIMARY KEY (MaKhachHang),
	CONSTRAINT UNI_SDT_KHACHHANG UNIQUE(SoDienThoai),
	CONSTRAINT CHK_LOAI_KHACHHANG CHECK (LoaiKH in(N'Khách hàng mới', N'Khách hàng thành viên', N'Khách hàng VIP'))
);
CREATE TABLE USERS (
    UserID  INT IDENTITY(1,1), 
    Username VARCHAR(50) NOT NULL,
    PasswordHash VARCHAR(50) NOT NULL,
    Roles VARCHAR(50) NOT NULL,
    MaKhachHang INT NULL,
    MaNhanVien INT NULL,
    CONSTRAINT PK_USERS PRIMARY KEY (UserID),
    CONSTRAINT FK_USERS_KHACHHANG FOREIGN KEY (MaKhachHang) REFERENCES KHACHHANG(MaKhachHang) ON DELETE CASCADE,
    CONSTRAINT FK_USERS_NHANVIEN FOREIGN KEY (MaNhanVien) REFERENCES NHANVIEN(MaNhanVien) ON DELETE CASCADE,
    CONSTRAINT CHK_MA_USERS CHECK (
        (MaKhachHang IS NOT NULL AND MaNhanVien IS NULL) OR 
        (MaNhanVien IS NOT NULL AND MaKhachHang IS NULL)
    ),
	CONSTRAINT UNI_NAME_USERS UNIQUE(Username),
	CONSTRAINT CHK_ROLES_USERS CHECK (Roles in (N'Khách hàng', N'Nhân viên', N'Admin'))
);

-- Sản phẩm
CREATE TABLE DANHMUC (
    MaDanhMuc INT IDENTITY(1,1),
    TenDanhMuc NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_DANHMUC PRIMARY KEY (MaDanhMuc),
	CONSTRAINT UNI_TEN_DANHMUC UNIQUE(TenDanhMuc) 
);
CREATE TABLE SANPHAM (
    MaSanPham INT IDENTITY(1,1),
    TenSanPham NVARCHAR(200) NOT NULL,
    MaDanhMuc INT,
    MoTa NVARCHAR(250) NOT NULL,
    GiaBan FLOAT NOT NULL,
    SoLuongTon INT NOT NULL, 
    HinhAnh VARCHAR(255) NOT NULL,
    TrangThai  NVARCHAR(100) NULL CONSTRAINT DF_SANPHAM_TRANGTHAI DEFAULT N'Còn hàng', 
	CONSTRAINT PK_SANPHAM PRIMARY KEY(MaSanPham),
    CONSTRAINT FK_SANPHAM_DANHMUC FOREIGN KEY (MaDanhMuc) REFERENCES DANHMUC(MaDanhMuc),
    CONSTRAINT CHK_SOLUONGTON_SANPHAM CHECK(SoluongTon >= 0),
	CONSTRAINT CHK_TRANGTHAI_SANPHAM CHECK (TrangThai in(N'Còn hàng', N'Hết hàng', N'Gần Hết')),
	CONSTRAINT CHK_GIABAN_SANPHAM CHECK (GiaBan >= 0),
);
CREATE TABLE GIOHANG (
    MaGioHang INT IDENTITY(1,1),
    MaKhachHang INT NOT NULL,
    MaSanPham INT NOT NULL,
    SoLuong INT NOT NULL, 
	TongTien FLOAT NULL CONSTRAINT DF_GIOHANG_TONGTIEN DEFAULT 0,
    NgayThem DATETIME NOT NULL CONSTRAINT DF_NGAYTHEM_GIOHANG DEFAULT GETDATE(), -- Tự động cập nhật
	CONSTRAINT PK_GIOHANG PRIMARY KEY(MaGioHang, MaKhachHang, MaSanPham),
    CONSTRAINT FK_GIOHANG_USERS FOREIGN KEY (MaKhachHang) REFERENCES KHACHHANG(MaKhachHang),
    CONSTRAINT FK_GIOHANG_SANPHAM FOREIGN KEY (MaSanPham) REFERENCES SANPHAM(MaSanPham),
	CONSTRAINT CHK_SOLUONG_GIOHANG CHECK(Soluong > 0),
	CONSTRAINT CHK_TONGTIEN_GIOHANG CHECK(TongTien >= 0)
);

-- Đơn hàng
CREATE TABLE KHUYENMAI (
    MaKhuyenMai  INT IDENTITY(1,1),
    TenKhuyenMai NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255),
    PhanTramGiamGia FLOAT NOT NULL,
    NgayBatDau DATETIME NOT NULL,
    NgayKetThuc DATETIME NOT NULL,
	DieuKien NVARCHAR(255) NOT NULL,
	CONSTRAINT PK_KHUYENMAI PRIMARY KEY (MaKhuyenMai),
	CONSTRAINT CHK_THOIGIAN_KHUYENMAI CHECK (NgayBatDau <= NgayKetThuc)
);
CREATE TABLE HOADON (
    MaHoaDon INT IDENTITY(1,1),
    MaKhachHang INT,
	MaNhanVien INT,
    NgayDatHang DATETIME NULL CONSTRAINT DF_NGAYDAT_HOADON DEFAULT GETDATE(),
    TongTien INT CONSTRAINT DF_HOADON_TONGTIEN DEFAULT 0,
    TrangThaiDH NVARCHAR(50) NULL CONSTRAINT DF_HOADON_TRANGTHAIDH DEFAULT N'Chờ xác nhận', 
	MaKhuyenMai INT NULL,
	TgianCapnhat DATETIME,
	PhuongThucTT NVARCHAR(50) NULL CONSTRAINT DF_HOADON_THANHTOAN DEFAULT N'Tiền mặt',
	TrangThaiTT NVARCHAR(50) CONSTRAINT DF_PHUONGTHUCTT_HOADON DEFAULT N'Chưa thanh toán',
	NgayTT DATE CONSTRAINT DF_NGAYTT_HOADON DEFAULT NULL,
	NgayDHDK DATE CONSTRAINT DF_NGAYGHDK_HOADON DEFAULT getDATE() + 3, 
	NgayGH DATE NULL CONSTRAINT DF_HOADON_NGAYGH DEFAULT NULL,
	GhiChu NVARCHAR(250) NULL CONSTRAINT DF_HOADON_GHICHU DEFAULT '',
	CONSTRAINT PK_HOADON PRIMARY KEY (MaHoaDon),
	CONSTRAINT FK_HOADON_KHACHHANG FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    CONSTRAINT FK_HOADON_NHANVIEN FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
	CONSTRAINT FK_HOADON_KHUYENMAI FOREIGN KEY (MaKhuyenMai) REFERENCES KHUYENMAI(MaKhuyenMai), 
	CONSTRAINT CHK_TONGTIEN_HOADON CHECK (TongTien >= 0),
	CONSTRAINT CHK_TRANGTHAIDH_HOADON CHECK (TrangThaiDH in (N'Chờ xác nhận', N'Đang vận chuyển', N'Hoàn thành', N'Hủy')),
	CONSTRAINT CHK_PHUONGTHUCTT_HOADON CHECK(PhuongThucTT in (N'Tiền mặt', N'Chuyển khoản')),
	CONSTRAINT CHK_TRANGTHAITT_HOADON CHECK (TrangThaiTT in (N'Đã thanh toán', N'Chưa thanh toán'))
);
CREATE TABLE CHITIETHD ( 
    MaHoaDon INT,
    MaSanPham INT,
    SoLuong INT NOT NULL,
    DonGia FLOAT NOT NULL,
	CONSTRAINT PK_CHITIETHD PRIMARY KEY(MaHoaDon, MaSanPham),
	CONSTRAINT FK_CHITIETHD_SANPHAM FOREIGN KEY(MaSanPham) REFERENCES SANPHAM(MaSanPham),
	CONSTRAINT FK_CHITIETHD_HOADON FOREIGN KEY (MaHoaDon) REFERENCES HOADON(MaHoaDon),
    CONSTRAINT CHK_SOLUONG_CHITIETHD CHECK(SoLuong > 0),
	CONSTRAINT CHK_DONGIA_CHITIETHD CHECK (DonGia > 0)
);
CREATE TABLE DANHGIA (
	MaSanPham INT,
	MaKhachHang INT,
    XepHang INT NOT NULL,
    NhanXet NVARCHAR(255) NULL CONSTRAINT DF_NHAXET_DANHGIA DEFAULT ' ',
    NgayDanhGia DATETIME NULL CONSTRAINT DF_NGAY_DANHGIA DEFAULT GETDATE(),
	CONSTRAINT PK_DANHGIA PRIMARY KEY (MaSanPham, MaKhachHang),
    CONSTRAINT FK_DANHGIA_SANPHAM FOREIGN KEY(MaSanPham) REFERENCES SANPHAM(MaSanPham),
	CONSTRAINT FK_DANHGIA_KHACHHANG FOREIGN KEY (MaKhachHang) REFERENCES KHACHHANG(MaKhachHang) ON DELETE CASCADE,
	CONSTRAINT CHK_XEPHANG_DANHGIA CHECK (XepHang BETWEEN 1 AND 5)
);

-- PHIẾU NHẬP
CREATE TABLE NHACUNGCAP(
    MaNCC  INT IDENTITY(1,1),
    TenNCC NVARCHAR(100) NOT NULL,
	DiaChi NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(20) NOT NULL,
	NgayBDCC DATE NOT NULL CONSTRAINT DF_NgayBDCC_NHACUNGCAP DEFAULT GETDATE(),
	CONSTRAINT PK_NHACUNGCAP PRIMARY KEY (MaNCC),
	CONSTRAINT UNI_TEN_NHANCUNGCAP UNIQUE(TenNCC),
	CONSTRAINT UNI_SDT_NHANCUNGCAP UNIQUE(SoDienThoai)
);
CREATE TABLE PHIEUNHAP(
	 MaPhieuNhap INT IDENTITY(1,1) NOT NULL,
	 NgayNhap DATE NULL CONSTRAINT DF_NGAYNHAP_PHIEUNHAP DEFAULT GETDATE(),
	 TongTien FLOAT NULL CONSTRAINT DF_PHIEUNHAP_TONGTIEN DEFAULT 0,
	 PhuongThucTT NVARCHAR(100) NULL CONSTRAINT DF_PHIEUNHAP_PHUONGTHUCTT DEFAULT N'Tiền mặt',
	 TrangThai NVARCHAR(50) NULL CONSTRAINT DF_PHIEUNHAP_TRANGTHAI DEFAULT N'Chưa thanh toán',
	 NgayThanhToan DATE NULL CONSTRAINT DF_NGAYTHANHTOAN_PHIEUNHAP DEFAULT NULL,
	 MaNhanVien INT NOT NULL,
	 MaNCC INT NOT NULL,
	 CONSTRAINT PK_PHIEUNHAP PRIMARY KEY (MaPhieuNhap),
	 CONSTRAINT FK_PHIEUNHAP_NHACUNGCAP FOREIGN KEY(MaNCC) REFERENCES NHACUNGCAP(MaNCC),
	 CONSTRAINT FK_PHIEUNHAP_NHANVIEN FOREIGN KEY(MaNhanVien) REFERENCES NHANVIEN(MaNhanVien),
	 CONSTRAINT CHK_PHIEUNHAP_TONGTIEN CHECK(TongTien >= 0),
	 CONSTRAINT CHK_PHIEUNHAP_PHUONGTHUCTT CHECK (PhuongThucTT in (N'Tiền mặt', N'Chuyển khoản')),
	 CONSTRAINT CHK_PHIEUNHAP_NGAYTHANHTOAN CHECK(NgayNhap <= NgayThanhToan),
	 CONSTRAINT CHK_PHIEUNHAP_TRANGTHAI CHECK (TrangThai in (N'Chưa thanh toán', N'Đã thanh toán'))
 );
CREATE TABLE CHITIETPN(
	  MaPhieuNhap INT,
	  MaSanPham INT,
	  SoLuong INT NULL CONSTRAINT DF_SOLUONG_CHITIETPN DEFAULT 1,
	  GiaNhap FLOAT NULL,
	  CONSTRAINT PK_CHITIETPN PRIMARY KEY (MaPhieuNhap, MaSanPham),
	  CONSTRAINT FK_CHITIETPN_PHIEUNHAP FOREIGN KEY(MaPhieuNhap) REFERENCES PHIEUNHAP(MaPhieuNhap),
	  CONSTRAINT FK_CHITIETPN_NGUYENLIEU FOREIGN KEY(MaSanPham) REFERENCES SANPHAM(MaSanPham),
	  CONSTRAINT CHK_CHITIETPN_SoLuong CHECK(Soluong > 0),
	  CONSTRAINT CHK_CHITIETPN_GiaNhap CHECK(GiaNhap > 0)
);
GO
-- ======================================== INSERT INTO ========================================
-- Users
INSERT INTO NHANVIEN (HoTen, Email, SoDienThoai, GioiTinh, DiaChi, NgayVL, LuongCoBan) 
VALUES 
(N'Nguyễn Văn An', 'an.nguyen@gmail.com', '0934556789', N'Nam', N'Số 12, Đường Lê Lợi, Quận 1, TP.HCM', '2021-03-15', 12000000),
(N'Trần Thị Bích', 'bich.tran@gmail.com', '0938123456', N'Nữ', N'Số 45, Đường Nguyễn Trãi, Quận 5, TP.HCM', '2022-05-10', 13000000),
(N'Lê Quang Huy', 'huy.le@gmail.com', '0942556897', N'Nam', N'Số 78, Đường Cộng Hòa, Tân Bình, TP.HCM', '2020-07-01', 14500000),
(N'Phạm Minh Tuấn', 'tuan.pham@gmail.com', '0913789456', N'Nam', N'Số 24, Đường Lạc Long Quân, Quận 11, TP.HCM', '2019-11-20', 11000000),
(N'Hoàng Thị Thu', 'thu.hoang@gmail.com', '0924658971', N'Nữ', N'Số 60, Đường Hoàng Diệu, Quận 4, TP.HCM', '2023-01-05', 15000000),
(N'Vũ Văn Nam', 'nam.vu@gmail.com', '0939123458', N'Nam', N'Số 33, Đường Xô Viết Nghệ Tĩnh, Bình Thạnh, TP.HCM', '2021-08-25', 12500000),
(N'Đặng Thị Hoa', 'hoa.dang@gmail.com', '0908789456', N'Nữ', N'Số 19, Đường Võ Văn Tần, Quận 3, TP.HCM', '2020-10-10', 14000000),
(N'Bùi Văn Phúc', 'phuc.bui@gmail.com', '0936889012', N'Nam', N'Số 89, Đường Lý Thái Tổ, Quận 10, TP.HCM', '2018-03-15', 13500000),
(N'Đỗ Thị Nga', 'nga.do@gmail.com', '0909876543', N'Nữ', N'Số 15, Đường Hùng Vương, Quận 5, TP.HCM', '2019-05-05', 12000000),
(N'Phan Văn Dũng', 'dung.phan@gmail.com', '0921234567', N'Nam', N'Số 50, Đường Trần Hưng Đạo, Quận 1, TP.HCM', '2022-09-01', 12500000),
(N'Nguyễn Thị Lan', 'lan.nguyen@gmail.com', '0944123456', N'Nữ', N'Số 66, Đường Pasteur, Quận 3, TP.HCM', '2023-06-10', 11000000),
(N'Trần Văn Hùng', 'hung.tran@gmail.com', '0938123999', N'Nam', N'Số 22, Đường Nam Kỳ Khởi Nghĩa, Quận 1, TP.HCM', '2020-01-12', 13000000),
(N'Lê Thị Hương', 'huong.le@gmail.com', '0913456789', N'Nữ', N'Số 44, Đường Nguyễn Văn Cừ, Quận 5, TP.HCM', '2021-03-22', 14000000),
(N'Phạm Văn Khánh', 'khanh.pham@gmail.com', '0905678990', N'Nam', N'Số 77, Đường Tôn Đức Thắng, Quận 1, TP.HCM', '2018-07-15', 12500000),
(N'Hoàng Văn Bình', 'binh.hoang@gmail.com', '0934678998', N'Nam', N'Số 88, Đường Phạm Ngũ Lão, Quận 1, TP.HCM', '2023-05-20', 13500000),
(N'Vũ Thị Mai', 'mai.vu@gmail.com', '0943789451', N'Nữ', N'Số 55, Đường Hai Bà Trưng, Quận 3, TP.HCM', '2019-11-01', 12000000),
(N'Bùi Minh Quân', 'quan.bui@gmail.com', '0909234567', N'Nam', N'Số 11, Đường Nguyễn Văn Linh, Quận 7, TP.HCM', '2022-03-11', 15000000),
(N'Đặng Văn Long', 'long.dang@gmail.com', '0921678901', N'Nam', N'Số 32, Đường Hoàng Sa, Quận 3, TP.HCM', '2020-05-18', 11500000),
(N'Đỗ Thị Vân', 'van.do@gmail.com', '0904567890', N'Nữ', N'Số 100, Đường Nguyễn Huệ, Quận 1, TP.HCM', '2021-12-25', 13000000),
(N'Phan Văn Hải', 'hai.phan@gmail.com', '0935778888', N'Nam', N'Số 28, Đường Lê Văn Sỹ, Phú Nhuận, TP.HCM', '2023-09-05', 14500000);
INSERT INTO KHACHHANG (HoTen, Email, SoDienThoai, DiaChi) 
VALUES 
(N'Nguyễn Thị Hạnh', 'hanh.nguyen@gmail.com', '0901345678', N'Số 1, Đường Đinh Tiên Hoàng, Quận 1, TP.HCM'),
(N'Trần Văn Minh', 'minh.tran@gmail.com', '0932678912', N'Số 2, Đường Võ Văn Kiệt, Quận 6, TP.HCM'),
(N'Phạm Thị Tuyết', 'tuyet.pham@gmail.com', '0912456789', N'Số 10, Đường Nguyễn Thái Học, Quận 4, TP.HCM'),
(N'Bùi Văn Sơn', 'son.bui@gmail.com', '0943567891', N'Số 25, Đường Lý Tự Trọng, Quận 1, TP.HCM'),
(N'Lê Thị Tâm', 'tam.le@gmail.com', '0934789012', N'Số 18, Đường Pasteur, Quận 3, TP.HCM'),
(N'Đỗ Văn Quân', 'quan.do@gmail.com', '0905123456', N'Số 30, Đường Phạm Văn Đồng, Thủ Đức, TP.HCM'),
(N'Trương Thị Vân', 'van.truong@gmail.com', '0924561234', N'Số 75, Đường Trần Quang Khải, Quận 1, TP.HCM'),
(N'Hoàng Văn Khoa', 'khoa.hoang@gmail.com', '0936123457', N'Số 50, Đường Hoàng Văn Thụ, Tân Bình, TP.HCM'),
(N'Ngô Thị Bích', 'bich.ngo@gmail.com', '0912678904', N'Số 23, Đường Điện Biên Phủ, Bình Thạnh, TP.HCM'),
(N'Vũ Minh Tuấn', 'tuan.vu@gmail.com', '0941123456', N'Số 15, Đường Nguyễn Văn Cừ, Quận 5, TP.HCM'),
(N'Lê Quang Hải', 'hai.le@gmail.com', '0909234561', N'Số 44, Đường Nguyễn Đình Chiểu, Quận 3, TP.HCM'),
(N'Nguyễn Thị Thanh', 'thanh.nguyen@gmail.com', '0914678901', N'Số 12, Đường Hòa Hảo, Quận 10, TP.HCM'),
(N'Phạm Văn Đạt', 'dat.pham@gmail.com', '0935789456', N'Số 66, Đường Lê Đại Hành, Quận 11, TP.HCM'),
(N'Trần Thị Loan', 'loan.tran@gmail.com', '0906789123', N'Số 7, Đường Tôn Thất Tùng, Quận 1, TP.HCM'),
(N'Bùi Văn Bình', 'binh.bui@gmail.com', '0921345678', N'Số 88, Đường Trường Chinh, Tân Phú, TP.HCM'),
(N'Trần Quốc Anh', 'anh.tran@gmail.com', '0942456781', N'Số 9, Đường Hoàng Sa, Phú Nhuận, TP.HCM'),
(N'Phan Thị Kim', 'kim.phan@gmail.com', '0913890234', N'Số 16, Đường Võ Thị Sáu, Quận 3, TP.HCM'),
(N'Lê Văn Thanh', 'thanh.le@gmail.com', '0931789456', N'Số 100, Đường Trần Hưng Đạo, Quận 5, TP.HCM'),
(N'Ngô Thị Yến', 'yen.ngo@gmail.com', '0907345678', N'Số 20, Đường Nguyễn Oanh, Gò Vấp, TP.HCM'),
(N'Hoàng Minh Phúc', 'phuc.hoang@gmail.com', '0923894567', N'Số 32, Đường Lê Quý Đôn, Quận 3, TP.HCM');
INSERT INTO USERS (Username, PasswordHash, Roles, MaKhachHang) 
VALUES 
('hanh.nguyen', '123456', N'Khách hàng', 1),
('minh.tran', '123456', N'Khách hàng', 2),
('tuyet.pham', '123456', N'Khách hàng', 3),
('son.bui', '123456', N'Khách hàng', 4),
('tam.le', '123456', N'Khách hàng', 5),
('quan.do', '123456', N'Khách hàng', 6),
('van.truong', '123456', N'Khách hàng', 7),
('khoa.hoang', '123456', N'Khách hàng', 8),
('bich.ngo', '123456', N'Khách hàng', 9),
('tuan.vu', '123456', N'Khách hàng', 10),
('hai.le', '123456', N'Khách hàng', 11),
('thanh.nguyen', '123456', N'Khách hàng', 12),
('dat.pham', '123456', N'Khách hàng', 13),
('loan.tran', '123456', N'Khách hàng', 14),
('binh.bui', '123456', N'Khách hàng', 15),
('anh.tran', '123456', N'Khách hàng', 16),
('kim.phan', '123456', N'Khách hàng', 17),
('thanh.le', '123456', N'Khách hàng', 18),
('yen.ngoc', '123456', N'Khách hàng', 19),
('phuc.hoang', '123456', N'Khách hàng', 20);
INSERT INTO USERS (Username, PasswordHash, Roles, MaNhanVien) 
VALUES 
('an.nguyen123', '123456', N'Nhân viên', 1),
('bich.tran456', '123456', N'Nhân viên', 2),
('huy.le789', '123456', N'Nhân viên', 3),
('tuan.pham321', '123456', N'Nhân viên', 4),
('thu.hoang654', '123456', N'Nhân viên', 5),
('nam.vu987', '123456', N'Nhân viên', 6),
('hoa.dang258', '123456', N'Nhân viên', 7),
('phuc.bui369', '123456', N'Nhân viên', 8),
('nga.do147', '123456', N'Nhân viên', 9),
('dung.phan258', '123456', N'Nhân viên', 10),
('lan.nguyen369', '123456', N'Admin', 11),
('hung.tran963', '123456', N'Admin', 12),
('huong.le741', '123456', N'Admin', 13),
('khanh.pham852', '123456', N'Admin', 14),
('binh.hoang963', '123456', N'Admin', 15);

-- Sản phẩm
INSERT INTO DANHMUC (TenDanhMuc)
VALUES 
(N'Điện thoại'),
(N'Máy tính bảng'),
(N'Đồng hồ thông minh'),
(N'Máy tính bàn, máy in'),
(N'Laptop'),
(N'Phụ kiện')
INSERT INTO SANPHAM (TenSanPham, MaDanhMuc, MoTa, GiaBan, SoLuongTon, HinhAnh, TrangThai) 
VALUES
(N'iPhone 14 Pro Max', 1, N'Điện thoại cao cấp của Apple', 32000000, 10, 'iphone_14_pro_max.jpg', N'Còn hàng'),
(N'Samsung Galaxy S23 Ultra', 1,  N'Flagship của Samsung với camera 200MP', 29000000, 8, 'galaxy_s23_ultra.jpg', N'Còn hàng'),
(N'Google Pixel 7 Pro', 1,  N'Điện thoại Android nguyên bản của Google', 25000000, 5, 'pixel_7_pro.jpg', N'Gần hết'),
(N'Xiaomi 13 Pro', 1,  N'Điện thoại với chip Snapdragon mới nhất', 22000000, 7, 'xiaomi_13_pro.jpg', N'Còn hàng'),
(N'OPPO Find X5 Pro', 1,  N'Camera Hasselblad, thiết kế độc đáo', 18000000, 15, 'oppo_find_x5_pro.jpg', N'Còn hàng'),
(N'Vivo X90 Pro', 1,  N'Điện thoại với camera Zeiss', 24000000, 10, 'vivo_x90_pro.jpg', N'Còn hàng'),
(N'Asus ROG Phone 7', 1,  N'Điện thoại chơi game chuyên nghiệp', 27000000, 4, 'rog_phone_7.jpg', N'Gần hết'),
(N'Sony Xperia 1 IV', 1,  N'Điện thoại với màn hình 4K HDR', 26000000, 6, 'xperia_1_iv.jpg', N'Hết hàng'),
(N'Realme GT2 Pro', 1, N'Điện thoại hiệu năng cao với giá tốt', 15000000, 20, 'realme_gt2_pro.jpg', N'Còn hàng'),
(N'iPhone 13 Mini', 1,  N'Dòng iPhone nhỏ gọn', 18000000, 12, 'iphone_13_mini.jpg', N'Còn hàng'),
(N'Samsung Galaxy Z Flip 5', 1,  N'Điện thoại màn hình gập tiện lợi', 26000000, 3, 'galaxy_z_flip_5.jpg', N'Gần hết'),
(N'OnePlus 11', 1,  N'Điện thoại flagship của OnePlus', 23000000, 8, 'OnePlus.jpg', N'Còn hàng'),
(N'Nokia G60 5G', 1,  N'Điện thoại bền bỉ của Nokia', 9000000, 18, 'Nokia_g60_5g.jpg', N'Còn hàng'),
(N'Motorola Edge 30 Ultra', 1,  N'Điện thoại với camera 200MP', 21000000, 9, 'motorola_edge_30_ultra.jpg', N'Còn hàng'),
(N'Samsung Galaxy A73', 1,  N'Dòng Galaxy tầm trung', 12000000, 22, 'galaxy_a73.jpg', N'Còn hàng'),
(N'Xiaomi Redmi Note 12', 1,  N'Dòng Redmi nổi tiếng', 6000000, 35, 'redmi_note_12.jpg', N'Còn hàng'),
(N'OPPO Reno8 T', 1, N'Smartphone với camera AI', 8000000, 14, 'oppo_reno8_t.jpg', N'Còn hàng'),
(N'Realme C55', 1, N'Điện thoại phổ thông giá rẻ', 4500000, 30, 'realme_c55.jpg', N'Còn hàng'),
(N'Vsmart Aris Pro', 1, N'Điện thoại của thương hiệu Việt', 7000000, 10, 'vsmart_aris_pro.jpg', N'Còn hàng'),
(N'Poco F5', 1, N'Smartphone hiệu năng tốt', 11000000, 15, 'poco_f5.jpg', N'Còn hàng'),

(N'iPad Pro 12.9', 2,  N'Máy tính bảng cao cấp của Apple', 30000000, 10, 'ipad_pro_12_9.jpg', N'Còn hàng'),
(N'Samsung Galaxy Tab S8 Ultra', 2,  N'Máy tính bảng cao cấp với màn hình lớn', 28000000, 8, 'galaxy_tab_s8_ultra.jpg', N'Còn hàng'),
(N'Lenovo Tab P11 Pro', 2, N'Máy tính bảng Android với hiệu năng mạnh', 18000000, 5, 'lenovo_tab_p11_pro.jpg', N'Gần hết'),
(N'Huawei MatePad Pro', 2, N'Máy tính bảng hiệu năng cao, thiết kế mỏng', 22000000, 7, 'huawei_matepad_pro.jpg', N'Còn hàng'),
(N'Microsoft Surface Pro 8', 2, N'Máy tính bảng 2 trong 1 với Windows', 32000000, 4, 'Surface_pro_8.jpg', N'Gần hết'),
(N'Xiaomi Pad 5', 2, N'Máy tính bảng với màn hình 120Hz', 12000000, 10, 'xiaomi_pad_5.jpg', N'Còn hàng'),
(N'Amazon Fire HD 10', 2, N'Máy tính bảng giá rẻ cho giải trí', 5000000, 20, 'Fire_hd_10.jpg', N'Còn hàng'),
(N'Asus ZenPad 3S 10', 2, N'Máy tính bảng với thiết kế đẹp và âm thanh chất lượng', 15000000, 6, 'Zenpad_3S_10.jpg', N'Gần hết'),
(N'Lenovo Yoga Tab 11', 2, N'Máy tính bảng với pin lâu dài', 17000000, 15, 'lenovo_yoga_tab_11.jpg', N'Còn hàng'),
(N'Samsung Galaxy Tab A7', 2, N'Máy tính bảng tầm trung với màn hình lớn', 10000000, 12, 'galaxy_tab_a7.jpg', N'Còn hàng'),
(N'Huawei MatePad 11', 2, N'Máy tính bảng với hiệu năng tốt', 15000000, 18, 'huawei_matepad_11.jpg', N'Còn hàng'),
(N'Microsoft Surface Go 3', 2, N'Máy tính bảng 2 trong 1 nhỏ gọn', 15000000, 8, 'Surface_go_3.jpg', N'Còn hàng'),
(N'Apple iPad 10', 2, N'Máy tính bảng phổ thông của Apple', 15000000, 10, 'ipad_10.jpg', N'Còn hàng'),
(N'Samsung Galaxy Tab S6 Lite', 2, N'Máy tính bảng với bút S Pen đi kèm', 12000000, 14, 'galaxy_tab_s6_lite.jpg', N'Còn hàng'),
(N'Vivo Pad', 2, N'Máy tính bảng mới ra mắt với giá tốt', 11000000, 9, 'vivo_pad.jpg', N'Còn hàng'),
(N'Xiaomi Pad 5 Pro', 2, N'Máy tính bảng hiệu năng cao với màn hình lớn', 25000000, 5, 'xiaomi_pad_5_pro.jpg', N'Còn hàng'),
(N'Honor V8 Pro', 2, N'Máy tính bảng với thiết kế hiện đại', 14000000, 10, 'Honor_v8_pro.jpg', N'Còn hàng'),
(N'Asus ROG Flow Z13', 2, N'Máy tính bảng chơi game với cấu hình mạnh', 30000000, 3, 'Rog_flow_z13.jpg', N'Gần hết'),
(N'Teclast X4', 2, N'Máy tính bảng với giá cực tốt', 8000000, 25, 'teclast_x4.jpg', N'Còn hàng'),
(N'Chuwi Hi10 X', 2, N'Máy tính bảng 2 trong 1 với giá tốt', 6000000, 12, 'chuwi_hi10_x.jpg', N'Còn hàng'),

(N'Apple Watch Series 8', 3,  N'Đồng hồ thông minh cao cấp với nhiều tính năng sức khỏe.', 12000000, 15, 'Apple_watch_series_8.jpg', N'Còn hàng'),
(N'Samsung Galaxy Watch 5', 3, N'Đồng hồ thông minh với màn hình AMOLED và theo dõi sức khỏe.', 10500000, 20, 'Galaxy_watch_5.jpg', N'Còn hàng'),
(N'Garmin Forerunner 245', 3, N'Đồng hồ thông minh chuyên cho vận động viên với GPS.', 8000000, 12, 'Garmin_forerunner_245.jpg', N'Còn hàng'),
(N'Fossil Gen 6', 3, N'Đồng hồ thông minh với thiết kế sang trọng và nhiều ứng dụng.', 7000000, 8, 'Fossil_gen_6.jpg', N'Còn hàng'),
(N'Huawei Watch GT 3', 3, N'Đồng hồ thông minh với pin lâu và tính năng theo dõi sức khỏe.', 6500000, 18, 'Huawei_watch_gt_3.jpg', N'Còn hàng'),
(N'Xiaomi Amazfit GTR 3', 3, N'Đồng hồ thông minh với nhiều chế độ thể thao.', 4500000, 10, 'Xiaomi_amazfit_gtr.jpg', N'Còn hàng'),
(N'Withings Steel HR', 3, N'Đồng hồ thông minh với thiết kế truyền thống và tính năng theo dõi sức khỏe.', 5500000, 6, 'withings_steel_hr.jpg', N'Gần hết'),
(N'Fitbit Versa 3', 3, N'Đồng hồ thông minh với tính năng theo dõi giấc ngủ và hoạt động.', 7000000, 9, 'fitbit_versa_3.jpg', N'Còn hàng'),
(N'TicWatch Pro 3', 3, N'Đồng hồ thông minh với hai màn hình và thời lượng pin lâu.', 8500000, 4, 'ticwatch_pro_3.jpg', N'Gần hết'),
(N'Garmin Venu Sq', 3, N'Đồng hồ thông minh với màn hình AMOLED và tính năng theo dõi sức khỏe.', 9000000, 15, 'Garmin_venu_SQ.jpg', N'Còn hàng'),

(N'Máy tính để bàn Dell Inspiron', 4, N'Máy tính để bàn với hiệu suất cao và thiết kế hiện đại.', 15000000, 10, 'Dell_inspiron.jpg', N'Còn hàng'),
(N'Máy tính để bàn HP Pavilion', 4, N'Máy tính để bàn HP với cấu hình mạnh mẽ, phù hợp cho học tập và làm việc.', 14000000, 12, 'Hp_pavilion.jpg', N'Còn hàng'),
(N'Máy tính để bàn Lenovo IdeaCentre', 4, N'Máy tính để bàn đa năng với thiết kế nhỏ gọn.', 13000000, 8, 'Lenovo_ideacentre.jpg', N'Còn hàng'),
(N'Máy tính để bàn Acer Aspire', 4, N'Máy tính để bàn với hiệu suất ổn định và đồ họa tốt.', 12000000, 15, 'Acer_aspire.jpg', N'Còn hàng'),
(N'Máy tính để bàn Asus Vivo', 4, N'Máy tính để bàn với cấu hình mạnh mẽ, thích hợp cho game thủ.', 16000000, 5, 'Asus_vivo.jpg', N'Gần hết'),
(N'Máy in Canon LBP 2900', 4, N'Máy in laser Canon với tốc độ in nhanh và chất lượng cao.', 3000000, 20, 'canon_lbp_2900.jpg', N'Còn hàng'),
(N'Máy in HP LaserJet Pro MFP', 4,N'Máy in đa chức năng với in, scan, copy.', 5000000, 10, 'hp_laserjet_pro_mfp.jpg', N'Còn hàng'),
(N'Máy in Epson EcoTank L3150', 4, N'Máy in phun màu tiết kiệm mực, thích hợp cho gia đình.', 4000000, 12, 'epson_ecotank_l3150.jpg', N'Còn hàng'),
(N'Máy in Brother HL-L2321D', 4, N'Máy in laser trắng đen với chất lượng in sắc nét.', 3500000, 8, 'brother_hl_l2321d.jpg', N'Còn hàng'),
(N'Máy in Samsung Xpress M2020', 4, N'Máy in laser nhỏ gọn, phù hợp cho văn phòng.', 2500000, 15, 'samsung_xpress_m2020.jpg', N'Còn hàng'),

(N'Dell XPS 13', 5, N'Laptop Dell XPS 13, hiệu suất cao, thiết kế mỏng nhẹ.', 30000000, 15, 'Dell_xps_13.jpg', N'Còn hàng'),
(N'HP Spectre x360', 5, N'Laptop HP Spectre x360, màn hình cảm ứng, thiết kế sang trọng.', 35000000, 10, 'Hp_spectre_x360.jpg', N'Còn hàng'),
(N'Lenovo ThinkPad X1 Carbon', 5, N'Laptop Lenovo ThinkPad X1 Carbon, bền bỉ, hiệu suất tốt.', 28000000, 8, 'Lenovo_thinkpad_x1.jpg', N'Còn hàng'),
(N'Acer Swift 3', 5, N'Laptop Acer Swift 3, nhẹ, pin lâu, hiệu suất ổn.', 22000000, 12, 'Acer_swift_3.jpg', N'Còn hàng'),
(N'Asus ZenBook 14', 5, N'Laptop Asus ZenBook 14, thiết kế tinh tế, hiệu suất mạnh.', 27000000, 9, 'Asus_zenbook_14.jpg', N'Còn hàng'),
(N'MSI GS66 Stealth', 5,N'Laptop Gaming MSI GS66 Stealth, hiệu suất cao cho game thủ.', 45000000, 5, 'Msi_gs66_stealth.jpg', N'Còn hàng'),
(N'Apple MacBook Air M2', 5, N'MacBook Air M2, hiệu suất mạnh mẽ, thiết kế mỏng nhẹ.', 38000000, 7, 'Macbook_air_m2.jpg', N'Còn hàng'),
(N'Razer Blade 15', 5, N'Laptop Razer Blade 15, hoàn hảo cho game và đồ họa.', 50000000, 4, 'Razer_blade_15.jpg', N'Còn hàng'),
(N'Dell Inspiron 15', 5, N'Laptop Dell Inspiron 15, phù hợp cho học tập và làm việc.', 22000000, 15, 'Dell_inspiron_15.jpg', N'Còn hàng'),
(N'HP Pavilion 15', 5, N'Laptop HP Pavilion 15, cấu hình mạnh, giá cả phải chăng.', 20000000, 10, 'Hp_pavilion_15.jpg', N'Còn hàng'),

(N'Sạc nhanh USB-C', 6, N'Sạc nhanh USB-C cho điện thoại và máy tính bảng.', 300000, 50, 'sac_nhanh_usb_c.jpg', N'Còn hàng'),
(N'Ốp lưng điện thoại', 6,  N'Ốp lưng bảo vệ cho điện thoại, nhiều mẫu mã.', 150000, 100, 'Op_lung_dien_thoai.jpg', N'Còn hàng'),
(N'Tai nghe Bluetooth', 6,  N'Tai nghe Bluetooth không dây, âm thanh tuyệt vời.', 600000, 25, 'tai_nghe_bluetooth.jpg', N'Còn hàng'),
(N'Kính cường lực', 6, N'Kính cường lực bảo vệ màn hình điện thoại.', 200000, 80, 'Kinh_cuong_luc.jpg', N'Còn hàng'),
(N'Sạc dự phòng 10000mAh', 6, N'Sạc dự phòng 10000mAh, tiện lợi cho chuyến đi.', 450000, 40, 'sac_du_phong_10000mah.jpg', N'Còn hàng'),
(N'Cáp USB-C', 6, N'Cáp USB-C cho sạc và truyền dữ liệu.', 100000, 60, 'Cap_usb_c.jpg', N'Còn hàng'),
(N'Sạc không dây', 6, N'Sạc không dây cho các thiết bị hỗ trợ.', 350000, 30, 'Sac_khong_day.jpg', N'Còn hàng'),
(N'Giá đỡ điện thoại', 6, N'Giá đỡ điện thoại cho xe hơi, sử dụng tiện lợi.', 200000, 20, 'gia_do_dien_thoai.jpg', N'Còn hàng'),
(N'Chuột không dây', 6, N'Chuột không dây tiện lợi cho máy tính.', 250000, 35, 'chuot_khong_day.jpg', N'Còn hàng'),
(N'Balo đựng laptop', 6, N'Balo đựng laptop, thiết kế thời trang và tiện lợi.', 600000, 15, 'balo_dung_laptop.jpg', N'Còn hàng'),
(N'Pin dự phòng', 6, N'Pin dự phòng cho các thiết bị điện tử.', 400000, 22, 'Pin_du_phong.jpg', N'Còn hàng'),
(N'Phụ kiện chơi game', 6, N'Phụ kiện chơi game cho máy tính, tăng trải nghiệm.', 700000, 10, 'phu_kien_choi_game.jpg', N'Còn hàng'),
(N'Tai nghe có dây', 6, N'Tai nghe có dây chất lượng cao, âm thanh trong trẻo.', 250000, 50, 'tai_nghe_co_day.jpg', N'Còn hàng'),
(N'Bao da tablet', 6,  N'Bao da cho máy tính bảng, bảo vệ và thời trang.', 300000, 20, 'bao_da_tablet.jpg', N'Còn hàng'),
(N'Giá đỡ máy tính bảng', 6, N'Giá đỡ máy tính bảng, tiện lợi cho việc xem phim.', 150000, 30, 'gia_do_may_tinh_bang.jpg', N'Còn hàng'),
(N'Đế tản nhiệt laptop', 6, N'Đế tản nhiệt cho laptop, giúp máy mát hơn.', 400000, 18, 'de_tan_nhiet_laptop.jpg', N'Còn hàng'),
(N'Camera an ninh', 6, N'Camera an ninh kết nối WiFi, giám sát từ xa.', 1200000, 10, 'camera_an_ninh.jpg', N'Còn hàng'),
(N'Stand chơi game', 6, N'Stand để chơi game, hỗ trợ thoải mái khi chơi.', 350000, 15, 'stand_choi_game.jpg', N'Còn hàng'),
(N'Microphone USB', 6, N'Microphone USB cho việc ghi âm và stream.', 700000, 12, 'Microphone_usb.jpg', N'Còn hàng');
INSERT INTO GIOHANG (MaKhachHang, MaSanPham, SoLuong)  
VALUES 
(1, 1, 1),  
(1, 2, 2), 
(1, 3, 10),  
(2, 4, 3),  
(2, 5, 1),  
(17, 44, 1),
(17, 42, 1),
(18, 42, 1),
(20, 42, 1),
(5, 42, 1),
(18, 42, 1);

-- Đơn hàng
INSERT INTO HOADON (MaKhachHang, MaNhanVien, TongTien, TrangThaiDH, TgianCapnhat, PhuongThucTT, TrangThaiTT)
VALUES 
(1, 1, 500000, N'Chờ xác nhận', GETDATE(), N'Tiền mặt', N'Chưa thanh toán'),
(2, 2, 300000, N'Đang vận chuyển', GETDATE(), N'Chuyển khoản', N'Chưa thanh toán'),
(3, 1, 450000, N'Hoàn thành', GETDATE(), N'Tiền mặt', N'Đã thanh toán'),
(1, 3, 600000, N'Chờ xác nhận', GETDATE(), N'Chuyển khoản', N'Chưa thanh toán'),
(4, 2, 350000, N'Hủy',  GETDATE(), N'Tiền mặt', N'Chưa thanh toán'),
(2, 3, 700000, N'Hoàn thành', GETDATE(), N'Chuyển khoản', N'Đã thanh toán'),
(3, 1, 800000, N'Đang vận chuyển', GETDATE(), N'Tiền mặt', N'Chưa thanh toán'),
(5, 2, 900000, N'Chờ xác nhận', GETDATE(), N'Chuyển khoản', N'Chưa thanh toán'),
(6, 3, 200000, N'Hoàn thành',  GETDATE(), N'Tiền mặt', N'Đã thanh toán'),
(1, 1, 100000, N'Chờ xác nhận', GETDATE(), N'Chuyển khoản', N'Chưa thanh toán'),
(2, 2, 150000, N'Đang vận chuyển', GETDATE(), N'Tiền mặt', N'Chưa thanh toán'),
(3, 1, 250000, N'Hoàn thành', GETDATE(), N'Chuyển khoản', N'Đã thanh toán'),
(4, 2, 300000, N'Chờ xác nhận', GETDATE(), N'Tiền mặt', N'Chưa thanh toán'),
(5, 3, 400000, N'Hoàn thành', GETDATE(), N'Chuyển khoản', N'Đã thanh toán'),
(1, 1, 500000, N'Chờ xác nhận', GETDATE(), N'Tiền mặt', N'Chưa thanh toán'),
(2, 2, 600000, N'Đang vận chuyển', GETDATE(), N'Chuyển khoản', N'Chưa thanh toán'),
(3, 3, 700000, N'Hoàn thành',  GETDATE(), N'Tiền mặt', N'Đã thanh toán'),
(4, 1, 800000, N'Chờ xác nhận', GETDATE(), N'Chuyển khoản', N'Chưa thanh toán'),
(5, 2, 900000, N'Hoàn thành',  GETDATE(), N'Tiền mặt', N'Đã thanh toán'),
(6, 3, 1000000, N'Hủy',  GETDATE(), N'Chuyển khoản', N'Chưa thanh toán'),
(2, 1, 1100000, N'Chờ xác nhận', GETDATE(), N'Tiền mặt', N'Đã thanh toán');
INSERT INTO KHUYENMAI (TenKhuyenMai, MoTa, PhanTramGiamGia, NgayBatDau, NgayKetThuc, DieuKien) 
VALUES (N'Khách hàng thành viên', N'Khuyến mãi giảm giá cho tất cả sản phẩm mà khách hàng mua với điều kiện khách hàng đó thuộc loại VIP', '0.4', '2024-06-01', '2025-06-01', N'Mua từ 1 sản phẩm trở lên.'),
(N'Khách hàng VIP', N'Khuyến mãi giảm giá cho tất cả sản phẩm mà khách hàng mua với điều kiện khách hàng đó thuộc loại VIP', '0.5', '2024-06-01', '2025-06-01', N'Mua từ 1 sản phẩm trở lên.'),
(N'Giảm giá mùa hè', N'Khuyến mãi giảm giá cho tất cả sản phẩm trong mùa hè.', '0.15', '2024-06-01', '2024-08-31', N'Mua từ 2 sản phẩm trở lên.'),
(N'Tết Nguyên Đán', N'Giảm giá chào đón Tết Nguyên Đán.', '0.2', '2024-01-01', '2024-01-31', N'Mua bất kỳ sản phẩm nào.'),
(N'Black Friday', N'Khuyến mãi giảm giá cực sốc vào ngày Black Friday.', '30.3', '2024-11-24', '2024-11-24', N'Mua bất kỳ sản phẩm nào.'),
(N'Giảm giá sinh nhật', N'Giảm giá cho khách hàng có sinh nhật trong tháng.', '0.1', '2024-01-01', '2024-12-31', N'Xuất trình CMND có ngày sinh trong tháng.'),
(N'Khuyến mãi Giáng sinh', N'Khuyến mãi giảm giá nhân dịp Giáng sinh.', '0.25', '2024-12-20', '2024-12-26', N'Mua 3 sản phẩm trở lên.'),
(N'Khuyến mãi học sinh', N'Giảm giá cho học sinh, sinh viên với thẻ sinh viên.', '0.15', '2024-01-01', '2024-12-31', N'Xuất trình thẻ sinh viên.'),
(N'Khuyến mãi dịp lễ', N'Giảm giá vào các dịp lễ lớn trong năm.', '0.2', '2024-04-01', '2024-04-30', N'Mua từ 1 sản phẩm trở lên.'),
(N'Giảm giá khi mua sắm online', N'Giảm giá cho khách hàng mua sắm online.', '0.1', '2024-01-01', '2024-12-31', N'Mua sắm qua website chính thức.'),
(N'Thiên đường giảm giá', N'Giảm giá tất cả sản phẩm trong kho.', '0.5', '2024-09-01', '2024-09-30', N'Mua từ 5 sản phẩm trở lên.'),
(N'Giảm giá lần đầu tiên', N'Giảm giá cho khách hàng lần đầu tiên mua sắm.', '0.15', '2024-01-01', '2024-12-31', N'Mua lần đầu tiên.');
INSERT INTO CHITIETHD (MaHoaDon, MaSanPham, SoLuong, DonGia) VALUES
(1, 1, 2, 1500000),
(1, 2, 1, 2000000),
(2, 3, 5, 1000000),
(2, 4, 3, 750000),
(3, 5, 4, 300000),
(4, 16, 2, 500000),
(4, 17, 1, 1200000),
(5, 18, 3, 900000),
(6, 1, 1, 2200000),
(6, 11, 2, 300000),
(7, 12, 5, 800000),
(8, 13, 3, 950000),
(8, 34, 4, 1100000),
(9, 35, 2, 1250000),
(9, 26, 1, 1700000),
(10, 27, 3, 1300000),
(10, 18, 2, 2000000),
(11, 19, 4, 900000),
(12, 10, 1, 2500000);
INSERT INTO DANHGIA (MaSanPham, MaKhachHang, XepHang, NhanXet, NgayDanhGia)
VALUES 
(1, 1, 5, N'Sản phẩm rất tốt, tôi hài lòng với chất lượng!', DEFAULT),
(2, 2, 4, N'Giao hàng nhanh, sản phẩm đúng như mô tả.', DEFAULT),
(3, 3, 3, N'Sản phẩm ổn, nhưng cần cải thiện một số chi tiết.', DEFAULT),
(4, 4, 5, N'Tuyệt vời! Tôi sẽ mua thêm sản phẩm này lần nữa.', DEFAULT),
(5, 5, 2, N'Sản phẩm không như mong đợi, có thể cải thiện.', DEFAULT),
(6, 6, 4, N'Sản phẩm chất lượng, giao hàng nhanh chóng.', DEFAULT),
(7, 7, 1, N'Tôi rất thất vọng với sản phẩm này.', DEFAULT),
(8, 8, 3, N'Sản phẩm bình thường, không có gì nổi bật.', DEFAULT),
(9, 9, 5, N'Thật sự tốt, tôi rất hài lòng!', DEFAULT),
(10, 10, 4, N'Sản phẩm chất lượng, giao hàng đúng hẹn.', DEFAULT),
(11, 11, 2, N'Tôi không hài lòng với sản phẩm, không như quảng cáo.', DEFAULT),
(12, 12, 3, N'Sản phẩm ổn, nhưng không đáng giá với giá tiền.', DEFAULT),
(13, 13, 5, N'Rất hài lòng với chất lượng và dịch vụ.', DEFAULT),
(14, 14, 4, N'Sản phẩm tốt, nhưng nên cải thiện dịch vụ giao hàng.', DEFAULT),
(15, 15, 5, N'Tôi sẽ giới thiệu sản phẩm này cho bạn bè!', DEFAULT);

-- Phiếu nhập
INSERT INTO NHACUNGCAP (TenNCC, DiaChi, SoDienThoai, NgayBDCC) 
VALUES 
(N'Viettel', N'Số 1, Đường Giải Phóng, Quận Hoàng Mai, Hà Nội', '0987654321', '2015-01-01'),
(N'MobiFone', N'Số 2, Đường Nguyễn Thị Minh Khai, Quận 1, TP.HCM', '0901234567', '2016-05-10'),
(N'Vinaphone', N'Số 3, Đường Trần Hưng Đạo, Quận 5, TP.HCM', '0912345678', '2017-03-15'),
(N'FPT Telecom', N'Số 5, Đường Lê Đại Hành, Quận 11, TP.HCM', '0945678901', '2019-02-12'),
(N'VNPT', N'Số 6, Đường Cách Mạng Tháng Tám, Quận 10, TP.HCM', '0956789012', '2020-07-25'),
(N'Sacom', N'Số 7, Đường Nguyễn Văn Linh, Quận 7, TP.HCM', '0967890123', '2019-09-30'),
(N'Gtel', N'Số 8, Đường Bạch Đằng, Quận Tân Bình, TP.HCM', '0978901234', '2020-08-20'),
(N'NetNam', N'Số 9, Đường Trường Chinh, Quận Tân Bình, TP.HCM', '0989012345', '2021-06-15'),
(N'Viettel Post', N'Số 10, Đường Võ Văn Kiệt, Quận 1, TP.HCM', '0990123456', '2021-04-01'),
(N'SMSC', N'Số 11, Đường Điện Biên Phủ, Quận Bình Thạnh, TP.HCM', '0901230987', '2022-01-12'),
(N'Hanel', N'Số 12, Đường Lê Quý Đôn, Quận 3, TP.HCM', '0912345670', '2021-08-28'),
(N'VNPT IT', N'Số 13, Đường Bến Vân Đồn, Quận 4, TP.HCM', '0923456780', '2023-05-05'),
(N'FPT Software', N'Số 14, Đường Khu công nghệ cao, Quận 9, TP.HCM', '0934567891', '2022-10-10'),
(N'CyberSoft', N'Số 15, Đường Nguyễn Hữu Cảnh, Quận Bình Thạnh, TP.HCM', '0945678902', '2021-12-30');
INSERT INTO PHIEUNHAP (TongTien, PhuongThucTT, TrangThai, NgayThanhToan, MaNhanVien, MaNCC)
VALUES 
(500000, N'Tiền mặt', N'Đã thanh toán', GETDATE(), 1, 1),
(1500000, N'Chuyển khoản', N'Chưa thanh toán', GETDATE(), 2, 2),
(750000, N'Tiền mặt', N'Đã thanh toán', GETDATE(), 3, 3),
(200000, N'Tiền mặt', N'Chưa thanh toán', GETDATE(), 4, 4),
(1300000, N'Chuyển khoản', N'Đã thanh toán', GETDATE(), 5, 5),
(110000, N'Tiền mặt', N'Đã thanh toán', GETDATE(), 1, 1),
(550000, N'Tiền mặt', N'Chưa thanh toán', GETDATE(), 2, 2),
(990000, N'Chuyển khoản', N'Đã thanh toán', GETDATE(), 3, 3),
(420000, N'Tiền mặt', N'Đã thanh toán', GETDATE(), 4, 4),
(600000, N'Chuyển khoản', N'Chưa thanh toán', GETDATE(), 5, 5),
(350000, N'Tiền mặt', N'Đã thanh toán', GETDATE(), 1, 1),
(870000, N'Chuyển khoản', N'Chưa thanh toán', GETDATE(), 2, 2),
(910000, N'Tiền mặt', N'Đã thanh toán', GETDATE(), 3, 3),
(260000, N'Chuyển khoản', N'Đã thanh toán', GETDATE(), 4, 4),
(480000, N'Tiền mặt', N'Chưa thanh toán', GETDATE(), 5, 5),
(720000, N'Tiền mặt', N'Đã thanh toán', GETDATE(), 1, 1),
(1000000, N'Chuyển khoản', N'Chưa thanh toán', GETDATE(), 2, 2),
(680000, N'Tiền mặt', N'Đã thanh toán', GETDATE(), 3, 3),
(300000, N'Chuyển khoản', N'Chưa thanh toán', GETDATE(), 4, 4),
(250000, N'Tiền mặt', N'Đã thanh toán', GETDATE(), 5, 5);
INSERT INTO CHITIETPN (MaPhieuNhap, MaSanPham, SoLuong, GiaNhap)
VALUES
(1, 1, 10, 50000),
(1, 2, 5, 100000),
(2, 3, 20, 75000),
(2, 4, 8, 120000),
(3, 1, 15, 70000),
(3, 5, 25, 60000),
(4, 2, 30, 45000),
(5, 4, 10, 130000),
(6, 3, 7, 65000),
(6, 5, 12, 80000),
(7, 2, 20, 90000),
(8, 1, 5, 55000),
(9, 3, 25, 60000),
(10, 5, 10, 50000),
(11, 2, 8, 70000),
(12, 4, 15, 110000),
(13, 1, 12, 100000),
(14, 5, 9, 65000),
(15, 3, 18, 90000),
(20, 4, 11, 80000);
GO
-- ======================================== RÀNH BUỘC TOÀN VEN - TRIGGER ========================================
-- Khi xóa khách hàng thì MaKH trong USERS cx bị xóa
CREATE TRIGGER trg_Delete_KHACHHANG
ON KHACHHANG
AFTER DELETE
AS
BEGIN
    DELETE FROM USERS
    WHERE MaKhachHang IN (SELECT MaKhachHang FROM deleted);
END;
GO

-- Khi xóa khách hàng thì MaNV trong USERS cx bị xóa
CREATE TRIGGER trg_Delete_NHANVIEN
ON NHANVIEN
AFTER DELETE
AS
BEGIN
    DELETE FROM USERS
    WHERE MaNhanVien IN (SELECT MaNhanVien FROM deleted);
END;
GO

-- Cập nhật LoaiKH trong bảng KHACHHANG
CREATE TRIGGER trg_UpDATE_LOAIKH_KHACHHANG
ON HOADON
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE KHACHHANG
    SET LoaiKH = CASE 
                    WHEN TongTien >= 10000000 THEN N'Khách hàng VIP'
                    WHEN TongTien >= 5000000 THEN N'Khách hàng thành viên'
                    ELSE N'Khách hàng mới'
                END
    FROM KHACHHANG AS kh
    INNER JOIN (
        SELECT MaKhachHang, SUM(TongTien) AS TongTien
        FROM HOADON
        GROUP BY MaKhachHang
    ) AS dh ON kh.MaKhachHang = dh.MaKhachHang
    WHERE dh.TongTien IS NOT NULL;
END;
GO

-- Cập nhật số lượng tồn khi sản phẩm được thêm, xóa vào CHITIETHD
CREATE TRIGGER trg_UPDATE_SLGTON_INSERT_CHITIETHD
ON CHITIETHD
AFTER INSERT
AS
BEGIN
    UPDATE SANPHAM
    SET SoLuongTon = SoLuongTon - inserted.SoLuong
    FROM SANPHAM
    INNER JOIN inserted ON SANPHAM.MaSanPham = inserted.MaSanPham;
END; 
GO
CREATE TRIGGER trg_UPDATE_SLGTON_DELETE_CHITIETHD
ON CHITIETHD
AFTER DELETE
AS
BEGIN
    UPDATE SANPHAM
    SET SoLuongTon = SoLuongTon + deleted.SoLuong
    FROM SANPHAM
    INNER JOIN deleted ON SANPHAM.MaSanPham = deleted.MaSanPham;
END;
GO

-- Cập nhật trạng thái của sản phẩm
CREATE TRIGGER trg_UPDATE_SOLUONGTON_TRANGTHAI
ON SANPHAM
AFTER UPDATE
AS
BEGIN
    UPDATE SANPHAM
    SET TrangThai = 
        CASE 
            WHEN SoLuongTon = 0 THEN N'Hết hàng'
            WHEN SoLuongTon BETWEEN 1 AND 5 THEN N'Gần Hết'
            ELSE N'Còn hàng'
        END
    WHERE MaSanPham IN (SELECT MaSanPham FROM inserted);
END;
GO

-- Khi xóa khách hàng thì MaKH trong GIOHANG cx bị xóa
CREATE TRIGGER trg_DELETE_KHACHHANG_GIOHANG
ON KHACHHANG
AFTER DELETE
AS
BEGIN
    DELETE FROM GIOHANG
    WHERE MaKhachHang IN (SELECT MaKhachHang FROM deleted);
END;
GO

-- Cập nhật tổng tiền cho HOADON
CREATE TRIGGER trg_UPDATE_TONGTIEN_HOADON
ON CHITIETHD
AFTER INSERT, DELETE
AS
BEGIN
    DECLARE @MaHoaDon INT;
    SELECT @MaHoaDon = MaHoaDon FROM inserted
    WHERE MaHoaDon IS NOT NULL;
    UPDATE HOADON
    SET TongTien = (
        SELECT SUM(SoLuong * DonGia) 
        FROM CHITIETHD 
        WHERE MaHoaDon = @MaHoaDon
    )
    WHERE MaHoaDon = @MaHoaDon;
END;
GO

-- kiểm tra và cập nhật số lượng tồn cho các đơn hàng bị hủy
CREATE TRIGGER trg_CHECK_HUY_HOADON
ON HOADON
AFTER UPDATE
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted WHERE TrangThaiDH = N'Hủy')
    BEGIN
        DECLARE @MaHoaDon INT;
        SELECT @MaHoaDon = MaHoaDon FROM inserted;

        -- Cập nhật số lượng tồn cho tất cả sản phẩm trong đơn hàng bị hủy
        UPDATE SANPHAM
        SET SoLuongTon = SoLuongTon + (
            SELECT SoLuong FROM CHITIETHD WHERE MaHoaDon = @MaHoaDon
        )
        WHERE MaSanPham IN (
            SELECT MaSanPham FROM CHITIETHD WHERE MaHoaDon = @MaHoaDon
        );
    END
END;
GO

-- Kiểm tra thời gian khuyến mãi
CREATE TRIGGER trg_CHECK_THOIGIAN_KHUYENMAI
ON KHUYENMAI
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @NgayBatDau DATETIME;
    DECLARE @NgayKetThuc DATETIME;

    SELECT @NgayBatDau = NgayBatDau, @NgayKetThuc = NgayKetThuc FROM inserted;

    IF @NgayBatDau < @NgayKetThuc
    BEGIN
        RAISERROR('Ngày bắt đầu không được lớn hơn ngày kết thúc!', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- tự động cập nhật giá bán của sản phẩm trong bản chi tiết phiếu nhật nếu giá nhập đc sản phẩm bị trống
CREATE TRIGGER trg_UpDATEGiaNhapIfNULL
ON CHITIETPN
AFTER INSERT
AS
BEGIN
    -- Cập nhật GiaNhap thành GiaBan nếu GiaNhap không được cung cấp
    UPDATE CHITIETPN
    SET GiaNhap = (select GiaBan from SANPHAM)
    FROM CHITIETPN
    INNER JOIN inserted i ON CHITIETPN.MaSanPham = i.MaSanPham
    WHERE i.GiaNhap IS NULL;
END;
GO

-- Kiểm tra ngày vào làm của nhân viên
CREATE TRIGGER trg_CHECK_NgayVL
ON NHANVIEN
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM INSERTED
        WHERE NgayVL < GETDATE() -- NgayVL không được lớn hơn ngày hiện tại
    )
    BEGIN
        RAISERROR ('Ngày vào làm không được lớn hơn ngày hiện tại.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- Kiểm tra SĐT của nhân viên
CREATE TRIGGER KiemTraSDT_NhanVien
ON NHANVIEN
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE LEN(SoDienThoai) <> 10 
          OR SoDienThoai NOT LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
    )
    BEGIN
        RAISERROR('Số điện thoại phải gồm 10 chữ số và không được chứa ký tự chữ.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- Kiểm tra email của nhân viên
CREATE TRIGGER KiemTraEmail_NhanVien
ON NHANVIEN
AFTER INSERT, UPDATE
AS
BEGIN
    -- Kiểm tra email hợp lệ
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE Email NOT LIKE '%_@__%.__%'
    )
    BEGIN
        -- Nếu email không hợp lệ, hiển thị thông báo lỗi
        RAISERROR('Email không hợp lệ. Vui lòng nhập email đúng định dạng.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- Kiểm tra tuổi của nhân viên
Create TRIGGER KiemTraTuoiNhanVien
ON NHANVIEN
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE DATEDIFF(YEAR, NgaySinh, GETDATE()) < 18
    )
    BEGIN
        RAISERROR('Nhân viên phải đủ 18 tuổi.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- Kiểm tra SĐT của nhân viên
CREATE TRIGGER KiemTraSDT_KhachHang
ON KHACHHANG
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE LEN(SoDienThoai) <> 10 
          OR SoDienThoai NOT LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
    )
    BEGIN
        RAISERROR('Số điện thoại phải gồm 10 chữ số và không được chứa ký tự chữ.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- Kiểm tra email của nhân viên
CREATE TRIGGER KiemTraEmail_KhachHang
ON KHACHHANG
AFTER INSERT, UPDATE
AS
BEGIN
    -- Kiểm tra email hợp lệ
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE Email NOT LIKE '%_@__%.__%'
    )
    BEGIN
        -- Nếu email không hợp lệ, hiển thị thông báo lỗi
        RAISERROR('Email không hợp lệ. Vui lòng nhập email đúng định dạng.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- Kiểm tra ngày thêm sản phẩm vào giỏ hàng
CREATE TRIGGER trg_CHECK_NgayThem
ON GIOHANG
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM INSERTED
        WHERE NgayThem < GETDATE() 
    )
    BEGIN
        RAISERROR ('Ngày thêm vào giỏ hàng không được lớn hơn ngày hiện tại.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- Tự động cập nhật thời gian khi cập nhật trạng thái của đơn hàng
CREATE TRIGGER trg_UpDATETgianCapnhat
ON HOADON
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    -- Kiểm tra xem cột TrangThaiDH có được cập nhật hay không
    IF UPDATE(TrangThaiDH)
    BEGIN
        UPDATE DONHANG
        SET TgianCapnhat = GETDATE() -- Cập nhật thời gian hiện tại
        FROM DONHANG d
        INNER JOIN INSERTED i ON d.MaDonHang = i.MaDonHang; -- Liên kết với bảng INSERTED
    END
END;
GO

-- Kiểm tra thời gian cho Đơn hàng
CREATE TRIGGER trg_CHECK_ThoiGian_DonHang
ON HOADON
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra ngày giao hàng dự kiến
    IF EXISTS (
        SELECT 1
        FROM INSERTED
        WHERE NgayDHDK > CONVERT(DATE, GETDATE())
    )
    BEGIN
        RAISERROR ('Ngày giao hàng dự kiến không được nhỏ hơn ngày hiện tại', 16, 1);
        ROLLBACK TRANSACTION;
    END;

    -- Kiểm tra ngày giao hàng thực tế (chỉ khi không phải NULL)
    IF EXISTS (
        SELECT 1
        FROM INSERTED
        WHERE NgayGH IS NOT NULL AND NgayGH > CONVERT(DATE, GETDATE())
    )
    BEGIN
        RAISERROR ('Ngày giao hàng thực tế không được nhỏ hơn ngày hiện tại', 16, 1);
        ROLLBACK TRANSACTION;
    END;
    
    -- Cập nhật thời gian cập nhật đơn hàng (trigger khác đảm nhiệm cập nhật này)
    IF EXISTS (
        SELECT 1
        FROM INSERTED
        WHERE TgianCapnhat IS NOT NULL AND TgianCapnhat < GETDATE() or TgianCapnhat > GETDATE()
    )
    BEGIN
        RAISERROR ('Thời gian cập nhật đơn hàng phải là thời gian hiện tại hoặc tương lai', 16, 1);
        ROLLBACK TRANSACTION;
    END;
END;
GO

-- Kiểm tra ngày thanh toán phải sau ngày lập
CREATE TRIGGER trg_NgayThanhToan_after_NgayLap
ON HOADON
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra Ngày thanh toán phải sau hoặc bằng Ngày lập
    IF EXISTS (
        SELECT 1
        FROM INSERTED
        WHERE NgayTT IS NOT NULL 
          AND NgayTT < NgayDatHang
    )
    BEGIN
        RAISERROR ('Ngày thanh toán phải sau hoặc bằng Ngày lập.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;
END;
GO

-- Kiểm tra ngày đánh giá sản phẩm
CREATE TRIGGER trg_CHECK_NgayDanhGia
ON DANHGIA
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM INSERTED
        WHERE NgayDanhGia < GETDATE() 
    )
    BEGIN
        RAISERROR ('Ngày đánh giá không được lớn hơn ngày hiện tại.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- Kiểm tra SĐT của nhân viên
CREATE TRIGGER KiemTraSDT_NhaCungCap
ON NHACUNGCAP
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE LEN(SoDienThoai) <> 10 
          OR SoDienThoai NOT LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
    )
    BEGIN
        RAISERROR('Số điện thoại phải gồm 10 chữ số và không được chứa ký tự chữ.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- Kiểm tra ngày thanh toán phải sau ngày lập
CREATE TRIGGER trg_NgayThanhToan_after_NgayLap_PhieuNhap
ON PHIEUNHAP
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra Ngày thanh toán phải sau hoặc bằng Ngày lập
    IF EXISTS (
        SELECT 1
        FROM INSERTED
        WHERE NgayThanhToan IS NOT NULL 
          AND NgayThanhToan < NgayNhap
    )
    BEGIN
        RAISERROR ('Ngày thanh toán phải sau hoặc bằng Ngày lập.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;
END;
GO

-- Kiểm tra khi hóa đơn được thanh toán, đảm bảo rằng trạng thái của hóa đơn không bị thay đổi nếu đã thanh toán.
CREATE TRIGGER TRG_KtraTrangThaiHoaDonKhiThanhToan ON HOADON
AFTER UPDATE
AS
BEGIN
    -- Kiểm tra nếu hóa đơn đã thanh toán trong bảng deleted (trạng thái cũ)
    IF EXISTS (
        SELECT 1 
        FROM deleted d
        WHERE d.TrangThaiTT = N'Đã thanh toán'
        AND EXISTS (
            SELECT 1 
            FROM inserted i 
            WHERE i.MaHoaDon = d.MaHoaDon
            AND i.TrangThaiTT <> d.TrangThaiTT
        )
    )
    BEGIN
        RAISERROR (N'Không thể cập nhật hóa đơn đã thanh toán!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO


-- ======================================== PROCEDURE ========================================
-- Cập nhật loại khách hàng
CREATE PROCEDURE SP_UPDATE_LOAIKHACHHANG
AS
BEGIN
    -- Cập nhật loại khách hàng VIP
    UPDATE KHACHHANG
    SET LoaiKH = N'Khách hàng VIP'
    WHERE MaKhachHang IN (SELECT MaKhachHang FROM USERS)
	and MaKhachHang IN (SELECT MaKhachHang FROM HOADON  GROUP BY MaKhachHang HAVING SUM(TongTien) >= 10000000 );

    -- Cập nhật khách hàng thành viên
    UPDATE KHACHHANG
    SET LoaiKH = N'Khách hàng thành viên'
    WHERE MaKhachHang IN (SELECT MaKhachHang FROM USERS)
	and MaKhachHang IN (SELECT MaKhachHang FROM HOADON  GROUP BY MaKhachHang HAVING SUM(TongTien) BETWEEN 5000000 AND 9999999);

    -- Cập nhật khách hàng mới
    UPDATE KHACHHANG
    SET LoaiKH = N'Khách hàng mới'
    WHERE MaKhachHang IN (SELECT MaKhachHang FROM USERS)
	and MaKhachHang NOT IN (SELECT MaKhachHang FROM HOADON);
END;
GO

-- Cập nhật ngày giao hàng cho HOADON
CREATE PROCEDURE SP_UPDATE_NGAYGH
AS
BEGIN
    UPDATE HOADON
    SET NgayGH = GETDATE()  
    WHERE TrangThaiDH = N'Hoàn thành';
END
GO

-- Cập nhật trạng thái của sản phẩm
CREATE PROCEDURE SP_UPDATE_TRANGTHAI_SANPHAM
AS
BEGIN
    -- Cập nhật trạng thái sản phẩm dựa trên số lượng tồn
    UPDATE SANPHAM
    SET TrangThai = CASE
                        WHEN SoLuongTon = 0 THEN N'Hết hàng'
                        WHEN SoLuongTon < 5 THEN N'Gần hết'
                        ELSE N'Còn hàng'
                    END;
END;
GO


-- ================================ PHÂN QUYỀN ================================
--- Tạo Role cho Admin
CREATE ROLE admin_role;

-- Tạo Role cho Nhân viên
CREATE ROLE employee_role;

-- Tạo Role cho Khách hàng
CREATE ROLE user_role;

-- Quyền quản lý tài khoản và nhân viên
GRANT SELECT, INSERT, UPDATE, DELETE ON USERS TO admin_role;
GRANT SELECT, INSERT, UPDATE, DELETE ON NHANVIEN TO admin_role;
GRANT SELECT, INSERT, UPDATE, DELETE ON KHACHHANG TO admin_role;

-- Quyền quản lý sản phẩm và danh mục
GRANT SELECT, INSERT, UPDATE, DELETE ON SANPHAM TO admin_role;
GRANT SELECT, INSERT, UPDATE, DELETE ON DANHMUC TO admin_role;
GRANT SELECT, INSERT, UPDATE, DELETE ON KHUYENMAI TO admin_role;

-- Quyền quản lý đơn hàng
GRANT SELECT, INSERT, UPDATE, DELETE ON HOADON TO admin_role;

-- Quyền báo cáo và thống kê
GRANT SELECT ON SANPHAM TO admin_role;
GRANT SELECT ON HOADON TO admin_role;

-- Quyền kiểm kê hàng hóa và nhập hàng
GRANT SELECT, INSERT, UPDATE ON PHIEUNHAP TO employee_role;
GRANT SELECT, INSERT, UPDATE ON CHITIETPN TO employee_role;

-- Quyền theo dõi và cập nhật trạng thái đơn hàng
GRANT SELECT, UPDATE ON HOADON TO employee_role;

select *from USERS
-- Tạo login cho user admin
CREATE LOGIN [lan.nguyen369] WITH PASSWORD = '123456'; 
CREATE LOGIN [hung.tran963] WITH PASSWORD = '123456'; 
CREATE LOGIN [huong.le741] WITH PASSWORD = '123456'; 
CREATE LOGIN [khanh.pham852] WITH PASSWORD = '123456'; 
CREATE LOGIN [binh.hoang963] WITH PASSWORD = '123456'; 

-- Tạo tài khoản cho user admin
CREATE USER [lan.nguyen369] FOR LOGIN [lan.nguyen369];  
CREATE USER [hung.tran963] FOR LOGIN [hung.tran963];  
CREATE USER [huong.le741] FOR LOGIN [huong.le741];  
CREATE USER [khanh.pham852] FOR LOGIN [khanh.pham852];  
CREATE USER [binh.hoang963] FOR LOGIN [binh.hoang963];  
-- Gán role admin cho user
EXEC sp_addrolemember 'admin_role', 'lan.nguyen369';
EXEC sp_addrolemember 'admin_role', 'hung.tran963';
EXEC sp_addrolemember 'admin_role', 'huong.le741';
EXEC sp_addrolemember 'admin_role', 'khanh.pham852';
EXEC sp_addrolemember 'admin_role', 'binh.hoang963';

-- Cấp quyền kết nối 
GRANT CONNECT TO [lan.nguyen369];
GRANT CONNECT TO [hung.tran963];
GRANT CONNECT TO [huong.le741];
GRANT CONNECT TO [khanh.pham852];
GRANT CONNECT TO [binh.hoang963];


-- Tạo login cho các nhân viên
CREATE LOGIN [an.nguyen123] WITH PASSWORD = '123456'; 
CREATE LOGIN [bich.tran456] WITH PASSWORD = '123456'; 
CREATE LOGIN [huy.le789] WITH PASSWORD = '123456'; 
CREATE LOGIN [tuan.pham321] WITH PASSWORD = '123456'; 
CREATE LOGIN [thu.hoang654] WITH PASSWORD = '123456'; 
CREATE LOGIN [nam.vu987] WITH PASSWORD = '123456'; 
CREATE LOGIN [hoa.dang258] WITH PASSWORD = '123456'; 
CREATE LOGIN [phuc.bui369] WITH PASSWORD = '123456'; 
CREATE LOGIN [nga.do147] WITH PASSWORD = '123456'; 
CREATE LOGIN [dung.phan258] WITH PASSWORD = '123456'; 

-- Tạo tài khoản cho các nhân viên
CREATE USER [an.nguyen123] FOR LOGIN [an.nguyen123];  
CREATE USER [bich.tran456] FOR LOGIN [bich.tran456];  
CREATE USER [huy.le789] FOR LOGIN [huy.le789];  
CREATE USER [tuan.pham321] FOR LOGIN [tuan.pham321];  
CREATE USER [thu.hoang654] FOR LOGIN [thu.hoang654];  
CREATE USER [nam.vu987] FOR LOGIN [nam.vu987];  
CREATE USER [hoa.dang258] FOR LOGIN [hoa.dang258];  
CREATE USER [phuc.bui369] FOR LOGIN [phuc.bui369];  
CREATE USER [nga.do147] FOR LOGIN [nga.do147];  
CREATE USER [dung.phan258] FOR LOGIN [dung.phan258];  

-- Gán role cho nhân viên
EXEC sp_addrolemember 'employee_role', 'an.nguyen123';
EXEC sp_addrolemember 'employee_role', 'bich.tran456';
EXEC sp_addrolemember 'employee_role', 'huy.le789';
EXEC sp_addrolemember 'employee_role', 'tuan.pham321';
EXEC sp_addrolemember 'employee_role', 'thu.hoang654';
EXEC sp_addrolemember 'employee_role', 'nam.vu987';
EXEC sp_addrolemember 'employee_role', 'hoa.dang258';
EXEC sp_addrolemember 'employee_role', 'phuc.bui369';
EXEC sp_addrolemember 'employee_role', 'nga.do147';
EXEC sp_addrolemember 'employee_role', 'dung.phan258';

-- Cấp quyền kết nối cho các nhân viên
GRANT CONNECT TO [an.nguyen123];
GRANT CONNECT TO [bich.tran456];
GRANT CONNECT TO [huy.le789];
GRANT CONNECT TO [tuan.pham321];
GRANT CONNECT TO [thu.hoang654];
GRANT CONNECT TO [nam.vu987];
GRANT CONNECT TO [hoa.dang258];
GRANT CONNECT TO [phuc.bui369];
GRANT CONNECT TO [nga.do147];
GRANT CONNECT TO [dung.phan258];

GO
-- Tạo login và user cho từng khách hàng tự động
CREATE TRIGGER trg_GrantCustomerRole
ON USERS
AFTER INSERT
AS
BEGIN
    DECLARE @username NVARCHAR(100);
    
    -- Lấy tên người dùng từ bản ghi mới chèn vào
    SELECT @username = Username FROM inserted;

    -- Tạo login cho user khách hàng
    DECLARE @sql NVARCHAR(MAX);
    SET @sql = N'CREATE LOGIN [' + @username + '] WITH PASSWORD = ''DEFAULTpassword'';'; 
    EXEC sp_executesql @sql;

    -- Tạo user cho login vừa tạo
    SET @sql = N'CREATE USER [' + @username + '] FOR LOGIN [' + @username + '];'; 
    EXEC sp_executesql @sql;

    -- Gán role khách hàng cho user
    EXEC sp_addrolemember 'user_role', @username;

    -- Cấp quyền kết nối
    SET @sql = N'GRANT CONNECT TO [' + @username + '];'; 
    EXEC sp_executesql @sql;

    -- Cấp quyền cho user_role
    -- Quyền đăng ký và cập nhật thông tin cá nhân
    GRANT SELECT, INSERT, UPDATE ON USERS TO user_role;
    GRANT SELECT, UPDATE ON KHACHHANG TO user_role;

    -- Quyền quản lý giỏ hàng
    GRANT SELECT, INSERT, UPDATE, DELETE ON GIOHANG TO user_role;

    -- Quyền đặt hàng và theo dõi đơn hàng
    GRANT SELECT, INSERT, UPDATE ON HOADON TO user_role;

    -- Quyền đánh giá và phản hồi sản phẩm
    GRANT SELECT, INSERT, UPDATE, DELETE ON DANHGIA TO user_role;
END;
GO
-- Kiểm tra các user có role admin
SELECT dp.name AS UserName 
FROM sys.database_role_members AS drm 
JOIN sys.database_principals AS dp ON drm.member_principal_id = dp.principal_id 
WHERE drm.role_principal_id = USER_ID('admin_role'); --thay role để xem

GO
CREATE PROCEDURE XoaKhachHang
    @MaKhachHang INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM USERS WHERE MaKhachHang = @MaKhachHang)
    BEGIN
        -- Xóa khách hàng khỏi bảng USERS
        DELETE FROM USERS
        WHERE MaKhachHang = @MaKhachHang;

        PRINT 'Khách hàng đã được xóa thành công.';
    END
    ELSE
    BEGIN
        PRINT 'Khách hàng không tồn tại.';
    END
END;

GO
CREATE PROCEDURE QuanLySanPham
    @Action NVARCHAR(10), -- Hành động: 'ADD', 'UPDATE', 'DELETE'
    @MaSanPham INT = NULL, -- ID của sản phẩm (nếu có)
    @TenSanPham NVARCHAR(200) = NULL, -- Tên sản phẩm
    @MaDanhMuc INT = NULL, -- ID danh mục
    @MoTa NVARCHAR(250) = NULL, -- Mô tả sản phẩm
    @GiaBan FLOAT = NULL, -- Giá bán sản phẩm
    @SoLuongTon INT = NULL, -- Số lượng tồn
    @HinhAnh VARCHAR(255) = NULL, -- Hình ảnh sản phẩm
    @TrangThai NVARCHAR(100) = NULL -- Trạng thái sản phẩm
AS
BEGIN
    -- Kiểm tra quyền của người dùng
    IF NOT EXISTS (SELECT 1 FROM sys.database_role_members WHERE role_principal_id = (SELECT role_principal_id FROM sys.database_principals WHERE name = 'admin_role') AND member_principal_id = (SELECT principal_id FROM sys.database_principals WHERE name = USER_NAME()))
    BEGIN
        PRINT 'Bạn không có quyền thực hiện thao tác này.';
        RETURN;
    END

    -- Kiểm tra hành động
    IF @Action = 'ADD'
    BEGIN
        INSERT INTO SANPHAM (TenSanPham, MaDanhMuc, MoTa, GiaBan, SoLuongTon, HinhAnh, TrangThai)
        VALUES (@TenSanPham, @MaDanhMuc, @MoTa, @GiaBan, @SoLuongTon, @HinhAnh, @TrangThai);
        
        PRINT 'Sản phẩm đã được thêm thành công.';
    END
    ELSE IF @Action = 'UPDATE'
    BEGIN
        -- Kiểm tra xem sản phẩm có tồn tại không
        IF EXISTS (SELECT * FROM SANPHAM WHERE MaSanPham = @MaSanPham)
        BEGIN
            UPDATE SANPHAM
            SET TenSanPham = @TenSanPham,
                MaDanhMuc = @MaDanhMuc,
                MoTa = @MoTa,
                GiaBan = @GiaBan,
                SoLuongTon = @SoLuongTon,
                HinhAnh = @HinhAnh,
                TrangThai = @TrangThai
            WHERE MaSanPham = @MaSanPham;
            PRINT 'Sản phẩm đã được cập nhật thành công.';
        END
        ELSE
        BEGIN
            PRINT 'Sản phẩm không tồn tại.';
        END
    END
    ELSE IF @Action = 'DELETE'
    BEGIN
        -- Kiểm tra xem sản phẩm có tồn tại không
        IF EXISTS (SELECT * FROM SANPHAM WHERE MaSanPham = @MaSanPham)
        BEGIN
            DELETE FROM SANPHAM WHERE MaSanPham = @MaSanPham;
            PRINT 'Sản phẩm đã được xóa thành công.';
        END
        ELSE
        BEGIN
            PRINT 'Sản phẩm không tồn tại.';
        END
    END
    ELSE
    BEGIN
        PRINT 'Hành động không hợp lệ. Vui lòng sử dụng ADD, UPDATE hoặc DELETE.';
    END
END;


