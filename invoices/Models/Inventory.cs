using invoices.Utils;

namespace invoices.Models
{
    public class Inventory: BaseEntity
    {
        public int SkuId { get; set; }
        public Sku Sku { get; set; }
        public int Stock { get; set; }
    }
}
