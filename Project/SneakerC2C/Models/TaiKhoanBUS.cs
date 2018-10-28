using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
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

        public string EditTaiKhoan(string tendangnhap, string matkhau, string email, string dienthoai, string cmnd)
        {
            TaiKhoan taikhoan = context.TaiKhoan.Where(tk => tk.TenDangNhap == tendangnhap).SingleOrDefault();
            if(matkhau != null)
            {
                taikhoan.MatKhau = taikhoan.CreateMD5(matkhau);
            }
            if(email != null)
            {
                taikhoan.Email = email;
            }
            if(dienthoai != null)
            {
                taikhoan.DienThoai = dienthoai;
            }
            if(cmnd != null)
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

        public List<TaiKhoan> Sort(string sortorder, int pagesize)
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            switch(sortorder)
            {
                case "tendangnhap-az":
                    list = context.TaiKhoan.Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                           .OrderBy(l => l.TenDangNhap)
                                           .Include(l => l.IdLoaiNguoiDungNavigation)
                                           .Take(pagesize)
                                           .ToList();
                    break;
                case "tendangnhap-za":
                    list = context.TaiKhoan.Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                           .OrderByDescending(l => l.TenDangNhap)
                                           .Include(l => l.IdLoaiNguoiDungNavigation)
                                           .Take(pagesize)
                                           .ToList();
                    break;
                case "ten-az":
                    list = context.TaiKhoan.Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                           .OrderBy(l => l.Ten)
                                           .Include(l => l.IdLoaiNguoiDungNavigation)
                                           .Take(pagesize)
                                           .ToList();
                    break;
                case "ten-za":
                    list = context.TaiKhoan.Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                           .OrderByDescending(l => l.Ten)
                                           .Include(l => l.IdLoaiNguoiDungNavigation)
                                           .Take(pagesize)
                                           .ToList();
                    break;
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
                                                   l.Cmnd.Contains(search))
                                       .Where(l => l.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Webmaster")
                                       .Include(l => l.IdLoaiNguoiDungNavigation)
                                       .Take(pagesize)
                                       .ToList();
            }
            return list;
        }
    }
}
