using invoices.Models;

namespace invoices.DTOs
{
    public class SkuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public Variation Variation { get; set; }
        public List<Attachment> Images { get; set; }
        public string Reference { get; set; }
        public bool IsActive { get; set; }
    }
}
