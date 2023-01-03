using System.ComponentModel.DataAnnotations;
using invoices.Models;

namespace invoices.DTOs
{
    public class ClientCreateDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TypeDoc { get; set; }
        public string Doc { get; set; }

    }
}