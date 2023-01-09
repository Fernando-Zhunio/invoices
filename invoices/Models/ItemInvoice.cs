using invoices.Utils;

namespace invoices.Models
{
    public class ItemInvoice: BaseEntity
    {
        public int SkuId { get; set; }
        public Sku Sku { get; set; }
        public int Quantity { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
