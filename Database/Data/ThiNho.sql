use QLBanGiay
---
select * from TaiKhoan
select * from LoaiNguoiDung
---khuyen mai---
insert into KhuyenMai
Values ('D557D8F9-198B-4CE9-AED4-9F50B09655A1','KM-1','11/20/2018','11/25/2018','0.3',N'Giảm giá ngày Black Friday',N'Không khoá'),
		('C41FF664-9A1A-4C97-81BF-393934943087','KM-2','12/25/2018','12/30/2018','0.15',N'Giáng sinh',N'Không khoá'),
		('B2E98470-120B-4261-B95C-4716DDE7EDAD','KM-3','01/25/2019','02/03/2019','0.2',N'Tết nguyên đán',N'Không khoá')

----San pham---
insert into SanPham
Values ('B77D9CF5-E9A2-4D31-9490-25E4E3971C61','G-1',N'Supernova Aktiv Da9657','18D79B1D-EE48-459A-AD1D-09A05A4773AD',40,N'Đen',N'Adidas',N'Nam','2.380.000' ,20,N'giayadidas_supernova_aktiv_Da9657.png',N'Làm bằng vải, cao su','',N'Còn hàng'),
		('B77D9CF5-E9A2-4D31-9490-25E4E3971C61','G-2',N'Supernova Aktiv Da9657','CA2EE7E2-7F64-4A5A-A49B-E22E9E05F053',40,N'Đen',N'Adidas',N'Nam','2.380.000' ,20,N'giayadidas_supernova_aktiv_Da9657.png','','',N'Còn hàng'),
		('8BF0E51F-1C56-4033-A3D2-88B6D9FE2AA6','G-3',N'Adidas NMD R1 OG','18D79B1D-EE48-459A-AD1D-09A05A4773AD',41,N'Đen Xanh Đỏ',N'Adidas',N'Nam','6.800.000',10,N'adidas_nmd_r1 og.jpg','','',N'Không khoá'),
		('51889068-C03B-4C21-A5DE-60F94775F5E8','G-4',N'Supreme x Vans Sk8-Mid Pro','18D79B1D-EE48-459A-AD1D-09A05A4773AD',42,N'Vàng nâu',N'Vans',N'Nam','5.000.000',10,N'vans-supreme-leopard.jpg','','',N'Còn hàng'),
		('EE9FB193-E170-4675-949A-211BB4BA1D6A','G-5',N'Converse Chuck Taylor','18D79B1D-EE48-459A-AD1D-09A05A4773AD',36,N'Đen',N'Converse',N'Nữ','1.788.000',20,N'converse_chuck_taylor_allstar.jpg','','0.1',N'Còn hàng'),
		('0D60B157-20D6-4CD3-BAF8-92D346FBD47E','G-6',N'Adidas NMD R2','CA2EE7E2-7F64-4A5A-A49B-E22E9E05F053',37,N'Trắng',N'Adidas',N'Nữ','2.600.000',20,N'adidas_nmd_r2.jpg','','',N'Còn hàng')