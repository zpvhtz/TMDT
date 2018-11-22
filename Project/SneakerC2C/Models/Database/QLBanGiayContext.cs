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

        public virtual DbSet<ChiTietPhieuDat> ChiTietPhieuDat { get; set; }
        public virtual DbSet<ChiTietPhieuGiao> ChiTietPhieuGiao { get; set; }
        public virtual DbSet<DanhGia> DanhGia { get; set; }
        public virtual DbSet<DiaChi> DiaChi { get; set; }
        public virtual DbSet<GianHang> GianHang { get; set; }
        public virtual DbSet<GiaShip> GiaShip { get; set; }
        public virtual DbSet<GioHang> GioHang { get; set; }
        public virtual DbSet<GoiQuangCao> GoiQuangCao { get; set; }
        public virtual DbSet<HangSanPham> HangSanPham { get; set; }
        public virtual DbSet<LichSuGianHang> LichSuGianHang { get; set; }
        public virtual DbSet<LoaiNguoiDung> LoaiNguoiDung { get; set; }
        public virtual DbSet<PhieuDat> PhieuDat { get; set; }
        public virtual DbSet<PhieuGiao> PhieuGiao { get; set; }
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
<<<<<<< HEAD
                optionsBuilder.UseSqlServer("Server=.;Database=QLBanGiay;User id=sa;Password=123456;Integrated Security=True;");
=======
                optionsBuilder.UseSqlServer("Server=HEOBAYMAU-VIVOS;Database=QLBanGiay;Integrated Security=True;");
>>>>>>> 64689870f32a220672cda4fba29d1bfb09f10a83
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

            modelBuilder.Entity<GianHang>(entity =>
            {
                entity.HasIndex(e => e.MaGianHang)
                    .HasName("UQ__GianHang__1772B230827E96FC")
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
                    .HasName("UQ__GoiQuang__7CE51DE30C53D4FA")
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
                    .HasName("UQ__HangSanP__19C0DB1C93B2ABE7")
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
                    .HasName("UQ__LoaiNguo__8D197318D7CD2D13")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaLoaiNguoiDung)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenLoaiNguoiDung).HasMaxLength(20);

                entity.Property(e => e.TinhTrang).HasMaxLength(20);
            });

            modelBuilder.Entity<PhieuDat>(entity =>
            {
                entity.HasIndex(e => e.MaPhieuDat)
                    .HasName("UQ__PhieuDat__01EA0D2A269E1CF9")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaPhieuDat)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.TinhTrang).HasMaxLength(20);

                entity.HasOne(d => d.IdTaiKhoanNavigation)
                    .WithMany(p => p.PhieuDat)
                    .HasForeignKey(d => d.IdTaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuDat_IdTaiKhoan");
            });

            modelBuilder.Entity<PhieuGiao>(entity =>
            {
                entity.HasIndex(e => e.MaPhieuGiao)
                    .HasName("UQ__PhieuGia__9A1DFE86215D0F2E")
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

                entity.HasOne(d => d.IdTaiKhoanNavigation)
                    .WithMany(p => p.PhieuGiao)
                    .HasForeignKey(d => d.IdTaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuGiao_IdTaiKhoan");
            });

            modelBuilder.Entity<QuangCao>(entity =>
            {
                entity.HasIndex(e => e.MaQuangCao)
                    .HasName("UQ__QuangCao__9353FEC374145856")
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
                    .HasName("UQ__SanPham__FAC7442C82269779")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ChiTiet).HasMaxLength(500);

                entity.Property(e => e.Hinh).HasMaxLength(200);

                entity.Property(e => e.MaSanPham)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Mau).HasMaxLength(20);

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
                    .HasName("UQ__TaiKhoan__F67C8D0B081EB25D")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__TaiKhoan__A9D105349CD5D519")
                    .IsUnique();

                entity.HasIndex(e => e.TenDangNhap)
                    .HasName("UQ__TaiKhoan__55F68FC0F262B7C1")
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
                    .HasName("UQ__TinhThan__B8FF995F70792C24")
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
                    .HasName("UQ__TrangQua__399828AEF8FAD4D5")
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
                    .HasName("UQ__ViTriQua__B08B247EC55245A3")
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
