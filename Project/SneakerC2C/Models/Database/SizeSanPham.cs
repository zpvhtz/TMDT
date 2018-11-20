using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class SizeSanPham
    {
        public SizeSanPham()
        {
            GioHang = new HashSet<GioHang>();
        }

        public Guid Id { get; set; }
        public Guid IdSanPham { get; set; }
        public int? Size { get; set; }
        public int? SoLuong { get; set; }
        public string TinhTrang { get; set; }

        public SanPham IdSanPhamNavigation { get; set; }
        public ICollection<GioHang> GioHang { get; set; }
    }
}
