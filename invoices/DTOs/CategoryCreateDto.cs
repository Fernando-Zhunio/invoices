using System.ComponentModel.DataAnnotations;

namespace invoices.DTOs
{
    public class CategoryCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}