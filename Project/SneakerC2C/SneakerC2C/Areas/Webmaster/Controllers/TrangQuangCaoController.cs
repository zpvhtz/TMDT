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
    public class TrangQuangCaoController : Controller
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
            TrangQuangCaoBUS trang = new TrangQuangCaoBUS();
            List<TrangQuangCao> list = trang.GetTrangQuangCaos(pageNumber, pageSize);
            List<TrangQuangCao> tong = trang.GetTrangQuangCaos();
            //ViewBag
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
            return View(list);
        }

        public IActionResult CreateTrangQuangCao(string item_them_ma, string item_them_ten, string item_them_chuthich)
        {
            TrangQuangCaoBUS trang = new TrangQuangCaoBUS();
            string thongbao = trang.CreateTrangQuangCao(item_them_ma, item_them_ten, item_them_chuthich);
            return RedirectToAction("Index", "TrangQuangCao", new { thongbao = thongbao });
        }

        public IActionResult EditTrangQuangCao(string item_sua_ma, string item_sua_ten, string item_sua_chuthich)
        {
            TrangQuangCaoBUS trang = new TrangQuangCaoBUS();
            string thongbao = trang.EditTrangQuangCao(item_sua_ma, item_sua_ten, item_sua_chuthich);
            return RedirectToAction("Index", "TrangQuangCao", new { thongbao = thongbao });
        }

        public IActionResult LockTrangQuangCao(string matrang)
        {
            TrangQuangCaoBUS trang = new TrangQuangCaoBUS();
            string thongbao = trang.LockTrangQuangCao(matrang);
            return RedirectToAction("Index", "TrangQuangCao", new { thongbao = thongbao });
        }

        public IActionResult UnlockTrangQuangCao(string matrang)
        {
            TrangQuangCaoBUS trang = new TrangQuangCaoBUS();
            string thongbao = trang.UnlockTrangQuangCao(matrang);
            return RedirectToAction("Index", "TrangQuangCao", new { thongbao = thongbao });
        }

        public IActionResult Sort(string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            TrangQuangCaoBUS trang = new TrangQuangCaoBUS();
            List<TrangQuangCao> list = trang.Sort(sortorder, pageSize, pageNumber);
            List<TrangQuangCao> tong = trang.Sort(sortorder);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "sort";
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }

        public IActionResult Search(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            TrangQuangCaoBUS trang = new TrangQuangCaoBUS();
            List<TrangQuangCao> list = trang.Search(search, pageSize, pageNumber);
            List<TrangQuangCao> tong = trang.Search(search, pageSize);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            return View("Index", list);
        }

        public IActionResult SearchAndSort(string search, string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            TrangQuangCaoBUS trang = new TrangQuangCaoBUS();
            List<TrangQuangCao> list = trang.SearchAndSort(search, sortorder, pageSize, pageNumber);
            List<TrangQuangCao> tong = trang.SearchAndSort(search, sortorder, pageSize);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "searchandsort";
            ViewBag.Search = search;
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }

        public int TongTrang(List<TrangQuangCao> list)
        {
            return ((list.Count / pageSize) + 1);
        }
    }
}