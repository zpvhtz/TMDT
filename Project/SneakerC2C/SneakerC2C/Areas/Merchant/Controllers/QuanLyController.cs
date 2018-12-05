using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.BusinessLogicLayer;
using Models.Database;

namespace SneakerC2C.Areas.Merchant.Controllers
{
    [Area("Merchant")]
    public class QuanLyController : BaseController
    {
        const int pageSize = 10;
        int pageNumber = 1;
        private readonly QLBanGiayContext ctx;
        public QuanLyController(QLBanGiayContext context)
        {
            ctx = context;
        }
        public IActionResult Index(string thongbao)
        {
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.HangSanPham = hang;
            //Thông báo
            if (thongbao != null)
            {
                ViewBag.ThongBao = thongbao;
            }
            return View();
        }
        public List<SanPham> Get()
        {
            List<SanPham> list= ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap") && sp.TinhTrang == "Không khoá")
                                           .Include(sp => sp.IdTaiKhoanNavigation)
                                           .Include(sp => sp.IdHangSanPhamNavigation)
                                           .ToList();
            return list;
        }
        public List<SanPham> Get(int pagenumber, int pagesize)
        {
            List<SanPham> list = ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap") && sp.TinhTrang == "Không khoá")
                                           .Include(sp => sp.IdTaiKhoanNavigation)
                                           .Include(sp => sp.IdHangSanPhamNavigation)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .ToList();
            return list;
        }
        public IActionResult ListSP(string thongbao, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            List<SizeSanPham> size = ctx.SizeSanPham.ToList();
            ViewBag.Size = size;
            //List<SanPham> list = ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap")&& sp.TinhTrang=="Không khoá")
            //                               .Include(sp => sp.IdTaiKhoanNavigation)
            //                               .Include(sp => sp.IdHangSanPhamNavigation)
            //                               .ToList();
            List<SanPham> list = Get(pageNumber, pageSize);
            List<SanPham> tong = Get();
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
            ViewBag.HangSanPham = hang;
            return View(list);
        }
        public IActionResult Search(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            List<SanPham> list = Search(search, pageSize, pageNumber);
            List<SanPham> tong = Search(search, pageSize);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            return View("Index", list);
        }
        public List<SanPham> Search(string search, int pagesize, int pagenumber)
        {
            List<SanPham> list = new List<SanPham>();
            if (search == null)
            {
                list = Get(1, pagesize);
            }
            else
            {
                list = ctx.SanPham.Where(l => l.MaSanPham.Contains(search) ||
                                                   l.TenSanPham.Contains(search) ||
                                                   l.Mau.Contains(search))
                                       .Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
                                       .Include(sp => sp.IdTaiKhoanNavigation)
                                           .Include(sp => sp.IdHangSanPhamNavigation)
                                       .Skip((pagenumber - 1) * pagesize)
                                       .Take(pagesize)
                                       .ToList();
            }
            return list;
        }

        public List<SanPham> Search(string search, int pagesize)
        {
            List<SanPham> list = new List<SanPham>();
            if (search == null)
            {
                list = Get(1, pagesize);
            }
            else
            {
                list = ctx.SanPham.Where(l => l.MaSanPham.Contains(search) ||
                                                   l.TenSanPham.Contains(search) ||
                                                   l.Mau.Contains(search))
                                       .Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
                                       .Include(sp => sp.IdTaiKhoanNavigation)
                                        .Include(sp => sp.IdHangSanPhamNavigation)
                                       .ToList();
            }
            return list;
        }
        public IActionResult KhoaSP()
        {
            List<SanPham> list=ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
                                           .Where(sp=>sp.TinhTrang=="Khoá")
                                            .Include(sp => sp.IdTaiKhoanNavigation)
                                           .Include(sp => sp.IdHangSanPhamNavigation)
                                           .ToList();
            return View(list);
        }
        //public IActionResult GetSize(string masp)
        //{
        //    List<SanPham> list = ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
        //                                   .Include(sp => sp.IdTaiKhoanNavigation)
        //                                   .Include(sp => sp.IdHangSanPhamNavigation)
        //                                   .ToList();
        //    List<SizeSanPham> listsize = ctx.SizeSanPham.Where(sp => list.Contains(sp.IdSanPhamNavigation)).ToList(); ;
            
        //    return PartialView("pSize", listsize);
        //}
        public IActionResult ConHang()
        {
            List<SizeSanPham> size = ctx.SizeSanPham.ToList();
            ViewBag.Size = size;
            var listsize = ctx.SizeSanPham.Where(s => s.SoLuong > 0)
                                        .Include(s => s.IdSanPhamNavigation)
                                        .Select(s => s.IdSanPham)
                                        .Distinct()
                                        .ToList();
            List<SanPham> list = ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
                                            .Where(sp => listsize.Contains(sp.Id)).ToList();
            return View(list);
        }
        public IActionResult HetHang()
        {
            //List<SizeSanPham> size = ctx.SizeSanPham.ToList();
            //ViewBag.Size = size;
            ////var listsize = ctx.SizeSanPham.GroupBy(s=>s.IdSanPham).Where(s => Sum(s.SoLuong) == 0)
            ////                            .Include(s => s.IdSanPhamNavigation)
            ////                            .Select(s => s.IdSanPham)
            ////                            .ToList();
            //var listgroupby = ctx.SizeSanPham.GroupBy(s => s.IdSanPham)
            //                              .Select(s => new { IdSanPham = s, SoLuong = s.Sum(k => k.SoLuong) })
            //                              .ToList();

            //var listidhethang = listgroupby.Where(l => l.SoLuong > 0).Select(l => l.IdSanPham).ToList();

            ////var listsize = ctx.SizeSanPham.Where(s => listidhethang.Contains(s.IdSanPham))

            //List<SanPham> list = ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
            //                                .Where(sp => listsize.Contains(sp.Id)).ToList();
            List<SanPham> list = ctx.SanPham.FromSql("p_hethang").ToList();
            return View(list);
        }
        public void XoaSP(string id)
        {
            SanPham sp = ctx.SanPham.Where(s => s.Id == Guid.Parse(id)).SingleOrDefault();
            sp.TinhTrang = "Khoá_mer";
            ctx.SaveChanges();
        }
        public IActionResult ThemSP(string item_them_ma,string item_them_tensp,string item_them_mau, string item_them_hang, string item_them_phanloai, string item_them_gia, string item_them_chitiet, string item_them_giamgia, IFormFile item_them_hinh,int item_them_size,int item_them_soluong)
        {
                //long size = item_them_hinh.Sum(f => f.Length);

                //// full path to file in temp location
                
                //foreach (var formFile in item_them_hinh)
                //{
                //    if (formFile.Length > 0)
                //    {
                //        using (var stream = new FileStream(filePath, FileMode.Create))
                //        {
                //        formFile.CopyTo(stream);
                //        }
                //    }
                //}
            if(item_them_hinh != null)
            {
                var path = Directory.GetCurrentDirectory() + @"/wwwroot/Hinh/SanPham/" + item_them_hinh.FileName;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    item_them_hinh.CopyTo(stream);
                }
            }
            SanPham sp = new SanPham();
            //string layma = ctx.SanPham
            //    .OrderByDescending(h => h.MaSanPham)
            //    .Select(h => h.MaSanPham)
            //    .FirstOrDefault();
            //int vitri = layma.IndexOf("-");
            //string tmp = layma.Substring(0, vitri);
            //int so = int.Parse(layma.Substring(vitri + 1, layma.Length - 1 - vitri));
            //so = so + 1;
            //string Ma = tmp + "-" + so;
            string tentk = HttpContext.Session.GetString("TenDangNhap");
            var idtk = ctx.SanPham.Where(s => s.IdTaiKhoanNavigation.TenDangNhap == tentk).Select(s => s.IdTaiKhoan).FirstOrDefault();
            //Guid tk = ctx.TaiKhoan.Where(t => t.Ten == HttpContext.Session.GetString("TenDangNhap")).Select(t=>t.Id).SingleOrDefault();
            sp.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            sp.MaSanPham = item_them_ma;
            sp.TenSanPham = item_them_tensp;
            sp.IdTaiKhoan = idtk;
            sp.Mau = item_them_mau;
            sp.IdHangSanPham = Guid.Parse(item_them_hang);
            sp.PhanLoai = item_them_phanloai;
            sp.Gia = double.Parse(item_them_gia);



            // full path to file in temp location
            sp.Hinh = item_them_hinh.FileName;
            sp.ChiTiet = item_them_chitiet;
            sp.NgayDang = DateTime.Now;
            sp.TinhTrang = "Không khoá";
            ctx.Add(sp);
            ctx.SaveChanges();
            return RedirectToAction("ListSP");
        }
        public IActionResult ChiTiet(string Ma)
        {
            SanPham sp = ctx.SanPham.Where(s => s.MaSanPham == Ma).SingleOrDefault();
            SanPhamBUS sanphambus = new SanPhamBUS();
            SizeSanPhamBUS sizesanphambus = new SizeSanPhamBUS();
            GioHangBUS giohangbus = new GioHangBUS();
            List<SizeSanPham> listsizesanpham = sizesanphambus.GetSize(Ma);
            ViewBag.ListSizeSanPham = listsizesanpham;
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.Hang = hang;
            return View("ChiTiet");
        }
        public IActionResult EditSP(string item_sua_ma, string item_sua_tensp, string item_sua_mau, string item_sua_hang, string item_sua_phanloai, string item_sua_gia, IFormFile item_sua_hinh, string item_sua_chitiet, string item_sua_giamgia)
        {
            List<SizeSanPham> size = ctx.SizeSanPham.ToList();
            ViewBag.Size = size;
            var sp = ctx.SanPham.Where(s => s.MaSanPham == item_sua_ma).SingleOrDefault();
            if (item_sua_tensp != null)
            {
                sp.TenSanPham = item_sua_tensp;
            }
            if (item_sua_mau != null)
            {
                sp.Mau = item_sua_mau;
            }
            sp.IdHangSanPham = Guid.Parse(item_sua_hang);
            sp.PhanLoai = item_sua_phanloai;
            if (item_sua_gia != null)
            {
                sp.Gia = float.Parse(item_sua_gia);
            }
            if (item_sua_hinh != null)
            {
                var path = Directory.GetCurrentDirectory() + @"/wwwroot/Hinh/SanPham/" + item_sua_hinh.FileName;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    item_sua_hinh.CopyTo(stream);
                }
                sp.Hinh = item_sua_hinh.FileName;
            }
            if (item_sua_chitiet != null)
            {
                sp.ChiTiet = item_sua_chitiet;
            }
            if (item_sua_giamgia != null)
            {
                sp.GiamGia = float.Parse(item_sua_giamgia);
            }
            ctx.SaveChanges();
            return RedirectToAction("ListSP");
        }

        public IActionResult GetProductDetails(string id)
        {
            SanPham sanpham = new SanPham();
            sanpham = ctx.SanPham.Where(sp => sp.Id == Guid.Parse(id))
                                 .Include(sp => sp.IdHangSanPhamNavigation)
                                 .Include(sp => sp.IdTaiKhoanNavigation)
                                 .SingleOrDefault();
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.HangSanPham = hang;

            List<SizeSanPham> listsize = ctx.SizeSanPham.Where(s => s.IdSanPham == Guid.Parse(id)).OrderBy(s=>s.Size).ToList();
            ViewBag.ListSizeSanPham = listsize;
            return PartialView("pSuaSanPham", sanpham);
        }

        public int GetQuantity(string id)
        {
            SizeSanPham size = ctx.SizeSanPham.Where(s => s.Id == Guid.Parse(id)).SingleOrDefault();
            return size.SoLuong ?? 0;
        }
        public int TongTrang(List<SanPham> list)
        {
            return ((list.Count / pageSize) + 1);
        }
    }
}