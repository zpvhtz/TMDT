using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.BusinessLogicLayer;
using Models.Database;

namespace SneakerC2C.Areas.Webmaster.Controllers
{
    [Area("Webmaster")]
    public class SanPhamController : BaseController
    {
        const int pageSize = 10;
        int pageNumber = 1;
        private readonly QLBanGiayContext ctx;
        //public PaginatedList<SanPham> Sp { get; set; }
        public SanPhamController(QLBanGiayContext context)
        {
            ctx = context;
        }
        public string NameSort { get; set; }
        public string GiaSort { get; set; }
        public string CurrentFilter { get; set; }
       public string CurrentSort { get; set; }
        public List<SanPham> GetSanPhams()
        {
            List<SanPham> list = ctx.SanPham.OrderByDescending(sp => sp.NgayDang)
                                            .Include(tk => tk.IdTaiKhoanNavigation)
                                            .Include(h => h.IdHangSanPhamNavigation)
                                            .ToList();
            return list;
        }
        public List<SanPham> GetSanPhams(int pagenumber, int pagesize)
        {
            List<SanPham> list=ctx.SanPham.OrderByDescending(sp=>sp.NgayDang)
                                    .Include(s => s.IdTaiKhoanNavigation)
                                    .Include(s => s.IdHangSanPhamNavigation)
                                    .Skip((pagenumber - 1) * pagesize)
                                     .Take(pagesize)
                                    .ToList();
            return list;
        }
        public IActionResult Index(string thongbao,int? pagenumber)
        {
            if (thongbao != null)
            {
                ViewBag.ThongBao = thongbao;
            }
            pageNumber = pagenumber ?? 1;
            List<SanPham> list = GetSanPhams(pageNumber, pageSize);
            List<SanPham> tong =GetSanPhams();
            //List<SanPham> list = ctx.SanPham.Include(tk => tk.IdTaiKhoanNavigation)
            //                                .Include(h => h.IdHangSanPhamNavigation)
            //                                 .ToList();
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.Hang = hang;
            ViewBag.NameSort = "";
            ViewBag.GiaSort = "Gia";
            ViewBag.ShopSort = "Shop";
            ViewBag.TrangThai = "index";
            return View(list);
        }
        public IActionResult Duyet(string ma)
        {
            SanPham sp = ctx.SanPham.Where(h => h.MaSanPham == ma).SingleOrDefault();
            sp.TinhTrang = "Không khoá";
            ctx.SaveChanges();
            return RedirectToAction("Index", "SanPham");
        }
        public IActionResult LockSP(string ma)
        {
            SanPham sp = ctx.SanPham.Where(h => h.MaSanPham == ma).SingleOrDefault();
            sp.TinhTrang = "Khoá";
            ctx.SaveChanges();

            List<SizeSanPham> listsize = ctx.SizeSanPham.Where(s => s.IdSanPhamNavigation.MaSanPham == ma)
                                                        .Include(s => s.IdSanPhamNavigation)
                                                        .ToList();

            foreach(var item in listsize)
            {
                item.TinhTrang = "Khoá";
            }
            ctx.SaveChanges();

            return RedirectToAction("Index", "SanPham");
        }
        public IActionResult UnLockSP(string ma)
        {
            SanPham sp = ctx.SanPham.Where(h => h.MaSanPham == ma).SingleOrDefault();
            sp.TinhTrang = "Không khoá";
            ctx.SaveChanges();

            List<SizeSanPham> listsize = ctx.SizeSanPham.Where(s => s.IdSanPhamNavigation.MaSanPham == ma)
                                                        .Include(s => s.IdSanPhamNavigation)
                                                        .ToList();

            foreach (var item in listsize)
            {
                item.TinhTrang = "Không khoá";
            }
            ctx.SaveChanges();

            return RedirectToAction("Index", "SanPham");
        }
        public IActionResult GetSizeSanPham(string masp)
        {
            List<SizeSanPham> listsize = ctx.SizeSanPham.Where(ssp => ssp.IdSanPhamNavigation.MaSanPham == masp)
                                                        .Include(ssp => ssp.IdSanPhamNavigation)
                                                        .ToList();
            return PartialView("pSizeSanPham", listsize);
        }

        public IActionResult Sort(string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            SanPhamBUS sanphambus = new SanPhamBUS();
            List<SanPham> list = sanphambus.Sort(sortorder, pageSize, pageNumber);
            List<SanPham> tong = sanphambus.Sort(sortorder);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "sort";
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }

        public IActionResult Search(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            SanPhamBUS sanphambus = new SanPhamBUS();
            List<SanPham> list = sanphambus.Search(search, pageSize, pageNumber);
            List<SanPham> tong = sanphambus.Search(search, pageSize);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            return View("Index", list);
        }

        public IActionResult SearchAndSort(string search, string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            SanPhamBUS sanphambus = new SanPhamBUS();
            List<SanPham> list = sanphambus.SearchAndSort(search, sortorder, pageSize, pageNumber);
            List<SanPham> tong = sanphambus.SearchAndSort(search, sortorder, pageSize);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "searchandsort";
            ViewBag.Search = search;
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }

        public int TongTrang(List<SanPham> list)
        {
            return ((list.Count / pageSize) + 1);
        }
        
    }

}