namespace invoices.Models
{
    public class TaxAndDiscountConditional
    {
        public int Id { get; set; }
        public int TaxAndDiscountId { get; set; }
        public TaxAndDiscount TaxAndDiscount { get; set; }
        public string Type { get; set; }
        public int TypeId { get; set; }
    }
}
