namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViTriQuangcao")]
    public partial class ViTriQuangcao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ViTriQuangcao()
        {
            GoiQuangCaos = new HashSet<GoiQuangCao>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(10)]
        public string MaViTri { get; set; }

        [StringLength(100)]
        public string TenViTri { get; set; }

        public Guid IdTrang { get; set; }

        public double? DonGia { get; set; }

        [StringLength(100)]
        public string ChuThich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoiQuangCao> GoiQuangCaos { get; set; }

        public virtual TrangQuangCao TrangQuangCao { get; set; }
    }
}
