using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class LoaiNguoiDung
    {
        public LoaiNguoiDung()
        {
            TaiKhoan = new HashSet<TaiKhoan>();
        }

        public Guid Id { get; set; }
        public string MaLoaiNguoiDung { get; set; }
        public string TenLoaiNguoiDung { get; set; }
        public string TinhTrang { get; set; }

        public ICollection<TaiKhoan> TaiKhoan { get; set; }
    }
}
