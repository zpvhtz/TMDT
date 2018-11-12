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
    public class TinhThanhController : Controller
    {
        const int pageSize = 10;
        int pageNumber = 1;

        public int TongTrang(List<TinhThanh> list)
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
            TinhThanhBUS TinhThanh = new TinhThanhBUS();
            List<TinhThanh> list = TinhThanh.GetTinhThanhs(pageNumber, pageSize);
            List<TinhThanh> tong = TinhThanh.GetTinhThanhs();
            //ViewBag
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
            return View(list);
        }

        public IActionResult CreateTinhThanh(string item_them_maTinhThanh, string item_them_tenTinhThanh)
        {
            TinhThanhBUS TinhThanh = new TinhThanhBUS();
            string thongbao = TinhThanh.CreateTinhThanh(item_them_maTinhThanh, item_them_tenTinhThanh);
            return RedirectToAction("Index", "TinhThanh", new { thongbao = thongbao });
        }

        public IActionResult EditTinhThanh(string item_sua_maTinhThanh, string item_sua_tenTinhThanh)
        {
            TinhThanhBUS TinhThanh = new TinhThanhBUS();
            string thongbao = TinhThanh.EditTinhThanh(item_sua_maTinhThanh, item_sua_tenTinhThanh);
            return RedirectToAction("Index", "TinhThanh", new { thongbao = thongbao });
        }

        public IActionResult LockTinhThanh(string maTinhThanh)
        {
            TinhThanhBUS TinhThanh = new TinhThanhBUS();
            string thongbao = TinhThanh.LockTinhThanh(maTinhThanh);
            return RedirectToAction("Index", "TinhThanh", new { thongbao = thongbao });
        }

        public IActionResult UnlockTinhThanh(string maTinhThanh)
        {
            TinhThanhBUS TinhThanh = new TinhThanhBUS();
            string thongbao = TinhThanh.UnlockTinhThanh(maTinhThanh);
            return RedirectToAction("Index", "TinhThanh", new { thongbao = thongbao });
        }

        public IActionResult Sort(string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            TinhThanhBUS TinhThanh = new TinhThanhBUS();
            List<TinhThanh> list = TinhThanh.Sort(sortorder, pageSize, pageNumber);
            List<TinhThanh> tong = TinhThanh.Sort(sortorder);

            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "sort";
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }
        public IActionResult Search(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            TinhThanhBUS TinhThanh = new TinhThanhBUS();
            List<TinhThanh> list = TinhThanh.Search(search, pageSize, pageNumber);
            List<TinhThanh> tong = TinhThanh.Search(search, pageSize);

            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            return View("Index", list);
        }

        public IActionResult SearchAndSort(string search, string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            TinhThanhBUS TinhThanh = new TinhThanhBUS();
            List<TinhThanh> list = TinhThanh.SearchAndSort(search, sortorder, pageSize, pageNumber);
            List<TinhThanh> tong = TinhThanh.SearchAndSort(search, sortorder, pageSize);

            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "searchandsort";
            ViewBag.Search = search;
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }
    }
}