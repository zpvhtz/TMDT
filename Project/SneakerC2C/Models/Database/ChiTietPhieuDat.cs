using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class ChiTietPhieuDat
    {
        public Guid IdPhieuDat { get; set; }
        public Guid IdSanPham { get; set; }
        public int? SoLuong { get; set; }
        public double? Gia { get; set; }

        public PhieuDat IdPhieuDatNavigation { get; set; }
        public SanPham IdSanPhamNavigation { get; set; }
    }
}
