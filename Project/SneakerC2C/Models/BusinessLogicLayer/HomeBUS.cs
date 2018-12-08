using Microsoft.EntityFrameworkCore;
using Models.Database;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BusinessLogicLayer
{
    public class HomeBUS
    {
        private readonly QLBanGiayContext context;

        public HomeBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public HomeBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        //public List<DoanhThuMerchant> GetDoanhThuMerchants(DateTime nbd, DateTime nkt)
        //{
        //    var list = from phieugiao in context.PhieuGiao
        //               join taikhoan in context.TaiKhoan on phieugiao.IdTaiKhoan equals taikhoan.Id

        //               //where phieugiao.NgayGiao.Value >= nbd && phieugiao.NgayGiao.Value <= nkt
        //               where phieugiao.NgayGiao.Value.Month >= nbd.Month && phieugiao.NgayGiao.Value.Month <= nkt.Month
        //                   && phieugiao.NgayGiao.Value.Year >= nbd.Year && phieugiao.NgayGiao.Value.Year <= nkt.Year
        //               group new { phieugiao, taikhoan } by new { phieugiao.NgayGiao.Value.Month, phieugiao.NgayGiao.Value.Year } into khoadeptrai
        //               select new DoanhThuMerchant
        //               {
        //                   Thang = khoadeptrai.Key.Month,
        //                   Nam = khoadeptrai.Key.Year,
        //                   SoLuong = khoadeptrai.Select(k => k.phieugiao.Id).Distinct().Count(),
        //                   ThuNhap = (double)khoadeptrai.Sum(k => k.phieugiao.TongTien)
        //               };
        //    List<DoanhThuMerchant> listthongke = list.ToList();
        //    return listthongke;
        //}
        public List<SoLuongNguoiDung> GetSoLuongNguoiDung()
        {
            var list = from taikhoan in context.TaiKhoan
                       join loainguoidung in context.LoaiNguoiDung on taikhoan.IdLoaiNguoiDung equals loainguoidung.Id
                       //where taikhoan.NgayTao >= nbd
                       group new { taikhoan, loainguoidung } by new { loainguoidung.TenLoaiNguoiDung } into khoadeptrai
                       select new SoLuongNguoiDung
                       {
                           TenLoaiNguoiDung = khoadeptrai.Key.TenLoaiNguoiDung,
                           SoLuong = khoadeptrai.Select(k => k.taikhoan.Id).Distinct().Count(),
                       };
            List<SoLuongNguoiDung> listthongke = list.ToList();
            return listthongke;
        }
        public List<DoanhThuQuangCao> GetDoanhThuQuangCao(DateTime nbd, DateTime nkt)
        {
            var list = from quangcao in context.QuangCao
                       join goiquangcao in context.GoiQuangCao on quangcao.IdGoiQuangCao equals  goiquangcao.Id

                       //where phieugiao.NgayGiao.Value >= nbd && phieugiao.NgayGiao.Value <= nkt
                       where quangcao.TinhTrang != "Sai dữ liệu" &&
                       quangcao.NgayBatDau.Value.Month >= nbd.Month && quangcao.NgayBatDau.Value.Month <= nkt.Month
                           && quangcao.NgayBatDau.Value.Year >= nbd.Year && quangcao.NgayBatDau.Value.Year <= nkt.Year
                       group new { quangcao, goiquangcao } by new { quangcao.NgayBatDau.Value.Month, quangcao.NgayBatDau.Value.Year } into khoadeptrai
                       select new DoanhThuQuangCao
                       {
                           Thang = khoadeptrai.Key.Month,
                           Nam = khoadeptrai.Key.Year,
                           SoLuong = khoadeptrai.Select(k => k.quangcao.Id).Distinct().Count(),
                           ThuNhap = (double)khoadeptrai.Sum(k => k.goiquangcao.TongTien)
                       };
            List<DoanhThuQuangCao> listthongke = list.ToList();
            return listthongke;
        }

        public List<DoanhThuGianHang> GetDoanhThuGianHang(DateTime nbd, DateTime nkt)
        {
            var list = from gianhang in context.GianHang
                       join lichsugianghang in context.LichSuGianHang on gianhang.Id equals lichsugianghang.IdGianHang
                       where
                       //where phieugiao.NgayGiao.Value >= nbd && phieugiao.NgayGiao.Value <= nkt
                       lichsugianghang.NgayBatDau.Value.Month >= nbd.Month && lichsugianghang.NgayBatDau.Value.Month <= nkt.Month
                           && lichsugianghang.NgayBatDau.Value.Year >= nbd.Year && lichsugianghang.NgayBatDau.Value.Year <= nkt.Year
                       group new { gianhang, lichsugianghang } by new { lichsugianghang.NgayBatDau.Value.Month, lichsugianghang.NgayBatDau.Value.Year } into khoadeptrai
                       select new DoanhThuGianHang
                       {
                           Thang = khoadeptrai.Key.Month,
                           Nam = khoadeptrai.Key.Year,
                           SoLuong = khoadeptrai.Select(k => k.lichsugianghang.Id).Distinct().Count(),
                           ThuNhap = (double)khoadeptrai.Sum(k => k.gianhang.Gia)
                       };
            List<DoanhThuGianHang> listthongke = list.ToList();
            return listthongke;
        }
    }
}
