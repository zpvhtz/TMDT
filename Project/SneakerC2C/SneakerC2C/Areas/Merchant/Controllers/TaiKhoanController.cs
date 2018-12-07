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
    public class TaiKhoanController : Controller
    {
        public string EditDiaChi(string tendangnhap, string duong, string tinhthanh)
        {
            DiaChiBUS diachibus = new DiaChiBUS();
            string thongbao = diachibus.EditDiaChiMer(tendangnhap, duong, tinhthanh);
            return thongbao;
        }

        public string EditThongTin(string tendangnhap, string sdt)
        {
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            string thongbao = taikhoanbus.EditTaiKhoan(tendangnhap, null, null, null, null, sdt, null);
            return thongbao;
        }

        public string SuaPassword(string tendangnhap, string matkhaucu, string matkhaumoi)
        {
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            string thongbao = "";
            if (taikhoanbus.CheckOldPassword(tendangnhap, matkhaucu))
            {
                thongbao = taikhoanbus.EditTaiKhoan(tendangnhap, matkhaumoi, null, null, null, null, null);
            }
            else
            {
                thongbao = "Mật khẩu cũ không trùng khớp";
            }
            return thongbao;
        }

        public void CreateDiaChi(string tendangnhap, string diachi, string tinhthanh)
        {
            DiaChiBUS diachibus = new DiaChiBUS();
            diachibus.CreateDiaChi(tendangnhap, diachi, tinhthanh);
        }

        public async Task<IActionResult> CreateTaiKhoan(string tendangnhap, string matkhau, string confirmmatkhau, string ten, string tenshop, string email, string dienthoai, string cmnd, string diachi, string tinhthanh)
        {
            string thongbao = "";
            if (matkhau != confirmmatkhau)
            {
                thongbao = "Mật khẩu không trùng nhau";
                return RedirectToAction("Index", "Home", new { thongbao = thongbao });
            }

            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            thongbao = taikhoan.CreateTaiKhoan(tendangnhap, matkhau, ten, tenshop, email, dienthoai, cmnd, "EA9FC9A5-9C26-40A4-9E8E-BB3DAE4E0156", "Chưa kích hoạt");
            CreateDiaChi(tendangnhap, diachi, tinhthanh);
            if (thongbao == "Vui lòng kiểm tra hộp thư email để kích hoạt tài khoản")
            {
                await ActivationMail(tendangnhap);
            }
            return RedirectToAction("Index", "Home", new { thongbao = thongbao });
        }

        public IActionResult EditTaiKhoan(string tendangnhap, string ten, string tenshop, string cmnd, string email, string dienthoai)
        {
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            string thongbao = taikhoanbus.EditTaiKhoan(tendangnhap, null, ten, tenshop, email, dienthoai, cmnd);
            return RedirectToAction("Index", "QuanLy", new { thongbao = thongbao });
        }

        public string EditPassword(string tendangnhap, string matkhau)
        {
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            string thongbao = taikhoanbus.EditTaiKhoan(tendangnhap, matkhau, null, null, null, null, null);
            return thongbao;
        }

        public JsonResult CheckTaiKhoan(string tendangnhap)
        {
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            TaiKhoan taikhoan = taikhoanbus.CheckTaiKhoan(tendangnhap);
            return Json(taikhoan);
        }

        public IActionResult Activate(string key)
        {
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            string thongbao = taikhoanbus.Activate(key);
            return RedirectToAction("Index", "Home", new { thongbao = thongbao });
        }

        public async Task<string> ForgotPassword(string tendangnhap, string email)
        {
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            TaiKhoan taikhoan = new TaiKhoan();
            taikhoan = taikhoanbus.CheckTaiKhoan(tendangnhap, email);
            if (taikhoan == null)
            {
                return "Thông tin không khớp";
            }
            else
            {
                await ForgotPasswordMail(tendangnhap);
            }
            taikhoanbus.AllowResetPassword(tendangnhap);
            return "Vui lòng kiểm tra hộp thư email để đặt lại mật khẩu";
        }

        public IActionResult ResetPassword(string tendangnhap, string matkhau)
        {
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            string thongbao = taikhoanbus.ResetPassword(tendangnhap, matkhau);
            return RedirectToAction("Index", "Home", new { thongbao = thongbao });
        }

        public async Task<IActionResult> ActivationMail(string tendangnhap)
        {
            TaiKhoan taikhoan = new TaiKhoan();
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            taikhoan = taikhoanbus.CheckTaiKhoan(tendangnhap);
            string kichhoat = "Để kích hoạt tài khoản, vui lòng nhấn vào link phía dưới: \n";
            var local = HttpContext.Request.Host;
            kichhoat += "https://" + local.ToString() + "/Merchant/TaiKhoan/Activate?key=" + taikhoan.Id;
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

        public async Task<IActionResult> ForgotPasswordMail(string tendangnhap)
        {
            TaiKhoan taikhoan = new TaiKhoan();
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            taikhoan = taikhoanbus.CheckTaiKhoan(tendangnhap);
            string kichhoat = "Hệ thống đã nhận được yêu cầu thay đổi mật khẩu của quý khách\n";
            kichhoat += "Xin hãy click vào đường dẫn sau để đổi mật khẩu: \n";
            var local = HttpContext.Request.Host;
            kichhoat += "https://" + local.ToString() + "/Merchant/Home/ResetPassword?key=" + taikhoan.Id;
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