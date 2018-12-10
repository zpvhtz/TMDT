using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.BusinessLogicLayer;
using Models.Database;

namespace SneakerC2C.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class DonHangController : BaseController
    {
        private GioHangBUS giohangbus = new GioHangBUS();
        private TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
        private GiaShipBUS giashipbus = new GiaShipBUS();
        private DonHangBUS donhangbus = new DonHangBUS();

        public IActionResult DatHang(string tendangnhap)
        {
            string checktendangnhap = HttpContext.Session.GetString("TenDangNhap");
            if (checktendangnhap != null && checktendangnhap != "")
            {
                TaiKhoan taikhoan = new TaiKhoan();
                taikhoan = taikhoanbus.CheckTaiKhoan(tendangnhap);
                List<GioHang> list = giohangbus.GetGioHangs(tendangnhap);
                List<TaiKhoan> listmerchant = giohangbus.GetMerchants(tendangnhap);
                List<DiaChi> listaddress = taikhoanbus.GetAllAddress(tendangnhap);
                DiaChi firstAddress = taikhoanbus.GetFirstAddress(tendangnhap);

                ViewBag.TaiKhoan = taikhoan;
                ViewBag.Merchants = listmerchant;
                ViewBag.FirstAddress = firstAddress;
                ViewBag.ListAddress = listaddress;

                return View(list);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult GetPhiShip(string tendangnhap, string iddiachi)
        {
            string checktendangnhap = HttpContext.Session.GetString("TenDangNhap");
            if (checktendangnhap != null && checktendangnhap != "")
            {
                List<DiaChi> listdiachi = new List<DiaChi>();
                listdiachi = giohangbus.GetPhiShip(tendangnhap);

                DiaChi diachi = new DiaChi();
                diachi = taikhoanbus.GetChoosenAddress(iddiachi);

                List<GiaShip> listgiaship = new List<GiaShip>();
                listgiaship = giashipbus.GetGiaShips();

                ViewBag.GiaShipNoiThanh = listgiaship.Where(gs => gs.Loai.Contains("Nội Thành"))
                                                     .OrderByDescending(gs => gs.NgayCapNhat)
                                                     .FirstOrDefault();
                ViewBag.GiaShipNgoaiThanh = listgiaship.Where(gs => gs.Loai.Contains("Ngoại Thành"))
                                                       .OrderByDescending(gs => gs.NgayCapNhat)
                                                       .FirstOrDefault();
                ViewBag.DiaChi = diachi;
            
                return PartialView("pTienThanhToan", listdiachi);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult GetDiaChi(string tendangnhap, string iddiachi)
        {
            string checktendangnhap = HttpContext.Session.GetString("TenDangNhap");
            if (checktendangnhap != null && checktendangnhap != "")
            {
                DiaChi diachi = new DiaChi();
                diachi = taikhoanbus.GetChoosenAddress(iddiachi);

                TaiKhoan taikhoan = new TaiKhoan();
                taikhoan = taikhoanbus.CheckTaiKhoan(tendangnhap);
                ViewBag.TaiKhoan = taikhoan;

                return PartialView("pDiaChi", diachi);
            }
            return RedirectToAction("Index", "Home");
        }

        public string CheckDonHang(string tendangnhap)
        {
            string checktendangnhap = HttpContext.Session.GetString("TenDangNhap");
            if (checktendangnhap != null && checktendangnhap != "")
            {
                string thongbao = donhangbus.CheckDonHang(tendangnhap);
                return thongbao;
            }
            return "";
        }

        public void CreateDonDatHang(string tendangnhap, string iddiachi, double tongtien)
        {
            string checktendangnhap = HttpContext.Session.GetString("TenDangNhap");
            if (checktendangnhap != null && checktendangnhap != "")
            {
                donhangbus.CreateDonDatHang(tendangnhap, iddiachi, tongtien);
            }
        }
    }
}