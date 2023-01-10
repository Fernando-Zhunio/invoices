namespace invoices.DTOs
{
    public class ResponseRegisteAuth
    {
        public string token { get; set; }
        public dynamic expiration { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }
}