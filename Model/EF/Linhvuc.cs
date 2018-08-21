namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Linhvuc")]
    public partial class Linhvuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Linhvuc()
        {
            LoaiSanPhams = new HashSet<LoaiSanPham>();
        }

        public int LinhvucID { get; set; }

        [Column("Linhvuc")]
        [StringLength(50)]
        public string Linhvuc1 { get; set; }

        public int? DisplayOrder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoaiSanPham> LoaiSanPhams { get; set; }
    }
}
