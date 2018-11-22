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
            return View(sanpham);
        }
        //trang list san pham
        public IActionResult List(/*string ploai*/)
        {
            //List<SanPham> list = ctx.SanPham.Where(x => x.PhanLoai == ploai).ToList();
            List<SanPham> list = ctx.SanPham
                                            .Include(sp=>sp.IdTaiKhoanNavigation)
                                            .Include(sp=>sp.IdHangSanPhamNavigation)
                                .ToList();
            return View(list);
        }


    }
}