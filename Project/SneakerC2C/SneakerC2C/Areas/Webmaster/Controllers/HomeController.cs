using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.BusinessLogicLayer;
using Models.DTO;
using Newtonsoft.Json;

namespace SneakerC2C.Areas.Webmaster.Controllers
{
    [Area("Webmaster")]
    public class HomeController : BaseController
    {
        public IActionResult Index(string thongbao)
        {
            //Thông báo
            if (thongbao != null)
            {
                ViewBag.ThongBao = thongbao;
            }
            
            return View();
        }

        public JsonResult GetThongKeMerchant()
        {
            DateTime nbd = DateTime.Parse("10/01/2018");
            DateTime nkt = DateTime.Parse("12/10/2018");
            HomeBUS homeBus = new HomeBUS();
            List<DoanhThuMerchant> list = homeBus.GetDoanhThuMerchants(nbd, nkt);
            var json = JsonConvert.SerializeObject(list);
            var json2 = JsonConvert.DeserializeObject(json);
            return Json(json2);
        }
    }
}