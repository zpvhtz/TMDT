namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaShip")]
    public partial class GiaShip
    {
        public Guid Id { get; set; }

        [StringLength(20)]
        public string Loai { get; set; }

        public double? Gia { get; set; }

        public DateTime? NgayCapNhat { get; set; }
    }
}
