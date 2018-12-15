using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Models.BusinessLogicLayer
{
    public class DoanhThuBUS
    {
        private readonly QLBanGiayContext context;
        public DoanhThuBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public DoanhThuBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public double GetTongDoanhThu(string tendangnhap)
        {
            List<ChiTietDonHang> listchitiet = context.ChiTietDonHang.Where(c => c.TinhTrangChiTiet == "Đã xử lý" && c.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tendangnhap)
                                                                     .Include(c => c.IdSizeSanPhamNavigation)
                                                                     .Include(c => c.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                                                     .Include(c => c.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                                                     .ToList();

            double tongdoanhthu = listchitiet.Sum(c => c.SoLuong * c.DonGia) ?? 0;
            return tongdoanhthu;
        }

        public double GetTongDoanhThu(string tendangnhap, DateTime nbd, DateTime nkt)
        {
            List<ChiTietDonHang> listchitiet = context.ChiTietDonHang.Where(c => c.TinhTrangChiTiet == "Đã xử lý" &&
                                                                                 c.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenDangNhap == tendangnhap &&
                                                                                 c.NgayGiao >= nbd &&
                                                                                 c.NgayGiao <= nkt)
                                                                     .Include(c => c.IdSizeSanPhamNavigation)
                                                                     .Include(c => c.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                                                     .Include(c => c.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                                                     .ToList();

            double tongdoanhthu = listchitiet.Sum(c => c.SoLuong * c.DonGia) ?? 0;
            return tongdoanhthu;
        }
    }
}
