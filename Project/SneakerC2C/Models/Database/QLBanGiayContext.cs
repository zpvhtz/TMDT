using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Models.Database
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

        public virtual DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual DbSet<DanhGia> DanhGia { get; set; }
        public virtual DbSet<DiaChi> DiaChi { get; set; }
        public virtual DbSet<DonHang> DonHang { get; set; }
        public virtual DbSet<GianHang> GianHang { get; set; }
        public virtual DbSet<GiaShip> GiaShip { get; set; }
        public virtual DbSet<GioHang> GioHang { get; set; }
        public virtual DbSet<GoiQuangCao> GoiQuangCao { get; set; }
        public virtual DbSet<HangSanPham> HangSanPham { get; set; }
        public virtual DbSet<LichSuGianHang> LichSuGianHang { get; set; }
        public virtual DbSet<LoaiNguoiDung> LoaiNguoiDung { get; set; }
        public virtual DbSet<QuangCao> QuangCao { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<SizeSanPham> SizeSanPham { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public virtual DbSet<TinhThanh> TinhThanh { get; set; }
        public virtual DbSet<TrangQuangCao> TrangQuangCao { get; set; }
        public virtual DbSet<ViTriQuangcao> ViTriQuangcao { get; set; }

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
            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.HasKey(e => new { e.IdDonHang, e.IdSizeSanPham });

                entity.HasOne(d => d.IdDonHangNavigation)
                    .WithMany(p => p.ChiTietDonHang)
                    .HasForeignKey(d => d.IdDonHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietDonHang_IdDonHang");

                entity.HasOne(d => d.IdSizeSanPhamNavigation)
                    .WithMany(p => p.ChiTietDonHang)
                    .HasForeignKey(d => d.IdSizeSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietDonHang_IdSizeSanPham");
            });

            modelBuilder.Entity<DanhGia>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdTaiKhoanDanhGiaNavigation)
                    .WithMany(p => p.DanhGiaIdTaiKhoanDanhGiaNavigation)
                    .HasForeignKey(d => d.IdTaiKhoanDanhGia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DanhGia_IdTaiKhoanDanhGia");

                entity.HasOne(d => d.IdTaiKhoanDuocDanhGiaNavigation)
                    .WithMany(p => p.DanhGiaIdTaiKhoanDuocDanhGiaNavigation)
                    .HasForeignKey(d => d.IdTaiKhoanDuocDanhGia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DanhGia_IdTaiKhoanDuocDanhGia");
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

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasIndex(e => e.MaDonHang)
                    .HasName("UQ__DonHang__129584ACD17564B8")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CmndnguoiGiao)
                    .HasColumnName("CMNDNguoiGiao")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DiaChiGiao).HasMaxLength(200);

                entity.Property(e => e.MaDonHang)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayGiao).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.TinhTrang).HasMaxLength(20);

                entity.Property(e => e.TinhTrangDanhGia).HasMaxLength(20);

                entity.HasOne(d => d.IdTaiKhoanNavigation)
                    .WithMany(p => p.DonHang)
                    .HasForeignKey(d => d.IdTaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DonHang_IdTaiKhoan");
            });

            modelBuilder.Entity<GianHang>(entity =>
            {
                entity.HasIndex(e => e.MaGianHang)
                    .HasName("UQ__GianHang__1772B230B2CA6801")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaGianHang)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenGianHang).HasMaxLength(100);

                entity.Property(e => e.TinhTrang).HasMaxLength(20);
            });

            modelBuilder.Entity<GiaShip>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Loai).HasMaxLength(20);

                entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");
            });

            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.HasKey(e => new { e.IdTaiKhoan, e.IdSizeSanPham });

                entity.Property(e => e.TinhTrang).HasMaxLength(20);

                entity.HasOne(d => d.IdSizeSanPhamNavigation)
                    .WithMany(p => p.GioHang)
                    .HasForeignKey(d => d.IdSizeSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GioHang_IdSizeSanPham");

                entity.HasOne(d => d.IdTaiKhoanNavigation)
                    .WithMany(p => p.GioHang)
                    .HasForeignKey(d => d.IdTaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GioHang_IdTaiKhoan");
            });

            modelBuilder.Entity<GoiQuangCao>(entity =>
            {
                entity.HasIndex(e => e.MaGoiQuangCao)
                    .HasName("UQ__GoiQuang__7CE51DE3A6DA89EB")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaGoiQuangCao)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TinhTrang).HasMaxLength(20);

                entity.HasOne(d => d.IdViTriNavigation)
                    .WithMany(p => p.GoiQuangCao)
                    .HasForeignKey(d => d.IdViTri)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GoiQuangCao_ViTriQuangCao");
            });

            modelBuilder.Entity<HangSanPham>(entity =>
            {
                entity.HasIndex(e => e.MaHang)
                    .HasName("UQ__HangSanP__19C0DB1CC7293467")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaHang)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenHang).HasMaxLength(100);

                entity.Property(e => e.TinhTrang).HasMaxLength(20);
            });

            modelBuilder.Entity<LichSuGianHang>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NgayBatDau).HasColumnType("datetime");

                entity.Property(e => e.NgayDangKy).HasColumnType("datetime");

                entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");

                entity.Property(e => e.TinhTrang).HasMaxLength(20);

                entity.HasOne(d => d.IdGianHangNavigation)
                    .WithMany(p => p.LichSuGianHang)
                    .HasForeignKey(d => d.IdGianHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LichSuGianHang_IdGianHang");

                entity.HasOne(d => d.IdTaiKhoanNavigation)
                    .WithMany(p => p.LichSuGianHang)
                    .HasForeignKey(d => d.IdTaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LichSuGianHang_IdTaiKhoan");
            });

            modelBuilder.Entity<LoaiNguoiDung>(entity =>
            {
                entity.HasIndex(e => e.MaLoaiNguoiDung)
                    .HasName("UQ__LoaiNguo__8D1973182995BEDB")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaLoaiNguoiDung)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenLoaiNguoiDung).HasMaxLength(20);

                entity.Property(e => e.TinhTrang).HasMaxLength(20);
            });

            modelBuilder.Entity<QuangCao>(entity =>
            {
                entity.HasIndex(e => e.MaQuangCao)
                    .HasName("UQ__QuangCao__9353FEC3FEAF1560")
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
                    .HasName("UQ__SanPham__FAC7442C71CDB712")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ChiTiet).HasMaxLength(500);

                entity.Property(e => e.Hinh).HasMaxLength(200);

                entity.Property(e => e.MaSanPham)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Mau).HasMaxLength(20);

                entity.Property(e => e.NgayDang).HasColumnType("datetime");

                entity.Property(e => e.PhanLoai).HasMaxLength(10);

                entity.Property(e => e.TenSanPham).HasMaxLength(100);

                entity.Property(e => e.TinhTrang).HasMaxLength(20);

                entity.HasOne(d => d.IdHangSanPhamNavigation)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.IdHangSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SanPham_IdHangSanPham");

                entity.HasOne(d => d.IdTaiKhoanNavigation)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.IdTaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SanPham_IdTaiKhoan");
            });

            modelBuilder.Entity<SizeSanPham>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TinhTrang).HasMaxLength(20);

                entity.HasOne(d => d.IdSanPhamNavigation)
                    .WithMany(p => p.SizeSanPham)
                    .HasForeignKey(d => d.IdSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SizeSanPham_IdSanPham");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasIndex(e => e.Cmnd)
                    .HasName("UQ__TaiKhoan__F67C8D0B747391C1")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__TaiKhoan__A9D1053417A7EC1A")
                    .IsUnique();

                entity.HasIndex(e => e.TenDangNhap)
                    .HasName("UQ__TaiKhoan__55F68FC0B0A80882")
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
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.Ten).HasMaxLength(100);

                entity.Property(e => e.TenDangNhap)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TenShop).HasMaxLength(100);

                entity.Property(e => e.ThoiHanGianHang).HasColumnType("datetime");

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
                    .HasName("UQ__TinhThan__B8FF995F72277AB2")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaTinhThanh)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenTinhThanh).HasMaxLength(20);

                entity.Property(e => e.TinhTrang).HasMaxLength(20);
            });

            modelBuilder.Entity<TrangQuangCao>(entity =>
            {
                entity.HasIndex(e => e.MaTrang)
                    .HasName("UQ__TrangQua__399828AE181D162F")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ChuThich).HasMaxLength(100);

                entity.Property(e => e.MaTrang)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenTrang).HasMaxLength(100);

                entity.Property(e => e.TinhTrang).HasMaxLength(20);
            });

            modelBuilder.Entity<ViTriQuangcao>(entity =>
            {
                entity.HasIndex(e => e.MaViTri)
                    .HasName("UQ__ViTriQua__B08B247E9E908140")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ChuThich).HasMaxLength(100);

                entity.Property(e => e.MaViTri)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenViTri).HasMaxLength(100);

                entity.Property(e => e.TinhTrang).HasMaxLength(20);

                entity.HasOne(d => d.IdTrangNavigation)
                    .WithMany(p => p.ViTriQuangcao)
                    .HasForeignKey(d => d.IdTrang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ViTriQuangCao_TrangQuangCao");
            });
        }
    }
}
