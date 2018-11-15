using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Database;

namespace SneakerC2C.Areas.Webmaster.Controllers
{
    [Area("Webmaster")]
    public class HangSanPhamController : Controller
    {
        private readonly QLBanGiayContext ctx;
        public HangSanPhamController(QLBanGiayContext context)
        {
            ctx = context;
        }
        public IActionResult Index()
        {
            List<HangSanPham> list = ctx.HangSanPham.ToList();
            return View(list);
        }
        public IActionResult ThemHangSanPham(string item_them_mahang,string item_them_ten)
        {
            //var layma = ctx.HangSanPham
            //    .OrderByDescending(h=>h.MaHang)
            //    .Select(h => h.MaHang)
            //    .SingleOrDefault();
            //ViewBag.LayMa = layma;
            HangSanPham hang= new HangSanPham();
            hang.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            hang.MaHang = item_them_mahang;
            hang.TenHang = item_them_ten;
            hang.TinhTrang = "Không khoá";
            ctx.Add(hang);
            ctx.SaveChanges();
            return RedirectToAction("Index","HangSanPham");
        }
    }
}