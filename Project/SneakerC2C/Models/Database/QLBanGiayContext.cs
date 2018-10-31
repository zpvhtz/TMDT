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
        public virtual DbSet<KhuyenMai> KhuyenMai { get; set; }
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
                    .HasName("UQ__GianHang__1772B2306D790020")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaGianHang)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenGianHang).HasMaxLength(100);
            });

            modelBuilder.Entity<GiaShip>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Loai).HasMaxLength(20);

                entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");
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
                    .HasName("UQ__GoiQuang__7CE51DE331B88CAA")
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
                    .HasName("UQ__HangSanP__19C0DB1C12DE9E0B")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaHang)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenHang).HasMaxLength(100);

                entity.Property(e => e.TinhTrang).HasMaxLength(20);
            });

            modelBuilder.Entity<KhuyenMai>(entity =>
            {
                entity.HasIndex(e => e.MaKhuyenMai)
                    .HasName("UQ__KhuyenMa__6F56B3BCD3DB31D7")
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

            modelBuilder.Entity<LichSuGianHang>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NgayDangKy).HasColumnType("datetime");

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
                    .HasName("UQ__LoaiNguo__8D197318862BD154")
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
                    .HasName("UQ__PhieuDat__01EA0D2AE26B7357")
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
                    .HasName("UQ__PhieuGia__9A1DFE86E69CB1E6")
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

            modelBuilder.Entity<QuangCao>(entity =>
            {
                entity.HasIndex(e => e.MaQuangCao)
                    .HasName("UQ__QuangCao__9353FEC3D5F52EF4")
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
                    .HasName("UQ__SanPham__FAC7442CEFEC5C67")
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
                    .HasName("UQ__TaiKhoan__F67C8D0B51612957")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__TaiKhoan__A9D10534FE5CCB28")
                    .IsUnique();

                entity.HasIndex(e => e.TenDangNhap)
                    .HasName("UQ__TaiKhoan__55F68FC05B4C4218")
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
                    .HasName("UQ__TinhThan__B8FF995FA22A9617")
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
                    .HasName("UQ__TrangQua__399828AEAD8578CE")
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
                    .HasName("UQ__ViTriQua__B08B247E9247D7CE")
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
