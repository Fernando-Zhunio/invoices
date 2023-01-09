using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using invoices.Utils;

namespace invoices.Models
{
    public class Sku: BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [ForeignKey("AttachmentId")]
        public int ImagesId { get; set; }
        public List<Attachment> Images { get; set; }
        [Required]
        public float Price { get; set; }
        public List<PriceHistorySku> Prices { get; set; }
        public string Description { get; set; }
        public int? VariationId { get; set; }
        public Variation Variation { get; set; }
        [Required]
        public string Reference { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
