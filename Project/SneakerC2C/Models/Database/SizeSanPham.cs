using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class SizeSanPham
    {
        public SizeSanPham()
        {
            ChiTietPhieuDat = new HashSet<ChiTietPhieuDat>();
            ChiTietPhieuGiao = new HashSet<ChiTietPhieuGiao>();
            GioHang = new HashSet<GioHang>();
        }

        public Guid Id { get; set; }
        public Guid IdSanPham { get; set; }
        public int? Size { get; set; }
        public int? SoLuong { get; set; }
        public string TinhTrang { get; set; }

        public SanPham IdSanPhamNavigation { get; set; }
        public ICollection<ChiTietPhieuDat> ChiTietPhieuDat { get; set; }
        public ICollection<ChiTietPhieuGiao> ChiTietPhieuGiao { get; set; }
        public ICollection<GioHang> GioHang { get; set; }
    }
}
