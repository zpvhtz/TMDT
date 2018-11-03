using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class GianHang
    {
        public GianHang()
        {
            LichSuGianHang = new HashSet<LichSuGianHang>();
        }

        public Guid Id { get; set; }
        public string MaGianHang { get; set; }
        public string TenGianHang { get; set; }
        public double? Gia { get; set; }
        public int? ThoiGian { get; set; }
        public string TinhTrang { get; set; }

        public ICollection<LichSuGianHang> LichSuGianHang { get; set; }
    }
}
