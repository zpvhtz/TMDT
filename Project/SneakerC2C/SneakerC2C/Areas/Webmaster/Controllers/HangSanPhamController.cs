using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Database;

namespace SneakerC2C.Areas.Webmaster.Controllers
{
    [Area("Webmaster")]
    public class HangSanPhamController : BaseController
    {
        private readonly QLBanGiayContext ctx;
        public HangSanPhamController(QLBanGiayContext context)
        {
            ctx = context;
        }
        public IActionResult Index(string thongbao)
        {
            if(thongbao !=null)
            {
                ViewBag.ThongBao = thongbao;
            }
            List<HangSanPham> list = ctx.HangSanPham.OrderBy(h=>h.MaHang).ToList();
            return View(list);
        }
        public IActionResult ThemHangSanPham(string item_them_mahang,string item_them_ten)
        {
            
            //Mã tự tăng
            string layma = ctx.HangSanPham
                .OrderByDescending(h => h.MaHang)
                .Select(h => h.MaHang)
                .FirstOrDefault();
            int vitri = layma.IndexOf("-");
            string tmp = layma.Substring(0, vitri);
            int so = int.Parse(layma.Substring(vitri + 1, layma.Length-1-vitri));
            so = so + 1;
            string Ma = tmp +"-"+ so;
            //
            HangSanPham hang = new HangSanPham();
            hang.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            hang.MaHang = Ma;
            hang.TenHang = item_them_ten;
            hang.TinhTrang = "Không khoá";
            ctx.Add(hang);
            ctx.SaveChanges();
            string thongbao = "Thêm hãng sản phẩm thành công";
            return RedirectToAction("Index","HangSanPham", new { thongbao = thongbao });
        }
        public IActionResult SuaHangSanPham(string item_sua_ma,string item_sua_ten)
        {
            HangSanPham hang = ctx.HangSanPham.Where(h => h.MaHang == item_sua_ma).SingleOrDefault();
            if (item_sua_ten != null)
            {
                hang.TenHang = item_sua_ten;
            }
            ctx.SaveChanges();
            return RedirectToAction("Index", "HangSanPham");
        }
        public IActionResult LockHang(string mahang)
        {
            HangSanPham hang = ctx.HangSanPham.Where(h => h.MaHang == mahang).SingleOrDefault();
            hang.TinhTrang = "Khoá";
            ctx.SaveChanges();
            return RedirectToAction("Index", "HangSanPham");
        }
        public IActionResult UnLockHang(string mahang)
        {
            HangSanPham hang = ctx.HangSanPham.Where(h => h.MaHang == mahang).SingleOrDefault();
            hang.TinhTrang = "Không khoá";
            ctx.SaveChanges();
            return RedirectToAction("Index", "HangSanPham");
        }
    }
}