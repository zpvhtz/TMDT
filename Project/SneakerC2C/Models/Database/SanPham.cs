using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class SanPham
    {
        public SanPham()
        {
            SizeSanPham = new HashSet<SizeSanPham>();
        }

        public Guid Id { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public Guid IdTaiKhoan { get; set; }
        public string Mau { get; set; }
        public Guid IdHangSanPham { get; set; }
        public string PhanLoai { get; set; }
        public double? Gia { get; set; }
        public string Hinh { get; set; }
        public string ChiTiet { get; set; }
        public double? GiamGia { get; set; }
        public DateTime? NgayDang { get; set; }
        public string TinhTrang { get; set; }

        public HangSanPham IdHangSanPhamNavigation { get; set; }
        public TaiKhoan IdTaiKhoanNavigation { get; set; }
        public ICollection<SizeSanPham> SizeSanPham { get; set; }
    }
}
