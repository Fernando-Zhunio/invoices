using System.ComponentModel.DataAnnotations;

namespace invoices.DTOs
{
    public class RegisterUserDto: CredentialsUserDto
    {
        public string Name { get; set; }
    }
}