using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Database;

namespace SneakerC2C.Areas.Webmaster.Controllers
{
    [Area("Webmaster")]
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            List<TaiKhoan> list = taikhoan.GetTaiKhoans();
            return View(list);
        }
    }
}