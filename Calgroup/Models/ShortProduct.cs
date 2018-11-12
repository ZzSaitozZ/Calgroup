using System.ComponentModel.DataAnnotations;

namespace Calgroup.Models
{
    public class ShortProduct
    {
        public string Category { get; set; }
        [Key]
        public string Alias { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string ImageLink { get; set; }
    }
}