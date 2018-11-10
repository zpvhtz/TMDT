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
    public class LichSuGianHangController : Controller
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

        public TaiKhoan CheckTaiKhoan(string tendangnhap)
        {
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            TaiKhoan taikhoan = taikhoanbus.CheckTaiKhoan(tendangnhap);
            return taikhoan;
        }

        public int TongTrang(List<LichSuGianHang> list)
        {
            return ((list.Count / pageSize) + 1);
        }
    }
}