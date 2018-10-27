﻿
CREATE DATABASE QLBanGiay
GO
--
USE QLBanGiay
GO

--TABLE--
CREATE TABLE LoaiNguoiDung
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaLoaiNguoiDung VARCHAR(10) UNIQUE NOT NULL,
	TenLoaiNguoiDung NVARCHAR(20) --Merchant, Customer, Nhân viên--
)

CREATE TABLE TaiKhoan
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	TenDangNhap VARCHAR(20) UNIQUE NOT NULL,
	MatKhau VARCHAR(30) NOT NULL,
	Email VARCHAR(100),
	Ten NVARCHAR(100),
	DienThoai VARCHAR(20),
	CMND VARCHAR(20),
	IdLoaiNguoiDung UNIQUEIDENTIFIER NOT NULL, --FK--
	NgayTao DATETIME,
	DanhGia FLOAT,
	TinhTrang NVARCHAR(20)
)

CREATE TABLE DanhGia
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	IdTaiKhoanDanhGia UNIQUEIDENTIFIER NOT NULL, --FK (Id người đánh giá)--
	IdTaiKhoanDuocDanhGia UNIQUEIDENTIFIER NOT NULL, --FK (Id người được đánh giá)--
	Diem FLOAT --Điểm đánh giá--
)

CREATE TABLE SanPham
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaSanPham VARCHAR(10) UNIQUE NOT NULL,
	TenSanPham NVARCHAR(100),
	IdTaiKhoan UNIQUEIDENTIFIER NOT NULL, --FK--
	Size INT,
	Mau NVARCHAR(20), --Màu--
	Hang NVARCHAR(50), --Hãng--
	PhanLoai NVARCHAR(10), --Nam/Nữ--
	Gia FLOAT,
	SoLuong INT,
	Hinh NVARCHAR(200),
	ChiTiet NVARCHAR(500),
	GiamGia FLOAT, -- vidu : 10 = 10% --
	TinhTrang NVARCHAR(20)
)


CREATE TABLE PhieuGiao
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaPhieuGiao VARCHAR(10) UNIQUE NOT NULL,
	CMNDGiao VARCHAR(20) NOT NULL,
	IdTaiKhoan UNIQUEIDENTIFIER NOT NULL, --FK--
	DiaChi NVARCHAR(200),
	NgayTao DATETIME,
	NgayGiao DATETIME,
	IdKhuyenMai UNIQUEIDENTIFIER NOT NULL, --FK--
	TongTien FLOAT,
	TinhTrang NVARCHAR(20)
)

CREATE TABLE ChiTietPhieuGiao
(
	IdPhieuGiao UNIQUEIDENTIFIER NOT NULL, --PK, FK--
	IdSanPham UNIQUEIDENTIFIER NOT NULL, --PK, FK--
	SoLuong INT,
	Gia FLOAT
)

CREATE TABLE PhieuDat
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaPhieuDat VARCHAR(10) UNIQUE NOT NULL,
	IdTaiKhoan UNIQUEIDENTIFIER NOT NULL, --FK--
	NgayTao DATETIME,
	IdKhuyenMai UNIQUEIDENTIFIER NOT NULL, --FK--
	TongTien FLOAT,
	TinhTrang NVARCHAR(20)
)

CREATE TABLE ChiTietPhieuDat
(
	IdPhieuDat UNIQUEIDENTIFIER NOT NULL, --PK, FK--
	IdSanPham UNIQUEIDENTIFIER NOT NULL, --PK, FK--
	SoLuong INT
)

CREATE TABLE TinhThanh --Tỉnh thành--
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaTinhThanh VARCHAR(10) UNIQUE NOT NULL,
	TenTinhThanh NVARCHAR(20),
)

CREATE TABLE DiaChi
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	IdTaiKhoan UNIQUEIDENTIFIER NOT NULL, --FK--
	Duong NVARCHAR(100) NOT NULL, --Đường--
	IdTinhThanh UNIQUEIDENTIFIER NOT NULL, --FK--
	TinhTrang NVARCHAR(20)
)

CREATE TABLE KhuyenMai
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaKhuyenMai VARCHAR(10) UNIQUE NOT NULL,
	NgayBatDau DATETIME,
	NgayKetThuc DATETIME,
	GiamGia FLOAT,
	NoiDung NVARCHAR(500),
	TinhTrang NVARCHAR(20)
)

CREATE TABLE QuangCao
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaQuangCao VARCHAR(10) UNIQUE NOT NULL,
	IdGoiQuangCao UNIQUEIDENTIFIER NOT NULL, --FK--
	IdTaiKhoan UNIQUEIDENTIFIER NOT NULL, --FK--
	Hinh NVARCHAR(200) NOT NULL,
	NgayBatDau DATETIME,
	NgayKetThuc DATETIME,
	ChuThich NVARCHAR(500),
	TinhTrang NVARCHAR(20)
)

CREATE TABLE GoiQuangCao
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaGoiQuangCao VARCHAR(10) UNIQUE NOT NULL,
	IdViTri UNIQUEIDENTIFIER NOT NULL, -- FK -- 
	TongTien FLOAT,
	ThoiLuong INT --Ngày--
)

CREATE TABLE TrangQuangCao
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaTrang VARCHAR(10) UNIQUE NOT NULL,
	TenTrang NVARCHAR(100),
	ChuThich NVARCHAR(100),
)

CREATE TABLE ViTriQuangcao
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaViTri VARCHAR(10) UNIQUE NOT NULL,
	TenViTri NVARCHAR(100),
	IdTrang UNIQUEIDENTIFIER NOT NULL, -- FK --
	DonGia FLOAT,
	ChuThich NVARCHAR(100)
)

CREATE TABLE GioHang
(
	IdTaiKhoan UNIQUEIDENTIFIER NOT NULL, --PK, FK--
	IdSanPham UNIQUEIDENTIFIER NOT NULL, --PK, FK--
	SoLuong INT,
	ThoiGian TIME, --Thời gian còn lại, hết trả số lượng về 0--
	TinhTrang NVARCHAR(20)
)

CREATE TABLE GiaShip
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	Loai NVARCHAR(20), -- NOI THANH HAY NGOAI THANH
	Gia FLOAT,
	NgayCapNhat DATETIME
)

ALTER TABLE TaiKhoan
	ADD
		CONSTRAINT FK_TaiKhoan_IdLoaiNguoiDung FOREIGN KEY (IdLoaiNguoiDung) REFERENCES LoaiNguoiDung(Id)

ALTER TABLE DanhGia
	ADD
		CONSTRAINT FK_DanhGia_IdTaiKhoanDanhGia FOREIGN KEY (IdTaiKhoanDanhGia) REFERENCES TaiKhoan(Id),
		CONSTRAINT FK_DanhGia_IdTaiKhoanDuocDanhGia FOREIGN KEY (IdTaiKhoanDuocDanhGia) REFERENCES TaiKhoan(Id)

ALTER TABLE SanPham
	ADD
		CONSTRAINT FK_SanPham_IdTaiKhoan FOREIGN KEY (IdTaiKhoan) REFERENCES TaiKhoan(Id)


ALTER TABLE PhieuGiao
	ADD
		CONSTRAINT FK_PhieuGiao_IdTaiKhoan FOREIGN KEY (IdTaiKhoan) REFERENCES TaiKhoan(Id),
		CONSTRAINT FK_PhieuGiao_IdKhuyenMai FOREIGN KEY (IdKhuyenMai) REFERENCES KhuyenMai(Id)

ALTER TABLE ChiTietPhieuGiao
	ADD
		CONSTRAINT FK_ChiTietPhieuGiao_IdPhieuGiao FOREIGN KEY (IdPhieuGiao) REFERENCES PhieuGiao(Id),
		CONSTRAINT FK_ChiTietPhieuGiao_IdSanPham FOREIGN KEY (IdSanPham) REFERENCES SanPham(Id),
		CONSTRAINT PK_ChiTietPhieuGiao_IdPhieuGiao_IdSanPham PRIMARY KEY (IdPhieuGiao, IdSanPham)

ALTER TABLE PhieuDat
	ADD
		CONSTRAINT FK_PhieuDat_IdTaiKhoan FOREIGN KEY (IdTaiKhoan) REFERENCES TaiKhoan(Id),
		CONSTRAINT FK_PhieuDat_IdKhuyenMai FOREIGN KEY (IdKhuyenMai) REFERENCES KhuyenMai(Id)

ALTER TABLE ChiTietPhieuDat
	ADD
		CONSTRAINT FK_ChiTietPhieuDat_IdPhieuDat FOREIGN KEY (IdPhieuDat) REFERENCES PhieuDat(Id),
		CONSTRAINT FK_ChiTietPhieuDat_IdSanPham FOREIGN KEY (IdSanPham) REFERENCES SanPham(Id),
		CONSTRAINT PK_ChiTietPhieuDat_IdPhieuDat_IdSanPham PRIMARY KEY (IdPhieuDat, IdSanPham)

ALTER TABLE DiaChi
	ADD
		CONSTRAINT FK_DiaChi_IdTaiKhoan FOREIGN KEY (IdTaiKhoan) REFERENCES TaiKhoan(Id),
		CONSTRAINT FK_DiaChi_IdTinhThanh FOREIGN KEY (IdTinhThanh) REFERENCES TinhThanh(Id)

ALTER TABLE QuangCao
	ADD
		CONSTRAINT FK_QuangCao_IdGoiQuangCao FOREIGN KEY (IdGoiQuangCao) REFERENCES GoiQuangCao(Id),
		CONSTRAINT FK_QuangCao_IdTaiKhoan FOREIGN KEY (IdTaiKhoan) REFERENCES TaiKhoan(Id)

ALTER TABLE GioHang
	ADD
		CONSTRAINT FK_GioHang_IdTaiKhoan FOREIGN KEY (IdTaiKhoan) REFERENCES TaiKhoan(Id),
		CONSTRAINT FK_GioHang_IdSanPham FOREIGN KEY (IdSanPham) REFERENCES SanPham(Id),
		CONSTRAINT PK_GioHang_IdTaiKhoan_IdSanPham PRIMARY KEY (IdTaiKhoan, IdSanPham)

ALTER TABLE GoiQuangCao
	ADD
		CONSTRAINT FK_GoiQuangCao_ViTriQuangCao FOREIGN KEY(IdViTri) REFERENCES ViTriQuangCao(Id)

ALTER TABLE ViTriQuangCao
	ADD
		CONSTRAINT FK_ViTriQuangCao_TrangQuangCao FOREIGN KEY(IdTrang) REFERENCES TrangQuangCao(Id)

