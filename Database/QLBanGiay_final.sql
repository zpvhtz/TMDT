USE master
GO
--
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
	TenLoaiNguoiDung NVARCHAR(20), --Merchant, Customer, Nhân viên--
	TinhTrang NVARCHAR(20)
)

CREATE TABLE TaiKhoan
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	TenDangNhap VARCHAR(20) UNIQUE NOT NULL,
	MatKhau VARCHAR(50) NOT NULL,
	Email VARCHAR(100) UNIQUE NOT NULL,
	Ten NVARCHAR(100),
	TenShop NVARCHAR(100),
	DienThoai VARCHAR(20),
	CMND VARCHAR(20) UNIQUE,
	IdLoaiNguoiDung UNIQUEIDENTIFIER NOT NULL, --FK--
	NgayTao DATETIME,
	DanhGia FLOAT,
	ThoiHanGianHang DATETIME, --Chỉ kiểm tra khi là Merchant, ghi lại thời gian kết thúc--
	DatLaiMatKhau INT, --1:Có/0:Không--
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
	Mau NVARCHAR(20), --Màu--
	IdHangSanPham UNIQUEIDENTIFIER NOT NULL, --FK--
	PhanLoai NVARCHAR(10), --Nam/Nữ--
	Gia FLOAT,
	Hinh NVARCHAR(200),
	ChiTiet NVARCHAR(500),
	GiamGia FLOAT, -- vidu : giảm 10% = 10 --
	NgayDang DATETIME, --Ngày đăng--
	TinhTrang NVARCHAR(20)
)

CREATE TABLE SizeSanPham
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	IdSanPham UNIQUEIDENTIFIER NOT NULL, --FK--
	Size INT,
	SoLuong INT,
	TinhTrang NVARCHAR(20)
)

CREATE TABLE HangSanPham
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaHang VARCHAR(10) UNIQUE NOT NULL,
	TenHang NVARCHAR(100),
	TinhTrang NVARCHAR(20)
)

CREATE TABLE DonHang
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaDonHang VARCHAR(10) UNIQUE NOT NULL,
	IdTaiKhoan UNIQUEIDENTIFIER NOT NULL, --FK (Người đặt)--
	DiaChiGiao NVARCHAR(200),
	NgayTao DATETIME,
	TongTien FLOAT,
	TinhTrangDanhGiaCustomer NVARCHAR(20), --Chưa đánh giá, đã đánh giá--
	TinhTrang NVARCHAR(20) --Chưa xử lý, Đã xử lý--
)

CREATE TABLE ChiTietDonHang
(
	IdDonHang UNIQUEIDENTIFIER NOT NULL, --PK, FK--
	IdSizeSanPham UNIQUEIDENTIFIER NOT NULL, --PK, FK--
	NgayGiao DATETIME,
	SoLuong INT,
	DonGia FLOAT,
	DiemCustomerDanhGia FLOAT, --1 - 5 | 0 là chưa đánh giá--
	DiemMerchantDanhGia FLOAT, --1 - 5 | 0 là chưa đánh giá--
	TinhTrangChiTiet NVARCHAR(20) --Chưa xử lý, Đang giao, Đang xử lý, Đã xử lý, Đã huỷ--
)

CREATE TABLE TinhThanh --Tỉnh thành--
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaTinhThanh VARCHAR(10) UNIQUE NOT NULL,
	TenTinhThanh NVARCHAR(20),
	TinhTrang NVARCHAR(20)
)

CREATE TABLE DiaChi
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	IdTaiKhoan UNIQUEIDENTIFIER NOT NULL, --FK--
	Duong NVARCHAR(100) NOT NULL, --Đường--
	IdTinhThanh UNIQUEIDENTIFIER NOT NULL, --FK--
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
	DuongDan VARCHAR(200), --Link--
	ChuThich NVARCHAR(500),
	TinhTrang NVARCHAR(20)
)

CREATE TABLE GoiQuangCao
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaGoiQuangCao VARCHAR(10) UNIQUE NOT NULL,
	IdViTri UNIQUEIDENTIFIER NOT NULL, -- FK -- 
	TongTien FLOAT,
	ThoiLuong INT, --Ngày--
	TinhTrang NVARCHAR(20)
)

CREATE TABLE TrangQuangCao
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaTrang VARCHAR(10) UNIQUE NOT NULL,
	TenTrang NVARCHAR(100),
	ChuThich NVARCHAR(100),
	TinhTrang NVARCHAR(20)
)

CREATE TABLE ViTriQuangcao
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaViTri VARCHAR(10) UNIQUE NOT NULL,
	TenViTri NVARCHAR(100),
	IdTrang UNIQUEIDENTIFIER NOT NULL, -- FK --
	DonGia FLOAT,
	ChuThich NVARCHAR(100),
	TinhTrang NVARCHAR(20)
)

CREATE TABLE GioHang
(
	IdTaiKhoan UNIQUEIDENTIFIER NOT NULL, --PK, FK--
	IdSizeSanPham UNIQUEIDENTIFIER NOT NULL, --PK, FK--
	SoLuong INT,
	TinhTrang NVARCHAR(20)
)

CREATE TABLE GiaShip
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	Loai NVARCHAR(20), -- NOI THANH HAY NGOAI THANH
	Gia FLOAT,
	NgayCapNhat DATETIME
)

CREATE TABLE GianHang --Cho thuê gian hàng theo thời gian--
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaGianHang VARCHAR(10) UNIQUE NOT NULL,
	TenGianHang NVARCHAR(100),
	Gia FLOAT,
	ThoiGian INT, --Tính theo ngày--
	TinhTrang NVARCHAR(20)
)

CREATE TABLE LichSuGianHang --Lịch sử đăng ký gian hàng--
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	IdTaiKhoan UNIQUEIDENTIFIER NOT NULL, --FK--
	IdGianHang UNIQUEIDENTIFIER NOT NULL, --FK--
	NgayDangKy DATETIME,
	NgayBatDau DATETIME,
	NgayKetThuc DATETIME,
	TinhTrang NVARCHAR(20)
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
		CONSTRAINT FK_SanPham_IdTaiKhoan FOREIGN KEY (IdTaiKhoan) REFERENCES TaiKhoan(Id),
		CONSTRAINT FK_SanPham_IdHangSanPham FOREIGN KEY (IdHangSanPham) REFERENCES HangSanPham(Id)

ALTER TABLE SizeSanPham
	ADD
		CONSTRAINT FK_SizeSanPham_IdSanPham FOREIGN KEY (IdSanPham) REFERENCES SanPham(Id)

ALTER TABLE DonHang
	ADD
		CONSTRAINT FK_DonHang_IdTaiKhoan FOREIGN KEY (IdTaiKhoan) REFERENCES TaiKhoan(Id)

ALTER TABLE ChiTietDonHang
	ADD
		CONSTRAINT FK_ChiTietDonHang_IdDonHang FOREIGN KEY (IdDonHang) REFERENCES DonHang(Id),
		CONSTRAINT FK_ChiTietDonHang_IdSizeSanPham FOREIGN KEY (IdSizeSanPham) REFERENCES SizeSanPham(Id),
		CONSTRAINT PK_ChiTietDonHang_IdDonHang_IdSanPham PRIMARY KEY (IdDonHang, IdSizeSanPham)

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
		CONSTRAINT FK_GioHang_IdSizeSanPham FOREIGN KEY (IdSizeSanPham) REFERENCES SizeSanPham(Id),
		CONSTRAINT PK_GioHang_IdTaiKhoan_IdSizeSanPham PRIMARY KEY (IdTaiKhoan, IdSizeSanPham)

ALTER TABLE GoiQuangCao
	ADD
		CONSTRAINT FK_GoiQuangCao_ViTriQuangCao FOREIGN KEY(IdViTri) REFERENCES ViTriQuangCao(Id)

ALTER TABLE ViTriQuangCao
	ADD
		CONSTRAINT FK_ViTriQuangCao_TrangQuangCao FOREIGN KEY(IdTrang) REFERENCES TrangQuangCao(Id)

ALTER TABLE LichSuGianHang
	ADD
		CONSTRAINT FK_LichSuGianHang_IdTaiKhoan FOREIGN KEY (IdTaiKhoan) REFERENCES TaiKhoan(Id),
		CONSTRAINT FK_LichSuGianHang_IdGianHang FOREIGN KEY (IdGianHang) REFERENCES GianHang(Id)
GO

--STORE PROCEDURED--
---tao pro list con hang, het hang
CREATE PROC p_conhang 
as
	select IdSanPham,SUM(SoLuong) as SoLuong from SizeSanPham
	group by IdSanPham
	having SUM(SoLuong)>0
go
---het hang
CREATE PROC p_hethang (@TenDangNhap VARCHAR(20)) 
as
	select sp.Id, sp.MaSanPham, sp.TenSanPham, sp.IdTaiKhoan, sp.Mau, sp.IdHangSanPham, sp.PhanLoai, sp.Gia, sp.Hinh, sp.ChiTiet, sp.GiamGia, sp.NgayDang, sp.TinhTrang
	from SanPham sp JOIN TaiKhoan tk ON sp.IdTaiKhoan = tk.Id
	where sp.TinhTrang = N'Không khoá' and tk.TenDangNhap = @TenDangNhap and sp.Id in
	(
		select IdSanPham from SizeSanPham
		group by IdSanPham
		having SUM(SoLuong)=0
	) 
go

CREATE PROC P_HetHang_Pagging (@TenDangNhap VARCHAR(20), @pageSize INT, @pageNumber INT)
AS
	DECLARE @Skip INT
	SET @Skip = ((@pageNumber - 1) * @pageSize)
	--
	select sp.Id, sp.MaSanPham, sp.TenSanPham, sp.IdTaiKhoan, sp.Mau, sp.IdHangSanPham, sp.PhanLoai, sp.Gia, sp.Hinh, sp.ChiTiet, sp.GiamGia, sp.NgayDang, sp.TinhTrang
	FROM SanPham sp JOIN TaiKhoan tk ON sp.IdTaiKhoan = tk.Id
	WHERE sp.TinhTrang = N'Không khoá' AND tk.TenDangNhap = @TenDangNhap AND sp.Id IN
	(
		SELECT IdSanPham
		FROM SizeSanPham
		GROUP BY IdSanPham
		HAVING SUM(SoLuong) = 0
	)
	ORDER BY Id
	OFFSET @Skip ROWS
	FETCH NEXT @pageSize ROWS ONLY
GO

---SEARCH
CREATE PROC P_HetHang_Search (@TenDangNhap VARCHAR(20), @search NVARCHAR(100), @pageSize INT, @pageNumber INT)
AS
	DECLARE @Skip INT
	DECLARE @searchString NVARCHAR(100)
	SET @Skip = ((@pageNumber - 1) * @pageSize)
	SET @searchString = '%' + @search + '%'
	--
	SELECT sp.Id, sp.MaSanPham, sp.TenSanPham, sp.IdTaiKhoan, sp.Mau, sp.IdHangSanPham, sp.PhanLoai, sp.Gia, sp.Hinh, sp.ChiTiet, sp.GiamGia, sp.NgayDang, sp.TinhTrang
	FROM SanPham sp JOIN TaiKhoan tk ON sp.IdTaiKhoan = tk.Id
	WHERE sp.TinhTrang = N'Không khoá' AND (TenSanPham LIKE @searchString OR Mau LIKE @searchString OR Gia LIKE @searchString) AND tk.TenDangNhap = @TenDangNhap AND sp.Id IN
	(
		SELECT IdSanPham
		FROM SizeSanPham
		GROUP BY IdSanPham
		HAVING SUM(SoLuong) = 0
	)
	ORDER BY sp.Id
	OFFSET @Skip ROWS
	FETCH NEXT @pageSize ROWS ONLY
GO

CREATE PROC P_HetHang_Search_NotPagging (@TenDangNhap VARCHAR(20), @search NVARCHAR(100))
AS
	DECLARE @Skip INT
	DECLARE @searchString NVARCHAR(100)
	SET @searchString = '%' + @search + '%'
	--
	SELECT sp.Id, sp.MaSanPham, sp.TenSanPham, sp.IdTaiKhoan, sp.Mau, sp.IdHangSanPham, sp.PhanLoai, sp.Gia, sp.Hinh, sp.ChiTiet, sp.GiamGia, sp.NgayDang, sp.TinhTrang
	FROM SanPham sp JOIN TaiKhoan tk ON sp.IdTaiKhoan = tk.Id
	WHERE sp.TinhTrang = N'Không khoá' AND (TenSanPham LIKE @searchString OR Mau LIKE @searchString OR Gia LIKE @searchString) AND tk.TenDangNhap = @TenDangNhap AND sp.Id IN
	(
		SELECT IdSanPham
		FROM SizeSanPham
		GROUP BY IdSanPham
		HAVING SUM(SoLuong) = 0
	)
	ORDER BY sp.Id
GO

--TRIGGER--
--Trigger cộng thời gian cho merchant--
CREATE TRIGGER TG_ThemThoiGian_GianHang ON LichSuGianHang AFTER INSERT
AS
	DECLARE @IdLichSuGianHang UNIQUEIDENTIFIER
	DECLARE @IdTaiKhoan UNIQUEIDENTIFIER
	DECLARE @IdGianHang UNIQUEIDENTIFIER
	DECLARE @ThoiGian INT
	DECLARE @ThoiHanGianHang DATETIME
	--
	DECLARE CUR CURSOR FOR
	SELECT i.Id, i.IdTaiKhoan, i.IdGianHang, g.ThoiGian
	FROM inserted i JOIN GianHang g ON i.IdGianHang = g.Id
	--
	OPEN CUR
	FETCH NEXT FROM CUR INTO @IdLichSuGianHang, @IdTaiKhoan, @IdGianHang, @ThoiGian
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SELECT @ThoiHanGianHang = ThoiHanGianHang
		FROM TaiKhoan
		WHERE Id = @IdTaiKhoan
		--
		IF(@ThoiHanGianHang < GETDATE())
		BEGIN
			--Update LichSuGianHang--
			UPDATE LichSuGianHang
			SET NgayBatDau = GETDATE(), NgayKetThuc = DATEADD(DAY, @ThoiGian, GETDATE())
			WHERE Id = @IdLichSuGianHang
			--Update TaiKhoan--
			UPDATE TaiKhoan
			SET ThoiHanGianHang = DATEADD(DAY, @ThoiGian, GETDATE())
			WHERE Id = @IdTaiKhoan
		END
		ELSE
		BEGIN
			--Update LichSuGianHang--
			UPDATE LichSuGianHang
			SET NgayBatDau = @ThoiHanGianHang, NgayKetThuc = DATEADD(DAY, @ThoiGian, @ThoiHanGianHang)
			WHERE Id = @IdLichSuGianHang
			--Update TaiKhoan--
			UPDATE TaiKhoan
			SET	ThoiHanGianHang = DATEADD(DAY, @ThoiGian, ThoiHanGianHang)
			WHERE Id = @IdTaiKhoan
		END
		FETCH NEXT FROM CUR INTO @IdLichSuGianHang, @IdTaiKhoan, @IdGianHang, @ThoiGian
	END
	CLOSE CUR
	DEALLOCATE CUR
GO

--Trigger trừ thời gian của merchant--
CREATE TRIGGER TG_SuaThoiGian_GianHang ON LichSuGianHang AFTER UPDATE
AS
	DECLARE @ThoiGian INT
	DECLARE @IdTaiKhoan UNIQUEIDENTIFIER
	--
	SELECT @IdTaiKhoan = i.IdTaiKhoan, @ThoiGian = g.ThoiGian
	FROM inserted i JOIN GianHang g ON i.IdGianHang = g.Id
	--
	UPDATE TaiKhoan
	SET ThoiHanGianHang = DATEADD(DAY, -@ThoiGian, ThoiHanGianHang)
	WHERE Id = @IdTaiKhoan
GO

--Thêm size sản phẩm tự động--
CREATE TRIGGER TG_ThemSizeSanPham ON SanPham AFTER INSERT
AS
	DECLARE @IdSanPham UNIQUEIDENTIFIER
	--
	DECLARE CUR CURSOR FOR
	SELECT Id
	FROM inserted
	--
	OPEN CUR
	FETCH NEXT FROM CUR INTO @IdSanPham
	WHILE(@@FETCH_STATUS = 0)
	BEGIN
		DECLARE @I INT
		SET @I = 35
		--
		WHILE(@I <= 45)
		BEGIN
			INSERT INTO SizeSanPham
				VALUES (NEWID(), @IdSanPham, @I, 0, N'Không khoá')
			--
			SET @I = @I + 1
		END
		FETCH NEXT FROM CUR INTO @IdSanPham
	END
	CLOSE CUR
	DEALLOCATE CUR
GO

--Trigger cộng lại số lượng cho sản phẩm nếu đơn huỷ--
CREATE TRIGGER TG_CongSoLuong_SizeSanPham_DonHang ON DonHang AFTER UPDATE
AS
	DECLARE @IdDonHang UNIQUEIDENTIFIER
	DECLARE @TinhTrang NVARCHAR(20)
	--
	SELECT @IdDonHang = Id, @TinhTrang = TinhTrang
	FROM inserted
	--
	IF(@TinhTrang = N'Đã huỷ')
	BEGIN
		DECLARE @IdSizeSanPham UNIQUEIDENTIFIER
		DECLARE @SoLuong INT
		--
		DECLARE CUR CURSOR FOR
		SELECT IdSizeSanPham, SoLuong
		FROM ChiTietDonHang
		WHERE IdDonHang = @IdDonHang
		--
		OPEN CUR
		FETCH NEXT FROM CUR INTO @IdSizeSanPham, @SoLuong
		WHILE @@FETCH_STATUS = 0
		BEGIN
			UPDATE SizeSanPham
			SET SoLuong = SoLuong + @SoLuong
			WHERE Id = @IdSizeSanPham
			--
			FETCH NEXT FROM CUR INTO @IdSizeSanPham, @SoLuong
		END
		CLOSE CUR
		DEALLOCATE CUR
	END
GO

--Trigger cập nhật tình trạng đơn hàng khi mọi merchant đều đã xử lý--
CREATE TRIGGER TG_CapNhatTinhTrang_DonHang ON ChiTietDonHang AFTER UPDATE
AS
	DECLARE @IdDonHang UNIQUEIDENTIFIER
	DECLARE @TongChiTietDonHang INT
	DECLARE @TongChiTietDonHangDaXuLy INT
	--
	SELECT @IdDonHang = IdDonHang
	FROM inserted
	--
	SELECT @TongChiTietDonHang = COUNT(*)
	FROM ChiTietDonHang
	WHERE IdDonHang = @IdDonHang
	--
	SELECT @TongChiTietDonHangDaXuLy = COUNT(*)
	FROM ChiTietDonHang
	WHERE IdDonHang = @IdDonHang AND TinhTrangChiTiet = N'Đã xử lý'
	--
	IF(@TongChiTietDonHang = @TongChiTietDonHangDaXuLy)
	BEGIN
		UPDATE DonHang
		SET	TinhTrang = N'Đã xử lý'
		WHERE Id = @IdDonHang
	END
GO

--Trigger cập nhật tình trạng đánh giá của đơn hàng khi customer đều đã đánh giá--
CREATE TRIGGER TG_CapNhatTinhTrangDanhGiaCustumer_DonHang ON ChiTietDonHang AFTER UPDATE
AS
	DECLARE @IdDonHang UNIQUEIDENTIFIER
	DECLARE @TongChiTietDonHang INT
	DECLARE @TongChiTietDonHangDaDanhGia INT
	--
	SELECT @IdDonHang = IdDonHang
	FROM inserted
	--
	SELECT @TongChiTietDonHang = COUNT(*)
	FROM ChiTietDonHang
	WHERE IdDonHang = @IdDonHang
	--
	SELECT @TongChiTietDonHangDaDanhGia = COUNT(*)
	FROM ChiTietDonHang
	WHERE IdDonHang = @IdDonHang AND DiemCustomerDanhGia != 0
	--
	IF(@TongChiTietDonHang = @TongChiTietDonHangDaDanhGia)
	BEGIN
		UPDATE DonHang
		SET	TinhTrangDanhGiaCustomer = N'Đã đánh giá'
		WHERE Id = @IdDonHang
	END
GO

--Trigger tính lại điểm đánh giá--
CREATE TRIGGER TG_CongDiemDanhGia ON DanhGia AFTER INSERT
AS
	DECLARE @IdTaiKhoanDuocDanhGia UNIQUEIDENTIFIER
	DECLARE @DiemTrungBinh FLOAT
	--
	SELECT @IdTaiKhoanDuocDanhGia = IdTaiKhoanDuocDanhGia
	FROM inserted
	--
	SELECT @DiemTrungBinh = AVG(Diem)
	FROM DanhGia
	WHERE IdTaiKhoanDuocDanhGia = @IdTaiKhoanDuocDanhGia
	--
	UPDATE TaiKhoan
	SET DanhGia = @DiemTrungBinh
	WHERE Id = @IdTaiKhoanDuocDanhGia
GO

--DỮ LIỆU--
INSERT INTO LoaiNguoiDung
	VALUES ('75523BB6-C366-4A28-A85C-B4C8C1D5747A', 'USR-WMT', N'Webmaster', N'Không khoá'),
		   ('15CF8A9B-517E-4BAE-91E2-F30C596990ED', 'USR-CUS', N'Khách hàng', N'Không khoá'),
		   ('EA9FC9A5-9C26-40A4-9E8E-BB3DAE4E0156', 'USR-MER', N'Thương nhân', N'Không khoá')

INSERT INTO TaiKhoan
	VALUES('CA2EE7E2-7F64-4A5A-A49B-E22E9E05F053', 'merchant1', 'F98919752BF9BFB31E539A1FE663FD68', 'hieu.trung.030197@gmail.com', N'Hiếu Trung', N'Titan', '09354268754', '654238415', 'EA9FC9A5-9C26-40A4-9E8E-BB3DAE4E0156', GETDATE(), 0, GETDATE(), 0, N'Không khoá'),
	      ('18D79B1D-EE48-459A-AD1D-09A05A4773AD', 'merchant2', '8B550A0CA911A53B1C6FC398C7828F40', 'tnngo.97@gmail.com', N'Thị Nho', N'Ramuh', '09345123654', '356984126', 'EA9FC9A5-9C26-40A4-9E8E-BB3DAE4E0156', GETDATE(), 0, GETDATE(), 0, N'Không khoá'),
		  ('499A28F6-67A2-4D2D-B027-183058A07646', 'merchant3', '3E99AD8EE3FBCBFA3D369D7FB0B0EA89', 'merchant03@gmail.com', N'Thanh Thảo', N'Shiva', '0935426714', '657135426', 'EA9FC9A5-9C26-40A4-9E8E-BB3DAE4E0156', GETDATE(), 0, GETDATE(), 0, N'Không khoá'),
		  ('739E7B3F-D6B8-4C48-81B4-487B75589E80', 'merchant4', 'DBB63DEE74EAD9034DEFD63D91D197E9', 'merchant04@gmail.com', N'Bá Đông', N'Leviathan', '0936582613', '958743265', 'EA9FC9A5-9C26-40A4-9E8E-BB3DAE4E0156', GETDATE(), 0, GETDATE(), 0, N'Không khoá'),
		  ('9D042E88-B462-4811-9FED-4CC6A1C7A3AC', 'merchant5', 'B522147E61BA70E1757ADF4988757BCA', 'merchant05@gmail.com', N'Lý Thành', N'Bahamut', '0934513559', '154786254', 'EA9FC9A5-9C26-40A4-9E8E-BB3DAE4E0156', GETDATE(), 0, GETDATE(), 0, N'Không khoá'),
		  ('1A31055B-A4BB-4BD7-81AB-1792CEB4B080', 'merchant6', 'F0277B130FA4966F39FD1986168DC042', 'merchant06@gmail.com', N'Quốc Thắng', N'Ifrit', '0937423651', '597326549', 'EA9FC9A5-9C26-40A4-9E8E-BB3DAE4E0156', GETDATE(), 0, GETDATE(), 0, N'Không khoá'),
		  ('0C2F1A1B-6412-4FE2-B229-5FCE555349FC', 'customer1', 'FFBC4675F864E0E9AAB8BDF7A0437010', 'chunglinhdan@gmail.com', N'Trang Thảo', NULL, '0934851349', '954134782', '15CF8A9B-517E-4BAE-91E2-F30C596990ED', GETDATE(), 0, NULL, 0, N'Không khoá'),
		  ('1FFCCD2B-D22D-4F01-8E5B-2CA3B690D5D7', 'customer2', '5CE4D191FD14AC85A1469FB8C29B7A7B', 'quachdaivy7@gmail.com', N'Đại Vĩ', NULL, '0935684251', '597268451', '15CF8A9B-517E-4BAE-91E2-F30C596990ED', GETDATE(), 0, NULL, 0, N'Không khoá'),
		  ('7C24DC80-B487-40D2-A656-B6358962BBF5', 'customer3', '033F7F6121501AE98285AD77F216D5E7', 'customer3@gmail.com', N'Anh Vũ', NULL, '0934621574', '684326519', '15CF8A9B-517E-4BAE-91E2-F30C596990ED', GETDATE(), 0, NULL, 0, N'Không khoá'),
		  ('1D154C23-D7F1-47C6-8E3A-4CA13CBC837D', 'customer4', '55FEB130BE438E686AD6A80D12DD8F44', 'customer4@gmail.com', N'Kiến Vinh', NULL, '0934625795', '132574985', '15CF8A9B-517E-4BAE-91E2-F30C596990ED', GETDATE(), 0, NULL, 0, N'Không khoá'),
		  ('EA550E6B-34F1-45F7-BEAB-52435507FD03', 'customer5', '9E8486CDD435BEDA9A60806DD334D964', 'customer5@gmail.com', N'Anh Dũng', NULL, '0931652346', '953264158', '15CF8A9B-517E-4BAE-91E2-F30C596990ED', GETDATE(), 0, NULL, 0, N'Không khoá'),
		  ('5FED6DA6-45E0-4825-8B03-689E30C5EC17', 'customer6', 'DBAA8BD25E06CC641F5406027C026E8B', 'customer6@gmail.com', N'Minh Bảo', NULL, '0934851362', '745632658', '15CF8A9B-517E-4BAE-91E2-F30C596990ED', GETDATE(), 0, NULL, 0, N'Không khoá'),
		  ('87186AF2-0D45-4ACD-898D-D799728C08AE', 'admin', '21232F297A57A5A743894A0E4A801FC3', 'feast.pock@gmail.com', N'Thiên Tuấn', NULL, '0934816735', '341267458', '75523BB6-C366-4A28-A85C-B4C8C1D5747A', GETDATE(), 0, NULL, 0, N'Không khoá'),
		  ('8634C513-90FB-4DB7-9E80-F8278ECDEF68', 'admin2', 'C84258E9C39059A89AB77D846DDAB909', 'admin2@gmail.com', N'Hoàng Tuấn', NULL, '0934125436', '6598742365', '75523BB6-C366-4A28-A85C-B4C8C1D5747A', GETDATE(), 0, NULL, 0, N'Không khoá')

INSERT INTO GianHang
	VALUES('2AE717B5-01AC-47DB-97FF-550130D1C537', 'GH-1', N'Gói 30 ngày', 400000, 30, N'Không khoá'),
		  ('3AE382C3-D4D9-44ED-8D0C-DBFA911A13BA', 'GH-2', N'Gói 60 ngày', 780000, 60, N'Không khoá'),
		  ('9FDEDF57-2F92-40B9-81CA-96A37472A81E', 'GH-3', N'Gói 6 tháng', 2200000, 180, N'Không khoá'),
		  ('80FF7A53-99C8-4505-AA5A-F19F1D82A5C6', 'GH-4', N'Gói 1 năm', 4200000, 365, N'Không khoá')

INSERT INTO LichSuGianHang(Id, IdTaiKhoan, IdGianHang, NgayDangKy, TinhTrang)
	VALUES('B1AD6C00-2136-476A-A120-1CCBAB3147F2', 'CA2EE7E2-7F64-4A5A-A49B-E22E9E05F053', '80FF7A53-99C8-4505-AA5A-F19F1D82A5C6', GETDATE(), N'Không khoá'),
		  ('B4000F6F-DE84-4467-92B9-3FAF28CB9F4C', '18D79B1D-EE48-459A-AD1D-09A05A4773AD', '9FDEDF57-2F92-40B9-81CA-96A37472A81E', GETDATE(), N'Không khoá'),
		  ('F15D5293-3369-45A9-93D3-BE3D5D00378F', '499A28F6-67A2-4D2D-B027-183058A07646', '3AE382C3-D4D9-44ED-8D0C-DBFA911A13BA', GETDATE(), N'Không khoá'),
		  ('1640280A-A9BC-485C-8FD1-5A3A3D2546A7', '739E7B3F-D6B8-4C48-81B4-487B75589E80', '2AE717B5-01AC-47DB-97FF-550130D1C537', GETDATE(), N'Không khoá')

INSERT INTO TinhThanh(Id,MaTinhThanh,TenTinhThanh,TinhTrang)
	VALUES
		  --Miền Bắc--
		  ('29EAC416-7A36-4523-BEE5-4584BA6B46BD','TT-01',N'Hà Nội',N'Không khoá'),
	      ('D39C9656-E5C5-4BB1-8C21-75D2CE92E13A','TT-02',N'Hà Giang',N'Không khoá'),
		  ('4201025A-F3F3-4082-9F67-2960F1987846','TT-03',N'Cao Bằng',N'Không khoá'),
		  ('C5803409-CBEA-4F88-8944-3413BD8CA1B0','TT-04',N'Bắc Kạn',N'Không khoá'),
		  ('CFBCFAB1-9EE6-4406-B057-940DBF737FE1','TT-05',N'Tuyên Quang',N'Không khoá'),
		  ('7C66F864-14CC-48DE-8CF2-B7DEA49BAB35','TT-06',N'Sơn La',N'Không khoá'),
		  ('21ABF173-C30F-43C7-9A42-2C2EFCEF2BA4','TT-07',N'Lào Cai',N'Không khoá'),
		  ('4FE093F8-525E-4825-945C-08C2B7A44C28','TT-08',N'Hải Phòng',N'Không khoá'),
		  ('D6A1904B-48B7-4C6C-8523-53546D209AC8','TT-09',N'Hải Dương',N'Không khoá'),
		  ('698927EA-DC64-4B9F-A58D-D78459CA6540','TT-10',N'Quảng Ninh',N'Không khoá'),
		  --Miên Trung--
		  ('89646395-6011-43E5-A8D0-8DD0826C8B7A','TT-11',N'Nghệ An',N'Không khoá'),
		  ('4584F350-6497-4F74-9341-9D3AD757BC41','TT-12',N'Hà Tĩnh',N'Không khoá'),
		  ('75BAF916-2B94-4DDB-89E7-A2C75B2FF8B9','TT-13',N'Quảng Trị',N'Không khoá'),
		  ('AD60B8AA-732B-4546-9EB1-0E0E565D3417','TT-14',N'Thừa Thiên Huế',N'Không khoá'),
		  ('9EFC73A5-AD71-40EC-B78C-4169800433AB','TT-15',N'Bình Định',N'Không khoá'),
		  ('33795BB6-3340-40F9-8DC0-E1A12252BBD7','TT-16',N'Quảng Trị',N'Không khoá'),
		  ('67D74025-1A09-4239-9622-B44E6B8BA0FB','TT-17',N'Quảng Nam',N'Không khoá'),
		  ('005A59B7-3812-4B23-B154-D8894AB92905','TT-18',N'Đà Nẵng',N'Không khoá'),
		  ('41CD4149-E90F-40F9-B249-B7B98AB4579E','TT-19',N'Phú Yên',N'Không khoá'),
		  --Miền Nam--
		  ('1D683773-5757-4C4E-BE2B-5537B5F567BD','TT-20',N'TP.Hồ Chí Minh',N'Không khoá'),
		  ('EF349D02-B36F-4BB5-B52E-152454BF2454','TT-21',N'Long An',N'Không khoá'),
		  ('61CA453B-3879-4D0E-A254-6D43F54189F1','TT-22',N'Tiền Giang',N'Không khoá'),
		  ('00FEDBBC-6BBA-4BB7-80B8-66A5E3AFF7CC','TT-23',N'Bến Tre',N'Không khoá'),
		  ('226B95A4-16E8-4830-8775-11A04A7BD803','TT-24',N'Trà Vinh',N'Không khoá'),
		  ('50D8C6E3-BCC8-45C4-B724-BE029A071C83','TT-25',N'Vĩnh Long',N'Không khoá'),
		  ('E33B46F3-313E-4008-923E-BA1C27184C19','TT-26',N'An Giang',N'Không khoá'),
		  ('FDF3C543-791C-47F7-8CAF-3AC502996138','TT-27',N'Sóc Trăng',N'Không khoá'),
		  ('24AD4EE6-FD58-43AE-8C7B-A81CAF2E6C60','TT-28',N'Bạc Liêu',N'Không khoá'),
		  ('78AE09D8-B2C7-4023-B133-A515DD3CA8D8','TT-29',N'Cà Mau',N'Không khoá')

INSERT INTO DiaChi
	VALUES('A42E13C6-0AAE-469C-B5A1-3ECDDC7767EB', 'CA2EE7E2-7F64-4A5A-A49B-E22E9E05F053', N'209 Trần Phú P4 Q5', '1D683773-5757-4C4E-BE2B-5537B5F567BD', N'Không khoá'),
		  ('CC133D4A-805C-456A-BD6A-F735561DEDA6', '18D79B1D-EE48-459A-AD1D-09A05A4773AD', N'386 Lê Hồng Phong P1 Q10', '1D683773-5757-4C4E-BE2B-5537B5F567BD', N'Không khoá'),
		  ('012D35DA-6F9F-477B-B6D9-4D3190AC539F', '499A28F6-67A2-4D2D-B027-183058A07646', N'S322B Quốc lộ 62 P6', 'EF349D02-B36F-4BB5-B52E-152454BF2454', N'Không khoá'),
		  ('7B1C2C92-4C07-46E1-A5E5-644A766F023E', '739E7B3F-D6B8-4C48-81B4-487B75589E80', N'92A Tán Kế P3', '00FEDBBC-6BBA-4BB7-80B8-66A5E3AFF7CC', N'Không khoá'),
		  ('447076CA-E76C-4CF6-A55E-62C68F6B18E9', '9D042E88-B462-4811-9FED-4CC6A1C7A3AC', N'49 Cách Mạng Tháng Tám P3', '00FEDBBC-6BBA-4BB7-80B8-66A5E3AFF7CC', N'Không khoá'),
		  ('38E1D107-A4E9-4C6C-AB50-3B4DFA5573D4', '1A31055B-A4BB-4BD7-81AB-1792CEB4B080', N'466C5 Nguyễn Huệ P.Phú Khương', '00FEDBBC-6BBA-4BB7-80B8-66A5E3AFF7CC', N'Không khoá'),
		  ('9B71D7CA-08F7-403B-BA95-38D2E4BDE140', '0C2F1A1B-6412-4FE2-B229-5FCE555349FC', N'236 Phó Cơ Điều P6 Q11', '1D683773-5757-4C4E-BE2B-5537B5F567BD', N'Không khoá'),
		  ('DF75434B-4CB4-4515-9A44-FB8239CA6AD7', '0C2F1A1B-6412-4FE2-B229-5FCE555349FC', N'440 Trần Văn Đang P10 Q3', '1D683773-5757-4C4E-BE2B-5537B5F567BD', N'Không khoá'),
		  ('C7120B3E-B986-4A98-AACF-36CF83D124C7', '1FFCCD2B-D22D-4F01-8E5B-2CA3B690D5D7', N'289 Lãnh Binh Thăng P8 Q11', '1D683773-5757-4C4E-BE2B-5537B5F567BD', N'Không khoá'),
		  ('700FC48E-6033-440F-9DFE-4D7A137A1251', '7C24DC80-B487-40D2-A656-B6358962BBF5', N'220 Nguyễn Tri Phương Q.Thanh Khê', '005A59B7-3812-4B23-B154-D8894AB92905', N'Không khoá'),
		  ('32D3A808-0F76-473F-8BE0-80BCC6489DA5', '1D154C23-D7F1-47C6-8E3A-4CA13CBC837D', N'39 Núi Thành Q.Hải Châu', '005A59B7-3812-4B23-B154-D8894AB92905', N'Không khoá'),
		  ('424C7F44-CAC8-4228-93EF-A7B0FC80E058', 'EA550E6B-34F1-45F7-BEAB-52435507FD03', N'38 Trần Cao Vân', 'AD60B8AA-732B-4546-9EB1-0E0E565D3417', N'Không khoá'),
		  ('F0A0BEC1-F0EF-41AD-9311-57CF95177F33', '5FED6DA6-45E0-4825-8B03-689E30C5EC17', N'80 Mai Thúc Loan, Thuận Lộc', 'AD60B8AA-732B-4546-9EB1-0E0E565D3417', N'Không khoá'),
		  ('752E8997-23E9-4DC4-8529-5FBC68066895', '87186AF2-0D45-4ACD-898D-D799728C08AE', N'482 Hồng Bàng P6 Q6', '1D683773-5757-4C4E-BE2B-5537B5F567BD', N'Không khoá'),
		  ('8D644CFB-1075-4895-AA04-4EC46EA6B786', '8634C513-90FB-4DB7-9E80-F8278ECDEF68', N'56 Bành Văn Trân P7 Q.Tân Bình', '1D683773-5757-4C4E-BE2B-5537B5F567BD', N'Không khoá')

INSERT INTO GiaShip
	VALUES('1BF4BA79-1047-40CE-8E46-A8309E249912',N'Nội Thành',10000,GETDATE()),
	      ('B54D15BF-12D2-4223-9C36-A4AD02AC923B',N'Ngoại Thành',20000,GETDATE())

INSERT INTO HangSanPham
	VALUES('5D85DE48-9D68-4F79-A951-24201CF7D4D4','H-1',N'Adidas',N'Không khoá'),
		  ('545DD2D2-E2C6-4DC3-A728-460E596E61B1','H-2',N'Nike',N'Không khoá'),
		  ('DE7797B9-028B-4DF7-A6B0-5E10A45E0608','H-3',N'Converse',N'Không khoá'),
		  ('41505B64-32C5-4CC7-8791-4CF6EE5788E8','H-4',N'Vans',N'Không khoá'),
		  ('C35D6991-9D6F-482E-9AC2-F6DA6A70D2D5','H-5',N'No brand',N'Không khoá')

INSERT INTO SanPham
	VALUES ('B77D9CF5-E9A2-4D31-9490-25E4E3971C61','G-1',N'Supernova Aktiv Da9657','18D79B1D-EE48-459A-AD1D-09A05A4773AD',N'Đen','5D85DE48-9D68-4F79-A951-24201CF7D4D4',N'Nam',2380000,N'56519.jpg',N'Làm bằng vải, cao su','', GETDATE(),N'Không khoá'),
		   ('8BF0E51F-1C56-4033-A3D2-88B6D9FE2AA6','G-3',N'Adidas NMD R1 OG','18D79B1D-EE48-459A-AD1D-09A05A4773AD',N'Đen Xanh Đỏ','5D85DE48-9D68-4F79-A951-24201CF7D4D4',N'Nam',6800000,N'adidas_nmd_r1og.jpg','','', GETDATE(),N'Không khoá'),
		   ('51889068-C03B-4C21-A5DE-60F94775F5E8','G-4',N'Supreme x Vans Sk8-Mid Pro','18D79B1D-EE48-459A-AD1D-09A05A4773AD',N'Vàng nâu','41505B64-32C5-4CC7-8791-4CF6EE5788E8',N'Nam',5000000,N'vans-supreme-leopard.jpg','','', GETDATE(),N'Không khoá'),
		   ('EE9FB193-E170-4675-949A-211BB4BA1D6A','G-5',N'Converse Chuck Taylor','18D79B1D-EE48-459A-AD1D-09A05A4773AD',N'Đen','DE7797B9-028B-4DF7-A6B0-5E10A45E0608',N'Nữ',1788000,N'converse_chuck_taylor_allstar.jpg','',10, GETDATE(),N'Không khoá'),
		   ('0D60B157-20D6-4CD3-BAF8-92D346FBD47E','G-6',N'Adidas NMD R2','CA2EE7E2-7F64-4A5A-A49B-E22E9E05F053',N'Trắng','5D85DE48-9D68-4F79-A951-24201CF7D4D4',N'Nữ',2600000,N'adidas_nmd_r2.jpg','','', GETDATE(),N'Không khoá'),
		   ('CDA692F1-8559-454D-8702-E89D06CBA617','G-7',N'Converse Chuck Taylor All Star Dainty Holiday Scene Seasonal Canvas','18D79B1D-EE48-459A-AD1D-09A05A4773AD',N'Trắng','DE7797B9-028B-4DF7-A6B0-5E10A45E0608',N'Nữ',1200000,N'chuck-taylor-all-star-dainty-holiday-scene-seasonal-canvas.jpg',N'','', GETDATE(),N'Không khoá'),
		   ('3014E623-489E-4258-8B49-B3583107347F','G-8',N'Converse Chuck Taylor All Star Shoreline Wonderland','CA2EE7E2-7F64-4A5A-A49B-E22E9E05F053',N'Tím','DE7797B9-028B-4DF7-A6B0-5E10A45E0608',N'Nữ',1300000,N'chuck-taylor-all-star-shoreline-wonderland.jpg','','', GETDATE(),N'Không khoá'),
		   ('1949BFBC-D0A7-4B5D-879F-AA4B43067DE0','G-9',N'Converse Chuck Taylor All Star Seasonal Canvas Color','18D79B1D-EE48-459A-AD1D-09A05A4773AD',N'Xanh','DE7797B9-028B-4DF7-A6B0-5E10A45E0608',N'Nữ',1200000,N'chuck-taylor-all-star-seasonal-canvas-color.jpg','','', GETDATE(),N'Không khoá'),
		   ('DA742174-B221-4FD0-8305-572073C7E045','G-10',N'Converse Chuck Taylor All Star Leather Gator','18D79B1D-EE48-459A-AD1D-09A05A4773AD',N'Kem','DE7797B9-028B-4DF7-A6B0-5E10A45E0608',N'Nữ',1800000,N'chuck-taylor-all-star-leather-gator.jpg','','', GETDATE(),N'Không khoá'),
		   ('6FA36E51-6939-4456-B602-25B9DF0DEA54','G-11',N'Converse Chuck Taylor All Star Seasonal Color','18D79B1D-EE48-459A-AD1D-09A05A4773AD',N'Xanh','DE7797B9-028B-4DF7-A6B0-5E10A45E0608',N'Nữ',1100000,N'chuck-taylor-all-star-seasonal-color.jpg','','', GETDATE(),N'Không khoá'),  
		   ('9B7FB6AD-6A62-41AD-936F-5AE5EFBB4E96','G-12',N'Adidas Ultraboost Shoes','CA2EE7E2-7F64-4A5A-A49B-E22E9E05F053',N'Trắng','5D85DE48-9D68-4F79-A951-24201CF7D4D4',N'Nam',4000000,N'ultraboost-shoes.jpg','','', GETDATE(),N'Không khoá'),
		   ('7DED44CB-C3DA-4701-8051-BCB2BFE57E1D','G-13',N'Adidas Ultraboost Lth Shoes','18D79B1D-EE48-459A-AD1D-09A05A4773AD',N'Xanh','5D85DE48-9D68-4F79-A951-24201CF7D4D4',N'Nam',4500000,N'ultraboost-ltd-shoes.jpg',N'','', GETDATE(),N'Không khoá'),
		   ('0233F0B6-E01D-445B-8064-8EBB798B8B63','G-14',N'Adidas NMD R1 Shoes','CA2EE7E2-7F64-4A5A-A49B-E22E9E05F053',N'Trắng','5D85DE48-9D68-4F79-A951-24201CF7D4D4',N'Nam',2000000,N'superstar-shoes.jpg','','', GETDATE(),N'Không khoá'),
		   ('1E770E9C-A7F6-4829-BC99-2B2C231C2432','G-15',N'Adidas Superstar Shoes','18D79B1D-EE48-459A-AD1D-09A05A4773AD',N'Đen','5D85DE48-9D68-4F79-A951-24201CF7D4D4',N'Nam',3000000,N'nmd-r1-shoes.jpg','','', GETDATE(),N'Không khoá'),
		   ('413BC289-D522-4725-874F-4A276C6E77DB','G-16',N'Vans Old Skool','18D79B1D-EE48-459A-AD1D-09A05A4773AD',N'Kem','41505B64-32C5-4CC7-8791-4CF6EE5788E8',N'Nữ',1400000,N'old-skool.jpg','','', GETDATE(),N'Không khoá'),
		   ('BEB67101-F488-4177-8366-E8C735BB86F2','G-17',N'Vans Primary Check Old Skool','18D79B1D-EE48-459A-AD1D-09A05A4773AD',N'Đen','41505B64-32C5-4CC7-8791-4CF6EE5788E8',N'Nam',1400000,N'primary-check-old-skool.jpg','',10, GETDATE(),N'Không khoá'),
		   ('19AB2F52-E016-4F1E-85D4-786533782B01','G-18',N'Vans Authentic','CA2EE7E2-7F64-4A5A-A49B-E22E9E05F053',N'Tím','41505B64-32C5-4CC7-8791-4CF6EE5788E8',N'Nữ',1200000,N'authentic.jpg','','', GETDATE(),N'Không khoá'),
		   ('81D3E3F0-A94C-4069-9A0F-A94154657349','G-19',N'Converse X Hello Kitty Chuck Taylor All Star Canvas Low Top','1A31055B-A4BB-4BD7-81AB-1792CEB4B080',N'Đen','DE7797B9-028B-4DF7-A6B0-5E10A45E0608',N'Nữ',1600000,N'converse-x-hello-kitty-chuck-taylor-all-star-canvas-low-top.jpg','','', GETDATE(),N'Không khoá'),
		   ('4DBF0115-F61B-48C4-92C0-050293D0779A','G-20',N'Converse X Hello Kitty Chuck Taylor All Star Canvas High Top','1A31055B-A4BB-4BD7-81AB-1792CEB4B080',N'Trắng','DE7797B9-028B-4DF7-A6B0-5E10A45E0608',N'Nữ',1700000,N'converse-x-hello-kitty-chuck-taylor-all-star-canvas-high-top.jpg','','', GETDATE(),N'Không khoá'),
		   ('3C811136-99D5-4F17-AE13-D6DBA8B89121','G-21',N'Converse Chuck Taylor All Star Ombre Wash','1A31055B-A4BB-4BD7-81AB-1792CEB4B080',N'Xanh','DE7797B9-028B-4DF7-A6B0-5E10A45E0608',N'Nữ',1300000,N'chuck-taylor-all-star-ombre-wash.jpg','','', GETDATE(),N'Không khoá'),
		   ('2123AE43-CFC7-4F3E-A8B0-4150BE4A8647','G-22',N'Converse Chuck Taylor All Star Mono Suede','1A31055B-A4BB-4BD7-81AB-1792CEB4B080',N'Đỏ','DE7797B9-028B-4DF7-A6B0-5E10A45E0608',N'Nữ',1500000,N'chuck-taylor-all-star-mono-suede.jpg','','', GETDATE(),N'Không khoá'),
		   ('2E3831FD-71A3-4A21-B635-E674ED0533AF','G-23',N'Converse Chuck Taylor All Star Perf Canvas','1A31055B-A4BB-4BD7-81AB-1792CEB4B080',N'Xám xanh','DE7797B9-028B-4DF7-A6B0-5E10A45E0608',N'Nữ',1200000,N'chuck-taylor-all-star-perf-canvas.jpg','','', GETDATE(),N'Không khoá'),
		   ('98ABFB8C-5CA6-4EA4-A8A7-8BCABB34198A','G-24',N'Converse Chuck Taylor All Star Mono Glam','1A31055B-A4BB-4BD7-81AB-1792CEB4B080',N'Xanh','DE7797B9-028B-4DF7-A6B0-5E10A45E0608',N'Nữ',1200000,N'chuck-taylor-all-star-mono-glam.jpg','','', GETDATE(),N'Không khoá'),
		   ('03407BDD-CD07-42B6-8F74-D26F8B00A30E','G-25',N'Converse Chuck Taylor All Star Leather & Thermal','1A31055B-A4BB-4BD7-81AB-1792CEB4B080',N'Xám xanh','DE7797B9-028B-4DF7-A6B0-5E10A45E0608',N'Nữ',1600000,N'chuck-taylor-all-star-leather--thermal.jpg','','', GETDATE(),N'Không khoá'),
		   ('DDB53D71-1FB7-41FE-97C8-FFA6EEF17337','G-26',N'Converse Chuck Taylor All Star Coral Animal Metallic','1A31055B-A4BB-4BD7-81AB-1792CEB4B080',N'Trắng/Vàng','DE7797B9-028B-4DF7-A6B0-5E10A45E0608',N'Nữ',1200000,N'chuck-taylor-all-star-coral-animal-metallic.jpg','','', GETDATE(),N'Không khoá'),
		   ('F5FA3C92-F0E7-4A8F-B498-773647707B60','G-27',N'Converse Chuck Taylor All Star Gemma Festival Poly Knit','1A31055B-A4BB-4BD7-81AB-1792CEB4B080',N'Trắng/Xanh','DE7797B9-028B-4DF7-A6B0-5E10A45E0608',N'Nữ',1200000,N'chuck-taylor-all-star-gemma-festival-poly-knit.jpg','','', GETDATE(),N'Không khoá'),
		   ('FF1DD7BD-CA33-447E-AEE3-D7BDDB69BBCC','G-28',N'Converse Chuck Taylor All Star Gemma Engineered Lace','1A31055B-A4BB-4BD7-81AB-1792CEB4B080',N'Vàng','DE7797B9-028B-4DF7-A6B0-5E10A45E0608',N'Nữ',1200000,N'chuck-taylor-all-star-gemma-engineered-lace.jpg','','', GETDATE(),N'Không khoá')

INSERT INTO TrangQuangCao
	VALUES ('75523BB6-C366-4A28-A85C-B4C8C1D5747A', 'ADHOME', N'Trang chủ', N'Test',N'Không khoá'),
		   ('15CF8A9B-517E-4BAE-91E2-F30C596990ED', 'ADPROD', N'Sản phẩm', N'Test',N'Không khoá')
		   

INSERT INTO ViTriQuangcao
	VALUES ('5284E840-16E1-4C73-9D00-1ACA5FF4642D', 'VTA1', N'Trang chủ 1','75523BB6-C366-4A28-A85C-B4C8C1D5747A',50000, N'', N'Không khoá'),
		   ('FF517A22-38AE-4584-8447-0A41594EDEC3', 'VTA2', N'Trang chủ 2', '75523BB6-C366-4A28-A85C-B4C8C1D5747A',50000,  N'', N'Không khoá'),
		   ('8C46E232-2EDF-4186-A5EA-901E5ABE0D33', 'VTA3', N'Trang chủ 3', '75523BB6-C366-4A28-A85C-B4C8C1D5747A',50000,  N'',N'Không khoá'),
		   ('0d3ef78f-85cb-41d1-95cf-c17a32f02d4d', 'VTA4', N'Trang chủ 4', '75523BB6-C366-4A28-A85C-B4C8C1D5747A',50000,  N'',N'Không khoá'),
		   ('999edeee-cdc9-4de7-9f5d-40e2d1251dff', 'VTB1', N'Trang chủ 5', '75523BB6-C366-4A28-A85C-B4C8C1D5747A',50000,  N'',N'Không khoá'),
		   ('c6d83caa-19e8-45ae-8984-5fa89155aeab', 'VTB2', N'Trang chủ 6', '75523BB6-C366-4A28-A85C-B4C8C1D5747A',50000,  N'',N'Không khoá'),
		   ('1bf214be-b856-477f-abbe-63ecde20fcde', 'VTC1', N'Sản phẩm 1', '15CF8A9B-517E-4BAE-91E2-F30C596990ED',50000,  N'',N'Không khoá'),
		   ('c2d5834d-7b2e-4eab-983e-f6badd8f4784', 'VTC2', N'Sản phẩm 2', '15CF8A9B-517E-4BAE-91E2-F30C596990ED',50000,  N'',N'Không khoá'),
		   ('6cc7287c-c09a-4fd1-9174-27dc1a586180', 'VTC3', N'Sản phẩm 3', '15CF8A9B-517E-4BAE-91E2-F30C596990ED',50000,  N'',N'Không khoá')

INSERT INTO GoiQuangCao
	VALUES('8804015b-62f8-46ed-b2bd-e662a1730381','GHOME11', '5284E840-16E1-4C73-9D00-1ACA5FF4642D',50000,1,N'Không khoá'),
		  ('66f36fc5-8d06-4d5e-ab8b-76d46c935ca6','GHOME14', '5284E840-16E1-4C73-9D00-1ACA5FF4642D',200000,4,N'Không khoá'),
		  ('5a884b7e-b5aa-461b-8af2-5c15fe236a09','GHOME21', 'FF517A22-38AE-4584-8447-0A41594EDEC3',50000,1,N'Không khoá'),
		  ('11c1c08f-bcf0-45ca-af9c-9d54e391e7e8','GHOME31', '8C46E232-2EDF-4186-A5EA-901E5ABE0D33',50000,1,N'Không khoá'),
		  ('41ccb6cf-6c8d-4455-a963-04c104664788','GHOME41', '0d3ef78f-85cb-41d1-95cf-c17a32f02d4d',50000,1,N'Không khoá'),
		  ('6786f5f0-02f8-4498-aeaa-43b9a0fcbc69','GHOME51', '999edeee-cdc9-4de7-9f5d-40e2d1251dff',50000,1,N'Không khoá'),
		  ('5fb84781-9d6f-4c69-a6a8-51ff6e2ba189','GHOME61', 'c6d83caa-19e8-45ae-8984-5fa89155aeab',50000,1,N'Không khoá'),
		  ('ffb3bfea-74ae-420d-9295-46ea9d71c54c','GPROD11', '1bf214be-b856-477f-abbe-63ecde20fcde',50000,1,N'Không khoá'),
		  ('ffe27b9a-eb37-4a59-88d2-6013fc577592','GPROD21', 'c2d5834d-7b2e-4eab-983e-f6badd8f4784',50000,1,N'Không khoá'),
		  ('4182d5c0-7e5b-4bce-a286-0367bd55a77b','GPROD31', '6cc7287c-c09a-4fd1-9174-27dc1a586180',50000,1,N'Không khoá')

INSERT INTO QuangCao
	VALUES ('51791099-c591-436f-aa87-6e9d860378ac','QC1','8804015b-62f8-46ed-b2bd-e662a1730381','18D79B1D-EE48-459A-AD1D-09A05A4773AD','1.jpg','2018-12-15','2018-12-22','google.com.vn','',N'Không khoá'),
		   ('14329aca-9c43-4736-94bf-e420778a17f0','QC2','8804015b-62f8-46ed-b2bd-e662a1730381','18D79B1D-EE48-459A-AD1D-09A05A4773AD','2.jpg','2018-12-22','2018-12-29','google.com.vn','',N'Không khoá'),
		   ('4729efc3-db86-4669-8171-4ddf0fe11a80','QC3','5a884b7e-b5aa-461b-8af2-5c15fe236a09','18D79B1D-EE48-459A-AD1D-09A05A4773AD','3.jpg','2018-12-15','2018-12-22','google.com.vn','',N'Không khoá'),
		   ('d4c02c5e-6c92-47b8-bab7-ab5f9fc4d6b0','QC4','5a884b7e-b5aa-461b-8af2-5c15fe236a09','18D79B1D-EE48-459A-AD1D-09A05A4773AD','4.jpg','2018-12-22','2018-12-29','google.com.vn','',N'Không khoá'),
		   ('9b43bedf-e4a2-4416-aede-04a18299db8f','QC5','11c1c08f-bcf0-45ca-af9c-9d54e391e7e8','18D79B1D-EE48-459A-AD1D-09A05A4773AD','5.jpg','2018-12-15','2018-12-22','google.com.vn','',N'Không khoá'),
		   ('f27012be-bc38-4f3b-857f-92f5430b37be','QC6','41ccb6cf-6c8d-4455-a963-04c104664788','18D79B1D-EE48-459A-AD1D-09A05A4773AD','6.png','2018-12-15','2018-12-22','google.com.vn','',N'Không khoá'),
		   ('9ae76878-fdfe-4e8f-9102-96ff42342f19','QC7','ffb3bfea-74ae-420d-9295-46ea9d71c54c','18D79B1D-EE48-459A-AD1D-09A05A4773AD','7.jpg','2018-12-15','2018-12-22','google.com.vn','',N'Không khoá'),
		   ('ffefce9d-6c07-4e92-b0ce-f193468bbec6','QC8','ffe27b9a-eb37-4a59-88d2-6013fc577592','18D79B1D-EE48-459A-AD1D-09A05A4773AD','8.jpg','2018-12-15','2018-12-22','google.com.vn','',N'Không khoá')
GO


--Update số lượng để thử cho đơn hàng--
UPDATE SizeSanPham
SET SoLuong = 20
GO

--FUNCTION--
CREATE FUNCTION daysinmonth(@month int, @year int) 
returns table
as 
return (WITH N(N)AS 
(SELECT 1 FROM(VALUES(1),(1),(1),(1),(1),(1))M(N)),
tally(N)AS(SELECT ROW_NUMBER()OVER(ORDER BY N.N)FROM N,N a)
SELECT N day,datefromparts(@year,@month,N) dates FROM tally
WHERE N <= day(EOMONTH(datefromparts(@year,@month,1))))
GO

		select * from [dbo].[daysinmonth](12,2016)
GO

CREATE FUNCTION ngaythichhop(@month int,@year int,@idgoi uniqueidentifier)
returns table
as

return (
Select day from [dbo].[daysinmonth](@month,@year)
where (((select count(*) from QuangCao where IdGoiQuangCao IN (Select ID from GoiQuangCao where IdVitri = (Select IdViTri from GoiQuangCao where Id=@idgoi))  AND tinhtrang=N'Không khoá' AND ngaybatdau >= dates And Ngaybatdau < (Select DATEADD(day,((Select thoiluong from GoiQuangCao where @idgoi=Id)*7),dates)))=0)
AND ( (select count(*) from QuangCao where IdGoiQuangCao IN (Select ID from GoiQuangCao where IdVitri = (Select IdViTri from GoiQuangCao where Id=@idgoi)) AND tinhtrang=N'Không khoá' AND ngayketthuc > dates  And ngayketthuc <= (Select DATEADD(day,((Select thoiluong from GoiQuangCao where @idgoi=Id)*7),dates)))=0)
AND NOT ((Select top 1 ngaybatdau from QuangCao where IdGoiQuangCao IN (Select ID from GoiQuangCao where IdVitri = (Select IdViTri from GoiQuangCao where Id=@idgoi)) AND tinhtrang=N'Không khoá' AND ngaybatdau<dates  order by NgayBatDau DESC) > (Select top 1 ngayketthuc from QuangCao where IdGoiQuangCao IN (Select ID from GoiQuangCao where IdVitri = (Select IdViTri from GoiQuangCao where Id=@idgoi)) AND tinhtrang=N'Không khoá' AND ngayketthuc <=dates  order by NgayKetThuc DESC))
OR (Select count(*) from QuangCao where tinhtrang=N'Không khoá' AND IdGoiQuangCao IN (Select ID from GoiQuangCao where IdVitri = (Select IdViTri from GoiQuangCao where Id=@idgoi)) ) = 0) AND day>=DAY(GETDATE()))
GO