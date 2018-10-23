using System;
using System.Collections.Generic;

namespace Models
{
    public partial class GoiQuangCao
    {
        public GoiQuangCao()
        {
            QuangCao = new HashSet<QuangCao>();
        }

        public Guid Id { get; set; }
        public string MaGoiQuangCao { get; set; }
        public string ViTri { get; set; }
        public double? Gia { get; set; }
        public int? ThoiLuong { get; set; }

        public ICollection<QuangCao> QuangCao { get; set; }
    }
}
