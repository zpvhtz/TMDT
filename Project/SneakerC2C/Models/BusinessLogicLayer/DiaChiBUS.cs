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

        public List<DiaChi> GetDiaChis(string taikhoan)
        {
            List<DiaChi> diachi = context.DiaChi.Where(dc => dc.IdTaiKhoanNavigation.TenDangNhap == taikhoan)
                                                .Include(dc => dc.IdTaiKhoanNavigation)
                                                .Include(dc => dc.IdTinhThanhNavigation)
                                                .ToList();
            return diachi;
        }
    }
}
