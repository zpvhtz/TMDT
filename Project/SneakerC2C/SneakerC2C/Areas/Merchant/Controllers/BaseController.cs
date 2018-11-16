using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SneakerC2C.Areas.Merchant.Controllers
{
    [Area("Merchant")]
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext.Session.GetString("TenDangNhap") == null)
                context.Result = RedirectToAction("Index", "Authentication");
            base.OnActionExecuting(context);
        }
    }
}