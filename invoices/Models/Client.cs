using System.ComponentModel.DataAnnotations;
using invoices.Utils;

namespace invoices.Models
{
    public class Client: BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string TypeDoc { get; set; }
        [Required]
        public string Doc { get; set; }
        [Required]
        public List<Address> Addresses { get; set; }
    }
}
