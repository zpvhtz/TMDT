using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class DonHang
    {
        public DonHang()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        public Guid Id { get; set; }
        public string MaDonHang { get; set; }
        public string CmndnguoiGiao { get; set; }
        public Guid IdTaiKhoan { get; set; }
        public string DiaChiGiao { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayGiao { get; set; }
        public double? TongTien { get; set; }
        public string TinhTrangDanhGiaCustomer { get; set; }
        public string TinhTrang { get; set; }

        public TaiKhoan IdTaiKhoanNavigation { get; set; }
        public ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }
    }
}
