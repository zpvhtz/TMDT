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
                .Where(gh =>gh.TinhTrang == "Không khoá")
                .ToList();
                
            return list;
        }

        public QuangCao LoadQuangCao(string mavitri)
        {
            QuangCao qc = new QuangCao();
            qc = context.QuangCao.Where(gh => gh.IdGoiQuangCaoNavigation.IdViTriNavigation.MaViTri == mavitri && gh.NgayBatDau <= DateTime.Now && gh.NgayKetThuc > DateTime.Now && gh.TinhTrang == "Không khoá")
               
               .SingleOrDefault();
           // qc = context.QuangCao.Where(gh => gh.MaQuangCao=="QC-2001").SingleOrDefault();
            if (qc == null)
            {
                return null;
            }
           
            return qc;
        }

        public List<QuangCaoThichHop> GetDates (int nam,int thang, string goi)
        {
            List<QuangCaoThichHop> lst = new List<QuangCaoThichHop>();
            GoiQuangCao goiqc = new GoiQuangCao();
            
            goiqc = context.GoiQuangCao.Where(gh => gh.Id == Guid.Parse(goi)).SingleOrDefault();
            SqlConnection con = new SqlConnection("Server=.;Database=QLBanGiay;Integrated Security=True;");
            var cmd = new SqlCommand("select day from [dbo].[ngaythichhop](@thang,@nam,@goi)", con);
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
        public int GetThoiLuong(string goi)
        {
            GoiQuangCao goiqc = new GoiQuangCao();
            goiqc = context.GoiQuangCao.Where(gh => gh.Id == Guid.Parse(goi)).SingleOrDefault();
           
            return Convert.ToInt32(goiqc.ThoiLuong);
        }
        public string GetTenViTri(string goi)
        {
            GoiQuangCao goiqc = new GoiQuangCao();
            goiqc = context.GoiQuangCao.Where(gh => gh.Id == Guid.Parse(goi)).Include(gh => gh.IdViTriNavigation).SingleOrDefault();
            return goiqc.IdViTriNavigation.TenViTri;
        }
        public string CheckMa(string ma)
        {
            QuangCao qc = new QuangCao();
            qc = context.QuangCao.Where(gh => gh.MaQuangCao==ma).SingleOrDefault();
            if (qc==null)
            {
                return null;
            }
            return qc.MaQuangCao;
        }
        public string CheckTaiKhoan(string taikhoan)
        {
            TaiKhoan tk = new TaiKhoan();
            tk = context.TaiKhoan.Where(gh => gh.TenDangNhap == taikhoan).SingleOrDefault();
            if (tk == null)
            {
                return null;
            }
            return tk.TenDangNhap;
        }


        public List<QuangCao> GetQuangCaos(int pagenumber, int pagesize)
        {
            List<QuangCao> list = context.QuangCao.OrderBy(gh => gh.MaQuangCao)
                                                  .Skip((pagenumber - 1) * pagesize)
                                                  .Take(pagesize)
                                                  .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
                                                  .ToList();
            return list;
        }

        public string CreateQuangCao(/*string ma, */string goiquangcao, string taikhoan, string hinh, DateTime ngaybatdau, string duongdan, string chuthich)
        {
            QuangCao quangcao;
            GoiQuangCao goi;
            TaiKhoan tk;

            //Kiểm tra
            //Tên đăng nhập
            //quangcao = context.QuangCao.Where(gh => gh.MaQuangCao == ma).SingleOrDefault();
            //if (quangcao != null)
            //{
            //    return "Quảng cáo này đã tồn tại";
            //}
            tk = context.TaiKhoan.Where(gh => gh.TenDangNhap == taikhoan).SingleOrDefault();
            if( tk == null)
            {
                return "Không tồn tại tài khoản này";
            }

            //Get mã quảng cáo
            string magianhangmoi = "";
            QuangCao gianhangcu = context.QuangCao.OrderByDescending(gh => gh.MaQuangCao.Substring(2)).FirstOrDefault();
            if (gianhangcu == null)
            {
                magianhangmoi = "QC1";
            }
            else
            {
                string magianhangcu = gianhangcu.MaQuangCao;
                int stt = int.Parse(magianhangcu.Substring(2));
                stt += 1;
                magianhangmoi = "QC" + stt.ToString();
            }


            //Thêm
            quangcao = new QuangCao();
            quangcao.Id = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
            quangcao.MaQuangCao = magianhangmoi;

            quangcao.IdGoiQuangCao = Guid.Parse(goiquangcao);

            quangcao.IdTaiKhoan = tk.Id;
            quangcao.DuongDan = duongdan;
          
            quangcao.Hinh = hinh;
            quangcao.NgayBatDau = ngaybatdau;
            goi = context.GoiQuangCao.Where(gh => gh.Id == Guid.Parse(goiquangcao)).SingleOrDefault();
            quangcao.NgayKetThuc = ngaybatdau.AddDays(Convert.ToDouble(goi.ThoiLuong) * 7);

            quangcao.ChuThich = chuthich;
            quangcao.TinhTrang = "Không khoá";

            context.QuangCao.Add(quangcao);
            context.SaveChanges();
            return "Thêm thành công";
        }

        public string EditQuangCao(string ma, string goiquangcao, string taikhoan, string hinh, DateTime ngaybatdau, DateTime ngayketthuc, string duongdan, string chuthich)
        {
            QuangCao quangcao = new QuangCao();
            GoiQuangCao goi;
            
            //Sửa
            quangcao = context.QuangCao.Where(gh => gh.MaQuangCao == ma).SingleOrDefault();
            if(hinh!=null)
            {
                quangcao.Hinh = hinh;
            }
            quangcao.DuongDan = duongdan;
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

        public string LockQuangCao2(string ma)
        {
            QuangCao quangcao = context.QuangCao.Where(gh => gh.MaQuangCao == ma).SingleOrDefault();
            quangcao.TinhTrang = "Sai dữ liệu";
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
                                           .ToList();
                    break;
                case "ngaybatdau-desc":
                    list = context.QuangCao.OrderByDescending(gh => gh.NgayBatDau)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
                                           .ToList();
                    break;

                case "ngayketthuc-asc":
                    list = context.QuangCao.OrderBy(gh => gh.NgayKetThuc)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
                                           .ToList();
                    break;
                case "ngayketthuc-desc":
                    list = context.QuangCao.OrderByDescending(gh => gh.NgayKetThuc)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
                                           .ToList();
                    break;
                case "goiquangcao-az":
                    list = context.QuangCao.OrderBy(gh => gh.IdGoiQuangCaoNavigation.MaGoiQuangCao)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
                                           .ToList();
                    break;
                case "goiquangcao-za":
                    list = context.QuangCao.OrderByDescending(gh => gh.IdGoiQuangCaoNavigation.MaGoiQuangCao)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
                                           .ToList();
                    break;
                case "taikhoan-az":
                    list = context.QuangCao.OrderBy(gh => gh.IdTaiKhoanNavigation.Ten)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
                                           .ToList();
                    break;
                case "taikhoan-za":
                    list = context.QuangCao.OrderByDescending(gh => gh.IdTaiKhoanNavigation.Ten)
                                           .Skip((pagenumber - 1) * pagesize)
                                           .Take(pagesize)
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
                                           .ToList();
                    break;
                case "ngaybatdau-desc":
                    list = context.QuangCao.OrderByDescending(gh => gh.NgayBatDau)
                                           
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
                                           .ToList();
                    break;

                case "ngayketthuc-asc":
                    list = context.QuangCao.OrderBy(gh => gh.NgayKetThuc)
                                           
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
                                           .ToList();
                    break;
                case "ngayketthuc-desc":
                    list = context.QuangCao.OrderByDescending(gh => gh.NgayKetThuc)
                                           
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
                                           .ToList();
                    break;
                case "goiquangcao-az":
                    list = context.QuangCao.OrderBy(gh => gh.IdGoiQuangCaoNavigation.MaGoiQuangCao)
                                          
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
                                           .ToList();
                    break;
                case "goiquangcao-za":
                    list = context.QuangCao.OrderByDescending(gh => gh.IdGoiQuangCaoNavigation.MaGoiQuangCao)
                                         
                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
                                           .ToList();
                    break;
                case "taikhoan-az":
                    list = context.QuangCao.OrderBy(gh => gh.IdTaiKhoanNavigation.Ten)

                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
                                           .ToList();
                    break;
                case "taikhoan-za":
                    list = context.QuangCao.OrderByDescending(gh => gh.IdTaiKhoanNavigation.Ten)

                                           .Include(gh => gh.IdGoiQuangCaoNavigation)
                                                  .Include(gh => gh.IdTaiKhoanNavigation)
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
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
                                                  .Where(gh => gh.TinhTrang != "Sai dữ liệu")
                                               .ToList();
                        break;

                }
            }
            return list;
        }

    }
}
