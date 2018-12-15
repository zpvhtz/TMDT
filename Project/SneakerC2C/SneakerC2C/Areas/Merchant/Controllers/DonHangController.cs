using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.BusinessLogicLayer;
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
        public IActionResult Index(string thongbao)
        {
            //Thông báo
            if (thongbao != null)
            {
                ViewBag.ThongBao = thongbao;
            }
            return View();
        }

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
            foreach (var item in donhang)
            {
                item.TinhTrangChiTiet = "Chờ lấy hàng";
            }
            ctx.SaveChanges();
            return RedirectToAction("ChoLayHang");
        }
        public IActionResult Search_XL(string search)
        {
            List<DonHang> list = ctx.DonHang.Where(s => s.MaDonHang.ToString().Contains(search)).Include(s => s.IdTaiKhoanNavigation).ToList();
            return View("XuLy", list);
        }
        public IActionResult ChoLayHang()
        {
            string tentk = HttpContext.Session.GetString("TenDangNhap");

            List<ChiTietDonHang> chitiet = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk && s.TinhTrangChiTiet == "Chờ lấy hàng")
                                        .Include(s => s.IdDonHangNavigation)
                                        .Include(s => s.IdSizeSanPhamNavigation)
                                        .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                        .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                        .ToList();
            ViewBag.ChiTiet = chitiet;
            var tenmer = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk && s.TinhTrangChiTiet == "Chờ lấy hàng")
                                        .Include(s => s.IdSizeSanPhamNavigation)
                                        .Select(s => s.IdDonHang)
                                        .Distinct()
                                        .ToList();
            List<DonHang> list = ctx.DonHang.Where(sp => tenmer.Contains(sp.Id)).Include(sp => sp.IdTaiKhoanNavigation).ToList();
            return View(list);
        }
        public IActionResult Search_LH(string search)
        {
            List<DonHang> list = ctx.DonHang.Where(s => s.MaDonHang.ToString().Contains(search)).Include(s => s.IdTaiKhoanNavigation).ToList();
            return View("ChoLayHang", list);
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
        public IActionResult Search_DG(string search)
        {
            List<DonHang> list = ctx.DonHang.Where(s => s.MaDonHang.ToString().Contains(search)).Include(s => s.IdTaiKhoanNavigation).ToList();
            return View("DangGiao", list);
        }
        public IActionResult DangGiao()
        {
            string tentk = HttpContext.Session.GetString("TenDangNhap");

            List<ChiTietDonHang> chitiet = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk && s.TinhTrangChiTiet == "Đang giao")
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
                item.TinhTrangChiTiet = "Đã xử lý";
                item.NgayGiao = DateTime.Now;
            }
            ctx.SaveChanges();
            return RedirectToAction("DaGiao");
        }
        public IActionResult DaGiao()
        {
            string tentk = HttpContext.Session.GetString("TenDangNhap");


            List<ChiTietDonHang> chitiet = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk && s.TinhTrangChiTiet == "Đã xử lý")
                                       .Include(s => s.IdDonHangNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                       .ToList();
            ViewBag.ChiTiet = chitiet;
            var tenmer = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk && s.TinhTrangChiTiet == "Đã xử lý")
                                        .Include(s => s.IdSizeSanPhamNavigation)
                                        .Select(s => s.IdDonHang)
                                        .Distinct()
                                        .ToList();
            List<DonHang> list = ctx.DonHang.Where(sp => tenmer.Contains(sp.Id)).Include(sp => sp.IdTaiKhoanNavigation).ToList();
            //List<DonHang> tmp = ctx.DonHang.Where(sp => tenmer.Contains(sp.Id)).Include(sp => sp.IdTaiKhoanNavigation).ToList();
            //ViewBag.Test = tmp;
            return View(list);
        }
        public IActionResult Search_G(string search)
        {
            List<DonHang> list = ctx.DonHang.Where(s => s.MaDonHang.ToString().Contains(search)).Include(s => s.IdTaiKhoanNavigation).ToList();
            return View("DaGiao", list);
        }
        public IActionResult DaHuy()
        {
            string tentk = HttpContext.Session.GetString("TenDangNhap");

            var dh = ctx.DonHang.Where(s => s.TinhTrang == "Đã huỷ").Select(s => s.Id).ToList();
            List<ChiTietDonHang> ct = ctx.ChiTietDonHang.Where(s => dh.Contains(s.IdDonHang) && s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk).ToList();
            ViewBag.ChiTiet = ct;
            //List<ChiTietDonHang> chitiet = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk)
            //                           .Include(s => s.IdDonHangNavigation)
            //                           .Include(s => s.IdSizeSanPhamNavigation)
            //                           .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation)
            //                           .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
            //                           .ToList();
            //ViewBag.ChiTiet = chitiet;
            var tenmer = ctx.ChiTietDonHang.Where(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk)
                                        .Include(s => s.IdSizeSanPhamNavigation)
                                        .Select(s => s.IdDonHang)
                                        .Distinct()
                                        .ToList();
            List<DonHang> list = ctx.DonHang.Where(sp => tenmer.Contains(sp.Id)&& sp.TinhTrang=="Đã huỷ").Include(sp => sp.IdTaiKhoanNavigation).ToList();
            //List<DonHang> tmp = ctx.DonHang.Where(sp => tenmer.Contains(sp.Id)).Include(sp => sp.IdTaiKhoanNavigation).ToList();
            //ViewBag.Test = tmp;
            return View(list);
        }
        public IActionResult Search_DH(string search)
        {
            List<DonHang> list = ctx.DonHang.Where(s => s.MaDonHang.ToString().Contains(search)).Include(s => s.IdTaiKhoanNavigation).ToList();
            return View("DaHuy", list);
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
            var iddon = ctx.DonHang.Where(s => s.Id == Guid.Parse(id)).Select(s => s.MaDonHang).SingleOrDefault();
            ViewBag.Id = iddon;
            var ten = ctx.DonHang.Where(s => s.Id == Guid.Parse(id)).Select(s => s.IdTaiKhoanNavigation.Ten).SingleOrDefault();
            ViewBag.HoTen = ten;
            double tongtien = ctx.ChiTietDonHang.Where(s => s.IdDonHang == Guid.Parse(id)).Sum(s => (s.SoLuong * s.DonGia)).Value;
            ViewBag.TongTien = tongtien;

            DonHang donhang = ctx.DonHang.Where(dh => dh.Id == Guid.Parse(id)).SingleOrDefault();
            ViewBag.DonHang = donhang;

            var ngay = ctx.ChiTietDonHang.Where(s => s.IdDonHang == Guid.Parse(id) && s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tendangnhap)
                                       .Include(s => s.IdDonHangNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                       .Include(s => s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                       .Select(s => s.NgayGiao).FirstOrDefault();
            ViewBag.NgayGiao = ngay;

            double diemdanhgia = ctx.ChiTietDonHang.Where(dh => dh.IdDonHang == Guid.Parse(id) && dh.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tendangnhap).Select(dh => dh.DiemMerchantDanhGia).FirstOrDefault() ?? 0;
            ViewBag.DiemDanhGia=diemdanhgia;
            bool danhgia = diemdanhgia > 0 ? false : true;
            ViewBag.DanhGia = danhgia;

            var tinhtrang = ctx.ChiTietDonHang.Where(s => s.IdDonHang == Guid.Parse(id) && s.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tendangnhap)
                                              .Select(s => s.TinhTrangChiTiet)
                                              .FirstOrDefault();
            ViewBag.TinhTrang = tinhtrang;
            var don = ctx.DonHang.Where(s => s.Id == Guid.Parse(id)).Select(s => s.DiaChiGiao).SingleOrDefault();
            ViewBag.DiaChi = don;
            var cus = ctx.DonHang.Where(s => s.Id == Guid.Parse(id)).Select(s => s.IdTaiKhoanNavigation.TenDangNhap).SingleOrDefault();
            ViewBag.Ten = cus;
            return View(list);
        }

        public IActionResult MerchantDanhGia(string iddonhang, int radio_check)
        {
            List<ChiTietDonHang> listchitietdonhang = new List<ChiTietDonHang>();
            listchitietdonhang = ctx.ChiTietDonHang.Where(c => c.IdDonHang == Guid.Parse(iddonhang) && c.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
                                                       .Include(c => c.IdSizeSanPhamNavigation)
                                                       .Include(c => c.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                                       .Include(c => c.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                                       .ToList();
            foreach (var item in listchitietdonhang)
            {
                item.DiemMerchantDanhGia = radio_check;
            }
            ctx.SaveChanges();

            //Đánh giá
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            TaiKhoan taikhoan = taikhoanbus.CheckTaiKhoan(HttpContext.Session.GetString("TenDangNhap"));
            DonHang donhang = ctx.DonHang.Where(dh => dh.Id == Guid.Parse(iddonhang)).SingleOrDefault();

            DanhGia danhgia = new DanhGia();
            danhgia.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            danhgia.IdTaiKhoanDanhGia = taikhoan.Id;
            danhgia.IdTaiKhoanDuocDanhGia = donhang.IdTaiKhoan;
            danhgia.Diem = radio_check;
            ctx.DanhGia.Add(danhgia);
            ctx.SaveChanges();

            //Return
            return RedirectToAction("DaGiao");
        }
    }
}