using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Models.Database;
using System.Linq;


namespace Models.BusinessLogicLayer
{
    public class DonHangBUS_Webmaster
    {
        private readonly QLBanGiayContext context;
        public DonHangBUS_Webmaster()
        {
            this.context = new QLBanGiayContext();
        }

        public DonHangBUS_Webmaster(QLBanGiayContext context)
        {
            this.context = context;
        }

        public List<DonHang> GetDonHangs()
        {
            List<DonHang> list = context.DonHang.ToList();
            return list;
        }

        public List<DonHang> GetDonHangs(int pagenumber, int pagesize)
        {
            List<DonHang> list = context.DonHang.OrderBy(temp => temp.NgayTao)
                                                  .Skip((pagenumber - 1) * pagesize)
                                                  .Take(pagesize)
                                                  .ToList();
            return list;
        }

        //------------------------------------------------------ THEM SUA XOA -----------------------------------------------------------------

        public string EditDonHang(string MaDonHang, string CMNDNguoiGiao, string TinhTrang, DateTime NgayGiao)
        {
            DonHang DonHang = new DonHang();

            //----------------------- chuan hoa du lieu ----------------------- 
            //----------------------- kiem tra ma -----------------------
            DonHang = context.DonHang.Where(temp => temp.MaDonHang == MaDonHang).SingleOrDefault();

            //----------------------- sua -----------------------

            if (CMNDNguoiGiao != null)
            {
                DonHang.CmndnguoiGiao = CMNDNguoiGiao;
            }
            if (TinhTrang != null) //Đã đặt, Đang giao, Đã thanh toán, Đã huỷ
            {
                DonHang.TinhTrang = TinhTrang;
            }
            if (NgayGiao != null) //Đã đặt, Đang giao, Đã thanh toán, Đã huỷ
            {
                if(NgayGiao > DateTime.Now)
                {
                    return "Ngày giao phải bé hơn hoặc bằng" + DateTime.Now.Date.ToString();
                }
                else
                {
                    DonHang.NgayGiao = NgayGiao;
                }
            }
            //if (TinhTrangDanhGia != null) // --Chưa đánh giá/Đã đánh giá--
            //{
            //    DonHang.TinhTrangDanhGia = TinhTrangDanhGia;
            //}
            context.SaveChanges();
            return "Sửa thành công";
        }

        public List<ChiTietDonHang> GetDetail(string madonhang)
        {
            return context.ChiTietDonHang.Where(ct => ct.IdDonHangNavigation.MaDonHang == madonhang)
                                         .Include(ct => ct.IdDonHangNavigation)
                                         .Include(ct => ct.IdSizeSanPhamNavigation)
                                         .Include(ct => ct.IdSizeSanPhamNavigation.IdSanPhamNavigation)
                                         .Include(ct => ct.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdTaiKhoanNavigation)
                                         .Include(ct => ct.IdSizeSanPhamNavigation.IdSanPhamNavigation.IdHangSanPhamNavigation)
                                         .ToList();
        }


        //------------------------------------------------------ TIM KIEM - SAP XEP -----------------------------------------------------------------

        public List<DonHang> Sort(string sortorder, int pagesize, int pagenumber)
        {
            List<DonHang> list = new List<DonHang>();
            switch (sortorder)
            {
                case "ngaytao-az":
                    {
                        list = context.DonHang
                                          .OrderBy(temp => temp.NgayTao)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                        break;
                    }
                case "ngaytao-za":
                    {
                        list = context.DonHang
                                          .OrderByDescending(temp => temp.NgayTao)
                                          .Skip((pagenumber - 1) * pagesize)
                                          .Take(pagesize)
                                          .ToList();
                        break;
                    }

            }
            return list;
        }
        public List<DonHang> Sort(string sortorder)
        {
            List<DonHang> list = new List<DonHang>();
            switch (sortorder)
            {
                case "ngaytao-az":
                    {
                        list = context.DonHang
                                    .OrderBy(temp => temp.NgayTao)
                                    .ToList();
                        break;
                    }
                case "ngaytao-za":
                    {
                        list = context.DonHang
                                    .OrderByDescending(temp => temp.NgayTao)
                                    .ToList();
                        break;
                    }
            }
            return list;
        }
        public List<DonHang> Search(string search, int pagesize, int pagenumber)
        {
            List<DonHang> list = new List<DonHang>();
            if (search == null)
            {
                list = GetDonHangs(1, pagesize);
            }
            else
            {
                list = context.DonHang.Where(temp => temp.MaDonHang.Contains(search)
                                                        || temp.CmndnguoiGiao.Contains(search)
                                                        || temp.DiaChiGiao.Contains(search)

                                                        || temp.TinhTrangDanhGiaCustomer.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                            .Skip((pagenumber - 1) * pagesize)
                                            .Take(pagesize)
                                            .ToList();
            }
            return list;
        }

        public List<DonHang> Search(string search, int pagesize)
        {
            List<DonHang> list = new List<DonHang>();
            if (search == null)
            {
                list = GetDonHangs(1, pagesize);
            }
            else
            {
                list = context.DonHang.Where(temp => temp.MaDonHang.Contains(search)
                                                        || temp.CmndnguoiGiao.Contains(search)
                                                        || temp.DiaChiGiao.Contains(search)

                                                        || temp.TinhTrangDanhGiaCustomer.Contains(search)
                                                        || temp.TinhTrang.Contains(search))
                                            .ToList();
            }
            return list;
        }

        public List<DonHang> SearchAndSort(string search, string sortorder, int pagesize, int pagenumber)
        {
            List<DonHang> list = new List<DonHang>();
            if (search == null)
            {
                list = GetDonHangs(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "ngaytao-az":
                        list = context.DonHang.Where(temp => temp.MaDonHang.Contains(search)
                                                                || temp.CmndnguoiGiao.Contains(search)
                                                                || temp.DiaChiGiao.Contains(search)

                                                                || temp.TinhTrangDanhGiaCustomer.Contains(search)
                                                                || temp.TinhTrang.Contains(search))
                                                   .Skip((pagenumber - 1) * pagesize)
                                                   .Take(pagesize)
                                                   .OrderBy(temp => temp.NgayTao)
                                                   .ToList();
                        break;
                    case "ngaytao-za":
                        list = context.DonHang.Where(temp => temp.MaDonHang.Contains(search)
                                                                || temp.CmndnguoiGiao.Contains(search)
                                                                || temp.DiaChiGiao.Contains(search)

                                                                || temp.TinhTrangDanhGiaCustomer.Contains(search)
                                                                || temp.TinhTrang.Contains(search))
                                               .Skip((pagenumber - 1) * pagesize)
                                               .Take(pagesize)
                                               .OrderByDescending(temp => temp.NgayTao)
                                               .ToList();
                        break;
                }
            }
            return list;
        }

        public List<DonHang> SearchAndSort(string search, string sortorder, int pagesize)
        {
            List<DonHang> list = new List<DonHang>();
            if (search == null)
            {
                list = GetDonHangs(1, pagesize);
            }
            else
            {
                switch (sortorder)
                {
                    case "ngaytao-az":
                        list = context.DonHang.Where(temp => temp.MaDonHang.Contains(search)
                                                                || temp.CmndnguoiGiao.Contains(search)
                                                                || temp.DiaChiGiao.Contains(search)

                                                                || temp.TinhTrangDanhGiaCustomer.Contains(search)
                                                                || temp.TinhTrang.Contains(search))
                                               .OrderBy(l => l.NgayTao)
                                               .ToList();
                        break;
                    case "ngaytao-za":
                        list = context.DonHang.Where(temp => temp.MaDonHang.Contains(search)
                                                                || temp.CmndnguoiGiao.Contains(search)
                                                                || temp.DiaChiGiao.Contains(search)

                                                                || temp.TinhTrangDanhGiaCustomer.Contains(search)
                                                                || temp.TinhTrang.Contains(search))
                                               .OrderByDescending(l => l.NgayTao)
                                               .ToList();
                        break;
                }
            }
            return list;
        }

    }
}
