using System.ComponentModel.DataAnnotations;

namespace invoices.DTOs
{
    public class CredentialsUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}