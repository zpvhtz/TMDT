﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SneakerC2C.Areas.Merchant.Controllers
{
    [Area("Merchant")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}