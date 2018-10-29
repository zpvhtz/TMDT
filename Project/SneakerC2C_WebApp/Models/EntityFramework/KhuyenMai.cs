namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhuyenMai")]
    public partial class KhuyenMai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhuyenMai()
        {
            PhieuDats = new HashSet<PhieuDat>();
            PhieuGiaos = new HashSet<PhieuGiao>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(10)]
        public string MaKhuyenMai { get; set; }

        public DateTime? NgayBatDau { get; set; }

        public DateTime? NgayKetThuc { get; set; }

        public double? GiamGia { get; set; }

        [StringLength(500)]
        public string NoiDung { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuDat> PhieuDats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuGiao> PhieuGiaos { get; set; }
    }
}
