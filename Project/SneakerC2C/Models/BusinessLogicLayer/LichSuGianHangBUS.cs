using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.BusinessLogicLayer
{
    public class LichSuGianHangBUS
    {
        private readonly QLBanGiayContext context;

        public LichSuGianHangBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public LichSuGianHangBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public List<LichSuGianHang> GetLichSuGianHangs()
        {
            List<LichSuGianHang> list = context.LichSuGianHang.OrderByDescending(gh => gh.NgayDangKy)
                                                              .Include(gh => gh.IdTaiKhoanNavigation)
                                                              .Include(gh => gh.IdGianHangNavigation)
                                                              .ToList();
            return list;
        }

        public List<LichSuGianHang> GetLichSuGianHangs(string tendangnhap)
        {
            List<LichSuGianHang> list = context.LichSuGianHang.Where(gh => gh.IdTaiKhoanNavigation.TenDangNhap == tendangnhap)
                                                              .OrderByDescending(gh => gh.NgayDangKy)
                                                              .Include(gh => gh.IdTaiKhoanNavigation)
                                                              .Include(gh => gh.IdGianHangNavigation)
                                                              .ToList();
            return list;
        }

        public List<LichSuGianHang> GetLichSuGianHangs(int pagenumber, int pagesize)
        {
            List<LichSuGianHang> list = context.LichSuGianHang.OrderBy(gh => gh.Id)
                                                              .Skip((pagenumber - 1) * pagesize)
                                                              .Take(pagesize)
                                                              .Include(gh => gh.IdTaiKhoanNavigation)
                                                              .Include(gh => gh.IdGianHangNavigation)
                                                              .ToList();
            return list;
        }

        public string CreateLichSuGianHang(string tendangnhap, string gianhang)
        {
            LichSuGianHang lichsugianhang = new LichSuGianHang();
            TaiKhoan taikhoan = context.TaiKhoan.Where(tk => tk.TenDangNhap == tendangnhap).SingleOrDefault();
            lichsugianhang.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            lichsugianhang.IdTaiKhoan = taikhoan.Id;
            lichsugianhang.IdGianHang = Guid.Parse(gianhang);
            lichsugianhang.NgayDangKy = DateTime.Now;
            lichsugianhang.TinhTrang = "Không khoá";
            context.LichSuGianHang.Add(lichsugianhang);
            context.SaveChanges();
            return "Thêm thành công";
        }

        public string EditLichSuGianHang(string id, string idgianhang)
        {
            LichSuGianHang lichsugianhang = context.LichSuGianHang.Where(gh => gh.Id == Guid.Parse(id)).SingleOrDefault();
            GianHang gianhang = context.GianHang.Where(gh => gh.Id == Guid.Parse(idgianhang)).SingleOrDefault();
            lichsugianhang.IdGianHang = Guid.Parse(idgianhang);
            lichsugianhang.NgayKetThuc = lichsugianhang.NgayBatDau.Value.AddDays((double)gianhang.ThoiGian);
            context.SaveChanges();
            return "Sửa thành công";
        }

        public string LockLichSuGianHang(string id)
        {
            LichSuGianHang lichsugianhang = context.LichSuGianHang.Where(gh => gh.Id == Guid.Parse(id)).SingleOrDefault();
            lichsugianhang.TinhTrang = "Khoá";
            context.SaveChanges();
            return "Khoá thành công";
        }

        public List<LichSuGianHang> Sort(string sortorder, int pagesize, int pagenumber)
        {
            List<LichSuGianHang> list = new List<LichSuGianHang>();
            switch (sortorder)
            {
                case "taikhoan-az":
                    list = context.LichSuGianHang.OrderBy(ls => ls.IdTaiKhoanNavigation.TenDangNhap)
                                                 .Include(ls => ls.IdTaiKhoanNavigation)
                                                 .Include(ls => ls.IdGianHangNavigation)
                                                 .Skip((pagenumber - 1) * pagesize)
                                                 .Take(pagesize)
                                                 .ToList();
                    break;
                case "taikhoan-za":
                    list = context.LichSuGianHang.OrderByDescending(ls => ls.IdTaiKhoanNavigation.TenDangNhap)
                                                 .Include(ls => ls.IdTaiKhoanNavigation)
                                                 .Include(ls => ls.IdGianHangNavigation)
                                                 .Skip((pagenumber - 1) * pagesize)
                                                 .Take(pagesize)
                                                 .ToList();
                    break;
                case "gianhang-az":
                    list = context.LichSuGianHang.OrderBy(ls => ls.IdGianHangNavigation.TenGianHang)
                                                 .Include(ls => ls.IdTaiKhoanNavigation)
                                                 .Include(ls => ls.IdGianHangNavigation)
                                                 .Skip((pagenumber - 1) * pagesize)
                                                 .Take(pagesize)
                                                 .ToList();
                    break;
                case "gianhang-za":
                    list = context.LichSuGianHang.OrderByDescending(ls => ls.IdGianHangNavigation.TenGianHang)
                                                 .Include(ls => ls.IdTaiKhoanNavigation)
                                                 .Include(ls => ls.IdGianHangNavigation)
                                                 .Skip((pagenumber - 1) * pagesize)
                                                 .Take(pagesize)
                                                 .ToList();
                    break;
                case "ngaydangky-asc":
                    list = context.LichSuGianHang.OrderBy(ls => ls.NgayDangKy)
                                                 .Include(ls => ls.IdTaiKhoanNavigation)
                                                 .Include(ls => ls.IdGianHangNavigation)
                                                 .Skip((pagenumber - 1) * pagesize)
                                                 .Take(pagesize)
                                                 .ToList();
                    break;
                case "ngaydangky-desc":
                    list = context.LichSuGianHang.OrderByDescending(ls => ls.NgayDangKy)
                                                 .Include(ls => ls.IdTaiKhoanNavigation)
                                                 .Include(ls => ls.IdGianHangNavigation)
                                                 .Skip((pagenumber - 1) * pagesize)
                                                 .Take(pagesize)
                                                 .ToList();
                    break;
            }
            return list;
        }

        public List<LichSuGianHang> Sort(string sortorder)
        {
            List<LichSuGianHang> list = new List<LichSuGianHang>();
            switch (sortorder)
            {
                case "taikhoan-az":
                    list = context.LichSuGianHang.OrderBy(ls => ls.IdTaiKhoanNavigation.TenDangNhap)
                                                 .Include(ls => ls.IdTaiKhoanNavigation)
                                                 .Include(ls => ls.IdGianHangNavigation)
                                                 .ToList();
                    break;
                case "taikhoan-za":
                    list = context.LichSuGianHang.OrderByDescending(ls => ls.IdTaiKhoanNavigation.TenDangNhap)
                                                 .Include(ls => ls.IdTaiKhoanNavigation)
                                                 .Include(ls => ls.IdGianHangNavigation)
                                                 .ToList();
                    break;
                case "gianhang-az":
                    list = context.LichSuGianHang.OrderBy(ls => ls.IdGianHangNavigation.TenGianHang)
                                                 .Include(ls => ls.IdTaiKhoanNavigation)
                                                 .Include(ls => ls.IdGianHangNavigation)
                                                 .ToList();
                    break;
                case "gianhang-za":
                    list = context.LichSuGianHang.OrderByDescending(ls => ls.IdGianHangNavigation.TenGianHang)
                                                 .Include(ls => ls.IdTaiKhoanNavigation)
                                                 .Include(ls => ls.IdGianHangNavigation)
                                                 .ToList();
                    break;
                case "ngaydangky-asc":
                    list = context.LichSuGianHang.OrderBy(ls => ls.NgayDangKy)
                                                 .Include(ls => ls.IdTaiKhoanNavigation)
                                                 .Include(ls => ls.IdGianHangNavigation)
                                                 .ToList();
                    break;
                case "ngaydangky-desc":
                    list = context.LichSuGianHang.OrderByDescending(ls => ls.NgayDangKy)
                                                 .Include(ls => ls.IdTaiKhoanNavigation)
                                                 .Include(ls => ls.IdGianHangNavigation)
                                                 .ToList();
                    break;
            }
            return list;
        }

        public List<LichSuGianHang> Search(string search, int pagesize, int pagenumber)
        {
            List<LichSuGianHang> list = new List<LichSuGianHang>();
            if (search == null)
            {
                list = GetLichSuGianHangs(1, pagesize);
            }
            else
            {
                list = context.LichSuGianHang.Where(ls => ls.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          ls.IdGianHangNavigation.TenGianHang.Contains(search) ||
                                                          ls.IdGianHangNavigation.MaGianHang.Contains(search) ||
                                                          ls.TinhTrang.Contains(search))
                                             .Include(ls => ls.IdTaiKhoanNavigation)
                                             .Include(ls => ls.IdGianHangNavigation)
                                             .Skip((pagenumber - 1) * pagesize)
                                             .Take(pagesize)
                                             .ToList();
            }
            return list;
        }

        public List<LichSuGianHang> Search(string search, int pagesize)
        {
            List<LichSuGianHang> list = new List<LichSuGianHang>();
            if (search == null)
            {
                list = GetLichSuGianHangs(1, pagesize);
            }
            else
            {
                list = context.LichSuGianHang.Where(ls => ls.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          ls.IdGianHangNavigation.TenGianHang.Contains(search) ||
                                                          ls.IdGianHangNavigation.MaGianHang.Contains(search) ||
                                                          ls.TinhTrang.Contains(search))
                                             .Include(ls => ls.IdTaiKhoanNavigation)
                                             .Include(ls => ls.IdGianHangNavigation)
                                             .ToList();
            }
            return list;
        }

        public List<LichSuGianHang> SearchAndSort(string search, string sortorder, int pagesize, int pagenumber)
        {
            List<LichSuGianHang> list = new List<LichSuGianHang>();
            if (search == null)
            {
                list = GetLichSuGianHangs(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "tendangnhap-az":
                        list = context.LichSuGianHang.Where(ls => ls.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          ls.IdGianHangNavigation.TenGianHang.Contains(search) ||
                                                          ls.IdGianHangNavigation.MaGianHang.Contains(search) ||
                                                          ls.TinhTrang.Contains(search))
                                             .OrderBy(ls => ls.IdTaiKhoanNavigation.TenDangNhap)
                                             .Include(ls => ls.IdTaiKhoanNavigation)
                                             .Include(ls => ls.IdGianHangNavigation)
                                             .Skip((pagenumber - 1) * pagesize)
                                             .Take(pagesize)
                                             .ToList();
                        break;
                    case "tendangnhap-za":
                        list = context.LichSuGianHang.Where(ls => ls.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          ls.IdGianHangNavigation.TenGianHang.Contains(search) ||
                                                          ls.IdGianHangNavigation.MaGianHang.Contains(search) ||
                                                          ls.TinhTrang.Contains(search))
                                             .OrderByDescending(ls => ls.IdTaiKhoanNavigation.TenDangNhap)
                                             .Include(ls => ls.IdTaiKhoanNavigation)
                                             .Include(ls => ls.IdGianHangNavigation)
                                             .Skip((pagenumber - 1) * pagesize)
                                             .Take(pagesize)
                                             .ToList();
                        break;
                    case "gianhang-az":
                        list = context.LichSuGianHang.Where(ls => ls.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          ls.IdGianHangNavigation.TenGianHang.Contains(search) ||
                                                          ls.IdGianHangNavigation.MaGianHang.Contains(search) ||
                                                          ls.TinhTrang.Contains(search))
                                             .OrderBy(ls => ls.IdGianHangNavigation.TenGianHang)
                                             .Include(ls => ls.IdTaiKhoanNavigation)
                                             .Include(ls => ls.IdGianHangNavigation)
                                             .Skip((pagenumber - 1) * pagesize)
                                             .Take(pagesize)
                                             .ToList();
                        break;
                    case "gianhang-za":
                        list = context.LichSuGianHang.Where(ls => ls.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          ls.IdGianHangNavigation.TenGianHang.Contains(search) ||
                                                          ls.IdGianHangNavigation.MaGianHang.Contains(search) ||
                                                          ls.TinhTrang.Contains(search))
                                             .OrderByDescending(ls => ls.IdGianHangNavigation.TenGianHang)
                                             .Include(ls => ls.IdTaiKhoanNavigation)
                                             .Include(ls => ls.IdGianHangNavigation)
                                             .Skip((pagenumber - 1) * pagesize)
                                             .Take(pagesize)
                                             .ToList();
                        break;
                    case "ngaydangky-asc":
                        list = context.LichSuGianHang.Where(ls => ls.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          ls.IdGianHangNavigation.TenGianHang.Contains(search) ||
                                                          ls.IdGianHangNavigation.MaGianHang.Contains(search) ||
                                                          ls.TinhTrang.Contains(search))
                                             .OrderBy(ls => ls.NgayDangKy)
                                             .Include(ls => ls.IdTaiKhoanNavigation)
                                             .Include(ls => ls.IdGianHangNavigation)
                                             .Skip((pagenumber - 1) * pagesize)
                                             .Take(pagesize)
                                             .ToList();
                        break;
                    case "ngaydangky-desc":
                        list = context.LichSuGianHang.Where(ls => ls.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          ls.IdGianHangNavigation.TenGianHang.Contains(search) ||
                                                          ls.IdGianHangNavigation.MaGianHang.Contains(search) ||
                                                          ls.TinhTrang.Contains(search))
                                             .OrderByDescending(ls => ls.NgayDangKy)
                                             .Include(ls => ls.IdTaiKhoanNavigation)
                                             .Include(ls => ls.IdGianHangNavigation)
                                             .Skip((pagenumber - 1) * pagesize)
                                             .Take(pagesize)
                                             .ToList();
                        break;
                }
            }
            return list;
        }

        public List<LichSuGianHang> SearchAndSort(string search, string sortorder, int pagesize)
        {
            List<LichSuGianHang> list = new List<LichSuGianHang>();
            if (search == null)
            {
                list = GetLichSuGianHangs(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "tendangnhap-az":
                        list = context.LichSuGianHang.Where(ls => ls.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          ls.IdGianHangNavigation.TenGianHang.Contains(search) ||
                                                          ls.IdGianHangNavigation.MaGianHang.Contains(search) ||
                                                          ls.TinhTrang.Contains(search))
                                             .OrderBy(ls => ls.IdTaiKhoanNavigation.TenDangNhap)
                                             .Include(ls => ls.IdTaiKhoanNavigation)
                                             .Include(ls => ls.IdGianHangNavigation)
                                             .ToList();
                        break;
                    case "tendangnhap-za":
                        list = context.LichSuGianHang.Where(ls => ls.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          ls.IdGianHangNavigation.TenGianHang.Contains(search) ||
                                                          ls.IdGianHangNavigation.MaGianHang.Contains(search) ||
                                                          ls.TinhTrang.Contains(search))
                                             .OrderByDescending(ls => ls.IdTaiKhoanNavigation.TenDangNhap)
                                             .Include(ls => ls.IdTaiKhoanNavigation)
                                             .Include(ls => ls.IdGianHangNavigation)
                                             .ToList();
                        break;
                    case "gianhang-az":
                        list = context.LichSuGianHang.Where(ls => ls.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          ls.IdGianHangNavigation.TenGianHang.Contains(search) ||
                                                          ls.IdGianHangNavigation.MaGianHang.Contains(search) ||
                                                          ls.TinhTrang.Contains(search))
                                             .OrderBy(ls => ls.IdGianHangNavigation.TenGianHang)
                                             .Include(ls => ls.IdTaiKhoanNavigation)
                                             .Include(ls => ls.IdGianHangNavigation)
                                             .ToList();
                        break;
                    case "gianhang-za":
                        list = context.LichSuGianHang.Where(ls => ls.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          ls.IdGianHangNavigation.TenGianHang.Contains(search) ||
                                                          ls.IdGianHangNavigation.MaGianHang.Contains(search) ||
                                                          ls.TinhTrang.Contains(search))
                                             .OrderByDescending(ls => ls.IdGianHangNavigation.TenGianHang)
                                             .Include(ls => ls.IdTaiKhoanNavigation)
                                             .Include(ls => ls.IdGianHangNavigation)
                                             .ToList();
                        break;
                    case "ngaydangky-asc":
                        list = context.LichSuGianHang.Where(ls => ls.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          ls.IdGianHangNavigation.TenGianHang.Contains(search) ||
                                                          ls.IdGianHangNavigation.MaGianHang.Contains(search) ||
                                                          ls.TinhTrang.Contains(search))
                                             .OrderBy(ls => ls.NgayDangKy)
                                             .Include(ls => ls.IdTaiKhoanNavigation)
                                             .Include(ls => ls.IdGianHangNavigation)
                                             .ToList();
                        break;
                    case "ngaydangky-desc":
                        list = context.LichSuGianHang.Where(ls => ls.IdTaiKhoanNavigation.TenDangNhap.Contains(search) ||
                                                          ls.IdGianHangNavigation.TenGianHang.Contains(search) ||
                                                          ls.IdGianHangNavigation.MaGianHang.Contains(search) ||
                                                          ls.TinhTrang.Contains(search))
                                             .OrderByDescending(ls => ls.NgayDangKy)
                                             .Include(ls => ls.IdTaiKhoanNavigation)
                                             .Include(ls => ls.IdGianHangNavigation)
                                             .ToList();
                        break;
                }
            }
            return list;
        }
    }
}
