using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models.Database;
using System.Text;
using PagedList;

namespace Models.BusinessLogicLayer
{
    public class LoaiNguoiDungBUS
    {
        QLBanGiayContext db = null;

        public LoaiNguoiDungBUS()
        {
            db = new QLBanGiayContext();
        }
        public LoaiNguoiDung GetByID(string MaLoaiNguoiDung)
        {
            return db.LoaiNguoiDung.SingleOrDefault(x => x.MaLoaiNguoiDung == MaLoaiNguoiDung);
        }

        public List<LoaiNguoiDung> GetAll()
        {
            return db.LoaiNguoiDung.ToList();
        }

        public LoaiNguoiDung ViewDetail(string MaLoaiNguoiDung)
        {
            return db.LoaiNguoiDung.Find(MaLoaiNguoiDung);
        }

        public IEnumerable<LoaiNguoiDung> listAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<LoaiNguoiDung> model = db.LoaiNguoiDung;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenLoaiNguoiDung.Contains(searchString));
            }
            return model.OrderBy(x => x.TenLoaiNguoiDung).ToPagedList(page, pageSize);
        }

        public string Insert(LoaiNguoiDung entity)
        {
            db.LoaiNguoiDung.Add(entity);
            db.SaveChanges();
            return entity.MaLoaiNguoiDung;
        }

        public bool Update(LoaiNguoiDung entity)
        {
            try
            {
                var loai = db.LoaiNguoiDung.Where(g => g.MaLoaiNguoiDung == entity.MaLoaiNguoiDung).SingleOrDefault();
                loai.MaLoaiNguoiDung = entity.MaLoaiNguoiDung;
                loai.TenLoaiNguoiDung = entity.TenLoaiNguoiDung;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(string MaLoaiNguoiDung)
        {
               var temp = db.LoaiNguoiDung.Find(MaLoaiNguoiDung);
               string status = temp.TinhTrang;
               if (status == "Khóa")
               {
                   status = "Không Khóa";
                   temp.TinhTrang = status;
                   db.SaveChanges();
                   return true;
               }
               else
               {
                   if (status == "Không Khóa")
                   {
                       status = "Khóa";
                      temp.TinhTrang = status;
                       db.SaveChanges();
                       return true;
                   }
               }
               return false;
               
        }


    }
}
