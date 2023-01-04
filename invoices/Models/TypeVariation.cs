using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace invoices.Models
{
    public class TypeVariation
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int VariationId { get; set; }
        public Variation Variation { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Value { get; set; }
    }

}
