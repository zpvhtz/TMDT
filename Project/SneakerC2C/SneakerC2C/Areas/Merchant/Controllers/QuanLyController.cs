using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        const int pageSizeAll = 11;
        const int pageSize = 12;
        int pageNumber = 1;
        private readonly QLBanGiayContext ctx;
        public QuanLyController(QLBanGiayContext context)
        {
            ctx = context;
        }
        [HttpPost]
        public IActionResult InThongBao(SizeSanPham size)
        {
            string tentk = HttpContext.Session.GetString("TenDangNhap");

            List<SizeSanPham> test = ctx.SizeSanPham.Where(s => s.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tentk && s.SoLuong == 0)
                                                    .Include(s=>s.IdSanPhamNavigation)
                                                    .Include(s=>s.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                                    .ToList();

            //TempData["AlertMessage"] = message;

            //foreach (var item in test)
            //{
            //    message = "Sản phẩm" + item.IdSanPhamNavigation.TenSanPham + "đã hết size" + item.Size;
            //}
            return PartialView(test);
        }
        public IActionResult Index(string thongbao)
        {
            if (thongbao != null)
            {
                ViewBag.ThongBao = thongbao;
            }
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.HangSanPham = hang;
            
            //thongbao = "Sản phẩm" + item.IdSanPhamNavigation.TenSanPham + "đã hết size" + item.Size;
            //Thông báo

            return View();
        }
        public List<SanPham> Get()
        {
            List<SanPham> list= ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap") && sp.TinhTrang == "Không khoá" && sp.IdTaiKhoanNavigation.ThoiHanGianHang>DateTime.Now)
                                           .Include(sp => sp.IdTaiKhoanNavigation)
                                           .Include(sp => sp.IdHangSanPhamNavigation)
                                           .ToList();
            return list;
        }
        public List<SanPham> Get(int pagenumber, int pagesize)
        {
            List<SanPham> list = ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap") && sp.TinhTrang == "Không khoá" && sp.IdTaiKhoanNavigation.ThoiHanGianHang > DateTime.Now)
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
            List<SanPham> list = Get(pageNumber, pageSizeAll);
            List<SanPham> tong = Get();
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
            ViewBag.HangSanPham = hang;
            //DateTime? date = ctx.SanPham.Where(t => t.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap")).Select(d => d.IdTaiKhoanNavigation.ThoiHanGianHang).SingleOrDefault();
            DateTime date = ctx.TaiKhoan.Where(tk => tk.TenDangNhap == HttpContext.Session.GetString("TenDangNhap")).Select(tk => tk.ThoiHanGianHang).SingleOrDefault() ?? DateTime.Now;
            ViewBag.Date = date;
            return View(list);
        }
        //search list sp all
        public IActionResult Search(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            List<SanPham> list = pSearch(search, pageSizeAll, pageNumber);
            List<SanPham> tong =pSearch(search, pageSizeAll);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            return View("ListSP", list);
        }
        //search list sp all
        public List<SanPham> pSearch(string search, int pagesize, int pagenumber)
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
                                       .Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap") && sp.TinhTrang == "Không khoá" && sp.IdTaiKhoanNavigation.ThoiHanGianHang > DateTime.Now)
                                       .Include(sp => sp.IdTaiKhoanNavigation)
                                           .Include(sp => sp.IdHangSanPhamNavigation)
                                       .Skip((pagenumber - 1) * pagesize)
                                       .Take(pagesize)
                                       .ToList();
            }
            return list;
        }
        //search list sp all
        public List<SanPham> pSearch(string search, int pagesize)
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
                                       .Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap") && sp.TinhTrang == "Không khoá" && sp.IdTaiKhoanNavigation.ThoiHanGianHang > DateTime.Now)
                                       .Include(sp => sp.IdTaiKhoanNavigation)
                                        .Include(sp => sp.IdHangSanPhamNavigation)
                                       .ToList();
            }
            return list;
        }


        public List<SanPham> GetKH()
        {
            List<SanPham> list = ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
                                          .Where(sp => sp.TinhTrang == "Khoá")
                                           .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                          .ToList();
            return list;
        }
        public List<SanPham> GetKH(int pagenumber, int pagesize)
        {
            List<SanPham> list = ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
                                          .Where(sp => sp.TinhTrang == "Khoá")
                                           .Include(sp => sp.IdTaiKhoanNavigation)
                                          .Include(sp => sp.IdHangSanPhamNavigation)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .ToList();
            return list;
        }
        public IActionResult KhoaSP(int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            List<SizeSanPham> size = ctx.SizeSanPham.ToList();
            ViewBag.Size = size;
            List<SanPham> list = GetKH(pageNumber, pageSizeAll);
            List<SanPham> tong = GetKH();
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
            ViewBag.HangSanPham = hang;
            return View(list);
        }
        /// <summary>
        /// SEARCH SAN PHAM BI KHOA
        /// </summary>
        /// <returns></returns>
        public IActionResult SearchKH(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            List<SanPham> list = pSearchKH(search, pageSizeAll, pageNumber);
            List<SanPham> tong = pSearchKH(search, pageSizeAll);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            return View("KhoaSP", list);
        }
        //search list sp all
        public List<SanPham> pSearchKH(string search, int pagesize, int pagenumber)
        {
            List<SanPham> list = new List<SanPham>();
            if (search == null)
            {
                list = GetKH(1, pagesize);
            }
            else
            {
                list = ctx.SanPham.Where(l => l.MaSanPham.Contains(search) ||
                                                   l.TenSanPham.Contains(search) ||
                                                   l.Mau.Contains(search))
                                       .Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
                                       .Where(sp => sp.TinhTrang == "Khoá")
                                       .Include(sp => sp.IdTaiKhoanNavigation)
                                           .Include(sp => sp.IdHangSanPhamNavigation)
                                       .Skip((pagenumber - 1) * pagesize)
                                       .Take(pagesize)
                                       .ToList();
            }
            return list;
        }
        //search list sp all
        public List<SanPham> pSearchKH(string search, int pagesize)
        {
            List<SanPham> list = new List<SanPham>();
            if (search == null)
            {
                list = GetKH(1, pagesize);
            }
            else
            {
                list = ctx.SanPham.Where(l => l.MaSanPham.Contains(search) ||
                                                   l.TenSanPham.Contains(search) ||
                                                   l.Mau.Contains(search))
                                       .Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap"))
                                       .Where(sp => sp.TinhTrang == "Khoá")
                                       .Include(sp => sp.IdTaiKhoanNavigation)
                                        .Include(sp => sp.IdHangSanPhamNavigation)
                                       .ToList();
            }
            return list;
        }


        public List<SanPham> GetCH()
        {
            List<SizeSanPham> size = ctx.SizeSanPham.ToList();
            ViewBag.Size = size;
            var listsize = ctx.SizeSanPham.Where(s => s.SoLuong > 0 && s.TinhTrang == "Không khoá")
                                        .Include(s => s.IdSanPhamNavigation)
                                        .Select(s => s.IdSanPham)
                                        .Distinct()
                                        .ToList();
            List<SanPham> list = ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap") && sp.TinhTrang == "Không khoá" && sp.IdTaiKhoanNavigation.ThoiHanGianHang > DateTime.Now)
                                            .Where(sp => listsize.Contains(sp.Id)).ToList();
            return list;
        }
        public List<SanPham> GetCH(int pagenumber, int pagesize)
        {
            List<SizeSanPham> size = ctx.SizeSanPham.ToList();
            ViewBag.Size = size;
            var listsize = ctx.SizeSanPham.Where(s => s.SoLuong > 0 && s.TinhTrang == "Không khoá")
                                        .Include(s => s.IdSanPhamNavigation)
                                        .Select(s => s.IdSanPham)
                                        .Distinct()
                                        .ToList();
            List<SanPham> list = ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap") && sp.TinhTrang == "Không khoá" && sp.IdTaiKhoanNavigation.ThoiHanGianHang > DateTime.Now)
                                            .Where(sp => listsize.Contains(sp.Id))
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .ToList();
            return list;
        }
        public IActionResult ConHang(int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            List<SizeSanPham> size = ctx.SizeSanPham.ToList();
            ViewBag.Size = size;
            List<SanPham> list = GetCH(pageNumber, pageSizeAll);
            List<SanPham> tong = GetCH();
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
            ViewBag.HangSanPham = hang;
            return View(list);
        }
        //search list sp con hàng
        public IActionResult SearchCH(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            List<SanPham> list = pSearchCH(search, pageSizeAll, pageNumber);
            List<SanPham> tong = pSearchCH(search, pageSizeAll);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            return View("ConHang", list);
        }
        //search list sp all
        public List<SanPham> pSearchCH(string search, int pagesize, int pagenumber)
        {
            List<SanPham> list = new List<SanPham>();
            if (search == null)
            {
                list = GetCH(1, pagesize);
            }
            else
            {
                List<SizeSanPham> size = ctx.SizeSanPham.ToList();
                ViewBag.Size = size;
                var listsize = ctx.SizeSanPham.Where(s => s.SoLuong > 0 )
                                            .Include(s => s.IdSanPhamNavigation)
                                            .Select(s => s.IdSanPham)
                                            .Distinct()
                                            .ToList();
                list = ctx.SanPham.Where(l => l.Gia.ToString().Contains(search) ||
                                                   l.TenSanPham.Contains(search) ||
                                                   l.Mau.Contains(search))
                    .Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap")  && sp.IdTaiKhoanNavigation.ThoiHanGianHang > DateTime.Now)
                                                .Where(sp => listsize.Contains(sp.Id) &&sp.TinhTrang == "Không khoá")
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .ToList();
            }
            return list;
        }
        //search list sp con hang
        public List<SanPham> pSearchCH(string search, int pagesize)
        {
            List<SanPham> list = new List<SanPham>();
            if (search == null)
            {
                list = GetCH(1, pagesize);
            }
            else
            {
                List<SizeSanPham> size = ctx.SizeSanPham.ToList();
                ViewBag.Size = size;
                var listsize = ctx.SizeSanPham.Where(s => s.SoLuong > 0)
                                            .Include(s => s.IdSanPhamNavigation)
                                            .Select(s => s.IdSanPham)
                                            .Distinct()
                                            .ToList();
                list = ctx.SanPham.Where(l => l.Gia.ToString().Contains(search) ||
                                                   l.TenSanPham.Contains(search) ||
                                                   l.Mau.Contains(search))
                    .Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap")&& sp.TinhTrang == "Không khoá" && sp.IdTaiKhoanNavigation.ThoiHanGianHang > DateTime.Now)
                                                .Where(sp => listsize.Contains(sp.Id))
                                               .ToList();
            }
            return list;
        }

        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        //lấy tổng sp
        public List<SanPham> GetHH ()
        {
            var store_tendangnhap = new SqlParameter("@TenDangNhap", HttpContext.Session.GetString("TenDangNhap"));
            List<SanPham> list = ctx.SanPham.Where(sp=>sp.IdTaiKhoanNavigation.ThoiHanGianHang>DateTime.Now).FromSql("p_hethang @TenDangNhap", store_tendangnhap).ToList();
            return list;
        }
        //lấy list sp từng trang
        public List<SanPham> GetHH(int pagenumber, int pagesize)
        {
            var store_tendangnhap = new SqlParameter("@TenDangNhap", HttpContext.Session.GetString("TenDangNhap"));
            var store_pagesize = new SqlParameter("@pageSize", pagesize);
            var store_pagenumber = new SqlParameter("@pageNumber", pagenumber);
            List<SanPham> list = ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.ThoiHanGianHang > DateTime.Now).FromSql("P_HetHang_Pagging @TenDangNhap, @pageSize, @pageNumber", store_tendangnhap, store_pagesize, store_pagenumber).Where(sp => sp.IdTaiKhoanNavigation.TenDangNhap == HttpContext.Session.GetString("TenDangNhap") && sp.TinhTrang == "Không khoá").ToList();
            return list;
        }
        public IActionResult HetHang(int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            List<SizeSanPham> size = ctx.SizeSanPham.ToList();
            ViewBag.Size = size;
            List<SanPham> list = GetHH(pageNumber, pageSize);
            List<SanPham> tong = GetHH();
            List<HangSanPham> hang = ctx.HangSanPham.ToList();
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TrangThai = "index";
            ViewBag.HangSanPham = hang;
            return View(list);
        }
        //seach hethang
        public List<SanPham> pSearchHH(string search, int pagesize, int pagenumber)
        {
            List<SanPham> list = new List<SanPham>();
            if (search == null)
            {
                list = GetHH(1, pagesize);
            }
            else
            {
                var store_tendangnhap = new SqlParameter("@TenDangNhap", HttpContext.Session.GetString("TenDangNhap"));
                var store_search = new SqlParameter("@search", search);
                var store_pagesize = new SqlParameter("@pageSize", pagesize);
                var store_pagenumber = new SqlParameter("@pageNumber", pagenumber);
                list = ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.ThoiHanGianHang > DateTime.Now).FromSql("P_HetHang_Search @TenDangNhap, @search, @pageSize, @pageNumber", store_tendangnhap, store_search, store_pagesize, store_pagenumber).ToList();
            }
            return list;
        }
        //search list sp all
        public List<SanPham> pSearchHH(string search, int pagesize)
        {
            List<SanPham> list = new List<SanPham>();
            if (search == null)
            {
                list = GetHH(1, pagesize);
            }
            else
            {
                var store_tendangnhap = new SqlParameter("@TenDangNhap", HttpContext.Session.GetString("TenDangNhap"));
                var store_search = new SqlParameter("@search", search);
                list = ctx.SanPham.Where(sp => sp.IdTaiKhoanNavigation.ThoiHanGianHang > DateTime.Now).FromSql("P_HetHang_Search_NotPagging @TenDangNhap, @search", store_tendangnhap, store_search).ToList();
            }
            return list;
        }
        public IActionResult SearchHH(string search, int? pagenumber)
        {
            pageNumber = pagenumber ?? 1;
            List<SanPham> list = pSearchHH(search, pageSize, pageNumber);
            List<SanPham> tong = pSearchHH(search, pageSize);
            ViewBag.TrangHienTai = pageNumber;
            ViewBag.TongTrang = TongTrang(tong);
            ViewBag.TrangThai = "search";
            ViewBag.Search = search;
            return View("HetHang", list);
        }
        public void XoaSP(string id)
        {
            SanPham sp = ctx.SanPham.Where(s => s.Id == Guid.Parse(id)).SingleOrDefault();
            sp.TinhTrang = "Khoá_mer";
            ctx.SaveChanges();

            List<SizeSanPham> listsize = ctx.SizeSanPham.Where(s => s.IdSanPham == Guid.Parse(id)).ToList();
            foreach(var item in listsize)
            {
                item.TinhTrang = "Khoá";
            }
            ctx.SaveChanges();
        }
        public IActionResult ThemSP(string item_them_tensp,string item_them_mau, string item_them_hang, string item_them_phanloai, string item_them_gia, string item_them_chitiet, string item_them_giamgia, IFormFile item_them_hinh,int item_them_size,int item_them_soluong)
        {
            DateTime date = ctx.TaiKhoan.Where(tk => tk.TenDangNhap == HttpContext.Session.GetString("TenDangNhap")).Select(tk => tk.ThoiHanGianHang).SingleOrDefault() ?? DateTime.Now;
            ViewBag.Date = date;
            if (date >DateTime.Now)
            {
                string tentk = HttpContext.Session.GetString("TenDangNhap");
                var idtk = ctx.SanPham.Where(s => s.IdTaiKhoanNavigation.TenDangNhap == tentk).Select(s => s.IdTaiKhoan).FirstOrDefault();
                //Guid tk = ctx.TaiKhoan.Where(t => t.Ten == HttpContext.Session.GetString("TenDangNhap")).Select(t=>t.Id).SingleOrDefault();
                SanPham sp = new SanPham();
                string mamoi = "";
                if (ctx.SanPham.Count() == 0)
                {
                    mamoi = "G-1";
                }
                else
                {
                    string layma = ctx.SanPham
                                          .OrderByDescending(h => int.Parse(h.MaSanPham.Substring(2)))
                                          .Select(h => h.MaSanPham)
                                          .FirstOrDefault();
                    int stt = int.Parse(layma.Substring(layma.IndexOf('-') + 1));
                    stt += 1;
                    mamoi = "G-" + stt.ToString();
                }
                sp.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
                sp.MaSanPham = mamoi;
                sp.TenSanPham = item_them_tensp;
                sp.IdTaiKhoan = idtk;
                sp.Mau = item_them_mau;
                sp.IdHangSanPham = Guid.Parse(item_them_hang);
                sp.PhanLoai = item_them_phanloai;


                sp.Gia = double.Parse(item_them_gia);

                if (item_them_hinh != null)
                {
                    int so = 0;
                    string ten = item_them_hinh.FileName;
                    string tentemp = ten;
                    while (ctx.SanPham.Where(s => s.Hinh == tentemp).SingleOrDefault() != null)
                    {
                        so++;
                        tentemp = ten.Substring(0, ten.IndexOf('.')) + so + ".jpg";

                    }
                    ten = tentemp;
                    var path = Directory.GetCurrentDirectory() + @"/wwwroot/Hinh/SanPham/" + ten;
                    //int so = 1;
                    //while (ctx.SanPham.Where(s => s.Hinh == path).SingleOrDefault() != null)
                    //{
                    //    path = path + so;
                    //    so++;
                    //}
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        item_them_hinh.CopyTo(stream);
                    }
                    // full path to file in temp location
                    sp.Hinh = ten;
                }
                sp.ChiTiet = item_them_chitiet;
                sp.NgayDang = DateTime.Now;
                sp.TinhTrang = "Chưa duyệt";
                ctx.SanPham.Add(sp);
                ctx.SaveChanges();
            }
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
        public IActionResult EditSP(string item_sua_ma, string item_sua_tensp, string item_sua_mau, string item_sua_hang, string item_sua_phanloai, string item_sua_gia, IFormFile item_sua_hinh, string item_sua_chitiet, string item_sua_giamgia,string item_sua_size,int? item_sua_soluong)
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
            if (item_sua_size != "không")
            {
                SizeSanPham sizesp = new SizeSanPham();
                sizesp = ctx.SizeSanPham.Where(s => s.Id == Guid.Parse(item_sua_size)).SingleOrDefault();
                sizesp.SoLuong = item_sua_soluong;
                ctx.SaveChanges();
            }
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