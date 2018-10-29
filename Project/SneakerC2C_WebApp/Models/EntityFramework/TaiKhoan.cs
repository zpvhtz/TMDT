namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            DanhGias = new HashSet<DanhGia>();
            DanhGias1 = new HashSet<DanhGia>();
            DiaChis = new HashSet<DiaChi>();
            GioHangs = new HashSet<GioHang>();
            PhieuDats = new HashSet<PhieuDat>();
            PhieuGiaos = new HashSet<PhieuGiao>();
            QuangCaos = new HashSet<QuangCao>();
            SanPhams = new HashSet<SanPham>();
        }

        public Guid Id { get; set; }

        [Column("TaiKhoan")]
        [Required]
        [StringLength(20)]
        public string TaiKhoan1 { get; set; }

        [Required]
        [StringLength(30)]
        public string MatKhau { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Ten { get; set; }

        [StringLength(20)]
        public string DienThoai { get; set; }

        [StringLength(20)]
        public string CMND { get; set; }

        public Guid IdLoaiNguoiDung { get; set; }

        public DateTime? NgayTao { get; set; }

        public double? DanhGia { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiaChi> DiaChis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }

        public virtual LoaiNguoiDung LoaiNguoiDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuDat> PhieuDats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuGiao> PhieuGiaos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuangCao> QuangCaos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
