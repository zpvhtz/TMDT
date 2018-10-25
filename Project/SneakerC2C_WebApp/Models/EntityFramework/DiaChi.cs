namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiaChi")]
    public partial class DiaChi
    {
        public Guid Id { get; set; }

        public Guid IdTaiKhoan { get; set; }

        [Required]
        [StringLength(100)]
        public string Duong { get; set; }

        public Guid IdTinhThanh { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        public virtual TinhThanh TinhThanh { get; set; }
    }
}
