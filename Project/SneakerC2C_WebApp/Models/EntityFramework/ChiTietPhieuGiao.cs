namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietPhieuGiao")]
    public partial class ChiTietPhieuGiao
    {
        [Key]
        [Column(Order = 0)]
        public Guid IdPhieuGiao { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid IdSanPham { get; set; }

        public int? SoLuong { get; set; }

        public double? Gia { get; set; }

        public virtual PhieuGiao PhieuGiao { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
