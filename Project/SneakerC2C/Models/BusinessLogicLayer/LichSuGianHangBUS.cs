using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.BusinessLogicLayer
{
    public class LichSuGianHangBUS
    {
        private readonly QLBanGiayContext context;

        public LichSuGianHangBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public LichSuGianHangBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public List<LichSuGianHang> GetLichSuGianHangs()
        {
            List<LichSuGianHang> list = context.LichSuGianHang.OrderByDescending(gh => gh.NgayDangKy)
                                                              .Include(gh => gh.IdTaiKhoanNavigation)
                                                              .Include(gh => gh.IdGianHangNavigation)
                                                              .ToList();
            return list;
        }

        public List<LichSuGianHang> GetLichSuGianHangs(string tendangnhap)
        {
            List<LichSuGianHang> list = context.LichSuGianHang.Where(gh => gh.IdTaiKhoanNavigation.TenDangNhap == tendangnhap)
                                                              .OrderByDescending(gh => gh.NgayDangKy)
                                                              .Include(gh => gh.IdTaiKhoanNavigation)
                                                              .Include(gh => gh.IdGianHangNavigation)
                                                              .ToList();
            return list;
        }

        public List<LichSuGianHang> GetLichSuGianHangs(int pagenumber, int pagesize)
        {
            List<LichSuGianHang> list = context.LichSuGianHang.OrderBy(gh => gh.Id)
                                                              .Skip((pagenumber - 1) * pagesize)
                                                              .Take(pagesize)
                                                              .Include(gh => gh.IdTaiKhoanNavigation)
                                                              .Include(gh => gh.IdGianHangNavigation)
                                                              .ToList();
            return list;
        }
    }
}
