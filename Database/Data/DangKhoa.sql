﻿	use QLBanGiay
	
	insert into GiaShip (Id,Loai,Gia,NgayCapNhat)
	values
		  ('1BF4BA79-1047-40CE-8E46-A8309E249912',N'Nội Thành',100000,'20180101'),
	      ('B54D15BF-12D2-4223-9C36-A4AD02AC923B',N'Ngoại Thành',20000,'20180101')

insert into DonHang(Id,MaDonHang,CMNDNguoiGiao,IDTaiKhoan,DiaChiGiao,NgayTao,NgayGiao,TongTien,TinhTrangDanhGiaCustomer,TinhTrang)
	values ('BC3C50BF-71CD-42C6-AEB4-9D95C6A8FD45','DH-001',N'12345678901','18D79B1D-EE48-459A-AD1D-09A05A4773AD',N'173 An Dương Vương','20181204','20181205',80000,N'Đã đánh giá',N'Đã thanh toán'),
		   ('05EC67CF-66A0-40DA-8B3E-018BEB5E33F2','DH-002',N'12345678902','499A28F6-67A2-4D2D-B027-183058A07646',N'174 An Dương Vương','20181204','20181205',80000,N'Đã đánh giá',N'Đã thanh toán'),
		   ('D0EDC844-B44A-4EB5-A532-A89258022B17','DH-003',N'12345678903','739E7B3F-D6B8-4C48-81B4-487B75589E80',N'175 An Dương Vương','20181104','20181105',60000,N'Đã đánh giá',N'Đã thanh toán'),
		   ('85560A4D-067A-406A-ADD4-1BC0943FF435','DH-004',N'12345678904','9D042E88-B462-4811-9FED-4CC6A1C7A3AC',N'176 An Dương Vương','20181004','20181005',120000,N'Đã đánh giá',N'Đã thanh toán'),
		   ('A95F8B77-9D4D-4557-960E-314F95C98E5B','DH-005',N'12345678908','9D042E88-B462-4811-9FED-4CC6A1C7A3AC',N'176 An Dương Vương','20181020','20181021',670000,N'Đã đánh giá',N'Đã thanh toán'),
		   ('0D10B0E2-109F-472F-AE84-2AB999FB5C2A','DH-006',N'12345678904','9D042E88-B462-4811-9FED-4CC6A1C7A3AC',N'176 An Dương Vương','20180802','20180805',120000,N'Đã đánh giá',N'Đã thanh toán'),
		   ('A1400367-1450-491D-A618-1A1769DE0198','DH-007',N'12345678908','9D042E88-B462-4811-9FED-4CC6A1C7A3AC',N'176 An Dương Vương','20180910','20180915',900000,N'Đã đánh giá',N'Đã thanh toán'),
		   ('891E3F2B-DE2D-4EFF-BE05-2B567ECFD522','DH-008',N'12345678908','9D042E88-B462-4811-9FED-4CC6A1C7A3AC',N'176 An Dương Vương','20181201','20181201',490000,N'Đã đánh giá',N'Đã thanh toán')	
		   
		   
		   
		   
			
		   where Ngay
select NgayGiao,TongTien
select * from DonHang

group by Month(Ngay)

select * from DonHang -> Id -> TaiKhoan

select * from TaiKhoan

select * from ChiTietDonHang('DH-006',40,1)

		   ('0D10B0E2-109F-472F-AE84-2AB999FB5C2A','DH-006',N'12345678904','9D042E88-B462-4811-9FED-4CC6A1C7A3AC',N'176 An Dương Vương','20180802','20180805',120000,N'Đã đánh giá',N'Đã thanh toán'),

		   select * from SizeSanPham

		   select* from ChiTietDonHang where IdDonHang=

		   select count(Id) 
		   from DonHang 
		   where TinhTrang !=N'Đã thanh toán'