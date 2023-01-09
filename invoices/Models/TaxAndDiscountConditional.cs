using invoices.Utils;

namespace invoices.Models
{
    public class TaxAndDiscountConditional: BaseEntity
    {
        public int TaxAndDiscountId { get; set; }
        public TaxAndDiscount TaxAndDiscount { get; set; }
        public string Type { get; set; }
        public int TypeId { get; set; }
    }
}
