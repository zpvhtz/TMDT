using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class ChiTietPhieuGiao
    {
        public Guid IdPhieuGiao { get; set; }
        public Guid IdSizeSanPham { get; set; }
        public int? SoLuong { get; set; }
        public double? Gia { get; set; }

        public PhieuGiao IdPhieuGiaoNavigation { get; set; }
        public SizeSanPham IdSizeSanPhamNavigation { get; set; }
    }
}
