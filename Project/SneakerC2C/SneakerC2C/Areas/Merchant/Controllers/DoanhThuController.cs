using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.BusinessLogicLayer;

namespace SneakerC2C.Areas.Merchant.Controllers
{
    [Area("Merchant")]
    public class DoanhThuController : BaseController
    {
        DoanhThuBUS doanhthubus = new DoanhThuBUS();
        public IActionResult Index()
        {
            string tendangnhap = HttpContext.Session.GetString("TenDangNhap");
            double tongtien = doanhthubus.GetTongDoanhThu(tendangnhap);
            ViewBag.TongDoanhThu = tongtien;
            return View();
        }

        public double GetTongDoanhThuTheoNgay(DateTime nbd, DateTime nkt)
        {
            string tendangnhap = HttpContext.Session.GetString("TenDangNhap");
            double tongtien = doanhthubus.GetTongDoanhThu(tendangnhap, nbd, nkt);
            return tongtien;
        }
    }
}