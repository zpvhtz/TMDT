using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.BusinessLogicLayer;
using Models.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Models.DTO;
using System.Globalization;

namespace SneakerC2C.Areas.Webmaster.Controllers
{
    [Area("Webmaster")]
    public class QuangCaoController : BaseController
    {    
        const int pageSize = 10;
        int pageNumber = 1;
       
        public IActionResult Index(string thongbao, int? pagenumber)
        {
            
            //Thông báo
            if (thongbao != null)
            {
                ViewBag.ThongBao = thongbao;
            }
            //Trang
            pageNumber = pagenumber ?? 1;
            //Lists
            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            GoiQuangCaoBUS goi = new GoiQuangCaoBUS();
            QuangCaoBUS quangcao = new QuangCaoBUS();

            List<QuangCao> list = quangcao.GetQuangCaos(pageNumber, pageSize);
            List<QuangCao> tong = quangcao.GetQuangCaos();
            List<GoiQuangCao> listgqc = goi.GetGoiQuangCaos();
            List<TaiKhoan> listtk = taikhoan.GetTaiKhoans();

            //ViewBag
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
            ViewBag.GoiQuangCao = listgqc;
            ViewBag.TaiKhoan = listtk;
            return View(list);
        }

        public IActionResult CreateQuangCao(/*string item_them_ma, */string item_them_goiquangcao, string item_them_taikhoan, IFormFile item_them_hinh, int item_them_nam, int item_them_thang, int item_them_ngay, string item_them_ngayketthuc, string item_them_duongdan, string item_them_chuthich)
        {
            QuangCaoBUS quangcao = new QuangCaoBUS();
            DateTime item_them_ngaybatdau = new DateTime(item_them_nam, item_them_thang, item_them_ngay);
           // DateTime ngayketthuc = DateTime.ParseExact(item_them_ngayketthuc, "d/M/yyyy", CultureInfo.InvariantCulture);

            var uniqueFileName = GetUniqueFileName(item_them_hinh.FileName);
                var fileName = Path.GetFileName(item_them_hinh.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Hinh\\QuangCao", fileName);
            var filestream = new FileStream(filePath, FileMode.Create);
                item_them_hinh.CopyTo(filestream);
                string hinh = fileName;
            filestream.Close();
                
               

                string thongbao = quangcao.CreateQuangCao(/*item_them_ma, */item_them_goiquangcao, item_them_taikhoan, hinh, item_them_ngaybatdau, item_them_duongdan, item_them_chuthich);
                
            return RedirectToAction("Index", "QuangCao", new { thongbao = thongbao });
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

        public IActionResult EditQuangCao(string item_sua_ma, string item_sua_goiquangcao, string item_sua_taikhoan, IFormFile item_sua_hinh, DateTime item_sua_ngaybatdau, DateTime item_sua_ngayketthuc, string item_sua_duongdan, string item_sua_chuthich)
        {
            QuangCaoBUS quangcao = new QuangCaoBUS();
            string hinh;
            if (item_sua_hinh != null)
            {
                var uniqueFileName = GetUniqueFileName(item_sua_hinh.FileName);
                var fileName = Path.GetFileName(item_sua_hinh.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Hinh\\QuangCao", fileName);
                var filestream = new FileStream(filePath, FileMode.Create);
                item_sua_hinh.CopyTo(filestream);
                filestream.Close();
                hinh = fileName;
            }
            else hinh = null;
            string thongbao = quangcao.EditQuangCao(item_sua_ma, item_sua_goiquangcao, item_sua_taikhoan, hinh, item_sua_ngaybatdau, item_sua_ngayketthuc, item_sua_duongdan, item_sua_chuthich);
            return RedirectToAction("Index", "QuangCao", new { thongbao = thongbao });
        }

        public IActionResult LockQuangCao(string maquangcao)
        {
            QuangCaoBUS quangcao = new QuangCaoBUS();
            string thongbao = quangcao.LockQuangCao(maquangcao);
            return RedirectToAction("Index", "QuangCao", new { thongbao = thongbao });
        }

        public IActionResult LockQuangCao2(string maquangcao)
        {
            QuangCaoBUS quangcao = new QuangCaoBUS();
            string thongbao = quangcao.LockQuangCao2(maquangcao);
            return RedirectToAction("Index", "QuangCao", new { thongbao = thongbao });
        }

        public IActionResult UnlockQuangCao(string maquangcao)
        {
            QuangCaoBUS quangcao = new QuangCaoBUS();
            string thongbao = quangcao.UnlockQuangCao(maquangcao);
            return RedirectToAction("Index", "QuangCao", new { thongbao = thongbao });
        }


        public IActionResult Sort(string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            GoiQuangCaoBUS goi = new GoiQuangCaoBUS();
            QuangCaoBUS quangcao = new QuangCaoBUS();
            List<QuangCao> list = quangcao.Sort(sortorder, pageSize, pageNumber);
            List<QuangCao> tong = quangcao.Sort(sortorder);
            List<GoiQuangCao> listgqc = goi.GetGoiQuangCaos();
            List<TaiKhoan> listtk = taikhoan.GetTaiKhoans();
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.GoiQuangCao = listgqc;
            ViewBag.TaiKhoan = listtk;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "sort";
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }

        public IActionResult Search(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            GoiQuangCaoBUS goi = new GoiQuangCaoBUS();
            QuangCaoBUS quangcao = new QuangCaoBUS();
            List<QuangCao> list = quangcao.Search(search, pageSize, pageNumber);
            List<QuangCao> tong = quangcao.Search(search, pageSize);
            List<GoiQuangCao> listgqc = goi.GetGoiQuangCaos();
            List<TaiKhoan> listtk = taikhoan.GetTaiKhoans();
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TaiKhoan = listtk;
            ViewBag.GoiQuangCao = listgqc;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            return View("Index", list);
        }

        public IActionResult SearchAndSort(string search, string sortorder, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            TaiKhoanBUS taikhoan = new TaiKhoanBUS();
            GoiQuangCaoBUS goi = new GoiQuangCaoBUS();
            QuangCaoBUS quangcao = new QuangCaoBUS();
            List<QuangCao> list = quangcao.SearchAndSort(search, sortorder, pageSize, pageNumber);
            List<QuangCao> tong = quangcao.SearchAndSort(search, sortorder, pageSize);
            List<GoiQuangCao> listgqc = goi.GetGoiQuangCaos();
            List<TaiKhoan> listtk = taikhoan.GetTaiKhoans();
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.GoiQuangCao = listgqc;
            ViewBag.TaiKhoan = listtk;
            ViewBag.TrangThai = "searchandsort";
            ViewBag.Search = search;
            ViewBag.Sort = sortorder;
            return View("Index", list);
        }

        public int TongTrang(List<QuangCao> list)
        {
            return ((list.Count / pageSize) + 1);
        }
        public List<QuangCaoThichHop> GetDates(int nam, int thang, string goi)
        {
            QuangCaoBUS quangcao = new QuangCaoBUS();
            List<QuangCaoThichHop> qc = quangcao.GetDates(nam, thang, goi);
            if(qc.Count==0)
            {
                return null;
            }
            return qc;
        }
        public int GetThoiLuong(string goi)
        {
            QuangCaoBUS quangcao = new QuangCaoBUS();
            return quangcao.GetThoiLuong(goi);
        }
        public string GetTenViTri(string goi)
        {
            QuangCaoBUS quangcao = new QuangCaoBUS();
            return quangcao.GetTenViTri(goi);
        }
        public string CheckMa(string ma)
        {
            QuangCaoBUS quangcao = new QuangCaoBUS();

            return quangcao.CheckMa(ma);
        }
        public string CheckTaiKhoan(string taikhoan)
        {
            QuangCaoBUS quangcao = new QuangCaoBUS();

            return quangcao.CheckTaiKhoan(taikhoan);
        }
    }
}