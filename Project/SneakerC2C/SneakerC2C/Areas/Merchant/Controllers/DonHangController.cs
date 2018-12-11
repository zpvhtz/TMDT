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
        
        public IActionResult ChoXuLy()
        {
            string tentk = HttpContext.Session.GetString("TenDangNhap");

            List<ChiTietDonHang> chitiet = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk && s.TinhTrangChiTiet == "Chưa xử lý")
                                       .Include(s => s.IdDonHangNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                       .ToList();
            ViewBag.ChiTiet = chitiet;
            var tenmer = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk && s.TinhTrangChiTiet == "Chưa xử lý")
                                        .Include(s => s.IdSizeSanPhamNavigation)
                                        .Select(s => s.IdDonHang)
                                        .Distinct()
                                        .ToList();
            List<DonHang> list = ctx.DonHang.Where(sp => tenmer.Contains(sp.Id)).Include(sp => sp.IdTaiKhoanNavigation).ToList();
            return View(list);
        }
        //chuyển qua để xử lý hàng
        public IActionResult XuLy(string iddonhang)
        {
            List<ChiTietDonHang> donhang = ctx.ChiTietDonHang.Where(s => s.IdDonHang == Guid.Parse(iddonhang) && s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
                                            .Include(s => s.IdDonHangNavigation)
                                           .Include(s => s.IdSizeSanPhamNavigation)
                                           .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                           .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                            .ToList();
            foreach(var item in donhang)
            {
               item.TinhTrangChiTiet = "Chờ lấy hàng";
            }
            ctx.SaveChanges();
            return RedirectToAction("ChoLayHang");
        }
        public IActionResult ChoLayHang()
        {
            string tentk = HttpContext.Session.GetString("TenDangNhap");

            List<ChiTietDonHang> chitiet = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk && s.TinhTrangChiTiet == "Chờ lấy hàng")
                                        .Include(s => s.IdDonHangNavigation)
                                        .Include(s => s.IdSizeSanPhamNavigation)
                                        .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                        .Include(s=>s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                        .ToList();
            ViewBag.ChiTiet=chitiet;
            var tenmer = ctx.ChiTietDonHang.Where(s=>s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap==tentk && s.TinhTrangChiTiet=="Chờ lấy hàng")
                                        .Include(s => s.IdSizeSanPhamNavigation)
                                        .Select(s => s.IdDonHang)
                                        .Distinct()
                                        .ToList();
            List<DonHang> list = ctx.DonHang.Where(sp => tenmer.Contains(sp.Id)).Include(sp=>sp.IdTaiKhoanNavigation).ToList();
            return View(list);
        }
        //cap nhật giao hàng
        public IActionResult GiaoHang(string iddonhang)
        {
            List<ChiTietDonHang> donhang = ctx.ChiTietDonHang.Where(s => s.IdDonHang == Guid.Parse(iddonhang) && s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
                                           .Include(s => s.IdDonHangNavigation)
                                          .Include(s => s.IdSizeSanPhamNavigation)
                                          .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                          .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                           .ToList();
            foreach (var item in donhang)
            {
                item.TinhTrangChiTiet = "Đang giao";
            }
            ctx.SaveChanges();
            return RedirectToAction("DangGiao");
        }
        public IActionResult DangGiao()
        {
            string tentk = HttpContext.Session.GetString("TenDangNhap");

            List<ChiTietDonHang> chitiet = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk && s.TinhTrangChiTiet =="Đang giao")
                                       .Include(s => s.IdDonHangNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                       .ToList();
            ViewBag.ChiTiet = chitiet;
            var tenmer = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk && s.TinhTrangChiTiet == "Đang giao")
                                        .Include(s => s.IdSizeSanPhamNavigation)
                                        .Select(s => s.IdDonHang)
                                        .Distinct()
                                        .ToList();
            List<DonHang> list = ctx.DonHang.Where(sp => tenmer.Contains(sp.Id)).Include(sp => sp.IdTaiKhoanNavigation).ToList();
            return View(list);
        }
        public IActionResult CapNhat(string iddonhang)
        {
            List<ChiTietDonHang> donhang = ctx.ChiTietDonHang.Where(s => s.IdDonHang == Guid.Parse(iddonhang) && s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
                                           .Include(s => s.IdDonHangNavigation)
                                          .Include(s => s.IdSizeSanPhamNavigation)
                                          .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                          .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                           .ToList();
            foreach (var item in donhang)
            {
                item.TinhTrangChiTiet = "Đã giao";
            }
            ctx.SaveChanges();
            return RedirectToAction("DaGiao");
        }
        public IActionResult DaGiao()
        {
            string tentk = HttpContext.Session.GetString("TenDangNhap");
            

            List<ChiTietDonHang> chitiet = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk && s.TinhTrangChiTiet == "Đã giao")
                                       .Include(s => s.IdDonHangNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                       .ToList();
            ViewBag.ChiTiet = chitiet;
            var tenmer = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk && s.TinhTrangChiTiet == "Đã giao")
                                        .Include(s => s.IdSizeSanPhamNavigation)
                                        .Select(s => s.IdDonHang)
                                        .Distinct()
                                        .ToList();
            List<DonHang> list = ctx.DonHang.Where(sp => tenmer.Contains(sp.Id)).Include(sp => sp.IdTaiKhoanNavigation).ToList();
            //List<DonHang> tmp = ctx.DonHang.Where(sp => tenmer.Contains(sp.Id)).Include(sp => sp.IdTaiKhoanNavigation).ToList();
            //ViewBag.Test = tmp;
            return View(list);
        }
        public IActionResult GetChiTiet(string id)
        {
            //    string tentk = HttpContext.Session.GetString("TenDangNhap");
            string tendangnhap = HttpContext.Session.GetString("TenDangNhap");
            List<ChiTietDonHang> list = ctx.ChiTietDonHang.Where(s => s.IdDonHang == Guid.Parse(id) && s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tendangnhap)
                                                          .Include(s => s.IdDonHangNavigation)
                                                          .Include(s => s.IdDonHangNavigation.IdTaiKhoanNavigation)
                                                          .Include(s => s.IdSizeSanPhamNavigation)
                                                          .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                                          .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                                          .ToList();
            var iddon = ctx.DonHang.Where(s => s.Id == Guid.Parse(id)).Select(s => s.Id).SingleOrDefault();
            ViewBag.Id = iddon;
            var ten = ctx.DonHang.Where(s => s.Id == Guid.Parse(id)).Select(s => s.IdTaiKhoanNavigation.Ten).SingleOrDefault();
            ViewBag.HoTen = ten;
            double tongtien = ctx.ChiTietDonHang.Where(s => s.IdDonHang == Guid.Parse(id)).Sum(s => (s.SoLuong * s.DonGia)).Value;
            ViewBag.TongTien = tongtien;
            var tinhtrang = ctx.ChiTietDonHang.Where(s => s.IdDonHang == Guid.Parse(id)).Select(s => s.TinhTrangChiTiet).SingleOrDefault();
            ViewBag.TinhTrang = tinhtrang;
            var don = ctx.DonHang.Where(s => s.Id == Guid.Parse(id)).Select(s=>s.DiaChiGiao).SingleOrDefault();
            ViewBag.DiaChi = don;
            var cus = ctx.DonHang.Where(s => s.Id == Guid.Parse(id)).Select(s => s.IdTaiKhoanNavigation.TenDangNhap).SingleOrDefault();
            ViewBag.Ten = cus;
            return View(list);
        }
    }
}