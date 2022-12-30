using System.ComponentModel.DataAnnotations;
using invoices.Models;

namespace invoices.DTOs
{
    public class AttachmentCreateDto
    {
        [Required]
        public int SkuId { get; set; }
        public Sku Sku { get; set; }
        public int TypeAttachmentId { get; set; }
        public TypeAttachment TypeAttachment { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
