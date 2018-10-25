using System;
using System.Collections.Generic;

namespace Models
{
    public partial class ViTriQuangcao
    {
        public ViTriQuangcao()
        {
            GoiQuangCao = new HashSet<GoiQuangCao>();
        }

        public Guid Id { get; set; }
        public string MaViTri { get; set; }
        public string TenViTri { get; set; }
        public Guid IdTrang { get; set; }
        public double? DonGia { get; set; }
        public string ChuThich { get; set; }

        public TrangQuangCao IdTrangNavigation { get; set; }
        public ICollection<GoiQuangCao> GoiQuangCao { get; set; }
    }
}
