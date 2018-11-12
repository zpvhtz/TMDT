using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.BusinessLogicLayer
{
    public class TinhThanhBUS
    {
        private readonly QLBanGiayContext context;
        public TinhThanhBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public TinhThanhBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public List<TinhThanh> GetTinhThanhs()
        {
            List<TinhThanh> list = context.TinhThanh.ToList();
            return list;
        }

        public List<TinhThanh> GetTinhThanhs(int pagenumber, int pagesize)
        {
            List<TinhThanh> list = context.TinhThanh
                                                  .OrderBy(temp => temp.TenTinhThanh)
                                                  .Skip((pagenumber - 1) * pagesize)
                                                  .Take(pagesize)
                                                  .ToList();
            return list;
        }

        //------------------------------------------------------ THEM SUA XOA -----------------------------------------------------------------
        public string CreateTinhThanh(string MaTinhThanh, string TenTinhThanh)
        {

            TinhThanh TinhThanh = new TinhThanh();

            //----------------------- chuan hoa du lieu ----------------------- 
            //----------------------- kiem tra ma -----------------------
            TinhThanh = context.TinhThanh.Where(temp => temp.MaTinhThanh == MaTinhThanh).SingleOrDefault();
            if (TinhThanh != null)
            {
                return "Mã tỉnh thành này đã tồn tại";
            }
            //----------------------- kiem tra ten -----------------------
            TinhThanh = context.TinhThanh.Where(temp => temp.TenTinhThanh == TenTinhThanh).SingleOrDefault();
            if (TinhThanh != null)
            {
                return "Tên tỉnh thành này đã tồn tại";
            }
            //----------------------- them -----------------------
            TinhThanh = new TinhThanh();
            TinhThanh.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            TinhThanh.MaTinhThanh = MaTinhThanh;
            TinhThanh.TenTinhThanh = TenTinhThanh;
            TinhThanh.TinhTrang = "Không khoá";

            context.TinhThanh.Add(TinhThanh);
            context.SaveChanges();

            return "Thêm thành công";
        }
        public string EditTinhThanh(string MaTinhThanh, string TenTinhThanh)
        {
            TinhThanh TinhThanh = new TinhThanh();

            //----------------------- chuan hoa du lieu ----------------------- 
            //----------------------- kiem tra ma -----------------------
            TinhThanh = context.TinhThanh.Where(temp => temp.MaTinhThanh == MaTinhThanh).SingleOrDefault();
            //if (TinhThanh != null)
            //{
            //    return "Mã tỉnh thành này đã tồn tại";
            //}
            //----------------------- kiem tra ten -----------------------
            TinhThanh = context.TinhThanh.Where(temp => temp.TenTinhThanh == TenTinhThanh).SingleOrDefault();
            if (TinhThanh != null)
            {
                return "Tên tỉnh thành này đã tồn tại";
            }
            //----------------------- sua -----------------------
            TinhThanh = context.TinhThanh.Where(temp => temp.MaTinhThanh == MaTinhThanh).SingleOrDefault();

            if (MaTinhThanh != null)
            {
                TinhThanh.MaTinhThanh = MaTinhThanh;
            }
            if (TenTinhThanh != null)
            {
                TinhThanh.TenTinhThanh = TenTinhThanh;
            }
            context.SaveChanges();
            return "Sửa thành công";
        }

        public string LockTinhThanh(string MaTinhThanh)
        {
            TinhThanh TinhThanh = context.TinhThanh.Where(temp => temp.MaTinhThanh == MaTinhThanh).SingleOrDefault();
            TinhThanh.TinhTrang = "Khoá";
            TinhThanh.TinhTrang.Trim();
            context.SaveChanges();
            return "Khoá thành công";
        }

        public string UnlockTinhThanh(string MaTinhThanh)
        {
            TinhThanh TinhThanh = context.TinhThanh.Where(temp => temp.MaTinhThanh == MaTinhThanh).SingleOrDefault();
            TinhThanh.TinhTrang = "Không khoá";
            TinhThanh.TinhTrang.Trim();
            context.SaveChanges();
            return "Mở khoá thành công";
        }

        //------------------------------------------------------ TIM KIEM - SAP XEP -----------------------------------------------------------------

        public List<TinhThanh> Sort(string sortorder, int pagesize, int pagenumber)
        {
            List<TinhThanh> list = new List<TinhThanh>();
            switch (sortorder)
            {
                case "maTinhThanh-az":
                    {
                        list = context.TinhThanh
                                          .OrderBy(temp => temp.MaTinhThanh)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();

                        break;
                    }
                case "maTinhThanh-za":
                    {
                        list = context.TinhThanh
                                          .OrderByDescending(temp => temp.MaTinhThanh)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();

                        break;
                    }
                case "tenTinhThanh-az":
                    {
                        list = context.TinhThanh
                                          .OrderBy(temp => temp.TenTinhThanh)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                        break;
                    }
                case "tenTinhThanh-za":
                    {
                        list = context.TinhThanh
                                      .OrderByDescending(temp => temp.TenTinhThanh)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .ToList();
                        break;
                    }

            }
            return list;
        }
        public List<TinhThanh> Sort(string sortorder)
        {
            List<TinhThanh> list = new List<TinhThanh>();
            switch (sortorder)
            {
                case "maTinhThanh-az":
                    {
                        list = context.TinhThanh
                                    .OrderBy(temp => temp.MaTinhThanh)
                                    .ToList();
                        break;
                    }
                case "maTinhThanh-za":
                    {
                        list = context.TinhThanh
                                    .OrderByDescending(temp => temp.MaTinhThanh)
                                    .ToList();
                        break;
                    }
                case "tenTinhThanh-az":
                    {
                        list = context.TinhThanh
                                    .OrderByDescending(temp => temp.TenTinhThanh)
                                    .ToList();
                        break;
                    }
                case "tenTinhThanh-za":
                    {
                        list = context.TinhThanh
                                    .OrderBy(temp => temp.TenTinhThanh)
                                    .ToList();
                        break;
                    }
            }
            return list;
        }
        public List<TinhThanh> Search(string search, int pagesize, int pagenumber)
        {
            List<TinhThanh> list = new List<TinhThanh>();
            if (search == null)
            {
                list = GetTinhThanhs(1, pagesize);
            }
            else
            {
                list = context.TinhThanh.Where(temp => temp.MaTinhThanh.Contains(search)
                                                        || temp.TenTinhThanh.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                            .Skip((pagenumber - 1) * pagesize)
                                            .Take(pagesize)
                                            .ToList();
            }
            return list;
        }

        public List<TinhThanh> Search(string search, int pagesize)
        {
            List<TinhThanh> list = new List<TinhThanh>();
            if (search == null)
            {
                list = GetTinhThanhs(1, pagesize);
            }
            else
            {
                list = context.TinhThanh.Where(temp => temp.MaTinhThanh.Contains(search)
                                                        || temp.TenTinhThanh.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                            .ToList();
            }
            return list;
        }

        public List<TinhThanh> SearchAndSort(string search, string sortorder, int pagesize, int pagenumber)
        {
            List<TinhThanh> list = new List<TinhThanh>();
            if (search == null)
            {
                list = GetTinhThanhs(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "maTinhThanh-az":
                        list = context.TinhThanh.Where(temp => temp.MaTinhThanh.Contains(search)
                                                        || temp.TenTinhThanh.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .OrderBy(temp => temp.MaTinhThanh)
                                               .ToList();
                        break;
                    case "maTinhThanh-za":
                        list = context.TinhThanh.Where(temp => temp.MaTinhThanh.Contains(search)
                                                        || temp.TenTinhThanh.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .OrderByDescending(temp => temp.MaTinhThanh)
                                               .ToList();
                        break;
                    case "tenTinhThanh-az":
                        list = context.TinhThanh.Where(temp => temp.MaTinhThanh.Contains(search)
                                                        || temp.TenTinhThanh.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .OrderBy(temp => temp.TenTinhThanh)
                                               .ToList();
                        break;
                    case "tenTinhThanh-za":
                        list = context.TinhThanh.Where(temp => temp.MaTinhThanh.Contains(search)
                                                        || temp.TenTinhThanh.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .OrderByDescending(temp => temp.TenTinhThanh)
                                               .ToList();
                        break;
                }
            }
            return list;
        }

        public List<TinhThanh> SearchAndSort(string search, string sortorder, int pagesize)
        {
            List<TinhThanh> list = new List<TinhThanh>();
            if (search == null)
            {
                list = GetTinhThanhs(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "maTinhThanh-az":
                        list = context.TinhThanh.Where(temp => temp.MaTinhThanh.Contains(search)
                                                        || temp.TenTinhThanh.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                               .OrderBy(l => l.MaTinhThanh)
                                               .ToList();
                        break;
                    case "maTinhThanh-za":
                        list = context.TinhThanh.Where(temp => temp.MaTinhThanh.Contains(search)
                                                        || temp.TenTinhThanh.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                               .OrderByDescending(l => l.MaTinhThanh)
                                               .ToList();
                        break;
                    case "tenTinhThanh-az":
                        list = context.TinhThanh.Where(temp => temp.MaTinhThanh.Contains(search)
                                                        || temp.TenTinhThanh.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                               .OrderBy(l => l.TenTinhThanh)
                                               .ToList();
                        break;
                    case "tenTinhThanh-za":
                        list = context.TinhThanh.Where(temp => temp.MaTinhThanh.Contains(search)
                                                        || temp.TenTinhThanh.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                               .OrderByDescending(l => l.TenTinhThanh)
                                               .ToList();
                        break;
                }
            }
            return list;
        }

    }
}
