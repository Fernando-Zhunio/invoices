
using System.ComponentModel.DataAnnotations;
using invoices.Utils;

namespace invoices.Models
{
    public class TaxAndDiscountInvoice: BaseEntity
    {
        [Required]
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        [Required]
        public int TaxAndDiscountId { get; set; }
        public TaxAndDiscount TaxAndDiscount { get; set; }
    }
}
