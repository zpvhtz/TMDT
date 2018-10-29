using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Database;
using Models.BusinessLogicLayer;
using Models.Database;
using Models.BusinessLogicLayer;

namespace SneakerC2C.Areas.Webmaster.Controllers
{
    [Area("Webmaster")]
    public class LoaiNguoiDungController : Controller
    {
        public IActionResult Index(string searchString, int page = 1, int pageSize = 8)
        {
            var temp = new LoaiNguoiDungBUS();
            var model = temp.listAllPaging(searchString, page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var temp = new LoaiNguoiDungBUS().ViewDetail(id);
            return View(temp);
        }

        [HttpPost]
        public ActionResult Create(LoaiNguoiDung loainguoidung)
        {
            if (ModelState.IsValid)
            {
                var bus = new LoaiNguoiDungBUS();
                string id = bus.Insert(loainguoidung);
                if (id != null) // if insert success, back to index
                {
                    return RedirectToAction("Index", "LoaiNguoiDung");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Đại lý Thất Bại!");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(LoaiNguoiDung nguoidung)
        {
            if (ModelState.IsValid)
            {
                var temp = new LoaiNguoiDungBUS();
                var result = temp.Update(nguoidung);
                if (result) // if update success, back to index
                {
                    return RedirectToAction("Index", "LoaiNguoiDung");
                }
                else
                {
                    ModelState.AddModelError("", "Cập Nhật Thất Bại!");
                }
            }
            return View("Index");
        }
        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    //var dao = new Model.DAO.DaiLyDAO();
        //    //var result = dao.Delete(id);
        //    //return RedirectToAction("Index", "DaiLy");

        //}

    }
}