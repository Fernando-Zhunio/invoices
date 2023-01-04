using System.ComponentModel.DataAnnotations;
using invoices.Models;

namespace invoices.DTOs
{
    public class InvoiceCreateDto
    {
        [Required]
        public float SubTotal { get; set; }
        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
