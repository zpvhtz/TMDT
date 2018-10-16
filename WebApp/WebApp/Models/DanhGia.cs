using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class DanhGia
    {
        public Guid Id { get; set; }
        public Guid IdTaiKhoanDanhGia { get; set; }
        public Guid IdTaiKhoanDuocDanhGia { get; set; }
        public double? Diem { get; set; }

        public TaiKhoan IdTaiKhoanDanhGiaNavigation { get; set; }
        public TaiKhoan IdTaiKhoanDuocDanhGiaNavigation { get; set; }
    }
}
