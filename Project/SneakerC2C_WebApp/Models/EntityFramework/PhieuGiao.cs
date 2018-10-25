namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuGiao")]
    public partial class PhieuGiao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuGiao()
        {
            ChiTietPhieuGiaos = new HashSet<ChiTietPhieuGiao>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(10)]
        public string MaPhieuGiao { get; set; }

        [Required]
        [StringLength(20)]
        public string CMNDGiao { get; set; }

        public Guid IdTaiKhoan { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgayGiao { get; set; }

        public Guid IdKhuyenMai { get; set; }

        public double? TongTien { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuGiao> ChiTietPhieuGiaos { get; set; }

        public virtual KhuyenMai KhuyenMai { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
