using System.ComponentModel.DataAnnotations;

namespace invoices.DTOs
{
    public class TypeVariationCreateDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int VariationId { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
