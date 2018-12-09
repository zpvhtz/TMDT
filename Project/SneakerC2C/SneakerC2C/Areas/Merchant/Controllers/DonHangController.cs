using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Database;

namespace SneakerC2C.Areas.Merchant.Controllers
{
    [Area("Merchant")]
    public class DonHangController : BaseController
    {
        private readonly QLBanGiayContext ctx;
        public DonHangController(QLBanGiayContext context)
        {
            ctx = context;
        }
        //public IActionResult Index(string thongbao)
        //{
        //    //Thông báo
        //    if (thongbao != null)
        //    {
        //        ViewBag.ThongBao = thongbao;
        //    }
        //    return View();
        //}
        public IActionResult ChoLayHang()
        {
            string tentk = HttpContext.Session.GetString("TenDangNhap");

            List<ChiTietDonHang> chitiet = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk)
                                        .Include(s => s.IdDonHangNavigation)
                                        .Include(s => s.IdSizeSanPhamNavigation)
                                        .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                        .Include(s=>s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                        .ToList();
            ViewBag.ChiTiet=chitiet;
            var tenmer = ctx.ChiTietDonHang.Where(s=>s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap==tentk)
                                        .Include(s => s.IdSizeSanPhamNavigation)
                                        .Select(s => s.IdDonHang)
                                        .Distinct()
                                        .ToList();
            List<DonHang> list = ctx.DonHang.Where(sp => tenmer.Contains(sp.Id)&& sp.TinhTrang=="Đã đặt").Include(sp=>sp.IdTaiKhoanNavigation).ToList();
            return View(list);
        }
        
        public IActionResult DangGiao()
        {
            string tentk = HttpContext.Session.GetString("TenDangNhap");

            List<ChiTietDonHang> chitiet = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk)
                                       .Include(s => s.IdDonHangNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                       .ToList();
            ViewBag.ChiTiet = chitiet;
            var tenmer = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk)
                                        .Include(s => s.IdSizeSanPhamNavigation)
                                        .Select(s => s.IdDonHang)
                                        .Distinct()
                                        .ToList();
            List<DonHang> list = ctx.DonHang.Where(sp => tenmer.Contains(sp.Id) && sp.TinhTrang == "Đang giao").Include(sp => sp.IdTaiKhoanNavigation).ToList();
            return View(list);
        }
        public IActionResult CapNhat(string iddonhang)
        {
            var donhang = ctx.DonHang.Where(s => s.Id == Guid.Parse(iddonhang)).SingleOrDefault();
            donhang.TinhTrang = "Đã giao";
            donhang.NgayGiao = DateTime.Now;
            ctx.SaveChanges();
            return RedirectToAction("DaGiao");
        }
        public IActionResult DaGiao()
        {
            string tentk = HttpContext.Session.GetString("TenDangNhap");

            List<ChiTietDonHang> chitiet = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk)
                                       .Include(s => s.IdDonHangNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                       .ToList();
            ViewBag.ChiTiet = chitiet;
            var tenmer = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk)
                                        .Include(s => s.IdSizeSanPhamNavigation)
                                        .Select(s => s.IdDonHang)
                                        .Distinct()
                                        .ToList();
            List<DonHang> list = ctx.DonHang.Where(sp => tenmer.Contains(sp.Id) && sp.TinhTrang == "Đã giao").Include(sp => sp.IdTaiKhoanNavigation).ToList();
            return View(list);
        }
        public IActionResult Huy(string iddonhang)
        {
            var donhang = ctx.DonHang.Where(s => s.Id == Guid.Parse(iddonhang)).SingleOrDefault();
            donhang.TinhTrang = "Huỷ";
            ctx.SaveChanges();
            return RedirectToAction("DaHuy");
        }
        public IActionResult DaHuy()
        {
            string tentk = HttpContext.Session.GetString("TenDangNhap");

            List<ChiTietDonHang> chitiet = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk)
                                       .Include(s => s.IdDonHangNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                       .ToList();
            ViewBag.ChiTiet = chitiet;
            var tenmer = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk)
                                        .Include(s => s.IdSizeSanPhamNavigation)
                                        .Select(s => s.IdDonHang)
                                        .Distinct()
                                        .ToList();
            List<DonHang> list = ctx.DonHang.Where(sp => tenmer.Contains(sp.Id) && sp.TinhTrang == "Huỷ").Include(sp => sp.IdTaiKhoanNavigation).ToList();
            return View(list);
        }
    }
}