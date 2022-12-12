namespace invoices.Models
{
    public class TaxAndDiscount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal value { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }       
        public List<TaxAndDiscountConditional> taxAndDiscountConditionals { get; set; }
    }
}
