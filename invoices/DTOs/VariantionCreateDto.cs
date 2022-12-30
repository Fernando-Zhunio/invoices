using System.ComponentModel.DataAnnotations;
using invoices.Models;

namespace invoices.DTOs
{
    public class VariationCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public List<TypeVariation> value { get; set; }
    }
}
