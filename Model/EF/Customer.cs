namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Adress { get; set; }

        public string Comment { get; set; }
    }
}
