using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.BusinessLogicLayer;
using Models.Database;

namespace SneakerC2C.Areas.Merchant.Controllers
{
    [Area("Merchant")]
    public class QuanLyController : BaseController
    {
        private readonly QLBanGiayContext ctx;
        public QuanLyController(QLBanGiayContext context)
        {
            ctx = context;
        }
        public IActionResult Index(string thongbao)
        {
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.HangSanPham = hang;
            //Thông báo
            if (thongbao != null)
            {
                ViewBag.ThongBao = thongbao;
            }
            return View();
        }
        public IActionResult ListSP()
        {
            
            List<SanPham> list = ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
                                           .Include(sp => sp.IdTaiKhoanNavigation)
                                           .Include(sp => sp.IdHangSanPhamNavigation)
                                           .ToList();
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.HangSanPham = hang;
            return View(list);
        }
        public IActionResult KhoaSP()
        {
            List<SanPham> list=ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
                                           .Where(sp=>sp.TinhTrang=="Khoá")
                                            .Include(sp => sp.IdTaiKhoanNavigation)
                                           .Include(sp => sp.IdHangSanPhamNavigation)
                                           .ToList();
            return View(list);
        }
        public IActionResult GetSize(string masp)
        {
            List<SanPham> list = ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
                                           .Include(sp => sp.IdTaiKhoanNavigation)
                                           .Include(sp => sp.IdHangSanPhamNavigation)
                                           .ToList();
            List<SizeSanPham> listsize = ctx.SizeSanPham.Where(sp => list.Contains(sp.IdSanPhamNavigation)).ToList(); ;
            
            return PartialView("pSize", listsize);
        }
        public IActionResult ConHang()
        {
            var listsize = ctx.SizeSanPham.Where(s => s.SoLuong > 0)
                                        .Include(s => s.IdSanPhamNavigation)
                                        .Select(s => s.IdSanPham)
                                        .Distinct()
                                        .ToList();
            List<SanPham> list = ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
                                            .Where(sp => listsize.Contains(sp.Id)).ToList();
            return View(list);
        }
        public IActionResult HetHang()
        {
            var listsize = ctx.SizeSanPham.Where(s => s.SoLuong == 0)
                                        .Include(s => s.IdSanPhamNavigation)
                                        .Select(s => s.IdSanPham)
                                        .ToList();
            List<SanPham> list = ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
                                            .Where(sp => listsize.Contains(sp.Id)).ToList();
            return View(list);
        }
        public IActionResult ThemSP(string item_them_ma,string item_them_tensp,string item_them_mau, string item_them_hang, string item_them_phanloai, string item_them_gia, string item_them_chitiet, string item_them_giamgia,string item_them_hinh)
        {
                //long size = item_them_hinh.Sum(f => f.Length);

                //// full path to file in temp location
                
                //foreach (var formFile in item_them_hinh)
                //{
                //    if (formFile.Length > 0)
                //    {
                //        using (var stream = new FileStream(filePath, FileMode.Create))
                //        {
                //        formFile.CopyTo(stream);
                //        }
                //    }
                //}
            SanPham sp = new SanPham();
            //string layma = ctx.SanPham
            //    .OrderByDescending(h => h.MaSanPham)
            //    .Select(h => h.MaSanPham)
            //    .FirstOrDefault();
            //int vitri = layma.IndexOf("-");
            //string tmp = layma.Substring(0, vitri);
            //int so = int.Parse(layma.Substring(vitri + 1, layma.Length - 1 - vitri));
            //so = so + 1;
            //string Ma = tmp + "-" + so;
            string tentk = HttpContext.Session.GetString("TenDangNhap");
            var idtk = ctx.SanPham.Where(s => s.IdTaiKhoanNavigation.TenDangNhap == tentk).Select(s => s.IdTaiKhoan).FirstOrDefault();
            //Guid tk = ctx.TaiKhoan.Where(t => t.Ten == HttpContext.Session.GetString("TenDangNhap")).Select(t=>t.Id).SingleOrDefault();
            sp.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            sp.MaSanPham = item_them_ma;
            sp.TenSanPham = item_them_tensp;
            sp.IdTaiKhoan = idtk;
            sp.Mau = item_them_mau;
            sp.IdHangSanPham = Guid.Parse(item_them_hang);
            sp.PhanLoai = item_them_phanloai;
            sp.Gia = double.Parse(item_them_gia);

          

            // full path to file in temp location
            sp.Hinh = Path.GetFileName(item_them_hinh);
            sp.ChiTiet = item_them_chitiet;
            sp.NgayDang = DateTime.Now;
            sp.TinhTrang = "Không khoá";
            ctx.Add(sp);
            ctx.SaveChanges();
            return RedirectToAction("ListSP");
        }
        public IActionResult ChiTiet(string Ma)
        {
            SanPham sp = ctx.SanPham.Where(s => s.MaSanPham == Ma).SingleOrDefault();
            SanPhamBUS sanphambus = new SanPhamBUS();
            SizeSanPhamBUS sizesanphambus = new SizeSanPhamBUS();
            GioHangBUS giohangbus = new GioHangBUS();
            List<SizeSanPham> listsizesanpham = sizesanphambus.GetSize(Ma);
            ViewBag.ListSizeSanPham = listsizesanpham;
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.Hang = hang;
            return View("ChiTiet");
        }
        public IActionResult EditSP(string Maedit, string Tenedit, string Mauedit, string Hangedit, string Phanloaiedit, string Giaedit, string Hinhedit, string Chitietedit, string Giamgiaedit)
        {
            var sp = ctx.SanPham.Where(s => s.MaSanPham == Maedit).SingleOrDefault();
            if (Tenedit != null)
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
            return RedirectToAction("ListSP");
        }

    }
}