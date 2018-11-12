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
    }
}
