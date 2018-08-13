namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Calibration")]
    public partial class Calibration
    {
        public int ID { get; set; }

        public string Detail { get; set; }

        public bool? Status { get; set; }

        public string Category { get; set; }
    }
}
