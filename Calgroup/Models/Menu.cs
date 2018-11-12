using System.ComponentModel.DataAnnotations;

namespace Calgroup.Models
{
    public class Menu
    {
        public string Linhvuc { get; set; }
        public string Category { get; set; }
        [Key]
        public string AliasCat { get; set; }
    }
}