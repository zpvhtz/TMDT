	use QLBanGiay
	
	insert into GiaShip (Id,Loai,Gia,NgayCapNhat)
	values
		  ('1BF4BA79-1047-40CE-8E46-A8309E249912',N'Nội Thành',100000,'20180101'),
	      ('B54D15BF-12D2-4223-9C36-A4AD02AC923B',N'Ngoại Thành',20000,'20180101')

insert into PhieuGiao (Id,MaPhieuGiao,CMNDGiao,IdTaiKhoan,DiaChi,NgayTao,NgayGiao,TongTien,TinhTrang)
	values ('BC3C50BF-71CD-42C6-AEB4-9D95C6A8FD45','001',N'12345678901','18D79B1D-EE48-459A-AD1D-09A05A4773AD',N'173 An Dương Vương','20181204','20181205',80000,N'Đã Giao'),
		   ('05EC67CF-66A0-40DA-8B3E-018BEB5E33F2','002',N'12345678902','499A28F6-67A2-4D2D-B027-183058A07646',N'174 An Dương Vương','20181204','20181205',80000,N'Đã Giao'),
		   ('D0EDC844-B44A-4EB5-A532-A89258022B17','003',N'12345678903','739E7B3F-D6B8-4C48-81B4-487B75589E80',N'175 An Dương Vương','20181104','20181105',60000,N'Đã Giao'),
		   ('85560A4D-067A-406A-ADD4-1BC0943FF435','004',N'12345678904','9D042E88-B462-4811-9FED-4CC6A1C7A3AC',N'176 An Dương Vương','20181004','20181005',120000,N'Đã Giao'),
		   ('A95F8B77-9D4D-4557-960E-314F95C98E5B','005',N'12345678908','9D042E88-B462-4811-9FED-4CC6A1C7A3AC',N'176 An Dương Vương','20181020','20181021',670000,N'Đã Giao'),
		   ('0D10B0E2-109F-472F-AE84-2AB999FB5C2A','006',N'12345678904','9D042E88-B462-4811-9FED-4CC6A1C7A3AC',N'176 An Dương Vương','20180802','20180805',120000,N'Đã Giao'),
		   ('A1400367-1450-491D-A618-1A1769DE0198','007',N'12345678908','9D042E88-B462-4811-9FED-4CC6A1C7A3AC',N'176 An Dương Vương','20180910','20180915',900000,N'Đã Giao'),
		   ('891E3F2B-DE2D-4EFF-BE05-2B567ECFD522','008',N'12345678908','9D042E88-B462-4811-9FED-4CC6A1C7A3AC',N'176 An Dương Vương','20181201','20181201',490000,N'Đã Giao')			   	

delete from PhieuGiao
select * from PhieuGiao
select * from TaiKhoan

create Procedure ThongKe_DoanhThu_Merchant (@NgayBatDau datetime , @NgayKetThuc datetime)
AS
BEGIN
	select /*IdTaiKhoan,*/MONTH(NgayGiao) as N'Thang', YEAR(NgayGiao) as 'Nam',COUNT(PhieuGiao.Id) as 'SoLuongBill', SUM(TongTien) AS 'ThuNhap'
	FROM PhieuGiao,TaiKhoan,LoaiNguoiDung
	where PhieuGiao.IdTaiKhoan=TaiKhoan.Id and TaiKhoan.IdLoaiNguoiDung= LoaiNguoiDung.Id and LoaiNguoiDung.MaLoaiNguoiDung='USR-MER' and
		  PhieuGiao.TinhTrang = N'Đã Giao' and (MONTH(NgayGiao) between MONTH(@NgayBatDau) and MONTH(@NgayKetThuc)) and (YEAR(NgayGiao) between YEAR(@NgayBatDau) and YEAR(@NgayKetThuc))
	group by /*IdTaiKhoan,*/ MONTH(NgayGiao), YEAR(NgayGiao)
END
GO

exec ThongKe_DoanhThu_Merchant '20180701', '20181201'
select * from SanPham

select TenLoaiNguoiDung, count(TaiKhoan.Id) as SoLuong
from TaiKhoan, LoaiNguoiDung
where LoaiNguoiDung.Id = TaiKhoan.IdLoaiNguoiDung
group by (TenLoaiNguoiDung)

select * from QuangCao

select Month(NgayBatDau),Year(NgayBatDau), count(QuangCao.Id),Sum(TongTien)
from QuangCao,GoiQuangCao
where QuangCao.IdGoiQuangCao = GoiQuangCao.Id and QuangCao.TinhTrang != N'Sai dữ liệu'
group by MONTH(NgayBatDau), Year(NgayBatDau)


select Month(NgayBatDau),Year(NgayBatDau), count(GianHang.Id),Sum(Gia)
from GianHang,LichSuGianHang
where GianHang.Id = LichSuGianHang.IdGianHang 
group by MONTH(NgayBatDau), Year(NgayBatDau)




