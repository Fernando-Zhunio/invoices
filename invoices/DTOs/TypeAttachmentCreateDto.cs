using System.ComponentModel.DataAnnotations;

namespace invoices.DTOs
{
    public class TypeAttachmentCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
