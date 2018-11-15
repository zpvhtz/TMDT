using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.BusinessLogicLayer;
using Models.Database;

namespace SneakerC2C.Areas.Webmaster.Controllers
{
    [Area("Webmaster")]
    public class AuthenticationController : Controller
    {
        public IActionResult Index(string thongbao)
        {
            //Thông báo
            if (thongbao != null)
            {
                ViewBag.ThongBao = thongbao;
            }
            
            return View();
        }

        public IActionResult LogIn(string tendangnhap, string matkhau, string remember)
        {
            TaiKhoanBUS tkbus = new TaiKhoanBUS();
            TaiKhoan taikhoan = tkbus.CheckTaiKhoan(tendangnhap, matkhau, "Webmaster");
            string thongbao = "";
            if (taikhoan == null)
            {
                thongbao = "Thông tin đăng nhập không đúng";
                return RedirectToAction("Index", "Authentication", new { thongbao = thongbao });
            }
            //Lưu Session
            HttpContext.Session.SetString("TenDangNhap", taikhoan.TenDangNhap);
            //Lưu Cookies nếu có
            if(remember != null)
            {
                HttpContext.Response.Cookies.Append("tendangnhap", tendangnhap);
                HttpContext.Response.Cookies.Append("matkhau", matkhau);
            }
            else
            {
                HttpContext.Response.Cookies.Delete("tendangnhap");
                HttpContext.Response.Cookies.Delete("matkhau");
            }
            thongbao = "Đăng nhập thành công";
            return RedirectToAction("Index", "Home", new { thongbao = thongbao });
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("TenDangNhap");
            return RedirectToAction("Index", "Home");
        }
    }
}