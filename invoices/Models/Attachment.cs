using System.ComponentModel.DataAnnotations;
using invoices.Utils;

namespace invoices.Models
{
    public class Attachment: BaseEntity
    {
        [Required]
        public int SkuId { get; set; }
        public Sku Sku { get; set; }
        [Required]
        public int TypeAttachmentId { get; set; }
        public TypeAttachment TypeAttachment { get; set; }
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }

    }
}
