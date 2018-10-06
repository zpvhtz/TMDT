using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class HoaHong
    {
        public HoaHong()
        {
            ChiTietPhieuGiao = new HashSet<ChiTietPhieuGiao>();
        }

        public Guid Id { get; set; }
        public string MaHoaHong { get; set; }
        public double? PhanTram { get; set; }
        public DateTime? NgayBatDau { get; set; }

        public ICollection<ChiTietPhieuGiao> ChiTietPhieuGiao { get; set; }
    }
}
