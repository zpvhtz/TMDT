﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SneakerC2C.Areas.Merchant.Controllers
{
    public class QuanLyController : BaseController
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
    }
}