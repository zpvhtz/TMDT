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
        [HttpGet]
        public JsonResult GetThongKeMerchant(string nbd, string nkt)
        {
            nbd = nbd ?? DateTime.Now.ToLongDateString();
            nkt = nkt ?? DateTime.Now.ToLongDateString();
            DateTime _nbd = DateTime.Parse(nbd);
            DateTime _nkt = DateTime.Parse(nkt);
            HomeBUS homeBus = new HomeBUS();
            List<DoanhThuMerchant> list = homeBus.GetDoanhThuMerchants(_nbd, _nkt);
            var json = JsonConvert.SerializeObject(list);
            var json2 = JsonConvert.DeserializeObject(json);
            return Json(json2);
        }

        public JsonResult GetSoLuongNguoiDung()
        {
            //nbd = nbd ?? DateTime.Now.ToLongDateString();
            //DateTime _nbd = DateTime.Parse(nbd);
            HomeBUS homeBus = new HomeBUS();
            List<SoLuongNguoiDung> list = homeBus.GetSoLuongNguoiDung();
            var json = JsonConvert.SerializeObject(list);
            var json2 = JsonConvert.DeserializeObject(json);
            return Json(json2);
        }
        public JsonResult GetThongKeQuangCao(string nbd, string nkt)
        {
            nbd = nbd ?? DateTime.Now.ToLongDateString();
            nkt = nkt ?? DateTime.Now.ToLongDateString();
            DateTime _nbd = DateTime.Parse(nbd);
            DateTime _nkt = DateTime.Parse(nkt);
            HomeBUS homeBus = new HomeBUS();
            List<DoanhThuQuangCao> list = homeBus.GetDoanhThuQuangCao(_nbd, _nkt);
            var json = JsonConvert.SerializeObject(list);
            var json2 = JsonConvert.DeserializeObject(json);
            return Json(json2);
        }
        public JsonResult GetThongKeGianHang(string nbd, string nkt)
        {
            nbd = nbd ?? DateTime.Now.ToLongDateString();
            nkt = nkt ?? DateTime.Now.ToLongDateString();
            DateTime _nbd = DateTime.Parse(nbd);
            DateTime _nkt = DateTime.Parse(nkt);
            HomeBUS homeBus = new HomeBUS();
            List<DoanhThuGianHang> list = homeBus.GetDoanhThuGianHang(_nbd, _nkt);
            var json = JsonConvert.SerializeObject(list);
            var json2 = JsonConvert.DeserializeObject(json);
            return Json(json2);
        }
    }
}