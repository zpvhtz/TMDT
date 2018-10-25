using System;
using System.Collections.Generic;

namespace Models
{
    public partial class KhuyenMai
    {
        public KhuyenMai()
        {
            PhieuDat = new HashSet<PhieuDat>();
            PhieuGiao = new HashSet<PhieuGiao>();
        }

        public Guid Id { get; set; }
        public string MaKhuyenMai { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public double? GiamGia { get; set; }
        public string NoiDung { get; set; }
        public string TinhTrang { get; set; }

        public ICollection<PhieuDat> PhieuDat { get; set; }
        public ICollection<PhieuGiao> PhieuGiao { get; set; }
    }
}
