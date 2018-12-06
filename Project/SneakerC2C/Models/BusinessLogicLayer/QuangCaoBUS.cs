using Microsoft.EntityFrameworkCore;
using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.DTO;
using System.Data.SqlClient;
using System.Data;

namespace Models.BusinessLogicLayer
{
    public class QuangCaoBUS
    {
        private readonly QLBanGiayContext context;

        public QuangCaoBUS()
        {
            this.context = new QLBanGiayContext();
        }

        public QuangCaoBUS(QLBanGiayContext context)
        {
            this.context = context;
        }

        public List<QuangCao> GetQuangCaos()
        {
            List<QuangCao> list = context.QuangCao.OrderBy(gh => gh.MaQuangCao)
                .Include(gh => gh.IdGoiQuangCaoNavigation)
                .Include(gh => gh.IdTaiKhoanNavigation)
                .ToList();
            return list;
        }

        public List<QuangCaoThichHop> GetDates (int nam,int thang, string goi)
        {
            List<QuangCaoThichHop> lst = new List<QuangCaoThichHop>();
            GoiQuangCao goiqc = new GoiQuangCao();
            
            goiqc = context.GoiQuangCao.Where(gh => gh.Id == Guid.Parse(goi)).SingleOrDefault();
            SqlConnection con = new SqlConnection("Server =.\\QUACHDAIVYTRUE; Database = QLBanGiay; User id = sa; Password = daivypro; Integrated Security = True");
            var cmd = new SqlCommand("select day from [dbo].[ngaythichhop]('9','2018','8804015b-62f8-46ed-b2bd-e662a1730381')", con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("thang", thang);
            cmd.Parameters.AddWithValue("nam",nam);
            cmd.Parameters.AddWithValue("goi", goiqc.Id);
            var da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                QuangCaoThichHop qcth = new QuangCaoThichHop();
                qcth.day = Convert.ToInt32(row["day"]);
                lst.Add(qcth);
            }
            con.Close();

            // Info.  
            return lst;
        }
    

        public List<QuangCao> GetQuangCaos(int pagenumber, int pagesize)
        {
            List<QuangCao> list = context.QuangCao.OrderBy(gh => gh.MaQuangCao)
                                                  .Skip((pagenumber - 1) * pagesize)
                                                  .Take(pagesize)
                                                  .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                                  .ToList();
            return list;
        }

        public string CreateQuangCao(string ma, string goiquangcao, string taikhoan, string hinh, DateTime ngaybatdau, DateTime ngayketthuc, string chuthich)
        {
            QuangCao quangcao;
            GoiQuangCao goi;

            //Kiểm tra
            //Tên đăng nhập
            quangcao = context.QuangCao.Where(gh => gh.MaQuangCao == ma).SingleOrDefault();
            if (quangcao != null)
            {
                return "Quảng cáo này đã tồn tại";
            }
            //Thêm
            quangcao = new QuangCao();
            quangcao.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            quangcao.MaQuangCao = ma;

            quangcao.IdGoiQuangCao = Guid.Parse(goiquangcao);
            quangcao.IdTaiKhoan = Guid.Parse(taikhoan);
            
            quangcao.Hinh = hinh;
            quangcao.NgayBatDau = ngaybatdau;
            quangcao.NgayKetThuc = ngayketthuc;
            quangcao.ChuThich = chuthich;
            quangcao.TinhTrang = "Không khoá";

            context.QuangCao.Add(quangcao);
            context.SaveChanges();
            return "Thêm thành công";
        }

        public string EditQuangCao(string ma, string goiquangcao, string taikhoan, string hinh, DateTime ngaybatdau, DateTime ngayketthuc, string chuthich)
        {
            QuangCao quangcao = new QuangCao();
            GoiQuangCao goi;
            //Sửa
            quangcao = context.QuangCao.Where(gh => gh.MaQuangCao == ma).SingleOrDefault();
            quangcao.ChuThich = chuthich;
            context.SaveChanges();
            return "Sửa thành công";
        }

        public string LockQuangCao(string ma)
        {
            QuangCao quangcao = context.QuangCao.Where(gh => gh.MaQuangCao == ma).SingleOrDefault();
            quangcao.TinhTrang = "Khoá";
            context.SaveChanges();
            return "Khoá thành công";
        }

        public string UnlockQuangCao(string ma)
        {
            QuangCao quangcao = context.QuangCao.Where(gh => gh.MaQuangCao == ma).SingleOrDefault();
            quangcao.TinhTrang = "Không khoá";
            context.SaveChanges();
            return "Mở khoá thành công";
        }

        public List<QuangCao> Sort(string sortorder, int pagesize, int pagenumber)
        {
            List<QuangCao> list = new List<QuangCao>();
            switch (sortorder)
            {
                case "ngaybatdau-asc":
                    list = context.QuangCao.OrderBy(gh => gh.NgayBatDau)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                           .ToList();
                    break;
                case "ngaybatdau-desc":
                    list = context.QuangCao.OrderByDescending(gh => gh.NgayBatDau)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                           .ToList();
                    break;

                case "ngayketthuc-asc":
                    list = context.QuangCao.OrderBy(gh => gh.NgayKetThuc)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                           .ToList();
                    break;
                case "ngayketthuc-desc":
                    list = context.QuangCao.OrderByDescending(gh => gh.NgayKetThuc)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                           .ToList();
                    break;
                case "goiquangcao-az":
                    list = context.QuangCao.OrderBy(gh => gh.IdGoiQuangCaoNavigation.MaGoiQuangCao)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                           .ToList();
                    break;
                case "goiquangcao-za":
                    list = context.QuangCao.OrderByDescending(gh => gh.IdGoiQuangCaoNavigation.MaGoiQuangCao)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                           .ToList();
                    break;
                case "taikhoan-az":
                    list = context.QuangCao.OrderBy(gh => gh.IdTaiKhoanNavigation.Ten)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                           .ToList();
                    break;
                case "taikhoan-za":
                    list = context.QuangCao.OrderByDescending(gh => gh.IdTaiKhoanNavigation.Ten)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                           .ToList();
                    break;

            }
            return list;
        }

        public List<QuangCao> Sort(string sortorder)
        {
            List<QuangCao> list = new List<QuangCao>();
            switch (sortorder)
            {
                case "ngaybatdau-asc":
                    list = context.QuangCao.OrderBy(gh => gh.NgayBatDau)
                                          
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                           .ToList();
                    break;
                case "ngaybatdau-desc":
                    list = context.QuangCao.OrderByDescending(gh => gh.NgayBatDau)
                                           
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                           .ToList();
                    break;

                case "ngayketthuc-asc":
                    list = context.QuangCao.OrderBy(gh => gh.NgayKetThuc)
                                           
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                           .ToList();
                    break;
                case "ngayketthuc-desc":
                    list = context.QuangCao.OrderByDescending(gh => gh.NgayKetThuc)
                                           
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                           .ToList();
                    break;
                case "goiquangcao-az":
                    list = context.QuangCao.OrderBy(gh => gh.IdGoiQuangCaoNavigation.MaGoiQuangCao)
                                          
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                           .ToList();
                    break;
                case "goiquangcao-za":
                    list = context.QuangCao.OrderByDescending(gh => gh.IdGoiQuangCaoNavigation.MaGoiQuangCao)
                                         
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                           .ToList();
                    break;
                case "taikhoan-az":
                    list = context.QuangCao.OrderBy(gh => gh.IdTaiKhoanNavigation.Ten)

                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                           .ToList();
                    break;
                case "taikhoan-za":
                    list = context.QuangCao.OrderByDescending(gh => gh.IdTaiKhoanNavigation.Ten)

                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                           .ToList();
                    break;
            }
            return list;
        }

        public List<QuangCao> Search(string search, int pagesize, int pagenumber)
        {
            List<QuangCao> list = new List<QuangCao>();
            if (search == null)
            {
                list = GetQuangCaos(1, pagesize);
            }
            else
            {
                list = context.QuangCao.Where(gh => gh.MaQuangCao.Contains(search) ||
                                                    gh.IdGoiQuangCaoNavigation.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdTaiKhoanNavigation.Ten.Contains(search))

                                       .Skip((pagenumber - 1) * pagesize)
                                       .Take(pagesize)
                                       .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                       .ToList();
            }
            return list;
        }

        public List<QuangCao> Search(string search, int pagesize)
        {
            List<QuangCao> list = new List<QuangCao>();
            if (search == null)
            {
                list = GetQuangCaos(1, pagesize);
            }
            else
            {
                list = context.QuangCao.Where(gh => gh.MaQuangCao.Contains(search) ||
                                                     gh.IdGoiQuangCaoNavigation.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdTaiKhoanNavigation.Ten.Contains(search) ||
                                                    gh.Hinh.Contains(search))
                                                            .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                       .ToList();
            }
            return list;
        }

        public List<QuangCao> SearchAndSort(string search, string sortorder, int pagesize, int pagenumber)
        {
            List<QuangCao> list = new List<QuangCao>();
            if (search == null)
            {
                list = GetQuangCaos(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "ngaybatdau-asc":
                        list = context.QuangCao.Where(gh => gh.MaQuangCao.Contains(search) ||
                                                    gh.IdGoiQuangCaoNavigation.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdTaiKhoanNavigation.Ten.Contains(search) ||
                                                    gh.Hinh.Contains(search))
                                                    .Skip((pagenumber - 1) * pagesize)
                                       .Take(pagesize)

                                               .OrderBy(gh => gh.NgayBatDau)
                                               .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                               .ToList();
                        break;
                    case "ngaybatdau-desc":
                        list = context.QuangCao.Where(gh => gh.MaQuangCao.Contains(search) ||
                                                    gh.IdGoiQuangCaoNavigation.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdTaiKhoanNavigation.Ten.Contains(search) ||
                                                    gh.Hinh.Contains(search))
                                                    .Skip((pagenumber - 1) * pagesize)
                                       .Take(pagesize)

                                               .OrderByDescending(gh => gh.NgayBatDau)
                                               .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                               .ToList();
                        break;
                    case "ngayketthuc-asc":
                        list = context.QuangCao.Where(gh => gh.MaQuangCao.Contains(search) ||
                                                    gh.IdGoiQuangCaoNavigation.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdTaiKhoanNavigation.Ten.Contains(search) ||
                                                    gh.Hinh.Contains(search))
                                                    .Skip((pagenumber - 1) * pagesize)
                                       .Take(pagesize)

                                               .OrderBy(gh => gh.NgayKetThuc)
                                               .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                               .ToList();
                        break;
                    case "ngayketthuc-desc":
                        list = context.QuangCao.Where(gh => gh.MaQuangCao.Contains(search) ||
                                                    gh.IdGoiQuangCaoNavigation.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdTaiKhoanNavigation.Ten.Contains(search) ||
                                                    gh.Hinh.Contains(search))
                                                    .Skip((pagenumber - 1) * pagesize)
                                       .Take(pagesize)

                                               .OrderByDescending(gh => gh.NgayKetThuc)
                                               .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                               .ToList();
                        break;
                    case "goiquangcao-asc":
                        list = context.QuangCao.Where(gh => gh.MaQuangCao.Contains(search) ||
                                                    gh.IdGoiQuangCaoNavigation.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdTaiKhoanNavigation.Ten.Contains(search) ||
                                                    gh.Hinh.Contains(search))
                                                    .Skip((pagenumber - 1) * pagesize)
                                       .Take(pagesize)

                                               .OrderBy(gh => gh.IdGoiQuangCaoNavigation.MaGoiQuangCao)
                                               .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                               .ToList();
                        break;
                    case "goiquangcao-desc":
                        list = context.QuangCao.Where(gh => gh.MaQuangCao.Contains(search) ||
                                                    gh.IdGoiQuangCaoNavigation.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdTaiKhoanNavigation.Ten.Contains(search) ||
                                                    gh.Hinh.Contains(search))
                                                    .Skip((pagenumber - 1) * pagesize)
                                       .Take(pagesize)

                                               .OrderByDescending(gh => gh.IdGoiQuangCaoNavigation.MaGoiQuangCao)
                                               .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                               .ToList();
                        break;
                    case "taikhoan-az":
                        list = context.QuangCao.Where(gh => gh.MaQuangCao.Contains(search) ||
                                                    gh.IdGoiQuangCaoNavigation.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdTaiKhoanNavigation.Ten.Contains(search) ||
                                                    gh.Hinh.Contains(search))
                                                    .Skip((pagenumber - 1) * pagesize)
                                       .Take(pagesize)

                                               .OrderBy(gh => gh.IdTaiKhoanNavigation.Ten)
                                               .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                               .ToList();
                        break;
                    case "taikhoan-za":
                        list = context.QuangCao.Where(gh => gh.MaQuangCao.Contains(search) ||
                                                    gh.IdGoiQuangCaoNavigation.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdTaiKhoanNavigation.Ten.Contains(search) ||
                                                    gh.Hinh.Contains(search))
                                                    .Skip((pagenumber - 1) * pagesize)
                                       .Take(pagesize)

                                               .OrderByDescending(gh => gh.IdTaiKhoanNavigation.Ten)
                                               .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                               .ToList();
                        break;

                }
            }
            return list;
        }

        public List<QuangCao> SearchAndSort(string search, string sortorder, int pagesize)
        {
            List<QuangCao> list = new List<QuangCao>();
            if (search == null)
            {
                list = GetQuangCaos(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "ngaybatdau-asc":
                        list = context.QuangCao.Where(gh => gh.MaQuangCao.Contains(search) ||
                                                    gh.IdGoiQuangCaoNavigation.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdTaiKhoanNavigation.Ten.Contains(search) ||
                                                    gh.Hinh.Contains(search))

                                               .OrderBy(gh => gh.NgayBatDau)
                                               .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                               .ToList();
                        break;
                    case "ngaybatdau-desc":
                        list = context.QuangCao.Where(gh => gh.MaQuangCao.Contains(search) ||
                                                    gh.IdGoiQuangCaoNavigation.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdTaiKhoanNavigation.Ten.Contains(search) ||
                                                    gh.Hinh.Contains(search))

                                               .OrderByDescending(gh => gh.NgayBatDau)
                                               .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                               .ToList();
                        break;
                    case "ngayketthuc-asc":
                        list = context.QuangCao.Where(gh => gh.MaQuangCao.Contains(search) ||
                                                    gh.IdGoiQuangCaoNavigation.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdTaiKhoanNavigation.Ten.Contains(search) ||
                                                    gh.Hinh.Contains(search))

                                               .OrderBy(gh => gh.NgayKetThuc)
                                               .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                               .ToList();
                        break;
                    case "ngayketthuc-desc":
                        list = context.QuangCao.Where(gh => gh.MaQuangCao.Contains(search) ||
                                                    gh.IdGoiQuangCaoNavigation.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdTaiKhoanNavigation.Ten.Contains(search) ||
                                                    gh.Hinh.Contains(search))

                                               .OrderByDescending(gh => gh.NgayKetThuc)
                                               .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                               .ToList();
                        break;
                    case "goiquangcao-asc":
                        list = context.QuangCao.Where(gh => gh.MaQuangCao.Contains(search) ||
                                                    gh.IdGoiQuangCaoNavigation.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdTaiKhoanNavigation.Ten.Contains(search) ||
                                                    gh.Hinh.Contains(search))

                                               .OrderBy(gh => gh.IdGoiQuangCaoNavigation.MaGoiQuangCao)
                                               .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                               .ToList();
                        break;
                    case "goiquangcao-desc":
                        list = context.QuangCao.Where(gh => gh.MaQuangCao.Contains(search) ||
                                                    gh.IdGoiQuangCaoNavigation.MaGoiQuangCao.Contains(search) ||
                                                   gh.IdTaiKhoanNavigation.Ten.Contains(search) ||
                                                    gh.Hinh.Contains(search))

                                               .OrderByDescending(gh => gh.IdGoiQuangCaoNavigation.MaGoiQuangCao)
                                               .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                               .ToList();
                        break;
                    case "taikhoan-az":
                        list = context.QuangCao.Where(gh => gh.MaQuangCao.Contains(search) ||
                                                    gh.IdGoiQuangCaoNavigation.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdTaiKhoanNavigation.Ten.Contains(search) ||
                                                    gh.Hinh.Contains(search))

                                               .OrderBy(gh => gh.IdTaiKhoanNavigation.Ten)
                                               .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                               .ToList();
                        break;
                    case "taikhoan-za":
                        list = context.QuangCao.Where(gh => gh.MaQuangCao.Contains(search) ||
                                                    gh.IdGoiQuangCaoNavigation.MaGoiQuangCao.Contains(search) ||
                                                    gh.IdTaiKhoanNavigation.Ten.Contains(search) ||
                                                    gh.Hinh.Contains(search))

                                               .OrderByDescending(gh => gh.IdTaiKhoanNavigation.Ten)
                                               .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                               .ToList();
                        break;

                }
            }
            return list;
        }

    }
}
