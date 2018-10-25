using System;
using System.Collections.Generic;

namespace Models
{
    public partial class GioHang
    {
        public Guid IdTaiKhoan { get; set; }
        public Guid IdSanPham { get; set; }
        public int? SoLuong { get; set; }
        public TimeSpan? ThoiGian { get; set; }
        public string TinhTrang { get; set; }

        public SanPham IdSanPhamNavigation { get; set; }
        public TaiKhoan IdTaiKhoanNavigation { get; set; }
    }
}
