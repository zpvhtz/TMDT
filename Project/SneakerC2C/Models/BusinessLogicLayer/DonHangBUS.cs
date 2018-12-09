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

        public void CreateDonDatHang(string tendangnhap, string iddiachi, float tongtien)
        {
            DonHang latestDonHang = context.DonHang.OrderByDescending(pd => int.Parse(pd.MaDonHang.Substring(3))).FirstOrDefault();
            string latestMa = "";
            if (latestDonHang == null)
            {
                latestMa = "DH-1";
            }
            else
            {
                int ma = int.Parse(latestDonHang.MaDonHang.Substring(3));
                latestMa = "PD-" + (ma + 1).ToString();
            }

            //Thêm đơn hàng
            TaiKhoan taikhoan = context.TaiKhoan.Where(tk => tk.TenDangNhap == tendangnhap).SingleOrDefault();
            DiaChi diachi = context.DiaChi.Where(dc => dc.Id == Guid.Parse(iddiachi)).Include(dc => dc.IdTaiKhoanNavigation).Include(dc => dc.IdTinhThanhNavigation).SingleOrDefault();

            Guid guid = Guid.Parse(Guid.NewGuid().ToString().ToUpper());

            DonHang donhang = new DonHang();
            donhang.Id = guid;
            donhang.MaDonHang = latestMa;
            donhang.CmndnguoiGiao = "Chưa có";
            donhang.IdTaiKhoan = taikhoan.Id;
            donhang.DiaChiGiao = diachi.Duong + " " + diachi.IdTinhThanhNavigation.TenTinhThanh;
            donhang.NgayTao = DateTime.Now;
            donhang.NgayGiao = null;
            donhang.TongTien = tongtien;
            donhang.DiemDanhGia = 0;
            donhang.TinhTrangDanhGia = "Chưa đánh giá";
            donhang.TinhTrang = "Đã đặt";

            context.DonHang.Add(donhang);
            context.SaveChanges();
            
            //Thêm chi tiết đơn hàng
            List<GioHang> listgiohang = context.GioHang.Where(gh => gh.IdTaiKhoan == taikhoan.Id).ToList();
            foreach (var item in listgiohang)
            {
                SizeSanPham sizesanpham = context.SizeSanPham.Where(s => s.Id == item.IdSizeSanPham).SingleOrDefault();
                SanPham sanpham = context.SanPham.Where(s => s.Id == sizesanpham.IdSanPham).SingleOrDefault();
                double dongia = 0;
                double giamgia = sanpham.GiamGia ?? 0;
                if (giamgia > 0)
                {
                    dongia = sanpham.Gia * (100 - sanpham.GiamGia) / 100 ?? 0;
                }
                else
                {
                    dongia = sanpham.Gia ?? 0;
                }

                ChiTietDonHang chitietdonhang = new ChiTietDonHang();
                chitietdonhang.IdDonHang = guid;
                chitietdonhang.IdSizeSanPham = item.IdSizeSanPham;
                chitietdonhang.SoLuong = item.SoLuong;
                chitietdonhang.DonGia = dongia;
                context.ChiTietDonHang.Add(chitietdonhang);
                context.SaveChanges();

                //SỬa SizeSanPham
                sizesanpham.SoLuong = sizesanpham.SoLuong - item.SoLuong;
                context.SaveChanges();
            }

            //Xoá lịch sử giỏ hàng
            GioHangBUS giohangbus = new GioHangBUS();
            giohangbus.DeleteAllFromCart(taikhoan.Id.ToString());
        }

        public List<DonHang> GetDonHang(string tendangnhap, string tinhtrang)
        {
            List<DonHang> list = context.DonHang.Where(dh => dh.IdTaiKhoanNavigation.TenDangNhap == tendangnhap && dh.TinhTrang == tinhtrang)
                                                .Include(dh => dh.IdTaiKhoanNavigation)
                                                .ToList();
            return list;
        }

        public List<ChiTietDonHang> GetChiTietDonHang(string tendangnhap, string tinhtrang)
        {
            List<ChiTietDonHang> list = context.ChiTietDonHang.Where(dh => dh.IdDonHangNavigation.TinhTrang == tinhtrang && dh.IdDonHangNavigation.IdTaiKhoanNavigation.TenDangNhap == tendangnhap)
                                                              .OrderBy(dh => dh.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoan)
                                                              .Include(dh => dh.IdDonHangNavigation)
                                                              .Include(dh => dh.IdDonHangNavigation.IdTaiKhoanNavigation)
                                                              .Include(dh => dh.IdSizeSanPhamNavigation)
                                                              .Include(dh => dh.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                                              .Include(dh => dh.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                                              .ToList();
            return list;
        }

        public DonHang GetExactDonHang(string id)
        {
            DonHang donhang = context.DonHang.Where(dh => dh.Id == Guid.Parse(id))
                                             .Include(dh => dh.IdTaiKhoanNavigation)
                                             .SingleOrDefault();
            return donhang;
        }

        public List<ChiTietDonHang> GetExactChiTietDonHang(string id)
        {
            List<ChiTietDonHang> list = context.ChiTietDonHang.Where(dh => dh.IdDonHang == Guid.Parse(id))
                                                              .OrderBy(dh => dh.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoan)
                                                              .Include(dh => dh.IdDonHangNavigation)
                                                              .Include(dh => dh.IdDonHangNavigation.IdTaiKhoanNavigation)
                                                              .Include(dh => dh.IdSizeSanPhamNavigation)
                                                              .Include(dh => dh.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                                              .Include(dh => dh.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                                              .ToList();
            return list;
        }

        public void HuyDonHang(string madonhang)
        {
            DonHang donhang = context.DonHang.Where(dh => dh.MaDonHang == madonhang).SingleOrDefault();
            donhang.TinhTrang = "Đã huỷ";
            context.SaveChanges();
        }
    }
}
