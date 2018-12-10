using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.BusinessLogicLayer
{
    public class ReportBUS
    {
        private readonly QLBanGiayContext context;

        public ReportBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public ReportBUS(QLBanGiayContext context)
        {
            this.context = context;
        }
       
        public DonHang GetDonHang(string Id)
        {
            return context.DonHang.Where(x => x.Id == Guid.Parse(Id))
                                        .Include(x => x.IdTaiKhoanNavigation)
                                        .SingleOrDefault();          
        }
        public List<ChiTietDonHang> GetChiTietDonHang(string Id)
        {
            return context.ChiTietDonHang.Where(x => x.IdDonHang == Guid.Parse(Id))                                                            
                                        .Include(dh => dh.IdDonHangNavigation)
                                        .Include(dh => dh.IdDonHangNavigation.IdTaiKhoanNavigation)
                                        .Include(dh => dh.IdSizeSanPhamNavigation)
                                        .Include(dh => dh.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                        .Include(dh => dh.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                        .OrderBy(dh => dh.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation.TenShop)
                                        .ToList();
        }
    }
}
