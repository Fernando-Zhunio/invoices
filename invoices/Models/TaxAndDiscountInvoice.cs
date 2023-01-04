
using System.ComponentModel.DataAnnotations;

namespace invoices.Models
{
    public class TaxAndDiscountInvoice
    {
        [Required]
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        [Required]
        public int TaxAndDiscountId { get; set; }
        public TaxAndDiscount TaxAndDiscount { get; set; }
    }
}
