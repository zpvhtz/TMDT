﻿using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class TrangQuangCao
    {
        public TrangQuangCao()
        {
            ViTriQuangcao = new HashSet<ViTriQuangcao>();
        }

        public Guid Id { get; set; }
        public string MaTrang { get; set; }
        public string TenTrang { get; set; }
        public string ChuThich { get; set; }
        public string TinhTrang { get; set; }

        public ICollection<ViTriQuangcao> ViTriQuangcao { get; set; }
    }
}
