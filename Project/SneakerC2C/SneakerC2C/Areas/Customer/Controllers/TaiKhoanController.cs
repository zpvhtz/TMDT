﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            TaiKhoan taikhoan = tkbus.CheckTaiKhoan(tendangnhap, matkhau);
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

        public async Task<IActionResult> ActivationMail()
        {
            var client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("emailtam3197@gmail.com", "hanhphuc")
            };
            using (var message = new MailMessage("emailtam3197@gmail.com", "tnngo.97@gmail.com")
            {
                Subject = "Test Email",
                Body = "Body"
            })
            {
                await client.SendMailAsync(message);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}