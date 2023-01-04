using System.ComponentModel.DataAnnotations;

namespace invoices.Dto
{
    public class PriceHistoryCreateSku
    {
        public int Id { get; set; }
        [Required]
        public int SkuId { get; set; }
        [Required]
        public float Price { get; set; }
    }
}