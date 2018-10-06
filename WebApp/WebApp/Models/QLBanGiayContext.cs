using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApp.Models
{
    public partial class QLBanGiayContext : DbContext
    {
        public QLBanGiayContext()
        {
        }

        public QLBanGiayContext(DbContextOptions<QLBanGiayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietPhieuDat> ChiTietPhieuDat { get; set; }
        public virtual DbSet<ChiTietPhieuGiao> ChiTietPhieuGiao { get; set; }
        public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }
        public virtual DbSet<DiaChi> DiaChi { get; set; }
        public virtual DbSet<GioHang> GioHang { get; set; }
        public virtual DbSet<GoiQuangCao> GoiQuangCao { get; set; }
        public virtual DbSet<HoaHong> HoaHong { get; set; }
        public virtual DbSet<HopDong> HopDong { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMai { get; set; }
        public virtual DbSet<LoaiNguoiDung> LoaiNguoiDung { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<PhieuDat> PhieuDat { get; set; }
        public virtual DbSet<PhieuGiao> PhieuGiao { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhap { get; set; }
        public virtual DbSet<QuangCao> QuangCao { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public virtual DbSet<TinhThanh> TinhThanh { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=HEOBAYMAU;Database=QLBanGiay;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietPhieuDat>(entity =>
            {
                entity.HasKey(e => new { e.IdPhieuDat, e.IdSanPham });

                entity.HasOne(d => d.IdPhieuDatNavigation)
                    .WithMany(p => p.ChiTietPhieuDat)
                    .HasForeignKey(d => d.IdPhieuDat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietPhieuDat_IdPhieuDat");

                entity.HasOne(d => d.IdSanPhamNavigation)
                    .WithMany(p => p.ChiTietPhieuDat)
                    .HasForeignKey(d => d.IdSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietPhieuDat_IdSanPham");
            });

            modelBuilder.Entity<ChiTietPhieuGiao>(entity =>
            {
                entity.HasKey(e => new { e.IdPhieuGiao, e.IdSanPham });

                entity.HasOne(d => d.IdHoaHongNavigation)
                    .WithMany(p => p.ChiTietPhieuGiao)
                    .HasForeignKey(d => d.IdHoaHong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietPhieuGiao_IdHoaHong");

                entity.HasOne(d => d.IdPhieuGiaoNavigation)
                    .WithMany(p => p.ChiTietPhieuGiao)
                    .HasForeignKey(d => d.IdPhieuGiao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietPhieuGiao_IdPhieuGiao");

                entity.HasOne(d => d.IdSanPhamNavigation)
                    .WithMany(p => p.ChiTietPhieuGiao)
                    .HasForeignKey(d => d.IdSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietPhieuGiao_IdSanPham");
            });

            modelBuilder.Entity<ChiTietPhieuNhap>(entity =>
            {
                entity.HasKey(e => new { e.IdPhieuNhap, e.IdSanPham });

                entity.HasOne(d => d.IdPhieuNhapNavigation)
                    .WithMany(p => p.ChiTietPhieuNhap)
                    .HasForeignKey(d => d.IdPhieuNhap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietPhieuNhap_IdPhieuNhap");

                entity.HasOne(d => d.IdSanPhamNavigation)
                    .WithMany(p => p.ChiTietPhieuNhap)
                    .HasForeignKey(d => d.IdSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietPhieuNhap_IdSanPham");
            });

            modelBuilder.Entity<DiaChi>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Duong)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TinhTrang).HasMaxLength(20);

                entity.HasOne(d => d.IdTaiKhoanNavigation)
                    .WithMany(p => p.DiaChi)
                    .HasForeignKey(d => d.IdTaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiaChi_IdTaiKhoan");

                entity.HasOne(d => d.IdTinhThanhNavigation)
                    .WithMany(p => p.DiaChi)
                    .HasForeignKey(d => d.IdTinhThanh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiaChi_IdTinhThanh");
            });

            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.HasKey(e => new { e.IdTaiKhoan, e.IdSanPham });

                entity.Property(e => e.TinhTrang).HasMaxLength(20);

                entity.HasOne(d => d.IdSanPhamNavigation)
                    .WithMany(p => p.GioHang)
                    .HasForeignKey(d => d.IdSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GioHang_IdSanPham");

                entity.HasOne(d => d.IdTaiKhoanNavigation)
                    .WithMany(p => p.GioHang)
                    .HasForeignKey(d => d.IdTaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GioHang_IdTaiKhoan");
            });

            modelBuilder.Entity<GoiQuangCao>(entity =>
            {
                entity.HasIndex(e => e.MaGoiQuangCao)
                    .HasName("UQ__GoiQuang__7CE51DE355E815B2")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaGoiQuangCao)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ViTri).HasMaxLength(100);
            });

            modelBuilder.Entity<HoaHong>(entity =>
            {
                entity.HasIndex(e => e.MaHoaHong)
                    .HasName("UQ__HoaHong__E2AD02ECC9A44AB2")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaHoaHong)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            });

            modelBuilder.Entity<HopDong>(entity =>
            {
                entity.HasIndex(e => e.MaHopDong)
                    .HasName("UQ__HopDong__36DD4343153A9231")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ChuThich).HasMaxLength(500);

                entity.Property(e => e.MaHopDong)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayBatDau).HasColumnType("datetime");

                entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");

                entity.HasOne(d => d.IdNhanVienNavigation)
                    .WithMany(p => p.HopDong)
                    .HasForeignKey(d => d.IdNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HopDong_IdNhanVien");
            });

            modelBuilder.Entity<KhuyenMai>(entity =>
            {
                entity.HasIndex(e => e.MaKhuyenMai)
                    .HasName("UQ__KhuyenMa__6F56B3BC392DABE3")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaKhuyenMai)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayBatDau).HasColumnType("datetime");

                entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");

                entity.Property(e => e.NoiDung).HasMaxLength(500);

                entity.Property(e => e.TinhTrang).HasMaxLength(20);
            });

            modelBuilder.Entity<LoaiNguoiDung>(entity =>
            {
                entity.HasIndex(e => e.MaLoaiNguoiDung)
                    .HasName("UQ__LoaiNguo__8D19731852539A2E")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaLoaiNguoiDung)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenLoaiNguoiDung).HasMaxLength(20);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasIndex(e => e.MaNhanVien)
                    .HasName("UQ__NhanVien__77B2CA4644346F59")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cmnd)
                    .HasColumnName("CMND")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.DienThoai)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GioiTinh).HasMaxLength(10);

                entity.Property(e => e.MaNhanVien)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.TenNhanVien).HasMaxLength(100);

                entity.Property(e => e.TinhTrang).HasMaxLength(20);

                entity.HasOne(d => d.IdLoaiNguoiDungNavigation)
                    .WithMany(p => p.NhanVien)
                    .HasForeignKey(d => d.IdLoaiNguoiDung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NhanVien_IdLoaiNguoiDung");
            });

            modelBuilder.Entity<PhieuDat>(entity =>
            {
                entity.HasIndex(e => e.MaPhieuDat)
                    .HasName("UQ__PhieuDat__01EA0D2AAC3C52F0")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaPhieuDat)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.TinhTrang).HasMaxLength(20);

                entity.HasOne(d => d.IdKhuyenMaiNavigation)
                    .WithMany(p => p.PhieuDat)
                    .HasForeignKey(d => d.IdKhuyenMai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuDat_IdKhuyenMai");

                entity.HasOne(d => d.IdTaiKhoanNavigation)
                    .WithMany(p => p.PhieuDat)
                    .HasForeignKey(d => d.IdTaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuDat_IdTaiKhoan");
            });

            modelBuilder.Entity<PhieuGiao>(entity =>
            {
                entity.HasIndex(e => e.MaPhieuGiao)
                    .HasName("UQ__PhieuGia__9A1DFE86F9757985")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cmndgiao)
                    .IsRequired()
                    .HasColumnName("CMNDGiao")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.MaPhieuGiao)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayGiao).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.TinhTrang).HasMaxLength(20);

                entity.HasOne(d => d.IdKhuyenMaiNavigation)
                    .WithMany(p => p.PhieuGiao)
                    .HasForeignKey(d => d.IdKhuyenMai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuGiao_IdKhuyenMai");

                entity.HasOne(d => d.IdTaiKhoanNavigation)
                    .WithMany(p => p.PhieuGiao)
                    .HasForeignKey(d => d.IdTaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuGiao_IdTaiKhoan");
            });

            modelBuilder.Entity<PhieuNhap>(entity =>
            {
                entity.HasIndex(e => e.MaPhieuNhap)
                    .HasName("UQ__PhieuNha__1470EF3A3BD4E70C")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaPhieuNhap)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayNhap).HasColumnType("datetime");

                entity.Property(e => e.TinhTrang).HasMaxLength(20);

                entity.HasOne(d => d.IdNhanVienNavigation)
                    .WithMany(p => p.PhieuNhap)
                    .HasForeignKey(d => d.IdNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuNhap_IdNhanVien");

                entity.HasOne(d => d.IdTaiKhoanNavigation)
                    .WithMany(p => p.PhieuNhap)
                    .HasForeignKey(d => d.IdTaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuNhap_IdTaiKhoan");
            });

            modelBuilder.Entity<QuangCao>(entity =>
            {
                entity.HasIndex(e => e.MaQuangCao)
                    .HasName("UQ__QuangCao__9353FEC30EAFBA00")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ChuThich).HasMaxLength(500);

                entity.Property(e => e.Hinh)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.MaQuangCao)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayBatDau).HasColumnType("datetime");

                entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");

                entity.Property(e => e.TinhTrang).HasMaxLength(20);

                entity.HasOne(d => d.IdGoiQuangCaoNavigation)
                    .WithMany(p => p.QuangCao)
                    .HasForeignKey(d => d.IdGoiQuangCao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuangCao_IdGoiQuangCao");

                entity.HasOne(d => d.IdTaiKhoanNavigation)
                    .WithMany(p => p.QuangCao)
                    .HasForeignKey(d => d.IdTaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuangCao_IdTaiKhoan");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasIndex(e => e.MaSanPham)
                    .HasName("UQ__SanPham__FAC7442CC886B59C")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ChiTiet).HasMaxLength(500);

                entity.Property(e => e.Hang).HasMaxLength(50);

                entity.Property(e => e.Hinh).HasMaxLength(200);

                entity.Property(e => e.MaSanPham)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Mau).HasMaxLength(20);

                entity.Property(e => e.TenSanPham).HasMaxLength(100);

                entity.Property(e => e.TinhTrang).HasMaxLength(20);

                entity.HasOne(d => d.IdTaiKhoanNavigation)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.IdTaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SanPham_IdTaiKhoan");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasIndex(e => e.TaiKhoan1)
                    .HasName("UQ__TaiKhoan__D5B8C7F0EBB7A59E")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cmnd)
                    .HasColumnName("CMND")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DienThoai)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.TaiKhoan1)
                    .IsRequired()
                    .HasColumnName("TaiKhoan")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ten).HasMaxLength(100);

                entity.Property(e => e.TinhTrang).HasMaxLength(20);

                entity.HasOne(d => d.IdLoaiNguoiDungNavigation)
                    .WithMany(p => p.TaiKhoan)
                    .HasForeignKey(d => d.IdLoaiNguoiDung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaiKhoan_IdLoaiNguoiDung");
            });

            modelBuilder.Entity<TinhThanh>(entity =>
            {
                entity.HasIndex(e => e.MaTinhThanh)
                    .HasName("UQ__TinhThan__B8FF995FD577DCE0")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaTinhThanh)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Quan).HasMaxLength(20);

                entity.Property(e => e.TenTinhThanh).HasMaxLength(20);
            });
        }
    }
}
