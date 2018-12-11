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
    public class ViTriQuangcaoController : BaseController
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
            TrangQuangCaoBUS trang = new TrangQuangCaoBUS();
            List<ViTriQuangcao> list = vitri.GetViTriQuangcaos(pageNumber, pageSize);
            List<ViTriQuangcao> tong = vitri.GetViTriQuangcaos();
            List<TrangQuangCao> listtqc = trang.GetTrangQuangCaos();
            //ViewBag
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
            ViewBag.TrangQuangCao = listtqc;
            return View(list);
        }

        public IActionResult CreateViTriQuangcao(string item_them_ma, string item_them_ten, string item_them_trangquangcao, double item_them_dongia, string item_them_chuthich)
        {
            ViTriQuangcaoBUS vitri = new ViTriQuangcaoBUS();
            string thongbao = vitri.CreateViTriQuangcao(item_them_ma, item_them_ten, item_them_trangquangcao, item_them_dongia, item_them_chuthich);
            return RedirectToAction("Index", "ViTriQuangcao", new { thongbao = thongbao });
        }

        public IActionResult EditViTriQuangcao(string item_sua_ma, string item_sua_ten, string item_sua_trangquangcao, double item_sua_dongia, string item_sua_chuthich)
        {
            ViTriQuangcaoBUS vitri = new ViTriQuangcaoBUS();
            string thongbao = vitri.EditViTriQuangcao(item_sua_ma, item_sua_ten, item_sua_trangquangcao, item_sua_dongia, item_sua_chuthich);
            return RedirectToAction("Index", "ViTriQuangcao", new { thongbao = thongbao });
        }

        public IActionResult LockViTriQuangcao(string mavitri)
        {
            ViTriQuangcaoBUS vitri = new ViTriQuangcaoBUS();
            string thongbao = vitri.LockViTriQuangcao(mavitri);
            return RedirectToAction("Index", "ViTriQuangcao", new { thongbao = thongbao });
        }

        public IActionResult UnlockViTriQuangcao(string mavitri)
        {
            ViTriQuangcaoBUS vitri = new ViTriQuangcaoBUS();
            string thongbao = vitri.UnlockViTriQuangcao(mavitri);
            return RedirectToAction("Index", "ViTriQuangcao", new { thongbao = thongbao });
        }
        public string CheckMa(string ma)
        {
            ViTriQuangcaoBUS vitri = new ViTriQuangcaoBUS();

            return vitri.CheckMa(ma);
        }

        public IActionResult Sort(string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            ViTriQuangcaoBUS vitri = new ViTriQuangcaoBUS();
            TrangQuangCaoBUS trang = new TrangQuangCaoBUS();
            List<ViTriQuangcao> list = vitri.Sort(sortorder, pageSize, pageNumber);
            List<ViTriQuangcao> tong = vitri.Sort(sortorder);
            List<TrangQuangCao> listtqc = trang.GetTrangQuangCaos();
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangQuangCao = listtqc;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "sort";
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }

        public IActionResult Search(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            ViTriQuangcaoBUS vitri = new ViTriQuangcaoBUS();
            TrangQuangCaoBUS trang = new TrangQuangCaoBUS();
            List<ViTriQuangcao> list = vitri.Search(search, pageSize, pageNumber);
            List<ViTriQuangcao> tong = vitri.Search(search, pageSize);
            List<TrangQuangCao> listtqc = trang.GetTrangQuangCaos();
            ViewBag.TrangHienTai = pageNumber;

            ViewBag.TrangQuangCao = listtqc;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            return View("Index", list);
        }

        public IActionResult SearchAndSort(string search, string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            ViTriQuangcaoBUS vitri = new ViTriQuangcaoBUS();
            TrangQuangCaoBUS trang = new TrangQuangCaoBUS();
            List<ViTriQuangcao> list = vitri.SearchAndSort(search, sortorder, pageSize, pageNumber);
            List<ViTriQuangcao> tong = vitri.SearchAndSort(search, sortorder, pageSize);
            List<TrangQuangCao> listtqc = trang.GetTrangQuangCaos();
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangQuangCao = listtqc;
            ViewBag.TrangThai = "searchandsort";
            ViewBag.Search = search;
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }

        public int TongTrang(List<ViTriQuangcao> list)
        {
            return ((list.Count / pageSize) + 1);
        }
    }
}