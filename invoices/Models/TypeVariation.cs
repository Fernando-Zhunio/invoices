using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using invoices.Utils;

namespace invoices.Models
{
    public class TypeVariation: BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public int VariationId { get; set; }
        public Variation Variation { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Value { get; set; }
    }

}
