---------------------------- TẠO DATABASE ----------------------------
CREATE DATABASE QL_NHAHANG
GO 
USE QL_NHAHANG
GO

---------------------------- TẠO BẢNG ----------------------------
-- KHACHHANG
CREATE TABLE KHACHHANG (
	IDKhachHang INT IDENTITY NOT NULL,
	HotenKH NVARCHAR(255) NOT NULL,
	DiaChi NVARCHAR(255) NULL CONSTRAINT DF_kHACHHANG_DIACHI DEFAULT ' ',
	SDT VARCHAR(12) NOT NULL,
	Email VARCHAR(50) NULL CONSTRAINT DF_KHACHHANG_EMAIL DEFAULT ' ',
	LoaiKH NVARCHAR(50) NULL CONSTRAINT DF_KHACHHANG_LOAIKH DEFAULT N'Khách hàng mới',
	CONSTRAINT PK_KHACHHANG PRIMARY KEY (IDKhachHang),
	CONSTRAINT CHK_KHACHHANG_LOAIKH CHECK (LoaiKH in (N'Khách hàng VIP', N'Khách hàng thành viên', N'Khách hàng mới'))
);

-- NHANVIEN
CREATE TABLE CHUCVU(
	 IDChucVu INT IDENTITY NOT NULL,
	 TenChucVu NVARCHAR(255) NOT NULL,
	 CONSTRAINT PK_CHUCVU PRIMARY KEY (IDChucVu),
	 CONSTRAINT UNI_CHUCVU_TEN UNIQUE (TenChucVu)
 );
CREATE TABLE NHANVIEN (
	IDNhanVien INT IDENTITY(1, 1) NOT NULL,
	HotenNV NVARCHAR(255) NOT NULL,
	NgaySinh DATE NULL CONSTRAINT DF_NHANVIEN_NGAYSINH DEFAULT NULL,
	SDT VARCHAR(12) NOT NULL,
	DiaChi NVARCHAR(255) NULL CONSTRAINT DF_NHANVIEN_DIACHI DEFAULT ' ',
	Email VARCHAR(50) NULL CONSTRAINT DF_NHANVIEN_EMAIL DEFAULT ' ',
	NgayVL DATE NOT NULL,
	LuongCoBan FLOAT NULL CONSTRAINT DF_NHANVIEN_LUONGCOBAN DEFAULT 0,
	GioiTinh NVARCHAR(10) NOT NULL,
	IdChucVu INT NULL CONSTRAINT DF_NHANVIEN_XET_CHUCVU DEFAULT 0,
	CONSTRAINT PK_NHANVIEN PRIMARY KEY (IDNhanVien),
	CONSTRAINT FK_NHANVIEN_CHUCVU FOREIGN KEY (IDChucVu) REFERENCES CHUCVU(IDChucVu),
	CONSTRAINT CHK_NHANVIEN_LUONGCOBAN CHECK(LuongCoBan >= 0),
	CONSTRAINT CHK_NHANVIEN_GIOITINH CHECK (GioiTinh in(N'Nam', N'Nữ', N'Khác'))
);
CREATE TABLE NGUOIDUNG(
	IDNhanVien INT NOT NULL,
	TenTK NVARCHAR(50) NOT NULL,
	MatKhau VARCHAR(50) NOT NULL,
	CONSTRAINT PK_NGUOIDUNG PRIMARY KEY (IDNhanVien),
	CONSTRAINT FK_NGUOIDUNG_NHANVIEN FOREIGN KEY (IDNhanVien) REFERENCES NHANVIEN(IDNhanVien),
	CONSTRAINT UNI_NGUOIDUNG_TENTK UNIQUE(TENTK)
);
CREATE TABLE CALAMVIEC(
	IDCaLamViec INT IDENTITY NOT NULL,
	TenCaLam NVARCHAR(50) NOT NULL,
	GioBD TIME,
	GioKT TIME,
	CONSTRAINT PK_CALAMVIEC PRIMARY KEY (IDCaLamViec),
	CONSTRAINT CHK_CALAMVIEC CHECK(TenCaLam in (N'Ca sáng', N'Ca chiều', N'Ca tối')),
	CONSTRAINT UNI_CALAMVEC_TEN UNIQUE (TenCaLam)
);

 -- BÀN
CREATE TABLE BAN (
	IDBan INT IDENTITY NOT NULL,
	TenBan NVARCHAR(50) NOT NULL,
	SoGhe INT NOT NULL,
	TrangThai NVARCHAR(125) NULL CONSTRAINT DF_BAN_TrangThai DEFAULT N'Bàn trống',
	CONSTRAINT PK_BAN PRIMARY KEY (IDBan) ,
	CONSTRAINT CHK_BAN_SOGHE CHECK (SoGhe > 0),
	CONSTRAINT CHK_BAN_TRANGTHAI CHECK (TrangThai in (N'Bàn trống', N'Bàn đã đặt trong ngày', N'Đã đặt trong 3 tiếng', N'Bàn đang ăn', N'Bàn hỏng'))
 );
CREATE TABLE PHANCONG ( 
	IDNhanVien INT NOT NULL, 
	IDCaLamViec INT NOT NULL, 
	IDBan INT NOT NULL,
	NgayLV DATE NOT NULL, 
	PhuTrachCV NVARCHAR(255) NULL CONSTRAINT DF_PHANCONG_PHUTRACHCV DEFAULT ' ',
	CONSTRAINT PK_PHANCONG PRIMARY KEY(IDNhanVien, IDCaLamViec, IDBan, NgayLV),
	CONSTRAINT FK_PHANCONG_NHANVIEN FOREIGN KEY (IDNhanVien) REFERENCES NHANVIEN(IDNhanVien),
	CONSTRAINT FK_PHANCONG_CALAMVIEC FOREIGN KEY(IDCaLamViec) REFERENCES CALAMVIEC(IDCaLamViec),
	CONSTRAINT FK_PHANCONG_BAN FOREIGN KEY (IDBan) REFERENCES BAN(IDBan)
);
CREATE TABLE DATBAN( 
	 IDDatBan INT IDENTITY NOT NULL,
	 IDKhachHang INT NOT NULL,
	 GioBD TIME NOT NULL,
	 NgayDB DATE NULL CONSTRAINT DF_DATBAN_NGAYBD DEFAULT GETDATE(),
	 SoluongBan INT NULL CONSTRAINT DF_DATBAN_SOLUONGBAN DEFAULT 0,
	 CONSTRAINT PK_DATBAN PRIMARY KEY (IDDatBan),
	 CONSTRAINT FK_DATBAN_KHACHHANG FOREIGN KEY (IDKhachHang) REFERENCES KHACHHANG(IDKhachHang),
	 CONSTRAINT CHK_DATBAN_SoLuongBan CHECK(SoluongBan >= 0)
 );
CREATE TABLE CHITIETDB(
	IDDatBan INT NOT NULL,
	IDBan INT NOT NULL,
	YeuCauDB NVARCHAR(255) NULL CONSTRAINT DF_DATBAN_YEUCAU DEFAULT ' ',
	Mota NVARCHAR(255) NULL CONSTRAINT DF_DATBAN_MOTA DEFAULT ' ',
	CONSTRAINT PK_CHITIETDB PRIMARY KEY (IDDatBan, IDBan),
	CONSTRAINT FK_CHITIETDB_DATBAN FOREIGN KEY (IDDatBan) REFERENCES DATBAN(IDDatBan),
	CONSTRAINT FK_CHITIETDB_BAN FOREIGN KEY (IDBan) REFERENCES BAN(IDBan)
);

-- MÓN
CREATE TABLE LOAIMON(
	IDLoaiMon INT IDENTITY(1,1) NOT NULL,
	TenLoaiMon NVARCHAR(255) NOT NULL,
	CONSTRAINT PK_LOAIMON PRIMARY KEY (IDLoaiMon),
	CONSTRAINT UNI_LOAIMON_TENLOAIMON UNIQUE (TenLoaiMon)
);
CREATE TABLE MON (
	IDMon INT IDENTITY(1,1) NOT NULL, 
	TenMon NVARCHAR(100) NOT NULL, 
	MoTa NVARCHAR(255) NULL CONSTRAINT DF_MON_MOTA DEFAULT ' ',
	DonGia FLOAT NOT NULL, 
	TrangThai NVARCHAR(255) NULL CONSTRAINT DF_MON_TRANGTHAI DEFAULT N'Có sẵn', 
	HinhAnh VARCHAR(MAX) NULL CONSTRAINT DF_MON_HINHANH DEFAULT ' ',
	IDLoaiMon INT NOT NULL,
	CONSTRAINT PK_MON PRIMARY KEY (IDMon),
	CONSTRAINT FK_MON_LOAIMON FOREIGN KEY(IDLoaiMon) REFERENCES LOAIMON(IDLoaiMon),
	CONSTRAINT CHK_DonGia CHECK(DonGia > 0),
	CONSTRAINT UNI_MON_TENMON UNIQUE (TenMon),
	CONSTRAINT CHK_MON_TRANGTHAI CHECK(TrangThai in(N'Có sẵn', N'Hết món'))
);
CREATE TABLE NGUYENLIEU (
	IDNguyenLieu INT IDENTITY(1,1) NOT NULL,
	TenNguyenLieu NVARCHAR(50) NOT NULL,
	SolgTon float NOT NULL, 
	DVT NVARCHAR(50) NOT NULL,
	TrangThaiNL nvarchar(100) CONSTRAINT DF_NGUYENLIEU_TRANGTHAI DEFAULT N'Có sẵn'
	CONSTRAINT PK_NGUYENLIEU PRIMARY KEY (IDNguyenLieu),
	CONSTRAINT UNI_NGUYENLIEU_TEN UNIQUE(TenNguyenLieu),
	CONSTRAINT CHK_NGUYENLIEU_SOLUONGTON CHECK(SolgTon >= 0),
	CONSTRAINT CHK_NGUYENLIEU_DVT CHECK(DVT in(N'ổ', 'g', 'Kg', 'ml', 'l', N'cái', N'muỗng', N'tép', N'miếng', N'quả', N'củ', N'nhánh')),
	CONSTRAINT CHK_NGUYENLIEU_TRANGTHAI CHECK(TrangThaiNL in (N'Có sẵn', N'Gần hết', N'Hết'))
);
CREATE TABLE CHITIETMON(
	IDMon INT NOT NULL,
	IDNguyenLieu INT NOT NULL,
	Soluong FLOAT NOT NULL,
	CONSTRAINT PK_CHITIETMON PRIMARY KEY (IDMon),
	CONSTRAINT FK_CHITIETMON_MON FOREIGN KEY (IDMon) REFERENCES MON(IDMon),
	CONSTRAINT FK_CHITIETMON_NGUYENLIEU FOREIGN KEY (IDNguyenLieu) REFERENCES NGUYENLIEU(IDNguyenLieu),
	CONSTRAINT CHK_CHITIETMON_SOLUONG CHECK(Soluong>=0)
);

 -- HÓA ĐƠN
CREATE TABLE KHUYENMAI(
	 IDKhuyenMai INT IDENTITY(1, 1) NOT NULL,
	 TenKhuyenMai NVARCHAR(255) NOT NULL,
	 NgayDB DATE NULL CONSTRAINT DF_KHUYENMAI_NGAYBD DEFAULT NULL,
	 NgayKT DATE NULL CONSTRAINT DF_KHUYENMAI_NGAYKT DEFAULT NULL,
	 PhanTram FLOAT NOT NULL,
	 DieuKien NVARCHAR(255) NOT NULL,
	 CONSTRAINT PK_KHUYENMAI PRIMARY KEY (IDKhuyenMai),
	 CONSTRAINT CHK_KHUYENMAI_THOIGIAN CHECK(NgayDB > NgayKT)
 );
CREATE TABLE HOADON( 
	 IDHoaDon INT IDENTITY(1, 1) NOT NULL, 
	 NgayLap DATE NULL CONSTRAINT DF_HOADON_NGAYLAP DEFAULT GetDate(), 
	 ThanhTien FLOAT NULL CONSTRAINT DF_HOADON_THANHTIEN DEFAULT 0,
	 PhuongThucTT NVARCHAR(100) NULL CONSTRAINT DF_HOADON_PHUONGHUCTT DEFAULT ' ',
	 TrangThaiTT NVARCHAR(50) NULL CONSTRAINT DF_HOADON_TRANGTHAITT DEFAULT N'Chưa thanh toán',
	 NgayThanhToan DATE NULL CONSTRAINT DF_HOADON_NGAYTHANHTOAN DEFAULT NULL,
	 IDKhachHang INT NOT NULL,
	 IDKhuyenMai INT NULL CONSTRAINT DF_HOADON_IDKHUYENMAI DEFAULT 0,
	 VAT FLOAT null CONSTRAINT DF_HOADON_VAT DEFAULT 0.1,
	 CONSTRAINT PK_HOADON PRIMARY KEY (IDHoaDon),
	 CONSTRAINT FK_HOADON_KHACHHANG FOREIGN KEY(IDKhachHang) REFERENCES KHACHHANG(IDKhachHang),
	 CONSTRAINT FK_HOADON_KHUYENMAI FOREIGN KEY(IDKhuyenMai) REFERENCES KHUYENMAI(IDKhuyenMai),
	 CONSTRAINT CHK_HOADON_THANHTIEN CHECK(ThanhTien>=0),
	 CONSTRAINT CHK_HOADON_PHUONGTHUCTT CHECK (PhuongThucTT in(N'Tiền mặt', N'Chuyển khoản', ' ')),
	 CONSTRAINT CHK_HOADON_TRANGTHAITT CHECK (TrangThaiTT in (N'Chưa thanh toán', N'Đã thanh toán'))
 );
CREATE TABLE CHITIETHD(
	IDHoaDon INT NOT NULL,
	IDBan INT NOT NULL,
	IDMon INT NOT NULL,
	SoLuong INT NOT NULL,
	DonGia FLOAT, 
	CONSTRAINT PK_CHITIETHD PRIMARY KEY (IDHoaDon, IDBan, IDMon),
	CONSTRAINT FK_CHITIETHD_HOADON FOREIGN KEY(IDHoaDon) REFERENCES HOADON(IDHoaDon),
	CONSTRAINT FK_CHITIETHD_MON FOREIGN KEY(IDMon) REFERENCES MON(IDMon),
	CONSTRAINT FK_CHITIETHD_BAN FOREIGN KEY (IDBan) REFERENCES BAN(IDBan),
	CONSTRAINT CHK_CHITIETHD_SOLUONG CHECK(Soluong > 0),
	CONSTRAINT CHK_CHITIETHD_DONGIA CHECK(DonGia > 0)
);
-- PHIÊU NHẬP
CREATE TABLE NHACUNGCAP(
	IDNhaCungCap INT IDENTITY(1,1) NOT NULL,
	TenNhaCungCap NVARCHAR(100) NOT NULL,
	SDT VARCHAR(12) NOT NULL, 
	DiaChi NVARCHAR(255) NULL CONSTRAINT DF_NHACUNGCAP_DIACHI DEFAULT ' ', 
	Email VARCHAR(50) NULL CONSTRAINT DF_NHACUNGCAP_EMAIL DEFAULT ' ', 
	NgayBDCC DATE NULL CONSTRAINT DF_NHACUNGCAP_NGAYBDCC DEFAULT GETDATE(),
	CONSTRAINT PK_NHACUNGCAP PRIMARY KEY (IDNhaCungCap),
	CONSTRAINT UNI_NHACUNGCAP_SDT UNIQUE (SDT)
); 
CREATE TABLE PHIEUNHAP(
	 IDPhieuNhap INT IDENTITY(1,1) NOT NULL,
	 NgayNhap DATE NULL CONSTRAINT DF_NGAYNHAP_PHIEUNHAP default GETDATE(),
	 TongTien FLOAT NULL CONSTRAINT DF_PHIEUNHAP_TONGTIEN DEFAULT 0,
	 PhuongThucTT NVARCHAR(100) NULL CONSTRAINT DF_PHIEUNHAP_PHUONGTHUCTT DEFAULT ' ',
	 TrangThai NVARCHAR(50) NULL CONSTRAINT DF_PHIEUNHAP_TRANGTHAI DEFAULT N'Chưa thanh toán',
	 NgayThanhToan DATE NULL CONSTRAINT DF_PHIEUNHAP_NGAYTHANHTOAN DEFAULT NULL,
	 IDNhanVien INT NOT NULL,
	 IDNhaCungCap INT NOT NULL,
	 CONSTRAINT PK_PHIEUNHAP PRIMARY KEY (IDPhieuNhap),
	 CONSTRAINT FK_PHIEUNHAP_NHACUNGCAP FOREIGN KEY(IDNhaCungCap) REFERENCES NHACUNGCAP(IDNhaCungCap),
	 CONSTRAINT FK_PHIEUNHAP_NHANVIEN FOREIGN KEY(IDNhanVien) REFERENCES NHANVIEN(IDNhanVien),
	 CONSTRAINT CHK_PHIEUNHAP_TONGTIEN CHECK(TongTien >= 0),
	 CONSTRAINT CHK_PHIEUNHAP_PHUONGTHUCTT CHECK (PhuongThucTT in(N'Tiền mặt', N'Chuyển khoản',' ')),
	 CONSTRAINT CHK_PHIEUNHAP_NGAYTHANHTOAN CHECK(N-gayNhap >= NgayThanhToan),
	 CONSTRAINT CHK_PHIEUNHAP_TRANGTHAI CHECK (TrangThai in (N'Chưa thanh toán', N'Đã thanh toán'))
 );
CREATE TABLE  CHITIETPN(
	  IDPhieuNhap INT NOT NULL,
	  IDNguyenLieu INT NOT NULL,
	  SoLuong INT NOT NULL,
	  GiaNhap FLOAT NOT NULL,
	  CONSTRAINT PK_CHITIETPN PRIMARY KEY (IDPhieuNhap, IDNguyenLieu),
	  CONSTRAINT FK_CHITIETPN_PHIEUNHAP FOREIGN KEY(IDPhieuNhap) REFERENCES PHIEUNHAP(IDPhieuNhap),
	  CONSTRAINT FK_CHITIETPN_NGUYENLIEU FOREIGN KEY(IDNguyenLieu) REFERENCES NGUYENLIEU(IDNguyenLieu),
	  CONSTRAINT CHK_CHITIETPN_SoLuong CHECK(Soluong > 0),
	  CONSTRAINT CHK_CHITIETPN_GiaNhap CHECK(GiaNhap > 0)
);

---------------------------- THÊM DỮ LIỆU ----------------------------
INSERT INTO KHACHHANG (HotenKH, DiaChi, SDT, Email, LoaiKH) 
VALUES 
    (N'Vãng lai',default, '0123456789', default, default),
    (N'Nguyễn Văn An', N'12 Lý Thường Kiệt, Hà Nội', '0987654321', 'nguyenvanan@gmail.com', N'Khách hàng VIP'),
    (N'Trần Thị Bích Ngọc', N'45 Trần Hưng Đạo, TP.HCM', '0912345678', 'ngoctran@yahoo.com', N'Khách hàng thành viên'),
    (N'Phạm Quốc Khánh', N'23 Phan Chu Trinh, Đà Nẵng', '0908765432', 'khanhpham@gmail.com', N'Khách hàng mới'),
    (N'Lê Thị Thu Hà', N'78 Nguyễn Trãi, Hà Nội', '0932456789', 'thuha.le@gmail.com', N'Khách hàng thành viên'),
    (N'Bùi Văn Minh', N'102 Lạc Long Quân, Hà Nội', '0943567890', 'minhbui@gmail.com', N'Khách hàng VIP'),
    (N'Hoàng Phương Linh', N'56 Nguyễn Văn Cừ, Hải Phòng', '0915678901', 'linhhoang@hotmail.com', N'Khách hàng thành viên'),
    (N'Đỗ Mạnh Hùng', N'89 Pasteur, TP.HCM', '0909876543', 'hungdo@outlook.com', N'Khách hàng mới'),
    (N'Nguyễn Thị Hồng', N'67 Lê Duẩn, Đà Nẵng', '0962345678', 'hongnguyen@yahoo.com', N'Khách hàng VIP'),
    (N'Vũ Thanh Tùng', N'32 Hoàng Văn Thụ, Cần Thơ', '0931234567', 'tungvu@gmail.com', N'Khách hàng thành viên'),
    (N'Trịnh Thu Trang', N'123 Điện Biên Phủ, Hải Phòng', '0979876543', 'trangtrinh@gmail.com', N'Khách hàng mới'),
    (N'Phan Văn Quang', N'21 Nguyễn Văn Linh, Huế', '0987651234', 'quangphan@hotmail.com', N'Khách hàng thành viên'),
    (N'Lý Minh Phúc', N'98 Võ Văn Tần, Hà Nội', '0951234567', 'phucly@gmail.com', N'Khách hàng VIP'),
    (N'Nguyễn Hữu Tài', N'88 Lý Chính Thắng, TP.HCM', '0922345678', 'tai.nguyen@gmail.com', N'Khách hàng thành viên'),
    (N'Tô Thị Yến', N'73 Bạch Đằng, Đà Nẵng', '0912345789', 'yent@gmail.com', N'Khách hàng mới'),
    (N'Phạm Anh Tuấn', N'42 Hùng Vương, Nha Trang', '0938765432', 'tuanpham@gmail.com', N'Khách hàng VIP'),
    (N'Lê Hoài Nam', N'90 Nguyễn Huệ, TP.HCM', '0945432187', 'hoainam@gmail.com', N'Khách hàng thành viên'),
    (N'Doãn Thị Mai', N'11 Cách Mạng Tháng 8, Hà Nội', '0952345678', 'maid@hotmail.com', N'Khách hàng VIP'),
    (N'Võ Thị Kim Chi', N'34 Hoàng Diệu, Đà Nẵng', '0972349876', 'kimchi@gmail.com', N'Khách hàng mới'),
    (N'Trần Văn Phú', N'71 Tôn Đức Thắng, Cần Thơ', '0982345789', 'phutran@yahoo.com', N'Khách hàng thành viên'),
    (N'Ngô Thanh Bình', N'15 Nguyễn Thị Minh Khai, TP.HCM', '0967890123', 'binhngo@gmail.com', N'Khách hàng VIP');
GO
INSERT INTO CHUCVU (TenChucVu) 
VALUES 
    (N'Nhân viên quản lý'),
    (N'Nhân viên phục vụ'),
    (N'Nhân viên thu ngân'),
    (N'Nhân viên bếp');
GO
INSERT INTO NHANVIEN (HotenNV, Ngaysinh, SDT, DiaChi, Email, NgayVL, LuongCoBan, GioiTinh, IdChucVu) 
VALUES
    (N'Châu Đức Toàn', '2004-12-16', '0941544797', N'Nguyễn Quý Anh, TP.HCM', 'toanpl060@gmail.com', '2022-01-10', 50000, N'Nam', 1),
    (N'Ngô Minh Thuận', '2004-05-19', '0783363383', N'157/29/01 Bùi Minh Trực, Phường 5, Quận 8', 'thuanthichlaptrinh@gmail.com', '2022-01-10', 50000, N'Nam', 1),
    (N'Lương Thanh Bình', '2004-08-24', '0359276823', N'763 Tây Thạnh, TP.HCM', 'thanhbinh12b4lh2022@gmail.com', '2021-09-15', 45000, N'Nam', 4),
    (N'Nguyễn Trọng Yến Linh', '2004-03-09', '0346798974', N'102 Nguyễn Quý Anh, Tân Sơn Nhì, Tân Phú, TP.HCM', 'nguyenyenlinh0102004@gmail.com', '2020-06-20', 45000, N'Nữ', 4),
    (N'Nguyễn Mạnh Quân', '2004-05-26', '0829359149', N'26/05/2004, Bình Chánh, TP.HCM', 'quan11012295@gmail.com', '2023-03-01', 50000, N'Nam', 1),
    (N'Hoàng Văn Khôi', '1985-07-10', '0943567891', N'102 Lạc Long Quân, Hà Nội', 'khoivan@gmail.com', '2019-12-01', 45000, N'Nam', 4),
    (N'Vũ Thị Thuỷ Tiên', '1992-09-03', '0915678904', N'56 Nguyễn Văn Cừ, Hải Phòng', 'tienthuy@gmail.com', '2022-05-25', 45000, N'Nữ', 4),
    (N'Bùi Mạnh Cường', '1987-11-22', '0909876544', N'89 Pasteur, TP.HCM', 'cuongbui@gmail.com', '2020-08-10', 30000, N'Nam', 2),
    (N'Ngô Thị Kim Ngân', '1994-10-18', '0962345679', N'67 Lê Duẩn, Đà Nẵng', 'kimngan@gmail.com', '2023-07-30', 35000, N'Nữ', 3),
    (N'Phan Văn Hậu', '1989-03-05', '0931234568', N'32 Hoàng Văn Thụ, Cần Thơ', 'hauphan@gmail.com', '2021-04-11', 30000, N'Nam', 2),
	(N'Tô Thị Bảo Ngọc', '1991-12-15', '0979876545', N'123 Điện Biên Phủ, Hải Phòng', 'baongoc@gmail.com', '2023-09-01', 45000, N'Nữ', 4),
    (N'Trần Quang Vinh', '1990-01-30', '0987651235', N'21 Nguyễn Văn Linh, Huế', 'quangvinh@gmail.com', '2018-11-05', 30000, N'Nam', 2),
    (N'Lê Thị Xuân', '1993-05-22', '0951234569', N'98 Võ Văn Tần, Hà Nội', 'xuanle@gmail.com', '2022-02-14', 35000, N'Nữ', 3),
    (N'Nguyễn Phúc Hưng', '1986-09-13', '0922345677', N'88 Lý Chính Thắng, TP.HCM', 'hungphuc@gmail.com', '2020-01-25', 30000, N'Nam', 2),
    (N'Trương Hồng Phát', '1991-07-01', '0912345790', N'73 Bạch Đằng, Đà Nẵng', 'phattruong@gmail.com', '2023-03-20', 35000, N'Nam', 3),
    (N'Đỗ Thị Mỹ Duyên', '1995-06-08', '0938765433', N'42 Hùng Vương, Nha Trang', 'myduyen@gmail.com', '2022-12-05', 30000, N'Nữ', 2),
    (N'Tô Văn Đức', '1988-11-14', '0945432188', N'90 Nguyễn Huệ, TP.HCM', 'vandu@gmail.com', '2019-10-10', 35000, N'Nam', 3),
    (N'Hoàng Phương Vy', '1992-04-19', '0952345681', N'11 Cách Mạng Tháng 8, Hà Nội', 'vyphuong@gmail.com', '2021-06-17', 30000, N'Nữ', 2),
    (N'Phạm Văn Thịnh', '1989-08-25', '0972349877', N'34 Hoàng Diệu, Đà Nẵng', 'thinhpham@gmail.com', '2020-09-01', 35000, N'Nam', 3),
    (N'Võ Thị Anh Đào', '1994-02-07', '0982345791', N'71 Tôn Đức Thắng, Cần Thơ', 'anhdao@gmail.com', '2022-04-23', 30000, N'Nữ', 2),
    (N'Ngô Minh Châu', '1993-12-09', '0967890124', N'15 Nguyễn Thị Minh Khai, TP.HCM', 'chau.ngo@gmail.com', '2021-02-08', 30000, N'Nữ', 2);
GO
INSERT INTO NGUOIDUNG (IDNhanVien, TenTK, MatKhau) 
VALUES
	(1, N'ChauDucToan', 'DucToanDepTrai'),
	(2, N'NgoMinhThuan', 'Thuan123'),
	(3, N'LuongThanhBinh', 'Binh789!'),
	(4, N'NguyenTrongYenLinh', 'Yenlinh123'),
	(5, N'HoangVanKhoi', 'Khoi@2023'),
	(6, N'NguyenManhQuan', 'Quan@2023'),
	(7, N'vuthithuytien', 'Tien#987'),
	(8, N'buimanhCuong', 'Cuong456!'),
	(9, N'ngothikimngan', 'Ngankim!123'),
	(10, N'phanvanhau', 'Hau@789'),
	(11, N'tothibaongoc', 'Ngoc987*'),
	(12, N'tranquangvinh', 'Vinh2022'),
	(13, N'lethixuan', 'Xuan!123'),
	(14, N'nguyenphuchung', 'Hung456'),
	(15, N'truonghongphat', 'Phat@789'),
	(16, N'dothimyduyen', 'Duyen321'),
	(17, N'tovanduc', 'Duc#456'),
	(18, N'hoangphuongvy', 'Vy!123'),
	(19, N'phamvanthinh', 'Thinh@789'),
	(20, N'vothianhdao', 'Dao987'),
	(21, N'ngominhchau', 'Chau#321');
GO
INSERT INTO CALAMVIEC (TenCaLam, GioBD, GioKT) 
VALUES
    (N'Ca sáng', '07:00:00', '12:00:00'),
    (N'Ca chiều', '12:00:00', '17:00:00'),
    (N'Ca tối', '17:00:00', '22:00:00');
GO
INSERT INTO BAN (TenBan, SoGhe) 
VALUES 
    (N'Bàn 1', 4),
    (N'Bàn 2', 6),
    (N'Bàn 3', 4),
    (N'Bàn 4', 8),
    (N'Bàn 5', 2),
    (N'Bàn 6', 4),
    (N'Bàn 7', 6),
    (N'Bàn 8', 4),
    (N'Bàn 9', 8),
    (N'Bàn 10', 2),
    (N'Bàn 11', 4),
    (N'Bàn 12', 6),
    (N'Bàn 13', 4),
    (N'Bàn 14', 8),
    (N'Bàn 15', 2),
    (N'Bàn 16', 4),
    (N'Bàn 17', 6),
    (N'Bàn 18', 4),
    (N'Bàn 19', 8),
    (N'Bàn 20', 2);
GO
INSERT INTO PHANCONG (IDNhanVien, IDCaLamViec, IDBan, NgayLV, PhuTrachCV)
VALUES
    (8, 1, 1, '2024-10-17', N'Phụ trách bàn 1'),
    (8, 1, 2, '2024-10-17', N'Phụ trách bàn 2'),
    (10, 1, 3, '2024-10-17', N'Phụ trách bàn 3'),
    (10, 1, 4, '2024-10-17', N'Phụ trách bàn 4'),
    (12, 1, 5, '2024-10-17', N'Phụ trách bàn 5'),
    (12, 1, 6, '2024-10-17', N'Phụ trách bàn 6'),
    (14, 1, 7, '2024-10-17', N'Phụ trách bàn 7'),
    (14, 1, 8, '2024-10-17', N'Phụ trách bàn 8'),
    (16, 2, 1, '2024-10-17', N'Phụ trách bàn 1'),
    (16, 2, 2, '2024-10-17', N'Phụ trách bàn 2'),
    (18, 2, 3, '2024-10-17', N'Phụ trách bàn 3'),
    (18, 2, 4, '2024-10-17', N'Phụ trách bàn 4'),
    (20, 2, 5, '2024-10-17', N'Phụ trách bàn 5'),
    (20, 2, 6, '2024-10-17', N'Phụ trách bàn 6'),
    (21, 2, 7, '2024-10-17', N'Phụ trách bàn 7'),
    (21, 2, 8, '2024-10-17', N'Phụ trách bàn 8'),
    (8, 3, 9, '2024-10-17', N'Phụ trách bàn 9'),
    (8, 3, 10, '2024-10-17', N'Phụ trách bàn 10'),
    (10, 3, 11, '2024-10-17', N'Phụ trách bàn 11'),
    (10, 3, 12, '2024-10-17', N'Phụ trách bàn 12'),
    (12, 3, 13, '2024-10-17', N'Phụ trách bàn 13'),
    (12, 3, 14, '2024-10-17', N'Phụ trách bàn 14'),
    (14, 3, 15, '2024-10-17', N'Phụ trách bàn 15'),
    (14, 3, 16, '2024-10-17', N'Phụ trách bàn 16'),
	(16, 1, 11, '2024-10-18', N'Phụ trách bàn 11'),
    (16, 1, 12, '2024-10-18', N'Phụ trách bàn 12'),
    (18, 1, 13, '2024-10-18', N'Phụ trách bàn 13'),
    (18, 1, 14, '2024-10-18', N'Phụ trách bàn 14'),
    (20, 1, 15, '2024-10-18', N'Phụ trách bàn 15'),
    (20, 1, 16, '2024-10-18', N'Phụ trách bàn 16'),
    (21, 1, 17, '2024-10-18', N'Phụ trách bàn 17'),
    (21, 1, 18, '2024-10-18', N'Phụ trách bàn 18'),
    (8, 2, 13, '2024-10-18', N'Phụ trách bàn 13'),
    (8, 2, 14, '2024-10-18', N'Phụ trách bàn 14'),
    (10, 2, 15, '2024-10-18', N'Phụ trách bàn 15'),
    (10, 2, 16, '2024-10-18', N'Phụ trách bàn 16'),
    (12, 2, 17, '2024-10-18', N'Phụ trách bàn 17'),
    (12, 2, 18, '2024-10-18', N'Phụ trách bàn 18'),
    (14, 2, 19, '2024-10-18', N'Phụ trách bàn 19'),
    (14, 2, 20, '2024-10-18', N'Phụ trách bàn 20'),
    (16, 3, 1, '2024-10-18', N'Phụ trách bàn 1'),
    (16, 3, 2, '2024-10-18', N'Phụ trách bàn 2'),
    (18, 3, 3, '2024-10-18', N'Phụ trách bàn 3'),
    (18, 3, 4, '2024-10-18', N'Phụ trách bàn 4'),
    (20, 3, 5, '2024-10-18', N'Phụ trách bàn 5'),
    (20, 3, 6, '2024-10-18', N'Phụ trách bàn 6'),
    (21, 3, 7, '2024-10-18', N'Phụ trách bàn 7'),
    (21, 3, 8, '2024-10-18', N'Phụ trách bàn 8');
GO
INSERT INTO DATBAN (IDKhachHang, GioBD, NgayDB,SoluongBan) 
VALUES
	(1, '8:00:00', GETDATE(),default),
	(2, '02:00:00', '2024-10-20', default),
	(3, '18:30:00', '2024-10-21', default),
	(4, '19:15:00', '2024-10-21', default),
	(5, '21:00:00', '2024-10-22', default),
	(6, '18:00:00', '2024-10-22', default),
	(7, '20:30:00', '2024-10-23', default),
	(8, '19:45:00', '2024-10-23', default),
	(9, '21:00:00', '2024-10-24', default),
	(10, '18:15:00', '2024-10-24', default),
	(11, '19:30:00', '2024-10-25', default),
	(12, '20:00:00', '2024-10-25', default),
	(13, '05:00:00', default, default),
	(14, '21:30:00', default, default),
	(15, '18:00:00', default, default);
GO
INSERT INTO CHITIETDB (IdDatBan, IDBan, YeuCauDB, Mota) 
VALUES (5,4,default, default),
	(10, 1, N'Thích ngồi gần cửa sổ', N'Khách hàng yêu cầu bàn gần cửa sổ.'),
	(1, 2, N'Yêu cầu thêm ghế', N'Khách hàng muốn thêm ghế cho bàn.'),
	(2, 3, N'Thích không gian yên tĩnh', N'Khách hàng yêu cầu bàn trong góc yên tĩnh.'),
	(3, 4, N'Yêu cầu bàn gần quầy bar', N'Khách hàng yêu cầu gần quầy bar.'),
	(4, 5, N'Thích bàn lớn', N'Khách hàng yêu cầu bàn cho 6 người.'),
	(5, 6, N'Yêu cầu bàn ngoài trời', N'Khách hàng muốn ngồi ngoài trời.'),
	(6, 7, N'Yêu cầu ghế cao', N'Khách hàng yêu cầu ghế cao cho bàn.'),
	(7, 8, N'Thích bàn gần quầy thu ngân', N'Khách hàng yêu cầu bàn gần quầy thu ngân.'),
	(8, 9, N'Thích không gian gần cửa ra vào', N'Khách hàng yêu cầu bàn gần cửa ra vào.'),
	(9, 10, N'Yêu cầu ngồi riêng', N'Khách hàng yêu cầu bàn riêng cho 2 người.'),
	(11, 11, default, default),
	(12, 12,default,default),
	(13, 13,default,default);
GO
INSERT INTO LOAIMON (TenLoaiMon) 
VALUES
    (N'Khai vị'),
    (N'Món chính'),
    (N'Đồ ăn kèm'),
    (N'Món tráng miệng'),
    (N'Đồ uống'),
    (N'Món nướng'),
    (N'Món chiên'),
    (N'Lẩu'),
    (N'Món hấp');
GO
INSERT INTO MON (TenMon, IDLoaiMon, MoTa, DonGia, TrangThai, Hinhanh) 
VALUES
    (N'Gỏi cuốn', 2, N'Gỏi cuốn tươi ngon với rau sống và tôm.', 50000, N'Có sẵn', '1_goicuon.png'),
    (N'Phở bò', 2, N'Món phở truyền thống với thịt bò và nước dùng.', 70000, N'Có sẵn', '2_phobo.png'),
    (N'Tiramisu', 4, N'Món tráng miệng ngọt ngào với cà phê và mascarpone.', 60000, N'Có sẵn', '3_tiramisu.png'),
    (N'Salad trộn', 2, N'Salad tươi ngon với rau và sốt đặc biệt.', 40000, N'Có sẵn', '4_salad.png'),
    (N'Nước cam tươi', 5, N'Nước cam tươi mát lạnh.', 25000, N'Có sẵn', '5_NuocCam.png'),
    (N'Socola', 4, N'Món ngọt từ sô cô la đặc biệt.', 30000, N'Có sẵn', '6_socola.png'),
    (N'Gà xào sả ớt', 2, N'Món gà xào với sả và ớt, thơm ngon.', 80000, N'Có sẵn', '7_gaxaoxaoot.png'),
    (N'Chả giò', 1, N'Món chả giò giòn rụm, thơm ngon.', 60000, N'Có sẵn', '8_chagio.png'),
    (N'Tôm rang muối', 2, N'Tôm rang muối, món ăn đặc sản miền biển.', 90000, N'Có sẵn', '9_tomrangmuoi.png'),
    (N'Sườn nướng', 6, N'Sườn heo nướng mật ong thơm ngon.', 120000, N'Có sẵn', '10_suongnuong.png'),
    (N'Cá kho tộ', 2, N'Cá kho tộ đậm đà hương vị miền Nam.', 110000, N'Có sẵn', '11_cakhoto.png'),
    (N'Soup măng', 1, N'Soup măng tươi mát, thanh nhiệt.', 35000, N'Có sẵn', '12_soupmang.png'),
    (N'Bánh bao', 9, N'Bánh bao nhân thịt, nóng hổi.', 20000, N'Có sẵn', '13_banhbao.png'),
    (N'Khoai tây chiên', 3, N'Khoai tây chiên giòn rụm, ăn kèm sốt.', 45000, N'Có sẵn', '14_khoaitaychien.png'),
    (N'Mỳ Ý sốt bò bằm', 2, N'Mỳ Ý thơm ngon với sốt bò bằm đặc biệt.', 75000, N'Có sẵn', '15_misotbobam.png'),
    (N'Bún thịt nướng', 2, N'Bún tươi với thịt nướng và nước mắm chua ngọt.', 60000, N'Có sẵn', '16_bunthitnuong.png'),
    (N'Bánh mì ốp la', 2, N'Bánh mì nóng giòn kèm trứng ốp la và pate.', 30000, N'Có sẵn', '17_banhmiopla.png'),
    (N'Gỏi xoài', 3, N'Gỏi xoài chua cay, thơm ngon với tôm khô.', 45000, N'Có sẵn', '18_goixoai.png'),
    (N'Bún bò Huế', 2, N'Món bún bò Huế truyền thống với hương vị đậm đà.', 70000, N'Có sẵn', '19_bunbohue.png'),
    (N'Mẹt nem nướng', 2, N'Nem nướng đặc sản Nha Trang thơm ngon.', 65000, N'Có sẵn', '20_metnemnuong.png'),
    (N'Cơm gà xối mỡ', 2, N'Cơm gà giòn rụm với nước mắm đặc biệt.', 80000, N'Có sẵn', '21_comgaxoimo.png'),
    (N'Cháo hải sản', 2, N'Cháo nóng hổi với tôm, mực và nghêu.', 50000, N'Có sẵn', '22_chaohaisan.png'),
    (N'Kem trái cây', 4, N'Kem tươi mát với các loại trái cây nhiệt đới.', 30000, N'Có sẵn', '23_kemtraicay.png'),
    (N'Lẩu Thái', 8, N'Lẩu chua cay Thái Lan với hải sản.', 350000, N'Có sẵn', '24_lauthai.png'),
    (N'Cà ri gà', 2, N'Món cà ri gà với nước cốt dừa thơm ngon.', 90000, N'Có sẵn', '25_cariga.png'),
    (N'Sinh tố bơ', 5, N'Sinh tố làm từ quả bơ tươi, béo ngậy và bổ dưỡng', 40000, DEFAULT, '27_SinhToBo.png'),
    (N'Xôi xoài', 4, N'Món tráng miệng nổi tiếng của Thái Lan, kết hợp giữa xoài và xôi ngọt', 65000, DEFAULT, '28_MangoStickyRice.png'),
    (N'Cá hồi nướng', 6, N'Cá hồi nướng thơm ngon, giàu Omega-3, tốt cho sức khỏe', 200000, DEFAULT, '29_CaHoiNuong.png'),
    (N'Trứng chiên hàu', 2, N'Trứng chiên giòn với hàu tươi, món ngon lạ miệng', 75000, DEFAULT, '30_TrungChienHau.png'),
    (N'Cá hồi kho tiêu', 2, N'Cá hồi kho tiêu đậm đà hương vị, thịt cá chắc và mềm', 100000, DEFAULT, '31_Cahoikho.png'),
    (N'Sinh tố xoài', 5, N'Sinh tố xoài thơm mát, giải nhiệt ngày hè', 20000, DEFAULT, '32_sinhtoxoai.png'),
    (N'Sinh tố dừa', 5, N'Sinh tố dừa tươi mát, bổ sung năng lượng', 25000, DEFAULT, '33_Sinhtodua.png'),
    (N'Gà chiên nước mắm', 2, N'Gà chiên giòn quyện cùng nước mắm đậm đà', 70000, DEFAULT, '34_Gachiennuocmam.png'),
    (N'Phở gà', 2, N'Phở gà truyền thống, nước dùng thanh ngọt, sợi phở mềm', 50000, DEFAULT, '35_Phoga.png'),
    (N'Tôm chiên bột', 2, N'Tôm chiên giòn phủ bột, hấp dẫn và thơm ngon', 40000, DEFAULT, '36_tomchienbot.png'),
    (N'Gà hấp lá chanh', 9, N'Gà hấp với lá chanh thơm mát, thịt gà mềm và ngọt', 70000, DEFAULT, '38_Gahaplachanh.png'),
    (N'Canh chua cá lóc',2, N'Canh chua cá lóc miền Tây, vị chua ngọt hài hòa', 100000, DEFAULT, '39_Canhchua.png'),
    (N'Mì xào hải sản', 2, N'Mì xào hải sản tươi ngon, đầy đủ dinh dưỡng', 50000, DEFAULT, '40_MiXaohaisan.png'),
    (N'Gà nướng muối ớt', 6, N'Gà nướng muối ớt cay nồng, hấp dẫn', 100000, DEFAULT, '41_Ganuong.png'),
    (N'Tôm rang nước mắm', 2, N'Tôm rang nước mắm đậm đà, hương vị khó quên', 60000, DEFAULT, '42_Tomrang.png'),
    (N'Bò nấu lagu', 2, N'Bò nấu lagu thơm ngon, thịt bò mềm, đậm vị', 150000, DEFAULT, '43_Bonaulagu.png'),
    (N'Bánh quy socola', 4, N'Bánh quy giòn với lớp socola ngọt ngào', 40000, DEFAULT, '44_Banhquy.png'),
    (N'Gà rán', 1, N'Gà rán giòn tan, lớp vỏ ngoài vàng ruộm, bên trong mềm', 70000, DEFAULT, '45_garan.png'),
    (N'Bún riêu cua', 2, N'Bún riêu cua thơm ngon, nước dùng đậm đà', 35000, DEFAULT, '46_Bunrieu.png'),
	(N'Hàu nướng mỡ hành', 6, N'Hàu tươi nướng cùng mỡ hành, thơm ngậy, đậm đà', 100000, DEFAULT, '47_Haunuong.png'),
    (N'Bạc xĩu', 5, N'Cà phê sữa đậm đà, thêm sữa tạo vị ngọt dịu nhẹ', 25000, DEFAULT, '48_Bacxiu.png'),
    (N'Cà phê sữa', 5, N'Cà phê sữa truyền thống, hòa quyện vị đắng và ngọt', 25000, DEFAULT, '49_Cafesua.png'),
    (N'Bò lúc lắc', 2, N'Món bò lúc lắc mềm ngon, đậm đà gia vị', 50000, DEFAULT, '50_Boluclac.png');
GO
INSERT INTO NGUYENLIEU (TenNguyenLieu, SolgTon, DVT) 
VALUES (N'Hàu', 30, 'Kg'),
	(N'Trái cây tổng hợp', 20, N'Kg'), 
	(N'Mỳ', 10 , N'Kg'), 
	(N'Bánh mỳ', 40, N'ổ'),
	(N'Phở', 30, N'Kg'),
	(N'Khoai tây', 10, N'Kg'),
	(N'Măng', 10, N'Kg'),
	(N'Socola', 100, 'g'),
	(N'Kem', 5, N'Kg'),
	(N'Cà phê', 2, N'g'),
	(N'Bún',30, N'Kg'),
    (N'Heo', 50, N'Kg'),
    (N'bánh tráng', 50, N'Kg'),
    (N'Tôm', 50, N'Kg'),
    (N'Gà', 100, N'Kg'),
    (N'Bò', 70, N'Kg'),
    (N'Cá', 60, N'Kg'),
    (N'Rau sống', 200, N'Kg'),
    (N'Đường', 20, N'Kg'),
    (N'Tiêu', 10, N'Kg'),
    (N'Bột ngũ vị hương', 5, N'g'),
    (N'Sả', 30, N'Kg'),
    (N'Ớt', 15, N'Kg'),
    (N'Hành', 25, N'Kg'),
    (N'Gừng', 10, N'Kg'),
    (N'Phô mai', 25, N'g'),
    (N'Nước mắm', 50, N'l'),
    (N'Sốt mayonnaise', 30, N'l'),
    (N'Trứng', 200, N'quả'),
    (N'Hải sản tổng hợp', 40, N'Kg'),
	(N'Bột làm bánh',10,N'Kg'),
	(N'Cua', 10, N'Kg')
GO
INSERT INTO CHITIETMON (IDMon,IDNguyenLieu, Soluong) 
VALUES  (1,14,0.3), 
		(2, 16,0.2), 
		(3, 31, 0.4),
		(4, 18, 0.5),
		(5, 2, 0.2),
		(6, 8, 50),
		(7, 15,1.5), 
		(8, 12, 0.5), 
		(9, 14, 1),
		(10, 12, 1),
		(11, 17, 1),
		(12, 7, 0.5),
		(13, 31, 0.5), 
		(14, 6, 0.3), 
		(15, 16, 0.3),
		(16, 12, 10),
		(17, 4, 1), 
		(18, 2, 1),
		(19, 16, 0.3),
		(20, 12, 0.5),
		(21, 15, 0.4),
		(22, 30, 1), 
		(23, 9, 0.3), 
		(24, 30, 5),
		(25, 15, 1.5),
		(26, 2, 0.3), 
		(27, 2, 0.2), 
		(28, 17, 1), 
		(29, 1, 2), 
		(30, 17, 1),
		(31, 2, 0.3), 
		(32, 2, 0.3),
		(33, 15, 1), 
		(34, 15, 0.4),
		(35, 14, 0.5),
		(36, 15, 2),
		(37, 17, 1),
		(38,30,0.5),
		(39,15,2),
		(40,14,0.5),
		(41,16,1),
		(42,8,100),
		(43,15,1),
		(44,32,1),
		(45,1,2),
		(46,10,40),
		(47,10,50),
		(48,16,0.4);
GO

INSERT INTO KHUYENMAI (TenKhuyenMai, NgayDB, NgayKT, PhanTram, DieuKien) 
VALUES
   (N'Giảm giá 5%', '2024-11-04', null, 0.05, N'Ăn từ 5 món'),
   (N'Giảm giá 7%', '2024-11-04', null, 0.07, N'Ăn từ 8 món'),
   (N'Giảm giá 10%', '2024-11-04', null, 0.10, N'Khách hàng VIP'),
   (N'Giảm giá 7%', '2024-11-04', null, 0.07, N'Khách hàng thành viên'), 
   (N'Tặng thẻ thành viên', '2024-11-04', null, 0, N'Khách hàng mới');
GO
INSERT INTO HOADON (NgayLap, ThanhTien, PhuongThucTT, TrangThaiTT, NgayThanhToan, IDKhachHang, IDKhuyenMai) 
VALUES
    (default, 300000, N'Tiền mặt', N'Chưa thanh toán', default, 2,2),
    ('2024-01-15', 500000, N'Chuyển khoản', N'Đã thanh toán', '2024-01-15', 1, 1),
    ('2024-03-05', 450000, N'Chuyển khoản', N'Đã thanh toán', '2024-03-05', 3,3),
    ('2024-04-20', 600000, N'Tiền mặt', N'Chưa thanh toán', default, 4, 4),
    ('2024-05-25', 250000, N'Chuyển khoản', N'Đã thanh toán', '2024-05-25', 5,1),
    ('2024-06-30', 800000, N'Tiền mặt', N'Chưa thanh toán', default, 6,2),
    ('2024-07-15', 900000, N'Chuyển khoản', N'Đã thanh toán', '2024-07-15', 7,3),
    ('2024-08-10', 700000, N'Tiền mặt', N'Chưa thanh toán', default, 8,4),
    ('2024-09-12', 350000, N'Chuyển khoản', N'Đã thanh toán', '2024-09-12', 9,1),
    ('2024-10-01', 550000, N'Tiền mặt', N'Chưa thanh toán', default, 10,2),
    ('2024-10-20', 400000, N'Chuyển khoản', N'Đã thanh toán', '2024-10-20', 1,2),
    ('2024-11-10', 600000, N'Tiền mặt', N'Chưa thanh toán', default, 12,4),
    ('2024-11-15', 250000, N'Chuyển khoản', N'Đã thanh toán', '2024-11-15', 13,1),
    ('2024-12-20', 300000, N'Tiền mặt', N'Chưa thanh toán', default, 14,4),
    ('2025-01-01', 500000, N'Chuyển khoản', N'Đã thanh toán', '2025-01-01', 15,4);
GO
INSERT INTO CHITIETHD (IDHoaDon, IDBan, IDMon, SoLuong, DonGia) 
VALUES
    (1, 8, 8, 3, 150000),
    (9, 9, 9, 2, 200000),
    (10, 10, 10, 1, 350000),
    (11, 11, 11, 2, 450000),
    (12, 12, 12, 1, 50000),
    (13, 13, 13, 4, 60000);
GO

INSERT INTO NHACUNGCAP (TenNhaCungCap, SDT, DiaChi, Email, NgayBDCC) 
VALUES
    (N'Công ty TNHH ABC', '0123456789', N'Số 1, Đường XYZ, Quận 1, TP.HCM', 'abc@domain.com', '2023-01-01'),
    (N'Công ty Cổ phần XYZ', '0987654321', N'Số 2, Đường DEF, Quận 2, TP.HCM', 'xyz@domain.com', '2023-02-01'),
    (N'Công ty TNHH PQR', '0123456780', N'Số 3, Đường GHI, Quận 3, TP.HCM', 'pqr@domain.com', '2023-03-01'),
    (N'Công ty TNHH MNO', '0987654320', N'Số 4, Đường JKL, Quận 4, TP.HCM', 'mno@domain.com', '2023-04-01'),
    (N'Công ty Cổ phần STU', '0123456790', N'Số 5, Đường OPQ, Quận 5, TP.HCM', 'stu@domain.com', '2023-05-01'),
    (N'Công ty TNHH VWX', '0987654310', N'Số 6, Đường RST, Quận 6, TP.HCM', 'vwx@domain.com', '2023-06-01'),
    (N'Công ty TNHH YZA', '0123456781', N'Số 7, Đường UVW, Quận 7, TP.HCM', 'yza@domain.com', '2023-07-01'),
    (N'Công ty TNHH BCD', '0987654322', N'Số 8, Đường TUV, Quận 8, TP.HCM', 'bcd@domain.com', '2023-08-01'),
    (N'Công ty Cổ phần EFG', '0123456791', N'Số 9, Đường WXY, Quận 9, TP.HCM', 'efg@domain.com', '2023-09-01'),
    (N'Công ty TNHH HIJ', '0987654311', N'Số 10, Đường ZAB, Quận 10, TP.HCM', 'hij@domain.com', '2023-10-01'),
    (N'Công ty TNHH KLM', '0123456782', N'Số 11, Đường CDE, Quận 11, TP.HCM', 'klm@domain.com', '2023-11-01'),
    (N'Công ty Cổ phần NOP', '0987654323', N'Số 12, Đường FGH, Quận 12, TP.HCM', 'nop@domain.com', '2023-12-01'),
    (N'Công ty TNHH QRS', '0123456792', N'Số 13, Đường IJK, Quận 13, TP.HCM', 'qrs@domain.com', '2024-01-01'),
    (N'Công ty TNHH TUV', '0987654312', N'Số 14, Đường LMN, Quận 14, TP.HCM', 'tuv@domain.com', '2024-02-01'),
    (N'Công ty Cổ phần WXY', '0123456783', N'Số 15, Đường OPQ, Quận 15, TP.HCM', 'wxy@domain.com', '2024-03-01');
GO
INSERT INTO PHIEUNHAP (IDNhaCungCap, NgayNhap, IDNhanVien, TongTien, PhuongThucTT, TrangThai, NgayThanhToan) ---
VALUES
    (1, '2024-01-05', 1, 1500000, N'Tiền mặt', N'Đã thanh toán', '2024-01-05'),
    (2, '2024-02-10', 2, 3000000, N'Chuyển khoản', DEFAULT, NULL),
    (3, '2024-03-15', 3, 2500000, N'Tiền mặt', N'Đã thanh toán', '2024-03-15'),
    (4, '2024-04-20', 4, 1800000, N'Chuyển khoản', DEFAULT, NULL),
    (5, '2024-05-25', 5, 4000000, N'Tiền mặt', DEFAULT, '2024-05-25'),
    (6, '2024-06-30', 6, 3500000, N'Chuyển khoản', DEFAULT, NULL),
    (7, '2024-07-15', 7, 2000000, N'Tiền mặt', N'Đã thanh toán', '2024-07-15'),
    (8, '2024-08-10', 8, 5000000, N'Chuyển khoản', DEFAULT, NULL),
    (9, '2024-09-12', 9, 6000000, N'Tiền mặt', N'Đã thanh toán', '2024-09-12'),
    (10, '2024-10-14', 16, 3200000, N'Chuyển khoản', DEFAULT, NULL),
    (11, '2024-11-20', 11, 2900000, N'Tiền mặt', N'Đã thanh toán', '2024-11-20'),
    (12, '2024-12-25', 12, 4300000, N'Chuyển khoản', DEFAULT, NULL),
    (13, '2025-01-05', 13, 3100000, N'Tiền mặt', DEFAULT, '2025-01-05'),
    (14, '2025-02-10', 14, 2200000, N'Chuyển khoản', DEFAULT, NULL),
    (15, '2025-03-12', 15, 2800000, N'Tiền mặt', DEFAULT, '2025-03-12');
GO
INSERT INTO CHITIETPN (IDPhieuNhap, IDNguyenLieu, SoLuong, GiaNhap) 
VALUES
	(1, 1, 10, 15000),
	(11, 2, 20, 20000),
	(2, 3, 15, 18000),
	(12, 4, 8, 25000),
	(3, 5, 6, 30000),
    (13, 6, 10, 35000),
	(4, 7, 90, 22000),
	(14, 8, 10, 28000),
	(15, 9, 70, 40000),
	(15, 10, 50, 50000),
	(6, 11, 140, 45000),
	(6, 12, 110, 48000),
	(7, 13, 100, 30000),
	(7, 14, 60, 35000),
	(8, 15, 80, 22000);
GO
---------------------------- TRIGGER ----------------------------
-- Kiểm tra trùng SDT và EMAIL của khách hàng 
CREATE TRIGGER TRG_KhachHang_sdt_email
ON KHACHHANG
AFTER INSERT, UPDATE
AS
BEGIN
    -- Chỉ kiểm tra khi có thay đổi ở cột SDT hoặc Email
    IF UPDATE(SDT) OR UPDATE(Email)
    BEGIN
        -- Kiểm tra độ dài số điện thoại
        IF EXISTS (SELECT 1 FROM inserted WHERE LEN(SDT) < 10 OR LEN(SDT) > 12)
        BEGIN
            RAISERROR (N'Số điện thoại phải có từ 10 đến 12 số!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Kiểm tra email hợp lệ
        IF EXISTS (SELECT 1 FROM inserted WHERE Email <> ' ' AND Email NOT LIKE N'%_@__%.__%')
        BEGIN
            RAISERROR (N'Email không hợp lệ!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Kiểm tra trùng lặp số điện thoại
        IF EXISTS (
            SELECT 1
            FROM inserted i
            JOIN KHACHHANG k ON k.SDT = i.SDT
            WHERE i.SDT IS NOT NULL 
            AND k.IDKhachHang <> i.IDKhachHang
        )
        BEGIN
            RAISERROR (N'Số điện thoại đã tồn tại. Vui lòng nhập số điện thoại khác.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Kiểm tra trùng lặp email
        IF EXISTS (
            SELECT 1
            FROM inserted i
            JOIN KHACHHANG k ON k.Email = i.Email and i.Email <> ' '
            WHERE i.Email IS NOT NULL 
            AND k.IDKhachHang <> i.IDKhachHang
        )
        BEGIN
            RAISERROR (N'Email đã tồn tại. Vui lòng nhập email khác.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
    END
END;
GO

-- kiểm tra ngày sinh phải trước ngày vào làm và nhân viên phải trên 18 tuổi 
CREATE TRIGGER TRG_KiemTraTuoivaNgaySinh
ON NHANVIEN
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @Ngaysinh DATE;
    DECLARE @NgayVL DATE;
    DECLARE cur CURSOR FOR
    SELECT Ngaysinh, NgayVL FROM INSERTED;

    OPEN cur;
    FETCH NEXT FROM cur INTO @Ngaysinh, @NgayVL;

    WHILE @@FETCH_STATUS = 0
    BEGIN
		IF @Ngaysinh >= @NgayVL
		 BEGIN
            RAISERROR ('Ngày sinh phải trước ngày vào làm', 16, 1);
            ROLLBACK TRANSACTION; 
            RETURN;
        END
        IF DATEDIFF(YEAR, @Ngaysinh, @NgayVL) < 18
        BEGIN
            RAISERROR ('Nhân viên phải trên 18 tuổi.', 16, 1);
            ROLLBACK TRANSACTION; 
            RETURN;
        END
        FETCH NEXT FROM cur INTO @Ngaysinh, @NgayVL;
    END
    CLOSE cur;
    DEALLOCATE cur;
END;
GO

--  Kiểm tra trùng SDT và EMAIL của nhân viên  
CREATE TRIGGER TRG_NhanVien_sdt_email
ON NHANVIEN
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra định dạng số điện thoại
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE LEN(SDT) < 10 OR LEN(SDT) > 12
    )
    BEGIN
        RAISERROR (N'Số điện thoại phải có từ 10 đến 12 số!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Kiểm tra định dạng email
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE Email NOT LIKE '%_@__%.__%'
    )
    BEGIN
        RAISERROR (N'Email không hợp lệ!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Kiểm tra trùng lặp số điện thoại
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN NHANVIEN n ON i.SDT = n.SDT
        WHERE i.IdNhanVien <> n.IdNhanVien
    )
    BEGIN
        RAISERROR (N'Số điện thoại đã tồn tại!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Kiểm tra trùng lặp email
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN NHANVIEN n ON i.Email = n.Email
        WHERE i.IdNhanVien <> n.IdNhanVien
    )
    BEGIN
        RAISERROR (N'Email đã tồn tại!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO

CREATE TRIGGER TRG_GioDatBan_GioiHan
ON DATBAN
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @NgayDB DATE, @GioBD TIME;
    SELECT @NgayDB = NgayDB, @GioBD = GioBD FROM inserted;
    
    -- Kiểm tra giờ đặt bàn
    IF (CAST(@GioBD AS TIME) < '06:00' OR CAST(@GioBD AS TIME) > '20:00')
    BEGIN
        RAISERROR ('Giờ đặt bàn phải nằm trong khoảng từ 6:00 đến 20:00.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;

GO

-- Kiểm tra trùng ngày giờ đặt bàn
CREATE TRIGGER TRG_KiemTraTrungGioDatBan
ON CHITIETDB
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @NgayDB DATE;
    DECLARE @GioBD TIME;
    DECLARE @IDDatBan INT;
    DECLARE @IDBan INT;

    SELECT @IDDatBan = IDDatBan, @IDBan = IDBan
    FROM INSERTED;

    SELECT @NgayDB = NgayDB, @GioBD = GioBD
    FROM DATBAN
    WHERE IDDatBan = @IDDatBan;

    IF EXISTS (
        SELECT 1
        FROM CHITIETDB AS ct
        JOIN DATBAN AS db ON ct.IDDatBan = db.IDDatBan
        WHERE db.NgayDB = @NgayDB
          AND ct.IDBan = @IDBan
          AND ABS(DATEDIFF(MINUTE, db.GioBD, @GioBD)) < 180  -- Cách nhau dưới 3 giờ
          AND ct.IDDatBan <> @IDDatBan
    )
    BEGIN
        RAISERROR ('Bàn này đã được đặt trong khoảng thời gian này. Vui lòng chọn thời gian khác hoặc bàn khác.', 16, 1);
        ROLLBACK TRANSACTION;
    END
    ELSE

    BEGIN
        INSERT INTO CHITIETDB (IDDatBan, IDBan, YeuCauDB, Mota)
        SELECT IDDatBan, IDBan, YeuCauDB, Mota
        FROM INSERTED;
    END
END; 
GO

-- Cập nhật trạng thái món ăn dựa trên nguyên liệu
CREATE TRIGGER TRG_Capnhaptrangthaimon_Nguyenlieu
ON NGUYENLIEU
AFTER UPDATE
AS
BEGIN
    UPDATE MON
    SET TrangThai = N'Hết món'
    FROM MON 
    INNER JOIN CHITIETMON ON MON.IDMon = CHITIETMON.IDMon
    INNER JOIN NGUYENLIEU ON CHITIETMON.IDNguyenLieu = NGUYENLIEU.IDNguyenLieu
    WHERE NGUYENLIEU.SolgTon < CHITIETMON.Soluong;

    UPDATE MON
    SET TrangThai = N'Có sẵn'
    FROM MON 
    INNER JOIN CHITIETMON ON MON.IDMon = CHITIETMON.IDMon
    INNER JOIN NGUYENLIEU ON CHITIETMON.IDNguyenLieu = NGUYENLIEU.IDNguyenLieu
    WHERE NGUYENLIEU.SolgTon >= CHITIETMON.Soluong;
END;
GO

--  Tự động cập nhật NgayTT nếu TrangThaiTT được cập nhật
CREATE TRIGGER TRG_UpdateThoiGianThanhToan
ON HOADON
AFTER UPDATE
AS
BEGIN
    -- Kiểm tra nếu trạng thái thanh toán được cập nhật
    IF EXISTS (
        SELECT 1
        FROM INSERTED i
        JOIN DELETED d ON i.IDHoaDon = d.IDHoaDon 
        WHERE i.TrangThaiTT = N'Đã thanh toán' 
          AND d.TrangThaiTT <> N'Đã thanh toán'
    )
    BEGIN
        -- Cập nhật thời gian thanh toán
        UPDATE HOADON  
		SET NgayThanhToan = GETDATE()  
        FROM HOADON
        WHERE TrangThaiTT = N'Đã thanh toán';
    END
END;
GO

-- Cập nhật số lượng bàn dựa trên CHITIETDB
CREATE TRIGGER TRG_CapNhatSoLuongBan_Them_Xoa
ON CHITIETDB
AFTER INSERT, DELETE
AS
BEGIN
   UPDATE DATBAN
    SET SoLuongBan = (
        SELECT COUNT(*) 
        FROM CHITIETDB 
        WHERE CHITIETDB.IDDatBan = DATBAN.IDDatBan
    )
    WHERE IDDatBan IN (
        SELECT IDDatBan FROM INSERTED
        UNION
        SELECT IDDatBan FROM DELETED
    );
END;
GO

-- Cập nhật trạng thái bàn nếu HOADON đã thanh toán
CREATE TRIGGER TRG_CapNhatTrangThaiBan_ThanhToan
ON HOADON
AFTER UPDATE
AS
BEGIN
    DECLARE @IDHoaDon INT;
    SELECT @IDHoaDon = IDHoaDon FROM inserted;
    -- Cập nhật trạng thái bàn thành 'Đã thanh toán' khi hóa đơn đã thanh toán
    UPDATE BAN
    SET TrangThai = N'Bàn trống'
    FROM BAN 
    JOIN CHITIETHD ON BAN.IDBan = CHITIETHD.IDBan
    WHERE CHITIETHD.IDHoaDon = @IDHoaDon
      AND EXISTS (SELECT 1 FROM inserted WHERE inserted.IDHoaDon = @IDHoaDon AND inserted.TrangThaiTT = N'Đã thanh toán')
END;
GO

-- Khi thêm món ăn mới, giá món phải lớn hơn 0 và trạng thái món phải là "Có sẵn" hoặc "Hết".
CREATE TRIGGER TRG_KiemTraKhiThemMon ON MON
FOR INSERT
AS
BEGIN
    DECLARE @DonGia FLOAT, @TrangThai NVARCHAR(255);
    SELECT @DonGia = DonGia, @TrangThai = TrangThai 
	FROM inserted;

    IF (@DonGia <= 0)
    BEGIN
        RAISERROR (N'Giá món ăn phải lớn hơn 0!', 16, 1);
        ROLLBACK TRANSACTION;
    END
    IF (@TrangThai NOT IN (N'Có sẵn', N'Hết món'))
    BEGIN
        RAISERROR (N'Trạng thái món ăn không hợp lệ. Chỉ chấp nhận "Có sẵn" hoặc "Hết món"!', 16, 1);
        ROLLBACK TRANSACTION;
    END
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
            WHERE i.IDHoaDon = d.IDHoaDon
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
-- Kiểm tra số lượng món ăn trong chi tiết hóa đơn không vượt quá số lượng tồn của nguyên liệu.
CREATE TRIGGER TRG_KTSoLuongMonKhongDuocVuotQuaSLTon ON CHITIETHD
FOR INSERT
AS
BEGIN
    DECLARE @IDMon INT, @Soluong INT
	SET @IDMon = (SELECT IDMON FROM inserted)
	SET @Soluong = (SELECT SoLuong FROM inserted)

    IF EXISTS (
        SELECT 1 
		FROM CHITIETMON ctm
        JOIN NGUYENLIEU nl ON ctm.IDNguyenLieu = nl.IDNguyenLieu
        WHERE ctm.IDMon = @IDMon AND nl.SolgTon < @Soluong
    )
    BEGIN
        RAISERROR (N'Số lượng món ăn vượt quá số lượng nguyên liệu có sẵn!', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO
-- Tự động cập nhật số lượng tồn mỗi khi nhập nguyên liệu
CREATE TRIGGER TRG_CapNhatSoLuongTonKhiNhapNguyenLieu ON CHITIETPN
FOR INSERT
AS
BEGIN
    DECLARE @IDNguyenLieu INT, @SoLuong INT;

    SELECT @IDNguyenLieu = IDNguyenLieu, @SoLuong = SoLuong 
	FROM inserted;

    UPDATE NGUYENLIEU
    SET SolgTon = SolgTon + @SoLuong
    WHERE IDNguyenLieu = @IDNguyenLieu;
END;
GO

CREATE TRIGGER  TRG_CapNhatSoLuongTonKhiBan ON CHITIETHD
FOR INSERT
AS
BEGIN
    DECLARE @IDMon INT, @SoLuongHD float, @SoLuongCL float, @IDNguyenLieu INT

    DECLARE item_cursor CURSOR FOR
    SELECT IDMon, SoLuong FROM inserted

    OPEN item_cursor
    FETCH NEXT FROM item_cursor INTO @IDMon, @SoLuongHD

    WHILE @@FETCH_STATUS = 0
    BEGIN
        DECLARE ingredient_cursor CURSOR FOR
        SELECT IDNguyenLieu, Soluong FROM CHITIETMON WHERE IDMon = @IDMon

        OPEN ingredient_cursor
        FETCH NEXT FROM ingredient_cursor INTO @IDNguyenLieu, @SoLuongCL

        WHILE @@FETCH_STATUS = 0
        BEGIN
            UPDATE NGUYENLIEU
            SET SolgTon = SolgTon - (@SoLuongHD * @SoLuongCL)
            WHERE IDNguyenLieu = @IDNguyenLieu

            FETCH NEXT FROM ingredient_cursor INTO @IDNguyenLieu, @SoLuongCL
        END

        CLOSE ingredient_cursor
        DEALLOCATE ingredient_cursor

        FETCH NEXT FROM item_cursor INTO @IDMon, @SoLuongHD
    END

    CLOSE item_cursor
    DEALLOCATE item_cursor
END;
GO
---------------------------- PROCEDURE ----------------------------
-- 1. Thêm khách hàng mới 
CREATE PROCEDURE SP_ThemKhachHang (
    @HotenKH NVARCHAR(255),
    @DiaChi NVARCHAR(255),
    @SDT VARCHAR(12),
    @Email VARCHAR(50),
    @LoaiKH NVARCHAR(50)
)
AS
BEGIN
    INSERT INTO KHACHHANG (HotenKH, DiaChi, SDT, Email, LoaiKH)
    VALUES (@HotenKH, @DiaChi, @SDT, @Email, @LoaiKH);
END;
GO

-- 2. Cập nhật thông tin khách hàng 
CREATE PROCEDURE SP_CapNhatThongTinKhachHang (
    @IDKhachHang INT,
    @HotenKH NVARCHAR(255),
    @DiaChi NVARCHAR(255),
    @SDT VARCHAR(12),
    @Email VARCHAR(50),
    @LoaiKH NVARCHAR(50)
)
AS
BEGIN
    UPDATE KHACHHANG
    SET HotenKH = @HotenKH, DiaChi = @DiaChi, SDT = @SDT, Email = @Email, LoaiKH = @LoaiKH
    WHERE IDKhachHang = @IDKhachHang;
END;
GO

-- 3. Xóa 1 khách hàng 
CREATE PROCEDURE SP_XoaKhachHang (@IDKhachHang INT)
AS
BEGIN
    DELETE FROM KHACHHANG 
	WHERE IDKhachHang = @IDKhachHang;
END;
GO

-- 4. Thêm một nhân viên 
CREATE PROCEDURE SP_ThemNhanVien (
    @HotenNV NVARCHAR(255),
    @NgaySinh DATE,
    @SDT VARCHAR(12),
    @DiaChi NVARCHAR(255),
    @Email VARCHAR(50),
    @NgayVL DATE,
    @LuongCoBan FLOAT,
    @GioiTinh NVARCHAR(10),
    @IdChucVu INT
)
AS
BEGIN
    INSERT INTO NHANVIEN (HotenNV, NgaySinh, SDT, DiaChi, Email, NgayVL, LuongCoBan, GioiTinh, IdChucVu)
    VALUES (@HotenNV, @NgaySinh, @SDT, @DiaChi, @Email, @NgayVL, @LuongCoBan, @GioiTinh, @IdChucVu);
END;
GO

-- 5. Cập nhật thông tin nhân viên 
CREATE PROCEDURE SP_CapNhatThongTinNhanVien (
    @IDNhanVien INT,
    @HotenNV NVARCHAR(255),
    @NgaySinh DATE,
    @SDT VARCHAR(12),
    @DiaChi NVARCHAR(255),
    @Email VARCHAR(50),
    @NgayVL DATE,
    @LuongCoBan FLOAT,
    @GioiTinh NVARCHAR(10),
    @IdChucVu INT
)
AS
BEGIN
    UPDATE NHANVIEN
    SET HotenNV = @HotenNV, NgaySinh = @NgaySinh, SDT = @SDT, DiaChi = @DiaChi, Email = @Email,
        NgayVL = @NgayVL, LuongCoBan = @LuongCoBan, GioiTinh = @GioiTinh, IdChucVu = @IdChucVu
    WHERE IDNhanVien = @IDNhanVien;
END;
GO

-- 6. Thêm nhân viên vào PhanCong 
CREATE PROCEDURE SP_ThemPhanCong
    @IDNhanVien INT,
    @NgayLamViec DATE,
    @CaLamViec INT,
    @Ban INT
AS
BEGIN
    -- Kiểm tra xem bản ghi phân công đã tồn tại chưa
    IF NOT EXISTS (
        SELECT 1
        FROM PHANCONG
        WHERE IDNhanVien = @IDNhanVien
            AND NgayLV = @NgayLamViec
            AND IDCaLamViec = @CaLamViec
            AND IDBan = @Ban
    )
    BEGIN
        -- Thêm phân công mới nếu chưa có
        INSERT INTO PHANCONG (IDNhanVien, NgayLV, IDCaLamViec, IDBan)
        VALUES (@IDNhanVien, @NgayLamViec, @CaLamViec, @Ban);
        PRINT 'Đã thêm phân công cho nhân viên thành công.';
    END
    ELSE
    BEGIN
        PRINT 'Phân công đã tồn tại.';
    END
END;
GO

-- 7. Đặt bàn 
CREATE PROC SP_ThemDatBan (
    @IDKhachHang INT,
    @GioBD TIME,
    @NgayDB DATE,
    @SoluongBan INT
)
AS
BEGIN
    INSERT INTO DATBAN (IDKhachHang, GioBD, NgayDB, SoluongBan)
    VALUES (@IDKhachHang, @GioBD, @NgayDB, @SoluongBan);
END;
GO

-- 8. Cập nhật số lượng tồn kho
CREATE PROCEDURE SP_CapNhatSoLuongTonKho (
    @IDNguyenLieu INT
)
AS
BEGIN
    DECLARE @TongSoLuongNhap INT;
    DECLARE @TongSoLuongSuDung INT;

    -- Tính tổng số lượng nhập từ bảng CHITIETPN cho nguyên liệu này
    SELECT @TongSoLuongNhap = SUM(SoLuong)
    FROM CHITIETPN
    WHERE IDNguyenLieu = @IDNguyenLieu;

    -- Tính tổng số lượng sử dụng từ bảng CHITIETMON cho nguyên liệu này
    SELECT @TongSoLuongSuDung = SUM(SoLuong)
    FROM CHITIETMON
    WHERE IDNguyenLieu = @IDNguyenLieu;

    -- Cập nhật số lượng tồn kho trong bảng NGUYENLIEU
    UPDATE NGUYENLIEU
    SET SolgTon = ISNULL(@TongSoLuongNhap, 0) - ISNULL(@TongSoLuongSuDung, 0)
    WHERE IDNguyenLieu = @IDNguyenLieu;
END;
GO

-- 9. Thêm hóa đơn 
CREATE PROCEDURE SP_ThemHoaDon (
    @NgayLap DATE,
    @ThanhTien FLOAT,
    @PhuongThucTT NVARCHAR(100),
    @TrangThai NVARCHAR(50),
    @NgayThanhToan DATE,
    @IDKhachHang INT,
    @IDKhuyenMai INT
)
AS
BEGIN
    INSERT INTO HOADON (NgayLap, ThanhTien, PhuongThucTT, TrangThaiTT, NgayThanhToan, IDKhachHang, IDKhuyenMai)
    VALUES (@NgayLap, @ThanhTien, @PhuongThucTT, @TrangThai, @NgayThanhToan, @IDKhachHang, @IDKhuyenMai);
END;
GO

-- 10. Thêm mặt hàng vào ChiTietHD 
CREATE PROCEDURE SP_ThemVaoCTHD (
    @IDHoaDon INT,
    @IDBan INT,
    @IDMon INT,
    @SoLuong INT,
    @DonGia FLOAT,
    @GiamGia INT
)
AS
BEGIN
    INSERT INTO CHITIETHD (IDHoaDon, IDBan, IDMon, SoLuong, DonGia)
    VALUES (@IDHoaDon, @IDBan, @IDMon, @SoLuong, @DonGia);
END;
GO

-- 11. Thêm 1 hóa đơn có đủ chi tiết hóa đơn
CREATE TYPE tb_Danhsachmon AS TABLE (
    IDMon INT,
    SoLuong INT,
    DonGia FLOAT
);
GO
-- Thủ tục tạo hóa đơn
CREATE PROCEDURE SP_Taohoadon 
    @IDBan INT,
    @IDKhachHang INT,
    @IDKhuyenMai INT = NULL,
    @PhuongThucTT NVARCHAR(100),
    @NgayThanhToan DATE,
    @tb_Danhsachmon tb_Danhsachmon READONLY
AS
BEGIN
    DECLARE @ThanhTien FLOAT;
    DECLARE @IDHoaDon INT;

    -- Tính tổng tiền hóa đơn dựa trên danh sách món và các chi tiết
    SELECT @ThanhTien = SUM(SoLuong * DonGia) FROM @tb_Danhsachmon;

    -- Tạo bản ghi hóa đơn
    INSERT INTO HOADON (NgayLap, ThanhTien, PhuongThucTT, TrangThaiTT, NgayThanhToan, IDKhachHang, IDKhuyenMai)
    VALUES (GETDATE(), @ThanhTien, @PhuongThucTT, N'Chưa thanh toán', @NgayThanhToan, @IDKhachHang, @IDKhuyenMai);

    -- Lấy ID của hóa đơn vừa tạo
    SET @IDHoaDon = SCOPE_IDENTITY();

    -- Thêm chi tiết hóa đơn cho mỗi món trong danh sách
    INSERT INTO CHITIETHD (IDHoaDon, IDBan, IDMon, SoLuong, DonGia)
    SELECT @IDHoaDon, @IDBan, IDMon, SoLuong, DonGia
    FROM @tb_Danhsachmon;

    -- Trả về ID hóa đơn để kiểm tra
    SELECT @IDHoaDon AS IDHoaDon;
END;
GO 

-- 17.  Hiện thị toàn bộ nhân viên thuộc chức vụ đó
CREATE PROCEDURE SP_LietKeNhanvien_Chucvu @TenChucVu NVARCHAR(50)
AS
BEGIN
    SELECT NV.IDNhanVien, NV.HotenNV, CV.TenChucVu
    FROM NHANVIEN AS NV
    JOIN CHUCVU AS CV ON NV.IDChucVu = CV.IDChucVu
    WHERE CV.TenChucVu = @TenChucVu;
END;
GO

-- 18 Cập nhật loại KH
CREATE PROCEDURE SP_CapNhatLoaiKhachHang
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            UPDATE kh
            SET LoaiKH = 
                CASE 
                    WHEN SoLanDen >= 10 THEN N'Khách hàng VIP'
                    WHEN SoLanDen >= 5 THEN N'Khách hàng thành viên'
                    ELSE N'Khách hàng mới'
                END
            FROM KHACHHANG kh
            JOIN (
                SELECT IDKhachHang, COUNT(IDHoaDon) AS SoLanDen
                FROM HOADON
                GROUP BY IDKhachHang
            ) AS hd ON kh.IDKhachHang = hd.IDKhachHang;

            UPDATE KHACHHANG 
            SET LoaiKH = N'Khách hàng mới'
            WHERE IDKhachHang NOT IN (SELECT IDKhachHang FROM HOADON);

        COMMIT TRANSACTION
        PRINT N'Cập nhật loại khách hàng thành công.'
        RETURN 0
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE()
        PRINT N'Lỗi: ' + @ErrorMessage
        RETURN -1
    END CATCH
END
GO
--cập nhật loại khách hàng
CREATE PROC SP_UpdateStatementTable
AS
BEGIN
    UPDATE BAN 
    SET TrangThai = 
        CASE 
            WHEN TrangThai != N'Bàn đang ăn' AND EXISTS (
                SELECT 1
                FROM CHITIETDB c
                JOIN DATBAN d ON c.IDDatBan = d.IDDatBan
                WHERE c.IDBan = BAN.IDBan
                AND d.NgayDB = CAST(GETDATE() AS DATE)
                AND ((SELECT CAST(GETDATE() AS TIME)) BETWEEN DATEADD(HOUR, -3, d.GioBD) AND DATEADD(HOUR, 1.5, d.GioBD))
            ) THEN N'Đã đặt trong 3 tiếng'
            
            WHEN TrangThai != N'Bàn đang ăn' AND EXISTS (
                SELECT 1
                FROM CHITIETDB c
                JOIN DATBAN d ON c.IDDatBan = d.IDDatBan
                WHERE c.IDBan = BAN.IDBan
                AND d.NgayDB = CAST(GETDATE() AS DATE)
                AND d.GioBD > CAST(GETDATE() AS TIME)
            ) THEN N'Bàn đã đặt trong ngày'
            
            WHEN TrangThai != N'Bàn đang ăn' AND TrangThai != N'Bàn hỏng' THEN N'Bàn trống'
            
            ELSE TrangThai -- Giữ nguyên trạng thái hiện tại nếu là "Bàn đang ăn"
        END;
END

GO
---------------------------- FUNCTION ---------------------------- 
-- Cập nhật IDKhuyenMai nếu HOADON đó đủ điều kiện để áp dụng
CREATE FUNCTION FC_CheckKhuyenMai
(
    @IDKhachHang INT,
    @SoLuongMon INT
)
RETURNS INT
AS
BEGIN
    DECLARE @LoaiKH NVARCHAR(50);
    SELECT @LoaiKH = LOAIKH 
    FROM KHACHHANG 
    WHERE IDKhachHang = @IDKhachHang;

	DECLARE @IDKhuyenMai INT;
    IF @SoLuongMon >= 8
    BEGIN
        SELECT @IDKhuyenMai = IDKhuyenMai 
        FROM KHUYENMAI 
        WHERE DieuKien = N'Ăn từ 8 món';
    END
    ELSE IF @SoLuongMon >= 5 AND @LoaiKH = N'Thành viên'
    BEGIN
        SELECT @IDKhuyenMai = IDKhuyenMai 
        FROM KHUYENMAI 
        WHERE DieuKien = N'Ăn từ 8 món';
    END
    ELSE IF @SoLuongMon >= 5
    BEGIN
        SELECT @IDKhuyenMai = IDKhuyenMai 
        FROM KHUYENMAI 
        WHERE DieuKien = N'Ăn từ 5 món';
    END
    ELSE IF @LoaiKH = N'Khách hàng VIP'
    BEGIN
        SELECT @IDKhuyenMai = IDKhuyenMai 
        FROM KHUYENMAI 
        WHERE DieuKien = N'Khách hàng VIP';
    END
	ELSE IF @LoaiKH = N'Khách hàng thành viên'
    BEGIN
        SELECT @IDKhuyenMai = IDKhuyenMai 
        FROM KHUYENMAI 
        WHERE DieuKien = N'Khách hàng thành viên';
    END
    ELSE 
    BEGIN
        SET @IDKhuyenMai = 0; 
    END
    RETURN @IDKhuyenMai;
END;
GO

-- Hàm lấy số lượng tồn kho hiện tại của nguyên liệu 
CREATE FUNCTION FC_LaySoLuongTonKho (@IDNguyenLieu INT)
RETURNS INT
AS
BEGIN
    DECLARE @SoLuongTon INT;

    SET @SoLuongTon = ( 
		SELECT SolgTon
		FROM NGUYENLIEU
		WHERE IDNguyenLieu = @IDNguyenLieu
	)

    RETURN ISNULL(@SoLuongTon, 0);
END;
GO

-- Tính tổng số tiền cho 1 phiếu nhập
CREATE FUNCTION FC_TinhTongTien1PhieuNhap(@IDPhieuNhap INT)
RETURNS FLOAT
AS
BEGIN
    DECLARE @TongTien FLOAT;

    SET @TongTien = ( 
		SELECT SUM(SoLuong * GiaNhap)
		FROM CHITIETPN
		WHERE IDPhieuNhap = @IDPhieuNhap
	)

    RETURN ISNULL(@TongTien, 0);
END;
GO

--DOANH THU 
CREATE FUNCTION FC_DOANHTHUTRONGNGAY(@DAY DATETIME)
RETURNS TABLE
RETURN
(
	SELECT SUM(ThanhTien) AS TONGDONVI, @DAY AS TENTHANHPHAN
    FROM HOADON
    WHERE NgayLap =  @DAY
);
GO

CREATE FUNCTION FC_DOANHTHUTRONGKHOANGTG(@DAYX DATETIME, @DAYY DATETIME)
RETURNS TABLE
RETURN
(
	SELECT 
        SUM(ThanhTien) AS TONGDONVI, NgayLap AS TENTHANHPHAN 
    FROM 
        HOADON
    WHERE 
        NgayLap BETWEEN @DAYX AND @DAYY
    GROUP BY 
        NgayLap
);
GO

CREATE FUNCTION FC_DANHTHUTRONGTUAN(@TUAN INT, @THANG INT, @NAM INT)
RETURNS TABLE
RETURN
(
	WITH DateRange AS (
        SELECT 
            DATEADD(DAY, (7 * (@TUAN - 1)), DATEFROMPARTS(@NAM, @THANG, 1)) AS StartDate,
            CASE 
                WHEN @TUAN = 4 THEN EOMONTH(DATEFROMPARTS(@NAM, @THANG, 1)) 
                ELSE DATEADD(DAY, (7 * @TUAN) - 1, DATEFROMPARTS(@NAM, @THANG, 1))
            END AS EndDate
    )
    SELECT 
        DATENAME(WEEKDAY, NgayLap) AS TENTHANHPHAN,
        SUM(ThanhTien) AS TONGDONVI
    FROM 
        HOADON
    CROSS JOIN DateRange
    WHERE 
        NgayLap BETWEEN DateRange.StartDate AND DateRange.EndDate
    GROUP BY 
        DATENAME(WEEKDAY, NgayLap),
        DATEPART(WEEKDAY, NgayLap)
);
GO

CREATE FUNCTION FC_DANHTHUTRONGTHANG(@THANG INT, @NAM INT)
RETURNS TABLE
RETURN
(
	WITH DateRange AS (
        SELECT 
            DATEFROMPARTS(@NAM, @THANG, 1) AS StartDate,
            EOMONTH(DATEFROMPARTS(@NAM, @THANG, 1)) AS EndDate
    ),
    Weeks AS (
        SELECT 
            (ROW_NUMBER() OVER (ORDER BY (SELECT NULL))) AS WeekNumber, 
            DATEADD(DAY, (7 * (week_num - 1)), StartDate) AS WeekStart,
            CASE 
                WHEN week_num = 4 THEN EndDate
                ELSE DATEADD(DAY, (7 * week_num) - 1, StartDate)
            END AS WeekEnd
        FROM 
            DateRange
        CROSS APPLY (
            VALUES (1), (2), (3), (4)
        ) AS WeekNumbers(week_num)
    )
    SELECT 
        N'Tuần ' + CAST(WeekNumber AS VARCHAR(10)) AS TENTHANHPHAN,
        SUM(ThanhTien) AS TONGDONVI
    FROM 
        HOADON
    CROSS JOIN 
        DateRange
    JOIN 
        Weeks ON NgayLap BETWEEN Weeks.WeekStart AND Weeks.WeekEnd
    WHERE 
        NgayLap BETWEEN DateRange.StartDate AND DateRange.EndDate
    GROUP BY 
        WeekNumber
);
GO

CREATE FUNCTION FC_DANHTHUTRONGNAM(@NAM INT)
RETURNS TABLE
RETURN
(
	SELECT SUM(ThanhTien) AS TONGDONVI ,MONTH(NgayLap) AS TENTHANHPHAN
	FROM HOADON
	WHERE YEAR(NgayLap) = @NAM
	GROUP BY MONTH(NgayLap)
);
GO

CREATE FUNCTION FC_DANHSACHNAM()
RETURNS TABLE
RETURN
(
	SELECT DISTINCT YEAR(NgayLap) AS NAM
	FROM HOADON
);
GO

--MON
CREATE FUNCTION FC_MONAN_BANCHAY_TRONGNGAY(@DAY DATE)
RETURNS TABLE
RETURN 
	(
		SELECT TOP 5 MON.TenMon AS TENTHANHPHAN, SUM(SoLuong) AS TONGDONVI
		FROM CHITIETHD, MON, HOADON
		WHERE HOADON.IDHoaDon=CHITIETHD.IDHoaDon and MON.IDMon=CHITIETHD.IDMon
				AND NgayLap = @DAY
		group by  MON.TenMon
		order by TONGDONVI DESC
	)
GO

CREATE FUNCTION FC_MONAN_BANCHAY_TRONGKHOANGTG(@DAY1 DATE, @DAY2 DATE)
RETURNS TABLE
RETURN 
	(
		SELECT TOP 5 MON.TenMon AS TENTHANHPHAN, SUM(SoLuong) AS TONGDONVI
		FROM CHITIETHD, MON, HOADON
		WHERE HOADON.IDHoaDon=CHITIETHD.IDHoaDon and MON.IDMon=CHITIETHD.IDMon
				AND NgayLap BETWEEN @DAY1 AND @DAY2 
		group by  MON.TenMon
		order by TONGDONVI DESC
	)
GO

CREATE FUNCTION FC_MONAN_BANCHAY_TRONGTUAN(@TUAN INT, @THANG INT, @NAM INT)
RETURNS TABLE
RETURN 
	(
	WITH DateRange AS (
        SELECT 
            DATEADD(DAY, (7 * (@TUAN - 1)), DATEFROMPARTS(@NAM, @THANG, 1)) AS StartDate,
            CASE 
                WHEN @TUAN = 4 THEN EOMONTH(DATEFROMPARTS(@NAM, @THANG, 1)) 
                ELSE DATEADD(DAY, (7 * @TUAN) - 1, DATEFROMPARTS(@NAM, @THANG, 1))
            END AS EndDate
    )
		SELECT TOP 5 MON.TenMon AS TENTHANHPHAN, SUM(SoLuong) AS TONGDONVI
		FROM CHITIETHD, MON, HOADON
		CROSS JOIN DateRange
		WHERE 
        NgayLap BETWEEN DateRange.StartDate AND DateRange.EndDate
		AND HOADON.IDHoaDon=CHITIETHD.IDHoaDon and MON.IDMon=CHITIETHD.IDMon
		GROUP BY 
			MON.TenMon
		order by TONGDONVI DESC
	)
GO

CREATE FUNCTION FC_MONAN_BANCHAY_TRONGTHANG(@THANG INT, @NAM INT)
RETURNS TABLE
RETURN 
	(
	WITH DateRange AS (
        SELECT 
			DATEFROMPARTS(@NAM, @THANG, 1) AS StartDate,
			EOMONTH(DATEFROMPARTS(@NAM, @THANG, 1)) AS EndDate     
    )
		SELECT TOP 5 MON.TenMon AS TENTHANHPHAN, SUM(SoLuong) AS TONGDONVI
		FROM CHITIETHD, MON, HOADON
		CROSS JOIN DateRange
		WHERE 
        NgayLap BETWEEN DateRange.StartDate AND DateRange.EndDate
		AND HOADON.IDHoaDon=CHITIETHD.IDHoaDon and MON.IDMon=CHITIETHD.IDMon
		GROUP BY 
			MON.TenMon
		order by TONGDONVI DESC
	)
GO

CREATE FUNCTION FC_MONAN_BANCHAY_TRONGNAM(@NAM INT)
RETURNS TABLE
RETURN 
	(
		SELECT TOP 5 MON.TenMon AS TENTHANHPHAN, SUM(SoLuong) AS TONGDONVI
		FROM CHITIETHD, MON, HOADON
		WHERE 
			YEAR(NgayLap) = @NAM
			AND HOADON.IDHoaDon=CHITIETHD.IDHoaDon and MON.IDMon=CHITIETHD.IDMon
		GROUP BY 
			MON.TenMon
		order by TONGDONVI DESC
	)
GO

CREATE PROC FC_MONAN_TONGSOLUONG_TRONGNGAY(@DAY DATE)
AS
BEGIN
	SELECT SUM(SoLuong)
	FROM CHITIETHD, MON, HOADON
	WHERE HOADON.IDHoaDon=CHITIETHD.IDHoaDon and MON.IDMon=CHITIETHD.IDMon
				AND NgayLap = @DAY
END
GO

CREATE PROC FC_MONAN_TONGSOLUONG_TRONGKHOANGTG(@DAY1 DATE, @DAY2 DATE)
AS
BEGIN
	SELECT SUM(SoLuong)
	FROM CHITIETHD, MON, HOADON
	WHERE HOADON.IDHoaDon=CHITIETHD.IDHoaDon and MON.IDMon=CHITIETHD.IDMon
				AND NgayLap BETWEEN @DAY1 AND @DAY2
END
GO

CREATE PROC FC_MONAN_TONGSOLUONG_TRONGTUAN(@TUAN INT, @THANG INT, @NAM INT)
AS
BEGIN 
	DECLARE @StartDate DATE = DATEADD(DAY, (7 * (@TUAN - 1)), DATEFROMPARTS(@NAM, @THANG, 1))
	DECLARE @EndDate DATE =	CASE 
				WHEN @TUAN = 4 THEN EOMONTH(DATEFROMPARTS(@NAM, @THANG, 1)) 
				ELSE DATEADD(DAY, (7 * @TUAN) - 1, DATEFROMPARTS(@NAM, @THANG, 1))
				END
	SELECT SUM(CHITIETHD.SoLuong) AS SOLUONGMON
    FROM CHITIETHD
    JOIN MON ON MON.IDMon = CHITIETHD.IDMon
    JOIN HOADON ON HOADON.IDHoaDon = CHITIETHD.IDHoaDon
    WHERE HOADON.NgayLap BETWEEN @StartDate AND @EndDate
END
GO

CREATE PROC FC_MONAN_TONGSOLUONG_TRONGTHANG(@THANG INT, @NAM INT)
AS
BEGIN
	DECLARE @StartDate DATE = DATEFROMPARTS(@NAM, @THANG, 1)
	DECLARE @EndDate DATE =	EOMONTH(DATEFROMPARTS(@NAM, @THANG, 1)) 

	SELECT SUM(SoLuong) AS SOLUONGMON
	FROM CHITIETHD, MON, HOADON
	WHERE 
    NgayLap BETWEEN @StartDate AND @EndDate
	AND HOADON.IDHoaDon=CHITIETHD.IDHoaDon and MON.IDMon=CHITIETHD.IDMon
END
GO

CREATE PROC FC_MONAN_TONGSOLUONG_TRONGNAM(@NAM INT)
AS
BEGIN
	SELECT SUM(SoLuong) AS SOLUONGMON
	FROM CHITIETHD, MON, HOADON
	WHERE 
		YEAR(NgayLap) = @NAM
		AND HOADON.IDHoaDon=CHITIETHD.IDHoaDon and MON.IDMon=CHITIETHD.IDMon
END


GO
--KHACH HANG
CREATE FUNCTION FC_KHACHHANG_TRONGNGAY(@DAY DATETIME)
RETURNS TABLE
RETURN
(
	SELECT COUNT(IDKhachHang) AS TONGDONVI, @DAY AS TENTHANHPHAN
    FROM HOADON
    WHERE NgayLap =  @DAY
);
GO

CREATE FUNCTION FC_KHACHHANG_TRONGKHOANGTG(@DAYX DATETIME, @DAYY DATETIME)
RETURNS TABLE
RETURN
(
	SELECT 
        COUNT(IDKhachHang) AS TONGDONVI, NgayLap AS TENTHANHPHAN 
    FROM 
        HOADON
    WHERE 
        NgayLap BETWEEN @DAYX AND @DAYY
    GROUP BY 
        NgayLap
);
GO

CREATE FUNCTION FC_KHACHHANG_TRONGTUAN(@TUAN INT, @THANG INT, @NAM INT)
RETURNS TABLE
RETURN
(
	WITH DateRange AS (
        SELECT 
            DATEADD(DAY, (7 * (@TUAN - 1)), DATEFROMPARTS(@NAM, @THANG, 1)) AS StartDate,
            CASE 
                WHEN @TUAN = 4 THEN EOMONTH(DATEFROMPARTS(@NAM, @THANG, 1)) 
                ELSE DATEADD(DAY, (7 * @TUAN) - 1, DATEFROMPARTS(@NAM, @THANG, 1))
            END AS EndDate
    )
    SELECT 
        DATENAME(WEEKDAY, NgayLap) AS TENTHANHPHAN,
        COUNT(IDKhachHang) AS TONGDONVI
    FROM 
        HOADON
    CROSS JOIN DateRange
    WHERE 
        NgayLap BETWEEN DateRange.StartDate AND DateRange.EndDate
    GROUP BY 
        DATENAME(WEEKDAY, NgayLap),
        DATEPART(WEEKDAY, NgayLap)
);
GO

CREATE FUNCTION FC_KHACHHANG_TRONGTHANG(@THANG INT, @NAM INT)
RETURNS TABLE
RETURN
(
	WITH DateRange AS (
        SELECT 
            DATEFROMPARTS(@NAM, @THANG, 1) AS StartDate,
            EOMONTH(DATEFROMPARTS(@NAM, @THANG, 1)) AS EndDate
    ),
    Weeks AS (
        SELECT 
            (ROW_NUMBER() OVER (ORDER BY (SELECT NULL))) AS WeekNumber, 
            DATEADD(DAY, (7 * (week_num - 1)), StartDate) AS WeekStart,
            CASE 
                WHEN week_num = 4 THEN EndDate
                ELSE DATEADD(DAY, (7 * week_num) - 1, StartDate)
            END AS WeekEnd
        FROM 
            DateRange
        CROSS APPLY (
            VALUES (1), (2), (3), (4)
        ) AS WeekNumbers(week_num)
    )
    SELECT 
        N'Tuần ' + CAST(WeekNumber AS VARCHAR(10)) AS TENTHANHPHAN,
        COUNT(IDKhachHang) AS TONGDONVI
    FROM 
        HOADON
    CROSS JOIN 
        DateRange
    JOIN 
        Weeks ON NgayLap BETWEEN Weeks.WeekStart AND Weeks.WeekEnd
    WHERE 
        NgayLap BETWEEN DateRange.StartDate AND DateRange.EndDate
    GROUP BY 
        WeekNumber
);
GO

CREATE FUNCTION FC_KHACHHANG_TRONGNAM(@NAM INT)
RETURNS TABLE
RETURN
(
	SELECT COUNT(IDKhachHang) AS TONGDONVI ,MONTH(NgayLap) AS TENTHANHPHAN
	FROM HOADON
	WHERE YEAR(NgayLap) = @NAM
	GROUP BY MONTH(NgayLap)
);
GO

--NGUYEN LIEU
CREATE FUNCTION FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGNGAY(@DAY DATE)
RETURNS TABLE
RETURN 
	(
		SELECT TOP 5 NGUYENLIEU.TenNguyenLieu AS TENTHANHPHAN,
		SUM(CHITIETMON.SoLuong) AS TONGDONVI
		FROM HOADON, CHITIETHD, MON,CHITIETMON, NGUYENLIEU
		WHERE HOADON.IDHoaDon=CHITIETHD.IDHoaDon 
				AND CHITIETHD.IDMon=MON.IDMon
				AND MON.IDMon = CHITIETMON.IDMon and CHITIETMON.IDNguyenLieu=NGUYENLIEU.IDNguyenLieu
				AND NgayLap = @DAY
		group by  NGUYENLIEU.TenNguyenLieu
		order by TONGDONVI DESC
	)
GO

CREATE FUNCTION FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGKHOANGTG(@DAY1 DATE, @DAY2 DATE)
RETURNS TABLE
RETURN 
	(
		SELECT TOP 5 NGUYENLIEU.TenNguyenLieu AS TENTHANHPHAN, SUM(CHITIETMON.SoLuong) AS TONGDONVI
		FROM HOADON, CHITIETHD, MON,CHITIETMON, NGUYENLIEU
		WHERE HOADON.IDHoaDon=CHITIETHD.IDHoaDon 
				AND CHITIETHD.IDMon=MON.IDMon
				AND MON.IDMon = CHITIETMON.IDMon and CHITIETMON.IDNguyenLieu=NGUYENLIEU.IDNguyenLieu
				AND NgayLap BETWEEN @DAY1 AND @DAY2
		group by  NGUYENLIEU.TenNguyenLieu
		order by TONGDONVI DESC	
	)
GO

CREATE FUNCTION FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGTUAN(@TUAN INT, @THANG INT, @NAM INT)
RETURNS TABLE
RETURN 
	(
	WITH DateRange AS (
        SELECT 
            DATEADD(DAY, (7 * (@TUAN - 1)), DATEFROMPARTS(@NAM, @THANG, 1)) AS StartDate,
            CASE 
                WHEN @TUAN = 4 THEN EOMONTH(DATEFROMPARTS(@NAM, @THANG, 1)) 
                ELSE DATEADD(DAY, (7 * @TUAN) - 1, DATEFROMPARTS(@NAM, @THANG, 1))
            END AS EndDate
    )
		SELECT TOP 5 NGUYENLIEU.TenNguyenLieu AS TENTHANHPHAN, SUM(CHITIETHD.SoLuong) AS TONGDONVI
		FROM HOADON, CHITIETHD, MON,CHITIETMON, NGUYENLIEU
		CROSS JOIN DateRange
		WHERE 
				HOADON.IDHoaDon=CHITIETHD.IDHoaDon 
				AND CHITIETHD.IDMon=MON.IDMon
				AND MON.IDMon = CHITIETMON.IDMon and CHITIETMON.IDNguyenLieu=NGUYENLIEU.IDNguyenLieu
				AND NgayLap BETWEEN DateRange.StartDate AND DateRange.EndDate
		GROUP BY 
			NGUYENLIEU.TenNguyenLieu
		order by TONGDONVI DESC
	)
GO

CREATE FUNCTION FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGTHANG(@THANG INT, @NAM INT)
RETURNS TABLE
RETURN 
	(
	WITH DateRange AS (
        SELECT 
			DATEFROMPARTS(@NAM, @THANG, 1) AS StartDate,
			EOMONTH(DATEFROMPARTS(@NAM, @THANG, 1)) AS EndDate     
    )
		SELECT TOP 5 NGUYENLIEU.TenNguyenLieu AS TENTHANHPHAN, SUM(CHITIETHD.SoLuong) AS TONGDONVI
		FROM HOADON, CHITIETHD, MON,CHITIETMON, NGUYENLIEU
		CROSS JOIN DateRange
		WHERE 
			NgayLap BETWEEN DateRange.StartDate AND DateRange.EndDate
			AND HOADON.IDHoaDon=CHITIETHD.IDHoaDon 
			AND CHITIETHD.IDMon=MON.IDMon
			AND MON.IDMon = CHITIETMON.IDMon and CHITIETMON.IDNguyenLieu=NGUYENLIEU.IDNguyenLieu
		GROUP BY 
			NGUYENLIEU.TenNguyenLieu
		order by TONGDONVI DESC
	)
GO

CREATE FUNCTION FC_NGUYENLIEU_SUDUNGNHIEUNHAT_TRONGNAM(@NAM INT)
RETURNS TABLE
RETURN 
	(
		SELECT TOP 5 NGUYENLIEU.TenNguyenLieu AS TENTHANHPHAN, 
		SUM(CHITIETHD.SoLuong) AS TONGDONVI
		FROM HOADON, CHITIETHD, MON,CHITIETMON, NGUYENLIEU
		WHERE 
			YEAR(NgayLap) = @NAM
			AND HOADON.IDHoaDon=CHITIETHD.IDHoaDon 
			AND CHITIETHD.IDMon=MON.IDMon
			AND MON.IDMon = CHITIETMON.IDMon and CHITIETMON.IDNguyenLieu=NGUYENLIEU.IDNguyenLieu
		GROUP BY 
			NGUYENLIEU.TenNguyenLieu
		order by TONGDONVI DESC
	)
GO
-- ===============================================================================================
-- ======================================= START: PHAN QUYEN ======================================
CREATE ROLE QuanLy_role;
CREATE ROLE ThuNgan_role;
CREATE ROLE  PhucVu_role;

-- NHÂN VIÊN PHỤC VỤ 
-- Xác định nhu cầu phân quyền
GRANT INSERT ON PHIEUNHAP TO PhucVu_role;
GRANT SELECT, INSERT ON CHITIETPN TO PhucVu_role;
-- Tạo login cho các nhân viên phục vụ
CREATE LOGIN [buimanhCuong] WITH PASSWORD = 'Cuong456!'; 
CREATE LOGIN [phanvanhau] WITH PASSWORD = 'Hau@789'; 
CREATE LOGIN [tranquangvinh] WITH PASSWORD = 'Vinh2022'; 
CREATE LOGIN [nguyenphuchung] WITH PASSWORD = 'Hung456'; 
CREATE LOGIN [dothimyduyen] WITH PASSWORD = 'Duyen321'; 
CREATE LOGIN [hoangphuongvy] WITH PASSWORD = 'Vy!123'; 

-- Tạo tài khoản cho các nhân viên phục vụ
CREATE USER [buimanhCuong123] FOR LOGIN [buimanhCuong];  
CREATE USER [phanvanhau234] FOR LOGIN [phanvanhau];  
CREATE USER [tranquangvinh345] FOR LOGIN [tranquangvinh];  
CREATE USER [nguyenphuchung456] FOR LOGIN [nguyenphuchung];  
CREATE USER [dothimyduyen567] FOR LOGIN [dothimyduyen];  
CREATE USER [hoangphuongvy789] FOR LOGIN [hoangphuongvy];  

-- Gán role cho nhân viên phục vụ
EXEC sp_addrolemember 'PhucVu_role', 'buimanhCuong123';
EXEC sp_addrolemember 'PhucVu_role', 'phanvanhau234';
EXEC sp_addrolemember 'PhucVu_role', 'tranquangvinh345';
EXEC sp_addrolemember 'PhucVu_role', 'nguyenphuchung456';
EXEC sp_addrolemember 'PhucVu_role', 'dothimyduyen567';
EXEC sp_addrolemember 'PhucVu_role', 'hoangphuongvy789';

-- Cấp quyền kết nối cho các nhân viên phục vụ
GRANT CONNECT TO [buimanhCuong123];
GRANT CONNECT TO [phanvanhau234];
GRANT CONNECT TO [tranquangvinh345];
GRANT CONNECT TO [nguyenphuchung456];
GRANT CONNECT TO [dothimyduyen567];
GRANT CONNECT TO [hoangphuongvy789];

-- NHÂN VIÊN THU NGÂN 
-- Xác định nhu cầu phân quyền
GRANT SELECT ON MON TO ThuNgan_role;

GRANT SELECT ON BAN TO ThuNgan_role;
GRANT SELECT, INSERT ON DATBAN TO ThuNgan_role;
GRANT SELECT, INSERT, UPDATE ON CHITIETDB TO ThuNgan_role;

GRANT SELECT, INSERT ON KHACHHANG TO ThuNgan_role;
GRANT SELECT ON KHUYENMAI TO ThuNgan_role;
GRANT SELECT, INSERT, UPDATE ON HOADON TO ThuNgan_role;
GRANT SELECT, INSERT, UPDATE ON CHITIETHD TO ThuNgan_role;
GRANT SELECT, INSERT, UPDATE ON MON TO ThuNgan_role;
GRANT SELECT, INSERT, UPDATE ON CHITIETMON TO ThuNgan_role;

GRANT INSERT ON PHIEUNHAP TO ThuNgan_role;
GRANT SELECT, INSERT ON CHITIETPN TO ThuNgan_role;

-- Tạo login cho các nhân viên thu ngân
CREATE LOGIN [leanhtuan] WITH PASSWORD = 'Tuan789!'; 
CREATE LOGIN [ngothikimngan] WITH PASSWORD = 'Ngankim!123'; 
CREATE LOGIN [lethixuan] WITH PASSWORD = 'Duc#456'; 
CREATE LOGIN [truonghongphat] WITH PASSWORD = 'Phat@789'; 
CREATE LOGIN [tovanduc] WITH PASSWORD = 'Duc#456'; 
CREATE LOGIN [phamvanthinh] WITH PASSWORD = 'Thinh@789'; 
CREATE LOGIN [vothianhdao] WITH PASSWORD = 'Dao987'; 
CREATE LOGIN [ngominhchau] WITH PASSWORD = 'Chau#321'; 

-- Tạo tài khoản cho các nhân viên thu ngân
CREATE USER [leanhtuan] FOR LOGIN [leanhtuan];  
CREATE USER [ngothikimngan] FOR LOGIN [ngothikimngan];  
CREATE USER [lethixuan] FOR LOGIN [lethixuan];  
CREATE USER [truonghongphat] FOR LOGIN [truonghongphat];  
CREATE USER [tovanduc] FOR LOGIN [tovanduc];  
CREATE USER [phamvanthinh] FOR LOGIN [phamvanthinh];  
CREATE USER [vothianhdao] FOR LOGIN [vothianhdao];  
CREATE USER [ngominhchau] FOR LOGIN [ngominhchau];  

-- Gán role cho nhân viên thu ngân
EXEC sp_addrolemember 'ThuNgan_role', 'leanhtuan';
EXEC sp_addrolemember 'ThuNgan_role', 'ngothikimngan';
EXEC sp_addrolemember 'ThuNgan_role', 'lethixuan';
EXEC sp_addrolemember 'ThuNgan_role', 'truonghongphat';
EXEC sp_addrolemember 'ThuNgan_role', 'tovanduc';
EXEC sp_addrolemember 'ThuNgan_role', 'phamvanthinh';
EXEC sp_addrolemember 'ThuNgan_role', 'vothianhdao';
EXEC sp_addrolemember 'ThuNgan_role', 'ngominhchau';

-- Cấp quyền kết nối cho các nhân viên thu ngân
GRANT CONNECT TO [leanhtuan];
GRANT CONNECT TO [ngothikimngan];
GRANT CONNECT TO [lethixuan];
GRANT CONNECT TO [truonghongphat];
GRANT CONNECT TO [tovanduc];
GRANT CONNECT TO [phamvanthinh];
GRANT CONNECT TO [vothianhdao];
GRANT CONNECT TO [ngominhchau];

--  NHÂN VIÊN QUẢN LÝ 
-- Xác định nhu cầu phân quyền
GRANT CONTROL ON DATABASE :: QL_NHAHANG TO QuanLy_role;

-- Tạo login cho nhân viên quản lý
CREATE LOGIN ChauDucToan WITH PASSWORD = 'DucToanDepTrai'; 
CREATE LOGIN tranthimailan WITH PASSWORD = 'Mailan321'; 

-- Tạo tài khoản cho nhân viên quản lý
CREATE USER [ChauDucToan123] FOR LOGIN [ChauDucToan];  
CREATE USER [tranthimailan963] FOR LOGIN [tranthimailan];  
-- Gán role cho nhân viên quản lý
EXEC sp_addrolemember 'QuanLy_role', 'ChauDucToan123';
EXEC sp_addrolemember 'QuanLy_role', 'tranthimailan963';

-- Cấp quyền kết nối nhân viên quản lý
GRANT CONNECT TO [ChauDucToan123];
GRANT CONNECT TO [tranthimailan963];


-- ===============================================================================================
-- ======================================= START: BACKUP ======================================
-- Full backup
BACKUP DATABASE QL_NHAHANG
TO DISK = 'D:\Tài Liệu Đại Học\Năm 3 ( HK 1)\Hệ quản trị cơ sở dữ liệu\Đồ án\Đồ án quản lý nhà hàng_Final\Backup\QL_NHAHANG_Full.bak'
WITH INIT;

-- Differential backup 
BACKUP DATABASE QL_NHAHANG
TO DISK = 'D:\Tài Liệu Đại Học\Năm 3 ( HK 1)\Hệ quản trị cơ sở dữ liệu\Đồ án\Đồ án quản lý nhà hàng_Final\Backup\QL_NHAHANG_Diff.bak'
WITH DIFFERENTIAL, INIT;

-- Transaction log backup
BACKUP LOG QL_NHAHANG
TO DISK = 'D:\Tài Liệu Đại Học\Năm 3 ( HK 1)\Hệ quản trị cơ sở dữ liệu\Đồ án\Đồ án quản lý nhà hàng_Final\Backup\QL_NHAHANG_Log.bak'
WITH INIT;


 
