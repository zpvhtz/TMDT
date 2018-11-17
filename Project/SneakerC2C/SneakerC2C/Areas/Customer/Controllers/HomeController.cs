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
        const int pagesize = 8;
        const int pagenumber = 1;
        public IActionResult Index(string thongbao)
        {
            //Thông báo
            if (thongbao != null)
            {
                ViewBag.ThongBao = thongbao;
            }
            SanPhamBUS sanphambus = new SanPhamBUS();
            List<SanPham> spnam = sanphambus.GetSanPhams("PhanLoai", "Nam", pagenumber, pagesize);
            List<SanPham> spnu = sanphambus.GetSanPhams("PhanLoai", "Nữ", pagenumber, pagesize);
            List<SanPham> spmoi = sanphambus.GetSanPhams("", "", pagenumber, pagesize);
            ViewBag.SanPhamNam = spnam;
            ViewBag.SanPhamNu = spnu;
            ViewBag.SanPhamMoi = spmoi;
            return View();
        }
        
        public IActionResult ResetPassword(string key)
        {
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            TaiKhoan taikhoan = taikhoanbus.CheckTaiKhoanResetPassword(key);
            return View(taikhoan);
        }
    }
}