using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.BusinessLogicLayer
{
    public class SanPhamBUS
    {
        private readonly QLBanGiayContext context;

        public SanPhamBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public SanPhamBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public SanPham GetSanPham(string id)
        {
            SanPham sanpham = context.SanPham.Where(sp => sp.Id == Guid.Parse(id))
                                             .Include(sp => sp.IdTaiKhoanNavigation)
                                             .Include(sp => sp.IdHangSanPhamNavigation)
                                             .SingleOrDefault();
            return sanpham;
        }

        public List<SanPham> GetSanPhams()
        {
            List<SanPham> list = context.SanPham.OrderBy(sp => sp.MaSanPham)
                                                .Include(sp => sp.IdHangSanPhamNavigation)
                                                .Include(sp => sp.IdTaiKhoanNavigation)
                                                .ToList();
            return list;
        }

        public List<SanPham> GetSanPhams(string ploai)
        {
            List<SanPham> list = context.SanPham.Where(sp => sp.PhanLoai == ploai)
                                                .Include(sp => sp.IdTaiKhoanNavigation)
                                                .Include(sp => sp.IdHangSanPhamNavigation)
                                                .OrderByDescending(sp => sp.MaSanPham)
                                                .ToList();
            return list;
        }

        public List<SanPham> GetSanPhams(string ploai, int pagenumber, int pagesize)
        {
            List<SanPham> list = context.SanPham.Where(sp => sp.PhanLoai == ploai)
                                                .Include(sp => sp.IdTaiKhoanNavigation)
                                                .Include(sp => sp.IdHangSanPhamNavigation)
                                                .OrderByDescending(sp => sp.MaSanPham)
                                                .Skip((pagenumber - 1) * pagesize)
                                                .Take(pagesize)
                                                .ToList();
            return list;
        }

        public List<SanPham> GetSanPhams(int pagenumber, int pagesize)
        {
            List<SanPham> list = context.SanPham.Include(sp => sp.IdTaiKhoanNavigation)
                                                .Include(sp => sp.IdHangSanPhamNavigation)
                                                .OrderByDescending(sp => sp.MaSanPham)
                                                .Skip((pagenumber - 1) * pagesize)
                                                .Take(pagesize)
                                                .ToList();
            return list;
        }

        public List<SanPham> GetSanPhams(string column, string dieukien, int pagenumber, int pagesize)
        {
            List<SanPham> list = new List<SanPham>();
            switch (column)
            {
                case "PhanLoai":
                    list = context.SanPham.Where(sp => sp.PhanLoai == dieukien)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .OrderByDescending(sp => sp.MaSanPham)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                    break;
                default:
                   list = context.SanPham.Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .OrderByDescending(sp => sp.MaSanPham)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                    break;
            }
            return list;
        }

        public List<SanPham> Sort(string sortorder, int pagesize, int pagenumber)
        {
            List<SanPham> list = new List<SanPham>();
            switch (sortorder)
            {
                case "masanpham-az":
                    list = context.SanPham.OrderBy(sp => sp.MaSanPham)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                    break;
                case "masanpham-za":
                    list = context.SanPham.OrderByDescending(sp => sp.MaSanPham)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                    break;
                case "tensanpham-az":
                    list = context.SanPham.OrderBy(sp => sp.TenSanPham)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                    break;
                case "tensanpham-za":
                    list = context.SanPham.OrderByDescending(sp => sp.TenSanPham)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                    break;
                case "gia-asc":
                    list = context.SanPham.OrderBy(sp => sp.Gia)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                    break;
                case "gia-desc":
                    list = context.SanPham.OrderByDescending(sp => sp.Gia)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                    break;
                case "moinhat":
                    list = context.SanPham.OrderByDescending(sp => sp.NgayDang)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                    break;
            }
            return list;
        }

        public List<SanPham> Sort(string sortorder)
        {
            List<SanPham> list = new List<SanPham>();
            switch (sortorder)
            {
                case "masanpham-az":
                    list = context.SanPham.OrderBy(sp => sp.MaSanPham)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .ToList();
                    break;
                case "masanpham-za":
                    list = context.SanPham.OrderByDescending(sp => sp.MaSanPham)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .ToList();
                    break;
                case "tensanpham-az":
                    list = context.SanPham.OrderBy(sp => sp.TenSanPham)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .ToList();
                    break;
                case "tensanpham-za":
                    list = context.SanPham.OrderByDescending(sp => sp.TenSanPham)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .ToList();
                    break;
                case "gia-asc":
                    list = context.SanPham.OrderBy(sp => sp.Gia)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .ToList();
                    break;
                case "gia-desc":
                    list = context.SanPham.OrderByDescending(sp => sp.Gia)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .ToList();
                    break;
                case "moinhat":
                    list = context.SanPham.OrderByDescending(sp => sp.NgayDang)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .ToList();
                    break;
            }
            return list;
        }

        public List<SanPham> Search(string search, int pagesize, int pagenumber)
        {
            List<SanPham> list = new List<SanPham>();
            if (search == null)
            {
                list = GetSanPhams(1, pagesize);
            }
            else
            {
                list = context.SanPham.Where(sp => sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search) ||
                                                   sp.Gia.ToString().Contains(search))
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .ToList();
            }
            return list;
        }

        public List<SanPham> Search(string search, int pagesize)
        {
            List<SanPham> list = new List<SanPham>();
            if (search == null)
            {
                list = GetSanPhams(1, pagesize);
            }
            else
            {
                list = context.SanPham.Where(sp => sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search) ||
                                                   sp.Gia.ToString().Contains(search))
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .ToList();
            }
            return list;
        }

        public List<SanPham> SearchAndSort(string search, string sortorder, int pagesize, int pagenumber)
        {
            List<SanPham> list = new List<SanPham>();
            if (search == null)
            {
                list = GetSanPhams(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "masanpham-az":
                        list = context.SanPham.Where(sp => sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search) ||
                                                   sp.Gia.ToString().Contains(search))
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .OrderBy(sp => sp.MaSanPham)
                                      .ToList();
                        break;
                    case "masanpham-za":
                        list = context.SanPham.Where(sp => sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search) ||
                                                   sp.Gia.ToString().Contains(search))
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .OrderByDescending(sp => sp.MaSanPham)
                                      .ToList();
                        break;
                    case "tensanpham-az":
                        list = context.SanPham.Where(sp => sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search) ||
                                                   sp.Gia.ToString().Contains(search))
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .OrderBy(sp => sp.TenSanPham)
                                      .ToList();
                        break;
                    case "tensanpham-za":
                        list = context.SanPham.Where(sp => sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search) ||
                                                   sp.Gia.ToString().Contains(search))
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .OrderByDescending(sp => sp.TenSanPham)
                                      .ToList();
                        break;
                    case "gia-asc":
                        list = context.SanPham.Where(sp => sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search) ||
                                                   sp.Gia.ToString().Contains(search))
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .OrderBy(sp => sp.Gia)
                                      .ToList();
                        break;
                    case "gia-desc":
                        list = context.SanPham.Where(sp => sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search) ||
                                                   sp.Gia.ToString().Contains(search))
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .OrderByDescending(sp => sp.Gia)
                                      .ToList();
                        break;
                    case "moinhat":
                        list = context.SanPham.Where(sp => sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search) ||
                                                   sp.Gia.ToString().Contains(search))
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .OrderByDescending(sp => sp.NgayDang)
                                      .ToList();
                        break;
                }
            }
            return list;
        }

        public List<SanPham> SearchAndSort(string search, string sortorder, int pagesize)
        {
            List<SanPham> list = new List<SanPham>();
            if (search == null)
            {
                list = GetSanPhams(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "masanpham-az":
                        list = context.SanPham.Where(sp => sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search) ||
                                                   sp.Gia.ToString().Contains(search))
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderBy(sp => sp.MaSanPham)
                                      .ToList();
                        break;
                    case "masanpham-za":
                        list = context.SanPham.Where(sp => sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search) ||
                                                   sp.Gia.ToString().Contains(search))
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderByDescending(sp => sp.MaSanPham)
                                      .ToList();
                        break;
                    case "tensanpham-az":
                        list = context.SanPham.Where(sp => sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search) ||
                                                   sp.Gia.ToString().Contains(search))
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderBy(sp => sp.TenSanPham)
                                      .ToList();
                        break;
                    case "tensanpham-za":
                        list = context.SanPham.Where(sp => sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search) ||
                                                   sp.Gia.ToString().Contains(search))
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderByDescending(sp => sp.TenSanPham)
                                      .ToList();
                        break;
                    case "gia-asc":
                        list = context.SanPham.Where(sp => sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search) ||
                                                   sp.Gia.ToString().Contains(search))
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderBy(sp => sp.Gia)
                                      .ToList();
                        break;
                    case "gia-desc":
                        list = context.SanPham.Where(sp => sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search) ||
                                                   sp.Gia.ToString().Contains(search))
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderByDescending(sp => sp.Gia)
                                      .ToList();
                        break;
                    case "moinhat":
                        list = context.SanPham.Where(sp => sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search) ||
                                                   sp.Gia.ToString().Contains(search))
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderByDescending(sp => sp.NgayDang)
                                      .ToList();
                        break;
                }
            }
            return list;
        }
    }
}
