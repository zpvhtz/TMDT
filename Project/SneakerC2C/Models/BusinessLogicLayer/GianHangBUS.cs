using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.BusinessLogicLayer
{
    public class GianHangBUS
    {
        private readonly QLBanGiayContext context;

        public GianHangBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public GianHangBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public List<GianHang> GetGianHangs()
        {
            List<GianHang> list = context.GianHang.Where(gh => gh.TinhTrang == "Không khoá")
                                                  .OrderBy(gh => gh.MaGianHang)
                                                  .ToList();
            return list;
        }

        public List<GianHang> GetGianHangs(int pagenumber, int pagesize)
        {
            List<GianHang> list = context.GianHang.OrderBy(gh => gh.MaGianHang)
                                                  .Skip((pagenumber - 1) * pagesize)
                                                  .Take(pagesize)
                                                  .ToList();
            return list;
        }

        public string CreateGianHang(string ma, string ten, float gia, int thoigian)
        {
            GianHang gianhang;
            //Kiểm tra
            //Tên đăng nhập
            gianhang = context.GianHang.Where(gh => gh.MaGianHang == ma).SingleOrDefault();
            if (gianhang != null)
            {
                return "Gian hàng đã tồn tại";
            }
            //Thêm
            gianhang = new GianHang();
            gianhang.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            gianhang.MaGianHang = ma;
            gianhang.TenGianHang = ten;
            gianhang.Gia = gia;
            gianhang.ThoiGian = thoigian;
            gianhang.TinhTrang = "Không khoá";
            context.GianHang.Add(gianhang);
            context.SaveChanges();
            return "Thêm thành công";
        }

        public string EditGianHang(string ma, string ten, float? gia, int? thoigian)
        {
            GianHang gianhang = new GianHang();
            //Sửa
            gianhang = context.GianHang.Where(gh => gh.MaGianHang == ma).SingleOrDefault();
            if (ten != null)
            {
                gianhang.TenGianHang = ten;
            }
            if (gia != null)
            {
                gianhang.Gia = gia;
            }
            if (thoigian != null)
            {
                gianhang.ThoiGian = thoigian;
            }
            context.SaveChanges();
            return "Sửa thành công";
        }

        public string LockGianHang(string magianhang)
        {
            GianHang gianhang = context.GianHang.Where(gh => gh.MaGianHang == magianhang).SingleOrDefault();
            gianhang.TinhTrang = "Khoá";
            context.SaveChanges();
            return "Khoá thành công";
        }

        public string UnlockGianHang(string magianhang)
        {
            GianHang gianhang = context.GianHang.Where(gh => gh.MaGianHang == magianhang).SingleOrDefault();
            gianhang.TinhTrang = "Không khoá";
            context.SaveChanges();
            return "Mở khoá thành công";
        }

        public double GetGiaTien(string id)
        {
            GianHang gianhang = context.GianHang.Where(gh => gh.Id == Guid.Parse(id)).SingleOrDefault();
            double giatien = gianhang.Gia ?? 0;
            return giatien;
        }

        public int GetThoiGian(string id)
        {
            GianHang gianhang = context.GianHang.Where(gh => gh.Id == Guid.Parse(id)).SingleOrDefault();
            int thoigian = gianhang.ThoiGian ?? 0;
            return thoigian;
        }

        public List<GianHang> Sort(string sortorder, int pagesize, int pagenumber)
        {
            List<GianHang> list = new List<GianHang>();
            switch (sortorder)
            {
                case "tengianhang-az":
                    list = context.GianHang.OrderBy(gh => gh.TenGianHang)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .ToList();
                    break;
                case "tengianhang-za":
                    list = context.GianHang.OrderByDescending(gh => gh.TenGianHang)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .ToList();
                    break;
                case "gia-asc":
                    list = context.GianHang.OrderBy(gh => gh.Gia)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .ToList();
                    break;
                case "gia-desc":
                    list = context.GianHang.OrderByDescending(gh => gh.Gia)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .ToList();
                    break;
            }
            return list;
        }

        public List<GianHang> Sort(string sortorder)
        {
            List<GianHang> list = new List<GianHang>();
            switch (sortorder)
            {
                case "tengianhang-az":
                    list = context.GianHang.OrderBy(gh => gh.TenGianHang).ToList();
                    break;
                case "tengianhang-za":
                    list = context.GianHang.OrderByDescending(gh => gh.TenGianHang).ToList();
                    break;
                case "gia-asc":
                    list = context.GianHang.OrderBy(gh => gh.Gia).ToList();
                    break;
                case "gia-desc":
                    list = context.GianHang.OrderByDescending(gh => gh.Gia).ToList();
                    break;
            }
            return list;
        }

        public List<GianHang> Search(string search, int pagesize, int pagenumber)
        {
            List<GianHang> list = new List<GianHang>();
            if (search == null)
            {
                list = GetGianHangs(1, pagesize);
            }
            else
            {
                list = context.GianHang.Where(gh => gh.MaGianHang.Contains(search) ||
                                                    gh.TenGianHang.Contains(search) ||
                                                    gh.TinhTrang.Contains(search))
                                       .Skip((pagenumber - 1) * pagesize)
                                       .Take(pagesize)
                                       .ToList();
            }
            return list;
        }

        public List<GianHang> Search(string search, int pagesize)
        {
            List<GianHang> list = new List<GianHang>();
            if (search == null)
            {
                list = GetGianHangs(1, pagesize);
            }
            else
            {
                list = context.GianHang.Where(gh => gh.MaGianHang.Contains(search) ||
                                                    gh.TenGianHang.Contains(search) ||
                                                    gh.TinhTrang.Contains(search))
                                       .ToList();
            }
            return list;
        }

        public List<GianHang> SearchAndSort(string search, string sortorder, int pagesize, int pagenumber)
        {
            List<GianHang> list = new List<GianHang>();
            if (search == null)
            {
                list = GetGianHangs(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "tengianhang-az":
                    list = context.GianHang.Where(gh => gh.MaGianHang.Contains(search) ||
                                                        gh.TenGianHang.Contains(search) ||
                                                        gh.TinhTrang.Contains(search))
                                           .OrderBy(gh => gh.TenGianHang)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .ToList();
                    break;
                    case "tengianhang-za":
                        list = context.GianHang.Where(gh => gh.MaGianHang.Contains(search) ||
                                                            gh.TenGianHang.Contains(search) ||
                                                            gh.TinhTrang.Contains(search))
                                               .OrderByDescending(gh => gh.TenGianHang)
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .ToList();
                    break;
                    case "gia-asc":
                        list = context.GianHang.Where(gh => gh.MaGianHang.Contains(search) ||
                                                            gh.TenGianHang.Contains(search) ||
                                                            gh.TinhTrang.Contains(search))
                                               .OrderBy(gh => gh.Gia)
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .ToList();
                    break;
                    case "gia-desc":
                        list = context.GianHang.Where(gh => gh.MaGianHang.Contains(search) ||
                                                            gh.TenGianHang.Contains(search) ||
                                                            gh.TinhTrang.Contains(search))
                                               .OrderByDescending(gh => gh.Gia)
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .ToList();
                    break;
                }
            }
            return list;
        }

        public List<GianHang> SearchAndSort(string search, string sortorder, int pagesize)
        {
            List<GianHang> list = new List<GianHang>();
            if (search == null)
            {
                list = GetGianHangs(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "tengianhang-az":
                        list = context.GianHang.Where(gh => gh.MaGianHang.Contains(search) ||
                                                            gh.TenGianHang.Contains(search) ||
                                                            gh.TinhTrang.Contains(search))
                                               .OrderBy(gh => gh.TenGianHang)
                                               .ToList();
                        break;
                    case "tengianhang-za":
                        list = context.GianHang.Where(gh => gh.MaGianHang.Contains(search) ||
                                                            gh.TenGianHang.Contains(search) ||
                                                            gh.TinhTrang.Contains(search))
                                               .OrderByDescending(gh => gh.TenGianHang)
                                               .ToList();
                        break;
                    case "gia-asc":
                        list = context.GianHang.Where(gh => gh.MaGianHang.Contains(search) ||
                                                            gh.TenGianHang.Contains(search) ||
                                                            gh.TinhTrang.Contains(search))
                                               .OrderBy(gh => gh.Gia)
                                               .ToList();
                        break;
                    case "gia-desc":
                        list = context.GianHang.Where(gh => gh.MaGianHang.Contains(search) ||
                                                            gh.TenGianHang.Contains(search) ||
                                                            gh.TinhTrang.Contains(search))
                                               .OrderByDescending(gh => gh.Gia)
                                               .ToList();
                        break;
                }
            }
            return list;
        }
    }
}
