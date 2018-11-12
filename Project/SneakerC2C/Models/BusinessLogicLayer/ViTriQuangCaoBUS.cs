using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.BusinessLogicLayer
{
    public class ViTriQuangcaoBUS
    {
        private readonly QLBanGiayContext context;

        public ViTriQuangcaoBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public ViTriQuangcaoBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public List<ViTriQuangcao> GetViTriQuangcaos()
        {
            List<ViTriQuangcao> list = context.ViTriQuangcao.OrderBy(gh => gh.MaViTri)
                .Include(gh=>gh.IdTrangNavigation)
                .ToList();
            return list;
        }

        public List<ViTriQuangcao> GetViTriQuangcaos(int pagenumber, int pagesize)
        {
            List<ViTriQuangcao> list = context.ViTriQuangcao.OrderBy(gh => gh.MaViTri)
                                                  .Skip((pagenumber - 1) * pagesize)
                                                  .Take(pagesize)
                                                  .Include(l=>l.IdTrangNavigation)
                                                  .ToList();
            return list;
        }

        public string CreateViTriQuangcao(string ma, string ten, string trangquangcao, double dongia, string chuthich)
        {
            ViTriQuangcao vitri;
            TrangQuangCao trang;
            
            //Kiểm tra
            //Tên đăng nhập
            vitri = context.ViTriQuangcao.Where(gh => gh.MaViTri == ma).SingleOrDefault();
            if (vitri != null)
            {
                return "Vị trí đã tồn tại";
            }     
            //Thêm
            vitri = new ViTriQuangcao();
            vitri.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            vitri.MaViTri = ma;
            vitri.TenViTri = ten;
            vitri.IdTrang = Guid.Parse(trangquangcao);
            
            vitri.DonGia = dongia;
            vitri.ChuThich = chuthich;
            vitri.TinhTrang = "Không khoá";

            context.ViTriQuangcao.Add(vitri);
            context.SaveChanges();
            return "Thêm thành công";
        }

        public string EditViTriQuangcao(string ma, string ten, string trangquangcao, double dongia, string chuthich)
        {
            ViTriQuangcao vitri = new ViTriQuangcao();
            //Sửa
            vitri = context.ViTriQuangcao.Where(gh => gh.MaViTri == ma).SingleOrDefault();
            vitri.TenViTri = ten;
            vitri.IdTrang = Guid.Parse(trangquangcao);
            vitri.DonGia = dongia;
            vitri.ChuThich = chuthich;
            context.SaveChanges();
            return "Sửa thành công";
        }

        public string LockViTriQuangcao(string ma)
        {
            ViTriQuangcao vitri = context.ViTriQuangcao.Where(gh => gh.MaViTri == ma).SingleOrDefault();
            vitri.TinhTrang = "Khoá";
            context.SaveChanges();
            return "Khoá thành công";
        }

        public string UnlockViTriQuangcao(string ma)
        {
            ViTriQuangcao vitri = context.ViTriQuangcao.Where(gh => gh.MaViTri == ma).SingleOrDefault();
            vitri.TinhTrang = "Không khoá";
            context.SaveChanges();
            return "Mở khoá thành công";
        }

        public List<ViTriQuangcao> Sort(string sortorder, int pagesize, int pagenumber)
        {
            List<ViTriQuangcao> list = new List<ViTriQuangcao>();
            switch (sortorder)
            {
                case "tenvitri-az":
                    list = context.ViTriQuangcao.OrderBy(gh => gh.TenViTri)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(l => l.IdTrangNavigation)
                                           .ToList();
                    break;
                case "tenvitri-za":
                    list = context.ViTriQuangcao.OrderByDescending(gh => gh.TenViTri)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(l => l.IdTrangNavigation)
                                           .ToList();
                    break;

                case "gia-asc":
                    list = context.ViTriQuangcao.OrderBy(gh => gh.DonGia)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(l => l.IdTrangNavigation)
                                           .ToList();
                    break;
                case "gia-desc":
                    list = context.ViTriQuangcao.OrderByDescending(gh => gh.DonGia)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(l => l.IdTrangNavigation)
                                           .ToList();
                    break;

            }
            return list;
        }

        public List<ViTriQuangcao> Sort(string sortorder)
        {
            List<ViTriQuangcao> list = new List<ViTriQuangcao>();
            switch (sortorder)
            {
                case "tenvitri-az":
                    list = context.ViTriQuangcao.OrderBy(gh => gh.TenViTri)
                        .Include(l => l.IdTrangNavigation)
                        .ToList();
                    break;
                case "tenvitri-za":
                    list = context.ViTriQuangcao.OrderByDescending(gh => gh.TenViTri)
                        .Include(l => l.IdTrangNavigation)
                        .ToList();
                    break;
                case "gia-asc":
                    list = context.ViTriQuangcao.OrderBy(gh => gh.DonGia)
                        .Include(l => l.IdTrangNavigation)
                        .ToList();
                    break;
                case "gia-desc":
                    list = context.ViTriQuangcao.OrderByDescending(gh => gh.DonGia)
                        .Include(l => l.IdTrangNavigation)
                        .ToList();
                    break;

            }
            return list;
        }

        public List<ViTriQuangcao> Search(string search, int pagesize, int pagenumber)
        {
            List<ViTriQuangcao> list = new List<ViTriQuangcao>();
            if (search == null)
            {
                list = GetViTriQuangcaos(1, pagesize);
            }
            else
            {
                list = context.ViTriQuangcao.Where(gh => gh.MaViTri.Contains(search) ||
                                                    gh.TenViTri.Contains(search) ||
                                                    gh.IdTrangNavigation.TenTrang.Contains(search) ||
                                                            gh.ChuThich.Contains(search))
                                       .Skip((pagenumber - 1) * pagesize)
                                       .Take(pagesize)
                                       .Include(l => l.IdTrangNavigation)
                                       .ToList();
            }
            return list;
        }

        public List<ViTriQuangcao> Search(string search, int pagesize)
        {
            List<ViTriQuangcao> list = new List<ViTriQuangcao>();
            if (search == null)
            {
                list = GetViTriQuangcaos(1, pagesize);
            }
            else
            {
                list = context.ViTriQuangcao.Where(gh => gh.MaViTri.Contains(search) ||
                                                    gh.TenViTri.Contains(search) ||
                                                    gh.IdTrangNavigation.TenTrang.Contains(search)||
                                                            gh.ChuThich.Contains(search))
                                                            .Include(l => l.IdTrangNavigation)
                                       .ToList();
            }
            return list;
        }

        public List<ViTriQuangcao> SearchAndSort(string search, string sortorder, int pagesize, int pagenumber)
        {
            List<ViTriQuangcao> list = new List<ViTriQuangcao>();
            if (search == null)
            {
                list = GetViTriQuangcaos(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "tenvitri-az":
                        list = context.ViTriQuangcao.Where(gh => gh.MaViTri.Contains(search) ||
                                                            gh.TenViTri.Contains(search) ||
                                                            gh.IdTrangNavigation.TenTrang.Contains(search) ||
                                                            gh.ChuThich.Contains(search))
                                               .OrderBy(gh => gh.TenViTri)
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .Include(l => l.IdTrangNavigation)
                                               .ToList();
                        break;
                    case "tenvitri-za":
                        list = context.ViTriQuangcao.Where(gh => gh.MaViTri.Contains(search) ||
                                                            gh.TenViTri.Contains(search) ||
                                                            gh.IdTrangNavigation.TenTrang.Contains(search) ||
                                                            gh.ChuThich.Contains(search))
                                               .OrderByDescending(gh => gh.TenViTri)
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .Include(l => l.IdTrangNavigation)
                                               .ToList();
                        break;
                    case "gia-asc":
                        list = context.ViTriQuangcao.Where(gh => gh.MaViTri.Contains(search) ||
                                                            gh.TenViTri.Contains(search) ||
                                                            gh.IdTrangNavigation.TenTrang.Contains(search) ||
                                                            gh.ChuThich.Contains(search))
                                               .OrderBy(gh => gh.DonGia)
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .Include(l => l.IdTrangNavigation)
                                               .ToList();
                        break;
                    case "gia-desc":
                        list = context.ViTriQuangcao.Where(gh => gh.MaViTri.Contains(search) ||
                                                            gh.TenViTri.Contains(search) ||
                                                            gh.IdTrangNavigation.TenTrang.Contains(search) ||
                                                            gh.ChuThich.Contains(search))
                                               .OrderByDescending(gh => gh.DonGia)
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .Include(l => l.IdTrangNavigation)
                                               .ToList();
                        break;

                }
            }
            return list;
        }

        public List<ViTriQuangcao> SearchAndSort(string search, string sortorder, int pagesize)
        {
            List<ViTriQuangcao> list = new List<ViTriQuangcao>();
            if (search == null)
            {
                list = GetViTriQuangcaos(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "tenvitri-az":
                        list = context.ViTriQuangcao.Where(gh => gh.MaViTri.Contains(search) ||
                                                            gh.TenViTri.Contains(search) ||
                                                            gh.IdTrangNavigation.TenTrang.Contains(search) ||
                                                            gh.ChuThich.Contains(search))
                                               .OrderBy(gh => gh.TenViTri)
                                               .Include(l => l.IdTrangNavigation)
                                               .ToList();
                        break;
                    case "tenvitri-za":
                        list = context.ViTriQuangcao.Where(gh => gh.MaViTri.Contains(search) ||
                                                            gh.TenViTri.Contains(search) ||
                                                            gh.IdTrangNavigation.TenTrang.Contains(search) ||
                                                            gh.ChuThich.Contains(search))
                                               .OrderByDescending(gh => gh.TenViTri)
                                               .Include(l => l.IdTrangNavigation)
                                               .ToList();
                        break;
                    case "gia-asc":
                        list = context.ViTriQuangcao.Where(gh => gh.MaViTri.Contains(search) ||
                                                            gh.TenViTri.Contains(search) ||
                                                            gh.IdTrangNavigation.TenTrang.Contains(search) ||
                                                            gh.ChuThich.Contains(search))
                                               .OrderBy(gh => gh.DonGia)
                                               .Include(l => l.IdTrangNavigation)
                                               .ToList();
                        break;
                    case "gia-desc":
                        list = context.ViTriQuangcao.Where(gh => gh.MaViTri.Contains(search) ||
                                                            gh.TenViTri.Contains(search) ||
                                                            gh.IdTrangNavigation.TenTrang.Contains(search) ||
                                                            gh.ChuThich.Contains(search))
                                               .OrderByDescending(gh => gh.DonGia)
                                               .Include(l => l.IdTrangNavigation)
                                               .ToList();
                        break;

                }
            }
            return list;
        }
    }
}
