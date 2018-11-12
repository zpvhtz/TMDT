using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.BusinessLogicLayer;
using Models.Database;

namespace SneakerC2C.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class SanPhamController : Controller
    {
        public IActionResult Index(string id)
        {
            string idd = id ?? "B77D9CF5-E9A2-4D31-9490-25E4E3971C61";
            SanPhamBUS sanphambus = new SanPhamBUS();
            SanPham sanpham = sanphambus.GetSanPham(idd);
            return View(sanpham);
        }
    }
}