using System.ComponentModel.DataAnnotations;

namespace invoices.Models
{
    public class PriceHistorySku
    {
        public int Id { get; set; }
        [Required]
        public int SkuId { get; set; }
        public Sku Sku { get; set; }
        [Required]
        public float Price { get; set; }
    }
}