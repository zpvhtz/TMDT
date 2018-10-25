namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        [Key]
        [Column(Order = 0)]
        public Guid IdTaiKhoan { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid IdSanPham { get; set; }

        public int? SoLuong { get; set; }

        public TimeSpan? ThoiGian { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
