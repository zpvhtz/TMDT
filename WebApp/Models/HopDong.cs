using System;
using System.Collections.Generic;

namespace Models
{
    public partial class HopDong
    {
        public Guid Id { get; set; }
        public string MaHopDong { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string ChuThich { get; set; }
        public double? Gia { get; set; }
    }
}
