using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Database;

namespace SneakerC2C.Areas.Webmaster.Controllers
{
    [Area("Webmaster")]
    public class HangSanPhamController : Controller
    {
        private readonly QLBanGiayContext ctx;
        public HangSanPhamController(QLBanGiayContext context)
        {
            ctx = context;
        }
        public IActionResult Index()
        {
            List<HangSanPham> list = ctx.HangSanPham.ToList();
            return View(list);
        }

    }
}