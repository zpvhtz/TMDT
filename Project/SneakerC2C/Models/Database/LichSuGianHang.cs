using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class LichSuGianHang
    {
        public Guid Id { get; set; }
        public Guid IdTaiKhoan { get; set; }
        public Guid IdGianHang { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string TinhTrang { get; set; }

        public GianHang IdGianHangNavigation { get; set; }
        public TaiKhoan IdTaiKhoanNavigation { get; set; }
    }
}
