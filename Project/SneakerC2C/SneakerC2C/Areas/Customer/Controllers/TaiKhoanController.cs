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

namespace SneakerC2C.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class TaiKhoanController : Controller
    {
        public IActionResult LogIn(string tendangnhap, string matkhau)
        {
            TaiKhoanBUS tkbus = new TaiKhoanBUS();
            TaiKhoan taikhoan = tkbus.CheckTaiKhoan(tendangnhap, matkhau, "Khách hàng");
            string thongbao = "";
            if(taikhoan == null)
            {
                thongbao = "Thông tin đăng nhập không đúng";
                return RedirectToAction("Index", "Home", new { thongbao = thongbao });
            }

            HttpContext.Session.SetString("TenDangNhap", taikhoan.TenDangNhap);
            thongbao = "Đăng nhập thành công";
            return RedirectToAction("Index", "Home", new { thongbao = thongbao });
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("TenDangNhap");
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CreateTaiKhoan(string tendangnhap, string matkhau, string confirmmatkhau, string ten, string email)
        {
            string thongbao = "";
            if(matkhau != confirmmatkhau)
            {
                thongbao = "Mật khẩu không trùng nhau";
                return RedirectToAction("Index", "Home", new { thongbao = thongbao });
            }

            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            thongbao = taikhoan.CreateTaiKhoan(tendangnhap, matkhau, ten, "", email, "", "", "15CF8A9B-517E-4BAE-91E2-F30C596990ED", "Chưa kích hoạt");
            if(thongbao == "Thêm thành công")
            {
                await ActivationMail(tendangnhap);
            }
            return RedirectToAction("Index", "Home", new { thongbao = thongbao });
        }

        public IActionResult Activate(string tendangnhap)
        {
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            string thongbao = taikhoanbus.Activate(tendangnhap);
            return RedirectToAction("Index", "Home", new { thongbao = thongbao });
        }

        public async Task<IActionResult> ActivationMail(string tendangnhap)
        {
            TaiKhoan taikhoan = new TaiKhoan();
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            taikhoan = taikhoanbus.CheckTaiKhoan(tendangnhap);
            string kichhoat = "Để kích hoạt tài khoản, vui lòng nhấn vào link phía dưới: \n";
            var local = HttpContext.Request.Host;
            kichhoat += "https://" + local.ToString() + "/Customer/TaiKhoan/Activate?tendangnhap=" + tendangnhap;
            var client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("snkrxemail@gmail.com", "1234@abcd")
            };

            using (var message = new MailMessage("snkrxemail@gmail.com", taikhoan.Email)
            {
                Subject = "Email kích hoạt tài khoản",
                Body = kichhoat,
                Priority = MailPriority.High,
                BodyEncoding = Encoding.UTF8
            })
            {
                await client.SendMailAsync(message);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}