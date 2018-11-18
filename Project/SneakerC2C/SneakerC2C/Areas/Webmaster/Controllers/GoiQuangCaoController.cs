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
    public class GoiQuangCaoController : BaseController
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
            //Lists
            ViTriQuangcaoBUS vitri = new ViTriQuangcaoBUS();
            GoiQuangCaoBUS goi = new GoiQuangCaoBUS();
            List<GoiQuangCao> list = goi.GetGoiQuangCaos(pageNumber, pageSize);
            List<GoiQuangCao> tong = goi.GetGoiQuangCaos();
            List<ViTriQuangcao> listvtqc = vitri.GetViTriQuangcaos();
            //ViewBag
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
            ViewBag.VitriQuangcao = listvtqc;
            return View(list);
        }

        public IActionResult CreateGoiQuangCao(string item_them_ma, string item_them_vitriquangcao, double item_them_tongtien, int item_them_thoiluong)
        {
            GoiQuangCaoBUS goi = new GoiQuangCaoBUS();
            string thongbao = goi.CreateGoiQuangCao(item_them_ma, item_them_vitriquangcao, item_them_tongtien, item_them_thoiluong);
            return RedirectToAction("Index", "GoiQuangCao", new { thongbao = thongbao });
        }

        public IActionResult EditGoiQuangCao(string item_sua_ma, string item_sua_vitriquangcao, double item_sua_tongtien, int item_sua_thoiluong)
        {
            GoiQuangCaoBUS goi = new GoiQuangCaoBUS();
            string thongbao = goi.EditGoiQuangCao(item_sua_ma, item_sua_vitriquangcao, item_sua_tongtien, item_sua_thoiluong);
            return RedirectToAction("Index", "GoiQuangCao", new { thongbao = thongbao });
        }

        public IActionResult LockGoiQuangCao(string magoi)
        {
            GoiQuangCaoBUS goi = new GoiQuangCaoBUS();
            string thongbao = goi.LockGoiQuangCao(magoi);
            return RedirectToAction("Index", "GoiQuangCao", new { thongbao = thongbao });
        }

        public IActionResult UnlockGoiQuangCao(string magoi)
        {
            GoiQuangCaoBUS goi = new GoiQuangCaoBUS();
            string thongbao = goi.UnlockGoiQuangCao(magoi);
            return RedirectToAction("Index", "GoiQuangCao", new { thongbao = thongbao });
        }

        public double GetDongia(string id)
        {
            ViTriQuangcaoBUS vitri = new ViTriQuangcaoBUS();
            double dongia = vitri.GetDonGia(id);
            return dongia;
        }


        public IActionResult Sort(string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            ViTriQuangcaoBUS vitri = new ViTriQuangcaoBUS();
            GoiQuangCaoBUS goi = new GoiQuangCaoBUS();
            List<GoiQuangCao> list = goi.Sort(sortorder, pageSize, pageNumber);
            List<GoiQuangCao> tong = goi.Sort(sortorder);
            List<ViTriQuangcao> listvtqc = vitri.GetViTriQuangcaos();
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.ViTriQuangcao = listvtqc;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "sort";
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }

        public IActionResult Search(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            ViTriQuangcaoBUS vitri = new ViTriQuangcaoBUS();
            GoiQuangCaoBUS goi = new GoiQuangCaoBUS();
            List<GoiQuangCao> list = goi.Search(search, pageSize, pageNumber);
            List<GoiQuangCao> tong = goi.Search(search, pageSize);
            List<ViTriQuangcao> listvtqc = vitri.GetViTriQuangcaos();
            ViewBag.TrangHienTai = pageNumber;

            ViewBag.ViTriQuangcao = listvtqc;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            return View("Index", list);
        }

        public IActionResult SearchAndSort(string search, string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            ViTriQuangcaoBUS vitri = new ViTriQuangcaoBUS();
            GoiQuangCaoBUS goi = new GoiQuangCaoBUS();
            List<GoiQuangCao> list = goi.SearchAndSort(search, sortorder, pageSize, pageNumber);
            List<GoiQuangCao> tong = goi.SearchAndSort(search, sortorder, pageSize);
            List<ViTriQuangcao> listvtqc = vitri.GetViTriQuangcaos();
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.ViTriQuangcao = listvtqc;
            ViewBag.TrangThai = "searchandsort";
            ViewBag.Search = search;
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }

        public int TongTrang(List<GoiQuangCao> list)
        {
            return ((list.Count / pageSize) + 1);
        }
    }
}