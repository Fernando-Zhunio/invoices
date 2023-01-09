using System.ComponentModel.DataAnnotations;
using invoices.interfaces;
using invoices.Utils;

namespace invoices.DTOs
{
    public class BrandDto: IBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Id { get; set; }
        public DateTime CreatedDate  { get; set; }
        public DateTime? ModifiedDate  { get; set; }
    }
}