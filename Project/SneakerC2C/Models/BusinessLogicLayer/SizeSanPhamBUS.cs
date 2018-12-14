using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.BusinessLogicLayer
{
    public class SizeSanPhamBUS
    {
        private readonly QLBanGiayContext context;

        public SizeSanPhamBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public SizeSanPhamBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public List<SizeSanPham> GetSize(string id)
        {
            List<SizeSanPham> list = context.SizeSanPham.Where(s => s.IdSanPhamNavigation.Id == Guid.Parse(id))
                                                        .Include(s => s.IdSanPhamNavigation)
                                                        .OrderByDescending(s => s.Size)
                                                        .ToList();
            return list;
        }

        public int GetSoLuong(string id)
        {
            SizeSanPham sizesanpham = context.SizeSanPham.Where(s => s.Id == Guid.Parse(id)).SingleOrDefault();
            return sizesanpham.SoLuong ?? 0;
        }
    }
}
