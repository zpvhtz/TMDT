using System;
using System.Collections.Generic;

namespace Models
{
    public partial class ChiTietPhieuNhap
    {
        public Guid IdPhieuNhap { get; set; }
        public Guid IdSanPham { get; set; }
        public int? SoLuong { get; set; }
        public double? Gia { get; set; }

        public PhieuNhap IdPhieuNhapNavigation { get; set; }
        public SanPham IdSanPhamNavigation { get; set; }
    }
}
