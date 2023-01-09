using invoices.Utils;

namespace invoices.Models
{
    public class Variation: BaseEntity
    {
        public string Name { get; set; }
        public List<TypeVariation> value { get; set; }

    }
}
