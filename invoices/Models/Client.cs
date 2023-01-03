using System.ComponentModel.DataAnnotations;

namespace invoices.Models
{
    public class Client
    {
        public int Id { get; set; }
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
