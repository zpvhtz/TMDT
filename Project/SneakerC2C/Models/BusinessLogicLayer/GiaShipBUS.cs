using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.BusinessLogicLayer
{
    public class GiaShipBUS
    {
        private readonly QLBanGiayContext context;
        public GiaShipBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public GiaShipBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public List<GiaShip> GetGiaShips()
        {
            List<GiaShip> list = context.GiaShip.ToList();
            return list;
        }

        public List<GiaShip> GetGiaShips(int pagenumber, int pagesize)
        {
            List<GiaShip> list = context.GiaShip
                                                  .OrderBy(temp => temp.NgayCapNhat)
                                                  .Skip((pagenumber - 1) * pagesize)
                                                  .Take(pagesize)
                                                  .ToList();
            return list;
        }

        //------------------------------------------------------ THEM SUA XOA -----------------------------------------------------------------
        public string CreateGiaShip(string Loai, double Gia)
        {

            GiaShip GiaShip = new GiaShip();

            //----------------------- chuan hoa du lieu ----------------------- 
            //----------------------- kiem tra loai -----------------------
            GiaShip = context.GiaShip.Where(temp => temp.Loai == Loai).SingleOrDefault();
            if (GiaShip != null)
            {
                return "Loại ship này đã tồn tại";
            }
            //----------------------- them -----------------------
            GiaShip = new GiaShip();
            GiaShip.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            GiaShip.Loai = Loai;
            GiaShip.Gia = Gia;
            GiaShip.NgayCapNhat = DateTime.Now;

            context.GiaShip.Add(GiaShip);
            context.SaveChanges();

            return "Thêm thành công";
        }
        public string EditGiaShip(string Loai, double Gia)
        {
            GiaShip GiaShip = new GiaShip();

            //----------------------- chuan hoa du lieu ----------------------- 
            //----------------------- kiem tra ma -----------------------
            GiaShip = context.GiaShip.Where(temp => temp.Loai == Loai).SingleOrDefault();

            GiaShip Temp = new GiaShip();
            Temp.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            Temp.Loai = GiaShip.Loai;
            Temp.Gia = Gia;
            Temp.NgayCapNhat = DateTime.Now;

            context.GiaShip.Add(Temp);
            context.SaveChanges();
            return "Sửa thành công";
        }

        //------------------------------------------------------ TIM KIEM - SAP XEP -----------------------------------------------------------------

        public List<GiaShip> Sort(string sortorder, int pagesize, int pagenumber)
        {
            List<GiaShip> list = new List<GiaShip>();
            switch (sortorder)
            {
                case "gia-az":
                    {
                        list = context.GiaShip
                                          .OrderBy(temp => temp.Gia)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();

                        break;
                    }
                case "gia-za":
                    {
                        list = context.GiaShip
                                          .OrderByDescending(temp => temp.Gia)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();

                        break;
                    }
                case "ngay-az":
                    {
                        list = context.GiaShip
                                          .OrderBy(temp => temp.NgayCapNhat)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                        break;
                    }
                case "ngay-za":
                    {
                        list = context.GiaShip
                                      .OrderByDescending(temp => temp.NgayCapNhat)
                                      .Skip((pagenumber - 1) * pagesize)
                                      .Take(pagesize)
                                      .ToList();
                        break;
                    }

            }
            return list;
        }
        public List<GiaShip> Sort(string sortorder)
        {
            List<GiaShip> list = new List<GiaShip>();
            switch (sortorder)
            {
                case "gia-az":
                    {
                        list = context.GiaShip
                                          .OrderBy(temp => temp.Gia)
                                          .ToList();

                        break;
                    }
                case "gia-za":
                    {
                        list = context.GiaShip
                                          .OrderByDescending(temp => temp.Gia)
                                          .ToList();

                        break;
                    }
                case "ngay-az":
                    {
                        list = context.GiaShip
                                          .OrderBy(temp => temp.NgayCapNhat)
                                          .ToList();
                        break;
                    }
                case "ngay-za":
                    {
                        list = context.GiaShip
                                          .OrderByDescending(temp => temp.NgayCapNhat)
                                          .ToList();
                        break;
                    }
            }
            return list;
        }
        public List<GiaShip> Search(string search, int pagesize, int pagenumber)
        {
            List<GiaShip> list = new List<GiaShip>();
            if (search == null)
            {
                list = GetGiaShips(1, pagesize);
            }
            else
            {
                list = context.GiaShip.Where(temp => temp.Loai.Contains(search))
                                            .Skip((pagenumber - 1) * pagesize)
                                            .Take(pagesize)
                                            .ToList();
            }
            return list;
        }

        public List<GiaShip> Search(string search, int pagesize)
        {
            List<GiaShip> list = new List<GiaShip>();
            if (search == null)
            {
                list = GetGiaShips(1, pagesize);
            }
            else
            {
                list = context.GiaShip.Where(temp => temp.Loai.Contains(search))
                                            .ToList();
            }
            return list;
        }

        public List<GiaShip> SearchAndSort(string search, string sortorder, int pagesize, int pagenumber)
        {
            List<GiaShip> list = new List<GiaShip>();
            if (search == null)
            {
                list = GetGiaShips(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "loai-az":
                        list = context.GiaShip.Where(temp => temp.Loai.Contains(search))
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .OrderBy(temp => temp.Loai)
                                               .ToList();
                        break;
                    case "loai-za":
                        list = context.GiaShip.Where(temp => temp.Loai.Contains(search))
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .OrderByDescending(temp => temp.Loai)
                                               .ToList();
                        break;
                    case "ngay-az":
                        list = context.GiaShip.Where(temp => temp.Loai.Contains(search))
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .OrderBy(temp => temp.NgayCapNhat)
                                               .ToList();
                        break;
                    case "ngay-za":
                        list = context.GiaShip.Where(temp => temp.Loai.Contains(search))
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .OrderByDescending(temp => temp.NgayCapNhat)
                                               .ToList();
                        break;
                }
            }
            return list;
        }

        public List<GiaShip> SearchAndSort(string search, string sortorder, int pagesize)
        {
            List<GiaShip> list = new List<GiaShip>();
            if (search == null)
            {
                list = GetGiaShips(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "loai-az":
                        list = context.GiaShip.Where(temp => temp.Loai.Contains(search))
                                               .Take(pagesize)
                                               .OrderBy(temp => temp.Loai)
                                               .ToList();
                        break;
                    case "loai-za":
                        list = context.GiaShip.Where(temp => temp.Loai.Contains(search))
                                               .Take(pagesize)
                                               .OrderByDescending(temp => temp.Loai)
                                               .ToList();
                        break;
                    case "ngay-az":
                        list = context.GiaShip.Where(temp => temp.Loai.Contains(search))
                                               .Take(pagesize)
                                               .OrderBy(temp => temp.NgayCapNhat)
                                               .ToList();
                        break;
                    case "ngay-za":
                        list = context.GiaShip.Where(temp => temp.Loai.Contains(search))
                                               .Take(pagesize)
                                               .OrderByDescending(temp => temp.NgayCapNhat)
                                               .ToList();
                        break;
                }
            }
            return list;
        }
    }

}
