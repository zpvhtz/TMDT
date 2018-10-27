using System;
using System.Collections.Generic;

namespace Models.Database
{
    public partial class GiaShip
    {
        public Guid Id { get; set; }
        public string Loai { get; set; }
        public double? Gia { get; set; }
        public DateTime? NgayCapNhat { get; set; }
    }
}
