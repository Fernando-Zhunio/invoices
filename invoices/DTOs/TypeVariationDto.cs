using System.ComponentModel.DataAnnotations;

namespace invoices.DTOs
{
    public class TypeVariationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VariationId { get; set; }
        public string Value { get; set; }
    }
}
