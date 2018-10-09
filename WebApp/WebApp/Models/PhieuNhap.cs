using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class PhieuNhap
    {
        public PhieuNhap()
        {
            ChiTietPhieuNhap = new HashSet<ChiTietPhieuNhap>();
        }

        public Guid Id { get; set; }
        public string MaPhieuNhap { get; set; }
        public Guid IdTaiKhoan { get; set; }
        public DateTime? NgayNhap { get; set; }
        public double? TongTien { get; set; }
        public string TinhTrang { get; set; }

        public TaiKhoan IdTaiKhoanNavigation { get; set; }
        public ICollection<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }
    }
}
