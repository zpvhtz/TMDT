using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Database;
using Models.BusinessLogicLayer;
using Models.Database;
using Models.BusinessLogicLayer;

namespace SneakerC2C.Areas.Webmaster.Controllers
{
    [Area("Webmaster")]
    public class GiaShipController : BaseController
    {
        const int pageSize = 10;
        int pageNumber = 1;
        public int TongTrang(List<GiaShip> list)
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
            GiaShipBUS GiaShip = new GiaShipBUS();
            List<GiaShip> list = GiaShip.GetGiaShips(pageNumber, pageSize);
            List<GiaShip> tong = GiaShip.GetGiaShips();
            //ViewBag
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
            return View(list);
        }

        public IActionResult CreateGiaShip(string item_them_maGiaShip, string item_them_tenGiaShip)
        {
            double Gia = double.Parse(item_them_tenGiaShip);

            GiaShipBUS GiaShip = new GiaShipBUS();
            string thongbao = GiaShip.CreateGiaShip(item_them_maGiaShip, Gia);
            return RedirectToAction("Index", "GiaShip", new { thongbao = thongbao });
        }

        public IActionResult EditGiaShip(string item_sua_maGiaShip, string item_sua_tenGiaShip)
        {
            double Gia = double.Parse(item_sua_tenGiaShip);

            GiaShipBUS GiaShip = new GiaShipBUS();
            string thongbao = GiaShip.EditGiaShip(item_sua_maGiaShip, Gia);
            return RedirectToAction("Index", "GiaShip", new { thongbao = thongbao });
        }


        public IActionResult Sort(string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            GiaShipBUS GiaShip = new GiaShipBUS();
            List<GiaShip> list = GiaShip.Sort(sortorder, pageSize, pageNumber);
            List<GiaShip> tong = GiaShip.Sort(sortorder);

            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "sort";
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }
        public IActionResult Search(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            GiaShipBUS GiaShip = new GiaShipBUS();
            List<GiaShip> list = GiaShip.Search(search, pageSize, pageNumber);
            List<GiaShip> tong = GiaShip.Search(search, pageSize);

            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            return View("Index", list);
        }

        public IActionResult SearchAndSort(string search, string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            GiaShipBUS GiaShip = new GiaShipBUS();
            List<GiaShip> list = GiaShip.SearchAndSort(search, sortorder, pageSize, pageNumber);
            List<GiaShip> tong = GiaShip.SearchAndSort(search, sortorder, pageSize);

            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "searchandsort";
            ViewBag.Search = search;
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }

    }
}