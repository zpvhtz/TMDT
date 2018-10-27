using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Database;

namespace SneakerC2C.Areas.Webmaster.Controllers
{
    [Area("Webmaster")]
    public class TaiKhoanController : Controller
    {
        public IActionResult Index(string thongbao)
        {
            if(thongbao != null)
            {
                ViewBag.ThongBao = thongbao;
            }

            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            List<TaiKhoan> list = taikhoan.GetTaiKhoans();
            return View(list);
        }

        public IActionResult EditTaiKhoan(string item_sua_tendangnhap, string item_sua_matkhau, string item_sua_email, string item_sua_dienthoai, string item_sua_cmnd)
        {
            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            string thongbao = taikhoan.EditTaiKhoan(item_sua_tendangnhap, item_sua_matkhau, item_sua_email, item_sua_dienthoai, item_sua_cmnd);
            return RedirectToAction("Index", "TaiKhoan", new { thongbao = thongbao});
        }

        public IActionResult LockTaiKhoan(string tendangnhap)
        {
            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            string thongbao = taikhoan.LockTaiKhoan(tendangnhap);
            return RedirectToAction("Index", "TaiKhoan", new { thongbao = thongbao });
        }

        public IActionResult UnlockTaiKhoan(string tendangnhap)
        {
            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            string thongbao = taikhoan.UnlockTaiKhoan(tendangnhap);
            return RedirectToAction("Index", "TaiKhoan", new { thongbao = thongbao });
        }
    }
}