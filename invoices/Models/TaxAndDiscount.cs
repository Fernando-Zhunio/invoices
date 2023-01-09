using System.ComponentModel.DataAnnotations;
using invoices.Utils;

namespace invoices.Models
{
    public class TaxAndDiscount: BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public float value { get; set; }
        public bool IsPercentage { get; set; } = true;
        [Required]
        public TaxAndDiscountType Type { get; set; }
        public bool IsActive { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }       
        public List<TaxAndDiscountConditional> taxAndDiscountConditionals { get; set; }
        public List<TaxAndDiscountInvoice> Invoices { get; set; }
    }

    public enum TaxAndDiscountType
    {
        Tax,
        Discount
    }
}
