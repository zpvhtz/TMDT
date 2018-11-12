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
    public class DiaChiController : Controller
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
            DiaChiBUS diachi = new DiaChiBUS();
            List<DiaChi> list = diachi.GetDiaChis(pageNumber, pageSize);
            List<DiaChi> tong = diachi.GetDiaChis();
            List<TinhThanh> tinhThanhs = diachi.GetTinhThanhs();
            //ViewBag
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
            ViewBag.ListTinhThanh = tinhThanhs;
            return View(list);
        }

        public IActionResult LockDiaChi(string iddiachi)
        {
            DiaChiBUS diachi = new DiaChiBUS();
            string thongbao = diachi.LockDiaChi(iddiachi);
            return RedirectToAction("Index", "DiaChi", new { thongbao = thongbao });
        }

        public IActionResult UnlockDiaChi(string iddiachi)
        {
            DiaChiBUS diachi = new DiaChiBUS();
            string thongbao = diachi.UnlockDiaChi(iddiachi);
            return RedirectToAction("Index", "DiaChi", new { thongbao = thongbao });
        }

        public IActionResult CreateDiaChi(string item_them_tendangnhap, string item_them_duong, string item_them_tinhthanh)
        {
            DiaChiBUS diachi = new DiaChiBUS();
            string thongbao = diachi.CreateDiaChi(item_them_tendangnhap, item_them_duong, item_them_tinhthanh);
            return RedirectToAction("Index", "DiaChi", new { thongbao = thongbao });
        }

        public IActionResult EditDiaChi(string item_sua_id, string item_sua_duong, string item_sua_tinhthanh)
        {
            DiaChiBUS diachi = new DiaChiBUS();
            string thongbao = diachi.EditDiaChi(item_sua_id, item_sua_duong, item_sua_tinhthanh);
            return RedirectToAction("Index", "DiaChi", new { thongbao = thongbao });
        }

        public IActionResult Sort(string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            DiaChiBUS diachi = new DiaChiBUS();
            List<DiaChi> list = diachi.Sort(sortorder, pageSize, pageNumber);
            List<DiaChi> tong = diachi.Sort(sortorder);
            List<TinhThanh> tinhThanhs = diachi.GetTinhThanhs();
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "sort";
            ViewBag.Sort = sortorder;
            ViewBag.ListTinhThanh = tinhThanhs;
            return View("Index", list);
        }

        public IActionResult Search(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            DiaChiBUS diachi = new DiaChiBUS();
            List<DiaChi> list = diachi.Search(search, pageSize, pageNumber);
            List<DiaChi> tong = diachi.Search(search, pageSize);
            List<TinhThanh> tinhThanhs = diachi.GetTinhThanhs();
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            ViewBag.ListTinhThanh = tinhThanhs;
            return View("Index", list);
        }

        public IActionResult SearchAndSort(string search, string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            DiaChiBUS diachi = new DiaChiBUS();
            List<DiaChi> list = diachi.SearchAndSort(search, sortorder, pageSize, pageNumber);
            List<DiaChi> tong = diachi.SearchAndSort(search, sortorder, pageSize);
            List<TinhThanh> tinhThanhs = diachi.GetTinhThanhs();
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "searchandsort";
            ViewBag.Search = search;
            ViewBag.Sort = sortorder;
            ViewBag.ListTinhThanh = tinhThanhs;
            return View("Index", list);
        }

        public int TongTrang(List<DiaChi> list)
        {
            return ((list.Count / pageSize) + 1);
        }
    }
}