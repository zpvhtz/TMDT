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
    public class QuanLyController : BaseController
    {
        private readonly QLBanGiayContext ctx;
        public QuanLyController(QLBanGiayContext context)
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
        public IActionResult ListSP()
        {
            List<SanPham> list = ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
                                           .Include(sp => sp.IdTaiKhoanNavigation)
                                           .Include(sp => sp.IdHangSanPhamNavigation)
                                           .ToList();
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
        //public List<SizeSanPham> GetSize()
        //{
        //    List<SizeSanPham> size=ctx.SizeSanPham.Where(s=>s.IdSanPhamNavigation)
        //}
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
    }
}