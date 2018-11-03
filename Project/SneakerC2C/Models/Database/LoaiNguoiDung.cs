using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Database
{
    public partial class LoaiNguoiDung
    {
        public LoaiNguoiDung()
        {
            TaiKhoan = new HashSet<TaiKhoan>();
        }

        [Display(Name = "Id: ")]
        public Guid Id { get; set; }
        [Display(Name = "Mã Loại Người Dùng: ")]
        public string MaLoaiNguoiDung { get; set; }
        [Display(Name = "Tên Loại Người Dùng: ")]
        public string TenLoaiNguoiDung { get; set; }
        [Display(Name = "Tình Trạng: ")]
        public string TinhTrang { get; set; }

        public ICollection<TaiKhoan> TaiKhoan { get; set; }
    }
}
