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
        public List<HangSanPham> Get()
        {
            List<HangSanPham> list = ctx.HangSanPham.OrderBy(h => h.MaHang).ToList();
            return list;
        }
        public List<HangSanPham> Get(int pagenumber, int pagesize)
        {
            List<HangSanPham> list = ctx.HangSanPham.OrderBy(h => h.MaHang)
                                                  .Skip((pagenumber - 1) * pagesize)
                                                  .Take(pagesize)
                                                  .ToList();
            return list;
        }
        public IActionResult Index(string thongbao, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            if (thongbao !=null)
            {
                ViewBag.ThongBao = thongbao;
            }
            List<HangSanPham> list = Get(pageNumber, pageSize);
            List<HangSanPham> tong = Get();
            //ViewBag
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
            return View(list);
        }
        public IActionResult ThemHangSanPham(string item_them_mahang,string item_them_ten)
        {

            //Mã tự tăng

            HangSanPham hang = new HangSanPham();
            string mamoi = "";
            if (ctx.HangSanPham.Count() == 0)
            {
                mamoi = "H-1";
            }
            else
            {
                string layma = ctx.HangSanPham
                                      .OrderByDescending(h => int.Parse(h.MaHang.Substring(2)))
                                      .Select(h => h.MaHang)
                                      .FirstOrDefault();
                int stt = int.Parse(layma.Substring(layma.IndexOf('-') + 1));
                stt += 1;
                mamoi = "H-" + stt.ToString();
            }
                //
                
            hang.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            hang.MaHang = mamoi;
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