using System;
using System.Collections.Generic;

namespace Models
{
    public partial class TinhThanh
    {
        public TinhThanh()
        {
            DiaChi = new HashSet<DiaChi>();
        }

        public Guid Id { get; set; }
        public string MaTinhThanh { get; set; }
        public string TenTinhThanh { get; set; }

        public ICollection<DiaChi> DiaChi { get; set; }
    }
}
