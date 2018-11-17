using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.BusinessLogicLayer;
using Models.Database;

namespace SneakerC2C.Areas.Webmaster.Controllers
{
    [Area("Webmaster")]
    public class TaiKhoanController : BaseController
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
            LoaiNguoiDungBUS loainguoidung = new LoaiNguoiDungBUS();
            List<TaiKhoan> list = taikhoan.GetTaiKhoans(pageNumber, pageSize);
            List<TaiKhoan> tong = taikhoan.GetTaiKhoans();
            List<LoaiNguoiDung> listlnd = loainguoidung.GetLoaiNguoiDungs();
            //ViewBag
            ViewBag.TinhThanh = taikhoan.GetTinhThanhs();
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.LoaiNguoiDung = listlnd;
            ViewBag.TrangThai = "index";
            return View(list);
        }

        public IActionResult CreateTaiKhoan(string item_them_tendangnhap, string item_them_matkhau, string item_them_ten, string item_them_tenshop, string item_them_email, string item_them_dienthoai, string item_them_cmnd, string item_them_loainguoidung)
        {
            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            string thongbao = taikhoan.CreateTaiKhoan(item_them_tendangnhap, item_them_matkhau, item_them_ten, item_them_tenshop, item_them_email, item_them_dienthoai, item_them_cmnd, item_them_loainguoidung, "Không khoá");
            return RedirectToAction("Index", "TaiKhoan", new { thongbao = thongbao });
        }

        public IActionResult EditTaiKhoan(string item_sua_tendangnhap, string item_sua_matkhau, string item_sua_email, string item_sua_dienthoai, string item_sua_cmnd)
        {
            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            string thongbao = taikhoan.EditTaiKhoan(item_sua_tendangnhap, item_sua_matkhau, item_sua_email, item_sua_dienthoai, item_sua_cmnd);
            return RedirectToAction("Index", "TaiKhoan");
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

        public IActionResult ActivateTaiKhoan(string tendangnhap)
        {
            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            string thongbao = taikhoan.ActivateTaiKhoan(tendangnhap);
            return RedirectToAction("Index", "TaiKhoan", new { thongbao = thongbao });
        }

        public IActionResult GetDiaChi(string tendangnhap)
        {
            DiaChiBUS diachi = new DiaChiBUS();
            TaiKhoanBUS tk = new TaiKhoanBUS();
            List<DiaChi> list = diachi.GetDiaChis(tendangnhap);
            ViewBag.TenDangNhap = tendangnhap;
            ViewBag.TinhThanh = tk.GetTinhThanhs();
            return PartialView("DiaChiPartialView", list);
        }

        public IActionResult GetThongTinDiaChi(string tendangnhap, string diachi)
        {
            DiaChiBUS dcbus = new DiaChiBUS();
            TaiKhoanBUS tk = new TaiKhoanBUS();
            DiaChi dc = dcbus.GetThongTinDiaChi(tendangnhap, diachi);
            ViewBag.TinhThanh = tk.GetTinhThanhs();
            return PartialView("SuaDiaChiPartialView", dc);
        }

        public IActionResult CreateDiaChi(string tendangnhap, string diachi, string tinhthanh)
        {
            DiaChiBUS dcbus = new DiaChiBUS();
            string thongbao = dcbus.CreateDiaChi(tendangnhap, diachi, tinhthanh);
            return RedirectToAction("Index", "TaiKhoan", new { thongbao = thongbao });
        }

        public IActionResult EditDiaChi(string id, string diachi, string tinhthanh)
        {
            DiaChiBUS dcbus = new DiaChiBUS();
            string thongbao = dcbus.EditDiaChi(id, diachi, tinhthanh);
            return RedirectToAction("Index", "TaiKhoan", new { thongbao = thongbao });
        }

        public IActionResult LockDiaChi(string id)
        {
            DiaChiBUS dcbus = new DiaChiBUS();
            string thongbao = dcbus.LockDiaChi(id);
            return RedirectToAction("Index", "TaiKhoan", new { thongbao = thongbao });
        }

        public IActionResult GetLichSuGianHang(string tendangnhap)
        {
            LichSuGianHangBUS lsgianhang = new LichSuGianHangBUS();
            List<LichSuGianHang> list = lsgianhang.GetLichSuGianHangs(tendangnhap);
            ViewBag.TenDangNhap = tendangnhap;
            return PartialView("LichSuGianHangPartialView", list);
        }

        public IActionResult Sort(string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            LoaiNguoiDungBUS loainguoidung = new LoaiNguoiDungBUS();
            List<TaiKhoan> list = taikhoan.Sort(sortorder, pageSize, pageNumber);
            List<TaiKhoan> tong = taikhoan.Sort(sortorder);
            List<LoaiNguoiDung> listlnd = loainguoidung.GetLoaiNguoiDungs();
            ViewBag.TinhThanh = taikhoan.GetTinhThanhs();
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "sort";
            ViewBag.LoaiNguoiDung = listlnd;
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }

        public IActionResult Search(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            LoaiNguoiDungBUS loainguoidung = new LoaiNguoiDungBUS();
            List<TaiKhoan> list = taikhoan.Search(search, pageSize, pageNumber);
            List<TaiKhoan> tong = taikhoan.Search(search, pageSize);
            List<LoaiNguoiDung> listlnd = loainguoidung.GetLoaiNguoiDungs();
            ViewBag.TinhThanh = taikhoan.GetTinhThanhs();
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.LoaiNguoiDung = listlnd;
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            return View("Index", list);
        }

        public IActionResult SearchAndSort(string search, string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            LoaiNguoiDungBUS loainguoidung = new LoaiNguoiDungBUS();
            List<TaiKhoan> list = taikhoan.SearchAndSort(search, sortorder, pageSize, pageNumber);
            List<TaiKhoan> tong = taikhoan.SearchAndSort(search, sortorder, pageSize);
            List<LoaiNguoiDung> listlnd = loainguoidung.GetLoaiNguoiDungs();
            ViewBag.TinhThanh = taikhoan.GetTinhThanhs();
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.LoaiNguoiDung = listlnd;
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