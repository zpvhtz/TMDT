using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.BusinessLogicLayer;
using Models.Database;

namespace SneakerC2C.Areas.Webmaster.Controllers
{
    [Area("Webmaster")]
    public class GianHangController : BaseController
    {
        const int pageSize = 10;
        int pageNumber = 1;

        public IActionResult Index(string thongbao, int? pagenumber)
        {
            //Thông báo
            if (thongbao != null)
            {
                ViewBag.ThongBao = thongbao;
            }
            //Trang
            pageNumber = pagenumber ?? 1;
            //List
            GianHangBUS gianhang = new GianHangBUS();
            List<GianHang> list = gianhang.GetGianHangs(pageNumber, pageSize);
            List<GianHang> tong = gianhang.GetGianHangs();
            //ViewBag
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
            return View(list);
        }

        public IActionResult CreateGianHang(string item_them_ma, string item_them_ten, float item_them_gia, int item_them_thoigian)
        {
            GianHangBUS gianhang = new GianHangBUS();
            string thongbao = gianhang.CreateGianHang(item_them_ma, item_them_ten, item_them_gia, item_them_thoigian);
            return RedirectToAction("Index", "GianHang", new { thongbao = thongbao });
        }

        public IActionResult EditGianHang(string item_sua_ma, string item_sua_ten, float item_sua_gia, int item_sua_thoigian)
        {
            GianHangBUS gianhang = new GianHangBUS();
            string thongbao = gianhang.EditGianHang(item_sua_ma, item_sua_ten, item_sua_gia, item_sua_thoigian);
            return RedirectToAction("Index", "GianHang", new { thongbao = thongbao });
        }

        public IActionResult LockGianHang(string magianhang)
        {
            GianHangBUS gianhang = new GianHangBUS();
            string thongbao = gianhang.LockGianHang(magianhang);
            return RedirectToAction("Index", "GianHang", new { thongbao = thongbao });
        }

        public IActionResult UnlockGianHang(string magianhang)
        {
            GianHangBUS gianhang = new GianHangBUS();
            string thongbao = gianhang.UnlockGianHang(magianhang);
            return RedirectToAction("Index", "GianHang", new { thongbao = thongbao });
        }

        public IActionResult Sort(string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            GianHangBUS gianhang = new GianHangBUS();
            List<GianHang> list = gianhang.Sort(sortorder, pageSize, pageNumber);
            List<GianHang> tong = gianhang.Sort(sortorder);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "sort";
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }

        public IActionResult Search(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            GianHangBUS gianhang = new GianHangBUS();
            List<GianHang> list = gianhang.Search(search, pageSize, pageNumber);
            List<GianHang> tong = gianhang.Search(search, pageSize);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            return View("Index", list);
        }

        public IActionResult SearchAndSort(string search, string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            GianHangBUS gianhang = new GianHangBUS();
            List<GianHang> list = gianhang.SearchAndSort(search, sortorder, pageSize, pageNumber);
            List<GianHang> tong = gianhang.SearchAndSort(search, sortorder, pageSize);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "searchandsort";
            ViewBag.Search = search;
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }

        public int TongTrang(List<GianHang> list)
        {
            return ((list.Count / pageSize) + 1);
        }
    }
}