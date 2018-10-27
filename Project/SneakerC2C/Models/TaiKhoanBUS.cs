using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class TaiKhoanBUS
    {
        private readonly QLBanGiayContext context;

        public TaiKhoanBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public TaiKhoanBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public List<TaiKhoan> GetTaiKhoans()
        {
            List<TaiKhoan> list = context.TaiKhoan.OrderBy(l => l.TenDangNhap).ToList();
            return list;
        }
    }
}
