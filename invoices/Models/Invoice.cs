namespace invoices.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public float SubTotal { get; set; }
        public List<ItemInvoice> Sku { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
