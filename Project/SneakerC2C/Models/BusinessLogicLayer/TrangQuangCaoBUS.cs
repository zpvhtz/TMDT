using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.BusinessLogicLayer
{
    public class TrangQuangCaoBUS
    {
        private readonly QLBanGiayContext context;

        public TrangQuangCaoBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public TrangQuangCaoBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public List<TrangQuangCao> GetTrangQuangCaos()
        {
            List<TrangQuangCao> list = context.TrangQuangCao.OrderBy(gh => gh.MaTrang).ToList();
            return list;
        }

        public List<TrangQuangCao> GetTrangQuangCaos(int pagenumber, int pagesize)
        {
            List<TrangQuangCao> list = context.TrangQuangCao.OrderBy(gh => gh.MaTrang)
                                                  .Skip((pagenumber - 1) * pagesize)
                                                  .Take(pagesize)
                                                  .ToList();
            return list;
        }

        public string CheckMa(string ma)
        {
            TrangQuangCao trang = new TrangQuangCao();
            trang = context.TrangQuangCao.Where(gh => gh.MaTrang == ma).SingleOrDefault();
            if (trang == null)
            {
                return null;
            }
            return trang.MaTrang;
        }

        public string CheckTen(string ten)
        {
            TrangQuangCao trang = new TrangQuangCao();
            trang = context.TrangQuangCao.Where(gh => gh.TenTrang == ten).SingleOrDefault();
            if (trang == null)
            {
                return null;
            }
            return trang.TenTrang;
        }

        public string CreateTrangQuangCao(string ma, string ten, string chuthich)
        {
            TrangQuangCao trang;
            //Kiểm tra
            //Tên đăng nhập
            trang = context.TrangQuangCao.Where(gh => gh.MaTrang == ma).SingleOrDefault();
            if (trang != null)
            {
                return "Trang đã tồn tại";
            }
            //Thêm
            trang = new TrangQuangCao();
            trang.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            trang.MaTrang = ma;
            trang.TenTrang = ten;
            trang.ChuThich = chuthich;
            trang.TinhTrang = "Không khoá";
           
            context.TrangQuangCao.Add(trang);
            context.SaveChanges();
            return "Thêm thành công";
        }

        public string EditTrangQuangCao(string ma, string ten, string chuthich)
        {
            TrangQuangCao trang = new TrangQuangCao();
            //Sửa
            trang = context.TrangQuangCao.Where(gh => gh.MaTrang == ma).SingleOrDefault();
            if (ten != null)
            {
                trang.TenTrang = ten;
            }
            if (chuthich != null)
            {
                trang.ChuThich = chuthich;
            }
            context.SaveChanges();
            return "Sửa thành công";
        }

        public string LockTrangQuangCao(string ma)
        {
            TrangQuangCao trang = context.TrangQuangCao.Where(gh => gh.MaTrang == ma).SingleOrDefault();
            trang.TinhTrang = "Khoá";
            context.SaveChanges();
            return "Khoá thành công";
        }

        public string UnlockTrangQuangCao(string ma)
        {
            TrangQuangCao trang = context.TrangQuangCao.Where(gh => gh.MaTrang == ma).SingleOrDefault();
            trang.TinhTrang = "Không khoá";
            context.SaveChanges();
            return "Mở khoá thành công";
        }

        public List<TrangQuangCao> Sort(string sortorder, int pagesize, int pagenumber)
        {
            List<TrangQuangCao> list = new List<TrangQuangCao>();
            switch (sortorder)
            {
                case "tentrang-az":
                    list = context.TrangQuangCao.OrderBy(gh => gh.TenTrang)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .ToList();
                    break;
                case "tentrang-za":
                    list = context.TrangQuangCao.OrderByDescending(gh => gh.TenTrang)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .ToList();
                    break;
                
            }
            return list;
        }

        public List<TrangQuangCao> Sort(string sortorder)
        {
            List<TrangQuangCao> list = new List<TrangQuangCao>();
            switch (sortorder)
            {
                case "tentrang-az":
                    list = context.TrangQuangCao.OrderBy(gh => gh.TenTrang).ToList();
                    break;
                case "tentrang-za":
                    list = context.TrangQuangCao.OrderByDescending(gh => gh.TenTrang).ToList();
                    break;
                
            }
            return list;
        }

        public List<TrangQuangCao> Search(string search, int pagesize, int pagenumber)
        {
            List<TrangQuangCao> list = new List<TrangQuangCao>();
            if (search == null)
            {
                list = GetTrangQuangCaos(1, pagesize);
            }
            else
            {
                list = context.TrangQuangCao.Where(gh => gh.MaTrang.Contains(search) ||
                                                    gh.TenTrang.Contains(search) ||
                                                            gh.ChuThich.Contains(search))
                                       .Skip((pagenumber - 1) * pagesize)
                                       .Take(pagesize)
                                       .ToList();
            }
            return list;
        }

        public List<TrangQuangCao> Search(string search, int pagesize)
        {
            List<TrangQuangCao> list = new List<TrangQuangCao>();
            if (search == null)
            {
                list = GetTrangQuangCaos(1, pagesize);
            }
            else
            {
                list = context.TrangQuangCao.Where(gh => gh.MaTrang.Contains(search) ||
                                                    gh.TenTrang.Contains(search) ||
                                                            gh.ChuThich.Contains(search))
                                       .ToList();
            }
            return list;
        }

        public List<TrangQuangCao> SearchAndSort(string search, string sortorder, int pagesize, int pagenumber)
        {
            List<TrangQuangCao> list = new List<TrangQuangCao>();
            if (search == null)
            {
                list = GetTrangQuangCaos(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "tentrang-az":
                        list = context.TrangQuangCao.Where(gh => gh.MaTrang.Contains(search) ||
                                                            gh.TenTrang.Contains(search) ||
                                                            gh.ChuThich.Contains(search))
                                               .OrderBy(gh => gh.TenTrang)
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .ToList();
                        break;
                    case "tentrang-za":
                        list = context.TrangQuangCao.Where(gh => gh.MaTrang.Contains(search) ||
                                                            gh.TenTrang.Contains(search) ||
                                                            gh.ChuThich.Contains(search))
                                               .OrderByDescending(gh => gh.TenTrang)
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .ToList();
                        break;
                    
                }
            }
            return list;
        }

        public List<TrangQuangCao> SearchAndSort(string search, string sortorder, int pagesize)
        {
            List<TrangQuangCao> list = new List<TrangQuangCao>();
            if (search == null)
            {
                list = GetTrangQuangCaos(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "tentrang-az":
                        list = context.TrangQuangCao.Where(gh => gh.MaTrang.Contains(search) ||
                                                            gh.TenTrang.Contains(search) ||
                                                            gh.ChuThich.Contains(search))
                                               .OrderBy(gh => gh.TenTrang)
                                               .ToList();
                        break;
                    case "tentrang-za":
                        list = context.TrangQuangCao.Where(gh => gh.MaTrang.Contains(search) ||
                                                            gh.TenTrang.Contains(search) ||
                                                            gh.ChuThich.Contains(search))
                                               .OrderByDescending(gh => gh.TenTrang)
                                               .ToList();
                        break;
                  
                }
            }
            return list;
        }
    }
}
