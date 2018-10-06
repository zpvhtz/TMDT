using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class LoaiNguoiDung
    {
        public LoaiNguoiDung()
        {
            NhanVien = new HashSet<NhanVien>();
            TaiKhoan = new HashSet<TaiKhoan>();
        }

        public Guid Id { get; set; }
        public string MaLoaiNguoiDung { get; set; }
        public string TenLoaiNguoiDung { get; set; }

        public ICollection<NhanVien> NhanVien { get; set; }
        public ICollection<TaiKhoan> TaiKhoan { get; set; }
    }
}
