using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class GoiQuangCao
    {
        public GoiQuangCao()
        {
            QuangCao = new HashSet<QuangCao>();
        }

        public Guid Id { get; set; }
        public string MaGoiQuangCao { get; set; }
        public Guid IdViTri { get; set; }
        public double? TongTien { get; set; }
        public int? ThoiLuong { get; set; }
        public string TinhTrang { get; set; }

        public ViTriQuangcao IdViTriNavigation { get; set; }
        public ICollection<QuangCao> QuangCao { get; set; }
    }
}
