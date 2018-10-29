namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietPhieuDats = new HashSet<ChiTietPhieuDat>();
            ChiTietPhieuGiaos = new HashSet<ChiTietPhieuGiao>();
            GioHangs = new HashSet<GioHang>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(10)]
        public string MaSanPham { get; set; }

        [StringLength(100)]
        public string TenSanPham { get; set; }

        public Guid IdTaiKhoan { get; set; }

        public int? Size { get; set; }

        [StringLength(20)]
        public string Mau { get; set; }

        [StringLength(50)]
        public string Hang { get; set; }

        public double? Gia { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(200)]
        public string Hinh { get; set; }

        [StringLength(500)]
        public string ChiTiet { get; set; }

        public double? GiamGia { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuDat> ChiTietPhieuDats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuGiao> ChiTietPhieuGiaos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
