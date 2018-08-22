namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoiTac")]
    public partial class DoiTac
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }
    }
}
