using System.ComponentModel.DataAnnotations;
using invoices.Utils;

namespace invoices.Models
{
    public class Category: BaseEntity
    {
        [Required]
        public string Name { get; set; }

    }
}
