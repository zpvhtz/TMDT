using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HopDong = new HashSet<HopDong>();
            PhieuNhap = new HashSet<PhieuNhap>();
        }

        public Guid Id { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Cmnd { get; set; }
        public Guid IdLoaiNguoiDung { get; set; }
        public double? LuongCoBan { get; set; }
        public double? HeSoLuong { get; set; }
        public double? PhuCap { get; set; }
        public double? TongLuong { get; set; }
        public string TinhTrang { get; set; }

        public LoaiNguoiDung IdLoaiNguoiDungNavigation { get; set; }
        public ICollection<HopDong> HopDong { get; set; }
        public ICollection<PhieuNhap> PhieuNhap { get; set; }
    }
}
