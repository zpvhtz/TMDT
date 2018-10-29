namespace Models.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyBanGiayC2CDbConText : DbContext
    {
        public QuanLyBanGiayC2CDbConText()
            : base("name=QuanLyBanGiayC2C")
        {
        }

        public virtual DbSet<ChiTietPhieuDat> ChiTietPhieuDats { get; set; }
        public virtual DbSet<ChiTietPhieuGiao> ChiTietPhieuGiaos { get; set; }
        public virtual DbSet<DanhGia> DanhGias { get; set; }
        public virtual DbSet<DiaChi> DiaChis { get; set; }
        public virtual DbSet<GiaShip> GiaShips { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<GoiQuangCao> GoiQuangCaos { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }
        public virtual DbSet<LoaiNguoiDung> LoaiNguoiDungs { get; set; }
        public virtual DbSet<PhieuDat> PhieuDats { get; set; }
        public virtual DbSet<PhieuGiao> PhieuGiaos { get; set; }
        public virtual DbSet<QuangCao> QuangCaos { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TinhThanh> TinhThanhs { get; set; }
        public virtual DbSet<TrangQuangCao> TrangQuangCaos { get; set; }
        public virtual DbSet<ViTriQuangcao> ViTriQuangcaos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GoiQuangCao>()
                .Property(e => e.MaGoiQuangCao)
                .IsUnicode(false);

            modelBuilder.Entity<GoiQuangCao>()
                .HasMany(e => e.QuangCaos)
                .WithRequired(e => e.GoiQuangCao)
                .HasForeignKey(e => e.IdGoiQuangCao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhuyenMai>()
                .Property(e => e.MaKhuyenMai)
                .IsUnicode(false);

            modelBuilder.Entity<KhuyenMai>()
                .HasMany(e => e.PhieuDats)
                .WithRequired(e => e.KhuyenMai)
                .HasForeignKey(e => e.IdKhuyenMai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhuyenMai>()
                .HasMany(e => e.PhieuGiaos)
                .WithRequired(e => e.KhuyenMai)
                .HasForeignKey(e => e.IdKhuyenMai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiNguoiDung>()
                .Property(e => e.MaLoaiNguoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiNguoiDung>()
                .HasMany(e => e.TaiKhoans)
                .WithRequired(e => e.LoaiNguoiDung)
                .HasForeignKey(e => e.IdLoaiNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuDat>()
                .Property(e => e.MaPhieuDat)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuDat>()
                .HasMany(e => e.ChiTietPhieuDats)
                .WithRequired(e => e.PhieuDat)
                .HasForeignKey(e => e.IdPhieuDat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuGiao>()
                .Property(e => e.MaPhieuGiao)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuGiao>()
                .Property(e => e.CMNDGiao)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuGiao>()
                .HasMany(e => e.ChiTietPhieuGiaos)
                .WithRequired(e => e.PhieuGiao)
                .HasForeignKey(e => e.IdPhieuGiao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuangCao>()
                .Property(e => e.MaQuangCao)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaSanPham)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietPhieuDats)
                .WithRequired(e => e.SanPham)
                .HasForeignKey(e => e.IdSanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietPhieuGiaos)
                .WithRequired(e => e.SanPham)
                .HasForeignKey(e => e.IdSanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.GioHangs)
                .WithRequired(e => e.SanPham)
                .HasForeignKey(e => e.IdSanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TaiKhoan1)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.DanhGias)
                .WithRequired(e => e.TaiKhoan)
                .HasForeignKey(e => e.IdTaiKhoanDanhGia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.DanhGias1)
                .WithRequired(e => e.TaiKhoan1)
                .HasForeignKey(e => e.IdTaiKhoanDuocDanhGia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.DiaChis)
                .WithRequired(e => e.TaiKhoan)
                .HasForeignKey(e => e.IdTaiKhoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.GioHangs)
                .WithRequired(e => e.TaiKhoan)
                .HasForeignKey(e => e.IdTaiKhoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.PhieuDats)
                .WithRequired(e => e.TaiKhoan)
                .HasForeignKey(e => e.IdTaiKhoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.PhieuGiaos)
                .WithRequired(e => e.TaiKhoan)
                .HasForeignKey(e => e.IdTaiKhoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.QuangCaos)
                .WithRequired(e => e.TaiKhoan)
                .HasForeignKey(e => e.IdTaiKhoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.SanPhams)
                .WithRequired(e => e.TaiKhoan)
                .HasForeignKey(e => e.IdTaiKhoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TinhThanh>()
                .Property(e => e.MaTinhThanh)
                .IsUnicode(false);

            modelBuilder.Entity<TinhThanh>()
                .HasMany(e => e.DiaChis)
                .WithRequired(e => e.TinhThanh)
                .HasForeignKey(e => e.IdTinhThanh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrangQuangCao>()
                .Property(e => e.MaTrang)
                .IsUnicode(false);

            modelBuilder.Entity<TrangQuangCao>()
                .HasMany(e => e.ViTriQuangcaos)
                .WithRequired(e => e.TrangQuangCao)
                .HasForeignKey(e => e.IdTrang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ViTriQuangcao>()
                .Property(e => e.MaViTri)
                .IsUnicode(false);

            modelBuilder.Entity<ViTriQuangcao>()
                .HasMany(e => e.GoiQuangCaos)
                .WithRequired(e => e.ViTriQuangcao)
                .HasForeignKey(e => e.IdViTri)
                .WillCascadeOnDelete(false);
        }
    }
}
