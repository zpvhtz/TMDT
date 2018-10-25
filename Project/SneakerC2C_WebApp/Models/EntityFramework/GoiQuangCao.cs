namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GoiQuangCao")]
    public partial class GoiQuangCao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoiQuangCao()
        {
            QuangCaos = new HashSet<QuangCao>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(10)]
        public string MaGoiQuangCao { get; set; }

        public Guid IdViTri { get; set; }

        public double? TongTien { get; set; }

        public int? ThoiLuong { get; set; }

        public virtual ViTriQuangcao ViTriQuangcao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuangCao> QuangCaos { get; set; }
    }
}
