using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class DiaChi
    {
        public Guid Id { get; set; }
        public Guid IdTaiKhoan { get; set; }
        public string Duong { get; set; }
        public Guid IdTinhThanh { get; set; }
        public string TinhTrang { get; set; }

        public TaiKhoan IdTaiKhoanNavigation { get; set; }
        public TinhThanh IdTinhThanhNavigation { get; set; }
    }
}
