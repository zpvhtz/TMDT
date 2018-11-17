using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Models.BusinessLogicLayer;
using Models.Database;

namespace SneakerC2C.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext.Session.GetString("TenDangNhap") != null)
            {
                string sessionval = HttpContext.Session.GetString("TenDangNhap");
                TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
                TaiKhoan taikhoan = new TaiKhoan();
                taikhoan = taikhoanbus.CheckTaiKhoan(sessionval);
                if (taikhoan.IdLoaiNguoiDungNavigation.TenLoaiNguoiDung != "Khách hàng")
                {
                    HttpContext.Session.Remove("TenDangNhap");
                }
            }
            base.OnActionExecuting(context);
        }
    }
}