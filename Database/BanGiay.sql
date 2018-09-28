use master
GO
drop database BanGiay
GO
use master
GO
create database BanGiay
GO
use BanGiay
GO

CREATE TABLE nhanvien
(   
    id uniqueidentifier,
	manv varchar(10) unique not null,
	tennv Nvarchar(100),
	gioitinh Nvarchar(5),
    ngaysinh datetime,
	diachi Nvarchar(100),
	dienthoai Nvarchar(20),
	cmnd nvarchar(20),
	loai Nvarchar(20),
	ngaylam nvarchar(50),
	giolam nvarchar(50),
	luong float,
	tinhtrang Nvarchar(20),
	PRIMARY KEY(id)
)
GO

CREATE TABLE taikhoan
(
   id uniqueidentifier,
   matk varchar(10) unique NOT NULL,
   username nvarchar(100) unique NOT NULL,
   password nvarchar(100) NOT NULL,
   email nvarchar(100),
   ten nvarchar(100),
   maquan varchar(10),
   dienthoai nvarchar(20),
   cmnd nvarchar(20),
   loai nvarchar(20),
   ngaytao datetime,
   tinhtrang nvarchar(20),
   PRIMARY KEY(id)
 )
 GO
 
CREATE TABLE sanpham
(
   id uniqueidentifier,
   masp varchar(10) unique not null,
   tensp nvarchar(100),
   gia float,
   soluong int,
   hinh varchar(256) default null,
   chitiet nvarchar(1000),
   makm varchar(10),
   tinhtrang nvarchar(20),
   matk varchar(10),
   PRIMARY KEY (id)
)
GO

CREATE TABLE phieunhap
(
  id uniqueidentifier,
  mapn varchar(10) unique not null,
  manv varchar(10),
  matk varchar(10),
  ngaynhap datetime,
  PRIMARY KEY (id)
)
GO

CREATE TABLE chitietphieunhap
( 
  id uniqueidentifier,
  mactpn varchar(10) unique not null,
  mapn varchar(10),
  masp varchar(10),
  soluong int,
  PRIMARY KEY (id)
)
GO

CREATE TABLE phieugiao
(
   id uniqueidentifier,
   mapg varchar(10) unique not null,
   tengiao varchar(100),
   cmndgiao varchar(20),
   matk varchar(10),
   diachi nvarchar(100),
   maquan varchar(10),
   mahh varchar(10),
   tonggia float,
   ngaytao datetime,
   ngaygui datetime,
   tinhtrang nvarchar(20),
   PRIMARY KEY (id)
)
GO

CREATE TABLE chitietphieugiao
( 
 id uniqueidentifier,
 mactpg varchar(10) unique not null,
 mapg varchar(10),
 masp varchar(10),
 matk varchar(10),
 soluong int,
 PRIMARY KEY(id)
)
GO

CREATE TABLE phieuxuat
(
id uniqueidentifier,
mapx varchar(10) unique not null,
ngaytao datetime,
ngayxuat datetime,
tinhtrang nvarchar(20),
PRIMARY KEY (id)
)
GO

CREATE TABLE chitietphieuxuat
(
id uniqueidentifier,
mactpx varchar(10) unique not null,
mapx varchar(10),
masp varchar(10),
soluong int,
PRIMARY KEY (id)
)
GO
 

CREATE TABLE phieudat
( 
  id uniqueidentifier,
  mapd varchar(10) unique not null,
  matk varchar(10),
  ngaytao datetime,
  tinhtrang nvarchar(20),
  PRIMARY KEY (ID)
)
GO

CREATE TABLE chitietphieudat
(
 id uniqueidentifier,
 mactpd varchar(10) unique not null,
 mapd varchar(10),
 matk varchar(10),
 masp varchar(10),
 soluong int,
 PRIMARY KEY (id)
)
GO

CREATE TABLE quan
(
 id uniqueidentifier,
 maquan varchar(10) unique not null,
 quan nvarchar(255),
 gia float,
 PRIMARY KEY (id)
)
GO

CREATE TABLE khuyenmai
(
id uniqueidentifier,
makm varchar(10) unique not null,
giamgia float,
primary key(id)
)
GO

CREATE TABLE hoahong
(
id uniqueidentifier,
mahh varchar(10) unique not null,
hoahong float,
primary key(id)
)
GO

CREATE TABLE diachi
(
id uniqueidentifier,
madc varchar(10) unique not null,
matk varchar(10),
diachi nvarchar(200),
primary key (id)
)
GO
CREATE TABLE hopdong
(
id uniqueidentifier,
mahd varchar(10) unique  not null,
manv varchar(10),
matk varchar(10),
ngaybatdau datetime,
ngayketthuc datetime,
primary key (id)
)
GO
CREATE TABLE quangcao
(
id uniqueidentifier,
maqc varchar(10) unique not null,
mavt varchar(10),
hinh varchar(100),
thoigian varchar(10),
thoiluong float,
mgaybatdau datetime,
ngayketthuc datetime,
gia float,
chuthich nvarchar(100),
tinhtrang nvarchar(10),
primary key (id)
)
GO
CREATE TABLE tienquangcao
(
id uniqueidentifier,
mavt varchar(10) unique not null,
vitri nvarchar(100),
gia float,
primary key (id)
)
GO
 
ALTER TABLE quangcao
ADD CONSTRAINT FK_quangcao_tienquangcao
FOREIGN KEY (mavt)
REFERENCES tienquangcao(mavt)
GO
ALTER TABLE hopdong
ADD CONSTRAINT FK_hopdong_nhanvien
FOREIGN KEY(manv)
REFERENCES nhanvien(manv)
GO
ALTER TABLE hopdong
ADD CONSTRAINT FK_hopdong_taikhoan
FOREIGN KEY(matk)
REFERENCES taikhoan(matk)
GO
ALTER TABLE diachi
ADD CONSTRAINT FK_diachi_taikhoan
FOREIGN KEY(matk)
REFERENCES taikhoan(matk) 
GO
ALTER TABLE phieugiao
ADD CONSTRAINT FK_phieugiao_hoahong
FOREIGN KEY(mahh)
REFERENCES hoahong(mahh)
GO

ALTER TABLE taikhoan
ADD CONSTRAINT FK_taikhoan_quan
FOREIGN KEY (maquan)
REFERENCES quan(maquan)
GO

ALTER TABLE sanpham
ADD CONSTRAINT FK_sanpham_khuyenmai
FOREIGN KEY (makm)
REFERENCES khuyenmai(makm)
GO

ALTER TABLE sanpham
ADD CONSTRAINT FK_sanpham_taikhoan
FOREIGN KEY (matk)
REFERENCES taikhoan(matk)
GO

ALTER TABLE phieunhap
ADD CONSTRAINT FK_phieunhap_taikhoan
FOREIGN KEY (matk)
REFERENCES taikhoan(matk)
GO

ALTER TABLE phieunhap
ADD CONSTRAINT FK_phieunhap_nhanvien
FOREIGN KEY (manv)
REFERENCES nhanvien(manv)
GO

ALTER TABLE chitietphieunhap
ADD CONSTRAINT FK_chitietphieunhap_phieunhap
FOREIGN KEY (mapn)
REFERENCES phieunhap(mapn)
GO

ALTER TABLE chitietphieunhap
ADD CONSTRAINT FK_chitietphieunhap_sanpham
FOREIGN KEY (masp)
REFERENCES sanpham(masp)
GO

ALTER TABLE phieugiao
ADD CONSTRAINT FK_phieugiao_taikhoan
FOREIGN KEY (matk)
REFERENCES taikhoan(matk)
GO

ALTER TABLE phieugiao
ADD CONSTRAINT FK_phieugiao_quan
FOREIGN KEY (maquan)
REFERENCES quan(maquan)
GO

ALTER TABLE chitietphieugiao
ADD CONSTRAINT FK_chitietphieugiao_phieugiao
FOREIGN KEY (mapg)
REFERENCES phieugiao(mapg)
GO

ALTER TABLE chitietphieugiao
ADD CONSTRAINT FK_chitietphieugiao_sanpham
FOREIGN KEY (masp)
REFERENCES sanpham(masp)
GO

ALTER TABLE chitietphieugiao
ADD CONSTRAINT FK_chitietphieugiao_taikhoan
FOREIGN KEY (matk)
REFERENCES taikhoan(matk)
GO

ALTER TABLE phieudat
ADD CONSTRAINT FK_phieudat_taikhoan
FOREIGN KEY (matk)
REFERENCES taikhoan(matk)
GO

ALTER TABLE chitietphieudat
ADD CONSTRAINT FK_chitietphieudat_phieudat
FOREIGN KEY (mapd)
REFERENCES phieudat(mapd)
GO

ALTER TABLE chitietphieudat
ADD CONSTRAINT FK_chitietphieudat_taikhoan
FOREIGN KEY(matk)
REFERENCES taikhoan(matk)
GO

ALTER TABLE chitietphieudat
ADD CONSTRAINT FK_chitietphieudat_sanpham
FOREIGN KEY (masp)
REFERENCES sanpham(masp)
GO






