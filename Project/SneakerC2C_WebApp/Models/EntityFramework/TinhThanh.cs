namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinhThanh")]
    public partial class TinhThanh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TinhThanh()
        {
            DiaChis = new HashSet<DiaChi>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(10)]
        public string MaTinhThanh { get; set; }

        [StringLength(20)]
        public string TenTinhThanh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiaChi> DiaChis { get; set; }
    }
}
