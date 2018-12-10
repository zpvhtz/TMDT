using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;

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
            SanPham sanpham = context.SanPham.Where(sp => sp.Id == Guid.Parse(id) && sp.TinhTrang =="Không khoá")
                                             .Include(sp => sp.IdTaiKhoanNavigation)
                                             .Include(sp => sp.IdHangSanPhamNavigation)
                                             .SingleOrDefault();
            return sanpham;
        }

        public List<SanPham> GetSanPhams()
        {
            List<SanPham> list = context.SanPham.Where( sp=>sp.TinhTrang == "Không khoá")
                                                .OrderBy(sp => sp.MaSanPham)
                                                .Include(sp => sp.IdHangSanPhamNavigation)
                                                .Include(sp => sp.IdTaiKhoanNavigation)
                                                .ToList();
            return list;
        }

        public List<SanPham> GetSanPhams(string ploai)
        {
            List<SanPham> list = context.SanPham.Where(sp => sp.PhanLoai == ploai && sp.TinhTrang == "Không khoá")
                                                .Include(sp => sp.IdTaiKhoanNavigation)
                                                .Include(sp => sp.IdHangSanPhamNavigation)
                                                .OrderByDescending(sp => sp.MaSanPham)
                                                .ToList();
            return list;
        }

        public List<SanPham> GetSanPhams(string ploai, int pagenumber, int pagesize)
        {
            List<SanPham> list = context.SanPham.Where(sp => sp.PhanLoai == ploai && sp.TinhTrang == "Không khoá")
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
            List<SanPham> list = context.SanPham.Where(sp => sp.TinhTrang == "Không khoá")
                                                .Include(sp => sp.IdTaiKhoanNavigation)
                                                .Include(sp => sp.IdHangSanPhamNavigation)
                                                .OrderByDescending(sp => sp.MaSanPham)
                                                .Skip((pagenumber - 1) * pagesize)
                                                .Take(pagesize)
                                                .ToList();
            return list;
        }
        public List<SanPham> GetBanChay()
        {
            var slist = context.ChiTietDonHang.Include(c => c.IdSizeSanPhamNavigation)
                                              .Include(c=>c.IdDonHangNavigation)
                                            .Where(c=>c.IdDonHangNavigation.TinhTrang=="Đã giao")
                                           .GroupBy(c => c.IdSizeSanPhamNavigation.IdSanPham)
                                           .Select(c => new
                                           {
                                               IdSanPham = c.Key,
                                               SoLuong = c.Sum(x => x.SoLuong)
                                           }).OrderByDescending(x=>x.SoLuong).ToList();
            var listsanpham = slist.Select(c => c.IdSanPham).ToList();
            List<SanPham> list = context.SanPham.Where(sp => listsanpham.Contains(sp.Id))
                                                .Include(sp => sp.IdTaiKhoanNavigation)
                                                .Include(sp => sp.IdHangSanPhamNavigation).ToList();
            List<SanPham> listphu = context.SanPham.Where(sp => !listsanpham.Contains(sp.Id))
                                                .Include(sp => sp.IdTaiKhoanNavigation)
                                                .Include(sp => sp.IdHangSanPhamNavigation)
                                                .OrderBy(sp => sp.MaSanPham)
                                                .ToList();
            foreach(var item in listphu)
            {
                list.Add(item);
            }

            return list;
        }
        public List<SanPham> GetSanPhams(string column, string dieukien, int pagenumber, int pagesize)
        {
            List<SanPham> list = new List<SanPham>();
            switch (column)
            {
                case "PhanLoai":
                    list = context.SanPham.Where(sp => sp.PhanLoai == dieukien && sp.TinhTrang == "Không khoá")
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .OrderByDescending(sp => sp.MaSanPham)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                    break;
                default:
                   list = context.SanPham.Where(sp=>sp.TinhTrang == "Không khoá")
                                            .Include(sp => sp.IdTaiKhoanNavigation)
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
                    list = context.SanPham.Where(sp=>sp.TinhTrang == "Không khoá")
                                            .OrderBy(sp => sp.MaSanPham)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                    break;
                case "masanpham-za":
                    list = context.SanPham.Where(sp => sp.TinhTrang == "Không khoá")
                                            .OrderByDescending(sp => sp.MaSanPham)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                    break;
                case "tensanpham-az":
                    list = context.SanPham.Where(sp => sp.TinhTrang == "Không khoá")
                                            .OrderBy(sp => sp.TenSanPham)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                    break;
                case "tensanpham-za":
                    list = context.SanPham.Where(sp => sp.TinhTrang == "Không khoá")
                                            .OrderByDescending(sp => sp.TenSanPham)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                    break;
                case "gia-asc":
                    list = context.SanPham.Where(sp => sp.TinhTrang == "Không khoá")
                                            .OrderBy(sp => sp.Gia)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                    break;
                case "gia-desc":
                    list = context.SanPham.Where(sp => sp.TinhTrang == "Không khoá")
                                            .OrderByDescending(sp => sp.Gia)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                    break;
                case "moinhat":
                    list = context.SanPham.Where(sp => sp.TinhTrang == "Không khoá")
                                            .OrderByDescending(sp => sp.NgayDang)
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
                    list = context.SanPham.Where(sp => sp.TinhTrang == "Không khoá")
                                            .OrderBy(sp => sp.MaSanPham)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .ToList();
                    break;
                case "masanpham-za":
                    list = context.SanPham.Where(sp => sp.TinhTrang == "Không khoá")
                                    .OrderByDescending(sp => sp.MaSanPham)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .ToList();
                    break;
                case "tensanpham-az":
                    list = context.SanPham.Where(sp => sp.TinhTrang == "Không khoá")
                                            .OrderBy(sp => sp.TenSanPham)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .ToList();
                    break;
                case "tensanpham-za":
                    list = context.SanPham.Where(sp => sp.TinhTrang == "Không khoá")
                                            .OrderByDescending(sp => sp.TenSanPham)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .ToList();
                    break;
                case "gia-asc":
                    list = context.SanPham.Where(sp => sp.TinhTrang == "Không khoá")
                                            .OrderBy(sp => sp.Gia)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .ToList();
                    break;
                case "gia-desc":
                    list = context.SanPham.Where(sp => sp.TinhTrang == "Không khoá")
                                            .OrderByDescending(sp => sp.Gia)
                                          .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .ToList();
                    break;
                case "moinhat":
                    list = context.SanPham.Where(sp => sp.TinhTrang == "Không khoá")
                                            .OrderByDescending(sp => sp.NgayDang)
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
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
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
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .ToList();
            }
            return list;
        }

        public List<SanPham> Filter(float minprice, float maxprice, int pagesize, int pagenumber)
        {
            List<SanPham> list = new List<SanPham>();
            list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice)
                                    .Where(sp => sp.TinhTrang == "Không khoá")
                                  .Include(sp => sp.IdHangSanPhamNavigation)
                                  .Include(sp => sp.IdTaiKhoanNavigation)
                                  .Skip((pagenumber - 1) * pagesize)
                                  .Take(pagesize)
                                  .ToList();
            return list;
        }

        public List<SanPham> Filter(float minprice, float maxprice)
        {
            List<SanPham> list = new List<SanPham>();
            list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice)
                                        .Where(sp => sp.TinhTrang == "Không khoá")
                                  .Include(sp => sp.IdHangSanPhamNavigation)
                                  .Include(sp => sp.IdTaiKhoanNavigation)
                                  .ToList();
            return list;
        }

        public List<SanPham> FilterAndSearch(float minprice, float maxprice, string search, string ploai, string mahang, int pagesize, int pagenumber)
        {
            List<SanPham> list = new List<SanPham>();
            if(search != null && search != "")
            {
                list = context.SanPham.Where(sp => (sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search)) &&
                                                   sp.Gia >= minprice && sp.Gia <= maxprice)
                                      .Where(sp => sp.TinhTrang == "Không khoá")
                                                   .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .ToList();
                return list;
            }
            if(ploai != null && ploai != "")
            {
                ploai = ploai == "Nam" ? "Nam" : "Nữ";
                list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.PhanLoai == ploai)
                                        .Where(sp => sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .ToList();
                return list;
            }
            if(mahang != null && mahang != "")
            {
                list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.IdHangSanPhamNavigation.MaHang == mahang)
                                      .Where(sp => sp.TinhTrang == "Không khoá")
                                    .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .ToList();
                return list;
            }
            return list;
        }

        public List<SanPham> FilterAndSearch(float minprice, float maxprice, string search, string ploai, string mahang)
        {
            List<SanPham> list = new List<SanPham>();
            if (search != null && search != "")
            {
                list = context.SanPham.Where(sp => (sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search)) &&
                                                   sp.Gia >= minprice && sp.Gia <= maxprice)
                                      .Where(sp => sp.TinhTrang == "Không khoá")
                                       .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .ToList();
                return list;
            }
            if (ploai != null && ploai != "")
            {
                ploai = ploai == "Nam" ? "Nam" : "Nữ";
                list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.PhanLoai == ploai)
                                       .Where(sp => sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .ToList();
                return list;
            }
            if (mahang != null && mahang != "")
            {
                list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.IdHangSanPhamNavigation.MaHang == mahang)
                                      .Where(sp => sp.TinhTrang == "Không khoá")
                                        .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .ToList();
                return list;
            }
            return list;
        }

        public List<SanPham> FilterAndSearchAndSort(float minprice, float maxprice, string search, string ploai, string mahang, string sortorder, int pagesize, int pagenumber)
        {
            List<SanPham> list = new List<SanPham>();
            if (search != null && search != "")
            {
                switch (sortorder)
                {
                    case "masanpham-az":
                        list = context.SanPham.Where(sp => (sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search)) &&
                                                   sp.Gia >= minprice && sp.Gia <= maxprice)
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
                                              .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.MaSanPham)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "masanpham-za":
                        list = context.SanPham.Where(sp => (sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search)) &&
                                                   sp.Gia >= minprice && sp.Gia <= maxprice)
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
                                              .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderByDescending(sp => sp.MaSanPham)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "tensanpham-az":
                        list = context.SanPham.Where(sp => (sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search)) &&
                                                   sp.Gia >= minprice && sp.Gia <= maxprice)
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
                                              .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.TenSanPham)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "tensanpham-za":
                        list = context.SanPham.Where(sp => (sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search)) &&
                                                   sp.Gia >= minprice && sp.Gia <= maxprice)
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
                                              .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderByDescending(sp => sp.TenSanPham)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "gia-asc":
                        list = context.SanPham.Where(sp => (sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search)) &&
                                                   sp.Gia >= minprice && sp.Gia <= maxprice)
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
                                              .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.Gia)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "gia-desc":
                        list = context.SanPham.Where(sp => (sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search)) &&
                                                   sp.Gia >= minprice && sp.Gia <= maxprice)
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
                                              .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderByDescending(sp => sp.Gia)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "moinhat":
                        list = context.SanPham.Where(sp => (sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search)) &&
                                                   sp.Gia >= minprice && sp.Gia <= maxprice)
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
                                              .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.NgayDang)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "banchay":
                        list = GetBanChay();
                        list = list.Where(sp => (sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search)) &&
                                                   sp.Gia >= minprice && sp.Gia <= maxprice)
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
                                              .OrderBy(sp => sp.NgayDang)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                }
                return list;
            }
            if (ploai != null && ploai != "")
            {
                ploai = ploai == "Nam" ? "Nam" : "Nữ";
                switch (sortorder)
                {
                    case "masanpham-az":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.PhanLoai == ploai)
                                                .Where(sp => sp.TinhTrang == "Không khoá")
                                              .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.MaSanPham)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "masanpham-za":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.PhanLoai == ploai)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderByDescending(sp => sp.MaSanPham)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "tensanpham-az":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.PhanLoai == ploai)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.TenSanPham)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "tensanpham-za":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.PhanLoai == ploai)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderByDescending(sp => sp.TenSanPham)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "gia-asc":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.PhanLoai == ploai)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.Gia)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "gia-desc":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.PhanLoai == ploai)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderByDescending(sp => sp.Gia)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "moinhat":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.PhanLoai == ploai)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.NgayDang)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "banchay":
                        list = GetBanChay();
                        list = list.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.PhanLoai == ploai)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                                              .OrderBy(sp => sp.NgayDang)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                }
                return list;
            }
            if (mahang != null && mahang != "")
            {
                switch (sortorder)
                {
                    case "masanpham-az":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.IdHangSanPhamNavigation.MaHang == mahang)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.MaSanPham)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "masanpham-za":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.IdHangSanPhamNavigation.MaHang == mahang)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderByDescending(sp => sp.MaSanPham)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "tensanpham-az":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.IdHangSanPhamNavigation.MaHang == mahang)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.TenSanPham)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "tensanpham-za":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.IdHangSanPhamNavigation.MaHang == mahang)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderByDescending(sp => sp.TenSanPham)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "gia-asc":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.IdHangSanPhamNavigation.MaHang == mahang)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.Gia)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "gia-desc":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.IdHangSanPhamNavigation.MaHang == mahang)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderByDescending(sp => sp.Gia)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "moinhat":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.IdHangSanPhamNavigation.MaHang == mahang)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.NgayDang)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                    case "banchay":
                        list = GetBanChay();
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.IdHangSanPhamNavigation.MaHang == mahang)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                                              .OrderBy(sp => sp.NgayDang)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                        break;
                }
                return list;
            }
            return list;
        }

        public List<SanPham> FilterAndSearchAndSort(float minprice, float maxprice, string search, string ploai, string mahang, string sortorder)
        {
            List<SanPham> list = new List<SanPham>();
            if (search != null && search != "")
            {
                switch (sortorder)
                {
                    case "masanpham-az":
                        list = context.SanPham.Where(sp => (sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search)) &&
                                                   sp.Gia >= minprice && sp.Gia <= maxprice)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                                                   .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.MaSanPham)
                                              .ToList();
                        break;
                    case "masanpham-za":
                        list = context.SanPham.Where(sp => (sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search)) &&
                                                   sp.Gia >= minprice && sp.Gia <= maxprice)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                                                   .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderByDescending(sp => sp.MaSanPham)
                                              .ToList();
                        break;
                    case "tensanpham-az":
                        list = context.SanPham.Where(sp => (sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search)) &&
                                                   sp.Gia >= minprice && sp.Gia <= maxprice)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                                                   .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.TenSanPham)
                                              .ToList();
                        break;
                    case "tensanpham-za":
                        list = context.SanPham.Where(sp => (sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search)) &&
                                                   sp.Gia >= minprice && sp.Gia <= maxprice)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                                                   .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderByDescending(sp => sp.TenSanPham)
                                              .ToList();
                        break;
                    case "gia-asc":
                        list = context.SanPham.Where(sp => (sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search)) &&
                                                   sp.Gia >= minprice && sp.Gia <= maxprice)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                                                   .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.Gia)
                                              .ToList();
                        break;
                    case "gia-desc":
                        list = context.SanPham.Where(sp => (sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search)) &&
                                                   sp.Gia >= minprice && sp.Gia <= maxprice)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                                                   .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderByDescending(sp => sp.Gia)
                                              .ToList();
                        break;
                    case "moinhat":
                        list = context.SanPham.Where(sp => (sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search)) &&
                                                   sp.Gia >= minprice && sp.Gia <= maxprice)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                                                   .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.NgayDang)
                                              .ToList();
                        break;
                    case "banchay":
                        list = GetBanChay();
                        list = list.Where(sp => (sp.MaSanPham.Contains(search) ||
                                                   sp.TenSanPham.Contains(search) ||
                                                   sp.IdTaiKhoanNavigation.TenShop.Contains(search) ||
                                                   sp.Mau.Contains(search)) &&
                                                   sp.Gia >= minprice && sp.Gia <= maxprice)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                                              .OrderBy(sp => sp.NgayDang)
                                              .ToList();
                        break;
                }
                return list;
            }
            if (ploai != null && ploai != "")
            {
                ploai = ploai == "Nam" ? "Nam" : "Nữ";
                switch (sortorder)
                {
                    case "masanpham-az":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.PhanLoai == ploai)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.MaSanPham)
                                              .ToList();
                        break;
                    case "masanpham-za":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.PhanLoai == ploai)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderByDescending(sp => sp.MaSanPham)
                                              .ToList();
                        break;
                    case "tensanpham-az":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.PhanLoai == ploai)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.TenSanPham)
                                              .ToList();
                        break;
                    case "tensanpham-za":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.PhanLoai == ploai)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderByDescending(sp => sp.TenSanPham)
                                              .ToList();
                        break;
                    case "gia-asc":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.PhanLoai == ploai)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.Gia)
                                              .ToList();
                        break;
                    case "gia-desc":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.PhanLoai == ploai)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderByDescending(sp => sp.Gia)
                                              .ToList();
                        break;
                    case "moinhat":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.PhanLoai == ploai)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.NgayDang)
                                              .ToList();
                        break;
                    case "banchay":
                        list = GetBanChay();
                        list = list.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.PhanLoai == ploai)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                                              .OrderBy(sp => sp.NgayDang)
                                              .ToList();
                        break;
                }
                return list;
            }
            if (mahang != null && mahang != "")
            {
                switch (sortorder)
                {
                    case "masanpham-az":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.IdHangSanPhamNavigation.MaHang == mahang)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.MaSanPham)
                                              .ToList();
                        break;
                    case "masanpham-za":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.IdHangSanPhamNavigation.MaHang == mahang)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderByDescending(sp => sp.MaSanPham)
                                              .ToList();
                        break;
                    case "tensanpham-az":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.IdHangSanPhamNavigation.MaHang == mahang)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.TenSanPham)
                                              .ToList();
                        break;
                    case "tensanpham-za":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.IdHangSanPhamNavigation.MaHang == mahang)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderByDescending(sp => sp.TenSanPham)
                                              .ToList();
                        break;
                    case "gia-asc":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.IdHangSanPhamNavigation.MaHang == mahang)
                                             .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.Gia)
                                              .ToList();
                        break;
                    case "gia-desc":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.IdHangSanPhamNavigation.MaHang == mahang)
                                             .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderByDescending(sp => sp.Gia)
                                              .ToList();
                        break;
                    case "moinhat":
                        list = context.SanPham.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.IdHangSanPhamNavigation.MaHang == mahang)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                            .Include(sp => sp.IdTaiKhoanNavigation)
                                              .Include(sp => sp.IdHangSanPhamNavigation)
                                              .OrderBy(sp => sp.NgayDang)
                                              .ToList();
                        break;
                    case "banchay":
                        list = GetBanChay();
                        list = list.Where(sp => sp.Gia >= minprice && sp.Gia <= maxprice && sp.IdHangSanPhamNavigation.MaHang == mahang)
                                              .Where(sp => sp.TinhTrang == "Không khoá")
                                              .OrderBy(sp => sp.NgayDang)
                                              .ToList();
                        break;
                }
                return list;
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
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
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
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
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
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
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
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
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
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
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
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
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
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
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
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
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
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
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
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
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
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
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
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
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
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
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
                                                   .Where(sp => sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderByDescending(sp => sp.NgayDang)
                                      .ToList();
                        break;
                }
            }
            return list;
        }

        public List<SanPham> ClassifyAndSort(string ploai, string sortorder, int pagesize, int pagenumber)
        {
            List<SanPham> list = new List<SanPham>();
            if (ploai == null)
            {
                list = GetSanPhams(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "masanpham-az":
                        list = context.SanPham.Where(sp => sp.PhanLoai == ploai &&sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .OrderBy(sp => sp.MaSanPham)
                                      .ToList();
                        break;
                    case "masanpham-za":
                        list = context.SanPham.Where(sp => sp.PhanLoai == ploai && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .OrderByDescending(sp => sp.MaSanPham)
                                      .ToList();
                        break;
                    case "tensanpham-az":
                        list = context.SanPham.Where(sp => sp.PhanLoai == ploai && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .OrderBy(sp => sp.TenSanPham)
                                      .ToList();
                        break;
                    case "tensanpham-za":
                        list = context.SanPham.Where(sp => sp.PhanLoai == ploai && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .OrderByDescending(sp => sp.TenSanPham)
                                      .ToList();
                        break;
                    case "gia-asc":
                        list = context.SanPham.Where(sp => sp.PhanLoai == ploai && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .OrderBy(sp => sp.Gia)
                                      .ToList();
                        break;
                    case "gia-desc":
                        list = context.SanPham.Where(sp => sp.PhanLoai == ploai && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .OrderByDescending(sp => sp.Gia)
                                      .ToList();
                        break;
                    case "moinhat":
                        list = context.SanPham.Where(sp => sp.PhanLoai == ploai && sp.TinhTrang == "Không khoá")
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

        public List<SanPham> ClassifyAndSort(string ploai, string sortorder, int pagesize)
        {
            List<SanPham> list = new List<SanPham>();
            if (ploai == null)
            {
                list = GetSanPhams(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "masanpham-az":
                        list = context.SanPham.Where(sp => sp.PhanLoai == ploai && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderBy(sp => sp.MaSanPham)
                                      .ToList();
                        break;
                    case "masanpham-za":
                        list = context.SanPham.Where(sp => sp.PhanLoai == ploai && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderByDescending(sp => sp.MaSanPham)
                                      .ToList();
                        break;
                    case "tensanpham-az":
                        list = context.SanPham.Where(sp => sp.PhanLoai == ploai && sp.TinhTrang == "Không khoá") 
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderBy(sp => sp.TenSanPham)
                                      .ToList();
                        break;
                    case "tensanpham-za":
                        list = context.SanPham.Where(sp => sp.PhanLoai == ploai && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderByDescending(sp => sp.TenSanPham)
                                      .ToList();
                        break;
                    case "gia-asc":
                        list = context.SanPham.Where(sp => sp.PhanLoai == ploai && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderBy(sp => sp.Gia)
                                      .ToList();
                        break;
                    case "gia-desc":
                        list = context.SanPham.Where(sp => sp.PhanLoai == ploai && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderByDescending(sp => sp.Gia)
                                      .ToList();
                        break;
                    case "moinhat":
                        list = context.SanPham.Where(sp => sp.PhanLoai == ploai && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderByDescending(sp => sp.NgayDang)
                                      .ToList();
                        break;
                }
            }
            return list;
        }

        public List<SanPham> BrandAndSort(string mahang, string sortorder, int pagesize, int pagenumber)
        {
            List<SanPham> list = new List<SanPham>();
            if (mahang == null)
            {
                list = GetSanPhams(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "masanpham-az":
                        list = context.SanPham.Where(sp => sp.IdHangSanPhamNavigation.MaHang == mahang && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .OrderBy(sp => sp.MaSanPham)
                                      .ToList();
                        break;
                    case "masanpham-za":
                        list = context.SanPham.Where(sp => sp.IdHangSanPhamNavigation.MaHang == mahang && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .OrderByDescending(sp => sp.MaSanPham)
                                      .ToList();
                        break;
                    case "tensanpham-az":
                        list = context.SanPham.Where(sp => sp.IdHangSanPhamNavigation.MaHang == mahang && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .OrderBy(sp => sp.TenSanPham)
                                      .ToList();
                        break;
                    case "tensanpham-za":
                        list = context.SanPham.Where(sp => sp.IdHangSanPhamNavigation.MaHang == mahang && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .OrderByDescending(sp => sp.TenSanPham)
                                      .ToList();
                        break;
                    case "gia-asc":
                        list = context.SanPham.Where(sp => sp.IdHangSanPhamNavigation.MaHang == mahang && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .OrderBy(sp => sp.Gia)
                                      .ToList();
                        break;
                    case "gia-desc":
                        list = context.SanPham.Where(sp => sp.IdHangSanPhamNavigation.MaHang == mahang && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .OrderByDescending(sp => sp.Gia)
                                      .ToList();
                        break;
                    case "moinhat":
                        list = context.SanPham.Where(sp => sp.IdHangSanPhamNavigation.MaHang == mahang && sp.TinhTrang == "Không khoá")
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

        public List<SanPham> BrandAndSort(string mahang, string sortorder, int pagesize)
        {
            List<SanPham> list = new List<SanPham>();
            if (mahang == null)
            {
                list = GetSanPhams(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "masanpham-az":
                        list = context.SanPham.Where(sp => sp.IdHangSanPhamNavigation.MaHang == mahang && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderBy(sp => sp.MaSanPham)
                                      .ToList();
                        break;
                    case "masanpham-za":
                        list = context.SanPham.Where(sp => sp.IdHangSanPhamNavigation.MaHang == mahang && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderByDescending(sp => sp.MaSanPham)
                                      .ToList();
                        break;
                    case "tensanpham-az":
                        list = context.SanPham.Where(sp => sp.IdHangSanPhamNavigation.MaHang == mahang && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderBy(sp => sp.TenSanPham)
                                      .ToList();
                        break;
                    case "tensanpham-za":
                        list = context.SanPham.Where(sp => sp.IdHangSanPhamNavigation.MaHang == mahang && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderByDescending(sp => sp.TenSanPham)
                                      .ToList();
                        break;
                    case "gia-asc":
                        list = context.SanPham.Where(sp => sp.IdHangSanPhamNavigation.MaHang == mahang && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderBy(sp => sp.Gia)
                                      .ToList();
                        break;
                    case "gia-desc":
                        list = context.SanPham.Where(sp => sp.IdHangSanPhamNavigation.MaHang == mahang && sp.TinhTrang == "Không khoá")
                                      .Include(sp => sp.IdTaiKhoanNavigation)
                                      .Include(sp => sp.IdHangSanPhamNavigation)
                                      .OrderByDescending(sp => sp.Gia)
                                      .ToList();
                        break;
                    case "moinhat":
                        list = context.SanPham.Where(sp => sp.IdHangSanPhamNavigation.MaHang == mahang && sp.TinhTrang == "Không khoá")
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
