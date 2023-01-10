using System.ComponentModel.DataAnnotations;

namespace invoices.DTOs
{
    public class RegisterUserDto: CredentialsUserDto
    {
        [Required]
        public string Name { get; set; }
    }
}