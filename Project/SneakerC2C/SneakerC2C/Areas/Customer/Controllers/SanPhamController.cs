using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.BusinessLogicLayer;
using Models.Database;

namespace SneakerC2C.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class SanPhamController : BaseController
    {
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
    }
}