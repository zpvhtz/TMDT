using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Database
{
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietPhieuDat = new HashSet<ChiTietPhieuDat>();
            ChiTietPhieuGiao = new HashSet<ChiTietPhieuGiao>();
            SizeSanPham = new HashSet<SizeSanPham>();
        }

        public Guid Id { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public Guid IdTaiKhoan { get; set; }
        public string Mau { get; set; }
        public Guid IdHangSanPham { get; set; }
        public string PhanLoai { get; set; }
        [Required(ErrorMessage ="Xin hãy nhập giá")]
        [Range(0.01,100000000,ErrorMessage ="Gía phải nằm trong khoảng 0,01 VND đến 100 triệu VND")]
        public double? Gia { get; set; }
        public string Hinh { get; set; }
        public string ChiTiet { get; set; }
        [Range(1,100,ErrorMessage ="Giảm giá phải nằm trong khoảng 1 đên 100%")]
        public double? GiamGia { get; set; }
        public DateTime? NgayDang { get; set; }
        public string TinhTrang { get; set; }

        public HangSanPham IdHangSanPhamNavigation { get; set; }
        public TaiKhoan IdTaiKhoanNavigation { get; set; }
        public ICollection<ChiTietPhieuDat> ChiTietPhieuDat { get; set; }
        public ICollection<ChiTietPhieuGiao> ChiTietPhieuGiao { get; set; }
        public ICollection<SizeSanPham> SizeSanPham { get; set; }
    }
}
