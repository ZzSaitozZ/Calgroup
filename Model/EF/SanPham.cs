namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Key]
        [StringLength(50)]
        public string Alias { get; set; }

        public string Name { get; set; }

        public int? CatID { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        public string ImageLink { get; set; }

        public string ImageLinkDetail { get; set; }

        public string ManualLink { get; set; }

        public string Detail { get; set; }

        public string Specification { get; set; }

        [StringLength(50)]
        public string Price { get; set; }

        public int? Hot { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
