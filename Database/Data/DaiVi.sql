USE QLBanGiay
GO
--
INSERT INTO TrangQuangCao
	VALUES ('75523BB6-C366-4A28-A85C-B4C8C1D5747A', 'ADHOME', N'Trang chủ', N'Test',N'Không khoá'),
		   ('15CF8A9B-517E-4BAE-91E2-F30C596990ED', 'ADPROD', N'Sản phẩm', N'Test',N'Không khoá')
		   
GO
		   

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
		   

GO

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

GO 


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




		   
GO

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



Select * from ngaythichhop(12,2018,'8804015B-62F8-46ED-B2BD-E662A1730381')
GO
Select * from ngaythichhop(12,2018,'66f36fc5-8d06-4d5e-ab8b-76d46c935ca6')
GO
Select * from ngaythichhop(12,2018,'973EDA9D-665D-4D15-9BBC-E35EF4E4C46C')
GO
Select * from ViTriQuangcao
GO
Select * from GoiQuangCao
GO
Select * from QuangCao where tinhtrang=N'Không khoá' AND MaQuangCao='QC-2001'
GO
	

Select  GoiQuangCao.ID from GoiQuangCao,QuangCao where IdVitri = '5284E840-16E1-4C73-9D00-1ACA5FF4642D' and IdGoiQuangCao=GoiQuangCao.id
Select ID from GoiQuangCao where IdVitri = (Select IdViTri from GoiQuangCao where Id= '66f36fc5-8d06-4d5e-ab8b-76d46c935ca6')