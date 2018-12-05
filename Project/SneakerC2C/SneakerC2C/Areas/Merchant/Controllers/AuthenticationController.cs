using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.BusinessLogicLayer;
using Models.Database;

namespace SneakerC2C.Areas.Merchant.Controllers
{
    [Area("Merchant")]
    public class AuthenticationController : Controller
    {

        public IActionResult LogIn(string tendangnhap, string matkhau)
        {
            TaiKhoanBUS tkbus = new TaiKhoanBUS();
            TaiKhoan taikhoan = tkbus.CheckTaiKhoan(tendangnhap, matkhau, "Thương nhân");
            string thongbao = "";
            if(taikhoan == null)
            {
                thongbao = "Thông tin đăng nhập không đúng";
                return RedirectToAction("Index", "Home", new { thongbao = thongbao });
            }
            if(taikhoan.TinhTrang == "Chưa kích hoạt")
            {
                thongbao = "Tài khoản chưa được kích hoạt, vui lòng kích hoạt thông qua email";
                return RedirectToAction("Index", "Home", new { thongbao = thongbao });
            }
            if(taikhoan.TinhTrang == "Chưa xác nhận")
            {
                thongbao = "Tài khoản chưa được xác nhận, vui lòng chờ hoặc liên hệ Webmaster để xác nhận";
                return RedirectToAction("Index", "Home", new { thongbao = thongbao });
            }
            if(taikhoan.TinhTrang == "Khoá")
            {
                thongbao = "Tài khoản đã bị khoá, vui lòng liên hệ Webmaster để mở khoá";
                return RedirectToAction("Index", "Home", new { thongbao = thongbao });
            }
            HttpContext.Session.SetString("TenDangNhap", taikhoan.TenDangNhap);
            thongbao = "Đăng nhập thành công";
            return RedirectToAction("Index", "QuanLy", new { thongbao = thongbao });
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("TenDangNhap");
            return RedirectToAction("Index", "Home");
        }
    }
}