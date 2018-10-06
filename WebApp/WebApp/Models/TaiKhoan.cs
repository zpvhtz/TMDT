using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            DiaChi = new HashSet<DiaChi>();
            GioHang = new HashSet<GioHang>();
            PhieuDat = new HashSet<PhieuDat>();
            PhieuGiao = new HashSet<PhieuGiao>();
            PhieuNhap = new HashSet<PhieuNhap>();
            QuangCao = new HashSet<QuangCao>();
            SanPham = new HashSet<SanPham>();
        }

        public Guid Id { get; set; }
        public string TaiKhoan1 { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string Ten { get; set; }
        public string DienThoai { get; set; }
        public string Cmnd { get; set; }
        public Guid IdLoaiNguoiDung { get; set; }
        public DateTime? NgayTao { get; set; }
        public string TinhTrang { get; set; }

        public LoaiNguoiDung IdLoaiNguoiDungNavigation { get; set; }
        public ICollection<DiaChi> DiaChi { get; set; }
        public ICollection<GioHang> GioHang { get; set; }
        public ICollection<PhieuDat> PhieuDat { get; set; }
        public ICollection<PhieuGiao> PhieuGiao { get; set; }
        public ICollection<PhieuNhap> PhieuNhap { get; set; }
        public ICollection<QuangCao> QuangCao { get; set; }
        public ICollection<SanPham> SanPham { get; set; }
    }
}
