using System.ComponentModel.DataAnnotations;
using invoices.Models;

namespace invoices.DTOs
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public int SkuId { get; set; }
        public int Stock { get; set; }
    }
}
