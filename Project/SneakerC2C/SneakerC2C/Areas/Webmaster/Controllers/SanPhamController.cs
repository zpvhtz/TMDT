using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            List<SanPham> list = ctx.SanPham.Include(tk => tk.IdTaiKhoanNavigation)
                                            .Include(h => h.IdHangSanPhamNavigation)
                                            .ToList();
            return list;
        }
        public List<SanPham> GetSanPhams(int pagenumber, int pagesize)
        {
            List<SanPham> list=ctx.SanPham.Include(s => s.IdTaiKhoanNavigation)
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
            ViewBag.Hang = hang;
            ViewBag.NameSort = "";
            ViewBag.GiaSort = "Gia";
            ViewBag.ShopSort = "Shop";
            ViewBag.TrangThai = "index";
            return View(list);
        }

        public IActionResult GetSizeSanPham(string masp)
        {
            List<SizeSanPham> listsize = ctx.SizeSanPham.Where(ssp => ssp.IdSanPhamNavigation.MaSanPham == masp)
                                                        .Include(ssp => ssp.IdSanPhamNavigation)
                                                        .ToList();
            return PartialView("pSizeSanPham", listsize);
        }

        public IActionResult Search(string search)
        {
            List<SanPham> sp = ctx.SanPham.Where(s => s.MaSanPham.Contains(search) || s.TenSanPham.Contains(search) || s.IdTaiKhoanNavigation.TenShop.Contains(search) || s.Mau.Contains(search) || s.IdHangSanPhamNavigation.TenHang.Contains(search) || s.PhanLoai.Contains(search) || s.ChiTiet.Contains(search) || s.TinhTrang.Contains(search)).Include(s => s.IdTaiKhoanNavigation)
                                            .Include(s => s.IdHangSanPhamNavigation)
                                            .ToList();
            return View("Index", sp);
        }


        public IActionResult Sort(string sortorder,string currentFilter, string search, int? pageIndex)
        {
            List<SanPham> tong = GetSanPhams();
            CurrentSort = sortorder;
            ViewBag.NameSort = String.IsNullOrEmpty(sortorder) ? "name_desc" : "";
            ViewBag.GiaSort = sortorder == "Gia" ? "gia_desc" : "Gia";
            ViewBag.ShopSort = sortorder == "Shop" ? "shop_desc" : "Shop";
            ViewBag.CurrentFilter = search;
            if (search != null)
            {
                pageIndex = 1;
            }
            else
            {
                search = currentFilter;
            }

            List<SanPham> sp = new List<SanPham>();
            List<SanPham> spid = ctx.SanPham.Include(s => s.IdTaiKhoanNavigation)
                                    .Include(s => s.IdHangSanPhamNavigation)
                                    //.Skip(( - 1) * pagesize)
                                    // .Take(pageIndex)
                                    .ToList();

            if (!String.IsNullOrEmpty(search))
            {
                spid=spid.Where(s => s.MaSanPham.Contains(search) || s.TenSanPham.Contains(search) || s.IdTaiKhoanNavigation.TenShop.Contains(search) || s.Mau.Contains(search) || s.IdHangSanPhamNavigation.TenHang.Contains(search) || s.PhanLoai.Contains(search) || s.ChiTiet.Contains(search) || s.TinhTrang.Contains(search))
                                            .ToList();
            }
            switch (sortorder)
            {
                case "name_desc":
                    spid = spid.OrderByDescending(s => s.TenSanPham).ToList();
                    //list = ctx.SanPham.OrderByDescending(l => l.TenSanPham)
                                       //.Skip((pagenumber - 1) * pagesize)
                                       //// .Take(pagesize)
                                       //.ToList();
                    break;
                case "Shop":
                    spid = spid.OrderBy(s => s.IdTaiKhoanNavigation.TenShop).ToList();
                    break;
                case "shop_desc":
                    spid = spid.OrderByDescending(s => s.IdTaiKhoanNavigation.TenShop).ToList();
                    break;
                case "Gia":
                    spid = spid.OrderBy(s => s.Gia).ToList();
                                      //.Include(l => l.IdTaiKhoanNavigation)
                                      //.Include(l => l.IdHangSanPhamNavigation)
                                      ////.Skip((pagenumber - 1) * pagesize)
                                      ////.Take(pagesize)
                                      //.ToList();
                    break;
                case "gia_desc":
                    spid = spid.OrderByDescending(s => s.Gia).ToList();
                    break;
                default:
                    spid = spid.OrderBy(s => s.TenSanPham).ToList();
                    break;
            }
            //ViewBag.SP = spid;
            ViewBag.TrangHienTai = pageIndex;
            //spid = PaginatedList<SanPham>.Create(spid, pageIndex ?? 1, pageSize) ;
            return View("Index", spid );
        }

        //public IActionResult Sort(string sortorder/*, int pagesize, int pagenumber*/)
        //{
        //    List<SanPham> list = new List<SanPham>();
        //    switch (sortorder)
        //    {
        //        case "masp-az":
        //            list = ctx.SanPham.OrderBy(l => l.MaSanPham)
        //                              .Include(l => l.IdTaiKhoanNavigation)
        //                              .Include(l=>l.IdHangSanPhamNavigation)
        //                              //.Skip((pagenumber - 1) * pagesize)
        //                              // .Take(pagesize)
        //                               .ToList();
        //            break;
        //        case "masp-za":
        //            list = ctx.SanPham.OrderByDescending(l => l.MaSanPham)
        //                              .Include(l => l.IdTaiKhoanNavigation)
        //                              .Include(l => l.IdHangSanPhamNavigation)
        //                              //.Skip((pagenumber - 1) * pagesize)
        //                              //.Take(pagesize)
        //                              .ToList();
        //            break;
        //        case "ten-az":
        //            list = ctx.SanPham.OrderBy(l => l.TenSanPham)
        //                              .Include(l => l.IdTaiKhoanNavigation)
        //                              .Include(l => l.IdHangSanPhamNavigation)
        //                                   //.Skip((pagenumber - 1) * pagesize)
        //                                   //.Take(pagesize)
        //                               .ToList();
        //            break;
        //        case "ten-za":
        //            list = ctx.SanPham.OrderByDescending(l => l.TenSanPham)
        //                              .Include(l => l.IdTaiKhoanNavigation)
        //                              .Include(l => l.IdHangSanPhamNavigation)
        //                                   //.Skip((pagenumber - 1) * pagesize)
        //                                   //.Take(pagesize)
        //                                   .ToList();
        //            break;
        //        case "tenshop-az":
        //            list = ctx.SanPham.OrderBy(l => l.IdTaiKhoanNavigation.TenShop)
        //                              .Include(l => l.IdTaiKhoanNavigation)
        //                              .Include(l => l.IdHangSanPhamNavigation)
        //                                   //.Skip((pagenumber - 1) * pagesize)
        //                                   //.Take(pagesize)
        //                                   .ToList();
        //            break;
        //        case "tenshop-za":
        //            list = ctx.SanPham.OrderByDescending(l => l.IdTaiKhoanNavigation.TenShop)
        //                              .Include(l => l.IdTaiKhoanNavigation)
        //                              .Include(l => l.IdHangSanPhamNavigation)
        //                                   //.Skip((pagenumber - 1) * pagesize)
        //                                   //.Take(pagesize)
        //                                   .ToList();
        //            break;
        //    }
        //    ViewBag.TrangThai = "sort";
        //    ViewBag.Sort = sortorder;
        //    return View("Index",list);
        //}
        //public IActionResult AddSP(string Maadd, string Tenadd, string Tenshop, string Mauedit, string Hangedit, string Phanloaiedit, string Giaedit, string Hinhedit, string Chitietedit, string Giamgiaedit)
        //{

        //    SanPham sp = new SanPham();
        //    if()
        //    return RedirectToAction("Index", sp);
        //}
        //public IActionResult EditSP(string Maedit, string Tenedit, string Tenshopedit, string Mauedit, string Hangedit, string Phanloaiedit, string Giaedit, string Hinhedit, string Chitietedit, string Giamgiaedit)
        //{
        //    var sp = ctx.SanPham.Where(s => s.MaSanPham == Maedit).SingleOrDefault();
        //    if(Tenedit !=null)
        //    {
        //        sp.TenSanPham = Tenedit;
        //    }
        //    if (Mauedit != null)
        //    {
        //        sp.Mau = Mauedit;
        //    }
        //        sp.PhanLoai = Phanloaiedit;
        //    if (Giaedit != null)
        //    {
        //        sp.Gia = float.Parse(Giaedit);
        //    }
        //    if (Hinhedit != null)
        //    {
        //        sp.Hinh = Hinhedit;
        //    }
        //    if (Chitietedit != null)
        //    {
        //        sp.ChiTiet = Chitietedit;
        //    }
        //    if (Giamgiaedit != null)
        //    {
        //        sp.GiamGia = float.Parse(Giamgiaedit);
        //    }
        //    ctx.SaveChanges();
        //    return RedirectToAction("Index",sp);
        //}
    }

}