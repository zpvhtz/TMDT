using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.BusinessLogicLayer;
using Models.Database;

namespace SneakerC2C.Areas.Webmaster.Controllers
{
    [Area("Webmaster")]
    public class HangSanPhamController : BaseController
    {
        const int pageSize = 10;
        int pageNumber = 1;
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
        public IActionResult Search(string search)
        {
            List<HangSanPham> hang = ctx.HangSanPham.Where(s => s.MaHang.Contains(search) || s.TenHang.Contains(search))  
                                            .ToList();
            return View("Index", hang);
        }

        public IActionResult Sort(string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            HangSanPhamBUS hangsanphambus = new HangSanPhamBUS();
            List<HangSanPham> list = hangsanphambus.Sort(sortorder, pageSize, pageNumber);
            List<HangSanPham> tong = hangsanphambus.Sort(sortorder);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "sort";
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }

        public IActionResult Search(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            HangSanPhamBUS hangsanphambus = new HangSanPhamBUS();
            List<HangSanPham> list = hangsanphambus.Search(search, pageSize, pageNumber);
            List<HangSanPham> tong = hangsanphambus.Search(search, pageSize);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            return View("Index", list);
        }

        public IActionResult SearchAndSort(string search, string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            HangSanPhamBUS hangsanphambus = new HangSanPhamBUS();
            List<HangSanPham> list = hangsanphambus.SearchAndSort(search, sortorder, pageSize, pageNumber);
            List<HangSanPham> tong = hangsanphambus.SearchAndSort(search, sortorder, pageSize);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "searchandsort";
            ViewBag.Search = search;
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }

        public int TongTrang(List<HangSanPham> list)
        {
            return ((list.Count / pageSize) + 1);
        }
    }
}