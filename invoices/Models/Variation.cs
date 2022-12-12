namespace invoices.Models
{
    public class Variation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TypeVariation> value { get; set; }

    }
}
