using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.BusinessLogicLayer;
using Models.Database;

namespace SneakerC2C.Areas.Merchant.Controllers
{
    [Area("Merchant")]
    public class HomeController : Controller
    {
        public IActionResult Index(string thongbao)
        {
            //Thông báo
            if (thongbao != null)
            {
                ViewBag.ThongBao = thongbao;
            }
            TinhThanhBUS tinhthanhbus = new TinhThanhBUS();
            List<TinhThanh> list = tinhthanhbus.GetTinhThanhs();
            return View(list);
        }

        public IActionResult ResetPassword(string key)
        {
            TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
            TaiKhoan taikhoan = taikhoanbus.CheckTaiKhoanResetPassword(key);
            return View(taikhoan);
        }
    }
}