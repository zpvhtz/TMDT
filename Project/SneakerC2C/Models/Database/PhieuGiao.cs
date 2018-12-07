using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class PhieuGiao
    {
        public PhieuGiao()
        {
            ChiTietPhieuGiao = new HashSet<ChiTietPhieuGiao>();
        }

        public Guid Id { get; set; }
        public string MaPhieuGiao { get; set; }
        public string Cmndgiao { get; set; }
        public Guid IdTaiKhoan { get; set; }
        public string DiaChi { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayGiao { get; set; }
        public double? TongTien { get; set; }
        public string DanhGia { get; set; }
        public string TinhTrang { get; set; }

        public TaiKhoan IdTaiKhoanNavigation { get; set; }
        public ICollection<ChiTietPhieuGiao> ChiTietPhieuGiao { get; set; }
    }
}
