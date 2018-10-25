namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrangQuangCao")]
    public partial class TrangQuangCao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrangQuangCao()
        {
            ViTriQuangcaos = new HashSet<ViTriQuangcao>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(10)]
        public string MaTrang { get; set; }

        [StringLength(100)]
        public string TenTrang { get; set; }

        [StringLength(100)]
        public string ChuThich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ViTriQuangcao> ViTriQuangcaos { get; set; }
    }
}
