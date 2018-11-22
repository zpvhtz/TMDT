using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.BusinessLogicLayer
{
    public class HangSanPhamBUS
    {
        private readonly QLBanGiayContext context;

        public HangSanPhamBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public HangSanPhamBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public List<HangSanPham> GetHangSanPhams()
        {
            List<HangSanPham> list = context.HangSanPham.OrderBy(h => h.MaHang).ToList();
            return list;
        }

        public List<HangSanPham> GetHangSanPhams(int pagenumber, int pagesize)
        {
            List<HangSanPham> list = context.HangSanPham.OrderBy(h => h.MaHang)
                                                        .Skip((pagenumber - 1) * pagesize)
                                                        .Take(pagesize)
                                                        .ToList();
            return list;
        }

        public List<HangSanPham> Sort(string sortorder, int pagesize, int pagenumber)
        {
            List<HangSanPham> list = new List<HangSanPham>();
            switch (sortorder)
            {
                case "mahang-az":
                    list = context.HangSanPham.OrderBy(h => h.MaHang)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                    break;
                case "mahang-za":
                    list = context.HangSanPham.OrderByDescending(h => h.MaHang)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                    break;
                case "tenhang-az":
                    list = context.HangSanPham.OrderBy(h => h.TenHang)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                    break;
                case "tenhang-za":
                    list = context.HangSanPham.OrderByDescending(h => h.TenHang)
                                              .Skip((pagenumber - 1) * pagesize)
                                              .Take(pagesize)
                                              .ToList();
                    break;
            }
            return list;
        }

        public List<HangSanPham> Sort(string sortorder)
        {
            List<HangSanPham> list = new List<HangSanPham>();
            switch (sortorder)
            {
                case "mahang-az":
                    list = context.HangSanPham.OrderBy(h => h.MaHang)
                                              .ToList();
                    break;
                case "mahang-za":
                    list = context.HangSanPham.OrderByDescending(h => h.MaHang)
                                              .ToList();
                    break;
                case "tenhang-az":
                    list = context.HangSanPham.OrderBy(h => h.TenHang)
                                              .ToList();
                    break;
                case "tenhang-za":
                    list = context.HangSanPham.OrderByDescending(h => h.TenHang)
                                              .ToList();
                    break;
            }
            return list;
        }

        public List<HangSanPham> Search(string search, int pagesize, int pagenumber)
        {
            List<HangSanPham> list = new List<HangSanPham>();
            if (search == null)
            {
                list = GetHangSanPhams(1, pagesize);
            }
            else
            {
                list = context.HangSanPham.Where(h => h.MaHang.Contains(search) ||
                                                      h.TenHang.Contains(search))
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
            }
            return list;
        }

        public List<HangSanPham> Search(string search, int pagesize)
        {
            List<HangSanPham> list = new List<HangSanPham>();
            if (search == null)
            {
                list = GetHangSanPhams(1, pagesize);
            }
            else
            {
                list = context.HangSanPham.Where(h => h.MaHang.Contains(search) ||
                                                      h.TenHang.Contains(search))
                                          .ToList();
            }
            return list;
        }

        public List<HangSanPham> SearchAndSort(string search, string sortorder, int pagesize, int pagenumber)
        {
            List<HangSanPham> list = new List<HangSanPham>();
            if (search == null)
            {
                list = GetHangSanPhams(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "mahang-az":
                        list = context.HangSanPham.Where(h => h.TenHang.Contains(search) ||
                                                              h.MaHang.Contains(search))
                                                  .OrderBy(h => h.MaHang)
                                                  .Skip((pagenumber - 1) * pagesize)
                                                  .Take(pagesize)
                                                  .ToList();
                        break;
                    case "mahang-za":
                        list = context.HangSanPham.Where(h => h.TenHang.Contains(search) ||
                                                              h.MaHang.Contains(search))
                                                  .OrderByDescending(h => h.MaHang)
                                                  .Skip((pagenumber - 1) * pagesize)
                                                  .Take(pagesize)
                                                  .ToList();
                        break;
                    case "tenhang-az":
                        list = context.HangSanPham.Where(h => h.TenHang.Contains(search) ||
                                                              h.MaHang.Contains(search))
                                                  .OrderBy(h => h.TenHang)
                                                  .Skip((pagenumber - 1) * pagesize)
                                                  .Take(pagesize)
                                                  .ToList();
                        break;
                    case "tenhang-za":
                        list = context.HangSanPham.Where(h => h.TenHang.Contains(search) ||
                                                              h.MaHang.Contains(search))
                                                  .OrderByDescending(h => h.TenHang)
                                                  .Skip((pagenumber - 1) * pagesize)
                                                  .Take(pagesize)
                                                  .ToList();
                        break;
                }
            }
            return list;
        }

        public List<HangSanPham> SearchAndSort(string search, string sortorder, int pagesize)
        {
            List<HangSanPham> list = new List<HangSanPham>();
            if (search == null)
            {
                list = GetHangSanPhams(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "mahang-az":
                        list = context.HangSanPham.Where(h => h.TenHang.Contains(search) ||
                                                              h.MaHang.Contains(search))
                                                  .OrderBy(h => h.MaHang)
                                                  .ToList();
                        break;
                    case "mahang-za":
                        list = context.HangSanPham.Where(h => h.TenHang.Contains(search) ||
                                                              h.MaHang.Contains(search))
                                                  .OrderByDescending(h => h.MaHang)
                                                  .ToList();
                        break;
                    case "tenhang-az":
                        list = context.HangSanPham.Where(h => h.TenHang.Contains(search) ||
                                                              h.MaHang.Contains(search))
                                                  .OrderBy(h => h.TenHang)
                                                  .ToList();
                        break;
                    case "tenhang-za":
                        list = context.HangSanPham.Where(h => h.TenHang.Contains(search) ||
                                                              h.MaHang.Contains(search))
                                                  .OrderByDescending(h => h.TenHang)
                                                  .ToList();
                        break;
                }
            }
            return list;
        }
    }
}
