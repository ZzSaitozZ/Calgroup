namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Staff
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public bool? Role { get; set; }

        [StringLength(50)]
        public string Skype { get; set; }

        [StringLength(50)]
        public string Zalo { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public string Image { get; set; }

        public bool? Status { get; set; }
    }
}
