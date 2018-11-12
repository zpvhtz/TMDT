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

        public List<LoaiNguoiDung> GetLoaiNguoiDungs(int pagenumber, int pagesize)
        {
            List<LoaiNguoiDung> list = context.LoaiNguoiDung
                                                  .OrderBy(temp => temp.TenLoaiNguoiDung)
                                                  .Skip((pagenumber - 1) * pagesize)
                                                  .Take(pagesize)
                                                  .ToList();
            return list;
        }

        //------------------------------------------------------ THEM SUA XOA -----------------------------------------------------------------
        public string CreateLoaiNguoiDung(string MaLoaiNguoiDung, string TenLoaiNguoiDung)
        {

            LoaiNguoiDung loainguoidung = new LoaiNguoiDung();

            //----------------------- chuan hoa du lieu ----------------------- 
            //----------------------- kiem tra ma -----------------------
            loainguoidung = context.LoaiNguoiDung.Where(temp => temp.MaLoaiNguoiDung == MaLoaiNguoiDung).SingleOrDefault();
            if (loainguoidung != null)
            {
                return "Mã loại người dùng này đã tồn tại";
            }
            //----------------------- kiem tra ten -----------------------
            loainguoidung = context.LoaiNguoiDung.Where(temp => temp.TenLoaiNguoiDung == TenLoaiNguoiDung).SingleOrDefault();
            if (loainguoidung != null)
            {
                return "Tên loại người dùng này đã tồn tại";
            }
            //----------------------- them -----------------------
            loainguoidung = new LoaiNguoiDung();
            loainguoidung.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            loainguoidung.MaLoaiNguoiDung = MaLoaiNguoiDung;
            loainguoidung.TenLoaiNguoiDung = TenLoaiNguoiDung;
            loainguoidung.TinhTrang = "Không khoá";

            context.LoaiNguoiDung.Add(loainguoidung);
            context.SaveChanges();

            return "Thêm thành công";
        }
        public string EditLoaiNguoiDung(string MaLoaiNguoiDung, string TenLoaiNguoiDung)
        {
            LoaiNguoiDung loainguoidung = new LoaiNguoiDung();

            //----------------------- chuan hoa du lieu ----------------------- 
            //----------------------- kiem tra ma -----------------------
            loainguoidung = context.LoaiNguoiDung.Where(temp => temp.MaLoaiNguoiDung == MaLoaiNguoiDung).SingleOrDefault();
            //if (loainguoidung != null)
            //{
            //    return "Mã loại người dùng này đã tồn tại";
            //}
            //----------------------- kiem tra ten -----------------------
            loainguoidung = context.LoaiNguoiDung.Where(temp => temp.TenLoaiNguoiDung == TenLoaiNguoiDung).SingleOrDefault();
            if (loainguoidung != null)
            {
                return "Tên loại người dùng này đã tồn tại";
            }
            //----------------------- sua -----------------------
            loainguoidung = context.LoaiNguoiDung.Where(temp => temp.MaLoaiNguoiDung == MaLoaiNguoiDung).SingleOrDefault();

            if (MaLoaiNguoiDung != null)
            {
                loainguoidung.MaLoaiNguoiDung = MaLoaiNguoiDung;
            }
            if (TenLoaiNguoiDung != null)
            {
                loainguoidung.TenLoaiNguoiDung = TenLoaiNguoiDung;
            }
            context.SaveChanges();
            return "Sửa thành công";
        }

        public string LockLoaiNguoiDung(string MaLoaiNguoiDung)
        {
            LoaiNguoiDung loainguoidung = context.LoaiNguoiDung.Where(temp => temp.MaLoaiNguoiDung == MaLoaiNguoiDung).SingleOrDefault();
            loainguoidung.TinhTrang = "Khoá";
            loainguoidung.TinhTrang.Trim();
            context.SaveChanges();
            return "Khoá thành công";
        }

        public string UnlockLoaiNguoiDung(string MaLoaiNguoiDung)
        {
            LoaiNguoiDung loainguoidung = context.LoaiNguoiDung.Where(temp => temp.MaLoaiNguoiDung == MaLoaiNguoiDung).SingleOrDefault();
            loainguoidung.TinhTrang = "Không khoá";
            loainguoidung.TinhTrang.Trim();
            context.SaveChanges();
            return "Mở khoá thành công";
        }

        //------------------------------------------------------ TIM KIEM - SAP XEP -----------------------------------------------------------------

        public List<LoaiNguoiDung> Sort(string sortorder, int pagesize, int pagenumber)
        {
            List<LoaiNguoiDung> list = new List<LoaiNguoiDung>();
            switch (sortorder)
            {
                case "maloainguoidung-az":
                    {
                        list = context.LoaiNguoiDung
                                          .OrderBy(temp => temp.MaLoaiNguoiDung)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();

                        break;
                    }
                case "maloainguoidung-za":
                    {
                        list = context.LoaiNguoiDung
                                          .OrderByDescending(temp => temp.MaLoaiNguoiDung)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();

                        break;
                    }
                case "tenloainguoidung-az":
                    {
                        list = context.LoaiNguoiDung
                                          .OrderBy(temp => temp.TenLoaiNguoiDung)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                        break;
                    }
                case "tenloainguoidung-za":
                    {
                        list = context.LoaiNguoiDung
                                      .OrderByDescending(temp => temp.TenLoaiNguoiDung)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .ToList();
                    break;
                    }

            }
            return list;
        }
        public List<LoaiNguoiDung> Sort(string sortorder)
        {
            List<LoaiNguoiDung> list = new List<LoaiNguoiDung>();
            switch (sortorder)
            {
                case "maloainguoidung-az":
                    {
                        list = context.LoaiNguoiDung
                                    .OrderBy(temp => temp.MaLoaiNguoiDung)
                                    .ToList();
                        break;
                    }                  
                case "maloainguoidung-za":
                    {
                        list = context.LoaiNguoiDung
                                    .OrderByDescending(temp => temp.MaLoaiNguoiDung)
                                    .ToList();
                        break;
                    }                  
                case "tenloainguoidung-az":
                    {
                        list = context.LoaiNguoiDung
                                    .OrderByDescending(temp => temp.TenLoaiNguoiDung)
                                    .ToList();
                        break;
                    }
                case "tenloainguoidung-za":
                    {
                        list = context.LoaiNguoiDung
                                    .OrderBy(temp => temp.TenLoaiNguoiDung)
                                    .ToList();
                        break;
                    }
            }
            return list;
        }
        public List<LoaiNguoiDung> Search(string search, int pagesize, int pagenumber)
        {
            List<LoaiNguoiDung> list = new List<LoaiNguoiDung>();
            if (search == null)
            {
                list = GetLoaiNguoiDungs(1, pagesize);
            }
            else
            {
                list = context.LoaiNguoiDung.Where(temp => temp.MaLoaiNguoiDung.Contains(search) 
                                                        || temp.TenLoaiNguoiDung.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                            .Skip((pagenumber - 1) * pagesize)
                                            .Take(pagesize)
                                            .ToList();                                                        
            }
            return list;
        }

        public List<LoaiNguoiDung> Search(string search, int pagesize)
        {
            List<LoaiNguoiDung> list = new List<LoaiNguoiDung>();
            if (search == null)
            {
                list = GetLoaiNguoiDungs(1, pagesize);
            }
            else
            {
                list = context.LoaiNguoiDung.Where(temp => temp.MaLoaiNguoiDung.Contains(search)
                                                        || temp.TenLoaiNguoiDung.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                            .ToList();
            }
            return list;
        }

        public List<LoaiNguoiDung> SearchAndSort(string search, string sortorder, int pagesize, int pagenumber)
        {
            List<LoaiNguoiDung> list = new List<LoaiNguoiDung>();
            if (search == null)
            {
                list = GetLoaiNguoiDungs(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "maloainguoidung-az":
                        list = context.LoaiNguoiDung.Where(temp => temp.MaLoaiNguoiDung.Contains(search)
                                                        || temp.TenLoaiNguoiDung.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .OrderBy(temp=>temp.MaLoaiNguoiDung)
                                               .ToList();
                        break;
                    case "maloainguoidung-za":
                        list = context.LoaiNguoiDung.Where(temp => temp.MaLoaiNguoiDung.Contains(search)
                                                        || temp.TenLoaiNguoiDung.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .OrderByDescending(temp => temp.MaLoaiNguoiDung)
                                               .ToList();
                        break;
                    case "tenloainguoidung-az":
                        list = context.LoaiNguoiDung.Where(temp => temp.MaLoaiNguoiDung.Contains(search)
                                                        || temp.TenLoaiNguoiDung.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .OrderBy(temp => temp.TenLoaiNguoiDung)
                                               .ToList();
                        break;
                    case "tenloainguoidung-za":
                        list = context.LoaiNguoiDung.Where(temp => temp.MaLoaiNguoiDung.Contains(search)
                                                        || temp.TenLoaiNguoiDung.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .OrderByDescending(temp => temp.TenLoaiNguoiDung)
                                               .ToList();
                        break;
                }
            }
            return list;
        }

        public List<LoaiNguoiDung> SearchAndSort(string search, string sortorder, int pagesize)
        {
            List<LoaiNguoiDung> list = new List<LoaiNguoiDung>();
            if (search == null)
            {
                list = GetLoaiNguoiDungs(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "maloainguoidung-az":
                        list = context.LoaiNguoiDung.Where(temp => temp.MaLoaiNguoiDung.Contains(search)
                                                        || temp.TenLoaiNguoiDung.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                               .OrderBy(l => l.MaLoaiNguoiDung)
                                               .ToList();
                        break;
                    case "maloainguoidung-za":
                        list = context.LoaiNguoiDung.Where(temp => temp.MaLoaiNguoiDung.Contains(search)
                                                        || temp.TenLoaiNguoiDung.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                               .OrderByDescending(l => l.MaLoaiNguoiDung)
                                               .ToList();
                        break;
                    case "tenloainguoidung-az":
                        list = context.LoaiNguoiDung.Where(temp => temp.MaLoaiNguoiDung.Contains(search)
                                                        || temp.TenLoaiNguoiDung.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                               .OrderBy(l => l.TenLoaiNguoiDung)
                                               .ToList();
                        break;
                    case "tenloainguoidung-za":
                        list = context.LoaiNguoiDung.Where(temp => temp.MaLoaiNguoiDung.Contains(search)
                                                        || temp.TenLoaiNguoiDung.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                               .OrderByDescending(l => l.TenLoaiNguoiDung)
                                               .ToList();
                        break;
                }
            }
            return list;
        }


    }
}
