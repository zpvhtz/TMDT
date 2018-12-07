using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class ChiTietPhieuDat
    {
        public Guid IdPhieuDat { get; set; }
        public Guid IdSizeSanPham { get; set; }
        public int? SoLuong { get; set; }
        public double? Gia { get; set; }

        public PhieuDat IdPhieuDatNavigation { get; set; }
        public SizeSanPham IdSizeSanPhamNavigation { get; set; }
    }
}
