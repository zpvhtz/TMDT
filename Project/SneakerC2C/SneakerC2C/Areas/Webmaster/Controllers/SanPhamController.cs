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
    public class SanPhamController : Controller
    {
        private readonly QLBanGiayContext ctx;
        public SanPhamController(QLBanGiayContext context)
        {
            ctx = context;
        }
        public IActionResult Index()
        {
            
            List<SanPham> list = ctx.SanPham.Include(tk => tk.IdTaiKhoanNavigation)
                                            .Include(h => h.IdHangSanPhamNavigation)
                                             .ToList();
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.Hang= hang;
            return View(list);
        }
        public IActionResult Search(string search)
        {
            List<SanPham> sp = ctx.SanPham.Where(s => s.MaSanPham.Contains(search) || s.TenSanPham.Contains(search) || s.IdTaiKhoanNavigation.TenShop.Contains(search) || s.Mau.Contains(search) || s.IdHangSanPhamNavigation.TenHang.Contains(search) || s.PhanLoai.Contains(search) || s.ChiTiet.Contains(search) || s.TinhTrang.Contains(search)).Include(tk => tk.IdTaiKhoanNavigation)
                                            .Include(h => h.IdHangSanPhamNavigation)
                                            .ToList();
            return View("Index",sp);
        }
        public IActionResult EditSP(string Maedit, string Tenedit, string Tenshopedit, string Mauedit, string Hangedit, string Phanloaiedit, string Giaedit, string Hinhedit, string Chitietedit, string Giamgiaedit)
        {
            var sp = ctx.SanPham.Where(s => s.MaSanPham == Maedit).SingleOrDefault();
            if(Tenedit !=null)
            {
                sp.TenSanPham = Tenedit;
            }
            if (Mauedit != null)
            {
                sp.Mau = Mauedit;
            }
                sp.PhanLoai = Phanloaiedit;
            if (Giaedit != null)
            {
                sp.Gia = float.Parse(Giaedit);
            }
            if (Hinhedit != null)
            {
                sp.Hinh = Hinhedit;
            }
            if (Chitietedit != null)
            {
                sp.ChiTiet = Chitietedit;
            }
            if (Giamgiaedit != null)
            {
                sp.GiamGia = float.Parse(Giamgiaedit);
            }
            ctx.SaveChanges();
            return RedirectToAction("Index",sp);
        }
    }
}