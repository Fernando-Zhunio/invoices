using invoices.interfaces;

namespace invoices.Utils
{
    public class BaseEntity: IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get;set;}
    }
}