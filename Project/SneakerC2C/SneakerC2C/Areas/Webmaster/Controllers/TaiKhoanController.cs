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
        const int pageSize = 10;
        int pageNumber = 1;

        public IActionResult Index(string thongbao, int? pagenumber)
        {
            //Thông báo
            if(thongbao != null)
            {
                ViewBag.ThongBao = thongbao;
            }
            //Trang
            pageNumber = pagenumber ?? 1;
            //List
            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            List<TaiKhoan> list = taikhoan.GetTaiKhoans(pageNumber, pageSize);
            List<TaiKhoan> tong = taikhoan.GetTaiKhoans();
            //ViewBag
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
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

        public IActionResult Sort(string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            List<TaiKhoan> list = taikhoan.Sort(sortorder, pageSize, pageNumber);
            List<TaiKhoan> tong = taikhoan.Sort(sortorder);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "sort";
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }

        public IActionResult Search(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            List<TaiKhoan> list = taikhoan.Search(search, pageSize, pageNumber);
            List<TaiKhoan> tong = taikhoan.Search(search, pageSize);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            return View("Index", list);
        }

        public IActionResult SearchAndSort(string search, string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            List<TaiKhoan> list = taikhoan.SearchAndSort(search, sortorder, pageSize, pageNumber);
            List<TaiKhoan> tong = taikhoan.SearchAndSort(search, sortorder, pageSize);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "searchandsort";
            ViewBag.Search = search;
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }

        public int TongTrang(List<TaiKhoan> list)
        {
            return ((list.Count / pageSize) + 1);
        }
    }
}