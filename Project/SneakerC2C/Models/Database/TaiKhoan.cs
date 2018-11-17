using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            DanhGiaIdTaiKhoanDanhGiaNavigation = new HashSet<DanhGia>();
            DanhGiaIdTaiKhoanDuocDanhGiaNavigation = new HashSet<DanhGia>();
            DiaChi = new HashSet<DiaChi>();
            GioHang = new HashSet<GioHang>();
            LichSuGianHang = new HashSet<LichSuGianHang>();
            PhieuDat = new HashSet<PhieuDat>();
            PhieuGiao = new HashSet<PhieuGiao>();
            QuangCao = new HashSet<QuangCao>();
            SanPham = new HashSet<SanPham>();
        }

        public Guid Id { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string Ten { get; set; }
        public string TenShop { get; set; }
        public string DienThoai { get; set; }
        public string Cmnd { get; set; }
        public Guid IdLoaiNguoiDung { get; set; }
        public DateTime? NgayTao { get; set; }
        public double? DanhGia { get; set; }
        public DateTime? ThoiHanGianHang { get; set; }
        public int? DatLaiMatKhau { get; set; }
        public string TinhTrang { get; set; }

        public LoaiNguoiDung IdLoaiNguoiDungNavigation { get; set; }
        public ICollection<DanhGia> DanhGiaIdTaiKhoanDanhGiaNavigation { get; set; }
        public ICollection<DanhGia> DanhGiaIdTaiKhoanDuocDanhGiaNavigation { get; set; }
        public ICollection<DiaChi> DiaChi { get; set; }
        public ICollection<GioHang> GioHang { get; set; }
        public ICollection<LichSuGianHang> LichSuGianHang { get; set; }
        public ICollection<PhieuDat> PhieuDat { get; set; }
        public ICollection<PhieuGiao> PhieuGiao { get; set; }
        public ICollection<QuangCao> QuangCao { get; set; }
        public ICollection<SanPham> SanPham { get; set; }
    }
}
