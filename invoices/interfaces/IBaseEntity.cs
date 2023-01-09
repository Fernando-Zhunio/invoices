namespace invoices.interfaces
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get;set;}
    }
}