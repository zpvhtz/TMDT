﻿USE QLBanGiay
GO
--
INSERT INTO LoaiNguoiDung
	VALUES ('75523BB6-C366-4A28-A85C-B4C8C1D5747A', 'USR-WMT', N'Webmaster'),
		   ('15CF8A9B-517E-4BAE-91E2-F30C596990ED', 'USR-CUS', N'Khách hàng'),
		   ('EA9FC9A5-9C26-40A4-9E8E-BB3DAE4E0156', 'USR-MER', N'Thương nhân')

INSERT INTO TaiKhoan
	VALUES('CA2EE7E2-7F64-4A5A-A49B-E22E9E05F053', 'merchant1', 'F98919752BF9BFB31E539A1FE663FD68', 'hieu.trung.030197@gmail.com', N'Hiếu Trung', '09354268754', '654238415', 'EA9FC9A5-9C26-40A4-9E8E-BB3DAE4E0156', GETDATE(), 0, N'Không khoá'),
	      ('18D79B1D-EE48-459A-AD1D-09A05A4773AD', 'merchant2', '8B550A0CA911A53B1C6FC398C7828F40', 'tnngo.97@gmail.com', N'Thị Nho', '09345123654', '356984126', 'EA9FC9A5-9C26-40A4-9E8E-BB3DAE4E0156', GETDATE(), 0, N'Không khoá'),
		  ('499A28F6-67A2-4D2D-B027-183058A07646', 'merchant3', '3E99AD8EE3FBCBFA3D369D7FB0B0EA89', 'merchant03@gmail.com', N'Thanh Thảo', '0935426714', '657135426', 'EA9FC9A5-9C26-40A4-9E8E-BB3DAE4E0156', GETDATE(), 0, N'Không khoá'),
		  ('739E7B3F-D6B8-4C48-81B4-487B75589E80', 'merchant4', 'DBB63DEE74EAD9034DEFD63D91D197E9', 'merchant04@gmail.com', N'Bá Đông', '0936582613', '958743265', 'EA9FC9A5-9C26-40A4-9E8E-BB3DAE4E0156', GETDATE(), 0, N'Không khoá'),
		  ('9D042E88-B462-4811-9FED-4CC6A1C7A3AC', 'merchant5', 'B522147E61BA70E1757ADF4988757BCA', 'merchant05@gmail.com', N'Lý Thành', '0934513559', '154786254', 'EA9FC9A5-9C26-40A4-9E8E-BB3DAE4E0156', GETDATE(), 0, N'Không khoá'),
		  ('1A31055B-A4BB-4BD7-81AB-1792CEB4B080', 'merchant6', 'F0277B130FA4966F39FD1986168DC042', 'merchant06@gmail.com', N'Quốc Thắng', '0937423651', '597326549', 'EA9FC9A5-9C26-40A4-9E8E-BB3DAE4E0156', GETDATE(), 0, N'Không khoá'),
		  ('0C2F1A1B-6412-4FE2-B229-5FCE555349FC', 'customer1', 'FFBC4675F864E0E9AAB8BDF7A0437010', 'chunglinhdan@gmail.com', N'Trang Thảo', '0934851349', '954134782', '15CF8A9B-517E-4BAE-91E2-F30C596990ED', GETDATE(), 0, N'Không khoá'),
		  ('1FFCCD2B-D22D-4F01-8E5B-2CA3B690D5D7', 'customer2', '5CE4D191FD14AC85A1469FB8C29B7A7B', 'quachdaivy7@gmail.com', N'Đại Vĩ', '0935684251', '597268451', '15CF8A9B-517E-4BAE-91E2-F30C596990ED', GETDATE(), 0, N'Không khoá'),
		  ('7C24DC80-B487-40D2-A656-B6358962BBF5', 'customer3', '033F7F6121501AE98285AD77F216D5E7', 'customer3@gmail.com', N'Anh Vũ', '0934621574', '684326519', '15CF8A9B-517E-4BAE-91E2-F30C596990ED', GETDATE(), 0, N'Không khoá'),
		  ('1D154C23-D7F1-47C6-8E3A-4CA13CBC837D', 'customer4', '55FEB130BE438E686AD6A80D12DD8F44', 'customer4@gmail.com', N'Kiến Vinh', '0934625795', '132574985', '15CF8A9B-517E-4BAE-91E2-F30C596990ED', GETDATE(), 0, N'Không khoá'),
		  ('EA550E6B-34F1-45F7-BEAB-52435507FD03', 'customer5', '9E8486CDD435BEDA9A60806DD334D964', 'customer5@gmail.com', N'Anh Dũng', '0931652346', '953264158', '15CF8A9B-517E-4BAE-91E2-F30C596990ED', GETDATE(), 0, N'Không khoá'),
		  ('5FED6DA6-45E0-4825-8B03-689E30C5EC17', 'customer6', 'DBAA8BD25E06CC641F5406027C026E8B', 'customer6@gmail.com', N'Minh Bảo', '0934851362', '745632658', '15CF8A9B-517E-4BAE-91E2-F30C596990ED', GETDATE(), 0, N'Không khoá'),
		  ('87186AF2-0D45-4ACD-898D-D799728C08AE', 'admin', '21232F297A57A5A743894A0E4A801FC3', 'feast.pock@gmail.com', N'Thiên Tuấn', '0934816735', '341267458', '75523BB6-C366-4A28-A85C-B4C8C1D5747A', GETDATE(), 0, N'Không khoá'),
		  ('8634C513-90FB-4DB7-9E80-F8278ECDEF68', 'admin2', 'C84258E9C39059A89AB77D846DDAB909', 'admin2@gmail.com', N'Hoàng Tuấn', '0934125436', '6598742365', '75523BB6-C366-4A28-A85C-B4C8C1D5747A', GETDATE(), 0, N'Không khoá')

INSERT INTO DiaChi
	VALUES('A42E13C6-0AAE-469C-B5A1-3ECDDC7767EB', 'CA2EE7E2-7F64-4A5A-A49B-E22E9E05F053', N'209 Trần Phú P4 Q5', '', N'Không khoá'),
		  ('239C76CD-7C6B-4F38-8D1A-22080B75C18C', 'CA2EE7E2-7F64-4A5A-A49B-E22E9E05F053', N'94 Nguyễn Chí Thanh P3 Q10', '', N'Không khoá'),
		  ('CC133D4A-805C-456A-BD6A-F735561DEDA6', '18D79B1D-EE48-459A-AD1D-09A05A4773AD', N'386 Lê Hồng Phong P1 Q10', '', N'Không khoá'),
		  ('9B71D7CA-08F7-403B-BA95-38D2E4BDE140', '0C2F1A1B-6412-4FE2-B229-5FCE555349FC', N'236 Phó Cơ Điều P6 Q11', '', N'Không khoá'),
		  ('C7120B3E-B986-4A98-AACF-36CF83D124C7', '1FFCCD2B-D22D-4F01-8E5B-2CA3B690D5D7', N'289 Lãnh Binh Thăng P8 Q11', '', N'Không khoá'),
		  ('752E8997-23E9-4DC4-8529-5FBC68066895', '87186AF2-0D45-4ACD-898D-D799728C08AE', N'482 Hồng Bàng P6 Q6', '', N'Không khoá')