using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.BusinessLogicLayer
{
    public class DiaChiBUS
    {
        private readonly QLBanGiayContext context;

        public DiaChiBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public DiaChiBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public List<DiaChi> GetDiaChis()
        {
            List<DiaChi> diachi = context.DiaChi.Include(dc => dc.IdTaiKhoanNavigation)
                                                .Include(dc => dc.IdTinhThanhNavigation)
                                                .ToList();
            return diachi;
        }

        public List<DiaChi> GetDiaChis(int pagenumber, int pagesize)
        {
            List<DiaChi> diachi = context.DiaChi.OrderBy(dc => dc.Id)
                                                .Skip((pagenumber - 1) * pagesize)
                                                .Take(pagesize)
                                                .Include(dc => dc.IdTaiKhoanNavigation)
                                                .Include(dc => dc.IdTinhThanhNavigation)
                                                .ToList();
            return diachi;
        }

        public List<DiaChi> GetDiaChis(string tendangnhap)
        {
            List<DiaChi> diachi = context.DiaChi.Where(dc => dc.IdTaiKhoanNavigation.TenDangNhap == tendangnhap)
                                                .Include(dc => dc.IdTaiKhoanNavigation)
                                                .Include(dc => dc.IdTinhThanhNavigation)
                                                .ToList();
            return diachi;
        }

        public List<TinhThanh> GetTinhThanhs()
        {
            List<TinhThanh> tinhthanh = context.TinhThanh.ToList();
            return tinhthanh;
        }

        public DiaChi GetThongTinDiaChi(string tendangnhap, string diachi)
        {
            DiaChi dc = context.DiaChi.Where(d => d.IdTaiKhoanNavigation.TenDangNhap == tendangnhap && d.Duong == diachi)
                                      .Include(d => d.IdTaiKhoanNavigation)
                                      .Include(d => d.IdTinhThanhNavigation)
                                      .SingleOrDefault();
            return dc;
        }

        public string CreateDiaChi(string tendangnhap, string duong, string tinhthanh)
        {
            TaiKhoan tk = new TaiKhoan();
            //Kiểm tra
            tk = context.TaiKhoan.Where(t => t.TenDangNhap == tendangnhap).SingleOrDefault();
            if(tk == null)
            {
                return "Tên tài khoản không tồn tại";
            }
            //Thêm
            DiaChi dc = new DiaChi();
            dc.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            dc.IdTaiKhoan = tk.Id;
            dc.Duong = duong;
            dc.IdTinhThanh = Guid.Parse(tinhthanh);
            dc.TinhTrang = "Không khoá";
            context.DiaChi.Add(dc);
            context.SaveChanges();
            return "Thêm thành công";
        }

        public string EditDiaChi(string id, string diachi, string tinhthanh)
        {
            DiaChi dc = context.DiaChi.Where(d => d.Id == Guid.Parse(id)).SingleOrDefault();
            if(dc.Duong == diachi && dc.IdTinhThanh.ToString() == tinhthanh)
            {
                return "Thông tin địa chỉ không thay đổi";
            }
            dc.Duong = diachi;
            dc.IdTinhThanh = Guid.Parse(tinhthanh);
            context.SaveChanges();
            return "Sửa thành công";
        }

        public string EditDiaChiMer(string tendangnhap, string duong, string tinhthanh)
        {
            TaiKhoan taikhoan = context.TaiKhoan.Where(tk => tk.TenDangNhap == tendangnhap).SingleOrDefault();
            DiaChi diachi = context.DiaChi.Where(dc => dc.IdTaiKhoan == taikhoan.Id).SingleOrDefault();
            diachi.Duong = duong;
            diachi.IdTinhThanh = Guid.Parse(tinhthanh);
            context.SaveChanges();
            return "Sửa thành công";
        }

        public string LockDiaChi(string id)
        {
            DiaChi dc = context.DiaChi.Where(d => d.Id == Guid.Parse(id)).SingleOrDefault();
            dc.TinhTrang = "Khoá";
            context.SaveChanges();
            return "Khoá thành công";
        }

        public string UnlockDiaChi(string id)
        {
            DiaChi dc = context.DiaChi.Where(d => d.Id == Guid.Parse(id)).SingleOrDefault();
            dc.TinhTrang = "Không khoá";
            context.SaveChanges();
            return "Mở khoá thành công";
        }

        public List<DiaChi> Sort(string sortorder, int pagesize, int pagenumber)
        {
            List<DiaChi> list = new List<DiaChi>();
            switch (sortorder)
            {
                case "taikhoan-az":
                    list = context.DiaChi.OrderBy(dc => dc.IdTaiKhoanNavigation.TenDangNhap)
                                         .Skip((pagenumber - 1) * pagesize)
                                         .Take(pagesize)
                                         .Include(dc => dc.IdTaiKhoanNavigation)
                                         .Include(dc => dc.IdTinhThanhNavigation)
                                         .ToList();
                    break;
                case "taikhoan-za":
                    list = context.DiaChi.OrderByDescending(dc => dc.IdTaiKhoanNavigation.TenDangNhap)
                                         .Skip((pagenumber - 1) * pagesize)
                                         .Take(pagesize)
                                         .Include(dc => dc.IdTaiKhoanNavigation)
                                         .Include(dc => dc.IdTinhThanhNavigation)
                                         .ToList();
                    break;
                case "tinhthanh-asc":
                    list = context.DiaChi.OrderBy(dc => dc.IdTinhThanhNavigation.TenTinhThanh)
                                         .Skip((pagenumber - 1) * pagesize)
                                         .Take(pagesize)
                                         .Include(dc => dc.IdTaiKhoanNavigation)
                                         .Include(dc => dc.IdTinhThanhNavigation)
                                         .ToList();
                    break;
                case "tinhthanh-desc":
                    list = context.DiaChi.OrderByDescending(dc => dc.IdTinhThanhNavigation.TenTinhThanh)
                                         .Skip((pagenumber - 1) * pagesize)
                                         .Take(pagesize)
                                         .Include(dc => dc.IdTaiKhoanNavigation)
                                         .Include(dc => dc.IdTinhThanhNavigation)
                                         .ToList();
                    break;
            }
            return list;
        }

        public List<DiaChi> Sort(string sortorder)
        {
            List<DiaChi> list = new List<DiaChi>();
            switch (sortorder)
            {
                case "taikhoan-az":
                    list = context.DiaChi.OrderBy(dc => dc.IdTaiKhoanNavigation.TenDangNhap)
                                         .Include(dc => dc.IdTaiKhoanNavigation)
                                         .Include(dc => dc.IdTinhThanhNavigation)
                                         .ToList();
                    break;
                case "taikhoan-za":
                    list = context.DiaChi.OrderByDescending(dc => dc.IdTaiKhoanNavigation.TenDangNhap)
                                         .Include(dc => dc.IdTaiKhoanNavigation)
                                         .Include(dc => dc.IdTinhThanhNavigation)
                                         .ToList();
                    break;
                case "tinhthanh-asc":
                    list = context.DiaChi.OrderBy(dc => dc.IdTinhThanhNavigation.TenTinhThanh)
                                         .Include(dc => dc.IdTaiKhoanNavigation)
                                         .Include(dc => dc.IdTinhThanhNavigation)
                                         .ToList();
                    break;
                case "tinhthanh-desc":
                    list = context.DiaChi.OrderByDescending(dc => dc.IdTinhThanhNavigation.TenTinhThanh)
                                         .Include(dc => dc.IdTaiKhoanNavigation)
                                         .Include(dc => dc.IdTinhThanhNavigation)
                                         .ToList();
                    break;
            }
            return list;
        }

        public List<DiaChi> Search(string search, int pagesize, int pagenumber)
        {
            List<DiaChi> list = new List<DiaChi>();
            if (search == null)
            {
                list = GetDiaChis(1, pagesize);
            }
            else
            {
                list = context.DiaChi.Where(dc => dc.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                  dc.IdTinhThanhNavigation.TenTinhThanh.Contains(search) ||
                                                  dc.TinhTrang.Contains(search))
                                     .Skip((pagenumber - 1) * pagesize)
                                     .Take(pagesize)
                                     .Include(dc => dc.IdTaiKhoanNavigation)
                                     .Include(dc => dc.IdTinhThanhNavigation)
                                     .ToList();
            }
            return list;
        }

        public List<DiaChi> Search(string search, int pagesize)
        {
            List<DiaChi> list = new List<DiaChi>();
            if (search == null)
            {
                list = GetDiaChis(1, pagesize);
            }
            else
            {
                list = context.DiaChi.Where(dc => dc.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                  dc.IdTinhThanhNavigation.TenTinhThanh.Contains(search) ||
                                                  dc.TinhTrang.Contains(search))
                                     .Include(dc => dc.IdTaiKhoanNavigation)
                                     .Include(dc => dc.IdTinhThanhNavigation)
                                     .ToList();
            }
            return list;
        }

        public List<DiaChi> SearchAndSort(string search, string sortorder, int pagesize, int pagenumber)
        {
            List<DiaChi> list = new List<DiaChi>();
            if (search == null)
            {
                list = GetDiaChis(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "taikhoan-az":
                        list = context.DiaChi.Where(dc => dc.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          dc.IdTinhThanhNavigation.TenTinhThanh.Contains(search) ||
                                                          dc.TinhTrang.Contains(search))
                                             .OrderBy(dc => dc.IdTaiKhoanNavigation.TenDangNhap)
                                             .Include(dc => dc.IdTaiKhoanNavigation)
                                             .Include(dc => dc.IdTinhThanhNavigation)
                                             .Skip((pagenumber - 1) * pagesize)
                                             .Take(pagesize)
                                             .ToList();
                        break;
                    case "taikhoan-za":
                        list = context.DiaChi.Where(dc => dc.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          dc.IdTinhThanhNavigation.TenTinhThanh.Contains(search) ||
                                                          dc.TinhTrang.Contains(search))
                                             .OrderByDescending(dc => dc.IdTaiKhoanNavigation.TenDangNhap)
                                             .Include(dc => dc.IdTaiKhoanNavigation)
                                             .Include(dc => dc.IdTinhThanhNavigation)
                                             .Skip((pagenumber - 1) * pagesize)
                                             .Take(pagesize)
                                             .ToList();
                        break;
                    case "tinhthanh-asc":
                        list = context.DiaChi.Where(dc => dc.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          dc.IdTinhThanhNavigation.TenTinhThanh.Contains(search) ||
                                                          dc.TinhTrang.Contains(search))
                                             .OrderBy(dc => dc.IdTinhThanhNavigation.TenTinhThanh)
                                             .Include(dc => dc.IdTaiKhoanNavigation)
                                             .Include(dc => dc.IdTinhThanhNavigation)
                                             .Skip((pagenumber - 1) * pagesize)
                                             .Take(pagesize)
                                             .ToList();
                        break;
                    case "tinhthanh-desc":
                        list = context.DiaChi.Where(dc => dc.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          dc.IdTinhThanhNavigation.TenTinhThanh.Contains(search) ||
                                                          dc.TinhTrang.Contains(search))
                                             .OrderByDescending(dc => dc.IdTinhThanhNavigation.TenTinhThanh)
                                             .Include(dc => dc.IdTaiKhoanNavigation)
                                             .Include(dc => dc.IdTinhThanhNavigation)
                                             .Skip((pagenumber - 1) * pagesize)
                                             .Take(pagesize)
                                             .ToList();
                        break;
                }
            }
            return list;
        }

        public List<DiaChi> SearchAndSort(string search, string sortorder, int pagesize)
        {
            List<DiaChi> list = new List<DiaChi>();
            if (search == null)
            {
                list = GetDiaChis(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "tengianhang-az":
                        list = context.DiaChi.Where(dc => dc.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          dc.IdTinhThanhNavigation.TenTinhThanh.Contains(search) ||
                                                          dc.TinhTrang.Contains(search))
                                             .OrderBy(dc => dc.IdTaiKhoanNavigation.TenDangNhap)
                                             .Include(dc => dc.IdTaiKhoanNavigation)
                                             .Include(dc => dc.IdTinhThanhNavigation)
                                             .ToList();
                        break;
                    case "tengianhang-za":
                        list = context.DiaChi.Where(dc => dc.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          dc.IdTinhThanhNavigation.TenTinhThanh.Contains(search) ||
                                                          dc.TinhTrang.Contains(search))
                                             .OrderByDescending(dc => dc.IdTaiKhoanNavigation.TenDangNhap)
                                             .Include(dc => dc.IdTaiKhoanNavigation)
                                             .Include(dc => dc.IdTinhThanhNavigation)
                                             .ToList();
                        break;
                    case "gia-asc":
                        list = context.DiaChi.Where(dc => dc.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          dc.IdTinhThanhNavigation.TenTinhThanh.Contains(search) ||
                                                          dc.TinhTrang.Contains(search))
                                             .OrderBy(dc => dc.IdTinhThanhNavigation.TenTinhThanh)
                                             .Include(dc => dc.IdTaiKhoanNavigation)
                                             .Include(dc => dc.IdTinhThanhNavigation)
                                             .ToList();
                        break;
                    case "gia-desc":
                        list = context.DiaChi.Where(dc => dc.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          dc.IdTinhThanhNavigation.TenTinhThanh.Contains(search) ||
                                                          dc.TinhTrang.Contains(search))
                                             .OrderByDescending(dc => dc.IdTinhThanhNavigation.TenTinhThanh)
                                             .Include(dc => dc.IdTaiKhoanNavigation)
                                             .Include(dc => dc.IdTinhThanhNavigation)
                                             .ToList();
                        break;
                }
            }
            return list;
        }
    }
}
