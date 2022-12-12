namespace invoices.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TypeDoc { get; set; }
        public string Doc { get; set; }
        public Address Address { get; set; }
    }
}
