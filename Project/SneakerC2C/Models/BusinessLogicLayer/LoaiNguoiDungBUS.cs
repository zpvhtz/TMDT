using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.BusinessLogicLayer
{
    public class LoaiNguoiDungBUS
    {
        private readonly QLBanGiayContext context;
        public LoaiNguoiDungBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public LoaiNguoiDungBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public List<LoaiNguoiDung> GetLoaiNguoiDungs()
        {
            List<LoaiNguoiDung> list = context.LoaiNguoiDung.ToList();
            return list;
        }

        public List<LoaiNguoiDung> GetTaiKhoans(int pagenumber, int pagesize)
        {
            List<LoaiNguoiDung> list = context.LoaiNguoiDung
                                                  .OrderBy(l => l.TenLoaiNguoiDung)
                                                  .Skip((pagenumber - 1) * pagesize)
                                                  .Take(pagesize)
                                                  .Include(l => l.TenLoaiNguoiDung)
                                                  .ToList();
            return list;
        }



        //------------------------------------------------------ THEM SUA XOA -----------------------------------------------------------------

        public string Edit(string MaLoaiNguoiDung, string TenLoaiNguoiDung, string TinhTrang)
        {
            LoaiNguoiDung loainguoidung = context.LoaiNguoiDung.Where(temp => temp.TenLoaiNguoiDung == TenLoaiNguoiDung).SingleOrDefault();

            if (MaLoaiNguoiDung != null)
            {
                loainguoidung.MaLoaiNguoiDung = MaLoaiNguoiDung;
            }
            if (TenLoaiNguoiDung != null)
            {
                loainguoidung.TenLoaiNguoiDung = TenLoaiNguoiDung;
            }
            if (TinhTrang != null)
            {
                loainguoidung.TinhTrang = TinhTrang;
            }
            context.SaveChanges();
            return "Sửa thành công";
        }

        public string Lock(string MaLoaiNguoiDung)
        {
            LoaiNguoiDung loainguoidung = context.LoaiNguoiDung.Where(temp => temp.MaLoaiNguoiDung == MaLoaiNguoiDung).SingleOrDefault();
            loainguoidung.TinhTrang = "Khoá";
            context.SaveChanges();
            return "Khoá thành công";
        }

        public string Unlock(string MaLoaiNguoiDung)
        {
            LoaiNguoiDung loainguoidung = context.LoaiNguoiDung.Where(temp => temp.MaLoaiNguoiDung == MaLoaiNguoiDung).SingleOrDefault();
            loainguoidung.TinhTrang = "Không khoá";
            context.SaveChanges();
            return "Mở khoá thành công";
        }

    }
}
