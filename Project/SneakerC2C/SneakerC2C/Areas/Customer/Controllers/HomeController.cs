using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.BusinessLogicLayer;
using Models.Database;

namespace SneakerC2C.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : BaseController
    {

        private readonly QLBanGiayContext ctx;
        public HomeController(QLBanGiayContext context)
        {
            ctx = context;
        }
        const int pagesize = 8;
        const int pagenumber = 1;
        public IActionResult Index(string thongbao)
        {
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.Hang = hang;
            //Thông báo
            if (thongbao != null)
            {
                ViewBag.ThongBao = thongbao;
            }
            SanPhamBUS sanphambus = new SanPhamBUS();
            List<SanPham> spnam = sanphambus.GetSanPhams("PhanLoai", "Nam", pagenumber, pagesize);
            List<SanPham> spnu = sanphambus.GetSanPhams("PhanLoai", "Nữ", pagenumber, pagesize);
            List<SanPham> spmoi = sanphambus.GetSanPhams("", "", pagenumber, pagesize);
            List<SanPham> spbanchay = sanphambus.GetBanChay();
            ViewBag.SanPhamNam = spnam;
            ViewBag.SanPhamNu = spnu;
            ViewBag.SanPhamMoi = spmoi;
            ViewBag.SanPhamBanChay = spbanchay;
            return View();
        }
        
        public IActionResult ResetPassword(string key)
        {
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            TaiKhoan taikhoan = taikhoanbus.CheckTaiKhoanResetPassword(key);
            return View(taikhoan);
        }

        public IActionResult DangKy()
        {
            TinhThanhBUS tinhthanhbus = new TinhThanhBUS();
            List<TinhThanh> list = tinhthanhbus.GetTinhThanhs();
            return PartialView("pDangKy", list);
        }
    }
}