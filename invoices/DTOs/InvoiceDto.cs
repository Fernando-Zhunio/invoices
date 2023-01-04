
namespace invoices.DTOs
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public float SubTotal { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
