using System.ComponentModel.DataAnnotations;
using invoices.Utils;

namespace invoices.Models
{
    public class Brand: BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
