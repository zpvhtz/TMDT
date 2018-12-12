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

            Guid idTaiKhoan= donHang.IdTaiKhoan;
            TaiKhoan taikhoan = bus.GetTaiKhoanById(idTaiKhoan);

            //Thong tin khach
            ViewBag.Ten = donHang.IdTaiKhoanNavigation.Ten;
            ViewBag.DiaChi = donHang.DiaChiGiao;
            ViewBag.Email = taikhoan.Email;
            ViewBag.SDT = taikhoan.DienThoai;

            //Thong tin don hang
            ViewBag.MaDonHang = donHang.MaDonHang;
            ViewBag.NgayTao = donHang.NgayTao;
            //if(donHang.NgayGiao !=null)
            //{
            //    ViewBag.NgayGiao = donHang.NgayGiao;
            //}

            //Tat ca chi tiet don hang
            List<ChiTietDonHang> model = bus.GetChiTietDonHang(idDonHang);            
            return View(model);
        }
    }
}