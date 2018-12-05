using Microsoft.EntityFrameworkCore;
using Models.Database;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BusinessLogicLayer
{
    public class HomeBUS
    {
        private readonly QLBanGiayContext context;

        public HomeBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public HomeBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public List<DoanhThuMerchant> GetDoanhThuMerchants(DateTime nbd, DateTime nkt)
        {
            var list = from pg in context.PhieuGiao
                       join tk in context.TaiKhoan
                       on pg.IdTaiKhoan equals tk.Id
                       group new { pg, tk } by new { /*tk.TenDangNhap,*/ pg.NgayGiao.Value.Month, pg.NgayGiao.Value.Year } into khoaocschos
                       select new DoanhThuMerchant
                       {
                           //TenDangNhap = khoaocschos.Key.TenDangNhap,
                           Thang = khoaocschos.Key.Month,
                           Nam = khoaocschos.Key.Year,
                           SoLuong = khoaocschos.Select(k => k.pg.Id).Distinct().Count(),
                           ThuNhap = (double)khoaocschos.Sum(k => k.pg.TongTien)
                       };
            List<DoanhThuMerchant> listkhoa = list.ToList();

            return listkhoa;

        }
    }
}
