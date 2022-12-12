namespace invoices.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public Sku Sku { get; set; }
        public int Stock { get; set; }
    }
}
