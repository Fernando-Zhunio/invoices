using System.ComponentModel.DataAnnotations;
using invoices.Utils;

namespace invoices.Models
{
    public class PriceHistorySku: BaseEntity
    {
        [Required]
        public int SkuId { get; set; }
        public Sku Sku { get; set; }
        [Required]
        public float Price { get; set; }
    }
}