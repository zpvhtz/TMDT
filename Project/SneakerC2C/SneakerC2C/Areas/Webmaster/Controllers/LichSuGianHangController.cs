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
            List<LichSuGianHang> list = lichsu.GetLichSuGianHangs(pageNumber, pageSize);
            List<LichSuGianHang> tong = lichsu.GetLichSuGianHangs();
            //ViewBag
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
            return View(list);
        }

        public int TongTrang(List<LichSuGianHang> list)
        {
            return ((list.Count / pageSize) + 1);
        }
    }
}