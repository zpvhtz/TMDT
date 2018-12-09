using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Database;
using Models.BusinessLogicLayer;

namespace SneakerC2C.Areas.Webmaster.Controllers
{
    [Area("Webmaster")]
    public class DonHang_WebmasterController : Controller
    {
        const int pageSize = 10;
        int pageNumber = 1;
        public int TongTrang(List<DonHang> list)
        {
            return ((list.Count / pageSize) + 1);
        }
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
            DonHangBUS_Webmaster DonHang = new DonHangBUS_Webmaster();
            List<DonHang> list = DonHang.GetDonHangs(pageNumber, pageSize);
            List<DonHang> tong = DonHang.GetDonHangs();
            //ViewBag
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
            return View(list);
        }

        public IActionResult EditDonHang(string item_sua_madonhang, string item_sua_cmndnguoigiao, string item_sua_tinhtrang)
        {
            DonHangBUS_Webmaster DonHang = new DonHangBUS_Webmaster();
            string thongbao = DonHang.EditDonHang(item_sua_madonhang, item_sua_cmndnguoigiao, item_sua_tinhtrang);
            return RedirectToAction("Index", "DonHang_Webmaster", new { thongbao = thongbao });
        }

        public IActionResult Sort(string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            DonHangBUS_Webmaster DonHang = new DonHangBUS_Webmaster();
            List<DonHang> list = DonHang.Sort(sortorder, pageSize, pageNumber);
            List<DonHang> tong = DonHang.Sort(sortorder);

            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "sort";
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }
        public IActionResult Search(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            DonHangBUS_Webmaster DonHang = new DonHangBUS_Webmaster();
            List<DonHang> list = DonHang.Search(search, pageSize, pageNumber);
            List<DonHang> tong = DonHang.Search(search, pageSize);

            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            return View("Index", list);
        }

        public IActionResult SearchAndSort(string search, string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            DonHangBUS_Webmaster DonHang = new DonHangBUS_Webmaster();
            List<DonHang> list = DonHang.SearchAndSort(search, sortorder, pageSize, pageNumber);
            List<DonHang> tong = DonHang.SearchAndSort(search, sortorder, pageSize);

            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "searchandsort";
            ViewBag.Search = search;
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }
    }
}