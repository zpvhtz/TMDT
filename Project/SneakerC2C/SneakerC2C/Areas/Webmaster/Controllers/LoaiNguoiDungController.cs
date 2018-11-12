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
    public class LoaiNguoiDungController : Controller
    {
        const int pageSize = 10;
        int pageNumber = 1;
        public int TongTrang(List<LoaiNguoiDung> list)
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
            LoaiNguoiDungBUS loainguoidung = new LoaiNguoiDungBUS();
            List<LoaiNguoiDung> list = loainguoidung.GetLoaiNguoiDungs(pageNumber, pageSize);
            List<LoaiNguoiDung> tong = loainguoidung.GetLoaiNguoiDungs();
            //ViewBag
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
            return View(list);
        }

        public IActionResult CreateLoaiNguoiDung(string item_them_maloainguoidung, string item_them_tenloainguoidung)
        {
            LoaiNguoiDungBUS loainguoidung = new LoaiNguoiDungBUS();
            string thongbao = loainguoidung.CreateLoaiNguoiDung(item_them_maloainguoidung, item_them_tenloainguoidung);
            return RedirectToAction("Index", "LoaiNguoiDung", new { thongbao = thongbao });
        }

        public IActionResult EditLoaiNguoiDung(string item_sua_maloainguoidung, string item_sua_tenloainguoidung)
        {
            LoaiNguoiDungBUS loainguoidung = new LoaiNguoiDungBUS();
            string thongbao = loainguoidung.EditLoaiNguoiDung(item_sua_maloainguoidung,item_sua_tenloainguoidung);
            return RedirectToAction("Index", "LoaiNguoiDung", new { thongbao = thongbao });
        }

        public IActionResult LockLoaiNguoiDung(string maloainguoidung)
        {
            LoaiNguoiDungBUS loainguoidung = new LoaiNguoiDungBUS();
            string thongbao = loainguoidung.LockLoaiNguoiDung(maloainguoidung);
            return RedirectToAction("Index", "LoaiNguoiDung", new { thongbao = thongbao });
        }

        public IActionResult UnlockLoaiNguoiDung(string maloainguoidung)
        {
            LoaiNguoiDungBUS loainguoidung = new LoaiNguoiDungBUS();
            string thongbao = loainguoidung.UnlockLoaiNguoiDung(maloainguoidung);
            return RedirectToAction("Index", "LoaiNguoiDung", new { thongbao = thongbao });
        }

        public IActionResult Sort(string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            LoaiNguoiDungBUS loainguoidung = new LoaiNguoiDungBUS();
            List<LoaiNguoiDung> list = loainguoidung.Sort(sortorder, pageSize, pageNumber);
            List<LoaiNguoiDung> tong = loainguoidung.Sort(sortorder);

            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "sort";
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }
        public IActionResult Search(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            LoaiNguoiDungBUS loainguoidung = new LoaiNguoiDungBUS();
            List<LoaiNguoiDung> list = loainguoidung.Search(search, pageSize, pageNumber);
            List<LoaiNguoiDung> tong = loainguoidung.Search(search, pageSize);

            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            return View("Index", list);
        }

        public IActionResult SearchAndSort(string search, string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            LoaiNguoiDungBUS LoaiNguoiDung = new LoaiNguoiDungBUS();
            List<LoaiNguoiDung> list = LoaiNguoiDung.SearchAndSort(search, sortorder, pageSize, pageNumber);
            List<LoaiNguoiDung> tong = LoaiNguoiDung.SearchAndSort(search, sortorder, pageSize);

            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "searchandsort";
            ViewBag.Search = search;
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }

    }
}