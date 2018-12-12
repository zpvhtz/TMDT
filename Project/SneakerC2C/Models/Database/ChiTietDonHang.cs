﻿using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class ChiTietDonHang
    {
        public Guid IdDonHang { get; set; }
        public Guid IdSizeSanPham { get; set; }
        public DateTime? NgayGiao { get; set; }
        public int? SoLuong { get; set; }
        public double? DonGia { get; set; }
        public double? DiemCustomerDanhGia { get; set; }
        public double? DiemMerchantDanhGia { get; set; }
        public string TinhTrangChiTiet { get; set; }

        public DonHang IdDonHangNavigation { get; set; }
        public SizeSanPham IdSizeSanPhamNavigation { get; set; }
    }
}
