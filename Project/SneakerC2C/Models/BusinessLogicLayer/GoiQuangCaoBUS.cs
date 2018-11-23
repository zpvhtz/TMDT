using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.BusinessLogicLayer
{
    public class GoiQuangCaoBUS
    {
        private readonly QLBanGiayContext context;

        public GoiQuangCaoBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public GoiQuangCaoBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public List<GoiQuangCao> GetGoiQuangCaos()
        {
            List<GoiQuangCao> list = context.GoiQuangCao.OrderBy(gh => gh.MaGoiQuangCao)
                .Include(gh => gh.IdViTriNavigation)
                .ToList();
            return list;
        }

        public List<GoiQuangCao> GetGoiQuangCaos(int pagenumber, int pagesize)
        {
            List<GoiQuangCao> list = context.GoiQuangCao.OrderBy(gh => gh.MaGoiQuangCao)
                                                  .Skip((pagenumber - 1) * pagesize)
                                                  .Take(pagesize)
                                                  .Include(l => l.IdViTriNavigation)
                                                  .ToList();
            return list;
        }

        public string CreateGoiQuangCao(string ma, string vitriquangcao, double tongtien, int thoiluong)
        {
            GoiQuangCao goi;
            ViTriQuangcao vitri;

            //Kiểm tra
            //Tên đăng nhập
            goi = context.GoiQuangCao.Where(gh => gh.MaGoiQuangCao == ma).SingleOrDefault();
            if (goi != null)
            {
                return "Gói đã tồn tại";
            }
            //Thêm
            goi = new GoiQuangCao();
            goi.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            goi.MaGoiQuangCao = ma;

            goi.IdViTri = Guid.Parse(vitriquangcao);

            goi.TongTien = tongtien;
            goi.ThoiLuong = thoiluong;
            goi.TinhTrang = "Không khoá";

            context.GoiQuangCao.Add(goi);
            context.SaveChanges();
            return "Thêm thành công";
        }

        public string EditGoiQuangCao(string ma, string vitriquangcao, double tongtien, int thoiluong)
        {
            GoiQuangCao goi = new GoiQuangCao();
            //Sửa
            goi = context.GoiQuangCao.Where(gh => gh.MaGoiQuangCao == ma).SingleOrDefault();

            goi.IdViTri = Guid.Parse(vitriquangcao);
            goi.TongTien = tongtien;
            goi.ThoiLuong = thoiluong;
            context.SaveChanges();
            return "Sửa thành công";
        }

        public string LockGoiQuangCao(string ma)
        {
            GoiQuangCao goi = context.GoiQuangCao.Where(gh => gh.MaGoiQuangCao == ma).SingleOrDefault();
            goi.TinhTrang = "Khoá";
            context.SaveChanges();
            return "Khoá thành công";
        }

        public string UnlockGoiQuangCao(string ma)
        {
            GoiQuangCao goi = context.GoiQuangCao.Where(gh => gh.MaGoiQuangCao == ma).SingleOrDefault();
            goi.TinhTrang = "Không khoá";
            context.SaveChanges();
            return "Mở khoá thành công";
        }

        public List<GoiQuangCao> Sort(string sortorder, int pagesize, int pagenumber)
        {
            List<GoiQuangCao> list = new List<GoiQuangCao>();
            switch (sortorder)
            {
                case "tenvitri-az":
                    list = context.GoiQuangCao.OrderBy(gh => gh.IdViTriNavigation.TenViTri)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(l => l.IdViTriNavigation)
                                           .ToList();
                    break;
                case "tenvitri-za":
                    list = context.GoiQuangCao.OrderByDescending(gh => gh.IdViTriNavigation.TenViTri)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(l => l.IdViTriNavigation)
                                           .ToList();
                    break;

                case "gia-asc":
                    list = context.GoiQuangCao.OrderBy(gh => gh.TongTien)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(l => l.IdViTriNavigation)
                                           .ToList();
                    break;
                case "gia-desc":
                    list = context.GoiQuangCao.OrderByDescending(gh => gh.TongTien)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(l => l.IdViTriNavigation)
                                           .ToList();
                    break;

            }
            return list;
        }

        public List<GoiQuangCao> Sort(string sortorder)
        {
            List<GoiQuangCao> list = new List<GoiQuangCao>();
            switch (sortorder)
            {
                case "tenvitri-az":
                    list = context.GoiQuangCao.OrderBy(gh => gh.IdViTriNavigation.TenViTri)
                        .Include(l => l.IdViTriNavigation)
                        .ToList();
                    break;
                case "tenvitri-za":
                    list = context.GoiQuangCao.OrderByDescending(gh => gh.IdViTriNavigation.TenViTri)
                        .Include(l => l.IdViTriNavigation)
                        .ToList();
                    break;
                case "gia-asc":
                    list = context.GoiQuangCao.OrderBy(gh => gh.TongTien)
                        .Include(l => l.IdViTriNavigation)
                        .ToList();
                    break;
                case "gia-desc":
                    list = context.GoiQuangCao.OrderByDescending(gh => gh.TongTien)
                        .Include(l => l.IdViTriNavigation)
                        .ToList();
                    break;

            }
            return list;
        }

        public List<GoiQuangCao> Search(string search, int pagesize, int pagenumber)
        {
            List<GoiQuangCao> list = new List<GoiQuangCao>();
            if (search == null)
            {
                list = GetGoiQuangCaos(1, pagesize);
            }
            else
            {
                list = context.GoiQuangCao.Where(gh => gh.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdViTriNavigation.TenViTri.Contains(search))

                                       .Skip((pagenumber - 1) * pagesize)
                                       .Take(pagesize)
                                       .Include(l => l.IdViTriNavigation)
                                       .ToList();
            }
            return list;
        }

        public List<GoiQuangCao> Search(string search, int pagesize)
        {
            List<GoiQuangCao> list = new List<GoiQuangCao>();
            if (search == null)
            {
                list = GetGoiQuangCaos(1, pagesize);
            }
            else
            {
                list = context.GoiQuangCao.Where(gh => gh.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdViTriNavigation.TenViTri.Contains(search))
                                                            .Include(l => l.IdViTriNavigation)
                                       .ToList();
            }
            return list;
        }

        public List<GoiQuangCao> SearchAndSort(string search, string sortorder, int pagesize, int pagenumber)
        {
            List<GoiQuangCao> list = new List<GoiQuangCao>();
            if (search == null)
            {
                list = GetGoiQuangCaos(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "tenvitri-az":
                        list = context.GoiQuangCao.Where(gh => gh.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdViTriNavigation.TenViTri.Contains(search))

                                               .OrderBy(gh => gh.IdViTriNavigation.TenViTri)
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .Include(l => l.IdViTriNavigation)
                                               .ToList();
                        break;
                    case "tenvitri-za":
                        list = context.GoiQuangCao.Where(gh => gh.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdViTriNavigation.TenViTri.Contains(search))

                                               .OrderByDescending(gh => gh.IdViTriNavigation.TenViTri)
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .Include(l => l.IdViTriNavigation)
                                               .ToList();
                        break;
                    case "gia-asc":
                        list = context.GoiQuangCao.Where(gh => gh.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdViTriNavigation.TenViTri.Contains(search))

                                               .OrderBy(gh => gh.TongTien)
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .Include(l => l.IdViTriNavigation)
                                               .ToList();
                        break;
                    case "gia-desc":
                        list = context.GoiQuangCao.Where(gh => gh.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdViTriNavigation.TenViTri.Contains(search))

                                               .OrderByDescending(gh => gh.TongTien)
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .Include(l => l.IdViTriNavigation)
                                               .ToList();
                        break;

                }
            }
            return list;
        }

        public List<GoiQuangCao> SearchAndSort(string search, string sortorder, int pagesize)
        {
            List<GoiQuangCao> list = new List<GoiQuangCao>();
            if (search == null)
            {
                list = GetGoiQuangCaos(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "tenvitri-az":
                        list = context.GoiQuangCao.Where(gh => gh.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdViTriNavigation.TenViTri.Contains(search))

                                               .OrderBy(gh => gh.IdViTriNavigation.TenViTri)
                                               .Include(l => l.IdViTriNavigation)
                                               .ToList();
                        break;
                    case "tenvitri-za":
                        list = context.GoiQuangCao.Where(gh => gh.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdViTriNavigation.TenViTri.Contains(search))

                                               .OrderByDescending(gh => gh.IdViTriNavigation.TenViTri)
                                               .Include(l => l.IdViTriNavigation)
                                               .ToList();
                        break;
                    case "gia-asc":
                        list = context.GoiQuangCao.Where(gh => gh.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdViTriNavigation.TenViTri.Contains(search))

                                               .OrderBy(gh => gh.TongTien)
                                               .Include(l => l.IdViTriNavigation)
                                               .ToList();
                        break;
                    case "gia-desc":
                        list = context.GoiQuangCao.Where(gh => gh.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdViTriNavigation.TenViTri.Contains(search))

                                               .OrderByDescending(gh => gh.TongTien)
                                               .Include(l => l.IdViTriNavigation)
                                               .ToList();
                        break;

                }
            }
            return list;
        }

    }
}
