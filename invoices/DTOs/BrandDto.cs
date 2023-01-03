using System.ComponentModel.DataAnnotations;

namespace invoices.DTOs
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}