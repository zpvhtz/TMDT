using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.BusinessLogicLayer;
using Models.Database;

namespace SneakerC2C.Areas.Merchant.Controllers
{
    [Area("Merchant")]
    public class QuanLyTaiKhoanController : BaseController
    {
        public IActionResult ThongTinTaiKhoan()
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
            TinhThanhBUS tinhthanhbus = new TinhThanhBUS();
            List<TinhThanh> tinhthanh = tinhthanhbus.GetTinhThanhs();
            ViewBag.TinhThanh = tinhthanh;
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
            return View(taikhoan);
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
    }
}