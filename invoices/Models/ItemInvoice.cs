namespace invoices.Models
{
    public class ItemInvoice
    {
        public int Id { get; set; }
        public Sku product { get; set; }
        public int quantity { get; set; }

    }
}
