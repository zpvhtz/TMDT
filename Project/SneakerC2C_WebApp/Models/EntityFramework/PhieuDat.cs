namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuDat")]
    public partial class PhieuDat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuDat()
        {
            ChiTietPhieuDats = new HashSet<ChiTietPhieuDat>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(10)]
        public string MaPhieuDat { get; set; }

        public Guid IdTaiKhoan { get; set; }

        public DateTime? NgayTao { get; set; }

        public Guid IdKhuyenMai { get; set; }

        public double? TongTien { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuDat> ChiTietPhieuDats { get; set; }

        public virtual KhuyenMai KhuyenMai { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
