namespace invoices.DTOs
{
    public class ItemInvoiceCreateDto
    {
        public int Id { get; set; }
        public int SkuId { get; set; }
        public int Quantity { get; set; }
    }
}
