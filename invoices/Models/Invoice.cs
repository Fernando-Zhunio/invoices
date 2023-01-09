using System.ComponentModel.DataAnnotations;
using invoices.Utils;

namespace invoices.Models
{
    public class Invoice: BaseEntity
    {
        [Required]
        public float SubTotal { get; set; }
        public List<ItemInvoice> Sku { get; set; }
        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<TaxAndDiscountInvoice> TaxAndDiscounts { get; set; }

    }
}
