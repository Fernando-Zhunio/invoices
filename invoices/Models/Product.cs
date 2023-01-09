using System.ComponentModel.DataAnnotations;
using invoices.Utils;

namespace invoices.Models
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Sku> Sku { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
