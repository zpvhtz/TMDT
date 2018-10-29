using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class PhieuDat
    {
        public PhieuDat()
        {
            ChiTietPhieuDat = new HashSet<ChiTietPhieuDat>();
        }

        public Guid Id { get; set; }
        public string MaPhieuDat { get; set; }
        public Guid IdTaiKhoan { get; set; }
        public DateTime? NgayTao { get; set; }
        public Guid IdKhuyenMai { get; set; }
        public double? TongTien { get; set; }
        public string TinhTrang { get; set; }

        public KhuyenMai IdKhuyenMaiNavigation { get; set; }
        public TaiKhoan IdTaiKhoanNavigation { get; set; }
        public ICollection<ChiTietPhieuDat> ChiTietPhieuDat { get; set; }
    }
}
