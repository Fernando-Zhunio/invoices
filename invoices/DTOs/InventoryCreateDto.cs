using System.ComponentModel.DataAnnotations;

namespace invoices.DTOs
{
    public class InventoryCreateDto
    {
         public int Id { get; set; }
        [Required]
        public int SkuId { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}