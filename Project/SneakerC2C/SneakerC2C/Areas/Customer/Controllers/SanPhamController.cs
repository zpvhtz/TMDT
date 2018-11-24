using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.BusinessLogicLayer;
using Models.Database;

namespace SneakerC2C.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class SanPhamController : BaseController
    {
        const int pageSize = 11;
        int pageNumber = 1;
        private readonly QLBanGiayContext ctx;
        public SanPhamController(QLBanGiayContext context)
        {
            ctx = context;
        }
        public IActionResult Index(string id)
        {
            string idd = id ?? "B77D9CF5-E9A2-4D31-9490-25E4E3971C61";
            //BUS
            SanPhamBUS sanphambus = new SanPhamBUS();
            SizeSanPhamBUS sizesanphambus = new SizeSanPhamBUS();
            GioHangBUS giohangbus = new GioHangBUS();

            SanPham sanpham = sanphambus.GetSanPham(idd);
            List<SizeSanPham> listsizesanpham = sizesanphambus.GetSize(idd);
            ViewBag.ListSizeSanPham = listsizesanpham;
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.Hang = hang;
            return View(sanpham);
        }
        //trang list san pham
        public IActionResult List(string ploai, int? pagenumber)
        {
            //List<SanPham> list = ctx.SanPham.Where(x => x.PhanLoai == ploai).ToList();
            //List<SanPham> list = ctx.SanPham.Where(sp => sp.PhanLoai == ploai)
            //                                .Include(sp=>sp.IdTaiKhoanNavigation)
            //                                .Include(sp=>sp.IdHangSanPhamNavigation)
            //                                .ToList();
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.Hang = hang;
            //Trang
            pageNumber = pagenumber ?? 1;
            SanPhamBUS sanphambus = new SanPhamBUS();
            List<SanPham> list = sanphambus.GetSanPhams(ploai, pageNumber, pageSize);
            List<SanPham> tong = sanphambus.GetSanPhams(ploai);
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
            return View(list);
        }
        public IActionResult ThuongHieu(string mahang)
        {
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            List<SanPham> list = ctx.SanPham.Where(sp => sp.IdHangSanPhamNavigation.MaHang == mahang)
                                            .Include(sp => sp.IdTaiKhoanNavigation)
                                            .Include(sp => sp.IdHangSanPhamNavigation)
                                            .ToList();
            ViewBag.Hang = hang;
            return View("List",list);
        }

        public IActionResult Sort(string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            SanPhamBUS sanphambus = new SanPhamBUS();
            List<SanPham> list = sanphambus.Sort(sortorder, pageSize, pageNumber);
            List<SanPham> tong = sanphambus.Sort(sortorder);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "sort";
            ViewBag.Sort = sortorder;
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.Hang = hang;
            return View("List", list);
        }

        public IActionResult Search(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            SanPhamBUS sanphambus = new SanPhamBUS();
            List<SanPham> list = sanphambus.Search(search, pageSize, pageNumber);
            List<SanPham> tong = sanphambus.Search(search, pageSize);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.Hang = hang;
            return View("List", list);
        }

        public IActionResult SearchAndSort(string search, string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            SanPhamBUS sanphambus = new SanPhamBUS();
            List<SanPham> list = sanphambus.SearchAndSort(search, sortorder, pageSize, pageNumber);
            List<SanPham> tong = sanphambus.SearchAndSort(search, sortorder, pageSize);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "searchandsort";
            ViewBag.Search = search;
            ViewBag.Sort = sortorder;
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.Hang = hang;
            return View("List", list);
        }

        public int TongTrang(List<SanPham> list)
        {
            return ((list.Count / pageSize) + 1);
        }

    }
}