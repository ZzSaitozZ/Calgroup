namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AliasName { get; set; }

        [Required]
        public string Details { get; set; }

        public bool Status { get; set; }
    }
}
