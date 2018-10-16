﻿using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietPhieuDat = new HashSet<ChiTietPhieuDat>();
            ChiTietPhieuGiao = new HashSet<ChiTietPhieuGiao>();
            ChiTietPhieuNhap = new HashSet<ChiTietPhieuNhap>();
            GioHang = new HashSet<GioHang>();
        }

        public Guid Id { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public Guid IdTaiKhoan { get; set; }
        public int? Size { get; set; }
        public string Mau { get; set; }
        public string Hang { get; set; }
        public double? Gia { get; set; }
        public int? SoLuong { get; set; }
        public string Hinh { get; set; }
        public string ChiTiet { get; set; }
        public double? GiamGia { get; set; }
        public string TinhTrang { get; set; }

        public TaiKhoan IdTaiKhoanNavigation { get; set; }
        public ICollection<ChiTietPhieuDat> ChiTietPhieuDat { get; set; }
        public ICollection<ChiTietPhieuGiao> ChiTietPhieuGiao { get; set; }
        public ICollection<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }
        public ICollection<GioHang> GioHang { get; set; }
    }
}
