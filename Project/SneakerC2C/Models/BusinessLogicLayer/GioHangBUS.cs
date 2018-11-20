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

        public List<GioHang> GetGioHangs(string idtaikhoan)
        {
            List<GioHang> list = context.GioHang.Where(gh => gh.IdTaiKhoan == Guid.Parse(idtaikhoan))
                                                .Include(gh => gh.IdTaiKhoanNavigation)
                                                .Include(gh => gh.IdSizeSanPhamNavigation)
                                                .Include(gh => gh.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                                .ToList();
            return list;
        }

        public string AddToCart(string idtaikhoan, string idsizesanpham)
        {
            GioHang giohang = new GioHang();
            giohang = context.GioHang.Where(gh => gh.IdTaiKhoan == Guid.Parse(idtaikhoan) && gh.IdSizeSanPham == Guid.Parse(idsizesanpham)).SingleOrDefault();
            if(giohang != null)
            {
                return "Đã tồn tại sản phẩm trong giỏ hàng";
            }
            giohang = new GioHang();
            giohang.IdTaiKhoan = Guid.Parse(idtaikhoan);
            giohang.IdSizeSanPham = Guid.Parse(idsizesanpham);
            giohang.SoLuong = 1;
            giohang.TinhTrang = "Không khoá";
            context.GioHang.Add(giohang);
            return "Thêm vào giỏ hàng thành công";
        }
    }
}
