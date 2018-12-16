﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.BusinessLogicLayer;
using Models.Database;

namespace SneakerC2C.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class TaiKhoanController : BaseController
    {
        public IActionResult ThongTinTaiKhoan()
        {
            string sessionval = HttpContext.Session.GetString("TenDangNhap");
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            TaiKhoan taikhoan = new TaiKhoan();
            if(sessionval != "" && sessionval != null)
            {
                taikhoan = taikhoanbus.CheckTaiKhoan(sessionval);
            }
            else
            {
                taikhoan = null;
            }
            HangSanPhamBUS hangsanphambus = new HangSanPhamBUS();
            List<HangSanPham> hang = hangsanphambus.GetHangSanPhams();
            ViewBag.Hang = hang;
            return View(taikhoan);
        }

        public IActionResult ThongTinDiaChi()
        {
            string sessionval = HttpContext.Session.GetString("TenDangNhap");
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            TaiKhoan taikhoan = new TaiKhoan();
            if (sessionval != "" && sessionval != null)
            {
                taikhoan = taikhoanbus.CheckTaiKhoan(sessionval);
            }
            else
            {
                taikhoan = null;
            }

            HangSanPhamBUS hangsanphambus = new HangSanPhamBUS();
            List<HangSanPham> hang = hangsanphambus.GetHangSanPhams();

            TinhThanhBUS tinhthanhbus = new TinhThanhBUS();
            List<TinhThanh> tinhthanh = tinhthanhbus.GetTinhThanhs();

            DiaChiBUS diachibus = new DiaChiBUS();
            List<DiaChi> diachi = new List<DiaChi>();

            if (taikhoan != null)
                diachi = diachibus.GetDiaChisCus(taikhoan.TenDangNhap);

            ViewBag.Hang = hang;
            ViewBag.TinhThanh = tinhthanh;
            ViewBag.DiaChi = diachi;
            return View(taikhoan);
        }

        public IActionResult DoiMatKhau()
        {
            string sessionval = HttpContext.Session.GetString("TenDangNhap");
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            TaiKhoan taikhoan = new TaiKhoan();
            if (sessionval != "" && sessionval != null)
            {
                taikhoan = taikhoanbus.CheckTaiKhoan(sessionval);
            }
            else
            {
                taikhoan = null;
            }
            HangSanPhamBUS hangsanphambus = new HangSanPhamBUS();
            List<HangSanPham> hang = hangsanphambus.GetHangSanPhams();
            ViewBag.Hang = hang;
            return View(taikhoan);
        }

        public IActionResult CustomerDanhGia(string iddonhang, string idmerchant, int radio_check)
        {
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            TaiKhoan taikhoan = new TaiKhoan();
            DonHangBUS donhangbus = new DonHangBUS();

            string sessionval = HttpContext.Session.GetString("TenDangNhap");
            if(sessionval != "" && sessionval != null)
            {
                taikhoan = taikhoanbus.CheckTaiKhoan(sessionval);
                donhangbus.CustomerDanhGia(iddonhang, idmerchant, radio_check);
                donhangbus.CustomerDanhGiaTable(taikhoan.Id.ToString(), idmerchant, radio_check);
            }
            return RedirectToAction("ChiTietDonMua", new { id = iddonhang });
        }

        public IActionResult ChiTietDonMua(string id)
        {
            string sessionval = HttpContext.Session.GetString("TenDangNhap");
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            TaiKhoan taikhoan = new TaiKhoan();
            DonHangBUS donhangbus = new DonHangBUS();
            DonHang donhang = new DonHang();
            List<ChiTietDonHang> listchitietdonhang = new List<ChiTietDonHang>();
            if (sessionval != "" && sessionval != null)
            {
                taikhoan = taikhoanbus.CheckTaiKhoan(sessionval);
                donhang = donhangbus.GetExactDonHang(id);
                listchitietdonhang = donhangbus.GetExactChiTietDonHang(id);
            }
            else
            {
                taikhoan = null;
                donhang = null;
            }
            HangSanPhamBUS hangsanphambus = new HangSanPhamBUS();
            List<HangSanPham> hang = hangsanphambus.GetHangSanPhams();
            ViewBag.Hang = hang;
            ViewBag.TaiKhoan = taikhoan;
            ViewBag.ChiTietDonHang = listchitietdonhang;

            //Kiểm tra có  cho huỷ hay không
            bool huydonhang;
            List<ChiTietDonHang> listhuydon = listchitietdonhang.Where(c => c.TinhTrangChiTiet != "Chưa xử lý").ToList();
            if (listhuydon.Count == 0)
                huydonhang = true;
            else
                huydonhang = false;
            ViewBag.HuyDonHang = huydonhang;
            return View(donhang);
        }

        public IActionResult DonMua(string tinhtrang)
        {
            if(tinhtrang == null || tinhtrang == "")
            {
                tinhtrang = "Chưa xử lý";
            }
            else
            {
                switch(tinhtrang)
                {
                    case "danggiao":
                        tinhtrang = "Đang giao";
                        break;
                    case "dangxuly":
                        tinhtrang = "Đang xử lý";
                        break;
                    case "daxuly":
                        tinhtrang = "Đã xử lý";
                        break;
                    case "dahuy":
                        tinhtrang = "Đã huỷ";
                        break;
                }
            }

            string sessionval = HttpContext.Session.GetString("TenDangNhap");
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            TaiKhoan taikhoan = new TaiKhoan();
            DonHangBUS donhangbus = new DonHangBUS();
            List<DonHang> listdonhang = new List<DonHang>();
            List<ChiTietDonHang> listchitietdonhang = new List<ChiTietDonHang>();
            if (sessionval != "" && sessionval != null)
            {
                taikhoan = taikhoanbus.CheckTaiKhoan(sessionval);
                listdonhang = donhangbus.GetDonHang(taikhoan.TenDangNhap, tinhtrang);
                listchitietdonhang = donhangbus.GetChiTietDonHang(taikhoan.TenDangNhap, tinhtrang);
            }
            else
            {
                taikhoan = null;
                listdonhang = null;
            }
            HangSanPhamBUS hangsanphambus = new HangSanPhamBUS();
            List<HangSanPham> hang = hangsanphambus.GetHangSanPhams();
            ViewBag.Hang = hang;
            ViewBag.TaiKhoan = taikhoan;
            ViewBag.ChiTietDonHang = listchitietdonhang;
            return View(listdonhang);
        }

        public void HuyDonMua(string madonhang)
        {
            string sessionval = HttpContext.Session.GetString("TenDangNhap");
            if (sessionval != "" && sessionval != null)
            {
                DonHangBUS donhangbus = new DonHangBUS();
                donhangbus.HuyDonHang(madonhang);
            }
        }

        public string ThemDiaChi(string tendangnhap, string diachi, string tinhthanh)
        {
            string checktendangnhap = HttpContext.Session.GetString("TenDangNhap");
            if (checktendangnhap != null && checktendangnhap != "")
            {
                DiaChiBUS diachibus = new DiaChiBUS();
                string thongbao = diachibus.CreateDiaChi(tendangnhap, diachi, tinhthanh);
                return thongbao;
            }
            return "";
        }

        public string SuaDiaChi(string id, string diachi, string tinhthanh)
        {
            string checktendangnhap = HttpContext.Session.GetString("TenDangNhap");
            if (checktendangnhap != null && checktendangnhap != "")
            {
                DiaChiBUS diachibus = new DiaChiBUS();
                string thongbao = diachibus.EditDiaChi(id, diachi, tinhthanh);
                return thongbao;
            }
            return "";
        }

        public string KhoaDiaChi(string id)
        {
            string checktendangnhap = HttpContext.Session.GetString("TenDangNhap");
            if (checktendangnhap != null && checktendangnhap != "")
            {
                DiaChiBUS diachibus = new DiaChiBUS();
                string thongbao = diachibus.LockDiaChi(id);
                thongbao = "Xoá thành công";
                return thongbao;
            }
            return "";
        }

        public string EditThongTin(string tendangnhap, string email, string sdt)
        {
            string checktendangnhap = HttpContext.Session.GetString("TenDangNhap");
            if (checktendangnhap != null && checktendangnhap != "")
            {
                TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
                string thongbao = taikhoanbus.EditTaiKhoan(tendangnhap, null, null, null, email, sdt, null);
                return thongbao;
            }
            return "";
        }

        public async Task<IActionResult> CreateTaiKhoan(string tendangnhap, string matkhau, string confirmmatkhau, string ten, string email, string diachi, string tinhthanh)
        {
            string thongbao = "";
            if (matkhau != confirmmatkhau)
            {
                thongbao = "Mật khẩu không trùng nhau";
                return RedirectToAction("Index", "Home", new { thongbao = thongbao });
            }

            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            thongbao = taikhoan.CreateTaiKhoan(tendangnhap, matkhau, ten, "", email, "", "", "15CF8A9B-517E-4BAE-91E2-F30C596990ED", "Chưa kích hoạt");

            DiaChiBUS diachibus = new DiaChiBUS();
            CreateDiaChi(tendangnhap, diachi, tinhthanh);

            if (thongbao == "Vui lòng kiểm tra hộp thư email để kích hoạt tài khoản")
            {
                await ActivationMail(tendangnhap);
            }
            return RedirectToAction("Index", "Home", new { thongbao = thongbao });
        }

        public void CreateDiaChi(string tendangnhap, string diachi, string tinhthanh)
        {
            DiaChiBUS diachibus = new DiaChiBUS();
            diachibus.CreateDiaChi(tendangnhap, diachi, tinhthanh);
        }

        public IActionResult EditTaiKhoan(string tendangnhap, string ten, string email, string dienthoai)
        {
            string checktendangnhap = HttpContext.Session.GetString("TenDangNhap");
            if (checktendangnhap != null && checktendangnhap != "")
            {
                TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
                string thongbao = taikhoanbus.EditTaiKhoan(tendangnhap, null, ten, null, email, dienthoai, null);
                return RedirectToAction("Index", "Home", new { thongbao = thongbao });
            }
            return RedirectToAction("Index", "Home");
        }

        public string EditPassword(string tendangnhap, string matkhaucu, string matkhaumoi)
        {
            string checktendangnhap = HttpContext.Session.GetString("TenDangNhap");
            if (checktendangnhap != null && checktendangnhap != "")
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
            return "";
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
            kichhoat += "https://" + local.ToString() + "/Customer/TaiKhoan/Activate?key=" + taikhoan.Id;
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
            kichhoat += "https://" + local.ToString() + "/Customer/Home/ResetPassword?key=" + taikhoan.Id;
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

        public string AddToCart(string idsizesanpham, int soluong)
        {
            string checktendangnhap = HttpContext.Session.GetString("TenDangNhap");
            if (checktendangnhap != null && checktendangnhap != "")
            {
                string tendangnhap = HttpContext.Session.GetString("TenDangNhap");
                TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
                TaiKhoan taikhoan = taikhoanbus.CheckTaiKhoan(tendangnhap);
                GioHangBUS giohangbus = new GioHangBUS();
                string thongbao = giohangbus.AddToCart(taikhoan.Id.ToString(), idsizesanpham, soluong);
                return thongbao;
            }
            return "";
        }

        public string CheckSoLuongCart(string idsizesanpham, int soluong)
        {
            GioHangBUS giohangbus = new GioHangBUS();
            string thongbao = giohangbus.CheckSoLuongCart(idsizesanpham, soluong);
            return thongbao;
        }

        public IActionResult DeleteFromCart(string idsizesanpham)
        {
            string checktendangnhap = HttpContext.Session.GetString("TenDangNhap");
            if (checktendangnhap != null && checktendangnhap != "")
            {
                string tendangnhap = HttpContext.Session.GetString("TenDangNhap");
                TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
                TaiKhoan taikhoan = taikhoanbus.CheckTaiKhoan(tendangnhap);
                GioHangBUS giohangbus = new GioHangBUS();
                string thongbao = giohangbus.DeleteFromCart(taikhoan.Id.ToString(), idsizesanpham);
                return RedirectToAction("GioHang", "SanPham", new { tendangnhap = tendangnhap });
            }
            return RedirectToAction("Index", "Home");
        }
        //var list = ctx.ChiTietDonHang..GroupBy(s => s.IdDonHang).Count();
    }
}