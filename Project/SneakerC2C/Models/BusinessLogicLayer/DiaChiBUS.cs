using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.BusinessLogicLayer
{
    public class DiaChiBUS
    {
        private readonly QLBanGiayContext context;

        public DiaChiBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public DiaChiBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public List<DiaChi> GetDiaChis()
        {
            List<DiaChi> diachi = context.DiaChi.Include(dc => dc.IdTaiKhoanNavigation)
                                                .Include(dc => dc.IdTinhThanhNavigation)
                                                .ToList();
            return diachi;
        }

        public List<DiaChi> GetDiaChis(string tendangnhap)
        {
            List<DiaChi> diachi = context.DiaChi.Where(dc => dc.IdTaiKhoanNavigation.TenDangNhap == tendangnhap)
                                                .Include(dc => dc.IdTaiKhoanNavigation)
                                                .Include(dc => dc.IdTinhThanhNavigation)
                                                .ToList();
            return diachi;
        }

        public DiaChi GetThongTinDiaChi(string tendangnhap, string diachi)
        {
            DiaChi dc = context.DiaChi.Where(d => d.IdTaiKhoanNavigation.TenDangNhap == tendangnhap && d.Duong == diachi)
                                      .Include(d => d.IdTaiKhoanNavigation)
                                      .Include(d => d.IdTinhThanhNavigation)
                                      .SingleOrDefault();
            return dc;
        }

        public string CreateDiaChi(string tendangnhap, string diachi, string tinhthanh)
        {
            TaiKhoan tk = context.TaiKhoan.Where(t => t.TenDangNhap == tendangnhap).SingleOrDefault();
            DiaChi dc = new DiaChi();
            dc.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            dc.IdTaiKhoan = tk.Id;
            dc.Duong = diachi;
            dc.IdTinhThanh = Guid.Parse(tinhthanh);
            dc.TinhTrang = "Không khoá";
            context.DiaChi.Add(dc);
            context.SaveChanges();
            return "Thêm thành công";
        }

        public string EditDiaChi(string id, string diachi, string tinhthanh)
        {
            DiaChi dc = context.DiaChi.Where(d => d.Id == Guid.Parse(id)).SingleOrDefault();
            if(dc.Duong == diachi && dc.IdTinhThanh.ToString() == tinhthanh)
            {
                return "Thông tin địa chỉ không thay đổi";
            }
            dc.Duong = diachi;
            dc.IdTinhThanh = Guid.Parse(tinhthanh);
            context.SaveChanges();
            return "Sửa thành công";
        }

        public string LockDiaChi(string id)
        {
            DiaChi dc = context.DiaChi.Where(d => d.Id == Guid.Parse(id)).SingleOrDefault();
            dc.TinhTrang = "Khoá";
            context.SaveChanges();
            return "Khoá thành công";
        }
    }
}
