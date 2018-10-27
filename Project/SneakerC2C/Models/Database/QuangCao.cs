using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class QuangCao
    {
        public Guid Id { get; set; }
        public string MaQuangCao { get; set; }
        public Guid IdGoiQuangCao { get; set; }
        public Guid IdTaiKhoan { get; set; }
        public string Hinh { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string ChuThich { get; set; }
        public string TinhTrang { get; set; }

        public GoiQuangCao IdGoiQuangCaoNavigation { get; set; }
        public TaiKhoan IdTaiKhoanNavigation { get; set; }
    }
}
