namespace invoices.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public float SubTotal { get; set; }
        public List<ItemInvoice> Sku { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
