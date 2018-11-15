using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.BusinessLogicLayer;
using Models.Database;

namespace SneakerC2C.Areas.Webmaster.Controllers
{
    [Area("Webmaster")]
    public class LichSuGianHangController : BaseController
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
            LichSuGianHangBUS lichsu = new LichSuGianHangBUS();
            GianHangBUS gianhang = new GianHangBUS();
            List<LichSuGianHang> list = lichsu.GetLichSuGianHangs(pageNumber, pageSize);
            List<LichSuGianHang> tong = lichsu.GetLichSuGianHangs();
            List<GianHang> listgh = gianhang.GetGianHangs();
            //ViewBag
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
            ViewBag.ListGianHang = listgh;
            return View(list);
        }

        public IActionResult CreateLichSuGianHang(string item_them_tendangnhap, string item_them_gianhang)
        {
            LichSuGianHangBUS lsghbus = new LichSuGianHangBUS();
            string thongbao = lsghbus.CreateLichSuGianHang(item_them_tendangnhap, item_them_gianhang);
            return RedirectToAction("Index", "LichSuGianHang", new { thongbao = thongbao });
        }

        public IActionResult EditLichSuGianHang(string item_sua_id, string item_sua_gianhang)
        {
            LichSuGianHangBUS lsghbus = new LichSuGianHangBUS();
            string thongbao = lsghbus.EditLichSuGianHang(item_sua_id, item_sua_gianhang);
            return RedirectToAction("Index", "LichSuGianHang", new { thongbao = thongbao });
        }

        public double GetGiaTien(string id)
        {
            GianHangBUS gianhang = new GianHangBUS();
            double giatien = gianhang.GetGiaTien(id);
            return giatien;
        }

        public int GetThoiGian(string id)
        {
            GianHangBUS gianhang = new GianHangBUS();
            int thoigian = gianhang.GetThoiGian(id);
            return thoigian;
        }

        public IActionResult LockLichSuGianHang(string id)
        {
            LichSuGianHangBUS lsghbus = new LichSuGianHangBUS();
            string thongbao = lsghbus.LockLichSuGianHang(id);
            return RedirectToAction("Index", "LichSuGianHang", new { thongbao = thongbao });
        }

        public TaiKhoan CheckTaiKhoan(string tendangnhap)
        {
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            TaiKhoan taikhoan = taikhoanbus.CheckTaiKhoan(tendangnhap);
            return taikhoan;
        }

        public IActionResult Sort(string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            LichSuGianHangBUS gianhang = new LichSuGianHangBUS();
            GianHangBUS gh = new GianHangBUS();
            List<LichSuGianHang> list = gianhang.Sort(sortorder, pageSize, pageNumber);
            List<LichSuGianHang> tong = gianhang.Sort(sortorder);
            List<GianHang> listgh = gh.GetGianHangs();
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "sort";
            ViewBag.Sort = sortorder;
            ViewBag.ListGianHang = listgh;
            return View("Index", list);
        }

        public IActionResult Search(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            LichSuGianHangBUS gianhang = new LichSuGianHangBUS();
            GianHangBUS gh = new GianHangBUS();
            List<LichSuGianHang> list = gianhang.Search(search, pageSize, pageNumber);
            List<LichSuGianHang> tong = gianhang.Search(search, pageSize);
            List<GianHang> listgh = gh.GetGianHangs();
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            ViewBag.ListGianHang = listgh;
            return View("Index", list);
        }

        public IActionResult SearchAndSort(string search, string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            LichSuGianHangBUS gianhang = new LichSuGianHangBUS();
            GianHangBUS gh = new GianHangBUS();
            List<LichSuGianHang> list = gianhang.SearchAndSort(search, sortorder, pageSize, pageNumber);
            List<LichSuGianHang> tong = gianhang.SearchAndSort(search, sortorder, pageSize);
            List<GianHang> listgh = gh.GetGianHangs();
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "searchandsort";
            ViewBag.Search = search;
            ViewBag.Sort = sortorder;
            ViewBag.ListGianHang = listgh;
            return View("Index", list);
        }

        public int TongTrang(List<LichSuGianHang> list)
        {
            return ((list.Count / pageSize) + 1);
        }
    }
}