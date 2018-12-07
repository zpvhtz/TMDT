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
    public class DonHangController : Controller
    {
        private GioHangBUS giohangbus = new GioHangBUS();
        private TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();

        public IActionResult DatHang(string tendangnhap)
        {
            TaiKhoan taikhoan = new TaiKhoan();
            taikhoan = taikhoanbus.CheckTaiKhoan(tendangnhap);
            List<GioHang> list = giohangbus.GetGioHangs(tendangnhap);
            ViewBag.TaiKhoan = taikhoan;
            return View(list);
        }
    }
}