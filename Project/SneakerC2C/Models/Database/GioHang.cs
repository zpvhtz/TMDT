using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class GioHang
    {
        public Guid IdTaiKhoan { get; set; }
        public Guid IdSizeSanPham { get; set; }
        public int? SoLuong { get; set; }
        public string TinhTrang { get; set; }

        public SizeSanPham IdSizeSanPhamNavigation { get; set; }
        public TaiKhoan IdTaiKhoanNavigation { get; set; }
    }
}
