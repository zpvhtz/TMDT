namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietPhieuDat")]
    public partial class ChiTietPhieuDat
    {
        [Key]
        [Column(Order = 0)]
        public Guid IdPhieuDat { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid IdSanPham { get; set; }

        public int? SoLuong { get; set; }

        public virtual PhieuDat PhieuDat { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
