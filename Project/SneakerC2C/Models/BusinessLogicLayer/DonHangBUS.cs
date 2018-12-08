using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.BusinessLogicLayer
{
    public class DonHangBUS
    {
        private readonly QLBanGiayContext context;
        public DonHangBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public DonHangBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public string CheckDonHang(string tendangnhap)
        {
            TaiKhoan taikhoan = context.TaiKhoan.Where(tk => tk.TenDangNhap == tendangnhap).SingleOrDefault();

            List<GioHang> listgiohang = context.GioHang.Where(gh => gh.IdTaiKhoan == taikhoan.Id).ToList();

            foreach(var item in listgiohang)
            {
                SizeSanPham sizesanpham = context.SizeSanPham.Where(s => s.Id == item.IdSizeSanPham).Include(s => s.IdSanPhamNavigation).SingleOrDefault();
                if(item.SoLuong > sizesanpham.SoLuong)
                {
                    string thongbao = "";
                    thongbao = sizesanpham.IdSanPhamNavigation.TenSanPham + " có số lượng vượt quá tồn kho (SL kho: )" + sizesanpham.SoLuong;
                    return thongbao;
                }
            }
            return "Đặt hàng thành công";
        }

        //public void CreateDonDatHang(string tendangnhap, string iddiachi, float tongtien)
        //{
        //    PhieuDat latestPhieuDat = context.PhieuDat.OrderByDescending(pd => int.Parse(pd.MaPhieuDat.Substring(3))).FirstOrDefault();
        //    string latestMa = "";
        //    if (latestPhieuDat == null)
        //    {
        //        latestMa = "PD-1";
        //    }
        //    else
        //    {
        //        int ma = int.Parse(latestPhieuDat.MaPhieuDat.Substring(3));
        //        latestMa = "PD-" + (ma + 1).ToString();
        //    }

        //    TaiKhoan taikhoan = context.TaiKhoan.Where(tk => tk.TenDangNhap == tendangnhap).SingleOrDefault();
        //    DiaChi diachi = context.DiaChi.Where(dc => dc.Id == Guid.Parse(iddiachi)).Include(dc => dc.IdTaiKhoanNavigation).Include(dc => dc.IdTinhThanhNavigation).SingleOrDefault();

        //    Guid guid = Guid.Parse(Guid.NewGuid().ToString().ToUpper());

        //    PhieuDat phieudat = new PhieuDat();
        //    phieudat.Id = guid;
        //    phieudat.MaPhieuDat = latestMa;
        //    phieudat.IdTaiKhoan = taikhoan.Id;
        //    phieudat.DiaChi = diachi.Duong + " " + diachi.IdTinhThanhNavigation.TenTinhThanh;
        //    phieudat.NgayTao = DateTime.Now;
        //    phieudat.TongTien = tongtien;
        //    phieudat.TinhTrang = "Không khoá";

        //    context.PhieuDat.Add(phieudat);
        //    context.SaveChanges();

        //    List<GioHang> listgiohang = context.GioHang.Where(gh => gh.IdTaiKhoan == taikhoan.Id).ToList();
        //    foreach(var item in listgiohang)
        //    {
        //        SizeSanPham sizesanpham = context.SizeSanPham.Where(s => s.Id == item.IdSizeSanPham).SingleOrDefault();
        //        SanPham sanpham = context.SanPham.Where(s => s.Id == sizesanpham.IdSanPham).SingleOrDefault();
        //        double dongia = 0;
        //        double giamgia = sanpham.GiamGia ?? 0;
        //        if(giamgia > 0)
        //        {
        //            dongia = sanpham.Gia * (100 - sanpham.GiamGia) / 100 ?? 0;
        //        }
        //        else
        //        {
        //            dongia = sanpham.Gia ?? 0;
        //        }

        //        ChiTietPhieuDat chitietphieudat = new ChiTietPhieuDat();
        //        chitietphieudat.IdPhieuDat = guid;
        //        chitietphieudat.IdSizeSanPham = item.IdSizeSanPham;
        //        chitietphieudat.SoLuong = item.SoLuong;
        //        chitietphieudat.Gia = dongia;
        //        context.ChiTietPhieuDat.Add(chitietphieudat);
        //        context.SaveChanges();
        //    }
        //}
    }
}
