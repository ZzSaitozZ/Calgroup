namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Library")]
    public partial class Library
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string PDF { get; set; }

        public string AliasName { get; set; }

        public bool Status { get; set; }

        public int IDCategory { get; set; }

        public virtual LibraryCategory LibraryCategory { get; set; }
    }
}
