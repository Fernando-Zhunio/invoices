using System.ComponentModel.DataAnnotations;

namespace invoices.DTOs
{
    public class SkuCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string Description { get; set; }
        public int VariationId { get; set; }
        [Required]
        public string Reference { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
