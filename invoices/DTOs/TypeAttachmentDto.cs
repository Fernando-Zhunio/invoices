using System.ComponentModel.DataAnnotations;
using invoices.Models;

namespace invoices.DTOs
{
    public class TypeAttachmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
