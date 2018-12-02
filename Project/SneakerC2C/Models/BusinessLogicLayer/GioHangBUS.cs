using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.BusinessLogicLayer
{
    public class GioHangBUS
    {
        private readonly QLBanGiayContext context;

        public GioHangBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public GioHangBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public List<GioHang> GetGioHangs(string tendangnhap)
        {
            List<GioHang> list = context.GioHang.Where(gh => gh.IdTaiKhoanNavigation.TenDangNhap == tendangnhap)
                                                .Include(gh => gh.IdTaiKhoanNavigation)
                                                .Include(gh => gh.IdSizeSanPhamNavigation)
                                                .Include(gh => gh.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                                .Include(gh => gh.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                                .OrderByDescending(gh => gh.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoan)
                                                .ToList();
            return list;
        }

        public string AddToCart(string idtaikhoan, string idsizesanpham, int soluong)
        {
            GioHang giohang = new GioHang();
            giohang = context.GioHang.Where(gh => gh.IdTaiKhoan == Guid.Parse(idtaikhoan) && gh.IdSizeSanPham == Guid.Parse(idsizesanpham)).SingleOrDefault();
            if(giohang != null)
            {
                giohang.SoLuong = giohang.SoLuong + soluong;
                context.SaveChanges();
            }
            else
            {
                giohang = new GioHang();
                giohang.IdTaiKhoan = Guid.Parse(idtaikhoan);
                giohang.IdSizeSanPham = Guid.Parse(idsizesanpham);
                giohang.SoLuong = soluong;
                giohang.TinhTrang = "Không khoá";
                context.GioHang.Add(giohang);
                context.SaveChanges();
            }
            return "Thêm vào giỏ hàng thành công";
        }

        public string DeleteFromCart(string idtaikhoan, string idsizesanpham)
        {
            GioHang giohang = new GioHang();
            giohang = context.GioHang.Where(gh => gh.IdTaiKhoan == Guid.Parse(idtaikhoan) && gh.IdSizeSanPham == Guid.Parse(idsizesanpham)).SingleOrDefault();
            context.GioHang.Remove(giohang);
            context.SaveChanges();
            return "Xoá sản phẩm khỏi giỏ hàng thành công";
        }

        public GioHang AddSingleItem(KeyValuePair<string, int> item)
        {
            //Khai báo
            GioHang giohang = new GioHang();
            TaiKhoan taikhoan = new TaiKhoan();
            SanPham sanpham = new SanPham();
            SizeSanPham sizesanpham = new SizeSanPham();
            //Lấy dữ liệu cho từng class
            sizesanpham = context.SizeSanPham.Where(s => s.Id == Guid.Parse(item.Key)).SingleOrDefault();
            sanpham = context.SanPham.Where(sp => sp.Id == sizesanpham.IdSanPham).SingleOrDefault();
            taikhoan = context.TaiKhoan.Where(tk => tk.Id == sanpham.IdTaiKhoan).SingleOrDefault();

            giohang.IdSizeSanPham = Guid.Parse(item.Key);
            giohang.IdTaiKhoan = Guid.Parse("3BA4CBB1-98AC-4768-BCE2-0B226C49DC56");
            giohang.SoLuong = item.Value;
            giohang.TinhTrang = "Không khoá";
            giohang.IdSizeSanPhamNavigation = sizesanpham;
            giohang.IdTaiKhoanNavigation = taikhoan;
            giohang.IdSizeSanPhamNavigation.IdSanPhamNavigation = sanpham;

            return giohang;
        }
    }
}
