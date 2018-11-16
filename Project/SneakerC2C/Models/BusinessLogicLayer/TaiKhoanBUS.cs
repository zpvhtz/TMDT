using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.BusinessLogicLayer
{
    public class TaiKhoanBUS
    {
        private readonly QLBanGiayContext context;

        public TaiKhoanBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public TaiKhoanBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        //Mai mốt bỏ qua TinhThanhBUS
        public List<TinhThanh> GetTinhThanhs()
        {
            List<TinhThanh> list = context.TinhThanh.OrderBy(tt => tt.TenTinhThanh).ToList();
            return list;
        }

        public List<TaiKhoan> GetTaiKhoans()
        {
            List<TaiKhoan> list = context.TaiKhoan.Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                                  .Include(l => l.IdLoaiNguoiDungNavigation)
                                                  .ToList();
            return list;
        }

        public List<TaiKhoan> GetTaiKhoans(int pagenumber, int pagesize)
        {
            List<TaiKhoan> list = context.TaiKhoan.Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                                  .OrderBy(l => l.TenDangNhap)
                                                  .Skip((pagenumber - 1) * pagesize)
                                                  .Take(pagesize)
                                                  .Include(l => l.IdLoaiNguoiDungNavigation)
                                                  .ToList();
            return list;
        }

        public string CreateTaiKhoan(string tendangnhap, string matkhau, string ten, string tenshop, string email, string dienthoai, string cmnd, string loainguoidung, string tinhtrang)
        {
            TaiKhoan taikhoan = new TaiKhoan();
            //Kiểm tra
            //Tên đăng nhập
            taikhoan = context.TaiKhoan.Where(tk => tk.TenDangNhap == tendangnhap).SingleOrDefault();
            if(taikhoan != null)
            {
                return "Tài khoản đã tồn tại";
            }
            //Email
            taikhoan = context.TaiKhoan.Where(tk => tk.Email == email).SingleOrDefault();
            if(taikhoan != null)
            {
                return "Email đã tồn tại";
            }
            //CMND
            taikhoan = context.TaiKhoan.Where(tk => tk.Cmnd == cmnd).SingleOrDefault();
            if(taikhoan != null)
            {
                return "CMND đã tồn tại";
            }
            //Thêm
            LoaiNguoiDung lnd = context.LoaiNguoiDung.Where(l => l.Id == Guid.Parse(loainguoidung)).SingleOrDefault();

            taikhoan = new TaiKhoan();
            taikhoan.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            taikhoan.TenDangNhap = tendangnhap;
            taikhoan.MatKhau = CreateMD5(matkhau);
            taikhoan.Ten = ten;
            if (lnd.TenLoaiNguoiDung == "Khách hàng")
                taikhoan.TenShop = "";
            else
                taikhoan.TenShop = tenshop;
            taikhoan.Email = email;
            taikhoan.DienThoai = dienthoai;
            taikhoan.Cmnd = cmnd;
            taikhoan.IdLoaiNguoiDung = Guid.Parse(loainguoidung);
            taikhoan.NgayTao = DateTime.Now;
            taikhoan.DanhGia = 0;
            taikhoan.ThoiHanGianHang = null;
            taikhoan.TinhTrang = tinhtrang;

            context.TaiKhoan.Add(taikhoan);
            context.SaveChanges();

            if (tinhtrang == "Chưa kích hoạt")
                return "Vui lòng kiểm tra hộp thư email để kích hoạt tài khoản";
            else
                return "Thêm thành công";
        }

        public string EditTaiKhoan(string tendangnhap, string matkhau, string email, string dienthoai, string cmnd)
        {
            TaiKhoan taikhoan = new TaiKhoan();
            //Kiểm tra
            //Email
            taikhoan = context.TaiKhoan.Where(tk => tk.Email == email && email != null).SingleOrDefault();
            if(taikhoan != null)
            {
                return "Email đã tồn tại";
            }
            //CMND
            taikhoan = context.TaiKhoan.Where(tk => tk.Cmnd == cmnd && cmnd != null).SingleOrDefault();
            if(taikhoan != null)
            {
                return "CMND đã tồn tại";
            }
            //Sửa
            taikhoan = context.TaiKhoan.Where(tk => tk.TenDangNhap == tendangnhap).SingleOrDefault();
            if (matkhau != null)
            {
                taikhoan.MatKhau = CreateMD5(matkhau);
            }
            if (email != null)
            {
                taikhoan.Email = email;
            }
            if (dienthoai != null)
            {
                taikhoan.DienThoai = dienthoai;
            }
            if (cmnd != null)
            {
                taikhoan.Cmnd = cmnd;
            }
            context.SaveChanges();
            return "Sửa thành công";
        }

        public string LockTaiKhoan(string tendangnhap)
        {
            TaiKhoan taikhoan = context.TaiKhoan.Where(tk => tk.TenDangNhap == tendangnhap).SingleOrDefault();
            taikhoan.TinhTrang = "Khoá";
            context.SaveChanges();
            return "Khoá thành công";
        }

        public string UnlockTaiKhoan(string tendangnhap)
        {
            TaiKhoan taikhoan = context.TaiKhoan.Where(tk => tk.TenDangNhap == tendangnhap).SingleOrDefault();
            taikhoan.TinhTrang = "Không khoá";
            context.SaveChanges();
            return "Mở khoá thành công";
        }

        public TaiKhoan CheckTaiKhoan(string tendangnhap)
        {
            TaiKhoan taikhoan = context.TaiKhoan.Where(tk => tk.TenDangNhap == tendangnhap).SingleOrDefault();
            return taikhoan;
        }

        public TaiKhoan CheckTaiKhoan(string tendangnhap, string matkhau, string loainguoidung)
        {
            string pass = CreateMD5(matkhau);
            TaiKhoan taikhoan = context.TaiKhoan.Where(tk => tk.TenDangNhap == tendangnhap &&
                                                       tk.MatKhau == pass &&
                                                       tk.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung == loainguoidung)
                                                .Include(tk => tk.IdLoaiNguoiDungNavigation)
                                                .SingleOrDefault();
            return taikhoan;
        }

        public TaiKhoan CheckTaiKhoan(string tendangnhap, string email)
        {
            TaiKhoan taikhoan = context.TaiKhoan.Where(tk => tk.TenDangNhap == tendangnhap && tk.Email == email && tk.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                                .Include(tk => tk.IdLoaiNguoiDungNavigation)
                                                .SingleOrDefault();
            return taikhoan;
        }

        public string Activate(string tendangnhap)
        {
            TaiKhoan taikhoan = context.TaiKhoan.Where(tk => tk.TenDangNhap == tendangnhap)
                                                .Include(tk => tk.IdLoaiNguoiDungNavigation)
                                                .SingleOrDefault();
            if(taikhoan.TinhTrang != "Chưa kích hoạt")
            {
                return "Tài khoản đã được kích hoạt";
            }
            if (taikhoan.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung == "Thương nhân")
                taikhoan.TinhTrang = "Chưa xác nhận";
            else
                taikhoan.TinhTrang = "Không khoá";
            context.SaveChanges();

            if (taikhoan.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung == "Thương nhân")
                return "Kích hoạt thành công. Vui lòng chờ tài khoản được duyệt";
            else
                return "Kích hoạt thành công";
        }

        public string ActivateTaiKhoan(string tendangnhap)
        {
            TaiKhoan taikhoan = context.TaiKhoan.Where(tk => tk.TenDangNhap == tendangnhap).SingleOrDefault();
            taikhoan.TinhTrang = "Không khoá";
            context.SaveChanges();
            return "Kích hoạt thành công";
        }

        public List<TaiKhoan> Sort(string sortorder, int pagesize, int pagenumber)
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            switch (sortorder)
            {
                case "tendangnhap-az":
                    list = context.TaiKhoan.Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                           .OrderBy(l => l.TenDangNhap)
                                           .Include(l => l.IdLoaiNguoiDungNavigation)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .ToList();
                    break;
                case "tendangnhap-za":
                    list = context.TaiKhoan.Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                           .OrderByDescending(l => l.TenDangNhap)
                                           .Include(l => l.IdLoaiNguoiDungNavigation)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .ToList();
                    break;
                case "ten-az":
                    list = context.TaiKhoan.Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                           .OrderBy(l => l.Ten)
                                           .Include(l => l.IdLoaiNguoiDungNavigation)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .ToList();
                    break;
                case "ten-za":
                    list = context.TaiKhoan.Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                           .OrderByDescending(l => l.Ten)
                                           .Include(l => l.IdLoaiNguoiDungNavigation)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .ToList();
                    break;
            }
            return list;
        }

        public List<TaiKhoan> Sort(string sortorder)
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            switch (sortorder)
            {
                case "tendangnhap-az":
                    list = context.TaiKhoan.Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                           .OrderBy(l => l.TenDangNhap)
                                           .Include(l => l.IdLoaiNguoiDungNavigation)
                                           .ToList();
                    break;
                case "tendangnhap-za":
                    list = context.TaiKhoan.Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                           .OrderByDescending(l => l.TenDangNhap)
                                           .Include(l => l.IdLoaiNguoiDungNavigation)
                                           .ToList();
                    break;
                case "ten-az":
                    list = context.TaiKhoan.Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                           .OrderBy(l => l.Ten)
                                           .Include(l => l.IdLoaiNguoiDungNavigation)
                                           .ToList();
                    break;
                case "ten-za":
                    list = context.TaiKhoan.Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                           .OrderByDescending(l => l.Ten)
                                           .Include(l => l.IdLoaiNguoiDungNavigation)
                                           .ToList();
                    break;
            }
            return list;
        }

        public List<TaiKhoan> Search(string search, int pagesize, int pagenumber)
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            if (search == null)
            {
                list = GetTaiKhoans(1, pagesize);
            }
            else
            {
                list = context.TaiKhoan.Where(l => l.TenDangNhap.Contains(search) ||
                                                   l.Ten.Contains(search) ||
                                                   l.DienThoai.Contains(search) ||
                                                   l.Email.Contains(search) ||
                                                   l.Cmnd.Contains(search) ||
                                                   l.TinhTrang.Contains(search))
                                       .Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                       .Include(l => l.IdLoaiNguoiDungNavigation)
                                       .Skip((pagenumber - 1) * pagesize)
                                       .Take(pagesize)
                                       .ToList();
            }
            return list;
        }

        public List<TaiKhoan> Search(string search, int pagesize)
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            if (search == null)
            {
                list = GetTaiKhoans(1, pagesize);
            }
            else
            {
                list = context.TaiKhoan.Where(l => l.TenDangNhap.Contains(search) ||
                                                   l.Ten.Contains(search) ||
                                                   l.DienThoai.Contains(search) ||
                                                   l.Email.Contains(search) ||
                                                   l.Cmnd.Contains(search) ||
                                                   l.TinhTrang.Contains(search))
                                       .Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                       .Include(l => l.IdLoaiNguoiDungNavigation)
                                       .ToList();
            }
            return list;
        }

        public List<TaiKhoan> SearchAndSort(string search, string sortorder, int pagesize, int pagenumber)
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            if (search == null)
            {
                list = GetTaiKhoans(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "tendangnhap-az":
                        list = context.TaiKhoan.Where(l => l.TenDangNhap.Contains(search) ||
                                                      l.Ten.Contains(search) ||
                                                      l.DienThoai.Contains(search) ||
                                                      l.Email.Contains(search) ||
                                                      l.Cmnd.Contains(search) ||
                                                      l.TinhTrang.Contains(search))
                                               .Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                               .Include(l => l.IdLoaiNguoiDungNavigation)
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .OrderBy(l => l.TenDangNhap)
                                               .ToList();
                        break;
                    case "tendangnhap-za":
                        list = context.TaiKhoan.Where(l => l.TenDangNhap.Contains(search) ||
                                                      l.Ten.Contains(search) ||
                                                      l.DienThoai.Contains(search) ||
                                                      l.Email.Contains(search) ||
                                                      l.Cmnd.Contains(search) ||
                                                      l.TinhTrang.Contains(search))
                                               .Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                               .Include(l => l.IdLoaiNguoiDungNavigation)
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .OrderByDescending(l => l.TenDangNhap)
                                               .ToList();
                        break;
                    case "ten-az":
                        list = context.TaiKhoan.Where(l => l.TenDangNhap.Contains(search) ||
                                                      l.Ten.Contains(search) ||
                                                      l.DienThoai.Contains(search) ||
                                                      l.Email.Contains(search) ||
                                                      l.Cmnd.Contains(search) ||
                                                      l.TinhTrang.Contains(search))
                                               .Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                               .Include(l => l.IdLoaiNguoiDungNavigation)
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .OrderBy(l => l.Ten)
                                               .ToList();
                        break;
                    case "ten-za":
                        list = context.TaiKhoan.Where(l => l.TenDangNhap.Contains(search) ||
                                                      l.Ten.Contains(search) ||
                                                      l.DienThoai.Contains(search) ||
                                                      l.Email.Contains(search) ||
                                                      l.Cmnd.Contains(search) ||
                                                      l.TinhTrang.Contains(search))
                                               .Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                               .Include(l => l.IdLoaiNguoiDungNavigation)
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .OrderByDescending(l => l.Ten)
                                               .ToList();
                        break;
                }
            }
            return list;
        }

        public List<TaiKhoan> SearchAndSort(string search, string sortorder, int pagesize)
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            if (search == null)
            {
                list = GetTaiKhoans(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "tendangnhap-az":
                        list = context.TaiKhoan.Where(l => l.TenDangNhap.Contains(search) ||
                                                      l.Ten.Contains(search) ||
                                                      l.DienThoai.Contains(search) ||
                                                      l.Email.Contains(search) ||
                                                      l.Cmnd.Contains(search) ||
                                                      l.TinhTrang.Contains(search))
                                               .Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                               .Include(l => l.IdLoaiNguoiDungNavigation)
                                               .OrderBy(l => l.TenDangNhap)
                                               .ToList();
                        break;
                    case "tendangnhap-za":
                        list = context.TaiKhoan.Where(l => l.TenDangNhap.Contains(search) ||
                                                      l.Ten.Contains(search) ||
                                                      l.DienThoai.Contains(search) ||
                                                      l.Email.Contains(search) ||
                                                      l.Cmnd.Contains(search) ||
                                                      l.TinhTrang.Contains(search))
                                               .Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                               .Include(l => l.IdLoaiNguoiDungNavigation)
                                               .OrderByDescending(l => l.TenDangNhap)
                                               .ToList();
                        break;
                    case "ten-az":
                        list = context.TaiKhoan.Where(l => l.TenDangNhap.Contains(search) ||
                                                      l.Ten.Contains(search) ||
                                                      l.DienThoai.Contains(search) ||
                                                      l.Email.Contains(search) ||
                                                      l.Cmnd.Contains(search) ||
                                                      l.TinhTrang.Contains(search))
                                               .Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                               .Include(l => l.IdLoaiNguoiDungNavigation)
                                               .OrderBy(l => l.Ten)
                                               .ToList();
                        break;
                    case "ten-za":
                        list = context.TaiKhoan.Where(l => l.TenDangNhap.Contains(search) ||
                                                      l.Ten.Contains(search) ||
                                                      l.DienThoai.Contains(search) ||
                                                      l.Email.Contains(search) ||
                                                      l.Cmnd.Contains(search) ||
                                                      l.TinhTrang.Contains(search))
                                               .Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                               .Include(l => l.IdLoaiNguoiDungNavigation)
                                               .OrderByDescending(l => l.Ten)
                                               .ToList();
                        break;
                }
            }
            return list;
        }

        public string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
