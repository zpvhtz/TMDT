namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuangCao")]
    public partial class QuangCao
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(10)]
        public string MaQuangCao { get; set; }

        public Guid IdGoiQuangCao { get; set; }

        public Guid IdTaiKhoan { get; set; }

        [Required]
        [StringLength(200)]
        public string Hinh { get; set; }

        public DateTime? NgayBatDau { get; set; }

        public DateTime? NgayKetThuc { get; set; }

        [StringLength(500)]
        public string ChuThich { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }

        public virtual GoiQuangCao GoiQuangCao { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
