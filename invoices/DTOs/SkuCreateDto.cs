using System.ComponentModel.DataAnnotations;

namespace invoices.DTOs
{
    public class SkuCreateDto
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int VariationId { get; set; }
        public string Reference { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
