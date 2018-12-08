use QLBanGiay
---
select * from TaiKhoan
select * from LoaiNguoiDung
select * from HangSanPham
select * from SanPham
select * from SizeSanPham
---khuyen mai---
--insert into KhuyenMai
--Values ('D557D8F9-198B-4CE9-AED4-9F50B09655A1','KM-1','11/20/2018','11/25/2018','0.3',N'Giảm giá ngày Black Friday',N'Không khoá'),
--		('C41FF664-9A1A-4C97-81BF-393934943087','KM-2','12/25/2018','12/30/2018','0.15',N'Giáng sinh',N'Không khoá'),
--		('B2E98470-120B-4261-B95C-4716DDE7EDAD','KM-3','01/25/2019','02/03/2019','0.2',N'Tết nguyên đán',N'Không khoá')

---Hãng sản phẩm---
INSERT INTO HangSanPham
	VALUES ('5D85DE48-9D68-4F79-A951-24201CF7D4D4','H-1',N'Adidas',N'Không khoá'),
		   ('545DD2D2-E2C6-4DC3-A728-460E596E61B1','H-2',N'Nike',N'Không khoá'),
		   ('DE7797B9-028B-4DF7-A6B0-5E10A45E0608','H-3',N'Converse',N'Không khoá'),
		   ('41505B64-32C5-4CC7-8791-4CF6EE5788E8','H-4',N'Vans',N'Không khoá'),
		   ('C35D6991-9D6F-482E-9AC2-F6DA6A70D2D5','H-5',N'No brand',N'Không khoá')
---Size san pham ---
INSERT INTO SizeSanPham
VALUES ('9DB9792B-CA17-4060-8C17-1C398BDFF9A1','B77D9CF5-E9A2-4D31-9490-25E4E3971C61',39,10,N'Không khoá'),
	   ('960BA7B5-EDC6-41A3-9689-EFCAD8C45A48','B77D9CF5-E9A2-4D31-9490-25E4E3971C61',40,5,N'Không khoá'),
	   ('A901122E-4F32-416C-92F9-26DE5D022985','B77D9CF5-E9A2-4D31-9490-25E4E3971C61',41,5,N'Không khoá'),
	   ('A8397480-0235-44EC-9A9C-8B7004DCA206','1BACE5D5-2C2B-41DA-9825-8ABAC7C95E38',41,10,N'Không khoá'),
	   ('D0019043-1336-41E1-B4FD-2BBB31DEA240','1BACE5D5-2C2B-41DA-9825-8ABAC7C95E38',42,10,N'Không khoá'),
	   ('7465CA3A-91C1-4350-A314-8557D54F02BD','8BF0E51F-1C56-4033-A3D2-88B6D9FE2AA6',37,5,N'Không khoá'),
	   ('71F50A50-D64F-4B96-9700-AC7ED4F0282A','8BF0E51F-1C56-4033-A3D2-88B6D9FE2AA6',38,5,N'Không khoá'),
	   ('A6F70D91-C23B-40B6-A1D0-6CE314954E76','51889068-C03B-4C21-A5DE-60F94775F5E8',38,5,N'Không khoá'),
	   ('48624EED-58C3-4F30-9262-911869A36524','51889068-C03B-4C21-A5DE-60F94775F5E8',39,5,N'Không khoá'),
	   ('C4A3F5F0-5281-4AE4-A348-1BC8794F35FF','EE9FB193-E170-4675-949A-211BB4BA1D6A',36,10,N'Không khoá'),
	   ('471D8D5B-377A-4547-8B30-BD903FE48664','EE9FB193-E170-4675-949A-211BB4BA1D6A',37,10,N'Không khoá'),
	   ('07B732E8-E414-4D85-9789-3CF5DEDA30DF','0D60B157-20D6-4CD3-BAF8-92D346FBD47E',37,10,N'Không khoá'),
	   ('60E99C83-381F-4EA7-B497-53CB76097740','0D60B157-20D6-4CD3-BAF8-92D346FBD47E',38,10,N'Không khoá')

----San pham---
INSERT INTO SanPham
VALUES ('B77D9CF5-E9A2-4D31-9490-25E4E3971C61','G-1',N'Supernova Aktiv Da9657','18D79B1D-EE48-459A-AD1D-09A05A4773AD',N'Đen','5D85DE48-9D68-4F79-A951-24201CF7D4D4',N'Nam',2380000,N'56519.jpg',N'Làm bằng vải, cao su','',N'Không khoá'),
	   ('1BACE5D5-2C2B-41DA-9825-8ABAC7C95E38','G-2',N'Supernova Aktiv Da9657','CA2EE7E2-7F64-4A5A-A49B-E22E9E05F053',N'Đen','5D85DE48-9D68-4F79-A951-24201CF7D4D4',N'Nam',2380000,N'56519.jpg','','',N'Không khoá'),
	   ('8BF0E51F-1C56-4033-A3D2-88B6D9FE2AA6','G-3',N'Adidas NMD R1 OG','18D79B1D-EE48-459A-AD1D-09A05A4773AD',N'Đen Xanh Đỏ','5D85DE48-9D68-4F79-A951-24201CF7D4D4',N'Nam',6800000,N'adidas_nmd_r1 og.jpg','','',N'Không khoá'),
	   ('51889068-C03B-4C21-A5DE-60F94775F5E8','G-4',N'Supreme x Vans Sk8-Mid Pro','18D79B1D-EE48-459A-AD1D-09A05A4773AD',N'Vàng nâu','41505B64-32C5-4CC7-8791-4CF6EE5788E8',N'Nam',5000000,N'vans-supreme-leopard.jpg','','',N'Không khoá'),
	   ('EE9FB193-E170-4675-949A-211BB4BA1D6A','G-5',N'Converse Chuck Taylor','18D79B1D-EE48-459A-AD1D-09A05A4773AD',N'Đen','DE7797B9-028B-4DF7-A6B0-5E10A45E0608',N'Nữ',1788000,N'converse_chuck_taylor_allstar.jpg','',10,N'Không khoá'),
	   ('0D60B157-20D6-4CD3-BAF8-92D346FBD47E','G-6',N'Adidas NMD R2','CA2EE7E2-7F64-4A5A-A49B-E22E9E05F053',N'Trắng','5D85DE48-9D68-4F79-A951-24201CF7D4D4',N'Nữ',2600000,N'adidas_nmd_r2.jpg','','',N'Không khoá')\
GO

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

---
select * from SanPham
select IdSanPham,SUM(SoLuong) as SoLuong from SizeSanPham
group by IdSanPham
having SUM(SoLuong)>0
go
---tao pro list con hang, het hang
create proc p_conhang 
as
	select IdSanPham,SUM(SoLuong) as SoLuong from SizeSanPham
	group by IdSanPham
	having SUM(SoLuong)>0
go
---het hang
alter proc p_hethang (@TenDangNhap VARCHAR(20)) 
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

ALTER PROC P_HetHang_Pagging (@TenDangNhap VARCHAR(20), @pageSize INT, @pageNumber INT)
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
ALTER PROC P_HetHang_Search (@TenDangNhap VARCHAR(20), @search NVARCHAR(100), @pageSize INT, @pageNumber INT)
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

ALTER PROC P_HetHang_Search_NotPagging (@TenDangNhap VARCHAR(20), @search NVARCHAR(100))
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

----SELECT MaSanPham, TenSanPham
----FROM SanPham sp JOIN TaiKhoan tk ON sp.IdTaiKhoan = tk.Id
----WHERE tk.TenDangNhap = 'merchant1' AND sp.Id IN
----(
----SELECT IdSanPham
----		FROM SizeSanPham
----		GROUP BY IdSanPham
----		HAVING SUM(SoLuong) = 0
----)

--exec P_HetHang_Search 'merchant1', N'Aktiv', 12, 1

