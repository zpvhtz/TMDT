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
    public class ReportController : Controller
    {
        public IActionResult Index(string idDonHang)
        {
            string temp = idDonHang;
            ReportBUS bus = new ReportBUS();
            DonHang donHang = new DonHang();
            donHang = bus.GetDonHang(idDonHang);

            ViewBag.MaDonHang = donHang.MaDonHang;
            ViewBag.Ten = donHang.IdTaiKhoanNavigation.Ten;
            ViewBag.DiaChi = donHang.DiaChiGiao;
            ViewBag.NgayTao = donHang.NgayTao;
            ViewBag.NgayGiao = donHang.NgayGiao;

            List<ChiTietDonHang> model = bus.GetChiTietDonHang(idDonHang);            
            return View(model);
        }
    }
}