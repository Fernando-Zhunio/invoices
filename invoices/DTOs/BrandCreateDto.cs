using System.ComponentModel.DataAnnotations;

namespace invoices.DTOs
{
    public class BrandCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}