using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    class HoaDonMerView
    {
        public Guid Id { get; set; }
        public string MaDonHang { get; set; }
        public string TenSanPham { get; set; }
        public string SoLuong { get; set; }
        public string TenMer { get; set; }
        public string TenKH { get; set; }
        public double? TongTien { get; set; }
        public string TinhTrang { get; set; }
    }
}
