using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
                    thongbao = sizesanpham.IdSanPhamNavigation.TenSanPham + " có số lượng vượt quá tồn kho (SL kho: " + sizesanpham.SoLuong + ")";
                    return thongbao;
                }
            }
            return "Đặt hàng thành công";
        }

        public void CreateDonDatHang(string tendangnhap, string iddiachi, double tongtien)
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
                latestMa = "DH-" + (ma + 1).ToString();
            }

            //Thêm đơn hàng
            TaiKhoan taikhoan = context.TaiKhoan.Where(tk => tk.TenDangNhap == tendangnhap).SingleOrDefault();
            DiaChi diachi = context.DiaChi.Where(dc => dc.Id == Guid.Parse(iddiachi)).Include(dc => dc.IdTaiKhoanNavigation).Include(dc => dc.IdTinhThanhNavigation).SingleOrDefault();

            Guid guid = Guid.Parse(Guid.NewGuid().ToString().ToUpper());

            DonHang donhang = new DonHang();
            donhang.Id = guid;
            donhang.MaDonHang = latestMa;
            donhang.IdTaiKhoan = taikhoan.Id;
            donhang.DiaChiGiao = diachi.Duong + " " + diachi.IdTinhThanhNavigation.TenTinhThanh;
            donhang.NgayTao = DateTime.Now;
            donhang.TongTien = tongtien;
            donhang.TinhTrangDanhGiaCustomer = "Chưa đánh giá";
            donhang.TinhTrang = "Chưa xử lý";

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
                chitietdonhang.DiemCustomerDanhGia = 0;
                chitietdonhang.DiemMerchantDanhGia = 0;
                chitietdonhang.TinhTrangChiTiet = "Chưa xử lý";
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
            List<DonHang> list = new List<DonHang>();

            if(tinhtrang == "Đã xử lý")
            {
                list = context.DonHang.Where(dh => dh.IdTaiKhoanNavigation.TenDangNhap == tendangnhap && dh.TinhTrang == "Đã xử lý")
                                      .Include(dh => dh.IdTaiKhoanNavigation)
                                      .ToList();
            }
            else
            {
                if(tinhtrang == "Chưa xử lý")
                {
                    List<ChiTietDonHang> listchitiet = new List<ChiTietDonHang>();
                    listchitiet = context.ChiTietDonHang.Where(ct => ct.TinhTrangChiTiet != tinhtrang).ToList();

                    var listid = listchitiet.Select(ct => ct.IdDonHang).ToList();
                    list = context.DonHang.Where(dh => !listid.Contains(dh.Id)).ToList();
                }
                else
                {
                    List<ChiTietDonHang> listchitiet = new List<ChiTietDonHang>();
                    listchitiet = context.ChiTietDonHang.Where(ct => ct.TinhTrangChiTiet == tinhtrang).ToList();

                    var listid = listchitiet.Select(ct => ct.IdDonHang).ToList();
                    list = context.DonHang.Where(dh => listid.Contains(dh.Id)).ToList();
                }
            }
            return list;
        }

        public List<ChiTietDonHang> GetChiTietDonHang(string tendangnhap, string tinhtrang)
        {
            List<ChiTietDonHang> list = new List<ChiTietDonHang>();
            if (tinhtrang == "Đã xử lý")
            {
                list = context.ChiTietDonHang.Where(dh => dh.TinhTrangChiTiet == tinhtrang && dh.IdDonHangNavigation.IdTaiKhoanNavigation.TenDangNhap == tendangnhap)
                                             .OrderBy(dh => dh.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoan)
                                             .Include(dh => dh.IdDonHangNavigation)
                                             .Include(dh => dh.IdDonHangNavigation.IdTaiKhoanNavigation)
                                             .Include(dh => dh.IdSizeSanPhamNavigation)
                                             .Include(dh => dh.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                             .Include(dh => dh.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                             .ToList();
            }
            else
            {
                list = context.ChiTietDonHang.Where(dh => dh.TinhTrangChiTiet == tinhtrang && dh.IdDonHangNavigation.IdTaiKhoanNavigation.TenDangNhap == tendangnhap)
                                             .OrderBy(dh => dh.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoan)
                                             .Include(dh => dh.IdDonHangNavigation)
                                             .Include(dh => dh.IdDonHangNavigation.IdTaiKhoanNavigation)
                                             .Include(dh => dh.IdSizeSanPhamNavigation)
                                             .Include(dh => dh.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                             .Include(dh => dh.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                             .ToList();
            }
             
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

        public void CustomerDanhGia(string iddonhang, string idmerchant, int radio_check)
        {
            List<ChiTietDonHang> listchitietdonhang = new List<ChiTietDonHang>();
            listchitietdonhang = context.ChiTietDonHang.Where(c => c.IdDonHang == Guid.Parse(iddonhang) && c.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoan == Guid.Parse(idmerchant))
                                                       .Include(c => c.IdSizeSanPhamNavigation)
                                                       .Include(c => c.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                                       .ToList();
            foreach(var item in listchitietdonhang)
            {
                item.DiemCustomerDanhGia = radio_check;
            }
            context.SaveChanges();

        }

        public void CustomerDanhGiaTable(string iddanhgia, string idduocdanhgia, int radio_check)
        {
            DanhGia danhgia = new DanhGia();
            danhgia.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            danhgia.IdTaiKhoanDanhGia = Guid.Parse(iddanhgia);
            danhgia.IdTaiKhoanDuocDanhGia = Guid.Parse(idduocdanhgia);
            danhgia.Diem = radio_check;
            context.DanhGia.Add(danhgia);
            context.SaveChanges();
        }
    }
}
